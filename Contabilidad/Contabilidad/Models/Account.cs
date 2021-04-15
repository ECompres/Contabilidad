using Contabilidad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounting.Models
{
    public class Account
    {
        public int Id { get; set; }

        public int IdAccountingAccount { get; set; }

        public int IdAccountingEntry { get; set; }

        public double CreditAmount { get; set; }

        public double DebitAmount { get; set; }

        public AccountingAccount AccountingAccount { get; set; }

        public AccountingEntry AccountingEntry { get; set; }

    }
}
