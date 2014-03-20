/* update the Status of all delivered orders to 3 to hide from lobby screen */
UPDATE orders SET status = 3 Where storeid=1 AND status = 2;