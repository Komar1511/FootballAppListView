USE master
IF EXISTS (SELECT * FROM SYS.DATABASES WHERE NAME='Football')
DROP DATABASE Football
GO
CREATE DATABASE Football
ON PRIMARY
( NAME = Football,
FILENAME='C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Football.mdf', SIZE=3 MB, MAXSIZE=100, FILEGROWTH=10)
LOG ON
(NAME = Football_log,
FILENAME ='C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Football_log.ldf', SIZE=3MB, MAXSIZE=100, FILEGROWTH=10)



IF EXISTS (SELECT * FROM SYSOBJECTS WHERE  NAME='Coaches'  AND TYPE='U')
DROP TABLE Coaches 
GO

 IF EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME='Clubs' AND TYPE='U')
DROP TABLE Clubs
GO

 IF EXISTS (SELECT * FROM SYSOBJECTS WHERE  NAME='Players' AND TYPE='U')
DROP TABLE Players
GO

 IF EXISTS (SELECT * FROM SYSOBJECTS WHERE  NAME='Location' AND TYPE='U')
DROP TABLE Location
GO

 IF EXISTS (SELECT * FROM SYSOBJECTS WHERE  NAME='Date_Location'  AND TYPE='U')
DROP TABLE Date_Location 
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE  NAME='Goals'  AND TYPE='U')
DROP TABLE Goals 
GO


IF EXISTS (SELECT * FROM SYSOBJECTS WHERE  NAME='Results'  AND TYPE='U')
DROP TABLE Results 
GO


IF EXISTS (SELECT * FROM SYSOBJECTS WHERE  NAME='Fans'  AND TYPE='U')
DROP TABLE Fans 
GO


IF EXISTS (SELECT * FROM SYSOBJECTS WHERE  NAME='Admins'  AND TYPE='U')
DROP TABLE Fans 
GO


USE Football
GO

CREATE TABLE Coaches(
id_coach int PRIMARY KEY,
Country_birth varchar(50) NULL,
Surname varchar(50) NOT NULL,
Name varchar(50) NULL,
ImageCoach varbinary(MAX) NULL

)

CREATE TABLE Clubs(
id_club int,
name_club varchar(50) NOT NULL,
city varchar(50) NULL,
country varchar(50) NULL,
id_coach int NOT NULL,
PRIMARY KEY (id_club),
CONSTRAINT fk_coach FOREIGN KEY (id_coach)
REFERENCES Coaches (id_coach)
)

CREATE TABLE Players(
id_player int,
Surname varchar(50) NOT NULL,
Name varchar(50) NULL,
Position varchar(50) NOT NULL,
Number_player int NULL,
id_club int NOT NULL,
PRIMARY KEY(id_club, id_player),
CONSTRAINT fk_id_clubs FOREIGN KEY (id_club)
REFERENCES Clubs(id_club)
)

CREATE TABLE Location(
id_stadium int PRIMARY KEY,
Name_stadium varchar(50) NOT NULL,
City varchar(50) NULL,
Country varchar(50) NULL,
ImageStadium varbinary(MAX) NULL
)

CREATE TABLE Date_Location(
id_match int PRIMARY KEY,
Date_time smalldatetime NOT NULL,
Name_tournament varchar(50) NOT NULL,
id_stadium int NOT NULL,
CONSTRAINT fk_id_stadium FOREIGN KEY (id_stadium)
REFERENCES Location(id_stadium)

)



CREATE TABLE Results(
id_club int NOT NULL, 
id_match int NOT NULL,

Final_Score varchar(5) NOT NULL CHECK(Final_Score LIKE '[0-9]:[0-9]'),

PRIMARY KEY(id_club, id_match),
CONSTRAINT fk_id_clubs_results FOREIGN KEY (id_club)
REFERENCES Clubs(id_club),
CONSTRAINT fk_id_matches_results FOREIGN KEY (id_match)
REFERENCES Date_Location(id_match)
)

CREATE TABLE Goals(
id_player int NOT NULL,
id_match int NOT NULL,
Score int NOT NULL,
id_club int NOT NULL,
PRIMARY KEY (id_player, id_club, id_match),
CONSTRAINT fk_id_players FOREIGN KEY (id_club, id_player)
REFERENCES Players(id_club, id_player),
CONSTRAINT fk_id_match FOREIGN KEY (id_match)
REFERENCES Date_Location(id_match)
)

CREATE TABLE Fans(
fan_id int PRIMARY KEY,
login varchar(50) NOT NULL,
password varchar(50) NOT NULL,
Name varchar(50) NOT NULL,
Surname varchar(50) NOT NULL
)

CREATE TABLE Admins(
admin_id int PRIMARY KEY,
login_adm varchar(50) NOT NULL,
password_adm varchar(50) NOT NULL,

)

GO
INSERT INTO Coaches(id_coach, Country_birth, Surname, Name)
VALUES
(1001, '��������', '������', '�����'),
(1002, '��������', '�������', '������'),
(1003, '�������', '����', '��������'),
(1004, '�������', '���������', '�����'),
(1005, '������', '���������', '�����'),
(1006, '������', '�����', '������'),
(1007, '��������', '�����������', '�����'),
(1008, '���������', '���������', '��������'),
(1009, '������', '������', '�������')


INSERT INTO Clubs(id_club, Name_club, Country, City, id_coach)
VALUES
(101, '�����', '������', '������', 1001),
(102, '���������', '������', '������', 1002),
(103, '���������', '�������', '���������', 1003),
(104, '��������� ����', '������', '���������', 1004),
(105, '���� ������', '�������', '������', 1005),
(106, '�����', '������', '�����-���������', 1006),
(107, '������� ������', '��������', '������', 1007),
(108, '���', '�������', '�����', 1008)


INSERT INTO Players(id_player, Surname, Name, Position, Number_player, id_club)
VALUES
(1, '�����', '�����', '��', 1, 101),
(2, '������', '������', '��', 27, 101),
(3, '�����', '�����', '��', 4, 101),
(4, '�����������', '�����', '��', 28, 101),
(5, '������', '���', '��', 13, 101),
(6, '�����', '�����', '���', 7, 101),
(7, '�������', '�����', '��', 8, 101),
(8, '������', '���', '���', 22, 101),
(9, '�������', '��������', '��', 10, 101),
(10, '������', '������', '���', 9, 101),
(11, '������', '����', '��', 11, 101),
(12, '�������', '��������', '��', 1, 102),
(13, '�����', '�����', '��', 31, 102),
(14, '�����', '���', '��', 3, 102),
(15, '�������', '���������', '��', 20, 102),
(16, '����������', '�������', '��', 2, 102),
(17, '�������', '�������', '���', 6, 102),
(18, '����-����', '�������', '���', 8, 102),
(19, '��������', '�����', '���', 11, 102),
(20, '������', '�������', '��', 10, 102),
(21, '�����', '��', '���', 9, 102),
(22, '����', '�������', '��', 15, 102),
(23, '���-������', '����', '��', 1, 103),
(24, '�����', '�����', '��', 30, 103),
(25, '����', '�����', '��', 3, 103),
(26, '������', '����', '��', 4, 103),
(27, '�����', '����', '��', 22, 103),
(28, '�������', '������', '���', 8, 103),
(29, '�� ����', '������', '��', 28, 103),
(30, '�����', '������', '���', 9, 103),
(31, '�������', '�����', '��', 10, 103),
(32, '���������', '����-������', '���', 28, 103),
(33, '��������', '�������', '��', 98, 103),
(34, '������', '�������', '��', 31, 104),
(35, '��������', '���������', '��', 11, 104),
(36, '����', '�����', '��', 3, 104),
(37, '������', '����', '��', 4, 104),
(38, '�����', '����', '��', 5, 104),
(39, '��������', '�����', '��', 20, 104),
(40, '������', '��������', '���', 21, 104),
(41, '�����', '����', '���', 28, 104),
(42, '��������', '�����', '���', 10, 104),
(43, '������', '��������', '���', 9, 104),
(44, '�����', '���', '���', 15, 104),
(45, '������', '����', '��', 1, 105),
(46, '�����', '�������', '��', 2, 105),
(47, '�������', '����', '��', 3, 105),
(48, '���������', '����', '��', 4, 105),
(49, '���������', '����', '��', 5, 105),
(50, '��������', '�����', '���', 6, 105),
(51, '������', '����', '��', 7, 105),
(52, '�����', '����', '��', 8, 105),
(53, '����', '����', '��', 10, 105),
(54, '�������', '�����', '���', 9, 105),
(55, '����', '�����', '��', 11, 105),
(56, '������', '���������', '��', 1, 106),
(57, '��������', '������', '��', 5, 106),
(58, '������', '����', '��', 2, 106),
(59, '��������', '�������', '��', 3, 106),
(60, '��������', '�������', '��', 4, 106),
(61, '��������', '��������', '��', 42, 106),
(62, '�������', '�������', '���', 6, 106),
(63, '������', '�������', '���', 8, 106),
(64, '������', '�������', '���', 7, 106),
(65, '�����', '����', '���', 22, 106),
(66, '�����', '������', '���', 9, 106),
(67, '�����', '�������', '��', 1, 107),
(68, '�����', '��������', '��', 2, 107),
(69, '����', '�������', '��', 3, 107),
(70, '��������', '����', '��', 4, 107),
(71, '�����', '��������', '��', 5, 107),
(72, '�������', '����', '��', 8, 107),
(73, '������', '�����', '��', 10, 107),
(74, '�������', '�������', '���', 22, 107),
(75, '�����', '�������', '��', 11, 107),
(76, '�����������', '������', '���', 9, 107),
(77, '������', '����', '��', 20, 107),
(78, '�����', '������', '��', 1, 108),
(79, '������', '����', '��', 23, 108),
(80, '���������', '���', '��', 3, 108),
(81, '������', '����', '��', 4, 108),
(82, '������', '�����', '��', 22, 108),
(83, '���', '�������', '���', 20, 108),
(84, '�������', '�������', '���', 8, 108),
(85, '�����', '�������', '���', 31, 108),
(86, '������', '�����', '��', 10, 108),
(87, '������', '������', '���', 9, 108),
(88, '�� �����', '������', '��', 11, 108)


INSERT INTO Location(id_stadium, Name_stadium, Country, City)
VALUES 
(10, '�������� �����', '������', '������'),
(20, '��� �����', '������', '������'),
(30, '���� ���', '�������', '���������'),
(40, '������ �������', '������', '���������'),
(50, '�������� ��������', '�������', '������'),
(60, '������� �����', '������', '�����-���������'),
(70, '������ �����', '��������', '������'),
(80, '���� �� �����', '�������', '�����'),
(90, '��������', '�������', '�������'),
(100, '��� ��������', '������', '���������'),
(110, '��� ����', '������', '�����'),
(120, '�������� �����', '������', '������'),
(130, '��������-����', '��������', '��������'),
(140, '�������� �������', '������', '������')



INSERT INTO Date_Location(id_match, Date_time, id_stadium, Name_tournament)
VALUES 
(10, CAST('19/04/2022 20:00:00' as smalldatetime), 10, 'Champions CUP'),
(11, CAST('19/04/2022 20:00:00' as smalldatetime), 10, 'Champions CUP'),
(20, CAST('19/04/2022 22:30:00' as smalldatetime), 20, 'Champions CUP'),
(21, CAST('19/04/2022 22:30:00' as smalldatetime), 20, 'Champions CUP'),
(30, CAST('20/04/2022 20:00:00' as smalldatetime), 30, 'Champions CUP'),
(31, CAST('20/04/2022 20:00:00' as smalldatetime), 30, 'Champions CUP'),
(40, CAST('20/04/2022 22:30:00' as smalldatetime), 50, 'Champions CUP'),
(41, CAST('20/04/2022 22:30:00' as smalldatetime), 50, 'Champions CUP'),
(50, CAST('03/05/2022 20:00:00' as smalldatetime), 80, 'Champions CUP'),
(51, CAST('03/05/2022 20:00:00' as smalldatetime), 80, 'Champions CUP'),
(60, CAST('03/05/2022 22:30:00' as smalldatetime), 70, 'Champions CUP'),
(61, CAST('03/05/2022 22:30:00' as smalldatetime), 70, 'Champions CUP'),
(70, CAST('04/05/2022 20:00:00' as smalldatetime), 60, 'Champions CUP'),
(71, CAST('04/05/2022 20:00:00' as smalldatetime), 60, 'Champions CUP'),
(80, CAST('04/05/2022 22:30:00' as smalldatetime), 40, 'Champions CUP'),
(81, CAST('04/05/2022 22:30:00' as smalldatetime), 40, 'Champions CUP')



INSERT INTO Results(id_match, id_club, Final_Score)
VALUES
(10, 101, '2:1'),
(11, 108, '1:2'),
(20, 102, '3:1'),
(21, 107, '1:3'),
(30, 103, '1:0'),
(31, 106, '0:1'),
(40, 104, '2:0'),
(41, 105, '0:2'),
(50, 108, '4:0'),
(51, 101, '0:4'),
(60, 107, '1:1'),
(61, 102, '1:1'),
(70, 106, '0:3'),
(71, 103, '3:0'),
(80, 105, '2:2'),
(81, 104, '2:2')


INSERT INTO Goals(id_match, id_player, id_club, Score)
VALUES
(10, 10, 101, 2),
(10, 84, 108, 1),
(20, 18, 102, 1),
(20, 19, 102, 1),
(20, 21, 102, 1),
(20, 69, 107, 1),
(30, 32, 103, 1),
(40, 36, 104, 1),
(40, 40, 104, 1),
(50, 85, 108, 1),
(50, 86, 108, 1),
(50, 87, 108, 2),
(60, 76, 107, 1),
(60, 14, 102, 1),
(70, 28, 103, 1),
(70, 30, 103, 2),
(80, 54, 105, 1),
(80, 52, 105, 1),
(80, 44, 104, 2)

GO
INSERT INTO Fans
VALUES
(1, 'samokhin28', '1511', '��������', '���������')


GO
INSERT INTO Admins
VALUES
(1, 'komar1511', '1511')

use Football
go
UPDATE Coaches 
SET ImageCoach = 
      (SELECT * FROM OPENROWSET(BULK N'C:\Users\komar1511\Desktop\Kyrsa4\Coach\tuchel.jpg', SINGLE_BLOB) AS image)
WHERE id_coach = 1001

use Football
go
UPDATE Coaches 
SET ImageCoach = 
      (SELECT * FROM OPENROWSET(BULK N'C:\Users\komar1511\Desktop\Kyrsa4\Coach\gisdol.jpg', SINGLE_BLOB) AS image)
WHERE id_coach = 1002

use Football
go
UPDATE Coaches 
SET ImageCoach = 
      (SELECT * FROM OPENROWSET(BULK N'C:\Users\komar1511\Desktop\Kyrsa4\Coach\xavi.jpg', SINGLE_BLOB) AS image)
WHERE id_coach = 1003

use Football
go
UPDATE Coaches 
SET ImageCoach = 
      (SELECT * FROM OPENROWSET(BULK N'C:\Users\komar1511\Desktop\Kyrsa4\Coach\guardiola.jpg', SINGLE_BLOB) AS image)
WHERE id_coach = 1004

use Football
go
UPDATE Coaches 
SET ImageCoach = 
      (SELECT * FROM OPENROWSET(BULK N'C:\Users\komar1511\Desktop\Kyrsa4\Coach\anchelotti.jpg', SINGLE_BLOB) AS image)
WHERE id_coach = 1005

use Football
go
UPDATE Coaches 
SET ImageCoach = 
      (SELECT * FROM OPENROWSET(BULK N'C:\Users\komar1511\Desktop\Kyrsa4\Coach\nagelsmann.jpg', SINGLE_BLOB) AS image)
WHERE id_coach = 1007

use Football
go
UPDATE Coaches 
SET ImageCoach = 
      (SELECT * FROM OPENROWSET(BULK N'C:\Users\komar1511\Desktop\Kyrsa4\Coach\pochettino.jpg', SINGLE_BLOB) AS image)
WHERE id_coach = 1008

use Football
go
UPDATE Location 
SET ImageStadium = 
      (SELECT * FROM OPENROWSET(BULK N'C:\Users\komar1511\Desktop\Kyrsa4\Stadium\Stamford.jpg', SINGLE_BLOB) AS image)
WHERE id_stadium = 10

use Football
go
UPDATE Location 
SET ImageStadium = 
      (SELECT * FROM OPENROWSET(BULK N'C:\Users\komar1511\Desktop\Kyrsa4\Stadium\RZD.jpg', SINGLE_BLOB) AS image)
WHERE id_stadium = 20

use Football
go
UPDATE Location 
SET ImageStadium = 
      (SELECT * FROM OPENROWSET(BULK N'C:\Users\komar1511\Desktop\Kyrsa4\Stadium\Camp.jpg', SINGLE_BLOB) AS image)
WHERE id_stadium = 30

use Football
go
UPDATE Location 
SET ImageStadium = 
      (SELECT * FROM OPENROWSET(BULK N'C:\Users\komar1511\Desktop\Kyrsa4\Stadium\Etihad.jpg', SINGLE_BLOB) AS image)
WHERE id_stadium = 40

use Football
go
UPDATE Location 
SET ImageStadium = 
      (SELECT * FROM OPENROWSET(BULK N'C:\Users\komar1511\Desktop\Kyrsa4\Stadium\Santiago.jpg', SINGLE_BLOB) AS image)
WHERE id_stadium = 50

use Football
go
UPDATE Location 
SET ImageStadium = 
      (SELECT * FROM OPENROWSET(BULK N'C:\Users\komar1511\Desktop\Kyrsa4\Stadium\Gazprom.jpg', SINGLE_BLOB) AS image)
WHERE id_stadium = 60

use Football
go
UPDATE Location 
SET ImageStadium = 
      (SELECT * FROM OPENROWSET(BULK N'C:\Users\komar1511\Desktop\Kyrsa4\Stadium\Allianz.jpg', SINGLE_BLOB) AS image)
WHERE id_stadium = 70

use Football
go
UPDATE Location 
SET ImageStadium = 
      (SELECT * FROM OPENROWSET(BULK N'C:\Users\komar1511\Desktop\Kyrsa4\Stadium\Parc.jpg', SINGLE_BLOB) AS image)
WHERE id_stadium = 80

use Football
go
UPDATE Location 
SET ImageStadium = 
      (SELECT * FROM OPENROWSET(BULK N'C:\Users\komar1511\Desktop\Kyrsa4\Stadium\Velodrom.jpg', SINGLE_BLOB) AS image)
WHERE id_stadium = 90

use Football
go
UPDATE Location 
SET ImageStadium = 
      (SELECT * FROM OPENROWSET(BULK N'C:\Users\komar1511\Desktop\Kyrsa4\Stadium\Old.jpg', SINGLE_BLOB) AS image)
WHERE id_stadium = 100

use Football
go
UPDATE Location 
SET ImageStadium = 
      (SELECT * FROM OPENROWSET(BULK N'C:\Users\komar1511\Desktop\Kyrsa4\Stadium\Sansiro.jpg', SINGLE_BLOB) AS image)
WHERE id_stadium = 110

use Football
go
UPDATE Location 
SET ImageStadium = 
      (SELECT * FROM OPENROWSET(BULK N'C:\Users\komar1511\Desktop\Kyrsa4\Stadium\Otkritie.jpg', SINGLE_BLOB) AS image)
WHERE id_stadium = 120

use Football
go
UPDATE Location 
SET ImageStadium = 
      (SELECT * FROM OPENROWSET(BULK N'C:\Users\komar1511\Desktop\Kyrsa4\Stadium\Borussia.jpg', SINGLE_BLOB) AS image)
WHERE id_stadium = 130

use Football
go
UPDATE Location 
SET ImageStadium = 
      (SELECT * FROM OPENROWSET(BULK N'C:\Users\komar1511\Desktop\Kyrsa4\Stadium\Emirates.jpg', SINGLE_BLOB) AS image)
WHERE id_stadium = 140






USE Football
GO 
IF OBJECT_ID ( 'Top_Scorer_Clubs3', 'P' ) IS NOT NULL 
DROP PROCEDURE Top_Scorer_Clubs3; 
GO 
CREATE PROCEDURE Top_Scorer_Clubs3
AS
SELECT TOP (3) dbo.Clubs.country, dbo.Clubs.city, dbo.Clubs.name_club, SUM(dbo.Goals.Score) AS Score
FROM  dbo.Clubs INNER JOIN
         dbo.Goals ON dbo.Clubs.id_club = dbo.Goals.id_club
GROUP BY dbo.Clubs.country, dbo.Clubs.city, dbo.Clubs.name_club
ORDER BY Score DESC


GO 
IF OBJECT_ID ( 'Top_Scorer5', 'P' ) IS NOT NULL 
DROP PROCEDURE Top_Scorer5; 
GO 
CREATE PROCEDURE Top_Scorer5
AS
SELECT TOP (5) dbo.Players.Surname, dbo.Players.Name, dbo.Players.Number_player, dbo.Players.Position, dbo.Clubs.name_club, SUM(dbo.Goals.Score) AS Score
FROM  dbo.Clubs INNER JOIN
         dbo.Players ON dbo.Clubs.id_club = dbo.Players.id_club INNER JOIN
         dbo.Goals ON dbo.Players.id_club = dbo.Goals.id_club AND dbo.Players.id_player = dbo.Goals.id_player
GROUP BY dbo.Players.Surname, dbo.Players.Name, dbo.Players.Number_player, dbo.Players.Position, dbo.Clubs.name_club
ORDER BY Score DESC, dbo.Players.Number_player ASC

GO 
IF OBJECT_ID ( 'Top_ScorerAll', 'P' ) IS NOT NULL 
DROP PROCEDURE Top_ScorerAll; 
GO 
CREATE PROCEDURE Top_ScorerAll
AS
SELECT dbo.Players.Surname, dbo.Players.Name, dbo.Players.Number_player, dbo.Players.Position, dbo.Clubs.name_club, SUM(dbo.Goals.Score) AS Score
FROM  dbo.Clubs INNER JOIN
         dbo.Players ON dbo.Clubs.id_club = dbo.Players.id_club INNER JOIN
         dbo.Goals ON dbo.Players.id_club = dbo.Goals.id_club AND dbo.Players.id_player = dbo.Goals.id_player
GROUP BY dbo.Players.Surname, dbo.Players.Name, dbo.Players.Number_player, dbo.Players.Position, dbo.Clubs.name_club
ORDER BY Score DESC, dbo.Players.Number_player ASC

GO 
IF OBJECT_ID ( 'Coaches_proc', 'P' ) IS NOT NULL 
DROP PROCEDURE Coaches_proc; 
GO 
CREATE PROCEDURE Coaches_proc
AS
SELECT dbo.Coaches.Surname, dbo.Coaches.Name, dbo.Coaches.Country_birth, dbo.Coaches.ImageCoach, dbo.Clubs.name_club
FROM  dbo.Coaches INNER JOIN
         dbo.Clubs ON dbo.Coaches.id_coach = dbo.Clubs.id_coach

GO 
IF OBJECT_ID ( 'Score_In_Match', 'P' ) IS NOT NULL 
DROP PROCEDURE Score_In_Match; 
GO 
CREATE PROCEDURE Score_In_Match
AS
SELECT DISTINCT dbo.Clubs.name_club, dbo.Players.Surname, dbo.Players.Position, dbo.Goals.Score, goals.id_match
FROM  dbo.Goals INNER JOIN
         dbo.Players ON dbo.Goals.id_club = dbo.Players.id_club AND dbo.Goals.id_player = dbo.Players.id_player INNER JOIN
         dbo.Results ON dbo.Goals.id_club = dbo.Results.id_club INNER JOIN
         dbo.Clubs ON dbo.Players.id_club = dbo.Clubs.id_club AND dbo.Results.id_club = dbo.Clubs.id_club
ORDER BY Goals.id_match

GO 
IF OBJECT_ID ( 'Match_Location', 'P' ) IS NOT NULL 
DROP PROCEDURE Match_Location; 
GO 
CREATE PROCEDURE Match_Location
AS
SELECT dbo.Results.Final_Score, dbo.Location.City, dbo.Clubs.name_club, dbo.Location.Name_stadium, dbo.Results.id_match, dbo.Date_Location.Date_time
FROM  dbo.Clubs INNER JOIN
         dbo.Results ON dbo.Clubs.id_club = dbo.Results.id_club INNER JOIN
         dbo.Date_Location ON dbo.Results.id_match = dbo.Date_Location.id_match INNER JOIN
         dbo.Location ON dbo.Date_Location.id_stadium = dbo.Location.id_stadium
ORDER BY dbo.Results.id_match

