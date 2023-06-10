using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EBankam
{
    public partial class BİLGİLER : Form
    {
        public BİLGİLER()
        {
            InitializeComponent();
        }


        SqlConnection bağlan = new SqlConnection("Data Source=DESKTOP-0DOOTGM\\SQLEXPRESS01;Initial Catalog=Bankam;Integrated Security=True");
        BankamDataSetTableAdapters.Table_HesapTableAdapter ds = new BankamDataSetTableAdapters.Table_HesapTableAdapter();

        private void BİLGİLER_Load(object sender, EventArgs e)
        {

            dataGridView1.DataSource = ds.GetData();

            bağlan.Open();
            SqlCommand dsx = new SqlCommand("Select Count (*) from Table_Hesap", bağlan);
            int kayitSayisi = (int)dsx.ExecuteScalar();
            bağlan.Close();
            labelhesapp.Text = kayitSayisi.ToString();

            bağlan.Open();
            SqlCommand erkekk = new SqlCommand("Select Count(*) from Table_Hesap where KullanıcıCinsiyet='Erkek'", bağlan);
            int erkek = (int)erkekk.ExecuteScalar();
            bağlan.Close();
            labelerkek.Text = erkek.ToString();

            bağlan.Open();
            SqlCommand kadın = new SqlCommand("Select Count(*) from Table_Hesap where KullanıcıCinsiyet='Kadın'", bağlan);
            int kad = (int)kadın.ExecuteScalar();
            bağlan.Close();
            labelkadın.Text = kad.ToString();


            bağlan.Open();
            SqlCommand t = new SqlCommand("Select Sum(ToplamHavale) from Table_Hesap", bağlan);
            int kadx = (int)t.ExecuteScalar();
            bağlan.Close();
            labelhavale.Text = kadx.ToString();

            bağlan.Open();
            SqlCommand toplambakiye = new SqlCommand("Select Sum(ToplamGelenPara) from Table_Hesap",bağlan);
            int toplambakiyem = (int)toplambakiye.ExecuteScalar();
            bağlan.Close();
            labelhesapbakiye.Text = toplambakiyem.ToString();


            bağlan.Open();
            SqlCommand hvl = new SqlCommand("Select Sum(ToplamGidenPara) from Table_Hesap", bağlan);
            int toplamhavale = (int)hvl.ExecuteScalar();
            bağlan.Close();
            labelgönderilenpara.Text = toplamhavale.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.AraHesap(textBox1.Text);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
