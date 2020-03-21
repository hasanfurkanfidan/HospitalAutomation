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
    public partial class Frmdoktorpaneli : Form
    {
        public Frmdoktorpaneli()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void Frmdoktorpaneli_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from table_doktorlar ",bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            SqlCommand komut2 = new SqlCommand("select bransad from tbl_branslar",bgl.baglanti());
            SqlDataReader dr = komut2.ExecuteReader();
            while(dr.Read())
            {
                cmbbrans.Items.Add(dr[0]);
            }

        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into table_doktorlar (doktorad,doktorsoyad,doktorbrans,doktortc,doktorsifre)values(@p1,@p2,@p3,@p4,@p5)",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3",cmbbrans.Text );
            komut.Parameters.AddWithValue("@p4",msktc.Text);
            komut.Parameters.AddWithValue("@p5",txtsifre.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();



        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbbrans.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            msktc.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtsifre.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();


        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from table_doktorlar where doktortc = @p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", msktc.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Silme işlemi tamamlandı.");


        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update table_doktorlar set doktorad = @p1,doktorsoyad = @p2,doktorbrans = @p3,doktorsifre = @p5 where doktortc = @p4", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", cmbbrans.Text);
            komut.Parameters.AddWithValue("@p4", msktc.Text);
            komut.Parameters.AddWithValue("@p5", txtsifre.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bilgi güncelleme başarılı");
        }
    }
}
