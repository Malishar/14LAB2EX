using ClassLibraryBankCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14LAB2EX
{
    public class YouthCardGroup
    {
        public bool IsHighCashback { get; set; }
        public List<BankCard> Cards { get; set; }
        public int Count { get; set; }
    }
}
