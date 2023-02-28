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
    public partial class FormUbahKategori : Form
    {
        public FormUbahKategori()
        {
            InitializeComponent();

            textBoxKode.MaxLength = 2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Kategori k = new Kategori(textBoxKode.Text, textBoxNamaKategor.Text);

            string result = Kategori.UbahBarang(k);

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
            this.Close();
            DaftarKategoriBarang form = (DaftarKategoriBarang)this.Owner;
            form.refresh();
        }
        List<Kategori> listDataKat = new List<Kategori>();
        private void textBoxKode_TextChanged(object sender, EventArgs e)
        {
            if (textBoxKode.Text.Length == textBoxKode.MaxLength)
            {
                listDataKat.Clear();
                string hasil = Kategori.BacaData("KodeKategori", textBoxKode.Text, listDataKat);

                if (hasil == "1")
                {
                    if (listDataKat.Count > 0)
                    {
                        textBoxNamaKategor.Text = listDataKat[0].Nama;
                        textBoxNamaKategor.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Kode Kategori tidak ditemukan");
                        textBoxKode.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Perintah SQL gagal dijalankan. Pesan kesalahan = " + hasil);
                }
            }
        }
    }
}
