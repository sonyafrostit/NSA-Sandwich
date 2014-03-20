Select 
	Q2.* ,CC.component , CC.name, CC.categoryid
from 
	(Select 
		
		Q.orderID, Q.storeid, Q.status, Q.timedelivered,Q.orderitemid, Q.name,OIR.componentremoved , OIR.name as removedname

	from 

		(Select O.orderID, O.storeid, O.status, O.timedelivered,OI.orderitemid, OI.name
			from 
				orders O, orderitems OI
			where
				O.orderid = OI.orderid ) Q
		left join 
			( Select 
				orderitemremoved.orderitemid, orderitemremoved.componentremoved , components.name
			  From
				orderitemremoved,components
			  where 
				componentremoved = componentid
			) AS OIR 
		on 
			Q.orderitemid = OIR.orderitemid
	    )as Q2

		left join 
			( Select 
				orderitemcomponents.orderitemid, orderitemcomponents.component , components.name, components.categoryid
			  From
				orderitemcomponents,components
			  where 
				component = componentid
			) AS CC
		on 
			Q2.orderitemid = CC.orderitemid

where  
	Q2.storeid = 1 AND
	Q2.status = 2 

Order by orderID, orderitemid, categoryid, componentremoved