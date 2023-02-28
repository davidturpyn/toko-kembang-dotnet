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
    public partial class DaftarSupplier : Form
    {
        List<Supplier> listSupplier = new List<Supplier>();
        public DaftarSupplier()
        {
            InitializeComponent();

            Refresh();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string kriteria = "";

            if (comboBox1.Text == "Kode Supplier")
            {
                kriteria = "KodeSupplier";
            }
            else if (comboBox1.Text == "Nama")
            {
                kriteria = "Nama";
            }
            else if(comboBox1.Text == "Alamat")
            {
                kriteria = "Alamat";
            }
            else if (comboBox1.Text == "Telpon")
            {
                kriteria = "Telpon";
            }

            listSupplier.Clear();

            string hasilBaca = Supplier.BacaData(kriteria, textBox1.Text, listSupplier);

            if (hasilBaca == "1")
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = listSupplier;
            }
            else
            {
                MessageBox.Show("gagal mencari data. pesan kesalahan: " + hasilBaca);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormTambahSupplier form = new FormTambahSupplier();
            form.Owner = this;
            form.ShowDialog();
        }

        public void Refresh()
        {
            listSupplier.Clear();
            string hasilBaca = Supplier.BacaData("", "", listSupplier);

            if (hasilBaca == "1") 
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = listSupplier;
            }
            else
            {
                MessageBox.Show("Data Gagal ditampilkan");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormUbahSupplier form = new FormUbahSupplier();
            form.Owner = this;
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormDeleteSupplier form = new FormDeleteSupplier();
            form.Owner = this;
            form.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
