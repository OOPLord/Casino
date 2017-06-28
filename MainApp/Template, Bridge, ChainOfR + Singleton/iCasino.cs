using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp
{
    //Template, Chain of Responsibility
    abstract class iCasino
    {
        public Bet _bet { get; set; }

        public decimal TemplateMenthod()
        {
            Spin();

            return Withdraw();

        }

        public iCasino State { get; set; }

        public abstract void Spin();
        public abstract decimal Withdraw();

        public abstract void HandleNext();

    }
}
