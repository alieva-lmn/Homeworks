use [Hospital]

create table Departments
(
  ID int identity (1, 1) primary key NOT NULL,
  Building int NOT NULL check(Building between 1 and 5),
  Financing money NOT NULL check(Financing >= 0) default 0,
  Floor int NOT NULL check(Floor > 0),
  Name nvarchar(100) NOT NULL UNIQUE
);

create table Diseases
(
  ID int identity (1, 1) primary key NOT NULL,
  Name nvarchar(100) NOT NULL UNIQUE,
  Severity int NOT NULL check(Severity > 0) default 1
);

create table Doctors
(
  ID int identity (1, 1) primary key NOT NULL,
  Name nvarchar(max) NOT NULL,
  Phone char(10) NOT NULL,
  Premium money NOT NULL CHECK (Premium >= 0) DEFAULT 0,
  Salary money NOT NULL CHECK (Salary > 0),
  Surname nvarchar(max) NOT NULL
);

create table Examinations
(
  ID int identity (1, 1) primary key NOT NULL,
  DayOfWeek int NOT NULL check(DayOfWeek between 1 and 7),
  EndTime time NOT NULL check(EndTime > '08:00'),
  Name nvarchar(100) NOT NULL UNIQUE,
  StartTime time NOT NULL check(StartTime between '08:00' and '18:00')
);

create table Wards
(
  ID int identity (1, 1) primary key NOT NULL,
  Building int NOT NULL check(Building between 1 and 5),
  Floor int NOT NULL check(Floor > 0),
  Name nvarchar(20) NOT NULL UNIQUE
);

insert into Departments values(2, 16000, 1, 'General surgery');
insert into Departments values(3, 22000, 5, 'Cardiology');
insert into Departments values(5, 150000, 8, 'Ophthalmology');

insert into Diseases values('Eczema', 3);
insert into Diseases values('Anaemia', 1);
insert into Diseases values('Herpes', 2);

insert into Doctors values('Anne', '0554056009', 1200, 2200, 'Rice');
insert into Doctors values('Mary', '0557004343', 1600, 3300, 'Shelley');
insert into Doctors values('Kristen', '0503224645', 2500, 4600, 'Bond');

insert into Examinations values(2, '09:00', 'E1', '08:30');
insert into Examinations values(5, '10:15', 'E2', '10:00');
insert into Examinations values(7, '12:30', 'E3', '12:00');

insert into Wards values(2, 1, 'W1');
insert into Wards values(1, 3, 'W2');
insert into Wards values(5, 2, 'W3');

select *
from Wards

select Surname, Phone
from Doctors

select distinct Floor
from Wards

select Name 'Name of Disease', Severity 'Severity of Disease'
from Diseases

select Name 'Name of Examinations'
from Examinations

select Floor 'Ward Floor'
from Wards

select Name 'Doctor Name'
from Doctors

select Name
from Departments
where Building = 5 and Financing < 30000

select Name
from Departments
where Building = 3 and Financing between 12000 and 15000

select Name
from Wards
where Floor = 1 and Building in (4, 5)

select Name, Building, Financing
from Departments
where Building in (3, 6) and (Financing < 11000 or Financing > 25000)

select Surname
from Doctors
where Salary + Premium > 1500

select Surname
from Doctors
where Salary/2 > Premium * 3

select Name
from Examinations
where DayOfWeek in (1, 3) and StartTime between '12:00' and '15:00'

select Name, Building
from Departments
where Building in (1, 3, 8, 10)

select Name
from Diseases
where Severity not in(1, 2)

select Name
from Departments
where Building not in(1, 3)

select Name
from Departments
where Building in(1, 3)

select Surname
from Doctors
where Surname like 'N%'