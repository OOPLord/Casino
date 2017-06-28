using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp
{
    abstract class Bet
    {
       
        public abstract void Change(RouletteMachine r);
        public abstract bool Condition(Pocket p);
    }

    class digitBet : Bet
    {
        private int number;

        public digitBet(int n)
        {
            this.number = n;
        }

        public override void Change(RouletteMachine r)
        {
            r._bet = new digitBet(number);
        }

        public override bool Condition(Pocket p)
        {
            return p.Number == number;
        }
    }

    class Manque : Bet
    {
        public override void Change(RouletteMachine r)
        {
            r._bet = RouletteMachine.pass;
        }

        public override bool Condition(Pocket p)
        {
            return (p.Number >= 1 && p.Number <= 18);
        }
    }

    class Passe : Bet
    {
        public override void Change(RouletteMachine r)
        {
            r._bet = RouletteMachine.man;
        }

        public override bool Condition(Pocket p)
        {
            return (p.Number >= 19 && p.Number <= 36);
        }
    }

    class Rouge : Bet
    {
        public override void Change(RouletteMachine r)
        {
            r._bet = RouletteMachine.noire;
        }

        public override bool Condition(Pocket p)
        {
            return (p.Color == Color.Red);
        }
    }

    class Noire : Bet
    {
        public override void Change(RouletteMachine r)
        {
            r._bet = RouletteMachine.rouge;
        }

        public override bool Condition(Pocket p)
        {
            return (p.Color == Color.Black);
        }
    }

    class Even : Bet
    {
        public override void Change(RouletteMachine r)
        {
            r._bet = RouletteMachine.odd;
        }

        public override bool Condition(Pocket p)
        {
            return (p.Number % 2 == 0);
        }
    }

    class Odd : Bet
    {
        public override void Change(RouletteMachine r)
        {
            r._bet = RouletteMachine.even;
        }

        public override bool Condition(Pocket p)
        {
            return (p.Number % 2 != 0);
        }
    }
}
