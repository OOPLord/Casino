using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp
{
    //Observer, Command, Facade
    class Casino : IObservable
    {
        private static Casino instance;

        public iCasino roulette, lottery;

        bool Update_On;
        public List<iAccount> accounts;
        
        private Casino(RouletteMachine rlm, Lottery lot)
        {
            accounts = new List<iAccount>();
            Update_On = true;

            roulette = rlm;
            lottery = lot;
        }

        public static Casino getInstance(RouletteMachine rlm, Lottery lot)
        {
            if (instance != null)
                return null;
            else
            {
                return new Casino(rlm, lot);
            }
        }

        public override void CasinoWork()
        {
            Console.WriteLine( roulette.TemplateMenthod() );
            Console.WriteLine( lottery.TemplateMenthod() );
        }

        public override void Register(iAccount acc)
        {
            accounts.Add(acc);
        }

        public override void Remove(iAccount acc)
        {
            accounts.Remove(acc);
        }

        public void UpdateOn()
        {
            Update_On = true;
        }
        public void UpdateOff()
        {
            Update_On = false;
        }

        public override void NotifyAll()
        {
            if (Update_On)
            {
                foreach (var acc in accounts)
                {
                    acc.Update("Casino data was updated!!!");
                }
            }
        }
    }
}
