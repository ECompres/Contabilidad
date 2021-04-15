using Accounting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contabilidad.Models
{
    public class AccountingAccount
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public int IdAccountType { get; set; }
        public AccountType AccountType { get; set; }
        public bool TransactionsEnabled { get; set; }
        public int Level { get; set; }
        public int MajorAccount { get; set; }
        public double Balance { get; set; }
        public bool Status { get; set; }

        public ICollection<Account> Accounts { get; set; }

    }
}
