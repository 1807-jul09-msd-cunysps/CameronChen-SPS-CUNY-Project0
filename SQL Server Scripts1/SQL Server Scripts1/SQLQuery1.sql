Create Table Customers(
ID int,
FirstName varchar(255) NOT NULL,
LastName varchar(255) NOT NULL,
CardNumber varchar(255),
PRIMARY KEY (ID)
);
CREATE TABLE Products(
ID int NOT NULL,
ProductName varchar(255) NOT NULL,
Price int,
PRIMARY KEY (ID)
);
CREATE TABLE Orders(
ID int,
ProductID int,
CustomerID int,
PRIMARY KEY (ID),
FOREIGN KEY (ProductID) REFERENCES Products(ID),
FOREIGN KEY (CustomerID) REFERENCES Customers(ID)
);

INSERT INTO Customers (ID, FirstName, LastName, CardNumber)
VALUES (1, 'Tina', 'Smith', '1111222233334444');
INSERT INTO Customers (ID, FirstName, LastName, CardNumber)
VALUES (2, 'Harry', 'Cortes', '2222333344445555');
INSERT INTO Customers (ID, FirstName, LastName, CardNumber)
VALUES (3, 'Russel', 'Chin', '3333444455556666');

INSERT INTO Products (ID, ProductName, Price)
VALUES (1, 'iPhone', $200);
INSERT INTO Products (ID, ProductName, Price)
VALUES (2, 'Android', $150);
INSERT INTO Products (ID, ProductName, Price)
VALUES (3, 'Window', $100);

INSERT INTO Orders (ID, ProductID, CustomerID)
VALUES (1, 3, 1);
INSERT INTO Orders (ID, ProductID, CustomerID)
VALUES (2, 2, 2);
INSERT INTO Orders (ID, ProductID, CustomerID)
VALUES (3, 1, 3);
INSERT INTO Orders (ID, ProductID, CustomerID)
VALUES (4, 1, 3);

SELECT * FROM Orders
WHERE (CustomerID = (SELECT CustomerID FROM Customers WHERE
FirstName = 'Tina'));

SELECT SUM(Price) FROM Products INNER JOIN Orders ON Orders.ProductID = Products.ID
WHERE ProductName = 'iPhone';

SELECT * FROM Products;
SELECT * FROM Customers;
SELECT * FROM Orders;

UPDATE Products 
SET Price = $250
WHERE Price = 200;