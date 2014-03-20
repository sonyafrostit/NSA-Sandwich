USE `nsa-database`;

DELETE FROM `nsa-database`.`componentcategories` WHERE `categoryid`='0';
DELETE FROM `nsa-database`.`componentcategories` WHERE `categoryid`='1';
DELETE FROM `nsa-database`.`componentcategories` WHERE `categoryid`='2';
DELETE FROM `nsa-database`.`componentcategories` WHERE `categoryid`='3';
DELETE FROM `nsa-database`.`componentcategories` WHERE `categoryid`='4';
DELETE FROM `nsa-database`.`componentcategories` WHERE `categoryid`='5';


INSERT INTO `componentcategories` (`categoryid`, `categoryname`) VALUES (0,'Unassigned'),(1,'Bread'),(2,'Meat'),(3,'Cheese'),(4,'Vegetables'),(5,'Condiments');

INSERT INTO `components` (`componentid`, `storeid`, `name`, `cost`, `price`, `categoryid`, `quantity`, `lowquantity`, `deleted`) VALUES (1,1,'Rye',0.5,1,1,1000,50,0),(2,1,'Corned Beef',1,2,2,1000,50,0),(3,1,'Swiss',0.5,1,3,1000,50,0),(4,1,'Sauerkraut',0.25,1,4,400,25,0),(5,1,'Russian Dressing',0.05,0.5,5,500,10,0),(6,1,'White',0.25,0.5,1,500,100,0),(7,1,'Wheat',0.3,0.5,1,100,50,0),(8,1,'Peanut Butter',0.5,1,5,1000,25,0),(9,1,'Grape Jelly',0.5,1,5,75,25,0),(10,1,'Orange Marmalade',0.5,1,5,50,5,0);

INSERT INTO `menuitem` (`menuitemid`, `storeid`, `name`, `cost`, `price`, `isspecial`, `menutypeid`, `deleted`, `imagefilename`) VALUES (0,1,'Custom',7.5,9.99,0,1,0,'blank.png'),(1,1,'Ruben',5,9.99,0,1,0,'blank.png'),(2,1,'PBJ',2.5,9.99,0,1,0,'blank.png');

INSERT INTO `menuitemcomponents` (`menuitemid`, `storeid`, `component`) VALUES (1,1,1),(1,1,2),(1,1,3),(1,1,4),(1,1,5),(2,1,6),(2,1,8),(2,1,9);

INSERT INTO `menutypes` (`menutypeid`, `name`) VALUES (0,'Unassigned'),(1,'Sandwich'),(2,'Salad'),(3,'Drinks'),(4,'Deserts'),(5,'Sides');

INSERT INTO `orderitemcomponents` (`orderitemid`, `storeid`, `component`) VALUES (3,1,3),(3,1,6),(3,1,10),(5,1,1),(5,1,9),(5,1,10),(6,1,2),(6,1,5),(6,1,7);

INSERT INTO `orderitemremoved` (`orderitemid`, `storeid`, `componentremoved`) VALUES (1,1,4),(1,1,5),(4,1,8),(7,1,9);

INSERT INTO `orderitems` (`orderitemid`, `storeid`, `orderid`, `menuitemid`, `name`, `price`, `refunded`) VALUES (1,1,1,1,'Ruben',9.99,0),(2,1,1,2,'PBJ',9.99,0),(3,1,2,0,'Custom',9.99,0),(4,1,3,2,'PBJ',9.99,0),(5,1,3,0,'Custom',9.99,0),(6,1,4,0,'Custom',9.99,0),(7,1,4,2,'PBJ',9.99,0);

INSERT INTO `orders` (`orderid`, `storeid`, `loyaltyid`, `status`, `timeplaced`, `timedelivered`, `total`, `tax`, `refunded`) VALUES (1,1,0,2,'2014-03-15 03:30:00','2014-03-15 03:35:00',10,'0.75',0),(2,1,0,2,'2014-03-15 03:31:00','2014-03-15 03:37:00',15,'1',0),(3,1,0,2,'2014-04-15 04:30:00','2014-04-15 04:38:00',20,'1.5',0),(4,1,0,2,'2014-04-15 04:30:31','2014-04-15 04:34:00',10,'0.75',0),(5,1,0,1,'2014-05-15 05:30:00',NULL,10,'0.75',0),(6,1,0,1,'2014-05-15 05:31:00',NULL,15,'1',0),(7,1,0,1,'2014-05-15 05:32:00',NULL,20,'1.5',0),(8,1,0,1,'2014-05-15 05:32:31',NULL,10,'0.75',0);

INSERT INTO `stores` (`storeid`, `name`, `address`, `city`, `state`, `zip`) VALUES (1,'Denton','1234 ELM','Denton','Tx','76201');
