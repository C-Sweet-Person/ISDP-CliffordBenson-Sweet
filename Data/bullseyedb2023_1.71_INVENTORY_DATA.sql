--
-- Insert data for table `inventory`
-- Needs to drop Inventory table, recreate without constraints,
-- insert inventory items, then recreate the constraints
--

use bullseyedb2023;

DROP TABLE IF EXISTS `inventory`;

CREATE TABLE `inventory` (
    `itemID` INT(11),
    `siteID` INT(11) DEFAULT NULL,
    `quantity` INT(11),
    `itemLocation` VARCHAR(20),
    `reorderThreshold` INT(11)
); 

-- Warehouse
insert into `inventory` (itemID) select itemID from item;
UPDATE `inventory`
SET siteID = 1, quantity = 25, itemLocation = 'Stock', reorderThreshold = 25
WHERE siteID is null;

-- Saint John
insert into `inventory` (itemID) select itemID from item;
UPDATE `inventory`
SET siteID = 4, quantity = 5, itemLocation = 'Shelf', reorderThreshold = 5
WHERE siteID is null;

-- Sussex
insert into `inventory` (itemID) select itemID from item;
UPDATE `inventory`
SET siteID = 5, quantity = 5, itemLocation = 'Shelf', reorderThreshold = 5
WHERE siteID is null;

-- Moncton
insert into `inventory` (itemID) select itemID from item;
UPDATE `inventory`
SET siteID = 6, quantity = 5, itemLocation = 'Shelf', reorderThreshold = 5
WHERE siteID is null;

-- Dieppe
insert into `inventory` (itemID) select itemID from item;
UPDATE `inventory`
SET siteID = 7, quantity = 5, itemLocation = 'Shelf', reorderThreshold = 5
WHERE siteID is null;

-- Oromocto
insert into `inventory` (itemID) select itemID from item;
UPDATE `inventory`
SET siteID = 8, quantity = 5, itemLocation = 'Shelf', reorderThreshold = 5
WHERE siteID is null;

-- Fredericton
insert into `inventory` (itemID) select itemID from item;
UPDATE `inventory`
SET siteID = 9, quantity = 5, itemLocation = 'Shelf', reorderThreshold = 5
WHERE siteID is null;

-- Miramichi
insert into `inventory` (itemID) select itemID from item;
UPDATE `inventory`
SET siteID = 10, quantity = 5, itemLocation = 'Shelf', reorderThreshold = 5
WHERE siteID is null;

ALTER TABLE `inventory` 
ADD FOREIGN KEY (siteID) REFERENCES `site` (`siteID`);

ALTER TABLE `inventory`
ADD FOREIGN KEY (itemID) REFERENCES `item` (`itemID`);

ALTER TABLE `inventory`
ADD PRIMARY KEY (itemID, siteID);
