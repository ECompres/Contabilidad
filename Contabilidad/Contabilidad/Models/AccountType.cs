using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contabilidad.Models
{
    public class AccountType
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public string Origin { get; set; }
        public bool Status { get; set; }
        public List<AccountingAccounts> AccountingAccounts { get; set; }
    }
}
