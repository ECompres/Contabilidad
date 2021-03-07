using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contabilidad.Models
{
    public class AuxiliarSystem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool State { get; set; }
        public List<AccountingEntry> AccountingEntry { get; set; }
    }
}
