using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    internal abstract class Behavior
    {
        public GameObject GameObject { get; private set; }

        internal void _setGameObject(GameObject gameObject)
        {
            GameObject = gameObject;
        }

        public virtual void Start()
        {
        }

        public virtual void Update(float deltaTime)
        {
        }

        internal virtual void Draw(RenderWindow window)
        {
        }
    }
}
