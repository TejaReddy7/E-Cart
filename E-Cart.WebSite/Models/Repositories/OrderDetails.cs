using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Cart.WebSite.Models
{
    public class OrderDetails
    {
        
        [Key]
        public int OrderNumber { get; set; }
        public int OrderId { get; set; }
        public int SellerId { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }
        public int Tax { get; set; }
        public DateTime DateStamp { get; set; }
        public int Freight { get; set; }


        //[ForeignKey("SellerId")]
        //public Sellers Sellers { get; set; }
        //[ForeignKey("OrderId")]
        //public Orders Orders { get; set; }

        public ICollection<Orders> Order { get; set; }
        public ICollection<Sellers> Seller { get; set; }



    }
}
