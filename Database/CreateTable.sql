CREATE DATABASE CoffeeManager
GO

USE CoffeeManager
GO

--Food
--Table
--FoodCategory
--Account
--Bill
--BillInfo

CREATE TABLE TableFood
(
    id INT IDENTITY PRIMARY KEY,
    name NVARCHAR(100) DEFAULT N'Chưa có tên',
    status NVARCHAR(100) DEFAULT N'Trống',  -- Trống | Có người

)
GO

CREATE TABLE Account
(
    UserName NVARCHAR(100) PRIMARY KEY not NULL,
    DisplayName NVARCHAR(100) not NULL DEFAULT N'Son',
    PassWord NVARCHAR(1000) not NULL DEFAULT 0,
    Type INT not NULL DEFAULT 0 --1: admin --0:staff
)
GO

CREATE TABLE FoodCategory
(
    id INT IDENTITY PRIMARY KEY,
    name NVARCHAR(100) DEFAULT N'Chưa đặt tên',
)
GO

CREATE TABLE Food
(
    id INT IDENTITY PRIMARY KEY,
    name NVARCHAR(100) DEFAULT N'Chưa đặt tên',
    idCategory INT not NULL,
    price FLOAT not NULL,
    FOREIGN KEY (idCategory) REFERENCES FoodCategory(id)
)
GO

CREATE TABLE Bill
(
    id INT IDENTITY PRIMARY KEY,
    DayCheckIn DATE not NULL DEFAULT GETDATE(),
    DayCheckOut DATE,
    idTable INT not NULL,
    status INT not NULL DEFAULT 0, --1: Đã thanh toán && 0: Chưa thanh toán
    FOREIGN KEY (idTable) REFERENCES TableFood(id)
)
GO

CREATE TABLE BillInfo
(
    id INT IDENTITY PRIMARY KEY,
    idBill INT not NULL,
    idFood INT not NULL,
    count INT not NULL DEFAULT 0,
    FOREIGN KEY (idBill) REFERENCES Bill(id),
    FOREIGN KEY (idFood) REFERENCES Food(id)
)
GO

INSERT INTO Account 
        (
            UserName,
            DisplayName,
            PassWord,
            Type
        )
VALUES  ( N'K9',
          N'RongK9',
          N'1',
          1
        )

INSERT INTO Account 
        (
            UserName,
            DisplayName,
            PassWord,
            Type
        )
VALUES  ( N'staff',
          N'staff',
          N'1',
          0
        )
GO

SELECT * FROM Account

CREATE PROC USP_GetListAccountByUserName
@userName nvarchar(100)
AS
BEGIN
    SELECT * FROM Account WHERE Username = @userName
END
GO

EXEC USP_GetListAccountByUserName @userName = N'K9'

SELECT * FROM Account WHERE UserName = N'K9' AND PassWord = N'1'
GO

CREATE PROC USP_Login
@userName nvarchar(100), @passWord nvarchar(100)
AS
BEGIN
	SELECT * FROM Account WHERE  UserName = @userName AND PassWord = @passWord
END
GO

DECLARE @i INT = 0
WHILE @i < 21
BEGIN
    INSERT TableFood(name) VALUES (N'Bàn ' + CAST(@i AS nvarchar(100)))
	-- UPDATE TableFood SET STATUS = N'Trống' WHERE id = @i
    SET @i = @i + 1
END

INSERT TableFood(name, status)
VALUES (N'Bàn 1',
        N'Trống'
        )

INSERT TableFood(name, status)
VALUES (N'Bàn 1',
        N'Trống'
        )

SELECT * FROM TableFood

CREATE PROC USP_GetTableList
AS SELECT * FROM TableFood
GO 

CREATE PROC USP_GetBillInfo

UPDATE TableFood SET STATUS = N'Có người' WHERE id = 6

EXEC USP_GetTableList   

SELECT * FROM Bill
GO 
SELECT * FROM BillInfo

SELECT * FROM Food
SELECT * FROM FoodCategory
GO


USE CoffeeManager
GO
-- Category

INSERT FoodCategory (name) VALUES (N'Hải sản')
INSERT FoodCategory (name) VALUES (N'Nông sản')
INSERT FoodCategory (name) VALUES (N'Lâm sản')
INSERT FoodCategory (name) VALUES (N'Sản sản')
INSERT FoodCategory (name) VALUES (N'Nước')

-- Món ăn
INSERT Food (name, idCategory, price) VALUES (N'Mực một nắng nước sa tế', 1, 120000)
INSERT Food (name, idCategory, price) VALUES (N'Ngao hấp xả', 1, 50000)
INSERT Food (name, idCategory, price) VALUES (N'Dú dê nướng sữa', 2, 60000)
INSERT Food (name, idCategory, price) VALUES (N'Heo rừng nướng múi ớt', 3, 75000)
INSERT Food (name, idCategory, price) VALUES (N'Cơm chiên mushi', 4, 99999)
INSERT Food (name, idCategory, price) VALUES (N'Cafe', 5, 15000)
INSERT Food (name, idCategory, price) VALUES (N'7Up', 5, 12000)

-- bill
INSERT bill (DayCheckIn, DayCheckOut, idTable, status) VALUES(GETDATE(), NULL, 1, 0)
INSERT bill (DayCheckIn, DayCheckOut, idTable, status) VALUES(GETDATE(), NULL, 2, 0)
INSERT bill (DayCheckIn, DayCheckOut, idTable, status) VALUES(GETDATE(), NULL, 2, 1)

-- billInfo
INSERT BillInfo (idBill, idFood, count) VALUES (1, 1, 2)
INSERT BillInfo (idBill, idFood, count) VALUES (1, 3, 4)
INSERT BillInfo (idBill, idFood, count) VALUES (1, 5, 1)
INSERT BillInfo (idBill, idFood, count) VALUES (2, 1, 2)
INSERT BillInfo (idBill, idFood, count) VALUES (2, 6, 2)
INSERT BillInfo (idBill, idFood, count) VALUES (3, 5, 2)
GO


DECLARE @i INT = 0
WHILE @i < 21
BEGIN
    INSERT TableFood(name) VALUES (N'Bàn ' + CAST(@i AS nvarchar(100)))
	-- UPDATE TableFood SET STATUS = N'Trống' WHERE id = @i
    SET @i = @i + 1
END

DECLARE @i INT = 3
WHILE @i < 21
BEGIN
    INSERT bill (DayCheckIn, DayCheckOut, idTable, status) VALUES(GETDATE(), NULL, @i, 0)
	-- UPDATE TableFood SET STATUS = N'Trống' WHERE id = @i
    SET @i = @i + 1
END

USE CoffeeManager
GO

SELECT * FROM BillInfo where idBill = 2