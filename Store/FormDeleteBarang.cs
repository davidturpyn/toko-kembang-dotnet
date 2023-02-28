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
    public partial class FormDeleteBarang : Form
    {
        List<Kategori> dataTambahKategori = new List<Kategori>();
        List<Barang> listBarang = new List<Barang>();
        public FormDeleteBarang()
        {
            InitializeComponent();

            string hasilBaca = Kategori.BacaData("", "", dataTambahKategori);
            if (hasilBaca == "1")
            {
                comboBoxKategoriBarang.Items.Clear();

                for (int i = 0; i < dataTambahKategori.Count; i++)
                {
                    comboBoxKategoriBarang.Items.Add(dataTambahKategori[i].KodeKategori + " - " + dataTambahKategori[i].Nama);
                }
            }
            else
            {
                MessageBox.Show("Data kategori barang gagal ditampilkan.");
            }
        }

        private void textBoxKodeBarang_TextChanged(object sender, EventArgs e)
        {
            if (textBoxKodeBarang.Text.Length == textBoxKodeBarang.MaxLength)
            {
                string hasil = Barang.BacaData("KodeBarang", textBoxKodeBarang.Text, listBarang);

                if (hasil == "1")
                {
                    textBoxKodeBarang.Text = listBarang[0].KodeBarang;
                    textBoxBarcode.Text = listBarang[0].Barcode;
                    textBoxHargaJual.Text = listBarang[0].HargaJual.ToString();
                    textBoxNamaBarang.Text = listBarang[0].Nama;
                    textBoxStock.Text = listBarang[0].Stok.ToString();

                    for (int i = 0; i < dataTambahKategori.Count; i++)
                    {
                        if (dataTambahKategori[i].KodeKategori == listBarang[0].Kategori.KodeKategori)
                        {
                            comboBoxKategoriBarang.SelectedIndex = i;
                        }
                    }
                }
                else
                {
                    MessageBox.Show(hasil);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int indexPilih = comboBoxKategoriBarang.SelectedIndex;
            Kategori kategoriBrg = dataTambahKategori[indexPilih];

            Barang brg = new Barang(textBoxKodeBarang.Text, textBoxNamaBarang.Text, long.Parse(textBoxHargaJual.Text), int.Parse(textBoxStock.Text), textBoxBarcode.Text, kategoriBrg);
            string hasil = Barang.HapusBarang(brg);
            if (hasil == "1")
            {
                MessageBox.Show("Barang berhasil di hapus");
            }
            else
            {
                MessageBox.Show(hasil);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBoxKategoriBarang.SelectedIndex = 0;
            textBoxKodeBarang.Text = "";
            textBoxBarcode.Text = "";
            textBoxHargaJual.Text = "";
            textBoxNamaBarang.Text = "";
            textBoxStock.Text = "";

            string kodeKategori = comboBoxKategoriBarang.Text.Substring(0, 2);
            string kodeTerbaru;

            string hasilGenerate = Barang.GenerateKode(kodeKategori, out kodeTerbaru);

            if (hasilGenerate == "1")
            {
                textBoxKodeBarang.Text = kodeTerbaru;
                textBoxBarcode.Focus();
            }
            else
            {
                MessageBox.Show(hasilGenerate);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DaftarBarang form = (DaftarBarang)this.Owner;
            form.refresh();
            this.Close();
        }
    }
}
