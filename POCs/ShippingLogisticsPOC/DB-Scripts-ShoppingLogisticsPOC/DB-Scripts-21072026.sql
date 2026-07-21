Use LogisticsPOC;

-- Create Customer table
CREATE TABLE Customers (
    CustomerId INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    State NVARCHAR(50),
    Country NVARCHAR(50),
    ZipCode CHAR(6),
    Phone VARCHAR(12)
);

-- Alter Orders table to add foreign key to Customers
ALTER TABLE Orders
ADD CONSTRAINT FK_Orders_Customers
FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId);


ALTER TABLE Orders
DROP CONSTRAINT FK_Orders_Customers;


Drop table Customers 
