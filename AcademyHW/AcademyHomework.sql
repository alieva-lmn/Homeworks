create table Groups
(
    ID int identity (1, 1) primary key NOT NULL,
    Name nvarchar(10) NOT NULL UNIQUE,
    Rating int NOT NULL CHECK (Rating <= 5 AND Rating >= 0),
    Year int NOT NULL CHECK (Year <= 5 AND Year >= 1)
);

create table Departments
(
    ID int identity (1, 1) primary key NOT NULL,
    Financing money NOT NULL CHECK (Financing > 0) DEFAULT 0,
    Name nvarchar(100) NOT NULL UNIQUE
);

create table Faculties
(
    ID int identity (1, 1) primary key NOT NULL,
    Name nvarchar(100) NOT NULL UNIQUE
);

create table Teachers
(
    ID int identity (1, 1) primary key NOT NULL,
    EmploymentDate date NOT NULL CHECK (EmploymentDate > '1990-01-01'),
    Name nvarchar(max) NOT NULL,
    Premium money NOT NULL CHECK (Premium > 0) DEFAULT 0,
    Salary money NOT NULL CHECK (Salary > 0),
    Surname nvarchar(max) NOT NULL
);

insert into Groups values('FBMS_1221', 2, 4);
insert into Groups values('FBMS_2112', 1, 5);
insert into Faculties values('Software Engineering');
insert into Departments values(120000, 'SOMENAME');
insert into Departments values(150000, 'ANOTHERNAME');
insert into Teachers values('1996-08-16', 'Laman', 2200, 4100, 'Aliyeva');

select *
from Teachers;