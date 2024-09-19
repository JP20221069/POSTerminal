using POSTerminal.Database;
using POSTerminal.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSTerminal
{
    public partial class FrmGlavna : Form
    {
        public static string jmbg;
        public static int brojkasira;
        public static float zauplatu;
        Racun racun;
        List<StavkaRacuna> stavke;
        public FrmGlavna()
        {
            InitializeComponent();
            racun = new Racun();
            stavke = new List<StavkaRacuna>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FIELD_DISPLAY.Text+="1";
            Effects.playsimplesound("Sounds/BUTTON.wav");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FIELD_DISPLAY.Text += "2";
            Effects.playsimplesound("Sounds/BUTTON.wav");
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            Effects.playsimplesound("Sounds/BUTTON.wav");
            if (stavke.Count==0)
            {
                Application.Exit();
            }
            else
            {
                if (listBox1.SelectedIndex != -1)
                {
                    stavke[listBox1.SelectedIndex].Kolicina--;
                    if (stavke[listBox1.SelectedIndex].Kolicina==0)
                    {
                        stavke.RemoveAt(listBox1.SelectedIndex);
                    }
                    listBox1.DataSource = null;
                    listBox1.DataSource = stavke;
                    listBox1.Refresh();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FIELD_DISPLAY.Text += "4";
            Effects.playsimplesound("Sounds/BUTTON.wav");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FIELD_DISPLAY.Text += "5";
            Effects.playsimplesound("Sounds/BUTTON.wav");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FIELD_DISPLAY.Text += "6";
            Effects.playsimplesound("Sounds/BUTTON.wav");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FIELD_DISPLAY.Text += "7";
            Effects.playsimplesound("Sounds/BUTTON.wav");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FIELD_DISPLAY.Text += "8";
            Effects.playsimplesound("Sounds/BUTTON.wav");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FIELD_DISPLAY.Text += "9";
            Effects.playsimplesound("Sounds/BUTTON.wav");
        }

        private void button0_Click(object sender, EventArgs e)
        {
            FIELD_DISPLAY.Text += "0";
            Effects.playsimplesound("Sounds/BUTTON.wav");
        }

        private void btEnter_Click(object sender, EventArgs e)
        {
            Effects.playsimplesound("Sounds/BUTTON.wav");
            try
            {
                DBManager db = new DBManager();
                List<SqlParameter> pp = new List<SqlParameter>();
                pp.Add(new SqlParameter("ID", FIELD_DISPLAY.Text));
                DALObject dao = db.GetSingle(new Proizvod(), pp);
                Proizvod p = (Proizvod)dao.Values;
                if(p==null)
                {
                    MessageBox.Show("Pogrešna šifra proizvoda!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                CountDialog cd = new CountDialog();
                float kolicina = 1.00f;
                if (cd.ShowDialog() != DialogResult.Cancel)
                {
                    kolicina = cd.amount;
                }
                stavke.Add(new StavkaRacuna(-1, racun.BrojRacuna, p, kolicina, false, null));
                listBox1.DataSource = null;
                listBox1.DataSource = stavke;
                listBox1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            FIELD_DISPLAY.Text = "";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (FIELD_DISPLAY.Text.Length >= 1)
            {
                FIELD_DISPLAY.Text=FIELD_DISPLAY.Text.Remove(FIELD_DISPLAY.Text.Length-1);
            }
            Effects.playsimplesound("Sounds/BUTTON.wav");
        }

        private void btScan_Click(object sender, EventArgs e)
        {
            SimuScan ss = new SimuScan();
            ss.target = this.FIELD_DISPLAY;
            DBManager db = new DBManager();
            DALObject dao = db.GetList(new Proizvod());
            List<object> p = (List<object>)dao.Values;
            List<CBObject> cbo = new List<CBObject>();
            foreach (object o in p)
            {
                Proizvod pr = (Proizvod)o;
                cbo.Add(new CBObject(pr.ID, pr.Naziv + " | " + pr.ID));
            }
            ss.displaylist = cbo;
            ss.Show();

        }

        private void btStorno_Click(object sender, EventArgs e)
        {
            Effects.playsimplesound("Sounds/BUTTON.wav");
            string br_racuna = FIELD_DISPLAY.Text;
            try
            {
                List<SqlParameter> sqop = new List<SqlParameter>();
                sqop.Add(new SqlParameter("BrojRačuna", br_racuna));
                DALObject dao = new DBManager().GetSingle(new Racun(), sqop);
                Racun r = (Racun)dao.Values;
                if(r==null)
                {
                    MessageBox.Show("Neispravan broj računa", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    sqop = new List<SqlParameter>();
                    sqop.Add(new SqlParameter("BrojRačuna", r.BrojRacuna));
                    DALObject dao2 = new DBManager().GetList(new StavkaRacuna(), sqop);
                    List<object> objs = (List<object>)dao2.Values;
                    List<StavkaRacuna> s = new List<StavkaRacuna>();
                    foreach(object o in objs)
                    {
                        s.Add((StavkaRacuna)o);
                    }
                    ManagerDialog m = new ManagerDialog();
                    if (m.ShowDialog() != DialogResult.Cancel)
                    {
                        new DBManager().Storniraj(r, s, m.mid);
                        MessageBox.Show("Uspešno storniran račun.", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Storniranje otkazano.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
              
                }    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btFinish_Click(object sender, EventArgs e)
        {
            float sum = 0.0f;
            foreach (StavkaRacuna name in stavke)
            {
                sum += name.Proizvod.Cena * name.Kolicina;
            }
            PaymentDialog p = new PaymentDialog();
            p.numericUpDown1.Value = (decimal)sum;
            p.numericUpDown1.Minimum = (decimal)sum;
            if (p.ShowDialog() != DialogResult.Cancel)
            {
                zauplatu = (float)p.numericUpDown1.Value;
                racun.NacinPlacanja = p.nacinplacanja;
                List<SqlParameter> sqop = new List<SqlParameter>();
                sqop.Add(new SqlParameter("ID", ConfigurationManager.AppSettings["sellplace"]));
                DALObject dao = new DBManager().GetSingle(new ProdajnoMesto(), sqop);
                racun.ProdajnoMesto = (ProdajnoMesto)dao.Values;
                FiskalnaIntegracija.StampajRacun(racun, stavke);
                try
                {
                    DBManager db = new DBManager();
                    db.Add(racun);
                    foreach(StavkaRacuna name in stavke)
                    {
                        db.Add(name);
                    }
                    stavke.Clear();
                    racun = new Racun();
                    listBox1.DataSource = null;
                    FIELD_DISPLAY.Text = "Sledeći račun . . .";
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FIELD_DISPLAY.Text += "3";
            Effects.playsimplesound("Sounds/BUTTON.wav");
        }

        private void btAddPr_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex!=-1)
            {
                stavke[listBox1.SelectedIndex].Kolicina++;
                listBox1.DataSource = null;
                listBox1.DataSource = stavke;
            }
            listBox1.Refresh();
            Effects.playsimplesound("Sounds/BUTTON.wav");
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            FIELD_DISPLAY.Text = "";
            Effects.playsimplesound("Sounds/BUTTON.wav");
        }

        private void FrmGlavna_Load(object sender, EventArgs e)
        {

        }
    }
}
