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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection bağlan = new SqlConnection("Data Source=DESKTOP-0DOOTGM\\SQLEXPRESS01;Initial Catalog=Bankam;Integrated Security=True");


        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            bağlan.Open();
            SqlCommand sorgula = new SqlCommand("Select * from Table_Hesap where KullanıcıSifre=@p2 and HesapNo=@p1",bağlan);
            sorgula.Parameters.AddWithValue("@p1", textBoxhesapno.Text);
            sorgula.Parameters.AddWithValue("@p2", textBoxsifre.Text);

            SqlDataReader dr = sorgula.ExecuteReader();

            if (dr.Read())
            {
                MessageBox.Show("Başarılı Şekilde Giriş Sağlandı","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                Bankam banka = new Bankam();
                banka.hesapno = Convert.ToInt32(textBoxhesapno.Text);
                banka.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre Yanlış !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            bağlan.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Sifrempanel sifre = new Sifrempanel();
            sifre.Show();
        }
    }
}
