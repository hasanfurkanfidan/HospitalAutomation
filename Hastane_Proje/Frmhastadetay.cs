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
    public partial class Frmhastadetay : Form
    {
        public Frmhastadetay()
        {
            InitializeComponent();
        }
        public string tc;
        public string adsoyad;
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void Frmhastadetay_Load(object sender, EventArgs e)
        {
            lbltc.Text = tc;
            // Ad soyad çekme..
            SqlCommand komut = new SqlCommand("select hastaad,hastasoyad from tbl_hastalar where hastatc = @p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", lbltc.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                lblad.Text = dr[0] + " " + dr[1];
            }
            bgl.baglanti().Close();
            //Randevu Geçmişi
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select*from tbl_randevular where hastaTc ="+tc,bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            //Branşları Çekme
            SqlCommand komut2 = new SqlCommand("select bransAd from Tbl_branslar",bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                cmbbrans.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();
            SqlCommand komut3 = new SqlCommand("select randevuid from tbl_randevular", bgl.baglanti());
            

        }

        private void cmbbrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbdoktor.Items.Clear();
            SqlCommand komut3 = new SqlCommand("select doktorad,doktorsoyad from table_doktorlar where doktorbrans = @p1", bgl.baglanti());
            komut3.Parameters.AddWithValue("@p1", cmbbrans.Text);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while(dr3.Read())
            {
                cmbdoktor.Items.Add(dr3[0]+" "+dr3[1]);
            }
            bgl.baglanti().Close();
        }

        private void cmbdoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select * from tbl_randevular where randevubrans = '"+cmbbrans.Text+"'"+"and randevudoktor='"+cmbdoktor.Text+"'",bgl.baglanti());
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;
        }

        private void lnkbilgiduzenle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Frmbilgiduzenle fr = new Frmbilgiduzenle();
            fr.tcno = lbltc.Text;
            fr.Show();
            

        }

        private void btnrandevu_Click(object sender, EventArgs e)
        {
            
        }
    }
}
