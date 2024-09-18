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
    public partial class SimuScan : Form
    {
        public TextBox target { get; set; }
        public List<CBObject> displaylist { get; set; }
        public SimuScan()
        {
            InitializeComponent();
        }

        private void SimuScan_Load(object sender, EventArgs e)
        {
            listBox1.DataSource = displaylist;
            listBox1.DisplayMember = "Name";
            listBox1.ValueMember = "Value";
        }

        private void btAccept_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                target.Text = listBox1.SelectedValue.ToString();
            }
            else
            {
                MessageBox.Show("Niste izabrali objekat.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FIELD_SEARCH_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FIELD_SEARCH.Text)==false)
            {
                List<CBObject> searchedlist = displaylist.FindAll(x => x.Name.Contains(FIELD_SEARCH.Text));
                if(searchedlist.Count==0)
                {
                    MessageBox.Show("Nema pronađenih objekata.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    listBox1.DataSource = searchedlist;
                    listBox1.Refresh();
                }    
            }
            else
            {
                listBox1.DataSource = displaylist;
                listBox1.Refresh();
            }
            
        }

        private void btResetFilter_Click(object sender, EventArgs e)
        {
            listBox1.DataSource = displaylist;
            listBox1.Refresh();
            MessageBox.Show("Filter uklonjen.", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
