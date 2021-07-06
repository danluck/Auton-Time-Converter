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

		private const UInt32 BYTE_SYMBOLS_COUNT = 2;

		private void DoHexConvertion()
		{
			// Source format: Little Endian (DCBA)
			const UInt32 EXPECTED_BYTE_LENGTH = 4;

			Console.WriteLine("textBoxHex.Text.Length={0}", textBoxHex.Text.Length);
			if (textBoxHex.Text.Length == (EXPECTED_BYTE_LENGTH * BYTE_SYMBOLS_COUNT))
			{
				UInt32 time = 0;
				try
				{
					time = Convert.ToUInt32(textBoxHex.Text, 16);
				}
				catch (System.Exception ex)
				{

				}

				byte[] sourceBytes = BitConverter.GetBytes(time);
				if (sourceBytes.Length == EXPECTED_BYTE_LENGTH)
				{
					// Convert to Little Endian (DCBA)
					var resultBytes = new byte[EXPECTED_BYTE_LENGTH];
					resultBytes[0] = sourceBytes[3];
					resultBytes[1] = sourceBytes[2];
					resultBytes[2] = sourceBytes[1];
					resultBytes[3] = sourceBytes[0];

					UInt32 result = BitConverter.ToUInt32(resultBytes, 0);
					Console.WriteLine("result={0}", result);
					ShowSecons(result);
				}
			}
		}

		/// <summary>
		/// Show time as string
		/// </summary>
		/// <param name="seconds">Seconds from 1980</param>
		private void ShowSecons(UInt32 seconds)
		{
			DateTime dateTime = new DateTime(1980, 1, 1);
			dateTime = dateTime.AddSeconds(seconds);
			textBox2.Text = dateTime.ToString();
		}

		private void richTextBoxEventDataHex_TextChanged(object sender, EventArgs e)
		{
			var length = richTextBoxEventDataHex.Text.Length;
			Console.WriteLine("richTextBoxEventDataHex.Text.Length={0}", length);

			const UInt32 EXPECTED_CLASS_ID_BYTE_LENGTH = 2;
			if (length % BYTE_SYMBOLS_COUNT == 0 &&
				length >= EXPECTED_CLASS_ID_BYTE_LENGTH * BYTE_SYMBOLS_COUNT)
			{
				labelStatus.Text = "Ok";

				UInt16 classId = 0;
				try
				{
					string classIdString = richTextBoxEventDataHex.Text.Substring(0, 4);
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
				}
			}
			else
			{
				labelStatus.Text = "Incorrect length";
			}
		}
	}
}
