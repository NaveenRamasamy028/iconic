using System;
using System.Collections.Generic;

namespace IconicBank1
{
    public partial class Transaction
    {
        public long TransactionId { get; set; }
        public long? AccountNumber { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string? TransactionType { get; set; }
        public double? TransactionAmount { get; set; }
        public long? AccountBalance { get; set; }

         public virtual User? AccountNumberNavigation { get; set; }
       
    }
}
