using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_Sederhana
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
                int angka1 = Convert.ToInt32(Angka1.Text);
                int angka2 = Convert.ToInt32(Angka2.Text);

                int hasil = angka1 + angka2;

                lblHasil.Text = "Hasil : " + hasil.ToString();
        }

        private void btnKurang_Click(object sender, EventArgs e)
        {
            int angka1 = Convert.ToInt32(Angka1.Text);
            int angka2 = Convert.ToInt32(Angka2.Text);

            int hasil = angka1 - angka2;

            lblHasil.Text = "Hasil : " + hasil.ToString();
        }

        private void btnKali_Click(object sender, EventArgs e)
        {
            int angka1 = Convert.ToInt32(Angka1.Text);
            int angka2 = Convert.ToInt32(Angka2.Text);

            int hasil = angka1 * angka2;

            lblHasil.Text = "Hasil : " + hasil.ToString();
        }

        private void btnBagi_Click(object sender, EventArgs e)
        {
            double angka1 = Convert.ToDouble(Angka1.Text);
            double angka2 = Convert.ToDouble(Angka2.Text);

            double hasil = angka1 / angka2;

            lblHasil.Text = "Hasil : " + hasil.ToString();
        }
    }
}
