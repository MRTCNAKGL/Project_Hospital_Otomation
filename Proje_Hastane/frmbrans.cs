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
    public partial class frmbrans : Form
    {
        public frmbrans()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl=new sqlbaglanti();
        private void frmbrans_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable(); 
            SqlDataAdapter da=new SqlDataAdapter("select * from tbl_branslar",bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into tbl_branslar (bransid,bransad) values (@p1,@p2)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtid.Text);
            komut.Parameters.AddWithValue("@p2", txtbransad.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Branş Başarıyla Eklendi..");

          

        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("delete from tbl_branslar where bransid=@b1", bgl.baglanti());
            komut2.Parameters.AddWithValue("@b1", txtid.Text);
            komut2.ExecuteNonQuery();
            MessageBox.Show("Branş başarıyla Silindi...","başarılı",MessageBoxButtons.OK,MessageBoxIcon.Information);   

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtbransad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();




        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut3 = new SqlCommand("update  tbl_branslar set bransad=@p1 where bransid=@p2",bgl.baglanti());
            komut3.Parameters.AddWithValue("@p1",txtbransad.Text);
            komut3.Parameters.AddWithValue("@p2", txtid.Text);
            komut3.ExecuteNonQuery();
            
            MessageBox.Show("Branş başarıyla güncellendi.","başarılı",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
