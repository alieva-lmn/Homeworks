use [University]

create table Curators -- +
(
    ID int identity (1, 1) primary key NOT NULL,
    Name nvarchar(max) NOT NULL check(len(Name) > 0),
    Surname nvarchar(max) NOT NULL check(len(Surname) > 0)
);

create table Departments -- +
(
    ID int identity (1, 1) primary key NOT NULL,
    Building int NOT NULL check(Building between 1 and 5),
    Financing money NOT NULL check(Financing >= 0) default 0,
    Name nvarchar(100) NOT NULL UNIQUE check(len(Name) > 0),
    FacultyId int NOT NULL foreign key references Faculties(ID)
);

create table Faculties -- +
(
    ID int identity (1, 1) primary key NOT NULL,
    Name nvarchar(100) NOT NULL UNIQUE check(len(Name) > 0)
);

create table Groups -- +
(
    ID int identity (1, 1) primary key NOT NULL,
    Name nvarchar(10) NOT NULL UNIQUE check(len(Name) > 0),
    Year int NOT NULL check(Year between 1 and 5),
    DepartmentId int NOT NULL foreign key references Departments(ID)
);

create table GroupsCurators -- +
(
    ID int identity (1, 1) primary key NOT NULL,
    CuratorId int NOT NULL foreign key references Curators(ID),
    GroupId int NOT NULL foreign key references Groups(ID)
);

create table GroupsLectures -- +
(
    ID int identity (1, 1) primary key NOT NULL,
    GroupId int NOT NULL foreign key references Groups(ID),
    LectureId int NOT NULL foreign key references Lectures(ID),
);

create table GroupsStudents -- +
(
    ID int identity (1, 1) primary key NOT NULL,
    GroupId int NOT NULL foreign key references Groups(ID),
    StudentId int NOT NULL foreign key references Students(ID),
);

create table Lectures -- +
(
    ID int identity (1, 1) primary key NOT NULL,
    Date date NOT NULL check(date <= getdate()),
    SubjectId int NOT NULL foreign key references Subjects(ID),
    TeacherId int NOT NULL foreign key references Teachers(ID)
);

create table Students -- +
(
    ID int identity (1, 1) primary key NOT NULL,
    Name nvarchar(max) NOT NULL check(len(Name) > 0),
    Rating int NOT NULL CHECK(Rating between 0 and 5),
    Surname nvarchar(max) NOT NULL check(len(Surname) > 0),
);

create table Subjects -- +
(
    ID int identity (1, 1) primary key NOT NULL,
    Name nvarchar(100) NOT NULL UNIQUE check(len(Name) > 0)
);

create table Teachers -- +
(
    ID int identity (1, 1) primary key NOT NULL,
    IsProfessor bit NOT NULL default 0,
    Name nvarchar(max) NOT NULL check(len(Name) > 0),
    Salary money NOT NULL check(Salary > 0),
    Surname nvarchar(max) NOT NULL check(len(Surname) > 0)
);


select *
from sys.tables

insert into Curators values('Levi', 'Ackerman') -- +
insert into Curators values('Reiner', 'Braun')
insert into Curators values('Annie', 'Leonhart')

insert into Departments values(2, 120000, 'Computer Science', 1) -- +
insert into Departments values(5, 100100, 'Software Development', 2)
insert into Departments values(1, 60000, 'Psychology', 3)

insert into Faculties values('Computer Science') -- +
insert into Faculties values('Software Development')
insert into Faculties values('CAD')

insert into Groups values('D221', 2, 5) -- +
insert into Groups values('D228', 1, 4)
insert into Groups values('D222', 3, 6)

insert into GroupsCurators values(1, 11) -- +
insert into GroupsCurators values(2, 10)
insert into GroupsCurators values(3, 12)

insert into GroupsLectures values(10, 4) -- +
insert into GroupsLectures values(11, 5)
insert into GroupsLectures values(12, 6)

insert into GroupsStudents values(10, 3) -- +
insert into GroupsStudents values(12, 2)
insert into GroupsStudents values(11, 1)

insert into Lectures values('2023-01-22', 1, 2) -- +
insert into Lectures values('2023-03-18', 2, 3)
insert into Lectures values('2023-02-12', 3, 1)
insert into Lectures values('2023-02-12', 1, 1)
insert into Lectures values('2023-02-12', 3, 1)
insert into Lectures values('2023-02-12', 3, 1)

insert into Students values('Shouta', 2, 'Kazehaya') -- +
insert into Students values('Sawako', 5, 'Kuronuma')
insert into Students values('Takashi', 1, 'Natsume')

insert into Subjects values('Math') -- +
insert into Subjects values('Autocad')
insert into Subjects values('ITE')

insert into Teachers values(0, 'Edward', 3600, 'Hopper') -- +
insert into Teachers values(0, 'Alex', 2500, 'Carmack')
insert into Teachers values(1, 'Erwin', 7200, 'Smith')



-- 1

select Building
from Departments
group by Building
having sum(Departments.Financing) > 100000

-- 2

select Groups.Name
from Groups
inner join Departments
on Groups.DepartmentId = Departments.ID
where Groups.Year = 5 and Departments.Name = 'Software Development'

-- 3

select Groups.Name
from GroupsStudents
inner join Groups
on GroupsStudents.GroupId = Groups.ID
inner join Students
on GroupsStudents.StudentId = Students.ID
group by Groups.Name
having avg(Students.Rating) > (select avg(Students.Rating) from GroupsStudents
                                inner join Groups
                                on GroupsStudents.GroupId = Groups.ID
                                inner join Students
                                on GroupsStudents.StudentId = Students.ID
                                where Groups.Name = 'D221')

-- 4

select Teachers.Name, Teachers.Surname
from Teachers
where Teachers.Salary > (select avg(Teachers.Salary) from Teachers where Teachers.IsProfessor = 1)

-- 5

select Groups.Name
from GroupsCurators
inner join Groups
on GroupsCurators.GroupId = Groups.ID
inner join Curators
on GroupsCurators.CuratorId = Curators.ID
group by Groups.Name
having (count(Curators.ID) > 1)

-- 6

select top 1 Groups.Name
from GroupsStudents
inner join Groups
on GroupsStudents.GroupId = Groups.ID
inner join Students
on GroupsStudents.StudentId = Students.ID
group by Groups.Name
having avg(Students.Rating) < (select avg(Students.Rating) as rating from GroupsStudents
                                inner join Groups
                                on GroupsStudents.GroupId = Groups.ID
                                inner join Students
                                on GroupsStudents.StudentId = Students.ID
                                where Groups.Year = 5)
                                order by avg(Students.Rating)

-- 7

select Faculties.Name
from Departments
inner join Faculties
on Departments.FacultyId = Faculties.ID
group by Faculties.Name
having sum(Departments.Financing) > (select sum(Departments.Financing) from Departments
                                inner join Faculties
                                on Departments.FacultyId = Faculties.ID
                                where Faculties.Name = 'Computer Science')

-- 8

select Teachers.Name, Teachers.Surname, Subjects.Name, count(*) as 'Number of Lectures'
from Lectures
inner join Teachers
on Lectures.TeacherId = Teachers.ID
inner join Subjects
on Lectures.SubjectId = Subjects.ID
group by Subjects.Name, Teachers.Name, Teachers.Surname

-- 9

select min(Subjects.Name)
from Lectures
inner join Subjects
on Lectures.SubjectId = Subjects.ID

-- 10

select count(GroupsLectures.LectureId) as 'Number of Students', count(Lectures.SubjectId) as 'Number of Subjects'
from GroupsStudents
inner join Students
on GroupsStudents.StudentId = Students.ID
inner join GroupsLectures
on GroupsStudents.GroupId = GroupsLectures.GroupId
inner join Lectures
on GroupsLectures.LectureId = Lectures.ID
inner join Groups
on GroupsStudents.GroupId = Groups.ID
inner join Departments
on Groups.DepartmentId = Departments.ID
where Departments.Name = 'Software Development'