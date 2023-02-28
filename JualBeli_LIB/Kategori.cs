﻿using JualBeli_LIB;
using MySql.Data.MySqlClient;
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

public class Kategori
{
    public Kategori()
    {
        KodeKategori = "";
        Nama = "";
    }

    public Kategori(string _KodeKategori, string _Nama)
    {
        KodeKategori = _KodeKategori;
        Nama = _Nama;
    }

	public virtual string KodeKategori
	{
		get;
		set;
	}

	public virtual string Nama
	{
		get;
		set;
    }


    #region Methode

    public static string GenerateKode(out string hasilKode)
    {
        string sql = "select max(KodeKategori) from kategori;";
        hasilKode = "";

        try
        {
            MySqlDataReader hasil = Koneksi.jalankanPerintahQuery(sql);

            if (hasil.Read() == true)
            {
                int kodeTerbaru = int.Parse(hasil.GetValue(0).ToString()) + 1;

                if (kodeTerbaru < 10)
                {
                    hasilKode = "0" + kodeTerbaru;
                }
                else
                {
                    hasilKode = kodeTerbaru.ToString();
                }
            }
            else
            {
                hasilKode = "01";
            }

            return "1";
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    public static string BacaData(string kriteria, string nilaiKriteria, List<Kategori> listDatakategori)
    {
        string sql = "";

        if (kriteria == "")
        {
            sql = "select * from kategori;";
        }
        else
        {
            sql = "select * from kategori where " + kriteria + " like '%" + nilaiKriteria + "%';";
        }

        try
        {
            MySqlDataReader hasil = Koneksi.jalankanPerintahQuery(sql);

            while (hasil.Read() == true)
            {
                Kategori kt = new Kategori();
                kt.KodeKategori = hasil.GetValue(0).ToString();
                kt.Nama = hasil.GetValue(1).ToString();

                listDatakategori.Add(kt);
            }

            return "1";
        }
        catch (MySqlException ex)
        {
            return ex.Message;
        }
    }

    public static string TambahBarang(Kategori kat)
    {
        string sql = "insert into kategori(KodeKategori, Nama) values ('" + kat.KodeKategori + "','" + kat.Nama.Replace("'","\\'") + "');";

        try
        {
            Koneksi.DML(sql);
            return "1";
        }
        catch (MySqlException ex)
        {
            return ex.Message + ". perintah sql : " + sql;
        }
    }

    public static string UbahBarang(Kategori kat)
    {
        string sql = "update kategori set Nama='" + kat.Nama.Replace("'", "\\'")+"' where KodeKategori = '"+ kat.KodeKategori+"';";

        try
        {
            Koneksi.DML(sql);
            return "1";
        }
        catch (MySqlException ex)
        {
            return ex.Message + ". perintah sql : " + sql;
        }
    }

    public static string HapusBarang(Kategori kat)
    {
        string sql = "delete from kategori where KodeKategori = '" + kat.KodeKategori + "';";

        try
        {
            Koneksi.DML(sql);
            return "1";
        }
        catch (MySqlException ex)
        {
            return ex.Message + ". perintah sql : " + sql;
        }
    }
    #endregion
}
