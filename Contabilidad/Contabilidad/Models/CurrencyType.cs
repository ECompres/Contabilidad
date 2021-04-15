using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contabilidad.Models
{
    public class CurrencyType
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public double LastExchangeRate { get; set; } //No sé si el tipo de dato es correcto
        public bool Status { get; set; }
    }
}
