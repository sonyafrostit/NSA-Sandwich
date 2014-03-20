ALTER TABLE `nsa-database`.`menuitem` 
ADD COLUMN `imagefilename` VARCHAR(255) NULL DEFAULT 'blank.png' AFTER `deleted`;

ALTER TABLE `nsa-database`.`orderitems` 
CHANGE COLUMN `orderitemid` `orderitemid` INT(11) NOT NULL AUTO_INCREMENT ;

ALTER TABLE `nsa-database`.`orders` 
CHANGE COLUMN `orderid` `orderid` INT(11) NOT NULL AUTO_INCREMENT ;

ALTER TABLE `nsa-database`.`menuitem` 
CHANGE COLUMN `menuitemid` `menuitemid` INT(11) NOT NULL AUTO_INCREMENT ;

ALTER TABLE `nsa-database`.`favoriteitems` 
CHANGE COLUMN `favoriteitemid` `favoriteitemid` INT(11) NOT NULL AUTO_INCREMENT ;

ALTER TABLE `nsa-database`.`managers` 
CHANGE COLUMN `managerid` `managerid` INT(11) NOT NULL AUTO_INCREMENT ;

ALTER TABLE `nsa-database`.`stores` 
CHANGE COLUMN `storeid` `storeid` INT(11) NOT NULL AUTO_INCREMENT COMMENT 'this is a zero padded integer 0001 to 9999 ' ;

ALTER TABLE `nsa-database`.`components` 
CHANGE COLUMN `componentid` `componentid` INT(11) NOT NULL AUTO_INCREMENT ;

ALTER TABLE `nsa-database`.`menuitemcomponents` 
DROP PRIMARY KEY,
ADD PRIMARY KEY (`menuitemid`, `storeid`, `component`);

ALTER TABLE `nsa-database`.`orderitemcomponents` 
DROP PRIMARY KEY,
ADD PRIMARY KEY (`orderitemid`, `storeid`, `component`);

ALTER TABLE `nsa-database`.`orderitemremoved` 
DROP PRIMARY KEY,
ADD PRIMARY KEY (`orderitemid`, `storeid`, `componentremoved`);

ALTER TABLE `nsa-database`.`orderitems` 
ADD COLUMN `refunded` TINYINT NULL DEFAULT 0 AFTER `price`;



