use [University]

select *
from sys.tables

-- 1

create function GetCuratorsCount()
returns int
as
    begin
        declare @count int = 0;
        set @count = (select count(*) from Curators);
        return @count;
    end

select dbo.GetCuratorsCount();

-- 2

create procedure ShowProfessor as
select Teachers.Name, Teachers.Surname
from Teachers
where Teachers.IsProfessor = 1;

exec ShowProfessor;

-- 3

create function GetFinancingOverall()
returns int
as
    begin
        declare @count money = 0;
        set @count = (select sum(Financing) from Departments);
        return @count;
    end

select dbo.GetFinancingOverall();

-- 4

create procedure ShowSalary as
select Teachers.Name, Teachers.Surname, Teachers.Salary
from Teachers
where Teachers.Name = 'Erwin'

exec ShowSalary;

-- 5

create function GetCuratorInfo(@name nvarchar(max))
returns table
as
    return
        (select * from Curators where Name = @name);

select * from GetCuratorInfo('Levi');