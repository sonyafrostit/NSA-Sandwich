CREATE TABLE `nsa-database`.`kidsmealday` (
  `storeid` INT NOT NULL,
  `monday` VARCHAR(45) NULL DEFAULT 0,
  `tuesday` VARCHAR(45) NULL DEFAULT 0,
  `wednesday` VARCHAR(45) NULL DEFAULT 0,
  `thursday` VARCHAR(45) NULL DEFAULT 0,
  `friday` VARCHAR(45) NULL DEFAULT 0,
  `saturday` VARCHAR(45) NULL DEFAULT 0,
  `sunday` VARCHAR(45) NULL DEFAULT 0,
  PRIMARY KEY (`storeid`));
