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

namespace Hastane_Proje
{
    public partial class Frmbilgiduzenle : Form
    {
        public Frmbilgiduzenle()
        {
            InitializeComponent();
        }
        public string tcno;
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void Frmbilgiduzenle_Load(object sender, EventArgs e)
        {
            msktc.Text = tcno;
            SqlCommand komut = new SqlCommand("select * from tbl_hastalar where hastatc = @p1", bgl.baglanti());
            komut.Parameters.AddWithValue("p1", msktc.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                txtad.Text = dr[1].ToString();
                txtsoyad.Text = dr[2].ToString();
                txtsifre.Text = dr[5].ToString();
                msktelefon.Text = dr[4].ToString();
                cmbcinsiyet.Text = dr[6].ToString();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("update tbl_hastalar set hastaad = @p1,hastasoyad = @p2,hastasifre = @p3,hastatelefon = @p4,hastacinsiyet = @p5 where hastatc = @p6", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p6", msktc.Text);
            komut2.Parameters.AddWithValue("@p1", txtad.Text);
            komut2.Parameters.AddWithValue("@p2 ", txtsoyad.Text);
            komut2.Parameters.AddWithValue("@p3", txtsifre.Text);
            komut2.Parameters.AddWithValue("@p4", msktelefon.Text);
            komut2.Parameters.AddWithValue("@p5", cmbcinsiyet.Text);
            komut2.ExecuteNonQuery();
            MessageBox.Show("Bilgileriniz Güncellendi.");
        }
    }
}
