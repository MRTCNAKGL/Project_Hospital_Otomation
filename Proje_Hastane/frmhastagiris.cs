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

namespace Proje_Hastane
{
    public partial class frmhastagiris : Form
    {
        public frmhastagiris()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl=new sqlbaglanti();
        private void frmhastagiris_Load(object sender, EventArgs e)
        {

        }

        private void Lnküyeol_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmuyeol uyeol = new frmuyeol();

            uyeol.Show();


        }

        private void btngirisyap_Click(object sender, EventArgs e)
        {

            SqlCommand komut = new SqlCommand("select * from tbl_hastalar where hastatc=@p1 and hastasifre=@p2",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", msktc.Text);
            komut.Parameters.AddWithValue("@p2", txtsifre.Text);
            SqlDataReader dr = komut.ExecuteReader();

            if(dr.Read())
            {
                frmhastadetay fr = new frmhastadetay();
                fr.tc = msktc.Text;
                fr.Show();              
                this.Hide();

            }

            else
            {
                MessageBox.Show("Hatalı TC veya Şifre!","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            bgl.baglanti().Close();
        }
        }
}
