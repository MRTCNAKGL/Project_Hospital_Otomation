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
    public partial class frmdoktordetay : Form
    {
        public frmdoktordetay()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl=new sqlbaglanti();
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            frmdoktorbilgiduzenle doktorbilgiduzenle=new frmdoktorbilgiduzenle();
            doktorbilgiduzenle.tcno = lbltc.Text; 
            doktorbilgiduzenle.Show();
          
        }

        private void btnduyurular_Click(object sender, EventArgs e)
        {
            frmduyuru duyuru=new frmduyuru();
            duyuru.Show();

        }
        public string tc;
        private void btncikis_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Başlangıç Ekranına Dönmek İster Misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {

                frmgirisler giris = new frmgirisler();

                giris.Show();
                this.Hide();
            }

            else
            {
                Application.Exit();
            }

        }

        private void frmdoktordetay_Load(object sender, EventArgs e)
        {
            lbltc.Text = tc;

            //ad soyad getirme

            SqlCommand komut = new SqlCommand("select doktorad,doktorsoyad from tbl_doktorlar where doktortc=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", tc);
            SqlDataReader dr=komut.ExecuteReader();
            while(dr.Read())
            {
                lbladsoyad.Text = dr[0]+" "+dr[1].ToString();
            }


            DataTable dt=new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_randevular where randevudoktor='"+lbladsoyad.Text+"'",bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void rchsikayet_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            rchsikayet.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
        }
    }
}
