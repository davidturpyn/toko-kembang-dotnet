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
    public partial class FormUbahPegawai : Form
    {
        List<Pegawai> listPegawai = new List<Pegawai>();
        List<Jabatan> listJabata = new List<Jabatan>();
        public FormUbahPegawai()
        {
            InitializeComponent();

            string hasilBaca = Jabatan.BacaData("", "", listJabata);
            if (hasilBaca == "1")
            {
                comboBoxJabatan.Items.Clear();

                for (int i = 0; i < listJabata.Count; i++)
                {
                    comboBoxJabatan.Items.Add(listJabata[i].IdJabatan + " - " + listJabata[i].NamaJabatan);
                }
            }
            else
            {
                MessageBox.Show("Data kategori barang gagal ditampilkan.");
            }
        }

        private void textBoxKode_TextChanged(object sender, EventArgs e)
        {
            if (textBoxKode.Text != "")
            {
                string hasil = Pegawai.BacaData("KodePegawai", textBoxKode.Text, listPegawai);

                if (hasil == "1")
                {
                    textBoxKode.Text = listPegawai[0].KodePegawai.ToString();
                    textBoxAlamat.Text = listPegawai[0].Alamat;
                    textBoxGaji.Text = listPegawai[0].Gaji.ToString();
                    textBoxNamaPegawai.Text = listPegawai[0].Nama;
                    textBoxPassword.Text = listPegawai[0].Password;
                    textBoxUalngpassword.Text = listPegawai[0].Password;
                    textBoxUsername.Text = listPegawai[0].Username;
                    dateTimePicker1.Value = listPegawai[0].TglLahir;

                    for (int i = 0; i < listJabata.Count; i++)
                    {
                        if (listJabata[i].IdJabatan == listPegawai[0].Jabatan.IdJabatan)
                        {
                            comboBoxJabatan.SelectedIndex = i;
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBoxPassword.Text == textBoxUalngpassword.Text)
            {
                int indexPilih = comboBoxJabatan.SelectedIndex;
                Jabatan j = listJabata[indexPilih];

                Pegawai p = new Pegawai(int.Parse(textBoxKode.Text), textBoxNamaPegawai.Text, textBoxUsername.Text, textBoxPassword.Text, dateTimePicker1.Value, textBoxAlamat.Text, int.Parse(textBoxGaji.Text), j);
                
                string hasil = Pegawai.UbahPegawai(p);
                if (hasil == "1")
                {
                    MessageBox.Show("Data berhasil diUbah");
                }
                else
                {
                    MessageBox.Show(hasil);
                }
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
    }
}
