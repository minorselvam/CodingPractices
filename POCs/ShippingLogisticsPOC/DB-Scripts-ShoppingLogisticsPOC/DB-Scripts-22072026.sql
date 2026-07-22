Use LogisticsPOC;

CREATE TABLE Products (
    ProductId INT PRIMARY KEY IDENTITY(1,1),
    Type NVARCHAR(100) NOT NULL,         -- e.g., TV, Mobile, WashingMachine
    Brand NVARCHAR(100) NOT NULL,        -- e.g., LG, Samsung, Bosch
    ProductName NVARCHAR(100) NOT NULL,  -- e.g., Samsung Ultra 2026 New, LG Ultravision
    Price DECIMAL(10,2) NOT NULL
);

-- Insert 5 product types, each with 4 products
INSERT INTO Products (Type, Brand, ProductName, Price)
VALUES
-- TVs
('TV', 'Sony', 'Sony Bravia 55"', 50000.00),
('TV', 'LG', 'LG Ultravision 65"', 45000.00),
('TV', 'Samsung', 'Samsung QLED 50"', 48000.00),
('TV', 'Panasonic', 'Panasonic SmartTV 42"', 40000.00),

-- Mobiles
('Mobile', 'Samsung', 'Samsung Galaxy Ultra 2026', 70000.00),
('Mobile', 'Apple', 'iPhone 16 Pro Max', 120000.00),
('Mobile', 'OnePlus', 'OnePlus 14 Pro', 65000.00),
('Mobile', 'Google', 'Pixel 9 XL', 80000.00),

-- Washing Machines
('WashingMachine', 'Bosch', 'Bosch Front Load 7kg', 35000.00),
('WashingMachine', 'LG', 'LG TurboWash 8kg', 32000.00),
('WashingMachine', 'Samsung', 'Samsung EcoBubble 9kg', 37000.00),
('WashingMachine', 'Whirlpool', 'Whirlpool FreshCare 7.5kg', 30000.00),

-- Laptops
('Laptop', 'Dell', 'Dell XPS 15', 140000.00),
('Laptop', 'HP', 'HP Spectre x360', 130000.00),
('Laptop', 'Lenovo', 'Lenovo ThinkPad X1 Carbon', 125000.00),
('Laptop', 'Apple', 'MacBook Pro 14"', 180000.00),

-- Refrigerators
('Refrigerator', 'Samsung', 'Samsung Family Hub 500L', 95000.00),
('Refrigerator', 'LG', 'LG InstaView 450L', 90000.00),
('Refrigerator', 'Whirlpool', 'Whirlpool Double Door 400L', 75000.00),
('Refrigerator', 'Bosch', 'Bosch FrostFree 420L', 88000.00);
