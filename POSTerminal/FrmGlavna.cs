using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSTerminal
{
    public partial class FrmGlavna : Form
    {
        public FrmGlavna()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FIELD_DISPLAY.Text+="1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FIELD_DISPLAY.Text += "2";
        }

        private void btExit_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            FIELD_DISPLAY.Text += "6";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FIELD_DISPLAY.Text += "5";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FIELD_DISPLAY.Text += "4";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FIELD_DISPLAY.Text += "9";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FIELD_DISPLAY.Text += "8";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FIELD_DISPLAY.Text += "7";
        }

        private void button0_Click(object sender, EventArgs e)
        {
            FIELD_DISPLAY.Text += "0";
        }

        private void btEnter_Click(object sender, EventArgs e)
        {
            FIELD_DISPLAY.Text = "";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (FIELD_DISPLAY.Text.Length >= 1)
            {
                FIELD_DISPLAY.Text=FIELD_DISPLAY.Text.Remove(FIELD_DISPLAY.Text.Length-1);
            }
        }

        private void btScan_Click(object sender, EventArgs e)
        {

        }

        private void btStorno_Click(object sender, EventArgs e)
        {

        }

        private void btFinish_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
