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
    public partial class FormTambahSupplier : Form
    {
        public FormTambahSupplier()
        {
            InitializeComponent();
        }

        private void FormTambahSupplier_Load(object sender, EventArgs e)
        {
            string kode;
            Supplier.GenerateKode(out kode);
            textBoxIDSupplier.Text = kode;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Supplier supplier = new Supplier(int.Parse(textBoxIDSupplier.Text), textBoxNama.Text, textBoxAlamat.Text, textBoxTelpon.Text);
            
            string hasil = Supplier.TambahData(supplier);

            if (hasil == "1")
            {
                MessageBox.Show("data berhasil ditambah");
            }
            else
            {
                MessageBox.Show("gagal mengubah data. pesan kesalahan: " + hasil);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DaftarSupplier form = (DaftarSupplier)this.Owner;
            form.Refresh();
            this.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBoxNama.Text = "";
            textBoxAlamat.Text = "";
            textBoxTelpon.Text = "";
            string kode;
            Supplier.GenerateKode(out kode);
            textBoxIDSupplier.Text = kode;
        }
    }
}
