﻿using System;
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

        private void button1_Click(object sender, EventArgs e)
        {
			DoConvertion();
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			DoConvertion();
		}

		private void DoConvertion()
		{
			UInt32 time = 0;
			try
			{
				time = Convert.ToUInt32(textBox1.Text);
			}
			catch (System.Exception ex)
			{

			}

			DateTime dateTime = new DateTime(1980, 1, 1);
			dateTime = dateTime.AddSeconds(time);
			textBox2.Text = dateTime.ToString();
		}
	}
}