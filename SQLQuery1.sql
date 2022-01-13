--create databe

CREATE DATABASE HOSPITAL 
	ON PRIMARY
(
	NAME = N'HOSPITAL_Data',
	FILENAME = N'C:\Users\BK\Desktop\DatabaseProject\HOSPITAL_Data.mdf',
	SIZE = 21632KB,
	MAXSIZE = UNLIMITED,
	FILEGROWTH = 16384KB
)
LOG ON
(
	NAME = N'HOSPITAL_Log',
	FILENAME = N'C:\Users\BK\Desktop\DatabaseProject\HOSPITAL_Log.ldf',
	SIZE = 2048KB,
	MAXSIZE = 2048GB,
	FILEGROWTH = 16384KB
)
GO

--create table
USE HOSPITAL

CREATE TABLE auth(
	name VARCHAR(50) PRIMARY KEY NOT NULL ,
	pass VARCHAR(50)
);


CREATE TABLE personel(
	id INTEGER NOT NULL,
	ad VARCHAR(50) NOT NULL,
	soyad VARCHAR(50) NOT NULL,
	adres VARCHAR(max) NOT NULL,
	cinsiyet INTEGER NOT NULL,
	telefon VARCHAR(50) NOT NULL,
	maas MONEY NOT NULL,
	pasaport VARCHAR(50) NULL,
	ehliyet VARCHAR(50) NULL
);

ALTER TABLE personel 
	ADD CONSTRAINT "Personel-pkey" PRIMARY KEY(id);

ALTER TABLE personel
	ADD CONSTRAINT "unique_Personel_ID" UNIQUE(id);

ALTER TABLE personel
    ADD CONSTRAINT "personCinsiyet_fkey" FOREIGN KEY (cinsiyet) REFERENCES cinsiyet(id) ON UPDATE CASCADE ON DELETE CASCADE;

CREATE TABLE resepsiyon(
	id integer PRIMARY KEY NOT NULL,
	ad VARCHAR(50) NOT NULL,
	soyad VARCHAR(50) NOT NULL,
	adres VARCHAR(max) NOT NULL,
	cinsiyet INTEGER NOT NULL,
	telefon VARCHAR(50) NOT NULL,
	maas MONEY NOT NULL,
	pasaport VARCHAR(50) NULL,
	ehliyet VARCHAR(50) NULL
);

ALTER TABLE resepsiyon
	ADD CONSTRAINT "unique_Resepsiyon_ID" UNIQUE(id);

ALTER TABLE resepsiyon
	ADD CONSTRAINT "resepsiyonPerson_fkey" FOREIGN KEY (id) REFERENCES personel(id) ON UPDATE CASCADE ON DELETE CASCADE;

CREATE TABLE doktor (
    id integer NOT NULL,
	ad VARCHAR(50) NOT NULL,
	soyad VARCHAR(50) NOT NULL,
	adres VARCHAR(max) NOT NULL,
	cinsiyet INTEGER NOT NULL,
	telefon VARCHAR(50) NOT NULL,
	maas MONEY NOT NULL,
	pasaport VARCHAR(50) NULL,
	ehliyet VARCHAR(50) NULL,
    brans INT NOT NULL,
);

ALTER TABLE doktor
    ADD CONSTRAINT "Doktor_pkey" PRIMARY KEY (id);

ALTER TABLE doktor
    ADD CONSTRAINT "unique_Doktor_ID" UNIQUE (id);

ALTER TABLE doktor
    ADD CONSTRAINT doktorbrans_pkey FOREIGN KEY (brans) REFERENCES brans(brans_numarasi) ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE doktor
    ADD CONSTRAINT "doktorPerson_fkey" FOREIGN KEY (id) REFERENCES personel(id) ON UPDATE CASCADE ON DELETE CASCADE;

CREATE TABLE hemsire (
    id integer NOT NULL,
	ad VARCHAR(50) NOT NULL,
	soyad VARCHAR(50) NOT NULL,
	adres VARCHAR(max) NOT NULL,
	cinsiyet INTEGER NOT NULL,
	telefon VARCHAR(50) NOT NULL,
	maas MONEY NOT NULL,
	pasaport VARCHAR(50) NULL,
	ehliyet VARCHAR(50) NULL,
    brans INT NOT NULL,
);

ALTER TABLE hemsire
    ADD CONSTRAINT hemsire_pkey PRIMARY KEY (id);

ALTER TABLE hemsire
    ADD CONSTRAINT unique_hemsire_id UNIQUE (id);

ALTER TABLE hemsire
    ADD CONSTRAINT brans_hemsire_fkey FOREIGN KEY (brans) REFERENCES brans(brans_numarasi) ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE hemsire
    ADD CONSTRAINT "hemsirePerson_fkey" FOREIGN KEY (id) REFERENCES personel(id) ON UPDATE CASCADE ON DELETE CASCADE;

CREATE TABLE cinsiyet(
	id INTEGER PRIMARY KEY IDENTITY(1,1) NOT NULL,
	name VARCHAR(50) NOT NULL
);

ALTER TABLE cinsiyet
    ADD CONSTRAINT unique_cinsiyet_id UNIQUE (id);


CREATE TABLE ilac (
    ilac_adi NVARCHAR(40) NOT NULL,
    kullanim_bilgi VARCHAR(50) NOT NULL
);

ALTER TABLE ilac
    ADD CONSTRAINT ilac_pkey PRIMARY KEY (ilac_adi);

ALTER TABLE ilac
    ADD CONSTRAINT unique_ilac_ilac_adi UNIQUE (ilac_adi);

CREATE TABLE il (
    ad character varying NOT NULL,
    id integer NOT NULL
);

ALTER TABLE il
alter column ad VARCHAR(40) NOT NULL

ALTER TABLE il
    ADD CONSTRAINT "Il_pkey" PRIMARY KEY (id);

ALTER TABLE il
    ADD CONSTRAINT "unique_Il_id" UNIQUE (id);

CREATE TABLE ilce (
    ilce_adi VARCHAR(50) NOT NULL,
    il_id integer NOT NULL,
    ilce_id integer NOT NULL
);

ALTER TABLE ilce
    ADD CONSTRAINT ilce_pkey PRIMARY KEY (ilce_id);

ALTER TABLE ilce
    ADD CONSTRAINT unique_ilce_ilce_id UNIQUE (ilce_id);

ALTER TABLE ilce
    ADD CONSTRAINT "ilIlce_fkey" FOREIGN KEY (il_id) REFERENCES il(id) ON UPDATE CASCADE ON DELETE CASCADE;

CREATE TABLE muayene (
    doktor_id integer NOT NULL,
    hasta_tc bigint NOT NULL,
    muayene_id integer NOT NULL,
    teshis VARCHAR(50) NOT NULL
);

ALTER TABLE muayene
    ADD CONSTRAINT muayene_pkey PRIMARY KEY (muayene_id);

ALTER TABLE muayene
    ADD CONSTRAINT "doktor-muayene-fkey" FOREIGN KEY (doktor_id) REFERENCES doktor(id) ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE muayene
    ADD CONSTRAINT "hasta-muayene-fkey" FOREIGN KEY (hasta_tc) REFERENCES hasta(tc_no) ON UPDATE CASCADE ON DELETE CASCADE;


CREATE TABLE oda_hareketleri (
    degisiklik_no integer IDENTITY(1,1) NOT NULL,
    odanumara integer,
    oda_cikis_tarihi datetime2(6) default GETDATE()
);

ALTER TABLE oda_hareketleri
    ADD CONSTRAINT oda_hareketleri_pkey PRIMARY KEY (degisiklik_no);



CREATE TABLE oda (
    oda_no integer NOT NULL,
    oda_durumu VARCHAR(50)
);

ALTER TABLE oda
    ADD CONSTRAINT oda_pkey PRIMARY KEY (oda_no);

ALTER TABLE oda
    ADD CONSTRAINT unique_oda_oda_no UNIQUE (oda_no);

	
CREATE TABLE brans (
    brans_adi NVARCHAR(40) NOT NULL,
    brans_numarasi integer NOT NULL
);

ALTER TABLE brans
    ADD CONSTRAINT "Brans_pkey" PRIMARY KEY (brans_adi);

ALTER TABLE brans
    ADD CONSTRAINT "unique_Brans_Ad" UNIQUE (brans_adi);

ALTER TABLE brans
    ADD CONSTRAINT unique_brans_brans_numarasi UNIQUE (brans_numarasi);

CREATE TABLE dilek_sikayet (
    ad VARCHAR(50) NOT NULL,
    aciklama VARCHAR(50) NOT NULL,
    id integer NOT NULL,
    soyad VARCHAR(50) NOT NULL,
    baslik VARCHAR(50) NOT NULL
);

ALTER TABLE dilek_sikayet
    ADD CONSTRAINT dilek_sikayet_pkey PRIMARY KEY (id);

ALTER TABLE dilek_sikayet
    ADD CONSTRAINT unique_dilek_sikayet_id UNIQUE (id);

CREATE TABLE duyurular (
    id integer NOT NULL,
    baslik VARCHAR(50) NOT NULL,
    aciklama VARCHAR(50) NOT NULL
);

ALTER TABLE duyurular
    ADD CONSTRAINT duyurular_pkey PRIMARY KEY (id);

CREATE TABLE hasta (
    tc_no bigint NOT NULL,
    ad VARCHAR(50) NOT NULL,
    soyad VARCHAR(50) NOT NULL,
    telefon VARCHAR(50) NOT NULL,
    ilce_id integer NOT NULL
);

ALTER TABLE hasta
    ADD CONSTRAINT "Hasta_pkey" PRIMARY KEY (tc_no);

ALTER TABLE hasta
    ADD CONSTRAINT "unique_Hasta_TCNo" UNIQUE (tc_no);

ALTER TABLE hasta
    ADD CONSTRAINT "hastailce-fkey" FOREIGN KEY (ilce_id) REFERENCES ilce(ilce_id) ON UPDATE CASCADE ON DELETE CASCADE;

CREATE TABLE randevu (
    hasta_tc bigint NOT NULL,
    doktor_id integer NOT NULL,
    tarih datetime2(2) NOT NULL default GETDATE(),
    randevu_id integer NOT NULL
);

ALTER TABLE randevu
    ADD CONSTRAINT "Randevu_pkey" PRIMARY KEY (randevu_id);

ALTER TABLE randevu
    ADD CONSTRAINT "unique_Randevu_Tarih" UNIQUE (tarih);

ALTER TABLE randevu
    ADD CONSTRAINT doktorrandevu_fkey FOREIGN KEY (doktor_id) REFERENCES doktor(id) ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE randevu
    ADD CONSTRAINT hastarandevu_fkey FOREIGN KEY (hasta_tc) REFERENCES hasta(tc_no) ON UPDATE CASCADE ON DELETE CASCADE;

CREATE TABLE recete (
    id integer NOT NULL,
    hasta_tc bigint NOT NULL,
    doktor_id integer NOT NULL
);

ALTER TABLE recete
    ADD CONSTRAINT recete_pkey PRIMARY KEY (id);

ALTER TABLE recete
    ADD CONSTRAINT unique_recete_id UNIQUE (id);


ALTER TABLE recete
    ADD CONSTRAINT "doktorrecete-fkey" FOREIGN KEY (doktor_id) REFERENCES doktor(id) ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE recete
    ADD CONSTRAINT "recete-hasta-fkey" FOREIGN KEY (hasta_tc) REFERENCES hasta(tc_no) ON UPDATE CASCADE ON DELETE CASCADE;
	
CREATE TABLE recete_ilac (
    recete_id integer NOT NULL,
    ilac_adi NVARCHAR(40) NOT NULL
);

ALTER TABLE recete_ilac
    ADD CONSTRAINT recete_ilac_pkey PRIMARY KEY (recete_id, ilac_adi);

ALTER TABLE recete_ilac
    ADD CONSTRAINT "ilac-recete-fkey" FOREIGN KEY (ilac_adi) REFERENCES ilac(ilac_adi) ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE recete_ilac
    ADD CONSTRAINT "recte-ilac-fkey" FOREIGN KEY (recete_id) REFERENCES recete(id) ON UPDATE CASCADE ON DELETE CASCADE;

CREATE TABLE yatis (
    hasta_tc bigint NOT NULL,
    oda_no integer NOT NULL,
    yatilacak_gun integer NOT NULL,
    id integer NOT NULL
);


ALTER TABLE yatis
    ADD CONSTRAINT yatis_pkey PRIMARY KEY (id);

ALTER TABLE yatis
    ADD CONSTRAINT unique_yatis_id UNIQUE (id);
	
ALTER TABLE yatis
    ADD CONSTRAINT hastayatis_fkey FOREIGN KEY (hasta_tc) REFERENCES hasta(tc_no) ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE yatis
    ADD CONSTRAINT odayatis_fkey FOREIGN KEY (oda_no) REFERENCES oda(oda_no) ON UPDATE CASCADE ON DELETE CASCADE;