using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    class OrderDetails
    {
        public string OrderId { get; set; }
        public string OrderNumber { get; set; }
        public string SellerId { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }
        public int Tax { get; set; }
        public DateTime DateStamp { get; set; }
        public int Freight { get; set; }

        public void AddOrderDetails()
        {

        }
        public void UpdateOrderDetails()
        {

        }
        public void RemoveOrderDetails()
        {

        }
    }
}
