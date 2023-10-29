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
    public partial class frmhastadetay : Form
    {
        public frmhastadetay()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl=new sqlbaglanti();
        private void frmhastadetay_Load(object sender, EventArgs e)
        {
            lbltc.Text = tc;

            //ad soyad getirme
            SqlCommand komut=new SqlCommand("select hastaad,hastasoyad from tbl_hastalar where hastatc=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", tc);
            SqlDataReader dr=komut.ExecuteReader();
           while(dr.Read())
            {
                lbladsoyad.Text = dr[0] +" "+ dr[1];
            }
            bgl.baglanti().Close();

            //randevu geçmişi

            DataTable dt=new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_randevular where hastatc=" + tc, bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            //branş çekme

            SqlCommand komut2 = new SqlCommand("select bransad from tbl_branslar", bgl.baglanti());
            SqlDataReader dr2=komut2.ExecuteReader();
            while(dr2.Read())
            {
                cmbbrans.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();

            //doktor çekme
            SqlCommand komut4 = new SqlCommand("select doktorad from tbl_doktorlar", bgl.baglanti());
            SqlDataReader dr3 = komut4.ExecuteReader();
            while(dr3.Read())
            {
                cmbdoktor.Items.Add(dr3[0].ToString());
            }

        }
        public string tc;
        private void lnkbilgiduzenle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmhastabilgiduzenle duzenle = new frmhastabilgiduzenle();
            duzenle.tc = lbltc.Text;
            duzenle.Show();

           
        }

        private void lbltc_Click(object sender, EventArgs e)
        {

        }

        private void cmbbrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbdoktor.Items.Clear();
            SqlCommand komut3 = new SqlCommand("select doktorad,doktorsoyad from tbl_doktorlar where doktorbrans=@p1", bgl.baglanti());
            komut3.Parameters.AddWithValue("@p1", cmbbrans.Text);
            SqlDataReader dr3=komut3.ExecuteReader();
            while(dr3.Read())
            {
                cmbdoktor.Items.Add(dr3[0]+ " " + dr3[1]);
            }
            bgl.baglanti().Close();
        }

        private void cmbdoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_randevular where randevubrans='" + cmbbrans.Text + "'" +"and randevudoktor='"+cmbdoktor.Text+"'and randevudurum=0", bgl.baglanti());
             da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnrandevual_Click(object sender, EventArgs e)
        {
            SqlCommand komutal = new SqlCommand("update tbl_randevular set randevudurum=1,hastatc=@r1,hastasikayet=@r2 where randevuid=@r3",bgl.baglanti());
            komutal.Parameters.AddWithValue("@r1", lbltc.Text);
            komutal.Parameters.AddWithValue("@r2", rhsikayet.Text);
            komutal.Parameters.AddWithValue("@r3",txtid.Text);
            komutal.ExecuteNonQuery();
            MessageBox.Show("Randevu başarıyla alındı","başarılı",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;

            txtid.Text = dataGridView2.SelectedCells[0].Value.ToString();

        }
    }
}
