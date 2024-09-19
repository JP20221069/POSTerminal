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
    public partial class FrmPrijava : Form
    {
        public FrmPrijava()
        {
            InitializeComponent();
        }

        private void btSimuScan_Click(object sender, EventArgs e)
        {
            SimuScan ss = new SimuScan();
            DBManager db = new DBManager();
            DALObject d = db.GetList(new Zaposleni());
            List<CBObject> lista = new List<CBObject>();
            foreach(object o in (List<object>)d.Values)
            {
                Zaposleni z = (Zaposleni)o;
                lista.Add(new CBObject(z.JMBG,z.Ime + " " + z.Prezime));
            }
            ss.displaylist = lista;
            ss.target = this.txtScan;
            ss.Show();
        }

        private void btPrijava_Click(object sender, EventArgs e)
        {
            DBManager db = new DBManager();
            if(Validacija())
            {
                if(db.Prijava(txtScan.Text))
                {
                    int brojkasira = db.GetBrojKasira(txtScan.Text);
                    FrmGlavna.brojkasira = brojkasira;
                    FrmGlavna.jmbg = txtScan.Text;
                    new FrmGlavna().Show();
                }
                else
                {
                    MessageBox.Show("Neispravan JMBG zaposlenog!", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private bool Validacija()
        {
            if(string.IsNullOrWhiteSpace(txtScan.Text))
            {
                MessageBox.Show("Obavezno je skenirati JMBG zaposlenog!", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}
