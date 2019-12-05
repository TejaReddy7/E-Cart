using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Cart.WebSite.Models
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        public int SellerId { get; set; }
        [Required]
        public string ProductName { get; set; }
        public int MRP { get; set; }
        public int SellingPrice { get; set; }
        public int Discount { get; set; }
        [Required]
        public string Vendor { get; set; }
        public int CategoryId { get; set; }
        [Required]
        public string Description { get; set; }

        [ForeignKey("SellerId")]
        public Sellers Sellers { get; set; }
        [ForeignKey("CategoryId")]
        public Categories Categories { get; set; }

        public ICollection<Sellers> Seller { get; set; }
        public ICollection<Categories> Category { get; set; }
    }
}
