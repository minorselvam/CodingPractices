-- Step 1: Run this in the master database
CREATE DATABASE LogisticsPOC;

-- Step 2: Switch context to the new database
USE LogisticsPOC;

-- Step 3: Create Orders table
CREATE TABLE Orders (
    OrderId INT PRIMARY KEY IDENTITY(1,1),
    CustomerId INT NOT NULL,
    OrderDate DATETIME NOT NULL DEFAULT GETDATE(),
    TotalAmount DECIMAL(18,2) NOT NULL
);

-- Step 4: Create Payments table
CREATE TABLE Payments (
    PaymentId INT PRIMARY KEY IDENTITY(1,1),
    OrderId INT NOT NULL,
    Amount DECIMAL(18,2) NOT NULL,
    PaymentMethod NVARCHAR(50) NOT NULL,
    Status NVARCHAR(20) NOT NULL,
    CONSTRAINT FK_Payments_Orders FOREIGN KEY (OrderId)
        REFERENCES Orders(OrderId) ON DELETE CASCADE
);

-- Step 5: Create Shipments table
CREATE TABLE Shipments (
    ShipmentId INT PRIMARY KEY IDENTITY(1,1),
    OrderId INT NOT NULL,
    Carrier NVARCHAR(100) NOT NULL,
    TrackingNumber NVARCHAR(100) NOT NULL,
    Status NVARCHAR(20) NOT NULL,
    CONSTRAINT FK_Shipments_Orders FOREIGN KEY (OrderId)
        REFERENCES Orders(OrderId) ON DELETE CASCADE
);