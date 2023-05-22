use [BarberShop]

CREATE TABLE Barbers
(
  BarberID INT IDENTITY (1, 1) PRIMARY KEY NOT NULL,
  FullName NVARCHAR(100) NOT NULL CHECK(len(FullName) > 0),
  Gender NVARCHAR(10) NOT NULL,
  ContactPhone NVARCHAR(20) NOT NULL,
  Email NVARCHAR(100) NOT NULL,
  DateOfBirth DATE NOT NULL,
  HireDate DATE NOT NULL,
  Position NVARCHAR(50) NOT NULL
);

CREATE TABLE Services
(
  ServiceID INT IDENTITY (1, 1) PRIMARY KEY NOT NULL,
  ServiceName NVARCHAR(100) NOT NULL CHECK(len(ServiceName) > 0),
  Price DECIMAL(10, 2) NOT NULL,
  Duration INT NOT NULL
);

CREATE TABLE BarberServices
(
  BarberServiceID INT IDENTITY (1, 1) PRIMARY KEY NOT NULL,
  BarberID INT NOT NULL FOREIGN KEY REFERENCES Barbers(BarberID),
  ServiceID INT NOT NULL FOREIGN KEY REFERENCES Services(ServiceID)
);

CREATE TABLE Feedbacks
(
  FeedbackID INT IDENTITY (1, 1) PRIMARY KEY NOT NULL,
  BarberID INT NOT NULL FOREIGN KEY REFERENCES Barbers(BarberID),
  ClientID INT NOT NULL FOREIGN KEY REFERENCES Clients(ClientID),
  Rating NVARCHAR(20) NOT NULL,
  Comment NVARCHAR(255) NOT NULL
);

CREATE TABLE Clients
(
  ClientID INT IDENTITY (1, 1) PRIMARY KEY NOT NULL,
  FullName NVARCHAR(100) NOT NULL CHECK(len(FullName) > 0),
  ContactPhone NVARCHAR(20) NOT NULL ,
  Email NVARCHAR(100) NOT NULL
);

CREATE TABLE ClientFeedbacks
(
  FeedbackID INT IDENTITY (1, 1) PRIMARY KEY NOT NULL,
  ClientID INT NOT NULL FOREIGN KEY REFERENCES Clients(ClientID),
  BarberID INT NOT NULL FOREIGN KEY REFERENCES Barbers(BarberID),
  Rating NVARCHAR(20) NOT NULL,
  Comment NVARCHAR(255) NOT NULL
);

CREATE TABLE Appointments
(
  AppointmentID INT IDENTITY (1, 1) PRIMARY KEY NOT NULL,
  BarberID INT NOT NULL FOREIGN KEY REFERENCES Barbers(BarberID),
  ClientID INT NOT NULL FOREIGN KEY REFERENCES Clients(ClientID),
  ServiceID INT NOT NULL FOREIGN KEY REFERENCES Services(ServiceID),
  Date DATE NOT NULL,
  StartTime TIME NOT NULL,
  EndTime TIME NOT NULL
);

CREATE TABLE VisitHistory
(
  VisitID INT IDENTITY (1, 1) PRIMARY KEY NOT NULL,
  ClientID INT NOT NULL FOREIGN KEY REFERENCES Clients(ClientID),
  BarberID INT NOT NULL FOREIGN KEY REFERENCES Barbers(BarberID),
  ServiceID INT NOT NULL FOREIGN KEY REFERENCES Services(ServiceID),
  Date DATE NOT NULL,
  TotalCost DECIMAL(10, 2) NOT NULL ,
  Rating NVARCHAR(20) NOT NULL,
  Comment NVARCHAR(255) NOT NULL
);


INSERT INTO Barbers (FullName, Gender, ContactPhone, Email, DateOfBirth, HireDate, Position)
VALUES
  ('Annie Leonhart', 'F', '1234567890', 'annie@example.com', '1980-01-01', '2020-01-01', 'Rookie Barber'),
  ('Levi Ackerman', 'M', '9876543210', 'levi@example.com', '1985-02-02', '2022-01-01', 'Senior Barber'),
  ('Reiner Braun', 'M', '5678901234', 'reiner@example.com', '1990-03-03', '2021-01-01', 'Junior Barber');


INSERT INTO Services (ServiceName, Price, Duration)
VALUES
  ('Hair coloring', 500, 60),
  ('Straight razor shave', 300, 30),
  ('Beard Grooming', 400, 45);


INSERT INTO BarberServices (BarberID, ServiceID)
VALUES
  (1, 1),
  (2, 1),
  (2, 2),
  (3, 1),
  (3, 3);


INSERT INTO Clients (FullName, ContactPhone, Email)
VALUES
  ('Erwin Smith', '0987654321', 'erwin@example.com'),
  ('Jean Kirstein', '4567890123', 'jean@example.com'),
  ('Historia Reiss', '9876543210', 'historia@example.com');


INSERT INTO Appointments (BarberID, ClientID, ServiceID, Date, StartTime, EndTime)
VALUES
  (1, 1, 1, '2023-05-17', '10:00:00', '11:00:00'),
  (2, 2, 2, '2023-05-17', '14:30:00', '15:00:00'),
  (3, 3, 3, '2023-05-18', '11:30:00', '12:15:00');


INSERT INTO VisitHistory (ClientID, BarberID, ServiceID, Date, TotalCost, Rating, Comment)
VALUES
  (1, 1, 1, '2023-05-17', 500, 'Bad', 'Bad haircut'),
  (2, 2, 2, '2023-05-17', 300, 'Good', 'Good beard grooming'),
  (3, 3, 3, '2023-05-18', 400, 'Excellent', 'Excellent hair coloring');


-- TASK 1

-- 1

SELECT TOP 1 *
FROM Barbers
ORDER BY HireDate ASC;

-- 2

CREATE FUNCTION dbo.GetTopBarberByClients
    (@StartDate DATE, @EndDate DATE)
RETURNS TABLE
AS
RETURN
    (SELECT TOP 1 b.BarberID, b.FullName, COUNT(*) AS TotalClients
    FROM Barbers b
    INNER JOIN Appointments a ON b.BarberID = a.BarberID
    WHERE a.Date >= @StartDate AND a.Date <= @EndDate
    GROUP BY b.BarberID, b.FullName
    ORDER BY TotalClients DESC);

DECLARE @StartDate DATE = '2023-05-17';
DECLARE @EndDate DATE = '2023-06-17';

SELECT *
FROM dbo.GetTopBarberByClients(@StartDate, @EndDate);


-- 3

CREATE FUNCTION dbo.TopClient()
RETURNS TABLE
AS
RETURN
    (SELECT TOP 1 Clients.FullName, MAX(Appointments.ClientID) AS Total
    FROM Clients
    INNER JOIN Appointments ON Clients.ClientID = Appointments.ClientID
    GROUP BY Clients.FullName
    ORDER BY Total DESC);

SELECT *
FROM dbo.TopClient()

-- 4

CREATE FUNCTION dbo.GetRichestClient()
RETURNS TABLE
AS
RETURN
    (SELECT TOP 1 Clients.FullName, SUM(VisitHistory.TotalCost) AS Total
    FROM Clients
    INNER JOIN VisitHistory on Clients.ClientID = VisitHistory.ClientID
    GROUP BY Clients.FullName
    ORDER BY Total DESC);

SELECT *
FROM dbo.GetRichestClient()

-- 5

CREATE FUNCTION dbo.GetLongestProcedure()
RETURNS TABLE
AS
RETURN
    (SELECT TOP 1 Services.ServiceName, Services.Duration
    FROM Services
    ORDER BY Services.Duration DESC)

SELECT *
FROM dbo.GetLongestProcedure()


-- TASK 2

CREATE FUNCTION dbo.GetTheMostPopularBarber()
RETURNS TABLE
AS
RETURN
    (SELECT TOP 1 Barbers.FullName, COUNT(VisitHistory.ClientID) as CountOfClients
     FROM Barbers
     INNER JOIN VisitHistory on Barbers.BarberID = VisitHistory.BarberID
     GROUP BY Barbers.FullName
     ORDER BY CountOfClients DESC)

SELECT *
FROM dbo.GetTheMostPopularBarber()


CREATE FUNCTION dbo.GetTop3BarberLastMonth()
RETURNS TABLE
AS
RETURN
    (SELECT TOP 3 Barbers.FullName, SUM(VisitHistory.TotalCost) as TotalCost
     FROM Barbers
     INNER JOIN VisitHistory on Barbers.BarberID = VisitHistory.BarberID
     GROUP BY Barbers.FullName
     ORDER BY TotalCost DESC)

SELECT *
FROM dbo.GetTop3BarberLastMonth()


CREATE FUNCTION dbo.GetTop3OfAllTime()
RETURNS TABLE
AS
RETURN
    (SELECT TOP 3 Barbers.FullName
     FROM Barbers
     INNER JOIN VisitHistory on Barbers.BarberID = VisitHistory.BarberID
     GROUP BY Barbers.FullName)

SELECT *
FROM dbo.GetTop3OfAllTime()


CREATE TRIGGER PreventJuniorBarberInsert
ON Barbers
FOR INSERT
AS
BEGIN
    DECLARE @JuniorBarberCount INT;

    SELECT @JuniorBarberCount = COUNT(*)
    FROM Barbers
    WHERE Position = 'Junior Barber';

    IF @JuniorBarberCount >= 5
    BEGIN
        RAISERROR ('There are more than 5 Junior Barbers', 16, 1);
    END
END

SELECT COUNT(*)
FROM Barbers

INSERT INTO Barbers values('Bertholdt Hoover', 'M', '0504086427', 'berutoto@example.com', '1922-10-11', '2019-02-24', 'Junior Barber');


CREATE FUNCTION dbo.GetClientWithNoFeedback()
RETURNS TABLE
AS
RETURN
    SELECT Clients.ClientID, Clients.FullName, Clients.ContactPhone, Clients.Email
    FROM Clients
    LEFT JOIN Feedbacks ON Clients.ClientID = Feedbacks.ClientID
    LEFT JOIN ClientFeedbacks ON Clients.ClientID = ClientFeedbacks.ClientID
    WHERE Feedbacks.FeedbackID IS NULL AND ClientFeedbacks.Rating IS NULL;

SELECT *
FROM dbo.GetClientWithNoFeedback()


CREATE FUNCTION dbo.GetClient()
RETURNS TABLE
AS
RETURN
    SELECT Clients.ClientID, Clients.FullName, Clients.ContactPhone, Clients.Email
    FROM Clients
    LEFT JOIN Appointments ON Clients.ClientID = Appointments.ClientID
    WHERE DATEDIFF(YEAR, Appointments.Date, GETDATE()) > 1 OR Appointments.Date IS NULL;

SELECT *
FROM dbo.GetClient()




