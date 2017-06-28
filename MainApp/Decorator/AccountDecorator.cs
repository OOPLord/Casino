using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainApp.Factory__Memento____Observer_for_Accs;

namespace MainApp
{
    //Decorator
    abstract class AccountDecorator : iAccount
    {
        public iAccount Account { get; set; }

        public AccountDecorator(iAccount acc)
        {
            this.Account = acc;
        }

        public abstract void Decorate();

        public override double Transfer(double data)
        {
            return Account.Transfer(data);
        }
    }

    class USD_Account_Decorator : AccountDecorator
    {
        public USD_Account_Decorator(iAccount acc) : base(acc)
        { }

        public override void Decorate()
        {
            Account.Login += "added via USD account";
        }
    }
    class UAH_Account_Decorator : AccountDecorator
    {
        public UAH_Account_Decorator(iAccount acc) : base(acc)
        {
        }

        public override void Decorate()
        {
            Account.Login += "added via UAH account";
        }
    }
    class RUB_Account_Decorator : AccountDecorator
    {
        public RUB_Account_Decorator(iAccount acc) : base(acc)
        {
        }

        public override void Decorate()
        {
            Account.Login += "added via RUB account";
        }
    }
    class EUR_Account_Decorator : AccountDecorator
    {
        public EUR_Account_Decorator(iAccount acc) : base(acc)
        {
        }

        public override void Decorate()
        {
            Account.Login += "added via EUR account";
        }
    }
}
