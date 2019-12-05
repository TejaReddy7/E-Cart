using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_Cart.WebSite.Models
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int SellerId { get; set; }
        public int UserId { get; set; }
        public int OrderNumber { get; set; }
        public int ShipmentId { get; set; }
        public int PaymentId { get; set; }
        public DateTime DateStamp { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }

        //[ForeignKey("SellerId")]
        //public Sellers Sellers { get; set; }
        [ForeignKey("ProductId")]
        public Products Products { get; set; }
        [ForeignKey("UserId")]
        public Users Users { get; set; }
        [ForeignKey("OrderNumber")]
        public OrderDetails OrderDetails { get; set; }
        [ForeignKey("PaymentId")]
        public Payments Payments { get; set; }
        [ForeignKey("ShipmentId")]
        public Shipments Shipments { get; set; }

        public ICollection<Products> Product { get; set; }
        public ICollection<Sellers> Seller { get; set; }
        public ICollection<Users> User { get; set; }
        //public ICollection<OrderDetails> OrderDetail { get; set; }
        //public ICollection<Payments> Payment { get; set; }
        //public ICollection<Shipments> Shipment { get; set; }

    }
}
