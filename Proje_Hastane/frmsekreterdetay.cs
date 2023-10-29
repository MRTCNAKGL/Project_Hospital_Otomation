using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proje_Hastane
{
    public partial class frmsekreterdetay : Form
    {
        public frmsekreterdetay()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl = new sqlbaglanti();
        private void btnseversin_Click(object sender, EventArgs e)
        {
            string soli = "https://www.google.com/logos/fnbx/solitaire/standalone.html";

            Process.Start(soli);
        }

        private void btndoktorpanel_Click(object sender, EventArgs e)
        {
            frmdoktorpaneli doktorpanel=new frmdoktorpaneli();
            doktorpanel.Show();
            
        }

        private void btnrandevuliste_Click(object sender, EventArgs e)
        {
           frmrandevuliste randevuliste=new frmrandevuliste();

            randevuliste.Show();
        }

        private void btnbrans_Click(object sender, EventArgs e)
        {
            frmbrans bransrandevu = new frmbrans();

            bransrandevu.Show();

        }
        public string tc;
        private void frmsekreterdetay_Load(object sender, EventArgs e)
        {
            lbltc.Text=tc;

            //ad soyad getirme
            SqlCommand komut = new SqlCommand("select sekreteradsoyad from tbl_sekreter where sekretertc=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", tc);
            SqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                lbladsoyad.Text = dr[0].ToString();
            }
            bgl.baglanti().Close();

          
            // doktor getirme
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select (doktorad + ' '+doktorsoyad) as 'Doktorlar',doktorbrans from tbl_doktorlar", bgl.baglanti());
            da.Fill(dt);
            
            dataGridView2.DataSource = dt;

            bgl.baglanti().Close();

            //brans getirme
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2=new SqlDataAdapter("select * from tbl_branslar",bgl.baglanti());
            da2.Fill(dt2);

            dataGridView1.DataSource= dt2;

            // branşı comboboxa getirme
            SqlCommand komut3 = new SqlCommand("select bransad from tbl_branslar", bgl.baglanti());
            SqlDataReader dr2 = komut3.ExecuteReader();

            while (dr2.Read())
            {
                cmbbrans.Items.Add(dr2[0].ToString());
            }
            bgl.baglanti().Close();


            // doktorları comboboxa getirme

        

        }

        private void rchduyuru_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("insert into tbl_randevular (randevutarih,randevusaat,randevubrans,randevudoktor) values (@r1,@r2,@r3,@r4)", bgl.baglanti());
            komut2.Parameters.AddWithValue("@r1", msktarih.Text);
            komut2.Parameters.AddWithValue("@r2", msksaat.Text);
            komut2.Parameters.AddWithValue("@r3", cmbbrans.Text);
            komut2.Parameters.AddWithValue("@r4", cmbdoktor.Text);

            komut2.ExecuteNonQuery();

            MessageBox.Show("Randevu Başarıyla Oluşturuldu...","başarılı ",MessageBoxButtons.OK, MessageBoxIcon.Information);
            bgl.baglanti().Close();
 

        }

        private void cmbbrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbdoktor.Items.Clear();

            SqlCommand komut = new SqlCommand("select doktorad,doktorsoyad from tbl_doktorlar where doktorbrans=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",cmbbrans.Text);
            SqlDataReader dr= komut.ExecuteReader();

            while(dr.Read())
            {
                cmbdoktor.Items.Add(dr[0] + " " + dr[1].ToString());
            }
            bgl.baglanti().Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update  tbl_doktorlar set randevutarih=@a1,randevusaat=@a2,randevubrans=@a3,randevudoktor=@a4 where hastatc=@a5", bgl.baglanti());
            komut.Parameters.AddWithValue("@a1", msktarih.Text);
            komut.Parameters.AddWithValue("@a2", msksaat.Text);
            komut.Parameters.AddWithValue("@a3", cmbbrans.Text);
            komut.Parameters.AddWithValue("@a4", cmbdoktor.Text);
            komut.Parameters.AddWithValue("@a5", msktc.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu Güncellendi...", "başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnolustur_Click(object sender, EventArgs e)
        {
            SqlCommand komut =new SqlCommand("insert into tbl_duyurular (duyuru) values (@d1)",bgl.baglanti());
            komut.Parameters.AddWithValue("@d1",rchduyuru.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Duyuru Oluşturuldu...","başarılı",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmduyuru duyuru = new frmduyuru();
            duyuru.Show();
        }
    }
}
