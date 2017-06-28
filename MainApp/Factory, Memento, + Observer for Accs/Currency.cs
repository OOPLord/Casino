using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.Factory__Memento____Observer_for_Accs
{
    public enum Curr
    {
        EUR, RUB, UAH, USD
    }

    public abstract class Currency
    {
        public string Name { get; set; }
        public Curr Curr { get; set; }
        public double Course { get; set; }

        public Currency()
        { }

        public Currency(string name, double course, Curr curr)
        {
            this.Name = name;
            this.Curr = curr;
        }

        public abstract double toCurr(double curr);
    }

    class EUR : Currency
    {
        public EUR(string name, double course) : base(name, course, Curr.EUR)
        { }

        public override double toCurr(double curr)
        {
            return curr * Course;
        }
    }
    class USD : Currency
    {
        public USD(string name, double course) : base(name, course, Curr.USD)
        { }

        public override double toCurr(double curr)
        {
            return curr * Course;
        }
    }
    class UAH : Currency
    {
        public UAH(string name, double course) : base(name, course, Curr.UAH)
        { }

        public override double toCurr(double curr)
        {
            return curr;
        }
    }
    class RUB : Currency
    {
        public RUB(string name, double course) : base(name, course, Curr.RUB)
        { }

        public override double toCurr(double curr)
        {
            return curr * Course;
        }
    }
}
