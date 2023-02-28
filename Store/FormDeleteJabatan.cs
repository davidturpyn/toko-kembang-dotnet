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
    public partial class FormDeleteJabatan : Form
    {
        List<Jabatan> listDatajabatan = new List<Jabatan>();
        public FormDeleteJabatan()
        {
            InitializeComponent();
        }

        private void textBoxIDJabatan_TextChanged(object sender, EventArgs e)
        {
            if (textBoxIDJabatan.Text.Length == textBoxIDJabatan.MaxLength)
            {
                string hasil = Jabatan.BacaData("IdJabatan", textBoxIDJabatan.Text, listDatajabatan);

                if (hasil == "1")
                {
                    textBoxIDJabatan.Text = listDatajabatan[0].IdJabatan;
                    textBoxNama.Text = listDatajabatan[0].NamaJabatan;
                }
                else
                {
                    MessageBox.Show(hasil);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Jabatan k = new Jabatan(textBoxIDJabatan.Text, textBoxNama.Text);

            string result = Jabatan.HapusJabatan(k);

            if (result == "1")
            {
                MessageBox.Show("Data Jabatan Telah tersimpan");
            }
            else
            {
                MessageBox.Show("Data gagal tersimpan. kesalahan : " + result);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBoxIDJabatan.Text = "";
            textBoxNama.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
