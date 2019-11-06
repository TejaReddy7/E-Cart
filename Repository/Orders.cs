using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    class Orders
    {
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        public string SellerId { get; set; }
        public string UserId { get; set; }
        public string ShipmentId { get; set; }
        public string PaymentId { get; set; }
        public DateTime DateStamp { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }
        
        public void AddOrder()
        {

        }
        public void ConfirmOrder()
        {

        }
        public void CancelOrder()
        {

        }
    }
}
