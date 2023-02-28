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
    public partial class FormTambahBarang : Form
    {
        List<Kategori> dataTambahKategori = new List<Kategori>();
        public FormTambahBarang()
        {
            InitializeComponent();

        }

        private void FormTambahBarang_Load(object sender, EventArgs e)
        {
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

        private void button2_Click(object sender, EventArgs e)
        {
            int indexPilih = comboBoxKategoriBarang.SelectedIndex;
            Kategori kategoriBrg = dataTambahKategori[indexPilih];

            Barang brg = new Barang(textBoxKodeBarang.Text, textBoxNamaBarang.Text, long.Parse(textBoxHargaJual.Text), int.Parse(textBoxStock.Text), textBoxBarcode.Text, kategoriBrg);
            string hasilTambah = Barang.TambahBarang(brg);

            if (hasilTambah == "1")
            {
                MessageBox.Show("Barang Telah Tersimpan");
                FormTambahBarang_Load(sender, e);
            }
            else
            {
                MessageBox.Show("gagal tambah barang");
            }
        }

        private void comboBoxKategoriBarang_SelectedIndexChanged(object sender, EventArgs e)
        {
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
