using POSTerminal.Database;
using POSTerminal.Model;
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
    public partial class ManagerDialog : Form
    {
        public int mid;
        public ManagerDialog()
        {
            InitializeComponent();
        }

        private void ManagerDialog_Load(object sender, EventArgs e)
        {

        }

        private void btSimuScan_Click(object sender, EventArgs e)
        {
            SimuScan ss = new SimuScan();
            DBManager db = new DBManager();
            DALObject d = db.GetList(new Zaposleni());
            List<CBObject> lista = new List<CBObject>();
            foreach (object o in (List<object>)d.Values)
            {
                Zaposleni z = (Zaposleni)o;
                lista.Add(new CBObject(z.JMBG, z.Ime + " " + z.Prezime));
            }
            ss.displaylist = lista;
            ss.target = this.txtScan;
            ss.Show();
        }

        private void btPrijava_Click(object sender, EventArgs e)
        {
            int x = new DBManager().PrijavaMenadzera(txtScan.Text);
            if(x!=-1)
            {
                this.DialogResult = DialogResult.OK;
                mid = x;
            }
            else
            {
                MessageBox.Show("Neispravna šifra menadžera", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
