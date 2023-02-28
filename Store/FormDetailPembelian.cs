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
    public partial class FormDetailPembelian : Form
    {
        List<NotaBeliDetil> listdetailpembelian = new List<NotaBeliDetil>();
        public FormDetailPembelian(string NoNotaBeli)
        {
            InitializeComponent();
            refresh();
            listdetailpembelian.Clear();
            string hasil = NotaBeliDetil.BacaData(NoNotaBeli, listdetailpembelian);
            if (hasil == "1")
            {
                labelNotaPenjualan.Text = listdetailpembelian[0].Pembelian.NoNotaBeli;
                labelTanggalPenjualan.Text = listdetailpembelian[0].Pembelian.Tanggal.ToString("dd/MM/yyyy");
                for (int i = 0; i < listdetailpembelian.Count; i++)
                {

                    dataGridViewDetailPembelian.Rows.Add(listdetailpembelian[i].Barang.KodeBarang, listdetailpembelian[i].Barang.Nama, listdetailpembelian[i].Jumlah, "Rp. " + listdetailpembelian[i].Harga, "Rp. " + (listdetailpembelian[i].Jumlah * listdetailpembelian[i].Harga));
                }
            }
            else
            {
                MessageBox.Show("salah");
            }
        }
        public void refresh()
        {

            dataGridViewDetailPembelian.Columns.Clear();
            dataGridViewDetailPembelian.Columns.Add("nama", "Nama Barang");
            dataGridViewDetailPembelian.Columns.Add("KodeBarang", "Kode Barang");            
            dataGridViewDetailPembelian.Columns.Add("jumlah", "Jumlah");
            dataGridViewDetailPembelian.Columns.Add("harga", "Harga Satuan");
            dataGridViewDetailPembelian.Columns.Add("subTotal", "Sub Total");

            dataGridViewDetailPembelian.Columns["nama"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewDetailPembelian.Columns["KodeBarang"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewDetailPembelian.Columns["jumlah"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewDetailPembelian.Columns["harga"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewDetailPembelian.Columns["subTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridViewDetailPembelian.Columns["nama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewDetailPembelian.Columns["KodeBarang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewDetailPembelian.Columns["jumlah"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewDetailPembelian.Columns["harga"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewDetailPembelian.Columns["subTotal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewDetailPembelian.Columns["harga"].DefaultCellStyle.Format = "0,###";
            dataGridViewDetailPembelian.Columns["subTotal"].DefaultCellStyle.Format = "0,###";

            listdetailpembelian.Clear();

        }
    }
}
