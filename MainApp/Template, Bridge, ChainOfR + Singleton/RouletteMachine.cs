using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp
{
    //Template, Chain, Singleton
    class RouletteMachine : iCasino
    {
        private bool RouletteOn = true;
        public static Bet bet { get; set; }
        public Pocket WinPocket { get; set; }
        
        public decimal _sum { get; set; }

        public static Manque man { get; set; } = new Manque();
        public static Passe pass { get; set; } = new Passe();
        public static Rouge rouge { get; set; } = new Rouge();
        public static Noire noire { get; set; } = new Noire();
        public static Even even { get; set; } = new Even();
        public static Odd odd { get; set; } = new Odd();

        public RouletteMachine()
        { }

        public void Work(int t)
        {

            switch (t)
            {
                case 1:
                    bet = man;
                    break;

                case 2:
                    bet = pass;
                    break;

                case 3:
                    bet = rouge;
                    break;

                case 4:
                    bet = new Noire();
                    break;

                case 5:
                    bet = new Even();
                    break;

                case 6:
                    bet = new Odd();
                    break;

                default:
                    Console.WriteLine("Enter your number: ");
                    int s = int.Parse(Console.ReadLine());
                    bet = new digitBet(s);
                    break;
            }
        }

        public void Add(decimal sum)
        {
            this._sum = sum;
        }

        public override void Spin()
        {
            try { 
                if(bet == null)
                    throw new Exception("No bet was made");
                if(_sum == 0)
                    throw new Exception("You bet was not made due. No money found!");

                IRoulette roulette = new Roulette();

                IRouletteIterator iterator = roulette.CreateIterator();

                Pocket p = new Pocket();

                for (int i = 0; i < new Random().Next(); i++)
                {
                    p = iterator.Next();
                }

                if (bet.Condition(p))
                {
                    _sum *= 2;
                    Console.WriteLine("You win!");
                }
                else
                {
                    _sum = 0;
                    Console.WriteLine("Oops, Lost your money!");
                }

                WinPocket = p;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public override void HandleNext()
        {
            if (!RouletteOn && State != null)
            {
                State.HandleNext();
            }
        }

        public override decimal Withdraw()
        {
            decimal temp = _sum;
            _sum = 0;

            return temp;
        }
    }
}
