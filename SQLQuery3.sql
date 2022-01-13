INSERT INTO dbo.auth VALUES('admin','admin');

INSERT INTO brans VALUES
('Dahiliye', 1),
('Deri ve Z�hrevi Hastal�klar', 2),
('Fizyoterapi', 3),
('G�z Hastal�klar�', 4),
('Kulak Burun Bo�az', 6),
('Ortopedi ve Tramvatoloji', 7),
('Psikiyatri', 8),
('N�roloji', 5);

INSERT INTO dilek_sikayet VALUES
('Ali', 'Hastanenin hijyen konusunda eksikleri bulunuyor', 1, 'G�ven', 'Temizlik'),
('BUR��N', 'Hastane yemekleri ald��� firmay� de�i�tirmeli!', 2, 'Karda�', 'Yemekler');

INSERT INTO cinsiyet VALUES
('Erkek'),
('Kad�n');

select * from personel;

INSERT INTO personel VALUES
(1, 'AHMET', 'YILMAZ', 'TOKAT','1', '5553211489', '2000.0','var','var'),
(5, 'TANJU', '�ELIKKAN', 'TOKAT','1', '5421526157','3000.0','var','var'),
(4, 'MUSTAFA', 'ALDIN�', 'TOKAT','1', '5895741223','3200.0','var','var'),
(3, 'NILG�N', '�ELIK', 'TOKAT', '2', '5245877413','4300.0','var','var'),
(6, 'SU', 'CANDANER', 'TOKAT', '2','5391520441','5000.0','var','var'),
(7, 'G�KCAN', 'A�AN', 'TOKAT', '2','5165581918','2600.0','var','var'),
(8, 'SARP', 'G�LSAYIN', 'TOKAT', '1','5825194921','2500.0','var','var'),
(2, 'H�SEY�N', 'AKIN', 'TOKAT', '1','5712596381','6000.0','var','var');

INSERT INTO personel VALUES
(9, 'EL�F', 'UYGUN','TOKAT','2', '5423659508',  '2000.0','var','var'),
(10, 'ERKAN', 'DO�A','TOKAT','1', '5040145974',  '2000.0','var','var'),
(11, 'AY�E G�L', 'G�DER','TOKAT','2', '5032147896',  '2000.0','var','var'),
(12, 'AY�E', 'TEK�N','TOKAT','2', '05587896985',  '2000.0','var','var'),
(13, 'NUR�YE', 'CANDAN','TOKAT','2', '05897462545',  '2000.0','var','var');

INSERT INTO hemsire VALUES
(9, 'EL�F', 'UYGUN','TOKAT','2', '5423659508',  '2000.0', 'var', 'var', '1'),
(10, 'ERKAN', 'DO�A','TOKAT','1', '5040145974',  '2000.0','var','var', '7'),
(11, 'AY�E G�L', 'G�DER','TOKAT','2', '5032147896',  '2000.0','var','var', '2'),
(12, 'AY�E', 'TEK�N','TOKAT','2', '05587896985',  '2000.0','var','var', '4'),
(13, 'NUR�YE', 'CANDAN','TOKAT','2', '05897462545',  '2000.0','var','var', '8');


INSERT INTO doktor VALUES
(1, 'AHMET', 'YILMAZ', 'TOKAT','1', '5553211489', '2000.0','var','var', '1'),
(5, 'TANJU', '�ELIKKAN', 'TOKAT','1', '5421526157','3000.0','var','var', '8'),
(4, 'MUSTAFA', 'ALDIN�', 'TOKAT','1', '5895741223','3200.0','var','var', '3'),
(3, 'NILG�N', '�ELIK', 'TOKAT', '2', '5245877413','4300.0','var','var', '2'),
(6, 'SU', 'CANDANER', 'TOKAT', '2','5391520441','5000.0','var','var', '4'),
(7, 'G�KCAN', 'A�AN', 'TOKAT', '2','5165581918','2600.0','var','var', '7'),
(8, 'SARP', 'G�LSAYIN', 'TOKAT', '1','5825194921','2500.0','var','var', '5'),
(2, 'H�SEY�N', 'AKIN', 'TOKAT', '1','5712596381','6000.0','var','var', '6');

/*
ALter table dbo.duyurular
alter column aciklama VARCHAR(200) NOT NULL
*/
INSERT INTO duyurular VALUES
(1, 'Covid-19', 'Koronavir�s tedbirleri kapsam�nda randevular yaln�zca internet �zerinden 
al�nabilmektedir.'),
(2, 'Yemek Listesi', '29.12.2021 tarihli yemek listesi: Tarhana �orbas�, Sulu K�fte, Salata');

INSERT INTO il VALUES
('Ankara', 1);

INSERT INTO ilce VALUES
('�ankaya', 1, 1),
('Elmada�', 1, 2),
('Sincan', 1, 3),
('Alt�nda�', 1, 4),
('K�z�lcahamam', 1, 5),
('Etimesgut', 1, 6);

INSERT INTO hasta VALUES
(37758167991, 'RUK�YE �ZDEN ', 'SARI', '5587419347', 2),
(95327413957, 'NECLA', 'ALABAY', '5511712510', 6),
(69287101233, 'CENG�ZHAN', 'ERDEN', '5534574241', 5),
(77201681510, 'D�L�AH', 'ARSAL', '5423090121', 3),
(88442647458, 'SENA', 'KO�Y���T', '5955655013', 4),
(67249922331, 'A�ELYA', 'YAKI�AN', '5083722667', 1);

INSERT INTO ilac VALUES
('majezik', 'g�nde 2 defa '),
('parol', 'g�nde 1 defa'),
('aspirin', 'g�nde 3 defa'),
('nurofen', '12 saate 1 kez'),
('aferin', 'g�nde 2 defa'),
('katarin', 'g�nde 1 kez');


INSERT INTO muayene VALUES
(1, 69287101233, 1, 'Guatr'),
(4, 77201681510, 2, 'Covid-19');

INSERT INTO oda VALUES
(7, 'Bo�'),
(8, 'Bo�'),
(15, 'Bo�'),
(12, 'Bo�'),
(13, 'Bo�'),
(14, 'Bo�'),
(1, 'Dolu'),
(9, 'Dolu'),
(10, 'Dolu'),
(2, 'Dolu'),
(11, 'Bo�'),
(3, 'Bo�'),
(4, 'Bo�'),
(6, 'Bo�'),
(5, 'Bo�');


INSERT INTO oda_hareketleri ( odanumara, oda_cikis_tarihi) VALUES 
(5, '2020-12-28 23:50:27.829352'),
(11, '2020-12-28 23:51:02.580178'),
(1, '2020-12-29 18:14:35.032395'),
(2, '2020-12-29 18:14:35.032395'),
(8, '2020-12-29 18:14:35.032395'),
(15, '2020-12-29 18:14:35.032395'),
(6, '2020-12-29 21:00:20.785655'),
(11, '2020-12-29 21:05:07.298947'),
(6, '2020-12-29 21:12:37.87675'),
(6, '2020-12-29 21:20:21.77982'),
(6, '2020-12-29 21:27:02.477871'),
(5, '2020-12-29 22:05:12.65025'),
(5, '2020-12-29 23:10:27.559889'),
(5, '2020-12-29 23:37:38.264808');

INSERT INTO randevu VALUES
(69287101233, 3, '2020-12-16 00:00:00', 1),
(95327413957, 4, '2021-02-17 00:00:00', 2);

INSERT INTO recete VALUES
(1, 95327413957, 6),
(2, 67249922331, 7);

INSERT INTO recete_ilac VALUES
(1, 'parol'),
(1, 'majezik'),
(2, 'katarin'),
(2, 'aspirin'),
(2, 'aferin');


INSERT INTO yatis VALUES
(77201681510, 1, 3, 1),
(88442647458, 9, 12, 2),
(67249922331, 10, 7, 3),
(69287101233, 2, 15, 4);


