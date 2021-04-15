using Accounting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contabilidad.Models
{
    public class AccountingEntry
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public int IdAuxiliarSystem { get; set; }
        public AuxiliarSystem AuxiliarSystem { get; set; }
        public string MovementType { get; set; }
        public DateTime EntryDate { get; set; }
        public bool Status { get; set; }
        public ICollection<Account> Accounts { get; set; }

    }
}
