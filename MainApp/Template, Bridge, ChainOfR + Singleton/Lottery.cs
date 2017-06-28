using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp
{
    class Lottery : iCasino
    {

        private bool LotteryOn = true;

        public decimal Sum;
        public int[] Num;

        public Lottery()
        { }

        public Lottery(int n)
        {
            Num = new int[n];
            
        }

        public void Add(decimal n)
        {
            Sum = n;

            GenerateWinNumber();

        }

        public override void HandleNext()
        {
            if (!LotteryOn)
            {
                State?.HandleNext();
            }
        }

        public void GenerateWinNumber()
        {
            for (int i = 0; i < Num.Length; i++)
            {
                Num[i] = new Random().Next();
            }
        }

        public override void Spin()
        {
            int k = 0;

            int[] winNumbers = new int[Num.Length];

            for (int i = 0; i < Num.Length; i++)
            {
                winNumbers[i] = new Random().Next();

                if (Num[i] == winNumbers[i])
                {
                    k++;
                }
            }

            int modulus = 1 / Num.Length;
            int multiplier = 0;

            if (k != 0)
                multiplier = (k * modulus) + 1;

            Sum *= multiplier;

        }

        public override decimal Withdraw()
        {
            
            return Sum;
        }
    }
}
