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
    public partial class DaftarNotaJual : Form
    {
        public DaftarNotaJual()
        {
            InitializeComponent();

            Refresh();
        }

        private void FormatDataGrid()
        {
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("NoNota", "No Nota");
            dataGridView1.Columns.Add("Tanggal", "Tanggal");
            dataGridView1.Columns.Add("KodeBarang", "KodeBarang");
            dataGridView1.Columns.Add("Nama", "Nama Barang");
            dataGridView1.Columns.Add("Jumlah", "Jumlah");
            dataGridView1.Columns.Add("HargaJual", "Harga Barang");            
            dataGridView1.Columns.Add("NamaPegawai", "Nama Pegawai");

            dataGridView1.Columns["NoNota"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["Tanggal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["KodeBarang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["Nama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["Jumlah"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["HargaJual"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;           
            dataGridView1.Columns["NamaPegawai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
        
        List<NotaJual> listNotaJual = new List<NotaJual>();
        string kriteria = "";

        public void Refresh()
        {
            listNotaJual.Clear();

            FormatDataGrid();

            string hasil = NotaJual.BacaData("", "", listNotaJual);

            if (hasil == "1")
            {
                dataGridView1.Rows.Clear();

                for (int i = 0; i < listNotaJual.Count; i++)
                {
                    dataGridView1.Rows.Add(listNotaJual[i].NoNotaJual, listNotaJual[i].Tanggal, listNotaJual[i].NotaJualDetil[0].Barang.KodeBarang, listNotaJual[i].NotaJualDetil[0].Barang.Nama, listNotaJual[i].NotaJualDetil[0].Harga, listNotaJual[i].NotaJualDetil[0].Jumlah, listNotaJual[i].Pegawai.Nama);
                }
            }
            else
            {
                dataGridView1.Rows.Clear();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "No Nota")
            {
                kriteria = "njd.NoNota";
            }
            else if (comboBox1.Text == "Tanggal")
            {
                kriteria = "nj.Tanggal";
            }
            else if (comboBox1.Text == "Kode Barang")
            {
                kriteria = "njd.Kodebarang";
            }
            else if (comboBox1.Text == "Nama")
            {
                kriteria = "b.Nama";
            }
            else if (comboBox1.Text == "Harga")
            {
                kriteria = "njd.Harga";
            }
            else if (comboBox1.Text == "Jumlah")
            {
                kriteria = "njd.Jumlah";
            }
            else if (comboBox1.Text == "Nama Pegawai")
            {
                kriteria = "p.Nama";
            }

            string hasil = NotaJual.BacaData(kriteria, textBox1.Text, listNotaJual);

            if (hasil == "1")
            {
                dataGridView1.Rows.Clear();

                for (int i = 0; i < listNotaJual.Count; i++)
                {
                    dataGridView1.Rows.Add(listNotaJual[i].NoNotaJual, listNotaJual[i].Tanggal, listNotaJual[i].NotaJualDetil[0].Barang.KodeBarang, listNotaJual[i].NotaJualDetil[0].Barang.Nama, listNotaJual[i].NotaJualDetil[0].Jumlah, "Rp. " + listNotaJual[i].NotaJualDetil[0].Harga, listNotaJual[i].Pegawai.Nama);
                }
            }
            else
            {
                dataGridView1.Rows.Clear();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string hasilCetak = NotaJual.CetakNota(kriteria, textBox1.Text, "nota_jual.txt");

            if (hasilCetak == "1")
            {
                MessageBox.Show("nota jual telah tercetak");
            }
            else
            {
                MessageBox.Show("nota jual gagal di cetak. pesan kesalahan : " + hasilCetak);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormTambahNotaJual form = new FormTambahNotaJual();
            form.Owner = this;
            form.ShowDialog();
        }

        private void DaftarNotaJual_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {

        }
    }
}
