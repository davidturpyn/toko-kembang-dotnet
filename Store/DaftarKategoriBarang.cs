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
    public partial class DaftarKategoriBarang : Form
    {
        List<Kategori> listDataKategori = new List<Kategori>();
        public DaftarKategoriBarang()
        {
            InitializeComponent();
            refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormTambahkategori form = new FormTambahkategori();
            form.Owner = this;
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormUbahKategori form = new FormUbahKategori();
            form.Owner = this;
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormDeleteKategori form = new FormDeleteKategori();
            form.Owner = this;
            form.ShowDialog();
        }

        public void refresh()
        {
            listDataKategori.Clear();
            string hasil = Kategori.BacaData("", "", listDataKategori);

            if (hasil == "1")
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = listDataKategori;
            }
            else
            {
                dataGridView1.DataSource = null;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string res = "";

            if (comboBox1.Text == "Id Jabatan")
            {
                res = "IdJabatan";
            }
            else if (comboBox1.Text == "Nama")
            {
                res = "Nama";
            }

            listDataKategori.Clear();

            string hasil = Kategori.BacaData(res , textBox1.Text, listDataKategori);

            if (hasil  == "1")
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = listDataKategori;
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
