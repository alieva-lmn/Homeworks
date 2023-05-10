use [UpdatedAcademy]

create table Assistants -- +
(
    ID int identity (1, 1) primary key NOT NULL,
    TeacherId int NOT NULL foreign key references Teachers(ID)
);

create table Curators -- +
(
    ID int identity (1, 1) primary key NOT NULL,
    TeacherId int NOT NULL foreign key references Teachers(ID)
);

create table Deans -- +
(
    ID int identity (1, 1) primary key NOT NULL,
    TeacherId int NOT NULL foreign key references Teachers(ID)
);

create table Departments -- +
(
    ID int identity (1, 1) primary key NOT NULL,
    Building int NOT NULL check(Building between 1 and 5),
    Name nvarchar(100) NOT NULL UNIQUE,
    FacultyId int NOT NULL foreign key references Faculties(ID),
    HeadId int NOT NULL foreign key references Heads(ID)
);

create table Faculties -- +
(
    ID int identity (1, 1) primary key NOT NULL,
    Building int NOT NULL check(Building between 1 and 5),
    Name nvarchar(100) NOT NULL UNIQUE,
    DeanId int NOT NULL foreign key references Deans(ID)
);

create table Groups -- +
(
    ID int identity (1, 1) primary key NOT NULL,
    Name nvarchar(10) NOT NULL UNIQUE,
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

create table Heads -- +
(
    ID int identity (1, 1) primary key NOT NULL,
    TeacherId int NOT NULL foreign key references Teachers(ID)
);

create table LectureRooms -- +
(
    ID int identity (1, 1) primary key NOT NULL,
    Building int NOT NULL check(Building between 1 and 5),
    Name nvarchar(10) NOT NULL UNIQUE
);

create table Lectures -- +
(
    ID int identity (1, 1) primary key NOT NULL,
    SubjectId int NOT NULL foreign key references Subjects(ID),
    TeacherId int NOT NULL foreign key references Teachers(ID)
);

create table Schedules -- +
(
    ID int identity (1, 1) primary key NOT NULL,
    Class int NOT NULL check(Class between 1 and 8),
    DayOfWeek int NOT NULL check(DayOfWeek between 1 and 7),
    Week int NOT NULL check(Week between 1 and 52),
    LectureId int NOT NULL foreign key references Lectures(ID),
    LectureRoomId int NOT NULL foreign key references LectureRooms(ID),
);

create table Subjects -- +
(
    ID int identity (1, 1) primary key NOT NULL,
    Name nvarchar(100) NOT NULL UNIQUE
);

create table Teachers -- +
(
    ID int identity (1, 1) primary key NOT NULL,
    Name nvarchar(max) NOT NULL,
    Surname nvarchar(100) NOT NULL
);

select *
from sys.tables

insert into Assistants values(1) -- +
insert into Assistants values(2)
insert into Assistants values(3)

insert into Curators values(1) -- +
insert into Curators values(2)
insert into Curators values(3)

insert into Deans values(1) -- +
insert into Deans values(3)
insert into Deans values(2)

insert into Departments values(2, 'Dep1', 1, 2) -- +
insert into Departments values(5, 'Dep2', 2, 1)
insert into Departments values(1, 'Dep3', 3, 3)

insert into Faculties values(1, 'Computer Science', 1) -- +
insert into Faculties values(3, 'Software Development', 2)
insert into Faculties values(5, 'CAD', 3)

insert into Groups values('F505', 2, 8) -- +
insert into Groups values('F723', 1, 7)
insert into Groups values('F963', 3, 9)

insert into GroupsCurators values(1, 7) -- +
insert into GroupsCurators values(2, 8)
insert into GroupsCurators values(3, 9)

insert into GroupsLectures values(9, 5) -- +
insert into GroupsLectures values(8, 5)
insert into GroupsLectures values(7, 6)

insert into Heads values(2) -- +
insert into Heads values(1)
insert into Heads values(3)

insert into LectureRooms values(1, 'A311') -- +
insert into LectureRooms values(4, 'A104')
insert into LectureRooms values(2, 'A208')

insert into Lectures values(1, 2) -- +
insert into Lectures values(2, 3)
insert into Lectures values(3, 1)

insert into Schedules values(2, 1, 18, 4, 2) -- +
insert into Schedules values(8, 7, 32, 5, 2)
insert into Schedules values(1, 2, 12, 6, 1)

insert into Subjects values('Math') -- +
insert into Subjects values('Autocad')
insert into Subjects values('ITE')

insert into Teachers values('Edward', 'Hopper') -- +
insert into Teachers values('Alex', 'Carmack')
insert into Teachers values('Erwin', 'Smith')


select LectureRooms.Name
from Lectures
inner join Teachers
on Lectures.TeacherId = Teachers.ID
inner join Schedules
on Lectures.Id = Schedules.LectureId
inner join LectureRooms
on Schedules.LectureRoomId = LectureRooms.Id
where Teachers.Name = 'Edward' and Teachers.Surname = 'Hopper'


select Surname
from Teachers
inner join Assistants
on Teachers.ID = Assistants.TeacherId
inner join Lectures
on Teachers.ID = Lectures.TeacherId
inner join GroupsLectures
on Lectures.ID = GroupsLectures.LectureId
inner join Groups
on GroupsLectures.GroupId = Groups.ID
where Groups.Name = 'F505'


select Teachers.ID, Teachers.Name, Subjects.Name as 'Subject Name'
from Lectures
inner join Teachers
on Lectures.TeacherId = Teachers.ID
inner join Subjects
on Lectures.SubjectId = Subjects.ID
inner join GroupsLectures
on Lectures.ID = GroupsLectures.LectureId
inner join Groups
on GroupsLectures.GroupId = Groups.ID
where Teachers.Name = 'Alex' and Teachers.Surname = 'Carmack' and Groups.Year = 5


select Surname
from Teachers
inner join Groups
on Teachers.Name = Groups.Name
inner join GroupsLectures
on Groups.ID = GroupsLectures.ID
inner join Schedules
on GroupsLectures.LectureId = Schedules.LectureId
where Schedules.DayOfWeek != 1


select distinct LectureRooms.Name from Schedules
inner join LectureRooms
on LectureRooms.Id = Schedules.LectureRoomId
inner join Lectures
on Lectures.Id = Schedules.LectureId
inner join Teachers
on Teachers.Id = Lectures.TeacherId
where Schedules.DayOfWeek != 3 and Schedules.Week != 2 and Schedules.Class != 3


select Building
from Faculties
select Building from Faculties
union
select Building from Departments
union
select Building from LectureRooms


select Name, Surname
from Teachers
inner join Deans
on Teachers.Id = Deans.TeacherId
union all
select Name, Surname
from Teachers
inner join Heads
on Teachers.Id = Heads.TeacherId
union all
select Name, Surname
from Teachers
union all
select Name, Surname
from Teachers
inner join Curators
on Teachers.Id = Curators.TeacherId
union all
select Name, Surname
from Teachers
inner join Assistants
on Teachers.Id = Assistants.TeacherId


select DayOfWeek from Schedules
inner join LectureRooms
on LectureRooms.Id = Schedules.LectureRoomId
inner join Lectures
on Lectures.Id = Schedules.LectureId
where LectureRooms.Name = 'A311' or LectureRooms.Name = 'A104' and LectureRooms.Building = 6