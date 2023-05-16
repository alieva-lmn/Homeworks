use [Med];

create table Departments
(
  ID int identity (1, 1) primary key NOT NULL,
  Building int NOT NULL check(Building between 1 and 5),
  Financing money NOT NULL check(Financing >= 0) default 0,
  Name nvarchar(100) NOT NULL UNIQUE
);

create table Diseases
(
  ID int identity (1, 1) primary key NOT NULL,
  Name nvarchar(100) NOT NULL UNIQUE
);

create table Doctors
(
  ID int identity (1, 1) primary key NOT NULL,
  Name nvarchar(max) NOT NULL,
  Salary money NOT NULL CHECK (Salary > 0),
  Surname nvarchar(max) NOT NULL
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

create table DoctorsExaminations
(
    ID int identity (1, 1) primary key NOT NULL,
    Date date NOT NULL check(date <= getdate()),
    DiseasesId int NOT NULL foreign key references Diseases(ID),
    DoctorId int NOT NULL foreign key references Doctors(ID),
    ExaminationId int NOT NULL foreign key references Examinations(ID),
    WardId int NOT NULL foreign key references Wards(ID)
);

create table Professors
(
  ID int identity (1, 1) primary key NOT NULL,
  DoctorId int NOT NULL foreign key references Doctors(ID)
);

create table Interns
(
  ID int identity (1, 1) primary key NOT NULL,
  DoctorId int NOT NULL foreign key references Doctors(ID)
);

insert into Departments values(2, 16000, 'General surgery');
insert into Departments values(3, 22000, 'Cardiology');
insert into Departments values(5, 150000, 'Ophthalmology');

insert into Diseases values('Eczema');
insert into Diseases values('Anaemia');
insert into Diseases values('Herpes');

insert into Doctors values('Anne', 2200, 'Rice');
insert into Doctors values('Mary', 3300, 'Shelley');
insert into Doctors values('Kristen', 4600, 'Bond');

insert into Examinations values('E1');
insert into Examinations values('E2');
insert into Examinations values('E3');

insert into Wards values('W1', 2, 1);
insert into Wards values('W2', 3, 2);
insert into Wards values('W3', 1, 2);

insert into DoctorsExaminations values('2023-01-22', 1, 2, 3, 2);
insert into DoctorsExaminations values('2023-01-23', 1, 1, 2, 1);
insert into DoctorsExaminations values('2023-01-24', 2, 1, 2, 3);
insert into DoctorsExaminations values('2023-05-11', 2, 1, 2, 3);

insert into Professors values(1);
insert into Professors values(2);
insert into Professors values(3);

insert into Interns values(3);
insert into Interns values(2);
insert into Interns values(1);


-- 1

select Wards.Name, Wards.Places
from Wards
inner join Departments
on Wards.DepartmentId = Departments.ID
where Building = 5 and Places >= 5
and exists (select Wards.Name, Wards.Places from Wards where Places > 15)

-- 2

select Departments.Name
from Departments
inner join Wards
on Departments.ID = Wards.DepartmentId
inner join DoctorsExaminations
on Wards.ID = DoctorsExaminations.WardId
where YEAR(DoctorsExaminations.Date) = YEAR(dateadd(week, -7, getdate()))

-- 3

select Diseases.Name
from Diseases
left join DoctorsExaminations
on DoctorsExaminations.DiseasesId = Diseases.ID
where DoctorsExaminations.ID is null

-- 4

select Doctors.Name, Doctors.Surname
from Doctors
left join DoctorsExaminations
on DoctorsExaminations.DoctorId = Doctors.ID
where DoctorsExaminations.ID is null

-- 5

select Departments.Name
from Departments
left join Wards
on Departments.ID = Wards.DepartmentId
left join DoctorsExaminations
on Wards.ID = DoctorsExaminations.WardId
where ExaminationId is null