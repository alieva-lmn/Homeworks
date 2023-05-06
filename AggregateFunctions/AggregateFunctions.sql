use [UpdatedHospital]

create table Departments
(
  ID int identity (1, 1) primary key NOT NULL,
  Building int NOT NULL check(Building between 1 and 5),
  Name nvarchar(100) NOT NULL UNIQUE,
);

create table Doctors
(
  ID int identity (1, 1) primary key NOT NULL,
  Name nvarchar(max) NOT NULL,
  Premium money NOT NULL CHECK (Premium >= 0) DEFAULT 0,
  Salary money NOT NULL CHECK (Salary > 0),
  Surname nvarchar(max) NOT NULL
);

create table DoctorsExaminations
(
    ID int identity (1, 1) primary key NOT NULL,
    EndTime time NOT NULL check(EndTime > '08:00'),
    StartTime time NOT NULL check(StartTime between '08:00' and '18:00'),
    DoctorId int NOT NULL foreign key references Doctors(ID),
    ExaminationId int NOT NULL foreign key references Examinations(ID),
    WardId int NOT NULL foreign key references Wards(ID)
);

create table Examinations
(
  ID int identity (1, 1) primary key NOT NULL,
  Name nvarchar(100) NOT NULL UNIQUE
);

create table Wards
(
  ID int identity (1, 1) primary key NOT NULL,
  Name nvarchar(20) NOT NULL UNIQUE,
  Places int NOT NULL check(Places > 0),
  DepartmentId int NOT NULL foreign key references Departments(ID)
);


insert into Departments values(2, 'General surgery');
insert into Departments values(3, 'Cardiology');
insert into Departments values(5, 'Ophthalmology');
insert into Departments values(5, 'Neurosurgery');

insert into Doctors values('Anne', 1200, 2200, 'Rice');
insert into Doctors values('Mary', 1600, 3300, 'Shelley');
insert into Doctors values('Kristen', 2500, 4600, 'Bond');

insert into DoctorsExaminations values('09:30', '09:15', 1, 1, 1);
insert into DoctorsExaminations values('10:15', '10:00', 2, 2, 2);
insert into DoctorsExaminations values('12:30', '12:00', 3, 3, 3);

insert into Examinations values('E1');
insert into Examinations values('E2');
insert into Examinations values('E3');

insert into Wards values('W1', 3, 1);
insert into Wards values('W2', 5, 2);
insert into Wards values('W3', 2, 3);
insert into Wards values('W4', 16, 1);
insert into Wards values('W5', 12, 2);
insert into Wards values('W6', 12, 4);
insert into Wards values('W7', 8, 1);


select count(*)
from Wards
where Places > 10

select Departments.Building, count(Wards.Id) as AmountOfWards
from Departments
inner join Wards on Departments.ID = Wards.DepartmentId
group by Departments.Building

select Departments.Name, count(Wards.Id) as AmountOfWards
from Departments
inner join Wards on Departments.ID = Wards.DepartmentId
group by Departments.Name

select Departments.Name, sum(Doc.Premium) as "Premium of all Docs"
from Departments
inner join Wards Ward on Departments.ID = Ward.DepartmentId
inner join DoctorsExaminations DocEx on Ward.ID = DocEx.WardId
inner join Doctors Doc on DocEx.DoctorId = Doc.Id
group by Departments.Name

select count(*) as 'Count of Doctors', sum(Doctors.Salary + Doctors.Premium) as 'Average Salary'
from Doctors

select avg(Salary + Premium)
from Doctors

select Name, Places
from Wards
where Places = (select min(Places) from Wards)
