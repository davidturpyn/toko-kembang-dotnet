//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JualBeli_LIB;
using MySql.Data.MySqlClient;

public class NotaBeliDetil
{
	public virtual long Harga
	{
		get;
		set;
	}

	public virtual int Jumlah
	{
		get;
		set;
	}

	public virtual Barang Barang
	{
		get;
		set;
	}
	public virtual NotaBeli Pembelian
    {
		get;
		set;
	}


    public NotaBeliDetil()
    {
        Harga = 0;
        Jumlah = 0;
        Barang = new Barang();
		Pembelian = new NotaBeli();
	}
    public NotaBeliDetil(long _Harga, int _Jumlah, Barang _Barang)
    {
        Harga = _Harga;
        Jumlah = _Jumlah;
        Barang = _Barang;
    }
    public static string BacaData(string pNilaiKriteria, List<NotaBeliDetil> listhasildata)
    {
        string sql1 = "";

        sql1 = "SELECT dn.NoNota,np.Tanggal,b.KodeBarang,b.Nama,dn.Jumlah,dn.Harga FROM notabelidetil AS dn INNER JOIN notabeli AS np ON dn.NoNota = np.NoNota INNER JOIN barang AS b ON dn.KodeBarang = b.KodeBarang WHERE dn.NoNota = '" + pNilaiKriteria + "';";

        try
        {
            MySqlDataReader hasildata1 = Koneksi.jalankanPerintahQuery(sql1);
            listhasildata.Clear();

            while (hasildata1.Read() == true)
            {

                NotaBeliDetil nota = new NotaBeliDetil();
                nota.Pembelian.NoNotaBeli = hasildata1.GetValue(0).ToString();
                nota.Pembelian.Tanggal = DateTime.Parse(hasildata1.GetValue(1).ToString());
                nota.Barang.Nama = hasildata1.GetValue(2).ToString();
                nota.Barang.KodeBarang = hasildata1.GetValue(3).ToString();
                nota.Jumlah = int.Parse(hasildata1.GetValue(4).ToString());
                nota.Harga = int.Parse(hasildata1.GetValue(5).ToString());

                listhasildata.Add(nota);
            }

            return "1";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

}

