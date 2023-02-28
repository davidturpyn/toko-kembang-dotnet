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
    public partial class FormMenu : Form
    {
        private Form activeForm = null;
        public FormMenu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            tableLayoutPanel2.Visible = true;
            this.IsMdiContainer = true;
            this.Enabled = false;
            this.WindowState = FormWindowState.Maximized;

            FormLogin form = new FormLogin();
            form.Owner = this;
            form.Show();
        }
        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void barangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new DaftarBarang());
        }

        private void kategoriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new DaftarKategoriBarang());
        }

        private void keluarSistemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pegawaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new DaftarPegawai());

        }

        public void PengaturaHakAksesMenu(Jabatan pJabatan)
        {
            if (pJabatan.IdJabatan == "J1")
            {
                masterToolStripMenuItem.Visible = false;
                penjualanToolStripMenuItem.Visible = false;
                buttonPenjualan.Visible = false;
                pembelianToolStripMenuItem.Visible = true;
                buttonPembelian.Visible = true;
                laporanPenjualanToolStripMenuItem.Visible = false;
                buttonLaporanPenjualan.Visible = false;
                laporanPembelianToolStripMenuItem.Visible = true;
                buttonLaporanPembelian.Visible = true;
            }
            else if (pJabatan.IdJabatan == "J2")
            {
                masterToolStripMenuItem.Visible = false;
                penjualanToolStripMenuItem.Visible = true;
                buttonPenjualan.Visible = true;
                pembelianToolStripMenuItem.Visible = false;
                buttonPembelian.Visible = false;
                laporanPenjualanToolStripMenuItem.Visible = true;
                buttonLaporanPenjualan.Visible = true;
                laporanPembelianToolStripMenuItem.Visible = false;
                buttonLaporanPembelian.Visible = false;
                this.Enabled = true;
                FormTambahNotaJual form = new FormTambahNotaJual();
                form.MdiParent = this;
                form.Show();
            }
            else if (pJabatan.IdJabatan == "J3")
            {
                masterToolStripMenuItem.Visible = true;
                penjualanToolStripMenuItem.Visible = true;
                pembelianToolStripMenuItem.Visible = true;
                laporanPenjualanToolStripMenuItem.Visible = true;
                laporanPembelianToolStripMenuItem.Visible = true;
            }
        }

        private void penjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new FormTambahNotaJual());
        }

        private void pembelianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new FormTambahNotaBeli());
        }

        private void suplaierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new DaftarSupplier());
        }

        private void laporanPenjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new DaftarNotaJual());
        }

        private void laporanPembelianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new DaftarNotaBeli());
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form forms = Application.OpenForms["DaftarBarang"];

            if (forms == null)
            {
                DaftarBarang form = new DaftarBarang();
                form.MdiParent = this;
                form.Show();
            }
            else
            {
                forms.Show();
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form forms = Application.OpenForms["DaftarKategoriBarang"];

            if (forms == null)
            {
                DaftarKategoriBarang form = new DaftarKategoriBarang();
                form.MdiParent = this;
                form.Show();
            }
            else
            {
                forms.Show();
            }
        }

        

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Form forms = Application.OpenForms["DaftarSupplier"];

            if (forms == null)
            {
                DaftarSupplier form = new DaftarSupplier();
                form.MdiParent = this;
                form.Show();
            }
            else
            {
                forms.Show();
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Form forms = Application.OpenForms["DaftarPegawai"];

            if (forms == null)
            {
                DaftarPegawai form = new DaftarPegawai();
                form.MdiParent = this;
                form.Show();
            }
            else
            {
                forms.Show();
            }
        }

        private void menuStripMaster_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openChildForm(new FormTambahNotaJual());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openChildForm(new DaftarNotaJual());
        }

        private void buttonBarang_Click(object sender, EventArgs e)
        {
            openChildForm(new DaftarBarang());
        }

        private void buttonSupplier_Click(object sender, EventArgs e)
        {
            openChildForm(new FormStokTerendah());
        }

        private void buttonPembelian_Click(object sender, EventArgs e)
        {
            openChildForm(new FormTambahNotaBeli());
        }

        private void buttonLaporanPembelian_Click(object sender, EventArgs e)
        {
            openChildForm(new DaftarNotaBeli());
        }

        private void masterToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
