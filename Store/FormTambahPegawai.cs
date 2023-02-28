using JualBeli_LIB;
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
    public partial class FormTambahPegawai : Form
    {
        List<Jabatan> listJabatan = new List<Jabatan>();
        public FormTambahPegawai()
        {
            InitializeComponent();

            string hasilKode = "";
            string hasil = Pegawai.GenerateKode(out hasilKode);

            if (hasil == "1")
            {
                textBoxKode.Text = hasilKode;
                textBoxNamaPegawai.Focus();
            }
            else
            {
                MessageBox.Show(hasil);
            }

            string hasilBaca = Jabatan.BacaData("", "", listJabatan);
            if (hasilBaca == "1")
            {
                comboBoxJabatan.Items.Clear();
                for (int i = 0; i < listJabatan.Count; i++)
                {
                    comboBoxJabatan.Items.Add(listJabatan[i].IdJabatan + " - " + listJabatan[i].NamaJabatan);
                }
            }
            else
            {
                MessageBox.Show("Data jenis jabatan barang gagal ditampilkan.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBoxPassword.Text == textBoxUalngpassword.Text)
            {
                int indexPilih = comboBoxJabatan.SelectedIndex;
                Jabatan j = listJabatan[indexPilih];

                Pegawai p = new Pegawai(int.Parse(textBoxKode.Text), textBoxNamaPegawai.Text, textBoxUsername.Text, textBoxPassword.Text, dateTimePicker1.Value, textBoxAlamat.Text, int.Parse(textBoxGaji.Text), j);
                string hasil = Pegawai.TambahPegawai(p);
                if (hasil == "1")
                {
                    MessageBox.Show("Data berhasil ditambahkan");
                }
                else
                {
                    MessageBox.Show(hasil);
                }
            }
            else
            {
                MessageBox.Show("Password tidak sama");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            DaftarPegawai form = (DaftarPegawai)this.Owner;
            form.refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBoxAlamat.Text = "";
            textBoxGaji.Text = "";
            textBoxKode.Text = "";
            textBoxNamaPegawai.Text = "";
            textBoxPassword.Text = "";
            textBoxUalngpassword.Text = "";
            textBoxUsername.Text = "";
            dateTimePicker1.Value = DateTime.Now;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxJabatan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
