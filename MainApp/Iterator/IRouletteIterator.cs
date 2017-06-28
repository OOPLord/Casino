using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp
{
    interface IRouletteIterator
    {
        Pocket Next();
        bool hasNext();
    }

    class RouletteNumerator : IRouletteIterator
    {
        private IRoulette _roulette;
        private int index = 0;

        public RouletteNumerator(IRoulette roulette)
        {
            this._roulette = roulette;
        }

        public bool hasNext()
        {
            return index < _roulette.Count;
        }

        public Pocket Next()
        {
            if(hasNext())
                return _roulette[index++];
            else
            {
                index = 0;
                return _roulette[index];
            }
        }
    }
}
