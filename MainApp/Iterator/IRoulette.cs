using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp
{
    interface IRoulette
    {
        IRouletteIterator CreateIterator();
        int Count { get; }
        Pocket this[int index] { get; }
    }

    class Roulette : IRoulette
    {
        private Pocket[] pockets;

        public Roulette()
        {
            Pocket[] temp = new Pocket[37];

            temp[0] = new Pocket(Color.Green, 0);

            for (int i = 1; i <= 36; i++)
            {
                if ((i >= 1 && i <= 10) || (i >= 19 && i <= 28))
                {
                    if (i%2 == 0)
                    {
                        temp[i] = new Pocket(Color.Black, i);
                    }
                    else
                    {
                        temp[i] = new Pocket(Color.Red, i);
                    }
                }
                else
                {
                    if (i % 2 == 0)
                    {
                        temp[i] = new Pocket(Color.Red, i);
                    }
                    else
                    {
                        temp[i] = new Pocket(Color.Black, i);
                    }
                }
            }

            pockets = new[] { temp[0], temp[32], temp[15], temp[19], temp[4], temp[21],
                temp[2], temp[25], temp[17], temp[34], temp[6], temp[27], temp[13], temp[36],
                temp[11], temp[30], temp[8], temp[23], temp[10], temp[5], temp[24], temp[16],
                temp[33], temp[1], temp[20], temp[14], temp[31], temp[9], temp[22], temp[18],
                temp[29], temp[7], temp[28], temp[12], temp[35], temp[3], temp[26]};

        }

        public int Count => pockets.Length;

        public Pocket this[int index] => pockets[index];

        public int count => pockets.Length;

        public IRouletteIterator CreateIterator()
        {
            return new RouletteNumerator(this);
        }
    }
}
