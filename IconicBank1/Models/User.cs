using System;
using System.Collections.Generic;

namespace IconicBank1
{
    public partial class User
    {
        public User()
        {
            Transactions = new HashSet<Transaction>();
        }

        public long AccountNumber { get; set; }
        public string? UserName { get; set; }
        public string? EmailId { get; set; }
        public long? PhoneNumber { get; set; }
        public string? Ifsccode { get; set; }
        public string? Password { get; set; }
        public DateTime? LoggedIn { get; set; }
        public int? LogCounter { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
