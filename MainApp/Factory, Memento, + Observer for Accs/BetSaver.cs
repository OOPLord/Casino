using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp
{
    //Memento
    class BetSaver
    {
        public Bet lastBet { get; set; }

        public BetSaver(Bet bet)
        {
            lastBet = bet;
        }
    }

    //CareTaker
    class BetHistory
    {
        public Stack<BetSaver> History { get; set; }
        public BetHistory()
        {
            History = new Stack<BetSaver>();
        }
    }
}
