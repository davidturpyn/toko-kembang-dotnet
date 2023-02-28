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
    public partial class FormDeleteKategori : Form
    {
        public FormDeleteKategori()
        {
            InitializeComponent();
            textBoxKode.MaxLength = 2;
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

        private void button2_Click(object sender, EventArgs e)
        {
            Kategori k = new Kategori(textBoxKode.Text, textBoxNamaKategor.Text);

            string result = Kategori.HapusBarang(k);

            if (result == "1")
            {
                MessageBox.Show("Data Kategori Telah terhapus");
            }
            else
            {
                MessageBox.Show("Data gagal terhapus. kesalahan : " + result);
            }
        }

        List<Kategori> listData = new List<Kategori>();
        private void textBoxKode_TextChanged(object sender, EventArgs e)
        {
            if (textBoxKode.Text.Length == textBoxKode.MaxLength)
            {
                listData.Clear();
                string hasil = Kategori.BacaData("KodeKategori", textBoxKode.Text, listData);

                if (hasil == "1")
                {
                    if (listData.Count > 0)
                    {
                        textBoxNamaKategor.Text = listData[0].Nama;
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
