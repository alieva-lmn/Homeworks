use NewAcademy;

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
    Dean nvarchar(max) NOT NULL,
    Name nvarchar(100) NOT NULL UNIQUE
);

create table Teachers
(
    ID int identity (1, 1) primary key NOT NULL,
    EmploymentDate date NOT NULL CHECK (EmploymentDate > '1990-01-01'),
    IsAssistant bit NOT NULL DEFAULT 0,
    IsProfessor bit NOT NULL DEFAULT 0,
    Name nvarchar(max) NOT NULL,
    Position nvarchar(max) NOT NULL,
    Premium money NOT NULL CHECK (Premium > 0) DEFAULT 0,
    Salary money NOT NULL CHECK (Salary > 0),
    Surname nvarchar(max) NOT NULL
);


insert into Groups values('Group1', 2, 4);
insert into Groups values('Group2', 1, 5);
insert into Groups values('Group3', 3, 5);

insert into Faculties values('Anne Rice', 'Computer-Aided Design');
insert into Faculties values('Mary Shelley', 'Computer Science');
insert into Faculties values('C. S. Lewis', 'Psychology');

insert into Departments values(20000, 'Astrophysics');
insert into Departments values(15000, 'Psychology');
insert into Departments values(180000, 'Software Development');
insert into Departments values(16000, 'Philosophy');
insert into Departments values(12000, 'Vampirology');

insert into Teachers values('1996-08-16', 0, 0, 'Martha', 'Teacher', 2200, 1000, 'Scott');
insert into Teachers values('1995-12-25', 0, 1, 'Jeff', 'PhD', 2300, 6300, 'Bridges');
insert into Teachers values('1994-05-18', 0, 1, 'Bill', 'PhD', 3400, 850, 'Murray');
insert into Teachers values('1994-03-23', 1, 0, 'Remus', 'Teacher', 220, 750, 'Lupin');
insert into Teachers values('1992-02-22', 1, 0, 'Ian', 'Teacher Assistant', 190, 650, 'Hart');


select *
from Departments
order by ID desc

select Name 'Group Name', Rating 'Group Rating'
from Groups

select CONCAT(Surname, ': ', Salary / Premium * 100, ' / ' ,Salary / (Salary + Premium) * 100)
from Teachers

select CONCAT('The dean of faculty ', Name, ' is ', Dean)
from Faculties

select Surname
from Teachers
where IsProfessor = 1 and Salary > 1050

select Name
from Departments
where Financing < 11000 or Financing > 25000

select Name
from Faculties
where not (Name = 'Computer Science')

select Surname, Position
from Teachers
where IsProfessor = 0

select Surname, Position, Salary, Premium
from Teachers
where IsAssistant = 1 and Premium >= 160 and Premium <= 550

select Surname, Salary
from Teachers
where IsAssistant = 1

select Surname, Position
from Teachers
where (EmploymentDate < '2000-01-01')

select Name 'Name of Department'
from Departments
where Name < 'S'

select Surname
from Teachers
where IsAssistant = 1 and (Salary + Premium) <= 1200

select Name
from Groups
where Year = 5 and (Rating >= 2 and Rating <= 4)

select Surname
from Teachers
where IsAssistant = 1 and (Salary < 550 or Premium < 200)

