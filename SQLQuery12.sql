create database Studente_Esame

create table Studente(
id int identity(1,1) primary key,
Nome varchar(40) not null,
Cognome varchar(40) not null,
AnnoNascita datetime not null)

create table Esame(
id int identity(1,1) primary key,
Nome varchar(40) not null,
CFU smallint not null,
Datas datetime not null,
idStudente int foreign key references Studente(id),
Votazione smallint not null,
Passato bit not null
)

insert into Studente(Nome, Cognome, AnnoNascita) values ('Pinco', 'Panco', 08-04-1995);
insert into Studente(Nome, Cognome, AnnoNascita) values ('Cinco', 'DiMaggio', 08-04-1995);
insert into Esame(Nome, CFU, Datas, idStudente, Votazione, Passato) values ('CryptoCurrencies', 6, 14-07-2021, 1, 30, 1);

select *
from Studente 