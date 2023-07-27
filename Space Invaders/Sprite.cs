using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    internal class Sprite
    {
        internal Shape _shape;

        public Sprite(Shape shape) 
        {
            _shape = shape;
        }
    }
}
