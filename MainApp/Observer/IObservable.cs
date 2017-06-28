using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp
{
    //Observer
    abstract class IObservable
    {

        
        public abstract void CasinoWork();
        public abstract void Register(iAccount acc);
        public abstract void Remove(iAccount acc);
        public abstract void NotifyAll();
    }
}
