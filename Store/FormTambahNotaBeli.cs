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
    public partial class FormTambahNotaBeli : Form
    {
        List<Supplier> listSupplier = new List<Supplier>();
        List<Barang> listBarang = new List<Barang>();
        public FormTambahNotaBeli()
        {
            InitializeComponent();

            string hasilNoNota;

            string hasilGenerate = NotaBeli.GenerateNoNota(out hasilNoNota);

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
            
            string hasilBacaSupplier = Supplier.BacaData("", "", listSupplier);
            if (hasilBacaSupplier == "1")
            {
                comboBoxSupplier.Items.Clear();
                for (int i = 0; i < listSupplier.Count; i++)
                {
                    comboBoxSupplier.Items.Add(listSupplier[i].KodeSupplier + " - " + listSupplier[i].Nama);
                }
            }
            else
            {
                MessageBox.Show("Data supplier gagal ditampilkan di combobox. pesan kesalahan: " + hasilBacaSupplier);
            }
            
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

            dataGridViewBarang.Columns["KodeBarang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewBarang.Columns["NamaBarang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewBarang.Columns["HargaJual"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewBarang.Columns["Jumlah"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewBarang.Columns["SubTotal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridViewBarang.Columns["KodeBarang"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewBarang.Columns["NamaBarang"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewBarang.Columns["Jumlah"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewBarang.Columns["HargaJual"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewBarang.Columns["SubTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; ;

            dataGridViewBarang.Columns["HargaJual"].DefaultCellStyle.Format = "0,###";
            dataGridViewBarang.Columns["SubTotal"].DefaultCellStyle.Format = "0,###";

            dataGridViewBarang.AllowUserToAddRows = false;
        }

        private void comboBoxSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            listSupplier.Clear();

            string hasil = Supplier.BacaData("KodeSupplier", comboBoxSupplier.Text.Substring(0, 1), listSupplier);
            
            if (hasil == "1")
            {
                textBoxAlamat.Clear();

                if (listSupplier.Count > 0)
                {
                    textBoxAlamat.Text = listSupplier[0].Alamat;
                }
                else
                {
                    textBoxAlamat.Text = "";
                    MessageBox.Show("Kode Supplier tidak ditemukan");
                }
            }
            else
            {
                MessageBox.Show("Perintah sql gagal dijalankan. pesan kesalahan = " + hasil);
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

        private void button2_Click(object sender, EventArgs e)
        {
            Supplier supplier = new Supplier(int.Parse(comboBoxSupplier.Text.Substring(0, 1)), comboBoxSupplier.Text.Substring(4, comboBoxSupplier.Text.Length - 4), textBoxAlamat.Text, textBoxTelpon.Text);
                        
            Pegawai pegawai = new Pegawai();
            pegawai.KodePegawai = int.Parse(labelKodePegawai.Text);
            pegawai.Nama = labelNamaPegawai.Text;

            NotaBeli nota = new NotaBeli(textBoxNoNota.Text, dateTimePickerTanggal.Value, pegawai, supplier);
            
            for (int i = 0; i < dataGridViewBarang.Rows.Count; i++)
            {
                Barang brg = new Barang();
                brg.KodeBarang = dataGridViewBarang.Rows[i].Cells["KodeBarang"].Value.ToString();
                brg.Nama = dataGridViewBarang.Rows[i].Cells["NamaBarang"].Value.ToString();

                int harga = int.Parse(dataGridViewBarang.Rows[i].Cells["HargaJual"].Value.ToString());
                int jumlah = int.Parse(dataGridViewBarang.Rows[i].Cells["Jumlah"].Value.ToString());

                NotaJualDetil notaDetil = new NotaJualDetil(brg, jumlah, harga);
                
                nota.TambahDetilBarang(harga, jumlah, brg);
            }
            string hasiltambah = NotaBeli.TambahData(nota);
            if (hasiltambah == "1")
            {
                MessageBox.Show("data nota beli telah tersimpan", "info");
                button3_Click(sender, e);
            }
            else
            {
                MessageBox.Show("data nota beli gagal disimpan. pesan kesalahan " + hasiltambah);
            }
        }

        private void FormTambahNotaBeli_Load(object sender, EventArgs e)
        {
            FormMenu formUtama = (FormMenu)Application.OpenForms["FormMenu"];
            labelKodePegawai.Text = formUtama.labelKode.Text;
            labelNamaPegawai.Text = formUtama.labelNamaPegawai.Text;
        }
        string kriteria = "nb.NoNota";

        private void button3_Click(object sender, EventArgs e)
        {
            string hasilCetak = NotaBeli.CetakNota(kriteria, textBoxNoNota.Text, "nota_beli.txt");
            
            if (hasilCetak == "1")
            {
                MessageBox.Show("nota jual telah tercetak");
            }
            else
            {
                MessageBox.Show("nota beli gagal di cetak. pesan kesalahan : " + hasilCetak);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
