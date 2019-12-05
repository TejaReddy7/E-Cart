using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Cart.WebSite.Models
{
    public class Sellers
    {
        [Key]
        public int SellerId { get; set; }
        [Required]
        public string SellerName { get; set; }
        public int MobileNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [Required(ErrorMessage = "Field can't be empty")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        [Required]
        public string GSTNumber { get; set; }
        public int AccountNumber { get; set; }

        [ForeignKey("AccountNumber")]
        public SellerAccounts SellerAccounts { get; set; }
        //public ICollection<SellerAccounts> SellerAccount { get; set; }


    }
}
