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

public class NotaJual
{
	public virtual string NoNotaJual
	{
		get;
		set;
	}

	public virtual DateTime Tanggal
	{
		get;
		set;
	}

	public virtual Pelanggan Pelanggan
	{
		get;
		set;
	}

	public virtual IEnumerable<NotaJualDetil> NotaJualDetil
	{
		get;
		set;
	}

	public virtual Pegawai Pegawai
	{
		get;
		set;
	}

}

