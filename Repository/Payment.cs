using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    class Payment
    {
        public string UserId { get; set; }
        public string ModeOfPayment { get; set; }
        public string PaymentId { get; set; }
        public DateTime DateStamp { get; set; }
        public int Amount { get; set; }

        public void ConfirmPayment()
        {

        }
        public void RejectPayment()
        {

        }

    }
}
