using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace E_Cart.WebSite.Models
{
    public class SellerAccounts
    {
        [Key]
        public int AccountNumber { get; set; }
        public int SellerId { get; set; }
        [Required]
        public string BankName { get; set; }
        [Required]
        public string IFSC { get; set; }
        public int MobileNumber { get; set; }
        public ICollection<Sellers> Seller { get; set; }


    }
}
