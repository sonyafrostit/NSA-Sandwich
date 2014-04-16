ALTER TABLE `nsa_database`.`orderitems` 
ADD COLUMN `iscombo` VARCHAR(45) NULL DEFAULT 0 AFTER `refunded`;
