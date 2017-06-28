using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MainApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            iAccount acc = new EUR_Account();
            Console.WriteLine("\t\tWelcome to casino.\nPlease, register!");

            Console.Write("Enter your login: ");

            RUB_Account_Decorator dec = new RUB_Account_Decorator(acc);
            dec.Account.Login = Console.ReadLine();

            Console.WriteLine($"Succesfully registered, {dec.Account.Login}");

            Casino casino = Casino.getInstance(new RouletteMachine(), new Lottery(4));
            

            Console.WriteLine("Enter your current money: ");
            decimal d = decimal.Parse(Console.ReadLine());

            Balance bal = new ProxyWallet(d);

            acc.wallet = bal as ProxyWallet;
            casino.Register(acc);
            ReDo(casino, bal as ProxyWallet, acc);

            Console.WriteLine(acc.wallet.Withdraw());

            //Delay
            Console.ReadKey();
        }

        public static void ReDo(Casino casino, ProxyWallet bal, iAccount acc)
        {

            bool flag = true;
            while (flag)
            {

                Console.WriteLine("What ammount of money do you want to bet: ");
                decimal sum = bal.Withdraw(decimal.Parse(Console.ReadLine()));

                Console.WriteLine(
                       "What type of bet?(1 - Manque, 2 - Passe, 3 - Rouge, 4 - Noire, 5 - Pair, 6 - Impair, default - digit)");
                int t = int.Parse(Console.ReadLine());

                (casino.roulette as RouletteMachine)?.Add(acc.wallet.Withdraw(sum));

                Console.WriteLine("Roulette spinning");
                (casino.roulette as RouletteMachine).Work(t);
                casino.roulette.Spin();

                casino.accounts.Find(n => n.Login.Equals(acc.Login)).wallet.AddMoney(casino.roulette.Withdraw());

                Console.WriteLine("\nYou current money: " + (casino.roulette as RouletteMachine)._sum);

                Console.WriteLine("\nDo you want to continue?( y/n )");
                string answ = Console.ReadLine();

                if (answ.ToLower().Equals("y"))
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }

            acc.wallet.AddMoney(casino.roulette.Withdraw());
        }
    }
}
