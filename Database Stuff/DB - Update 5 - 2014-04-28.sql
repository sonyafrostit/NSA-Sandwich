ALTER TABLE `nsa_database`.`favoriteitemcomponents` 
DROP PRIMARY KEY;

ALTER TABLE `nsa_database`.`favoriteitems` 
CHANGE COLUMN `name` `name` VARCHAR(45) NOT NULL ;
