using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace E_Cart.WebSite.Models
{
    public class Payments
    {
        [Key]
        public int PaymentId { get; set; }
        public int UserId { get; set; }
        [Required]
        public string ModeOfPayment { get; set; }
        public DateTime DateStamp { get; set; }
        public int Amount { get; set; }

        public ICollection<Users> User { get; set; }
    }
}
