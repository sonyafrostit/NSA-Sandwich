using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Order{
        //Each order contains a list of items within that order
            private List<Item> list_of_items = new List<Item>();
            //internal orderid, should be set to same ID as database 
            private int orderid;
            private Order()
            {
                orderid = -1;
            }
            public Order(int orderid)
            {
                this.orderid = orderid;

            }
            public Order(int orderid, Item newitem)
            {
                this.orderid = orderid;
                this.list_of_items.Add(newitem);

            }
            public Order(int orderid, List<Item> list_of_items)
            {
                this.orderid = orderid;
                this.list_of_items = list_of_items;

            }
            public int numItems()
            {
                return list_of_items.Count();

            }
            public int getOrderId()
            {
                return this.orderid;
            }
            public void add(Item newitem)
            {
                this.list_of_items.Add(newitem);
            }
            public void add(List<Item> list_of_items)
            {
                this.list_of_items = list_of_items;
            }
            public Item itemAt(int i)
            {
                return list_of_items[i];

            }
            public List<Item> getOrderItems()
            {
                return this.list_of_items;
            }
    }
}
