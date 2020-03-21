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
    public partial class Frmsekreterdetay : Form
    {
        public Frmsekreterdetay()
        {
            InitializeComponent();
        }
        public string adsoyad;
        public string tc;
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void Frmsekreterdetay_Load(object sender, EventArgs e)
        {
            lbltc.Text = tc;
            SqlCommand komut = new SqlCommand("select sekreteradsoyad from tbl_sekreter where sekretertc = @p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", lbltc.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                lbladsoyad.Text = dr[0].ToString();
            }
            //Branşları datagridview e çekme
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_branslar",bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            //Doktorları datagride çekme
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("select * from table_doktorlar", bgl.baglanti());
            da1.Fill(dt1);
            dataGridView2.DataSource = dt1;
            //Branşı comboboxa aktarma
            SqlCommand komut2 = new SqlCommand("select bransad from tbl_branslar", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                cmbbrans.Items.Add(dr2[0].ToString());
            }

            }
      





        private void btnrandevuolustur_Click(object sender, EventArgs e)
        {
            SqlCommand komutkaydet = new SqlCommand("insert into tbl_randevular (randevutarih,randevusaat,randevubrans,randevudoktor)values(@r1,@r2,@r3,@r4)",bgl.baglanti());
            komutkaydet.Parameters.AddWithValue("@r1", msktarih.Text);
            komutkaydet.Parameters.AddWithValue("@r2", msksaat.Text);
            komutkaydet.Parameters.AddWithValue("@r3", cmbbrans.Text);
            komutkaydet.Parameters.AddWithValue("@r4", cmbdoktor.Text);
            komutkaydet.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu Oluşturuldu");


        }

        private void cmbbrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbdoktor.Items.Clear();
            SqlCommand komut3 = new SqlCommand("select doktorad,doktorsoyad from table_doktorlar where doktorbrans = @p1 ", bgl.baglanti());
            komut3.Parameters.AddWithValue("@p1", cmbbrans.Text);
            SqlDataReader dr = komut3.ExecuteReader();
            while(dr.Read())
            {
                cmbdoktor.Text = (dr[0] + " " + dr[1]).ToString();
            }
        }

        private void btnduyuruolustur_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into tbl_duyurular (duyuru) values (@p1)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", rchduyuru.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Duyuru Oluşturuldu");
        }

        private void btndoktorpaneli_Click(object sender, EventArgs e)
        {
            Frmdoktorpaneli drp = new Frmdoktorpaneli();
            drp.Show();

        }

        private void btnbranspaneli_Click(object sender, EventArgs e)
        {
            frmbrans fbr = new frmbrans();
            fbr.Show();
        }

        private void btnrandevuliste_Click(object sender, EventArgs e)
        {
            frmrandevulistesi frr = new frmrandevulistesi();
            frr.Show();
        }

        private void btnrandevuguncelle_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frmduyurular frd = new Frmduyurular();
            frd.Show();
        }
    }
}
