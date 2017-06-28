using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainApp.Factory__Memento____Observer_for_Accs;

namespace MainApp
{
    
    //Factory, Memento, Observer, Bridge, Decorator


    abstract class iAccount
    {
        public string Login { get; set; }
        public Currency currency { get; set; }
        public BetHistory history;
        public ProxyWallet wallet { get; set; }

        public iAccount()
        {
            history = new BetHistory();
            wallet = new ProxyWallet(1500);
        }

        public iAccount(Currency curr)
        {
            currency = curr;
        }

        public abstract double Transfer(double data);

        public void Saver(Bet bet)
        {
            history.History.Push(new BetSaver(bet));
        }

        public void Update(string str)
        {
            Console.WriteLine(str);
        }
    }

    class RefinedAcc : iAccount
    {
        public RefinedAcc(Currency cur) : base(cur)
        { }

        public override double Transfer(double data)
        {
            return currency.toCurr(data);
        }
    }

    class USD_Account : iAccount
    {
        public USD_Account()
        {
            currency = new USD("Dollar", 27.7);
        }

        public override double Transfer(double data)
        {
            return currency.toCurr(data);
        }
    }

    class UAH_Account : iAccount
    {
        public UAH_Account()
        {
            currency = new UAH("Ukrainian hryvna", 1);
        }
        public override double Transfer(double data)
        {
            return currency.toCurr(data);
        }
    }

    class RUB_Account : iAccount
    {
        public RUB_Account()
        {
            currency = new RUB("Russian rubl'", 0.5);
        }
        public override double Transfer(double data)
        {
            return currency.toCurr(data);
        }

    }

    class EUR_Account : iAccount
    {
        public EUR_Account()
        {
            currency = new EUR("Euro", 30);
        }
        public override double Transfer(double data)
        {
            return currency.toCurr(data);
        }
    }
}
