using System;
using System.Collections.Generic;
using System.Text;

namespace PokeBattle.Utilities.DataObjects
{
    public class Credit
    {
        public string CreditFor { get; set; }
        public string CreditReciever { get; set; }

        public string CreditLink { get; set; }

        public Credit() { }

        public Credit(string creditfor, string creditreciever, string creditlink)
        {
            CreditFor = creditfor;
            CreditReciever = creditreciever;
            CreditLink = creditlink;
        }
    }
}
