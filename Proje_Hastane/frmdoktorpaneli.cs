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
    public partial class frmdoktorpaneli : Form
    {
        public frmdoktorpaneli()
        {
            InitializeComponent();
        }
       sqlbaglanti bgl=new sqlbaglanti();

        private void frmdoktorpaneli_Load(object sender, EventArgs e)
        {
            DataTable dt=new DataTable();
            SqlDataAdapter dr= new SqlDataAdapter("select * from tbl_doktorlar",bgl.baglanti());
            dr.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.baglanti().Close();


            SqlCommand komut4 = new SqlCommand("select bransad from tbl_branslar", bgl.baglanti());
            SqlDataReader dr1 = komut4.ExecuteReader();
            while (dr1.Read())
            {
                cmbbrans.Items.Add(dr1[0].ToString());
            }




        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut3=new SqlCommand("update tbl_doktorlar set doktorad=@a1,doktorsoyad=@a2,doktorbrans=@a3,doktortc=@a4,doktorsifre=@a5 where doktortc=@i6",bgl.baglanti());
            komut3.Parameters.AddWithValue("@a1", txtad.Text);
            komut3.Parameters.AddWithValue("@a2", txtsoyad.Text);
            komut3.Parameters.AddWithValue("@a3", cmbbrans.Text);
            komut3.Parameters.AddWithValue("@a4",msktc.Text);
            komut3.Parameters.AddWithValue("@a5", txtsifre.Text);
            komut3.Parameters.AddWithValue("@i6", msktc.Text);
            komut3.ExecuteNonQuery();
            MessageBox.Show("Kayıt başarıyla Güncellendi.","başarılı",MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnekle_Click(object sender, EventArgs e)
        {

        }

        private void btnekle_Click_1(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into tbl_doktorlar (doktorad,doktorsoyad,doktorbrans,doktortc,doktorsifre) values (@p1,@p2,@p3,@p4,@p5)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", cmbbrans.Text);
            komut.Parameters.AddWithValue("@p4", msktc.Text);
            komut.Parameters.AddWithValue("@p5", txtsifre.Text);
            komut.ExecuteNonQuery();

            MessageBox.Show("Doktor Başarıyla Eklendi.", "başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void txtad_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("delete from tbl_doktorlar where doktortc=@p1 ", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", msktc.Text);
            komut2.ExecuteNonQuery();
            MessageBox.Show("Kayıt Başarıyla Silindi","başarılı",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            txtad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbbrans.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            msktc.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtsifre.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
