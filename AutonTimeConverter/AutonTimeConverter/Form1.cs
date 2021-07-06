using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
			BYTE_SYMBOLS_COUNT * EXPECTED_DATE_TIME_BYTE_LENGTH;

		// ClassId
		const UInt32 EXPECTED_CLASS_ID_BYTE_LENGTH = 2;
		const UInt32 EXPECTED_CLASS_ID_LENGTH =
			EXPECTED_CLASS_ID_BYTE_LENGTH * BYTE_SYMBOLS_COUNT;

		public Form1()
		{
			InitializeComponent();
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

		private void DoHexConvertion()
		{
			Console.WriteLine("textBoxHex.Text.Length={0}", textBoxHex.Text.Length);
			if (textBoxHex.Text.Length == (EXPECTED_DATE_TIME_BYTE_LENGTH * BYTE_SYMBOLS_COUNT))
			{
				int stringLength = (int)(EXPECTED_DATE_TIME_BYTE_LENGTH * BYTE_SYMBOLS_COUNT);
				string text = textBoxHex.Text.Substring(0, stringLength);

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
			var length = richTextBoxEventDataHex.Text.Length;
			Console.WriteLine("richTextBoxEventDataHex.Text.Length={0}", length);

			if (length % BYTE_SYMBOLS_COUNT == 0 &&
				length >= EXPECTED_CLASS_ID_LENGTH)
			{
				labelStatus.Text = "Ok";

				UInt16 classId = 0;
				try
				{
					string classIdString = 
						richTextBoxEventDataHex.Text.Substring(
							0, (int)EXPECTED_CLASS_ID_LENGTH);
					classId = Convert.ToUInt16(classIdString, 16);
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

					UInt16 result = BitConverter.ToUInt16(resultBytes, 0);
					Console.WriteLine("result={0}", result);
					textBoxClassId.Text = result.ToString();

					const UInt16 PressureTemperatureEventId = 22822;
					if (result == PressureTemperatureEventId)
					{
						if (length >= (EXPECTED_CLASS_ID_LENGTH + EXPECTED_DATE_TIME_LENGTH))
						{
							int startIndexPosition = (int)EXPECTED_CLASS_ID_LENGTH;
							Console.WriteLine("startIndexPosition={0}", startIndexPosition);
							string dateTimeString = 
								richTextBoxEventDataHex.Text.Substring(
									startIndexPosition, (int)EXPECTED_DATE_TIME_LENGTH);
							Console.WriteLine("dateTimeString={0}", dateTimeString);

							UInt32 time = GetUint32FromString(dateTimeString);
							DateTime dateTime = GetActualDateTime(time);
							textBoxDateTimeString.Text = dateTime.ToString();
						}
					}
				}
			}
			else
			{
				labelStatus.Text = "Incorrect length";
			}
		}
	}
}
