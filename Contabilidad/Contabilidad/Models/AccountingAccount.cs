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
        public string MajorAccount { get; set; } //No sé si el tipo de dato es correcto
        public double Balance { get; set; }
        public bool Status { get; set; }
    }
}
