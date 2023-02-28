using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JualBeli_LIB;

namespace Store
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();            
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Size = new Size(368, 310);
        }

        List<Pegawai> listDataPegawai = new List<Pegawai>();
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (textBoxUsername.Text != "")
            {
                Koneksi k = new Koneksi("localhost", "tokokembang", textBoxUsername.Text, textBoxPassword.Text);

                string hasilConnect = k.Connect();

                if (hasilConnect == "sukses")
                {
                    FormMenu form = (FormMenu)this.Owner;
                    form.Enabled = true;
                    MessageBox.Show("SELAMAT DATANG DISISTEM PENCATATAN JUAL BELI TOKO KEMBANG", "Info");

                    string hasilCariPegawai = Pegawai.BacaData("p.Username", textBoxUsername.Text, listDataPegawai);

                    if (hasilCariPegawai == "1")
                    {
                        if (listDataPegawai.Count > 0)
                        {
                            form.Enabled = true;
                            form.labelKode.Text = listDataPegawai[0].KodePegawai.ToString();
                            form.labelNamaPegawai.Text = listDataPegawai[0].Nama.ToString();
                            form.labelJabatan.Text = listDataPegawai[0].Jabatan.NamaJabatan.ToString();
                            
                            form.PengaturaHakAksesMenu(listDataPegawai[0].Jabatan);
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Username tidak ditemukan");
                    }

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Username atau Password Salah." +
                        "Mohon diperiksa kembali");
                }
            }
            else
            {
                MessageBox.Show("username tidak boleh kosong", "kesalahan");
            }
        }
    }
}
