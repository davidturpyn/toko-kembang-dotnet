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
    public partial class FormTambahNotaJual : Form
    {
        
        List<Barang> listBarang = new List<Barang>();
        public FormTambahNotaJual()
        {
            InitializeComponent();

            string hasilNoNota;
            string hasilGenerate = NotaJual.GenerateNoNota(out hasilNoNota);

            if (hasilGenerate == "1")
            {
                textBoxNoNota.Text = hasilNoNota;
                textBoxNoNota.Enabled = false;
            }
            else
            {
                MessageBox.Show(hasilGenerate);
            }

            dateTimePickerTanggal.Value = DateTime.Now;
            dateTimePickerTanggal.Enabled = false;


            formatDataGrid();
        }

        private void formatDataGrid()
        {
            dataGridViewBarang.Columns.Clear();

            dataGridViewBarang.Columns.Add("KodeBarang", "Kode Barang");
            dataGridViewBarang.Columns.Add("Namabarang", "Nama Barang");
            dataGridViewBarang.Columns.Add("HargaJual", "Harga Jual");
            dataGridViewBarang.Columns.Add("Jumlah", "Jumlah");
            dataGridViewBarang.Columns.Add("SubTotal", "Sub Total");

            dataGridViewBarang.Columns["KodeBarang"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewBarang.Columns["NamaBarang"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewBarang.Columns["HargaJual"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewBarang.Columns["Jumlah"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewBarang.Columns["SubTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridViewBarang.Columns["KodeBarang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewBarang.Columns["NamaBarang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewBarang.Columns["Jumlah"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewBarang.Columns["HargaJual"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewBarang.Columns["SubTotal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridViewBarang.Columns["HargaJual"].DefaultCellStyle.Format = "0,###";
            dataGridViewBarang.Columns["SubTotal"].DefaultCellStyle.Format = "0,###";

            dataGridViewBarang.AllowUserToAddRows = false;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Pegawai pegawai = new Pegawai();
            pegawai.KodePegawai = int.Parse(labelKodePegawai.Text);
            pegawai.Nama = labelNamaPegawai.Text;

            NotaJual nota = new NotaJual(textBoxNoNota.Text, dateTimePickerTanggal.Value, pegawai);

            for (int i = 0; i < dataGridViewBarang.Rows.Count; i++)
            {
                Barang brg = new Barang();
                brg.KodeBarang = dataGridViewBarang.Rows[i].Cells["KodeBarang"].Value.ToString();
                brg.Nama = dataGridViewBarang.Rows[i].Cells["NamaBarang"].Value.ToString();

                int harga = int.Parse(dataGridViewBarang.Rows[i].Cells["HargaJual"].Value.ToString());
                int jumlah = int.Parse(dataGridViewBarang.Rows[i].Cells["Jumlah"].Value.ToString());
                NotaJualDetil notaDetil = new NotaJualDetil(brg, jumlah, harga);
                
                nota.TambahDetilBarang(brg, jumlah, harga);
            }

            string hasiltambah = NotaJual.TambahData(nota);

            if (hasiltambah == "1")
            {
                MessageBox.Show("data nota jual telah tersimpan", "info");
                button3_Click(sender, e);
            }
            else
            {
                MessageBox.Show("data nota jual gagal disimpan. pesan kesalahan " + hasiltambah);
            }
        }

       

        private void textBoxBarcode_TextChanged(object sender, EventArgs e)
        {
            if (textBoxBarcode.Text.Length == textBoxBarcode.MaxLength)
            {
                listBarang.Clear();

                string hasil = Barang.BacaData("B.Barcode", textBoxBarcode.Text, listBarang);

                if (hasil == "1")
                {
                    if (listBarang.Count > 0)
                    {
                        textBoxKode.Text = listBarang[0].KodeBarang;
                        textBoxNama.Text = listBarang[0].Nama;
                        textBoxHarga.Text = listBarang[0].HargaJual.ToString();
                        textBoxJumlah.Text = 1.ToString();
                        textBoxJumlah.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Barang tidak ditemukan");
                        textBoxBarcode.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Perintah sql gagal dijalankan. pesan kesalahan " + hasil);
                }
            }
            else
            {
                textBoxKode.Text = "";
                textBoxNama.Text = "";
                textBoxHarga.Text = "";
                textBoxJumlah.Text = "";
            }
        }

        private int HitungGrandTotal()
        {
            int grandtotal = 0;
            for (int i = 0; i < dataGridViewBarang.Rows.Count; i++)
            {
                int subtotal = int.Parse(dataGridViewBarang.Rows[i].Cells["SubTotal"].Value.ToString());
                grandtotal = grandtotal + subtotal;
            }
            return grandtotal;
        }

        private void textBoxJumlah_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int subtotal = int.Parse(textBoxJumlah.Text) * int.Parse(textBoxHarga.Text);
                dataGridViewBarang.Rows.Add(textBoxKode.Text, textBoxNama.Text, textBoxHarga.Text, textBoxJumlah.Text, subtotal);
                labelGrandTotal.Text = HitungGrandTotal().ToString("0,####");
                textBoxBarcode.Clear();
                textBoxKode.Clear();
                textBoxNama.Clear();
                textBoxHarga.Clear();
                textBoxJumlah.Clear();
                textBoxBarcode.Focus();
            }
        }

        private void FormTambahNotaJual_Load(object sender, EventArgs e)
        {
            FormMenu formUtama = (FormMenu)Application.OpenForms["FormMenu"];
            labelKodePegawai.Text = formUtama.labelKode.Text;
            labelNamaPegawai.Text = formUtama.labelNamaPegawai.Text;
        }
        string kriteria = "";
        private void button3_Click(object sender, EventArgs e)
        {
            string hasilCetak = NotaJual.CetakNota(kriteria, textBoxNoNota.Text, "nota_jual.txt");

            if (hasilCetak == "1")
            {
                MessageBox.Show("nota jual telah tercetak");
            }
            else
            {
                MessageBox.Show("nota jual gagal di cetak. pesan kesalahan : " + hasilCetak);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePickerTanggal_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
