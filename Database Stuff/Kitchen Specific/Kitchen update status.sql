/*kitchen update query sets the Status for orderID 5 to 2 (Delivered) and the time delivered to now for station 1*/

UPDATE orders SET status = 2, timedelivered = now() Where storeid=1 AND orderID = 5;