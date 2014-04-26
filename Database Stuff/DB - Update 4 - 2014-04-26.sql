CREATE TABLE `nsa_database`.`combodrinkmenuid` (
  `storeid` INT NOT NULL,
  `menuitemid` INT NOT NULL,
  `discountamount` FLOAT NULL DEFAULT 1.00,
  PRIMARY KEY (`storeid`));
  
INSERT INTO `nsa_database`.`menuitem` (`storeid`, `name`, `cost`, `price`, `isspecial`, `menutypeid`, `deleted`, `imagefilename`) VALUES ('1', 'discount', '0', '0', '0', '0', '0', 'blank.png');