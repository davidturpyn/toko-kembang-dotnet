using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Printing;
using MySql.Data.MySqlClient;

namespace JualBeli_LIB
{
    public class Cetak
    {
        private Font jenisFont;
        private float marginKiri, marginKanan, marginAtas, marginBawah;
        private StreamReader fileCetak;

        #region Properties
        public Font JenisFont
        {
            get { return jenisFont; }
            set { jenisFont = value; }
        }
        public StreamReader FileCetak
        {
            get { return fileCetak; }
            set { fileCetak = value; }
        }
        public float MarginBawah
        {
            get { return marginBawah; }
            set { marginBawah = value; }
        }

        public float MarginAtas
        {
            get { return marginAtas; }
            set { marginAtas = value; }
        }

        public float MarginKanan
        {
            get { return marginKanan; }
            set { marginKanan = value; }
        }

        public float MarginKiri
        {
            get { return marginKiri; }
            set { marginKiri = value; }
        }
        #endregion

        #region Contruktor
        public Cetak(string namaFile)
        {
            FileCetak = new StreamReader(namaFile);
            JenisFont = new Font("Arial", 10);
            marginAtas = (float)10.5;
            marginBawah = (float)10.5;
            marginKanan = (float)10.5;
            marginKiri = (float)10.5;
        }

        public Cetak(string namaFile, string pNamaFont, int pUkuranFont, float pMarginKiri, float pMarginKanan, float pMarginAtas, float pMarginBawah)
        {
            FileCetak = new StreamReader(namaFile);
            JenisFont = new Font(pNamaFont, pUkuranFont);
            marginAtas = pMarginAtas;
            marginBawah = pMarginBawah;
            marginKanan = pMarginKanan;
            marginKiri = pMarginKiri;
        }
        #endregion

        #region Methode
        private void CetakTulisan(object sender, PrintPageEventArgs e)
        {
            int jumBarisPerhalaman = (int)((e.MarginBounds.Height - MarginBawah) / jenisFont.GetHeight(e.Graphics));
            float y = MarginAtas;
            int jumbaris = 0;
            string tulisancetak = FileCetak.ReadLine();

            while (jumbaris < jumBarisPerhalaman && tulisancetak != null)
            {
                y = MarginAtas + (jumbaris * jenisFont.GetHeight(e.Graphics));
                e.Graphics.DrawString(tulisancetak, JenisFont, Brushes.Black, MarginKiri, y);
                jumbaris++;

                tulisancetak = FileCetak.ReadLine();
            }

            if (tulisancetak != null)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }
        }

        public string CetakKePrinter(string ptipe)
        {
            try
            {
                PrintDocument p = new PrintDocument();

                if (ptipe == "tulisan")
                {
                    p.PrintPage += new PrintPageEventHandler(CetakTulisan);
                }
                p.Print();

                FileCetak.Close();

                return "1";
            }
            catch (Exception e)
            {
                return "Proses cetak gagal. Pesan kesalahan = " + e.Message;
            }
        }
        #endregion
    }
}
