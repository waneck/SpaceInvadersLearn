using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    internal class SpriteRenderer : Behavior
    {
        public bool Active = true;
        public Sprite Sprite;

        public SpriteRenderer(Sprite sprite)
        {
            Sprite = sprite;
        }

        internal override void Draw(RenderWindow window)
        {
            if (Active)
            {
                Sprite._shape.Position = GameObject.Position;
                window.Draw(Sprite._shape);
            }
        }
    }
}
