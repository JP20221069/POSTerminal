using POSTerminal.Database;
using POSTerminal.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSTerminal
{
    public class FiskalnaIntegracija
    {
        public static string GenerateRandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder result = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                result.Append(chars[random.Next(chars.Length)]);
            }

            return result.ToString();
        }
        public static string GenerisiBR()
        {
            DBManager db = new DBManager();
            string latestbr = db.GetNajnovijiBrojacRacuna();
            if(string.IsNullOrEmpty(latestbr))
            {
                return "000000/000001PP";
            }
            else
            {
                string[] x = latestbr.Split('/');
                string lp = x[1].Substring(0, x[1].IndexOf('P'));
                string y = (int.Parse(lp)+1).ToString();
                string text = "";
                for(int i=0;i<6-y.Length;i++)
                {
                    text += "0";
                }
                text += y;
                string nstr = x[0] + "/" + text + "PP";
                return nstr;

            }
        }

        public static string GenerisiPFRBroj()
        {
            string first = GenerateRandomString(8);
            string second = GenerateRandomString(6);
            return first + "-" + first + "-" + second;
        }

        public static void StampajRacun(Racun racun, List<StavkaRacuna> stavke)
        {
            string template = "";
            string culture = ConfigurationManager.AppSettings["culture"].ToString();
            if (culture=="cyr")
            {
                StreamReader myreader = new StreamReader("Templates/RacunCyr.txt");
                template = myreader.ReadToEnd();
                myreader.Close();
            }
            else if (culture=="lat")
            {
                StreamReader myreader = new StreamReader("Templates/RacunLat.txt");
                template = myreader.ReadToEnd();
                myreader.Close();
            }
            DBManager db = new DBManager();
            List<SqlParameter> sqop = new List<SqlParameter>();
            sqop.Add(new SqlParameter("PIB", ConfigurationManager.AppSettings["company"].ToString()));
            DALObject dao = db.GetSingle(new Preduzece(), sqop);
            sqop.Clear();
            sqop.Add(new SqlParameter("ID", ConfigurationManager.AppSettings["sellplace"].ToString()));
            DALObject dao2 = db.GetSingle(new ProdajnoMesto(), sqop);
            Preduzece pred = (Preduzece)dao.Values;
            ProdajnoMesto prod = (ProdajnoMesto)dao2.Values;
            template = template.Replace("<PIB>", pred.PIB);
            template = template.Replace("<COM_NAME>", pred.Naziv);
            template = template.Replace("<PM_NAME>", prod.Naziv);
            template = template.Replace("<PM_ADDRESS>", prod.Ulica + " " + prod.Broj);
            template = template.Replace("<CITYANDMUNICIP>", prod.Mesto.Opstina.Grad + " " + prod.Mesto.Opstina.Naziv + " " + prod.Mesto.Naziv);
            template = template.Replace("<ESIR>", racun.ESIRbroj);
            template = template.Replace("<CASHIER>", FrmGlavna.brojkasira.ToString());
            string temp = "";
            float sum = 0.0f;
            List<PoreskaGrupa> pg = new List<PoreskaGrupa>();
            foreach(StavkaRacuna name in stavke)
            {
                temp += name.Proizvod.Naziv + " ("+name.Proizvod.PoreskaGrupa.Akronim+")\t" + name.Kolicina + "\t" + name.Proizvod.Cena * name.Kolicina + "\n";
                sum += name.Proizvod.Cena * name.Kolicina;
                if(pg.Contains(name.Proizvod.PoreskaGrupa)==false)
                {
                    pg.Add(name.Proizvod.PoreskaGrupa);
                }
            }
            template = template.Replace("<ART>", temp);
            template = template.Replace("<TOTAL>", sum.ToString());
            string type = "";
            if(culture=="cyr" && racun.NacinPlacanja == NacinPlacanja.Kes)
            {
                type = "Готовина:";
            }
            else if (culture == "cyr" && racun.NacinPlacanja == NacinPlacanja.Kartica)
            {
                type = "Картица:";
            }
            else if (culture == "lat" && racun.NacinPlacanja == NacinPlacanja.Kes)
            {
                type = "Gotovina:";
            }
            else if (culture == "cyr" && racun.NacinPlacanja == NacinPlacanja.Kartica)
            {
                type = "Kartica:";
            }
            template = template.Replace("<TYPE>", type);
            template = template.Replace("<CASH>", FrmGlavna.zauplatu.ToString());
            if(racun.NacinPlacanja==NacinPlacanja.Kes)
            {
                template = culture == "cyr" ? template.Replace("<RETURNIF>", "Повраћај:") : template.Replace("<RETURNIF>", "Povraćaj:");
                template = template.Replace("<RETURN>", (FrmGlavna.zauplatu-sum).ToString());
            }
            else
            {
                template = template.Replace("<RETURNIF>", "");
                template = template.Replace("<RETURN>", "");
            }
            string tpg = "";
            float sumtax = 0.0f;
            foreach(PoreskaGrupa ppg in pg)
            {
                tpg += ppg.Akronim + "\t" + ppg.Stopa+"\n";
                sumtax += ppg.Stopa;
            }
            template = template.Replace("<TAX>", tpg);

            template = template.Replace("<TAXTOTAL>", (sumtax).ToString());
            template = template.Replace("<PFR_TIME>", DateTime.Now.ToString());
            template = template.Replace("<PFR_COUNTER>", racun.PFRBroj);
            template = template.Replace("<BILL_NO>", racun.BrojRacuna);

            PrintPreview pprev = new PrintPreview();
            pprev.richTextBox1.Text = template;
            pprev.Show();
        }


    }
}
