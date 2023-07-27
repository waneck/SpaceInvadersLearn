using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders.Components
{
    internal class Laser : Behavior
    {
        public bool Shooting = false;
        public bool Up = true;

        public Laser()
        {
        }

        public override void Start()
        {
            GameObject.GetComponent<SpriteRenderer>()!.Active = false;
        }

        public void StartShooting(Vector2f position)
        {
            if (Shooting)
            {
                return;
            }


            GameObject.Position = position;
            Shooting = true;
            GameObject.GetComponent<SpriteRenderer>()!.Active = true;
        }

        public override void Update(float deltaTime)
        {
            if (Shooting)
            {
                if (Up)
                {
                    GameObject.Position.Y -= Level.LASER_SPEED * deltaTime;
                }
                else
                {
                    GameObject.Position.Y += Level.LASER_SPEED * deltaTime;
                }
                if (GameObject.Position.Y < 0)
                {
                    Shooting = false;
                    GameObject.GetComponent<SpriteRenderer>()!.Active = false;
                }
            }
        }
    }
}
