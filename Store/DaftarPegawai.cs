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
    public partial class DaftarPegawai : Form
    {
        List<Pegawai> listPegawai = new List<Pegawai>();
        public DaftarPegawai()
        {
            InitializeComponent();
            refresh();
        }

        private void FormatDataGrid()
        {
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("KodePegawai", "Kode Pegawai");
            dataGridView1.Columns.Add("Nama", "Nama Pegawai");
            dataGridView1.Columns.Add("TglLahir", "Tanggal Lahir");
            dataGridView1.Columns.Add("Alamat", "Alamat");
            dataGridView1.Columns.Add("Gaji", "Gaji");
            dataGridView1.Columns.Add("Username", "Username");
            dataGridView1.Columns.Add("IdJabatan", "Id Jabatan");
            dataGridView1.Columns.Add("NamaJabatan", "Nama Jabatan");

            dataGridView1.Columns["KodePegawai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["Nama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["TglLahir"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["Alamat"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["Gaji"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["Username"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["IdJabatan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["NamaJabatan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridView1.Columns["Gaji"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["KodePegawai"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dataGridView1.Columns["Gaji"].DefaultCellStyle.Format = "0,###";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormTambahPegawai form = new FormTambahPegawai();
            form.Owner = this;
            form.ShowDialog();
        }

        public void refresh()
        {
            listPegawai.Clear();

            FormatDataGrid();

            string hasil = Pegawai.BacaData("", "", listPegawai);

            if (hasil == "1")
            {
                dataGridView1.Rows.Clear();

                for (int i = 0; i < listPegawai.Count; i++)
                {
                    dataGridView1.Rows.Add(listPegawai[i].KodePegawai, listPegawai[i].Nama, listPegawai[i].TglLahir, listPegawai[i].Alamat, listPegawai[i].Gaji, listPegawai[i].Username, listPegawai[i].Jabatan.IdJabatan, listPegawai[i].Jabatan.NamaJabatan);
                }
            }
            else
            {
                dataGridView1.Rows.Clear();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string kriteria = "";

            if (comboBox1.Text == "Kode Pegawai")
            {
                kriteria = "p.KodePegawai";
            }
            else if (comboBox1.Text == "Nama")
            {
                kriteria = "p.Nama";
            }
            else if (comboBox1.Text == "Tanggal Lahir")
            {
                kriteria = "p.TglLahir";
            }
            else if (comboBox1.Text == "Alamat")
            {
                kriteria = "p.Alamat";
            }
            else if (comboBox1.Text == "Gaji")
            {
                kriteria = "p.Gaji";
            }
            else if (comboBox1.Text == "Username")
            {
                kriteria = "p.Username";
            }
            else if (comboBox1.Text == "Id Jabatan")
            {
                kriteria = "p.IdJabatan";
            }
            else if (comboBox1.Text == "Nama Jabatan")
            {
                kriteria = "j.Nama";
            }

            listPegawai.Clear();
            string hasil = Pegawai.BacaData(kriteria, textBox1.Text, listPegawai);

            if (hasil == "1")
            {
                dataGridView1.Rows.Clear();

                for (int i = 0; i < listPegawai.Count; i++)
                {
                    dataGridView1.Rows.Add(listPegawai[i].KodePegawai, listPegawai[i].Nama, listPegawai[i].TglLahir, listPegawai[i].Alamat, listPegawai[i].Gaji, listPegawai[i].Username, listPegawai[i].Jabatan.IdJabatan, listPegawai[i].Jabatan.NamaJabatan);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormUbahPegawai form = new FormUbahPegawai();
            form.Owner = this;
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormDeletePegawai form = new FormDeletePegawai();
            form.Owner = this;
            form.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
