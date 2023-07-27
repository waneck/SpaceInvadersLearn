using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders.Components
{
    internal class Player : Behavior
    {
        public Laser? laser;

        public override void Update(float deltaTime)
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Left) && GameObject.Position.X >= 10)
            {
                GameObject.Position.X -= Level.SPEED * deltaTime;
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.Right) && GameObject.Position.X <= (640 - 20 - 10))
            {
                GameObject.Position.X += Level.SPEED * deltaTime;
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.Space) && !laser!.Shooting)
            {
                laser!.StartShooting(new SFML.System.Vector2f(GameObject.Position.X + 10 - (3.0f / 2), GameObject.Position.Y));
                // laser.Position = new SFML.System.Vector2f(shape.Position.X + 10 - (3.0f / 2), shape.Position.Y);
            }
        }
    }
}
