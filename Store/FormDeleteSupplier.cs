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
    public partial class FormDeleteSupplier : Form
    {
        List<Supplier> listSupplier = new List<Supplier>();
        public FormDeleteSupplier()
        {
            InitializeComponent();
            textBoxIDSupplier.MaxLength = 11;
        }

        private void textBoxIDSupplier_TextChanged(object sender, EventArgs e)
        {
            if (textBoxIDSupplier.Text.Length <= textBoxIDSupplier.MaxLength)
            {
                listSupplier.Clear();
                string hasilBaca = Supplier.BacaData("KodeSupplier", textBoxIDSupplier.Text, listSupplier);

                if (hasilBaca == "1")
                {
                    if (listSupplier.Count > 0)
                    {
                        textBoxNama.Text = listSupplier[0].Nama;
                        textBoxAlamat.Text = listSupplier[0].Alamat;
                        textBoxTelpon.Text = listSupplier[0].Telpon;
                    }
                    else
                    {
                        MessageBox.Show("Kode kategori tidak ditemukan, proses hapus data tidak bisa dilakukan");
                    }
                }
                else
                {
                    MessageBox.Show("Perintah SQL gagal dijalankan. pesan kesalahan = " + hasilBaca);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Supplier sup = new Supplier(int.Parse(textBoxIDSupplier.Text), textBoxNama.Text, textBoxAlamat.Text, textBoxTelpon.Text);
            string hasil = Supplier.HapusData(sup);
            if (hasil == "1")
            {
                MessageBox.Show("data berhasil dihapus");
            }
            else
            {
                MessageBox.Show("gagal hapus data. pesan kesalahan: " + hasil);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBoxIDSupplier.Text = "";
            textBoxAlamat.Text = "";
            textBoxNama.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DaftarSupplier form = (DaftarSupplier)this.Owner;

            form.Refresh();
            this.Close();
        }
    }
}
