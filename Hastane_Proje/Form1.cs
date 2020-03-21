using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hastane_Proje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnhastagirisi_Click(object sender, EventArgs e)
        {
            FrmHastaGiris frm = new FrmHastaGiris();
            frm.Show();
            this.Hide();
        }

        private void btndoktorgirisi_Click(object sender, EventArgs e)
        {
            Frmdoktorgiris frm = new Frmdoktorgiris();
            frm.Show();
            this.Hide();
        }

        private void btnsekretergirisi_Click(object sender, EventArgs e)
        {
            Frmsekretergiris frm = new Frmsekretergiris();
            frm.Show();
            this.Hide();
            
        }
    }
}
