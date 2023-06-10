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
using System.Reflection.Emit;

namespace EBankam
{
    public partial class Bankam : Form
    {
        public Bankam()
        {
            InitializeComponent();
        }

        // Sql Bağlantı//
        SqlConnection bağlan = new SqlConnection("Data Source=DESKTOP-0DOOTGM\\SQLEXPRESS01;Initial Catalog=Bankam;Integrated Security=True");
        // Sql Bağlantı//


        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Değişkenler//
        public int hesapno;
        int topla = 0, benimpara = 0, adampara = 0, ben = 0, geneltoplam = 0, toplamhavale = 0;

        private void AdminDetay_Click(object sender, EventArgs e)
        {
            BİLGİLER frmBilgiler = new BİLGİLER();
            frmBilgiler.Show();
        }

        int kalpara = 0, toplagiden = 0;
        private void Bankam_Load(object sender, EventArgs e)
        {
            labelHesapNo.Text = hesapno.ToString();
            bağlan.Open();
            SqlCommand getirbilgilerimi = new SqlCommand("Select * from Table_Hesap where HesapNo=@p1", bağlan);
            getirbilgilerimi.Parameters.AddWithValue("@p1", labelHesapNo.Text);
            SqlDataReader dr = getirbilgilerimi.ExecuteReader();
            while (dr.Read())
            {
                labelad.Text = dr[2].ToString() + " " + dr[3].ToString();
                textBoxBAKİYE.Text = dr[7].ToString();
                label4.Text = dr[5].ToString();
                label7.Text = dr[6].ToString();
                labelhavale.Text = dr[8].ToString();
                label14.Text = dr[9].ToString();
                labelgönderilenbakiye.Text = dr[10].ToString();
            }
            bağlan.Close();

           

            if (hesapno == 4000)
            {
                AdminDetay.Visible = true;
            }


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


        void toplamhavalem()
        {
            /// giden para toplam
            kalpara = int.Parse(labelgönderilenbakiye.Text);
            toplagiden = kalpara + int.Parse(textBoxtutar.Text);
            labelgönderilenbakiye.Text = toplagiden.ToString();
            /// giden para toplam
        }

        private void buttongirisyap_Click(object sender, EventArgs e)
        {

            bağlan.Open();
            SqlCommand getir = new SqlCommand("Select * from Table_Hesap where HesapNo=@p3", bağlan);
            getir.Parameters.AddWithValue("@p3", textBoxhesapno.Text);

            SqlDataReader dr = getir.ExecuteReader();

            while (dr.Read())
            {
                labelbenimpara.Text = dr[7].ToString();
            }
            bağlan.Close();



            benimpara = int.Parse(labelbenimpara.Text);
            ben = int.Parse(textBoxtutar.Text);
            adampara = int.Parse(textBoxBAKİYE.Text);

            if (int.Parse(textBoxBAKİYE.Text) > 0)
            {
                toplamhavalem();


                topla = (ben);
                geneltoplam = adampara - topla;


                textBoxBAKİYE.Text = geneltoplam.ToString();
                geneltoplam = ben + benimpara;
                label11.Text = geneltoplam.ToString();

                bağlan.Open();
                SqlCommand göndertransfer = new SqlCommand("Update Table_Hesap Set KullanıcıBakiye=@p1,ToplamGelenPara=@p2 where HesapNo=@p3", bağlan);
                göndertransfer.Parameters.AddWithValue("@p1", label11.Text);

                göndertransfer.Parameters.AddWithValue("@p3", textBoxhesapno.Text);
                göndertransfer.Parameters.AddWithValue("@p2", textBoxtutar.Text);
                göndertransfer.ExecuteNonQuery();
                bağlan.Close();

                toplamhavale = int.Parse(labelhavale.Text);

                toplamhavale++;
                labelhavale.Text = toplamhavale.ToString();

                bağlan.Open();
                SqlCommand güncelle2 = new SqlCommand("Update Table_Hesap Set KullanıcıBakiye=@p2,ToplamHavale=@p3,ToplamGidenPara=@p5 where HesapNo=@p4", bağlan);
                güncelle2.Parameters.AddWithValue("@p2", textBoxBAKİYE.Text);
                güncelle2.Parameters.AddWithValue("@p4", labelHesapNo.Text);
                güncelle2.Parameters.AddWithValue("@p3", labelhavale.Text);
                güncelle2.Parameters.AddWithValue("@p5", labelgönderilenbakiye.Text);
                güncelle2.ExecuteNonQuery();
                bağlan.Close();
                MessageBox.Show("Bakiye " + labelHesapNo.Text + " No'lu Hesaba Gönderilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Hesabınızda Yeterli Bakiye Kalmadı !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
