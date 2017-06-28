using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp
{
    //Factory
    abstract class AccountCreator
    {
        public iAccount Account;
    }

    class RussianAccount : AccountCreator
    {
        public RussianAccount()
        {
            Account = new RUB_Account();
        }
    }
    class UkrainianAccount : AccountCreator
    {
        public UkrainianAccount()
        {
            Account = new UAH_Account();
        }
    }
    class EuropeAccount : AccountCreator
    {
        public EuropeAccount()
        {
            Account = new EUR_Account();
        }
    }
    class AmericanAccount : AccountCreator
    {
        public AmericanAccount()
        {
            Account = new USD_Account();
        }
    }
}
