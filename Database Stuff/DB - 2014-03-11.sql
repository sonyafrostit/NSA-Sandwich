CREATE DATABASE  IF NOT EXISTS `nsa_database` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `nsa_database`;
-- MySQL dump 10.13  Distrib 5.6.13, for Win32 (x86)
--
-- Host: 127.0.0.1    Database: nsa_database
-- ------------------------------------------------------
-- Server version	5.6.14

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `componentcategories`
--

DROP TABLE IF EXISTS `componentcategories`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `componentcategories` (
  `categoryid` int(11) NOT NULL,
  `categoryname` varchar(45) NOT NULL,
  PRIMARY KEY (`categoryid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='the categories remain the same ';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `componentcategories`
--

LOCK TABLES `componentcategories` WRITE;
/*!40000 ALTER TABLE `componentcategories` DISABLE KEYS */;
INSERT INTO `componentcategories` (`categoryid`, `categoryname`) VALUES (0,'Unassigned'),(1,'Meat'),(2,'Cheese'),(3,'Vegetables'),(4,'Condiments'),(5,'Bread');
/*!40000 ALTER TABLE `componentcategories` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `components`
--

DROP TABLE IF EXISTS `components`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `components` (
  `componentid` int(11) NOT NULL,
  `storeid` int(11) NOT NULL,
  `name` varchar(45) NOT NULL,
  `cost` float NOT NULL DEFAULT '0',
  `price` float NOT NULL DEFAULT '0',
  `categoryid` int(11) NOT NULL DEFAULT '0',
  `quantity` int(11) NOT NULL DEFAULT '0',
  `lowquantity` int(11) NOT NULL DEFAULT '0',
  `deleted` tinyint(4) DEFAULT NULL,
  PRIMARY KEY (`componentid`,`storeid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `components`
--

LOCK TABLES `components` WRITE;
/*!40000 ALTER TABLE `components` DISABLE KEYS */;
/*!40000 ALTER TABLE `components` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `favoriteitemcomponents`
--

DROP TABLE IF EXISTS `favoriteitemcomponents`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `favoriteitemcomponents` (
  `favoriteitemid` int(11) NOT NULL,
  `storeid` int(11) NOT NULL,
  `compontentid` int(11) NOT NULL,
  PRIMARY KEY (`favoriteitemid`,`storeid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='List of components for a favorite item.';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `favoriteitemcomponents`
--

LOCK TABLES `favoriteitemcomponents` WRITE;
/*!40000 ALTER TABLE `favoriteitemcomponents` DISABLE KEYS */;
/*!40000 ALTER TABLE `favoriteitemcomponents` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `favoriteitems`
--

DROP TABLE IF EXISTS `favoriteitems`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `favoriteitems` (
  `favoriteitemid` int(11) NOT NULL,
  `storeid` int(11) NOT NULL,
  `loyaltyid` int(11) NOT NULL,
  `name` int(11) NOT NULL,
  `price` float NOT NULL,
  `menuitemid` int(11) DEFAULT NULL,
  PRIMARY KEY (`favoriteitemid`,`storeid`,`loyaltyid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='stores the favorite items for a loyalty account.';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `favoriteitems`
--

LOCK TABLES `favoriteitems` WRITE;
/*!40000 ALTER TABLE `favoriteitems` DISABLE KEYS */;
/*!40000 ALTER TABLE `favoriteitems` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `favoriteorder`
--

DROP TABLE IF EXISTS `favoriteorder`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `favoriteorder` (
  `orderID` int(11) NOT NULL COMMENT 'this is the order in the Orders table that is a favorite for the StoreID Loyalty account pair',
  `storeid` int(11) NOT NULL,
  `loyaltyaccount` int(11) NOT NULL,
  PRIMARY KEY (`orderID`,`storeid`,`loyaltyaccount`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='this stores the favorite orders for a loyalty account';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `favoriteorder`
--

LOCK TABLES `favoriteorder` WRITE;
/*!40000 ALTER TABLE `favoriteorder` DISABLE KEYS */;
/*!40000 ALTER TABLE `favoriteorder` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `loyaltyaccounts`
--

DROP TABLE IF EXISTS `loyaltyaccounts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `loyaltyaccounts` (
  `loyaltyid` int(11) NOT NULL COMMENT 'Limited from 00000001 to 99999999 per store',
  `storeid` int(11) NOT NULL COMMENT 'Limited to 0001 to 9999',
  `name` varchar(45) DEFAULT NULL,
  `e-mailaddress` varchar(60) NOT NULL,
  `rewardscount` int(11) NOT NULL DEFAULT '0',
  `deleted` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`loyaltyid`,`storeid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='This stores the Loyalty Accounts \nThe Printed Loyalty ID Comprises of:\n	Store number zero padded with 4 spaces IE. "0001"\n	Loyalty number in sequence by store zero padded with 8 spaces IE. "00000002"';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `loyaltyaccounts`
--

LOCK TABLES `loyaltyaccounts` WRITE;
/*!40000 ALTER TABLE `loyaltyaccounts` DISABLE KEYS */;
/*!40000 ALTER TABLE `loyaltyaccounts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `managers`
--

DROP TABLE IF EXISTS `managers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `managers` (
  `managerid` int(11) NOT NULL,
  `storeid` int(11) NOT NULL,
  `firstname` varchar(45) NOT NULL,
  `lastname` varchar(45) NOT NULL,
  `employeeid` varchar(45) NOT NULL,
  `password` varchar(45) NOT NULL DEFAULT 'password',
  `isassistant` tinyint(4) NOT NULL DEFAULT '0',
  `deleted` tinyint(4) DEFAULT NULL,
  PRIMARY KEY (`managerid`,`storeid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `managers`
--

LOCK TABLES `managers` WRITE;
/*!40000 ALTER TABLE `managers` DISABLE KEYS */;
/*!40000 ALTER TABLE `managers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `menuitem`
--

DROP TABLE IF EXISTS `menuitem`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `menuitem` (
  `menuitemid` int(11) NOT NULL,
  `storeid` int(11) NOT NULL,
  `name` varchar(45) NOT NULL,
  `cost` float NOT NULL,
  `price` float NOT NULL,
  `isspecial` tinyint(4) NOT NULL DEFAULT '0',
  `menutypeid` int(11) NOT NULL DEFAULT '0',
  `deleted` tinyint(4) DEFAULT NULL,
  PRIMARY KEY (`menuitemid`,`storeid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `menuitem`
--

LOCK TABLES `menuitem` WRITE;
/*!40000 ALTER TABLE `menuitem` DISABLE KEYS */;
/*!40000 ALTER TABLE `menuitem` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `menuitemcomponents`
--

DROP TABLE IF EXISTS `menuitemcomponents`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `menuitemcomponents` (
  `menuitemid` int(11) NOT NULL,
  `storeid` int(11) NOT NULL,
  `component` int(11) NOT NULL,
  PRIMARY KEY (`menuitemid`,`storeid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `menuitemcomponents`
--

LOCK TABLES `menuitemcomponents` WRITE;
/*!40000 ALTER TABLE `menuitemcomponents` DISABLE KEYS */;
/*!40000 ALTER TABLE `menuitemcomponents` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `menutypes`
--

DROP TABLE IF EXISTS `menutypes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `menutypes` (
  `menutypeid` int(11) NOT NULL,
  `name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`menutypeid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='these will remain the same';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `menutypes`
--

LOCK TABLES `menutypes` WRITE;
/*!40000 ALTER TABLE `menutypes` DISABLE KEYS */;
INSERT INTO `menutypes` (`menutypeid`, `name`) VALUES (0,'Unassigned'),(1,'Sandwich'),(2,'Salad'),(3,'Drinks'),(4,'Deserts'),(5,'Sides');
/*!40000 ALTER TABLE `menutypes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orderitemcomponents`
--

DROP TABLE IF EXISTS `orderitemcomponents`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orderitemcomponents` (
  `orderitemid` int(11) NOT NULL,
  `storeid` int(11) NOT NULL,
  `component` int(11) NOT NULL,
  PRIMARY KEY (`orderitemid`,`storeid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orderitemcomponents`
--

LOCK TABLES `orderitemcomponents` WRITE;
/*!40000 ALTER TABLE `orderitemcomponents` DISABLE KEYS */;
/*!40000 ALTER TABLE `orderitemcomponents` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orderitemremoved`
--

DROP TABLE IF EXISTS `orderitemremoved`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orderitemremoved` (
  `orderitemid` int(11) NOT NULL,
  `storeid` int(11) NOT NULL,
  `componentremoved` int(11) NOT NULL,
  PRIMARY KEY (`orderitemid`,`storeid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orderitemremoved`
--

LOCK TABLES `orderitemremoved` WRITE;
/*!40000 ALTER TABLE `orderitemremoved` DISABLE KEYS */;
/*!40000 ALTER TABLE `orderitemremoved` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orderitems`
--

DROP TABLE IF EXISTS `orderitems`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orderitems` (
  `orderitemid` int(11) NOT NULL,
  `storeid` int(11) NOT NULL,
  `orderid` int(11) NOT NULL,
  `menuitemid` int(11) DEFAULT NULL,
  `name` varchar(45) DEFAULT NULL,
  `price` float DEFAULT NULL,
  PRIMARY KEY (`orderitemid`,`storeid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orderitems`
--

LOCK TABLES `orderitems` WRITE;
/*!40000 ALTER TABLE `orderitems` DISABLE KEYS */;
/*!40000 ALTER TABLE `orderitems` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orders`
--

DROP TABLE IF EXISTS `orders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orders` (
  `orderid` int(11) NOT NULL,
  `storeid` int(11) NOT NULL,
  `loyaltyid` int(11) NOT NULL DEFAULT '0',
  `status` int(11) NOT NULL COMMENT '0 - not placed\n1 - placed and ready to be made (put on Kitchen interface)\n2 - Order Created and delivered (put on lobby screen)',
  `timeplaced` datetime DEFAULT NULL,
  `timedelivered` datetime DEFAULT NULL,
  `total` float DEFAULT NULL COMMENT 'This is the pretax total.',
  `tax` varchar(45) DEFAULT NULL,
  `refunded` tinyint(4) DEFAULT '0',
  PRIMARY KEY (`orderid`,`storeid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='This is the table of items.';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orders`
--

LOCK TABLES `orders` WRITE;
/*!40000 ALTER TABLE `orders` DISABLE KEYS */;
/*!40000 ALTER TABLE `orders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `specials`
--

DROP TABLE IF EXISTS `specials`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `specials` (
  `menuitemid` int(11) NOT NULL,
  `storeid` int(11) NOT NULL,
  `begindate` date NOT NULL,
  `enddate` date NOT NULL,
  `daymask` int(11) NOT NULL DEFAULT '0' COMMENT 'MONDAY 2^0, Tuesday 2^1, Wednesday 2^2, ',
  PRIMARY KEY (`menuitemid`,`storeid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `specials`
--

LOCK TABLES `specials` WRITE;
/*!40000 ALTER TABLE `specials` DISABLE KEYS */;
/*!40000 ALTER TABLE `specials` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stores`
--

DROP TABLE IF EXISTS `stores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `stores` (
  `storeid` int(11) NOT NULL COMMENT 'this is a zero padded integer 0001 to 9999 ',
  `name` varchar(45) DEFAULT NULL COMMENT 'name of the store that can be used in lieu of city',
  `address` varchar(45) DEFAULT NULL,
  `city` varchar(45) DEFAULT NULL,
  `state` varchar(45) DEFAULT NULL,
  `zip` varchar(7) DEFAULT NULL,
  PRIMARY KEY (`storeid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='This is the table that stores the list of stores ';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stores`
--

LOCK TABLES `stores` WRITE;
/*!40000 ALTER TABLE `stores` DISABLE KEYS */;
/*!40000 ALTER TABLE `stores` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2014-03-11 15:29:12
