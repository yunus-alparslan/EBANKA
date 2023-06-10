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
    public partial class Sifrempanel : Form
    {
        public Sifrempanel()
        {
            InitializeComponent();
        }
        SqlConnection bağlan = new SqlConnection("Data Source=DESKTOP-0DOOTGM\\SQLEXPRESS01;Initial Catalog=Bankam;Integrated Security=True");

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttongirisyap_Click(object sender, EventArgs e)
        {

            if (textBoxsifre.Text == textBoxsifre2.Text)
            {
                bağlan.Open();
                SqlCommand güncellesifre = new SqlCommand("Update Table_Hesap Set KullanıcıSifre=@p1 where HesapNo=@p2 and KullanıcıTC=@p3 and KullanıcıTelefon=@p4", bağlan);
                güncellesifre.Parameters.AddWithValue("@p1", textBoxsifre.Text);
                güncellesifre.Parameters.AddWithValue("@p2", textBoxhesapno.Text);
                güncellesifre.Parameters.AddWithValue("@p3", textBoxtc.Text);
                güncellesifre.Parameters.AddWithValue("@p4", textBoxtel.Text);
                güncellesifre.ExecuteNonQuery();
                bağlan.Close();
                MessageBox.Show("Sifre Değiştirildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Sifreler Uyuşmamaktadır !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void Sifrempanel_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
