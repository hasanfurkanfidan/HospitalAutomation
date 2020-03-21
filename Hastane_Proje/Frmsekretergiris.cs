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
    public partial class Frmsekretergiris : Form
    {
        public Frmsekretergiris()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut1 = new SqlCommand("select * from tbl_sekreter where sekretertc = @p1 and sekretersifre = @p2 ", bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1", msktc.Text);
            komut1.Parameters.AddWithValue("@p2", txtsifre.Text);
            SqlDataReader dr = komut1.ExecuteReader();
            if(dr.Read())
            {
                Frmsekreterdetay frm = new Frmsekreterdetay();
                frm.tc = msktc.Text;
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı TC yada sifre");
            }
            bgl.baglanti().Close();
        }
    }
}
