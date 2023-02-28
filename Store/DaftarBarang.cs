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
    public partial class DaftarBarang : Form
    {
        List<Barang> listBarang = new List<Barang>();
        public DaftarBarang()
        {
            InitializeComponent();
            refresh();
        }

        private void FormatDataGrid()
        {
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("KodeBarang", "Kode Barang");
            dataGridView1.Columns.Add("Barcode", "Barcode");
            dataGridView1.Columns.Add("NamaBarang", "Nama Barang");
            dataGridView1.Columns.Add("HargaJual", "Harga Jual");
            dataGridView1.Columns.Add("Stok", "Stok");
            dataGridView1.Columns.Add("KodeKategori", "Kode Kategori");
            dataGridView1.Columns.Add("NamaKategori", "Nama Kategori");

            dataGridView1.Columns["KodeBarang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["Barcode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["NamaBarang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["HargaJual"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["Stok"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["KodeKategori"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["NamaKategori"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridView1.Columns["HargaJual"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["Stok"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dataGridView1.Columns["HargaJual"].DefaultCellStyle.Format = "0,###";
        }

        public void refresh()
        {
            listBarang.Clear();

            FormatDataGrid();

            string hasil = Barang.BacaData("", "", listBarang);

            if (hasil == "1")
            {
                dataGridView1.Rows.Clear();

                for (int i = 0; i < listBarang.Count; i++)
                {
                    dataGridView1.Rows.Add(listBarang[i].KodeBarang, listBarang[i].Barcode, listBarang[i].Nama, listBarang[i].HargaJual, listBarang[i].Stok, listBarang[i].Kategori.KodeKategori, listBarang[i].Kategori.Nama);
                }
            }
            else
            {
                dataGridView1.Rows.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormTambahBarang form = new FormTambahBarang();
            form.Owner = this;
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormUbahBarang form = new FormUbahBarang(); 
            form.Owner = this;
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormDeleteBarang form = new FormDeleteBarang();
            form.Owner = this;
            form.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string kriteria = "";

            if (comboBox1.Text == "Kode Barang")
            {
                kriteria = "B.KodeBarang";
            }
            else if (comboBox1.Text == "Barcode")
            {
                kriteria = "B.Barcode";
            }
            else if (comboBox1.Text == "Nama")
            {
                kriteria = "B.Nama";
            }
            else if (comboBox1.Text == "Harga Jual")
            {
                kriteria = "B.HargaJual";
            }
            else if (comboBox1.Text == "Stok")
            {
                kriteria = "B.Stok";
            }
            else if (comboBox1.Text == "Kode Kategori")
            {
                kriteria = "B.KodeKategori";
            }
            else if (comboBox1.Text == "Nama Kategori")
            {
                kriteria = "K.Nama";
            }

            listBarang.Clear();
            string hasil = Barang.BacaData(kriteria, textBox1.Text, listBarang);

            if (hasil == "1")
            {
                dataGridView1.Rows.Clear();

                for (int i = 0; i < listBarang.Count; i++)
                {
                    dataGridView1.Rows.Add(listBarang[i].KodeBarang, listBarang[i].Barcode, listBarang[i].Nama, listBarang[i].HargaJual, listBarang[i].Stok, listBarang[i].Kategori.KodeKategori, listBarang[i].Kategori.Nama);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
