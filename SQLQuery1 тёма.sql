
use db_AK;

CREATE TABLE Reader(
	ID_reader INTEGER IDENTITY(1, 1) PRIMARY KEY NOT NULL,
	
	reader_Name VARCHAR(30) NOT NULL,
	reader_Surname VARCHAR(30) NOT NULL,
	reader_Otchestvo VARCHAR(30) NOT NULL,
	reader_Phone VARCHAR(30) NOT NULL,
	reader_strahpolis VARCHAR(30) NOT NULL,
	reader_medbook VARCHAR(30) NOT NULL,
	reader_birthday VARCHAR(30) NOT NULL
	);


CREATE TABLE AdressOfClient(
	ID_AdressOfClient INTEGER IDENTITY(1, 1) PRIMARY KEY,
	
	clientAdress_Region VARCHAR(30) NOT NULL,
	clientAdress_City VARCHAR(30) NOT NULL,
	clientAdress_District VARCHAR(30) NOT NULL,
	clientAdress_Street VARCHAR(30) NOT NULL,
	clientAdress_House VARCHAR(10) NOT NULL,
	clientAdress_Appartment VARCHAR(10)
);
alter table Reader add ID_AdressOfClient int
alter table Reader add foreign key (ID_AdressOfClient) references dbo.AdressOfClient(ID_AdressOfClient) on delete no action on update cascade

CREATE TABLE Book(
	ID_book INTEGER IDENTITY(1, 1) PRIMARY KEY NOT NULL,

	book_Name VARCHAR(30) NOT NULL,
	book_level VARCHAR(30) NOT NULL,
	book_sympthoms VARCHAR(100) NOT NULL
);

CREATE TABLE Author(
	ID_author INTEGER IDENTITY(1, 1) PRIMARY KEY NOT NULL,

	author_pills VARCHAR(30) NOT NULL,
	author_sroklechenia VARCHAR(30) NOT NULL
);
alter table Book add ID_author int
alter table Book add foreign key (ID_author) references dbo.Author(ID_author) on delete no action on update cascade


CREATE TABLE Borrowing(
	ID_borrowing INTEGER IDENTITY(1, 1) PRIMARY KEY,

	borrowing_DateOfObrashenia DATE NOT NULL DEFAULT CURRENT_TIMESTAMP,
	borrowing_price INTEGER,
	borrowing_Status VARCHAR(30)

);

CREATE TABLE Librarian(
	ID_librarian INTEGER IDENTITY(1, 1) PRIMARY KEY,
	
	librarian_FIO VARCHAR(100) NOT NULL,
	librarian_Phone VARCHAR(30) NOT NULL,
	librarian_position VARCHAR(30) NOT NULL,
	librarian_specialization VARCHAR(30) NOT NULL,
	librarian_qualification VARCHAR(30) NOT NULL

);
34215
alter table Borrowing add ID_book int
alter table Borrowing add foreign key (ID_book) references dbo.Book(ID_book) on delete no action on update cascade

alter table Borrowing add ID_reader int
alter table Borrowing add foreign key (ID_reader) references dbo.Reader(ID_reader) on delete no action on update cascade

alter table Borrowing add ID_librarian int
alter table Borrowing add foreign key (ID_librarian) references dbo.Librarian(ID_librarian) on delete no action on update cascade

DROP TABLE Borrowing

DELETE FROM Book;

SELECT * FROM Borrowing 
                INNER JOIN Librarian ON Librarian.ID_librarian = Borrowing.ID_librarian
                INNER JOIN Reader ON Reader.ID_reader = Borrowing.ID_reader 
                INNER JOIN Book ON Book.ID_book = Borrowing.ID_book
                where Librarian.librarian_FIO = ' ыщаорпи'

SELECT ID_borrowing, borrowing_price, borrowing_Status, b.reader_Surname, b.reader_Name
                FROM Borrowing a 
                INNER JOIN Reader b ON b.ID_reader = a.ID_reader 
                where borrowing_price BETWEEN 1001 and 2001

SELECT *
                FROM Borrowing
                INNER JOIN Reader ON Reader.ID_reader = Borrowing.ID_reader 
                INNER JOIN Book ON Book.ID_book = Borrowing.ID_book 
                where Reader.reader_Surname = ' Баторов'
SELECT * FROM Borrowing LEFT JOIN Reader ON Reader.ID_reader = Borrowing.ID_reader 
            LEFT JOIN AdressOfClient ON AdressOfClient.ID_AdressOfClient = Reader.ID_AdressOfClient LEFT JOIN Book ON Book.ID_book = Borrowing.ID_book 
         