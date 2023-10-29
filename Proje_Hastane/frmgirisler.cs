using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje_Hastane
{
    public partial class frmgirisler : Form
    {
        public frmgirisler()
        {
            InitializeComponent();
        }
   
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmhastagiris frmhasta = new frmhastagiris();

            frmhasta.Show();
            this.Hide();    

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmdoktorgiris doktorgiris=new frmdoktorgiris();

            doktorgiris.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmsekretergiris sekretergiris = new frmsekretergiris();

            sekretergiris.Show();

            this.Hide();
        }
    }
}
