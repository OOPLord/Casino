using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp
{
    enum Color
    {
        Red, Black, Green
    }

    
    class Pocket
    {
        private Color _color;
        private int _number;

        public Pocket()
        { }
        
        public Pocket(Color color, int number)
        {

           this._color = color;
           this._number = number;
        }

        public Color Color {
            get { return _color; }
            set { _color = value; }
        }

        public int Number {
            get { return _number; }
            set { _number = value; }
        }
    }
}
