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
    public partial class frmdoktorbilgiduzenle : Form
    {
        public frmdoktorbilgiduzenle()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl = new sqlbaglanti();
        private void btnbilgiguncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update tbl_doktorlar set doktorad=@d1,doktorsoyad=@d2,doktorbrans=@d3,doktorsifre=@d4 where doktortc=@d5", bgl.baglanti());
            komut.Parameters.AddWithValue("@d1", txtad.Text);
            komut.Parameters.AddWithValue("@d2",txtsoyad.Text);
            komut.Parameters.AddWithValue("@d3", cmbbrans.Text);
            komut.Parameters.AddWithValue("@d4",txtsifre.Text);
            komut.Parameters.AddWithValue("@d5",msktc.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Bilgiler başarıyla güncellendi","başarılı",MessageBoxButtons.OK, MessageBoxIcon.Information);
            bgl.baglanti().Close();
        }
        public string tcno;
        private void frmdoktorbilgiduzenle_Load(object sender, EventArgs e)
        {
            msktc.Text = tcno;


            SqlCommand komut2 = new SqlCommand("select * from tbl_doktorlar where doktortc=@p1", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1",msktc.Text);
            SqlDataReader dr= komut2.ExecuteReader();
            while (dr.Read())
            {
                txtad.Text = dr[1].ToString();
                txtsoyad.Text = dr[2].ToString();
                cmbbrans.Text = dr[3].ToString();
                txtsifre.Text = dr[5].ToString();
            }
            
        }
    }
}
