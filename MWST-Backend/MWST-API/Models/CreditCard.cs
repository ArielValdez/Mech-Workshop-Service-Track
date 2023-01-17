using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MWST_API.Models
{
    public class CreditCard
    {
        public int ID { get; set; }
        public int IdUser { get; set; }
        public string Numbers { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string CVV { get; set; }
        public string Name { get; set; }
    }
}
