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
    public partial class CountDialog : Form
    {
        public float amount;
        public CountDialog()
        {
            InitializeComponent();
        }

        private void button0_Click(object sender, EventArgs e)
        {
            amount = (float)numericUpDown1.Value;
            this.DialogResult = DialogResult.OK;
        }
    }
}
