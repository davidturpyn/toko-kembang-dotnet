-- phpMyAdmin SQL Dump
-- version 4.3.11
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: 17 Mei 2021 pada 08.43
-- Versi Server: 5.6.24
-- PHP Version: 5.6.8

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `tokokembang`
--

-- --------------------------------------------------------

--
-- Struktur dari tabel `barang`
--

CREATE TABLE IF NOT EXISTS `barang` (
  `KodeBarang` char(5) NOT NULL,
  `Barcode` varchar(13) DEFAULT NULL,
  `Nama` varchar(45) DEFAULT NULL,
  `HargaJual` int(11) DEFAULT NULL,
  `Stok` smallint(6) DEFAULT NULL,
  `KodeKategori` char(2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data untuk tabel `barang`
--

INSERT INTO `barang` (`KodeBarang`, `Barcode`, `Nama`, `HargaJual`, `Stok`, `KodeKategori`) VALUES
('01001', '8997035563414', 'Pocari Sweat', 12000, 30, '01'),
('01002', '8997035563424', 'Orange Squash', 5000, 66, '01'),
('01003', '8997035564524', 'My Cola', 10000, 87, '01'),
('01004', '8990234123567', 'Choco Avocado Coffee', 20000, 14, '01'),
('01005', '3414677414352', 'pucuk', 6000, 19, '01'),
('02001', '5411026164138', 'Bumbu Ayam Kalasan Royku', 15000, 97, '02'),
('02002', '5421031164128', 'Kaldu Ayam Magic', 30000, 13, '02'),
('03001', '0421032464101', 'T-Shirt Pelangi Lengan Pendek', 80000, 27, '03'),
('03002', '0421035564301', 'Baju Sekolah SD', 120000, 12, '03'),
('04001', '5421031164368', 'Keju Cheddar Healthy Choice', 67000, 40, '04');

-- --------------------------------------------------------

--
-- Struktur dari tabel `jabatan`
--

CREATE TABLE IF NOT EXISTS `jabatan` (
  `IdJabatan` char(2) NOT NULL,
  `Nama` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data untuk tabel `jabatan`
--

INSERT INTO `jabatan` (`IdJabatan`, `Nama`) VALUES
('J1', 'Pegawai Pembelian'),
('J2', 'Kasir'),
('J3', 'Manajer');

-- --------------------------------------------------------

--
-- Struktur dari tabel `kategori`
--

CREATE TABLE IF NOT EXISTS `kategori` (
  `KodeKategori` char(2) NOT NULL,
  `Nama` varchar(30) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data untuk tabel `kategori`
--

INSERT INTO `kategori` (`KodeKategori`, `Nama`) VALUES
('01', 'Minuman'),
('02', 'Bumbu Dapur'),
('03', 'Fashion'),
('04', 'Susu dan Olahan'),
('05', 'Daging'),
('06', 'Pakaian Baru'),
('07', 'Baju');

-- --------------------------------------------------------

--
-- Struktur dari tabel `notabeli`
--

CREATE TABLE IF NOT EXISTS `notabeli` (
  `NoNota` char(11) NOT NULL,
  `Tanggal` datetime DEFAULT NULL,
  `KodeSupplier` int(11) NOT NULL,
  `KodePegawai` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data untuk tabel `notabeli`
--

INSERT INTO `notabeli` (`NoNota`, `Tanggal`, `KodeSupplier`, `KodePegawai`) VALUES
('20210428002', '2021-04-28 09:40:04', 3, 1),
('20210428003', '2021-04-28 09:45:05', 4, 1),
('20210428004', '2021-04-28 10:43:14', 4, 1),
('20210428005', '2021-04-28 01:31:14', 2, 1),
('20210428006', '2021-04-28 01:41:01', 4, 1),
('20210428007', '2021-04-28 02:43:36', 5, 1);

-- --------------------------------------------------------

--
-- Struktur dari tabel `notabelidetil`
--

CREATE TABLE IF NOT EXISTS `notabelidetil` (
  `NoNota` char(11) NOT NULL,
  `KodeBarang` char(5) NOT NULL,
  `Harga` int(11) DEFAULT NULL,
  `Jumlah` smallint(6) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data untuk tabel `notabelidetil`
--

INSERT INTO `notabelidetil` (`NoNota`, `KodeBarang`, `Harga`, `Jumlah`) VALUES
('20210428002', '01003', 4000, 12),
('20210428003', '01002', 4000, 12),
('20210428004', '01001', 12000, 4),
('20210428005', '01004', 20000, 2),
('20210428006', '01004', 20000, 4),
('20210428006', '02002', 30000, 2),
('20210428007', '03002', 120000, 2);

-- --------------------------------------------------------

--
-- Struktur dari tabel `notajual`
--

CREATE TABLE IF NOT EXISTS `notajual` (
  `NoNota` char(11) NOT NULL,
  `Tanggal` datetime DEFAULT NULL,
  `KodePegawai` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data untuk tabel `notajual`
--

INSERT INTO `notajual` (`NoNota`, `Tanggal`, `KodePegawai`) VALUES
('20171105001', '2017-11-05 11:17:08', 1),
('20171106001', '2017-11-06 11:13:12', 1),
('20171106002', '2017-11-06 11:13:47', 3),
('20171106003', '2017-11-06 11:16:22', 3),
('20171107001', '2017-11-07 11:18:14', 1),
('20171114001', '2017-11-14 09:07:23', 4),
('20210411001', '2021-04-11 08:44:51', 1),
('20210412001', '2021-04-12 07:34:53', 1),
('20210415001', '2021-04-15 07:16:48', 1),
('20210415002', '2021-04-15 07:18:39', 1),
('20210428001', '2021-04-28 08:37:10', 0),
('20210428002', '2021-04-28 08:37:43', 0),
('20210428003', '2021-04-28 01:24:32', 1),
('20210429001', '2021-04-29 04:56:36', 1);

-- --------------------------------------------------------

--
-- Struktur dari tabel `notajualdetil`
--

CREATE TABLE IF NOT EXISTS `notajualdetil` (
  `NoNota` char(11) NOT NULL,
  `KodeBarang` char(5) NOT NULL,
  `Harga` int(11) DEFAULT NULL,
  `Jumlah` smallint(6) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data untuk tabel `notajualdetil`
--

INSERT INTO `notajualdetil` (`NoNota`, `KodeBarang`, `Harga`, `Jumlah`) VALUES
('20171105001', '01001', 12000, 5),
('20171105001', '02001', 15000, 1),
('20171106001', '01001', 12000, 3),
('20171106001', '01002', 5000, 2),
('20171106002', '02001', 15000, 2),
('20171106002', '02002', 30000, 1),
('20171106002', '04001', 67000, 4),
('20171106003', '01001', 12000, 3),
('20171107001', '03001', 80000, 2),
('20171114001', '01001', 12000, 2),
('20171114001', '01002', 5000, 1),
('20171114001', '02001', 15000, 3),
('20210411001', '01001', 12000, 1),
('20210412001', '02001', 15000, 2),
('20210415001', '01005', 6000, 2),
('20210415002', '01005', 6000, 3),
('20210428001', '01002', 5000, 1),
('20210428002', '01002', 5000, 2),
('20210428003', '01004', 20000, 2),
('20210429001', '04001', 67000, 1);

-- --------------------------------------------------------

--
-- Struktur dari tabel `pegawai`
--

CREATE TABLE IF NOT EXISTS `pegawai` (
  `KodePegawai` int(11) NOT NULL,
  `Nama` varchar(45) DEFAULT NULL,
  `TglLahir` date DEFAULT NULL,
  `Alamat` varchar(100) DEFAULT NULL,
  `Gaji` bigint(20) DEFAULT NULL,
  `Username` varchar(8) DEFAULT NULL,
  `Password` varchar(8) DEFAULT NULL,
  `IdJabatan` char(2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data untuk tabel `pegawai`
--

INSERT INTO `pegawai` (`KodePegawai`, `Nama`, `TglLahir`, `Alamat`, `Gaji`, `Username`, `Password`, `IdJabatan`) VALUES
(1, 'Nancy', '2017-08-16', 'Tenggilis Mejoyo AA-10', 5000000, 'user', 'user', 'J3'),
(2, 'Andrew', '1977-03-09', 'Raya Darmo 129', 10000000, 'andrew', '1234', 'J3'),
(3, 'Janet', '1987-02-20', 'Darmo Permai Utara X/12', 4000000, 'janet', 'janet123', 'J2'),
(4, 'Margaret', '1984-11-20', 'Raya Kendangsari 200', 4000000, 'margaret', 'margaret', 'J2'),
(5, 'Steven', '1967-03-07', 'Raya Tenggilis 44', 3000000, 'steve', 'steve123', 'J1'),
(6, 'Michael', '1988-07-12', 'Sidosermo Indah Blok A No 12', 3000000, 'michael', '123', 'J1'),
(7, 'Putra', '2021-05-18', 'Borong', 5000000, 'putra', 'put', 'J3');

-- --------------------------------------------------------

--
-- Struktur dari tabel `supplier`
--

CREATE TABLE IF NOT EXISTS `supplier` (
  `KodeSupplier` int(11) NOT NULL,
  `Nama` varchar(30) DEFAULT NULL,
  `Alamat` varchar(100) DEFAULT NULL,
  `Telpon` varchar(12) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data untuk tabel `supplier`
--

INSERT INTO `supplier` (`KodeSupplier`, `Nama`, `Alamat`, `Telpon`) VALUES
(1, 'New Orleans Company', 'P.O. Box 78934', '081234127088'),
(2, 'Cooperativa the Spain', 'MH. Thamrin 55', '081234123869'),
(3, 'UD. Subur Selalu', 'Raya Jemursari 123', '081369741288'),
(4, 'Leka Trading', '22 Jump Street', '081258789321'),
(5, 'UD Mujur', 'Pesapen Selatan no 5', '081333262220');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `barang`
--
ALTER TABLE `barang`
  ADD PRIMARY KEY (`KodeBarang`), ADD KEY `fk_Produk_Kategori1_idx` (`KodeKategori`);

--
-- Indexes for table `jabatan`
--
ALTER TABLE `jabatan`
  ADD PRIMARY KEY (`IdJabatan`);

--
-- Indexes for table `kategori`
--
ALTER TABLE `kategori`
  ADD PRIMARY KEY (`KodeKategori`);

--
-- Indexes for table `notabeli`
--
ALTER TABLE `notabeli`
  ADD PRIMARY KEY (`NoNota`), ADD KEY `fk_NotaBeli_Pemasok1_idx` (`KodeSupplier`), ADD KEY `fk_NotaBeli_Pegawai1_idx` (`KodePegawai`);

--
-- Indexes for table `notabelidetil`
--
ALTER TABLE `notabelidetil`
  ADD PRIMARY KEY (`NoNota`,`KodeBarang`), ADD KEY `fk_NotaBeli_has_Produk_Produk1_idx` (`KodeBarang`), ADD KEY `fk_NotaBeli_has_Produk_NotaBeli1_idx` (`NoNota`);

--
-- Indexes for table `notajual`
--
ALTER TABLE `notajual`
  ADD PRIMARY KEY (`NoNota`), ADD KEY `fk_NotaJual_Pegawai1_idx` (`KodePegawai`);

--
-- Indexes for table `notajualdetil`
--
ALTER TABLE `notajualdetil`
  ADD PRIMARY KEY (`NoNota`,`KodeBarang`), ADD KEY `fk_NotaJual_has_Produk_Produk1_idx` (`KodeBarang`), ADD KEY `fk_NotaJual_has_Produk_NotaJual_idx` (`NoNota`);

--
-- Indexes for table `pegawai`
--
ALTER TABLE `pegawai`
  ADD PRIMARY KEY (`KodePegawai`), ADD KEY `fk_Pegawai_Jabatan1_idx` (`IdJabatan`);

--
-- Indexes for table `supplier`
--
ALTER TABLE `supplier`
  ADD PRIMARY KEY (`KodeSupplier`);

--
-- Ketidakleluasaan untuk tabel pelimpahan (Dumped Tables)
--

--
-- Ketidakleluasaan untuk tabel `notabeli`
--
ALTER TABLE `notabeli`
ADD CONSTRAINT `fk_NotaBeli_Pemasok1` FOREIGN KEY (`KodeSupplier`) REFERENCES `supplier` (`KodeSupplier`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Ketidakleluasaan untuk tabel `notabelidetil`
--
ALTER TABLE `notabelidetil`
ADD CONSTRAINT `fk_NotaBeli_has_Produk_NotaBeli1` FOREIGN KEY (`NoNota`) REFERENCES `notabeli` (`NoNota`),
ADD CONSTRAINT `fk_NotaBeli_has_Produk_Produk1` FOREIGN KEY (`KodeBarang`) REFERENCES `barang` (`KodeBarang`);

--
-- Ketidakleluasaan untuk tabel `notajualdetil`
--
ALTER TABLE `notajualdetil`
ADD CONSTRAINT `fk_NotaJual_has_Produk_NotaJual` FOREIGN KEY (`NoNota`) REFERENCES `notajual` (`NoNota`),
ADD CONSTRAINT `fk_NotaJual_has_Produk_Produk1` FOREIGN KEY (`KodeBarang`) REFERENCES `barang` (`KodeBarang`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
