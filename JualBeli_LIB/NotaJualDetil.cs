﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NotaJualDetil
{
	public virtual int Jumlah
	{
		get;
		set;
	}

	public virtual long Harga
	{
		get;
		set;
	}

	public virtual Barang Barang
	{
		get;
		set;
	}

    public NotaJualDetil()
    {
        Jumlah = 1;
        Harga = 0;
    }
    public NotaJualDetil(Barang pBarang, int pJumlah, long pHarga)
    {
        Barang = pBarang;
        Jumlah = pJumlah;
        Harga = pHarga;
    }
}
