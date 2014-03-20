/* Gets the number of orders in queue */

Select count(*) as NumberOrders from orders where status = 1 AND storeid = 1;

/* THe Following is just to get the orders with status 1 for station 1  */

Select * from orders where status = 1 AND storeid = 1;


/* The following gets the orders as above as well as the ordered items */

Select O.orderID, O.storeid, O.status, O.timedelivered, OI.menuitemid, OI.name, OI.orderitemid
from 
	orders O, orderitems OI
where
	O.orderid = OI.orderid AND 
	O.storeid = 1 AND
	O.status = 1;

/* The following gets the components that are added to order item 5*/
Select 
	OIC.orderitemid, OIC.component, C.name, C.componentid
From 
	orderitemcomponents OIC join components C
where
	OIC.component = C.componentid AND
	OIC.orderitemid = 5
order by 
	componentid;

/* The following gets the components that are Removed From item 1*/
Select 
	OIR.orderitemid, OIR.componentremoved, C.name, C.componentid
From 
	orderitemremoved OIR join components C
where
	OIR.componentremoved = C.componentid AND
	OIR.orderitemid = 1
order by 
	componentid;
	
