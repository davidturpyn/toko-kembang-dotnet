using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store
{
    public partial class FormTambahkategori : Form
    {
        public FormTambahkategori()
        {
            InitializeComponent();
            string kodeBaru;
            string hasilGenerate = Kategori.GenerateKode(out kodeBaru);

            if (hasilGenerate == "1")
            {
                textBoxKode.Text = kodeBaru;

                textBoxKode.Enabled = false;
                textBoxNamaKategor.Focus();
            }
            else
            {
                MessageBox.Show("Gagal" + hasilGenerate);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Kategori k = new Kategori(textBoxKode.Text, textBoxNamaKategor.Text);

            string result = Kategori.TambahBarang(k);

            if (result == "1")
            {
                MessageBox.Show("Data Kategori Telah tersimpan");
            }
            else
            {
                MessageBox.Show("Data gagal tersimpan. kesalahan : " + result);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBoxKode.Text = "";
            textBoxNamaKategor.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DaftarKategoriBarang form = (DaftarKategoriBarang)this.Owner;
            form.refresh();
            this.Close();
        }
    }
}
