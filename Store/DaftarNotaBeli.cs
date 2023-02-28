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
    public partial class DaftarNotaBeli : Form
    {
        public static String notaPembelian = "";
        public DaftarNotaBeli()
        {
            InitializeComponent();
            Refresh();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "No Nota")
            {
                kriteria = "nb.NoNota";
            }
            else if (comboBox1.Text == "Tanggal")
            {
                kriteria = "nb.Tanggal";
            }
            else if (comboBox1.Text == "Kode Supplier")
            {
                kriteria = "nb.KodeSupplier";
            }
            else if (comboBox1.Text == "Nama Supplier")
            {
                kriteria = "s.Nama";
            }
            else if (comboBox1.Text == "Alamat Supplier")
            {
                kriteria = "s.Alamat";
            }
            else if (comboBox1.Text == "Kode Pegawai")
            {
                kriteria = "nb.KodePegawai";
            }
            else if (comboBox1.Text == "Nama Pegawai")
            {
                kriteria = "p.Nama";
            }

            string hasil = NotaBeli.BacaData(kriteria, textBox1.Text, listNotaBeli);

            if (hasil == "1")
            {
                dataGridViewPembelian.Rows.Clear();

                for (int i = 0; i < listNotaBeli.Count; i++)
                {
                    dataGridViewPembelian.Rows.Add(listNotaBeli[i].NoNotaBeli, listNotaBeli[i].Tanggal, listNotaBeli[i].Supplier.KodeSupplier, listNotaBeli[i].Supplier.Nama, listNotaBeli[i].Supplier.Alamat, listNotaBeli[i].Pegawai.KodePegawai, listNotaBeli[i].Pegawai.Nama);
                }
            }
            else
            {
                dataGridViewPembelian.Rows.Clear();
            }
        }

        List<NotaBeli> listNotaBeli = new List<NotaBeli>();
        string kriteria = "";

        public void Refresh()
        {
            listNotaBeli.Clear();

            FormatDataGrid();

            string hasil = NotaBeli.BacaData("", "", listNotaBeli);

            if (hasil == "1")
            {
                dataGridViewPembelian.Rows.Clear();

                for (int i = 0; i < listNotaBeli.Count; i++)
                {
                    dataGridViewPembelian.Rows.Add(listNotaBeli[i].NoNotaBeli, listNotaBeli[i].Tanggal, listNotaBeli[i].Supplier.KodeSupplier, listNotaBeli[i].Supplier.Nama, listNotaBeli[i].Supplier.Alamat, listNotaBeli[i].Pegawai.KodePegawai, listNotaBeli[i].Pegawai.Nama);
                }
            }
            else
            {
                dataGridViewPembelian.Rows.Clear();
            }
        }

        private void FormatDataGrid()
        {
            dataGridViewPembelian.Columns.Clear();

            dataGridViewPembelian.Columns.Add("NoNota", "No Nota");
            dataGridViewPembelian.Columns.Add("Tanggal", "Tanggal");
            dataGridViewPembelian.Columns.Add("KodeSupplier", "Kode Supplier");
            dataGridViewPembelian.Columns.Add("NamaSupplier", "Nama Supplier");
            dataGridViewPembelian.Columns.Add("AlamatSupplier", "Alamat Supplier");
            dataGridViewPembelian.Columns.Add("KodePegawai", "Kode Pegawai");
            dataGridViewPembelian.Columns.Add("NamaPegawai", "Nama Pegawai");

            dataGridViewPembelian.Columns["NoNota"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPembelian.Columns["Tanggal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPembelian.Columns["KodeSupplier"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPembelian.Columns["NamaSupplier"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPembelian.Columns["AlamatSupplier"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPembelian.Columns["KodePegawai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPembelian.Columns["NamaPegawai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string hasilCetak = NotaBeli.CetakNota(kriteria, textBox1.Text, "nota_Beli.txt");

            if (hasilCetak == "1")
            {
                MessageBox.Show("nota beli telah tercetak");
            }
            else
            {
                MessageBox.Show("nota beli gagal di cetak. pesan kesalahan : " + hasilCetak);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            FormTambahNotaBeli form = new FormTambahNotaBeli();
            form.Owner = this;
            form.ShowDialog();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewPembelian_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            notaPembelian = dataGridViewPembelian.Rows[e.RowIndex].Cells["noNota"].Value.ToString();
            FormDetailPembelian detail = new FormDetailPembelian(notaPembelian);
            detail.Show();
        }

        private void dataGridViewPembelian_CellContentDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
    }
}
