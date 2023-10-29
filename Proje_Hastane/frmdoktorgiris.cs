﻿using System;
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
    public partial class frmdoktorgiris : Form
    {
        public frmdoktorgiris()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl=new sqlbaglanti();

   
        private void btngirisyap_Click(object sender, EventArgs e)
        {
          SqlCommand komut=new SqlCommand("select * from tbl_doktorlar where doktortc=@p1 and doktorsifre=@p2",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", msktc.Text);
            komut.Parameters.AddWithValue("@p2", txtsifre.Text);
            SqlDataReader dr= komut.ExecuteReader();

            if (dr.Read())
            {
                frmdoktordetay dkdetay = new frmdoktordetay();
                dkdetay.tc = msktc.Text;
                dkdetay.Show();
                this.Hide();

                bgl.baglanti().Close();
            }
            else
            {
                MessageBox.Show("Hatalı TC veya Şifre!","hata",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }

        }

        private void frmdoktorgiris_Load(object sender, EventArgs e)
        {

        }
    }
}
