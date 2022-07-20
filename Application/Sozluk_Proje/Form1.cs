using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Sozluk_Proje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\HP\Desktop\dbSozluk.mdb");

        // verileri listboxa çekmek
        private void Form1_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("Select ingilizce From sozluk", baglanti);
            OleDbDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                listBox1.Items.Add(dr[0].ToString());
            }
            baglanti.Close();
        }

        // listboxda tıkladığımız verinin türkçesini yazdırmak
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut3 = new OleDbCommand("Select turkce From sozluk where ingilizce=@p1", baglanti);
            komut3.Parameters.AddWithValue("@p1", listBox1.SelectedItem);
            OleDbDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                textBox2.Text = dr3[0].ToString();
            }
            baglanti.Close();
        }

        // ingilizce arama yerine harf yazdığımızda verilerin çıkması
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            baglanti.Open();
            OleDbCommand komut2 = new OleDbCommand("Select ingilizce From sozluk where ingilizce like '" + textBox1.Text + "%'", baglanti);
            OleDbDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                listBox1.Items.Add(dr2[0].ToString());
            }
            baglanti.Close();
        }
    }
}
