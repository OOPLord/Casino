using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp
{
    //Proxy, Prototype
    interface Balance
    {
        decimal Withdraw();
        decimal Withdraw(decimal d);
        void AddMoney(decimal d);
        Balance Clone();
    }

    class Wallet : Balance
    {
        public decimal Cash { get; set; }

        public Wallet(decimal sum)
        {
            Cash = sum;
        }

        public decimal Withdraw()
        {
            decimal temp = Cash;
            Cash = 0;

            return temp;
        }

        public decimal Withdraw(decimal d)
        {
            try
            {
                if (d < Cash)
                {
                    Cash -= d;

                    return d;
                }
                else throw new Exception("Not enough cash in the bank!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
            
        }

        public void AddMoney(decimal d)
        {
            Cash += d;
        }

        public Balance Clone()
        {
            return new Wallet(Cash);
        }
    }

    class ProxyWallet : Balance
    {
        private Wallet wallet;

        public ProxyWallet(decimal d)
        {
            if(wallet == null)
                wallet = new Wallet(d);
        }

        public decimal Withdraw()
        {
           return wallet.Withdraw();
        }

        public decimal Withdraw(decimal d)
        {
            return wallet.Withdraw(d);
        }

        public void AddMoney(decimal d)
        {
            wallet.AddMoney(d);
        }

        public Balance Clone()
        {
            return new ProxyWallet(wallet.Cash);
        }
    }


}
