using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

// 		const UInt32 LOCATION_ID_BYTE_LENGTH = 8;
// 		const UInt32 LOCATION_ID_LENGTH = 
// 			LOCATION_ID_BYTE_LENGTH * BYTE_SYMBOLS_COUNT;

		public Form1()
		{
			InitializeComponent();
			ClearEventOutput();
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

		private void richTextBoxEventDataHex_TextChanged(object sender, EventArgs e)
		{
			ClearEventOutput();

			var inputString = richTextBoxEventDataHex.Text.Replace(" ", String.Empty);
			if (!richTextBoxEventDataHex.Text.Equals(inputString))
				richTextBoxEventDataHex.Text = inputString;

			var length = inputString.Length;
			if (length % BYTE_SYMBOLS_COUNT == 0 &&
				length >= EXPECTED_CLASS_ID_LENGTH)
			{
				labelStatus.Text = "Ok";

				UInt16 eventId = 0;
				try
				{
					string classIdString =
						inputString.Substring(
							0, (int)EXPECTED_CLASS_ID_LENGTH);
					eventId = GetUint16FromString(classIdString);
				}
				catch (System.Exception ex)
				{
				}

				if (eventId != 0)
				{
					textBoxClassId.Text = eventId.ToString();

					if (length >= (EXPECTED_CLASS_ID_LENGTH + EXPECTED_DATE_TIME_LENGTH))
					{
						int startIndexPosition = (int)EXPECTED_CLASS_ID_LENGTH;
						Console.WriteLine("startIndexPosition={0}", startIndexPosition);
						string dateTimeString =
							inputString.Substring(
								startIndexPosition, (int)EXPECTED_DATE_TIME_LENGTH);
						Console.WriteLine("dateTimeString={0}", dateTimeString);

						UInt32 time = GetUint32FromString(dateTimeString);
						DateTime dateTime = GetActualDateTime(time);
						textBoxDateTimeString.Text = dateTime.ToString();
					}

					const UInt16 TemperatureEventId = 22820;
					const UInt16 PressureEventId = 22821;
					const UInt16 PressureTemperatureEventId = 22822;
					const UInt16 WasChangedEventId = 19008;
					const UInt16 ProcessStartedEventId = 19007;
					switch (eventId)
					{
						case ProcessStartedEventId:
							textBoxEventName.Text = "ProcessStartedEvent";
							break;
						case WasChangedEventId:
							textBoxEventName.Text = "WasChangedEvent";

							// It's event-container
							// #TODO check string length
							groupBoxWasChangedEvent.Enabled = true;

							int startIndexPositionClassId = (int)
								(EXPECTED_CLASS_ID_LENGTH + EXPECTED_DATE_TIME_LENGTH);
							string classIdString =
							inputString.Substring(
								startIndexPositionClassId, (int)EXPECTED_CLASS_ID_LENGTH);
							Console.WriteLine("classIdString={0}", classIdString);
							UInt16 containeredClassId = GetUint16FromString(classIdString);
							textBoxWasChangedEventContainerClassId.Text = containeredClassId.ToString();
							break;

						case TemperatureEventId:
							textBoxEventName.Text = "Temperature";

							break;
						case PressureEventId:
							textBoxEventName.Text = "Pressure";
							break;
						case PressureTemperatureEventId:
							textBoxEventName.Text = "PressureTemperature";
							break;
					}
				}
			}
			else
			{
				labelStatus.Text = "Incorrect length";
			}
		}

		private void ClearEventOutput()
		{
			textBoxClassId.Text = "";
			textBoxDateTimeString.Text = "";
			labelStatus.Text = "";
			textBoxEventName.Text = "";

			groupBoxWasChangedEvent.Enabled = false;
			textBoxWasChangedEventContainerClassId.Text = "";
		}
	}
}
