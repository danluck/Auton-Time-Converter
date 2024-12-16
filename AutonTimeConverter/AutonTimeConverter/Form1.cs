using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
//using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutonTimeConverter
{
	public partial class Form1 : Form
	{
		// One byte symbols length
		private const UInt32 BYTE_SYMBOLS_COUNT = 2;

		// DateTime
		const UInt32 EXPECTED_DATE_TIME_BYTE_LENGTH = 4;
		const UInt32 EXPECTED_DATE_TIME_LENGTH =
			EXPECTED_DATE_TIME_BYTE_LENGTH * BYTE_SYMBOLS_COUNT;

		// ClassId
		const UInt32 EXPECTED_CLASS_ID_BYTE_LENGTH = 2;
		const UInt32 EXPECTED_CLASS_ID_LENGTH =
			EXPECTED_CLASS_ID_BYTE_LENGTH * BYTE_SYMBOLS_COUNT;

        // Temperature Текущая температура (0.01С) int16
        const UInt32 EXPECTED_TEMPERATURE_BYTE_LENGTH = 2;
        const UInt32 EXPECTED_TEMPERATURE_LENGTH =
            EXPECTED_TEMPERATURE_BYTE_LENGTH * BYTE_SYMBOLS_COUNT;

        // Temperature Cчетчик изменений состояния технологического процесса uint32
        const UInt32 EXPECTED_STATE_CHANGE_COUNTER_BYTE_LENGTH = 4;
        const UInt32 EXPECTED_STATE_CHANGE_COUNTER_LENGTH =
            EXPECTED_STATE_CHANGE_COUNTER_BYTE_LENGTH * BYTE_SYMBOLS_COUNT;

        // Float
        const UInt32 EXPECTED_FLOAT_BYTE_LENGTH = 4;
        const UInt32 EXPECTED_FLOAT_LENGTH = EXPECTED_FLOAT_BYTE_LENGTH * BYTE_SYMBOLS_COUNT;

        // int32_t
        const UInt32 EXPECTED_INT32_BYTE_LENGTH = 4;
        const UInt32 EXPECTED_INT32_LENGTH =
            EXPECTED_INT32_BYTE_LENGTH * BYTE_SYMBOLS_COUNT;

        // uint8_t
        const UInt32 EXPECTED_UINT8_BYTE_LENGTH = 1;
        const UInt32 EXPECTED_UINT8_LENGTH =
            EXPECTED_UINT8_BYTE_LENGTH * BYTE_SYMBOLS_COUNT;
        const UInt32 EXPECTED_INT8_LENGTH = EXPECTED_UINT8_LENGTH;

		// uint16_t
		const UInt32 EXPECTED_UINT16_BYTE_LENGTH = 2;
        const UInt32 EXPECTED_UINT16_LENGTH = 
			EXPECTED_UINT16_BYTE_LENGTH * BYTE_SYMBOLS_COUNT;
		const UInt32 EXPECTED_INT16_LENGTH = EXPECTED_UINT16_LENGTH;

		// 		const UInt32 LOCATION_ID_BYTE_LENGTH = 8;
		// 		const UInt32 LOCATION_ID_LENGTH = 
		// 			LOCATION_ID_BYTE_LENGTH * BYTE_SYMBOLS_COUNT;

		public Form1()
		{
			InitializeComponent();
			ClearEventOutput();
            checkBoxCapture.Checked = true;

			openFileDialog1 = new OpenFileDialog();
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			DoDecimalConvertion();
		}

		private void textBoxHex_TextChanged(object sender, EventArgs e)
		{
			DoHexConvertion();
		}

		private void DoDecimalConvertion()
		{
			UInt32 time = 0;
			try
			{
				time = Convert.ToUInt32(textBoxDecimal.Text);
			}
			catch (System.Exception ex)
			{

			}

			ShowSecons(time);
		}

		// Initial format: Little Endian (DCBA), minimum 4 symbols
		private UInt32 GetUint32FromString(string text)
		{
			UInt32 number = 0;
			try
			{
				number = Convert.ToUInt32(text, 16);
			}
			catch (System.Exception ex)
			{
			}

			byte[] sourceBytes = BitConverter.GetBytes(number);
			if (sourceBytes.Length == EXPECTED_DATE_TIME_BYTE_LENGTH)
			{
				// Convert to Little Endian (DCBA)
				var resultBytes = new byte[EXPECTED_DATE_TIME_BYTE_LENGTH];
				resultBytes[0] = sourceBytes[3];
				resultBytes[1] = sourceBytes[2];
				resultBytes[2] = sourceBytes[1];
				resultBytes[3] = sourceBytes[0];

				UInt32 result = BitConverter.ToUInt32(resultBytes, 0);
				Console.WriteLine("result={0}", result);
				return result;
			}

			return 0;
		}

        private Int32 GetInt32FromString(string text)
        {
			Console.WriteLine($"text={text}");
			UInt32 number = 0;
            try
            {
                number = Convert.ToUInt32(text, 16);
            }
            catch (System.Exception ex)
            {
            }

            byte[] sourceBytes = BitConverter.GetBytes(number);
            if (sourceBytes.Length == EXPECTED_DATE_TIME_BYTE_LENGTH)
            {
                // Convert to Little Endian (DCBA)
                var resultBytes = new byte[EXPECTED_DATE_TIME_BYTE_LENGTH];
                resultBytes[0] = sourceBytes[3];
                resultBytes[1] = sourceBytes[2];
                resultBytes[2] = sourceBytes[1];
                resultBytes[3] = sourceBytes[0];

                Int32 result = BitConverter.ToInt32(resultBytes, 0);
                Console.WriteLine("result={0}", result);
                return result;
            }

            return 0;
        }

        private float GetFloatFromString(string text)
        {
            UInt32 number = 0;
            try
            {
                number = Convert.ToUInt32(text, 16);
            }
            catch (System.Exception ex)
            {
            }

            byte[] sourceBytes = BitConverter.GetBytes(number);
            if (sourceBytes.Length == EXPECTED_DATE_TIME_BYTE_LENGTH)
            {
                // Convert to Little Endian (DCBA)
                var resultBytes = new byte[EXPECTED_DATE_TIME_BYTE_LENGTH];
                resultBytes[0] = sourceBytes[3];
                resultBytes[1] = sourceBytes[2];
                resultBytes[2] = sourceBytes[1];
                resultBytes[3] = sourceBytes[0];

                float result = BitConverter.ToSingle(resultBytes, 0);
                Console.WriteLine("result={0}", result);
                return result;
            }

            return 0;
        }

        private byte GetUint8FromString(string text)
        {
            byte value = 0;
            try
            {
                value = Convert.ToByte(text, 16);
            }
            catch (System.Exception ex)
            {
            }
            return value;
        }

        private sbyte GetInt8FromString(string text)
        {
            sbyte value = 0;
            try
            {
                value = Convert.ToSByte(text, 16);
            }
            catch (System.Exception ex)
            {
            }
            return value;
        }

		private UInt16 GetUint16FromString(string text)
		{
			UInt16 classId = 0;
			UInt16 eventId = 0;
			try
			{
				classId = Convert.ToUInt16(text, 16);
			}
			catch (System.Exception ex)
			{
			}

			byte[] sourceBytes = BitConverter.GetBytes(classId);
			Console.WriteLine("sourceBytes.Length={0}", sourceBytes.Length);
			if (sourceBytes.Length == EXPECTED_CLASS_ID_BYTE_LENGTH)
			{
				// Convert to Little Endian (DCBA)
				var resultBytes = new byte[EXPECTED_CLASS_ID_BYTE_LENGTH];
				resultBytes[0] = sourceBytes[1];
				resultBytes[1] = sourceBytes[0];

				eventId = BitConverter.ToUInt16(resultBytes, 0);
				Console.WriteLine("result={0}", eventId);
			}

			return eventId;
		}

        private Int16 GetInt16FromString(string text)
        {
            UInt16 classId = 0;
            Int16 eventId = 0;
            try
            {
                classId = Convert.ToUInt16(text, 16);
            }
            catch (System.Exception ex)
            {
            }

            byte[] sourceBytes = BitConverter.GetBytes(classId);
            Console.WriteLine("sourceBytes.Length={0}", sourceBytes.Length);
            if (sourceBytes.Length == EXPECTED_CLASS_ID_BYTE_LENGTH)
            {
                // Convert to Little Endian (DCBA)
                var resultBytes = new byte[EXPECTED_CLASS_ID_BYTE_LENGTH];
                resultBytes[0] = sourceBytes[1];
                resultBytes[1] = sourceBytes[0];

                eventId = BitConverter.ToInt16(resultBytes, 0);
                Console.WriteLine("result={0}", eventId);
            }

            return eventId;
        }

        private void DoHexConvertion()
		{
			Console.WriteLine("textBoxHex.Text.Length={0}", textBoxHex.Text.Length);
			int expectedLength = (int)(EXPECTED_DATE_TIME_BYTE_LENGTH * BYTE_SYMBOLS_COUNT);
			if (textBoxHex.Text.Length == expectedLength)
			{
				string text = textBoxHex.Text.Substring(0, expectedLength);
				ShowSecons(GetUint32FromString(text));
			}
		}

		private DateTime GetActualDateTime(UInt32 autonTimeSeconds)
		{
			DateTime dateTime = new DateTime(1980, 1, 1);
			dateTime = dateTime.AddSeconds(autonTimeSeconds);
			return dateTime;
		}

		/// <summary>
		/// Show time as string
		/// </summary>
		/// <param name="seconds">Seconds from 1980</param>
		private void ShowSecons(UInt32 seconds)
		{
			textBox2.Text = GetActualDateTime(seconds).ToString();
		}

        private void AddHistory(string text)
        {
			if (!_isInputFileOpened)
			{
				richTextBoxHistory.Text += text + "\t";
			}
        }

        private void AddFloatValueToForm(string inputString, int startIndexPositionData, string name)
        {
            string data0 = inputString.Substring(
                startIndexPositionData, (int)EXPECTED_FLOAT_LENGTH);
            float dataValue = GetFloatFromString(data0);
			if (!_isInputFileOpened)
			{
				richTextBoxCommon.Text += name + "=";
				richTextBoxCommon.Text += dataValue.ToString() + "\r\n";
			}
            AddHistory(dataValue.ToString());
			AddToOutputString(dataValue);
		}
        private byte AddUint8ToForm(string inputString,
            int startIndexPositionData, string name, string delimiter = "\r\n")
        {
            string data0 = inputString.Substring(
                startIndexPositionData, (int)EXPECTED_UINT8_LENGTH);
            byte dataValue = GetUint8FromString(data0);
            if (!_isInputFileOpened)
            {
                richTextBoxCommon.Text += name + "=";
                richTextBoxCommon.Text += dataValue.ToString() + delimiter;
            }
            AddHistory(dataValue.ToString());
            AddToOutputString(dataValue);
            return dataValue;
        }

        private void AddRadarModuleParamsToForm(string inputString,
            int startIndexPositionData, string name, string delimiter = "\r\n")
        {
			string data0 = inputString.Substring(
                startIndexPositionData, (int)EXPECTED_INT8_LENGTH);
            var signalQuality = GetInt8FromString(data0);
            if (!_isInputFileOpened)
            {
                richTextBoxCommon.Text += name + "\r\n";
                richTextBoxCommon.Text += "\tSignalQuality=";
				richTextBoxCommon.Text += signalQuality.ToString() + delimiter;
            }
            AddHistory(signalQuality.ToString());
            AddToOutputString(signalQuality);

            startIndexPositionData += (int)EXPECTED_INT8_LENGTH;
            string data1 = inputString.Substring(
                startIndexPositionData, (int)EXPECTED_INT8_LENGTH);
            var thresholdValue = GetInt8FromString(data1);
            if (!_isInputFileOpened)
            {
                richTextBoxCommon.Text += "\tThresholdValue=";
                richTextBoxCommon.Text += thresholdValue.ToString() + delimiter;
            }
            AddHistory(thresholdValue.ToString());
            AddToOutputString(thresholdValue);

			// Options: MaxProfile : 3, PeakSortingMode : 1, ThresholdType : 1, CloseRangeLeakageCancellation : 1
			startIndexPositionData += (int)EXPECTED_INT8_LENGTH;
            string data2 = inputString.Substring(
                startIndexPositionData, (int)EXPECTED_UINT8_LENGTH);
            var options = GetUint8FromString(data2);
            if (!_isInputFileOpened)
            {
                richTextBoxCommon.Text += "\tOptions=";
                richTextBoxCommon.Text += options.ToString() + delimiter;
            }
            AddHistory(options.ToString());
            AddToOutputString(options);
		}

		private void AddUint16ToForm(string inputString, 
			int startIndexPositionData, string name, string delimiter = "\r\n")
		{
			string data0 = inputString.Substring(
				startIndexPositionData, (int)EXPECTED_UINT16_LENGTH);
			UInt16 dataValue = GetUint16FromString(data0);
			if (!_isInputFileOpened)
			{
				richTextBoxCommon.Text += name + "=";
				richTextBoxCommon.Text += dataValue.ToString() + delimiter;
			}
			AddHistory(dataValue.ToString());
			AddToOutputString(dataValue);
		}

		private void AddInt16ToForm(string inputString,
			int startIndexPositionData, string name, string delimiter = "\r\n")
		{
			string data0 = inputString.Substring(
				startIndexPositionData, (int)EXPECTED_UINT16_LENGTH);
			Int16 dataValue = GetInt16FromString(data0);
			if (!_isInputFileOpened)
			{
				richTextBoxCommon.Text += name + "=";
				richTextBoxCommon.Text += dataValue.ToString() + delimiter;
			}
			AddHistory(dataValue.ToString());
			AddToOutputString(dataValue);
		}

		private void AddInt32ToForm(string inputString,
			int startIndexPositionData, string name, string delimiter = "\r\n")
		{
			string data0 = inputString.Substring(
				startIndexPositionData, (int)EXPECTED_INT32_LENGTH);
			int dataValue = GetInt32FromString(data0);
			if (!_isInputFileOpened)
			{
				richTextBoxCommon.Text += name + "=";
				richTextBoxCommon.Text += dataValue.ToString() + delimiter;
			}
			AddHistory(dataValue.ToString());
			AddToOutputString(dataValue);
		}

		private string _outputString;
		private void ResetOutputString()
		{
			_outputString = "";
		}
		private void AddToOutputString(string text)
		{
			_outputString += text;
		}
		private void AddToOutputString(object anyObject)
		{
			_outputString += anyObject.ToString() + " ; ";
		}

		private void ProcessInputString(string inputString)
		{
			ResetOutputString();

			var length = inputString.Length;
			if (length % BYTE_SYMBOLS_COUNT == 0 &&
				length >= EXPECTED_CLASS_ID_LENGTH)
			{
				labelStatus.Text = "Ok";
				AddHistory(inputString);
				UInt16 eventId = 0;
				try
				{
					string classIdString =
						inputString.Substring(
							0, (int)EXPECTED_CLASS_ID_LENGTH);
					eventId = GetUint16FromString(classIdString);
					AddToOutputString(eventId);
				}
				catch (System.Exception ex) { }

				if (eventId != 0)
				{
					AddHistory(eventId.ToString());
					textBoxClassId.Text = eventId.ToString();
					int startIndexPositionData = 0;

                    const ushort EVENT_ID_RANGE_START = 16000;
                    if (eventId > EVENT_ID_RANGE_START)
                    {
                        if (length >= (EXPECTED_CLASS_ID_LENGTH + EXPECTED_DATE_TIME_LENGTH))
                        {
                            int startIndexPosition = (int)EXPECTED_CLASS_ID_LENGTH;
                            string dateTimeString =
                                inputString.Substring(
                                    startIndexPosition, (int)EXPECTED_DATE_TIME_LENGTH);
                            Console.WriteLine("dateTimeString={0}", dateTimeString);
                            startIndexPositionData = (int)
                                (EXPECTED_CLASS_ID_LENGTH + EXPECTED_DATE_TIME_LENGTH);

                            UInt32 time = GetUint32FromString(dateTimeString);
                            DateTime dateTime = GetActualDateTime(time);
                            textBoxDateTimeString.Text = dateTime.ToString();
                            AddToOutputString(dateTime);
                            AddHistory(dateTime.ToString());
                        }
                    }

                    const UInt16 A125MeasureSettings = 125;

					const UInt16 LorawanDownlinkErrorEventId = 17023;
					const UInt16 ConcentrationMeasureErrorEventId = 17200;
					const UInt16 TimeCorruptWarningEventId = 18004;

					const UInt16 DeviceStateEventId = 19003;

					const UInt16 ProcessStartedEventId = 19007;
					const UInt16 WasChangedEventId = 19008;

					const UInt16 RadarRawSignalInformationEventId = 19120;

					const UInt16 DistanceMeasureEventId = 22125;

					const UInt16 ConcentrationMeasureEventEventEventId = 22205;

					const UInt16 CurrentResultEventId = 22405;
					const UInt16 Current03ResultEventId = 22406;

					const UInt16 DiscontinuousMonitoringEventEventId = 22550;

					const UInt16 TemperatureMonitoringEventEventId = 22557;

					const UInt16 TemperatureEventId = 22820;
					const UInt16 PressureEventId = 22821;
					const UInt16 PressureTemperatureEventId = 22822;

                    const int MonitoringSettingsLengthBytes = 44;

					switch (eventId)
					{
                        case A125MeasureSettings:
                            {
                                textBoxEventName.Text = "A125MeasureSettings";

								// Skip MonitoringProcessSettings
								startIndexPositionData += (MonitoringSettingsLengthBytes * 2);
                                AddFloatValueToForm(inputString, startIndexPositionData, "MinDistance");
                                startIndexPositionData += (int)EXPECTED_FLOAT_LENGTH;
								AddFloatValueToForm(inputString, startIndexPositionData, "MaxDistance");
                                startIndexPositionData += (int)EXPECTED_FLOAT_LENGTH;

                                AddUint8ToForm(inputString, startIndexPositionData, "AccuracyMm");
                                startIndexPositionData += (int)EXPECTED_UINT8_LENGTH;

                                AddUint16ToForm(inputString, startIndexPositionData, "MaxDistanceSpeedMmPerHour");
                                startIndexPositionData += (int)EXPECTED_UINT16_LENGTH;

                                AddUint8ToForm(inputString, startIndexPositionData, "AlgorithmId");
                                startIndexPositionData += (int)EXPECTED_UINT8_LENGTH;

								// Skip RadarModuleParams StageParams[2]
								AddRadarModuleParamsToForm(inputString, startIndexPositionData, "Stage0");
								startIndexPositionData += (3 * 2);
                                AddRadarModuleParamsToForm(inputString, startIndexPositionData, "Stage1");
                                startIndexPositionData += (3 * 2);

								// Options
								byte optionsValue = AddUint8ToForm(inputString, startIndexPositionData, 
                                    "Options");
                                bool reflectorShape = (optionsValue & 0x1) != 0;
                                bool evaluateOnlyReliablePeaks = (optionsValue & 0x2) != 0;
                                bool removeFalsePeak = (optionsValue & 0x4) != 0;
								bool setAccuracyAtFirstStage = (optionsValue & 0x8) != 0;
                                bool increaseCalibrationNoisePointsNum = (optionsValue & 0x10) != 0;
								string optionsString = $"\t reflectorShape={reflectorShape},\r\n" +
                                                       $"\t evaluateOnlyReliablePeaks={evaluateOnlyReliablePeaks},\r\n" +
                                                       $"\t removeFalsePeak={removeFalsePeak},\r\n" +
                                                       $"\t setAccuracyAtFirstStage={setAccuracyAtFirstStage},\r\n" +
                                                       $"\t increaseCalibrationNoisePointsNum={increaseCalibrationNoisePointsNum}\r\n";
								richTextBoxCommon.Text += optionsString;

								startIndexPositionData += (int)EXPECTED_UINT8_LENGTH;
							}
							break;

						case LorawanDownlinkErrorEventId:
							{
								textBoxEventName.Text = "LorawanDownlinkErrorEvent";
								var dataErrorCode = inputString.Substring(
									startIndexPositionData, (int)EXPECTED_INT32_LENGTH);
								int errorCode = GetInt32FromString(dataErrorCode);
								richTextBoxCommon.Text += "ErrorCode=";
								richTextBoxCommon.Text += errorCode.ToString();
								AddHistory(errorCode.ToString());
							}
							break;
						case ConcentrationMeasureErrorEventId:
							{
								textBoxEventName.Text = "ConcentrationMeasureErrorEvent";
								var dataErrorCode = inputString.Substring(
									startIndexPositionData, (int)EXPECTED_INT32_LENGTH);
								int errorCode = GetInt32FromString(dataErrorCode);
								richTextBoxCommon.Text += "ErrorCode=";
								richTextBoxCommon.Text += errorCode.ToString();
								AddHistory(errorCode.ToString());
							}
							break;

						case TimeCorruptWarningEventId:
							textBoxEventName.Text = "TimeCorruptWarningEvent";
							break;

						case DeviceStateEventId:
							textBoxEventName.Text = "DeviceStateEvent";
							string dataBattery = inputString.Substring(
								startIndexPositionData, (int)EXPECTED_UINT16_LENGTH);
							UInt16 battery = GetUint16FromString(dataBattery);
							richTextBoxCommon.Text += "Battery=";
							richTextBoxCommon.Text += battery.ToString() + "\r\n";
							AddHistory(battery.ToString());

							startIndexPositionData += (int)EXPECTED_UINT16_LENGTH;
							string dataSignal = inputString.Substring(
								startIndexPositionData, (int)EXPECTED_UINT16_LENGTH);
							UInt16 signal = GetUint16FromString(dataSignal);
							richTextBoxCommon.Text += "Signal=";
							richTextBoxCommon.Text += signal.ToString();
							AddHistory(signal.ToString());
							break;

						case ProcessStartedEventId:
							textBoxEventName.Text = "ProcessStartedEvent";
							break;
						case WasChangedEventId:
							textBoxEventName.Text = "WasChangedEvent";

							// It's event-container
							// #TODO check string length
							groupBoxWasChangedEvent.Enabled = true;
							string classIdString = inputString.Substring(
								startIndexPositionData, (int)EXPECTED_CLASS_ID_LENGTH);
							Console.WriteLine("classIdString={0}", classIdString);
							UInt16 containeredClassId = GetUint16FromString(classIdString);
							textBoxWasChangedEventContainerClassId.Text = containeredClassId.ToString();
							break;

						case RadarRawSignalInformationEventId:
							textBoxEventName.Text = "RadarRawSignalInformationEvent";

							// Gain
							AddUint16ToForm(inputString, startIndexPositionData, "Gain");
							startIndexPositionData += (int)EXPECTED_UINT16_LENGTH;

							// Peaks[10]
							// uint16_t DistanceMm;
							// int16_t Amplitude;
							for (int i = 0; i < 10; i++)
							{
								// DistanceMm
								AddUint16ToForm(inputString, startIndexPositionData, "DistanceMm", ", ");
								startIndexPositionData += (int)EXPECTED_UINT16_LENGTH;

								// Amplitude
								AddInt16ToForm(inputString, startIndexPositionData, "Amplitude");
								startIndexPositionData += (int)EXPECTED_INT16_LENGTH;
							}
							break;

						case DistanceMeasureEventId:
							textBoxEventName.Text = "DistanceMeasureEvent";
							AddFloatValueToForm(inputString, startIndexPositionData, "Distance");
							break;

						case ConcentrationMeasureEventEventEventId:
							textBoxEventName.Text = "ConcentrationMeasureEvent";
							AddFloatValueToForm(inputString, startIndexPositionData, "Concentration");

							startIndexPositionData += (int)EXPECTED_FLOAT_LENGTH;
							string data1 = inputString.Substring(
								startIndexPositionData, (int)EXPECTED_INT32_LENGTH);
							int cas = GetInt32FromString(data1);
							richTextBoxCommon.Text += "Cas=";
							richTextBoxCommon.Text += cas.ToString();
							AddHistory(cas.ToString());
							break;

						case CurrentResultEventId:
							textBoxEventName.Text = "CurrentResultEvent";
							AddFloatValueToForm(inputString, startIndexPositionData, "Current");
							break;

						case Current03ResultEventId:
							textBoxEventName.Text = "Current03ResultEvent";
							AddFloatValueToForm(inputString, startIndexPositionData, "CurrentA");

							startIndexPositionData += (int)EXPECTED_FLOAT_LENGTH;
							AddFloatValueToForm(inputString, startIndexPositionData, "CurrentB");

							startIndexPositionData += (int)EXPECTED_FLOAT_LENGTH;
							AddFloatValueToForm(inputString, startIndexPositionData, "CurrentC");
							break;

						case DiscontinuousMonitoringEventEventId:
							textBoxEventName.Text = "DiscontinuousMonitoringEvent";
							string dataString = inputString.Substring(
								startIndexPositionData, (int)EXPECTED_STATE_CHANGE_COUNTER_LENGTH);
							UInt32 data = GetUint32FromString(dataString);
							richTextBoxCommon.Text += "StateChangedCounter=";
							richTextBoxCommon.Text += data.ToString();
							AddHistory(data.ToString());
							break;

						case TemperatureMonitoringEventEventId:
						case TemperatureEventId:
							textBoxEventName.Text = "Temperature";
							string temperatureDataString = inputString.Substring(
								startIndexPositionData, (int)EXPECTED_TEMPERATURE_LENGTH);
							Int16 temperature = GetInt16FromString(temperatureDataString);
							richTextBoxCommon.Text += "temperature 0.01°C=";
							richTextBoxCommon.Text += temperature.ToString();
							AddHistory(temperature.ToString());
							AddToOutputString(temperature);
							break;

						case PressureEventId:
							textBoxEventName.Text = "Pressure";
							// PressurePa, int32_t
							AddInt32ToForm(inputString, startIndexPositionData, "PressurePa");
							startIndexPositionData += (int)EXPECTED_INT32_LENGTH;
							break;

						case PressureTemperatureEventId:
							textBoxEventName.Text = "PressureTemperature";

							// PressurePa, int32_t
							// TemperatureC01, int16_t
							AddInt32ToForm(inputString, startIndexPositionData, "PressurePa", ", ");
							startIndexPositionData += (int)EXPECTED_INT32_LENGTH;
							
							AddInt16ToForm(inputString, startIndexPositionData, "TemperatureC01");
							startIndexPositionData += (int)EXPECTED_UINT16_LENGTH;
							break;

						default:
							// MonitoringProcess
                            if (eventId < 1000)
                            {
                                textBoxEventName.Text = "MonitoringProcess";

                                // Skip MonitoringProcessSettings
                                startIndexPositionData += (30 * 2);

                                AddFloatValueToForm(inputString, startIndexPositionData, "CheckPeriodSec");
                                startIndexPositionData += (int)EXPECTED_FLOAT_LENGTH;

                                AddUint16ToForm(inputString, startIndexPositionData, "RemoteReplicationDelayMinutes1");
                                startIndexPositionData += (int)EXPECTED_UINT16_LENGTH;

                                AddUint16ToForm(inputString, startIndexPositionData, "Reserved");
                                startIndexPositionData += (int)EXPECTED_UINT16_LENGTH;

                                AddUint16ToForm(inputString, startIndexPositionData, "LocalReplicationPeriodSec1");
                                startIndexPositionData += (int)EXPECTED_UINT16_LENGTH;

                                AddUint16ToForm(inputString, startIndexPositionData, "StorePeriodMinutes");
                                startIndexPositionData += (int)EXPECTED_UINT16_LENGTH;

                                AddUint16ToForm(inputString, startIndexPositionData, "RemoteReplicationPeriodMinutes");
                                startIndexPositionData += (int)EXPECTED_UINT16_LENGTH;

								// MonitoringExtProcessSettings
								if (length >= ((MonitoringSettingsLengthBytes + 2) * 2))
                                {
                                    AddUint16ToForm(inputString, startIndexPositionData, "MeasureStorePeriodMinutes");
                                    startIndexPositionData += (int)EXPECTED_UINT16_LENGTH;
								}
							}
                            break;
					}
				}
				richTextBoxHistory.Text += "\r\n";
			}
			else
			{
				labelStatus.Text = "Incorrect length";
			}
		}

		private void richTextBoxEventDataHex_TextChanged(object sender, EventArgs e)
		{
			ClearEventOutput();

			var inputString = richTextBoxEventDataHex.Text.Replace(" ", String.Empty);
			if (!richTextBoxEventDataHex.Text.Equals(inputString))
				richTextBoxEventDataHex.Text = inputString;

			ProcessInputString(inputString);
		}

		private void ClearEventOutput()
		{
			textBoxClassId.Text = "";
			textBoxDateTimeString.Text = "";
			labelStatus.Text = "";
			textBoxEventName.Text = "";

			groupBoxWasChangedEvent.Enabled = false;
			textBoxWasChangedEventContainerClassId.Text = "";
            richTextBoxCommon.Text = "";
		}

        private void Form1_Activated(object sender, EventArgs e)
        {
            if (checkBoxCapture.Checked)
            {
                if (String.Equals(richTextBoxEventDataHex.Text, Clipboard.GetText()) == false)
                    richTextBoxEventDataHex.Text = Clipboard.GetText();
            }
        }

		private OpenFileDialog openFileDialog1;

		private bool _isInputFileOpened;
		private string inputFileName;

		private void button1_Click(object sender, EventArgs e)
		{
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				inputFileName = openFileDialog1.FileName;
				_isInputFileOpened = true;
				string outputFileName = inputFileName + "2";

				StreamWriter fileToWrite = new StreamWriter(outputFileName);

				foreach (string line in File.ReadLines(openFileDialog1.FileName))
				{
					Console.WriteLine(line);
					ProcessInputString(line);

					fileToWrite.WriteLine(_outputString);
				}

				fileToWrite.Close();
			}
		}
	}
}
