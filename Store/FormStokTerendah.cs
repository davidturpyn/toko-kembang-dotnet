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
    public partial class FormStokTerendah : Form
    {
        public List<Barang> listbarang = new List<Barang>();
        public FormStokTerendah()
        {
            InitializeComponent();
        }

        private void FormStokTerendah_Load(object sender, EventArgs e)
        {
            refresh();
        }
        public void refresh()
        {
            dataGridViewBarang.Columns.Clear();
            dataGridViewBarang.Columns.Add("KodeBarang", "Kode Barang");
            dataGridViewBarang.Columns.Add("Barcode", "Barcode Barang");
            dataGridViewBarang.Columns.Add("Nama", "Nama Barang");
            dataGridViewBarang.Columns.Add("HargaJual", "Harga Jual (Rp)");
            dataGridViewBarang.Columns.Add("Stok", "Stok");
            dataGridViewBarang.Columns.Add("Kategori", "Kategori Barang");

            dataGridViewBarang.Columns["kodebarang"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewBarang.Columns["Barcode"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewBarang.Columns["Nama"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewBarang.Columns["HargaJual"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewBarang.Columns["Stok"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewBarang.Columns["Kategori"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridViewBarang.Columns["KodeBarang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewBarang.Columns["Barcode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewBarang.Columns["Nama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewBarang.Columns["HargaJual"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewBarang.Columns["Stok"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewBarang.Columns["Kategori"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            listbarang.Clear();
            string hasil = Barang.BacaData("Terendah", "", listbarang);

            if (hasil == "1")
            {
                for (int i = 0; i < listbarang.Count; i++)
                {
                    dataGridViewBarang.Rows.Add(listbarang[i].KodeBarang, listbarang[i].Barcode, listbarang[i].Nama, "Rp. " + listbarang[i].HargaJual.ToString("0,###"), listbarang[i].Stok, listbarang[i].Kategori.Nama); 
                }
            }
            else
            {
                dataGridViewBarang.DataSource = null;
            }
        }
    }
}
