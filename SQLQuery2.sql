
use HOSPITAL

--create function

CREATE FUNCTION bosodalarilistele()
RETURNS TABLE
AS
	RETURN SELECT oda_no, oda_durumu FROM dbo.oda WHERE CONVERT(VARCHAR, oda_durumu)='Boþ';
GO

select * from dbo.bosodalarilistele();

CREATE FUNCTION doluOdalariListele()
RETURNS TABLE
AS
 RETURN SELECT oda_no, oda_durumu FROM dbo.oda
 WHERE CONVERT(VARCHAR, oda_durumu)='Dolu';

 select* from dbo.doluOdalariListele();

 CREATE FUNCTION hasta_sayisi()
 RETURNS INT
 AS
 BEGIN
 DECLARE @hasta INT;
 SET @hasta = (SELECT count(tc_no) from hasta);
 RETURN @hasta
 END;

 CREATE FUNCTION personel_sayisi()
 RETURNS INT
 AS
 BEGIN
 DECLARE @personel INT;
 SET @personel = (SELECT count(id) from personel);
 RETURN @personel
 END;

select dbo.hasta_sayisi();
select dbo.personel_sayisi();

 CREATE FUNCTION oda_sayisi()
 RETURNS INT
 AS
 BEGIN
 DECLARE @oda INT;
 SET @oda = (SELECT count(*) from oda);
 RETURN @oda
 END;

 
select dbo.oda_sayisi();

--create trigger

CREATE TRIGGER yatis_eklendiginde_dolu_yap
ON dbo.yatis
AFTER INSERT
AS
	BEGIN
		DECLARE @odano INT;
		SELECT @odano = oda_no from inserted;
		UPDATE oda set oda_durumu='Dolu' WHERE oda_no = @odano;
	END;

CREATE TRIGGER yatis_silindiginde_bos_yap
ON dbo.yatis
AFTER DELETE
AS
	BEGIN
		DECLARE @odano INT;
		SELECT @odano = oda_no from deleted;
		UPDATE oda set oda_durumu='Boþ' WHERE oda_no = @odano;
	END;

	drop trigger doktor_eklerken
	drop trigger hemsire_eklerken
	drop trigger resepsiyon_eklerken




CREATE TRIGGER doktor_eklerken
ON dbo.doktor
INSTEAD OF INSERT AS
BEGIN
	DECLARE @id INT;
	DECLARE @ad VARCHAR(20);
	DECLARE @soyad VARCHAR(20);
	DECLARE @adres VARCHAR(20);
	DECLARE @cinsiyet INT;
	DECLARE @telefon VARCHAR(20);
	DECLARE @maas MONEY;
	DECLARE @pasaport VARCHAR(20); 
	DECLARE @ehliyet VARCHAR(20); 
	DECLARE @brans INT; 
	Select @id=id, @ad=UPPER(ad), @soyad=UPPER(soyad), @adres= adres, @cinsiyet=cinsiyet, @telefon=telefon,@maas=maas,@pasaport=pasaport,@ehliyet=ehliyet,@brans=brans from inserted;
	INSERT dbo.personel Values(@id, @ad, @soyad, @adres, @cinsiyet, @telefon, @maas, @pasaport, @ehliyet);
	INSERT dbo.doktor Values(@id, @ad, @soyad, @adres, @cinsiyet, @telefon, @maas, @pasaport, @ehliyet,@brans);
END;


CREATE TRIGGER hemsire_eklerken
ON dbo.hemsire
INSTEAD OF INSERT AS
BEGIN
	DECLARE @id INT;
	DECLARE @ad VARCHAR(20);
	DECLARE @soyad VARCHAR(20);
	DECLARE @adres VARCHAR(20);
	DECLARE @cinsiyet INT;
	DECLARE @telefon VARCHAR(20);
	DECLARE @maas MONEY;
	DECLARE @pasaport VARCHAR(20); 
	DECLARE @ehliyet VARCHAR(20); 
	DECLARE @brans INT; 
	Select @id=id, @ad=UPPER(ad), @soyad=UPPER(soyad), @adres= adres, @cinsiyet=cinsiyet, @telefon=telefon,@maas=maas,@pasaport=pasaport,@ehliyet=ehliyet,@brans=brans from inserted;
	INSERT dbo.personel Values(@id, @ad, @soyad, @adres, @cinsiyet, @telefon, @maas, @pasaport, @ehliyet);
	INSERT dbo.hemsire Values(@id, @ad, @soyad, @adres, @cinsiyet, @telefon, @maas, @pasaport, @ehliyet,@brans);
END;


CREATE TRIGGER resepsiyon_eklerken
ON dbo.resepsiyon
INSTEAD OF INSERT AS
BEGIN
	DECLARE @id INT;
	DECLARE @ad VARCHAR(20);
	DECLARE @soyad VARCHAR(20);
	DECLARE @adres VARCHAR(20);
	DECLARE @cinsiyet INT;
	DECLARE @telefon VARCHAR(20);
	DECLARE @maas MONEY;
	DECLARE @pasaport VARCHAR(20); 
	DECLARE @ehliyet VARCHAR(20); 
	Select @id=id, @ad=UPPER(ad), @soyad=UPPER(soyad), @adres= adres, @cinsiyet=cinsiyet, @telefon=telefon,@maas=maas,@pasaport=pasaport,@ehliyet=ehliyet from inserted;
	INSERT dbo.personel Values(@id, @ad, @soyad, @adres, @cinsiyet, @telefon, @maas, @pasaport, @ehliyet);
	INSERT dbo.resepsiyon Values(@id, @ad, @soyad, @adres, @cinsiyet, @telefon, @maas, @pasaport, @ehliyet);
END;


CREATE TRIGGER doktor_silerken
ON dbo.doktor
AFTER DELETE AS
BEGIN
	DECLARE @id INT;
	Select @id=id from deleted;
	DELETE dbo.personel where id = @id;
END;

CREATE TRIGGER hemsire_silerken
ON dbo.hemsire
AFTER DELETE AS
BEGIN
	DECLARE @id INT;
	Select @id=id from deleted;
	DELETE dbo.personel where id = @id;
END;

CREATE TRIGGER resepsiyon_silerken
ON dbo.resepsiyon
AFTER DELETE AS
BEGIN
	DECLARE @id INT;
	Select @id=id from deleted;
	DELETE dbo.personel where id = @id;
END;




CREATE TRIGGER oda_cikis_yapildiginda
ON dbo.yatis
AFTER DELETE AS
BEGIN
	DECLARE @odanumara INT;
	DECLARE @oda_cikis_tarihi datetime2(6);

	Select @odanumara = oda_no from deleted;
	INSERT INTO dbo.oda_hareketleri VALUES (@odanumara,GETDATE());
END;





--create proc

CREATE PROC duyuru_ekle
(
	@id int, 
	@baslik VARCHAR(50),
	@aciklama VARCHAR(200)
)
AS 
BEGIN
	INSERT INTO duyurular(id, baslik,aciklama)
	VALUES (@id,@baslik,@aciklama);
END;

CREATE PROC doktor_ekle
(
	@id int, 
	@ad VARCHAR(50),
	@soyad VARCHAR(50),
	@adres VARCHAR(max),
	@cinsiyet int,
	@telefon VARCHAR(50),
	@maas money,
	@pasaport VARCHAR(50),
	@ehliyet VARCHAR(50),
	@brans INT
)
AS 
BEGIN
	INSERT INTO doktor(id, ad,soyad,adres,cinsiyet,telefon,maas,pasaport,ehliyet,brans)
	VALUES (@id,@ad,@soyad,@adres,@cinsiyet,@telefon,@maas,@pasaport,@ehliyet,@brans);
END;

CREATE PROC hemsire_ekle
(
	@id int, 
	@ad VARCHAR(50),
	@soyad VARCHAR(50),
	@adres VARCHAR(max),
	@cinsiyet int,
	@telefon VARCHAR(50),
	@maas money,
	@pasaport VARCHAR(50),
	@ehliyet VARCHAR(50),
	@brans INT
)
AS 
BEGIN
	INSERT INTO hemsire(id, ad,soyad,adres,cinsiyet,telefon,maas,pasaport,ehliyet,brans)
	VALUES (@id,@ad,@soyad,@adres,@cinsiyet,@telefon,@maas,@pasaport,@ehliyet,@brans);
END;

CREATE PROC resepsiyon_ekle
(
	@id int, 
	@ad VARCHAR(50),
	@soyad VARCHAR(50),
	@adres VARCHAR(max),
	@cinsiyet int,
	@telefon VARCHAR(50),
	@maas money,
	@pasaport VARCHAR(50),
	@ehliyet VARCHAR(50)
)
AS 
BEGIN
	INSERT INTO resepsiyon(id, ad,soyad,adres,cinsiyet,telefon,maas,pasaport,ehliyet)
	VALUES (@id,@ad,@soyad,@adres,@cinsiyet,@telefon,@maas,@pasaport,@ehliyet);
END;

CREATE PROC resepsiyon_sil
(
	@id int
)
AS 
BEGIN
	DELETE dbo.resepsiyon WHERE id = @id;
END;

exec resepsiyon_sil 16

CREATE PROC doktor_sil
(
	@id int
)
AS 
BEGIN
	DELETE dbo.doktor WHERE id = @id;
END;

CREATE PROC hemsire_sil
(
	@id int
)
AS 
BEGIN
	DELETE dbo.hemsire WHERE id = @id;
END;

exec resepsiyon_sil @id=16;

CREATE PROC resepsiyon_güncelle
(
	@id int, 
	@ad VARCHAR(50),
	@soyad VARCHAR(50),
	@adres VARCHAR(max),
	@cinsiyet int,
	@telefon VARCHAR(50),
	@maas money,
	@pasaport VARCHAR(50),
	@ehliyet VARCHAR(50)
)
AS 
BEGIN
	UPDATE resepsiyon SET ad=@ad,soyad=@soyad,adres=@adres,cinsiyet=@cinsiyet,telefon=@telefon,maas=@maas,pasaport=@pasaport,ehliyet=@ehliyet WHERE id = @id;
END;

CREATE PROC personel_güncelle
(
	@id int, 
	@ad VARCHAR(50),
	@soyad VARCHAR(50),
	@adres VARCHAR(max),
	@cinsiyet int,
	@telefon VARCHAR(50),
	@maas money,
	@pasaport VARCHAR(50),
	@ehliyet VARCHAR(50)
)
AS 
BEGIN
	UPDATE personel SET ad=@ad,soyad=@soyad,adres=@adres,cinsiyet=@cinsiyet,telefon=@telefon,maas=@maas,pasaport=@pasaport,ehliyet=@ehliyet WHERE id = @id;
END;

CREATE PROC doktor_güncelle
(
	@id int, 
	@ad VARCHAR(50),
	@soyad VARCHAR(50),
	@adres VARCHAR(max),
	@cinsiyet int,
	@telefon VARCHAR(50),
	@maas money,
	@pasaport VARCHAR(50),
	@ehliyet VARCHAR(50),
	@brans INT
)
AS 
BEGIN
	UPDATE doktor SET ad=@ad,soyad=@soyad,adres=@adres,cinsiyet=@cinsiyet,telefon=@telefon,maas=@maas,pasaport=@pasaport,ehliyet=@ehliyet, brans=@brans WHERE id = @id;
END;

CREATE PROC hemsire_güncelle
(
	@id int, 
	@ad VARCHAR(50),
	@soyad VARCHAR(50),
	@adres VARCHAR(max),
	@cinsiyet int,
	@telefon VARCHAR(50),
	@maas money,
	@pasaport VARCHAR(50),
	@ehliyet VARCHAR(50),
	@brans INT
)
AS 
BEGIN
	UPDATE hemsire SET ad=@ad,soyad=@soyad,adres=@adres,cinsiyet=@cinsiyet,telefon=@telefon,maas=@maas,pasaport=@pasaport,ehliyet=@ehliyet, brans=@brans WHERE id = @id;
END;

--create view

CREATE VIEW personel_ad
AS
SELECT fullname=ad+'   '+soyad FROM dbo.personel where tur = '30';

drop view vw_doktor

CREATE VIEW vw_doktor
AS
SELECT d.id,d.ad,d.soyad,d.adres,c.name,d.telefon,d.maas,d.pasaport,d.ehliyet,b.brans_adi
FROM dbo.doktor d, dbo.cinsiyet c, dbo.brans b 
WHERE d.cinsiyet = c.id and d.brans=b.brans_numarasi;

CREATE VIEW vw_hemsire
AS
SELECT h.id,h.ad,h.soyad,h.adres,c.name,h.telefon,h.maas,h.pasaport,h.ehliyet,b.brans_adi
FROM dbo.hemsire h, dbo.cinsiyet c, dbo.brans b
WHERE h.cinsiyet = c.id and h.brans=b.brans_numarasi;

CREATE VIEW vw_resepsiyon
AS
SELECT r.id,r.ad,r.soyad,r.adres,c.name,r.telefon,r.maas,r.pasaport,r.ehliyet
FROM dbo.resepsiyon r, dbo.cinsiyet c
WHERE r.cinsiyet = c.id;

select * from vw_doktor


--create cursor

CREATE PROC tamad_getir
@id int
AS
BEGIN
	DECLARE @tamad VARCHAR(100)
	DECLARE cursoryapisi CURSOR FOR
	SELECT tam = ad + '   '+soyad FROM dbo.personel 
	WHERE id = @id
	OPEN cursoryapisi
	FETCH NEXT FROM cursoryapisi INTO @tamad
	while @@FETCH_STATUS = 0
	BEGIN
		PRINT @tamad
		FETCH NEXT FROM cursoryapisi INTO @tamad
	END
	close cursoryapisi
	deallocate cursoryapisi 
END;

exec tamad_getir 2