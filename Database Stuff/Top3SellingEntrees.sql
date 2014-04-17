SELECT  J.name, count(J.menuitemid) as Rank
FROM 
	(SELECT OI.name, OI.menuitemid, O.timeplaced  
	FROM orderitems OI join orders O ON OI.orderID = O.orderID 
	Where 
		DATE(O.timeplaced) = DATE(DATE_SUB(NOW(), INTERVAL 1 DAY)) AND 
		O.storeid = 1 AND 
		OI.menuitemid in (SELECT menuitemid FROM menuitem where storeid = 1 AND menutypeid in (1,2))) as J
GROUP BY name
ORDER BY Rank DESC
LIMIT 3;
