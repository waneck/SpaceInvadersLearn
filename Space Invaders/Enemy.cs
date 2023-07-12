using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    public class Enemy
    {
        public RectangleShape shape;
        public Vector2f position;
        public bool isAlive;

        public RectangleShape laser;
        public bool isShooting;

        public Enemy(Vector2f inPosition)
        {
            this.shape = new SFML.Graphics.RectangleShape(new SFML.System.Vector2f(20, 20));
            this.position = inPosition;
            this.isAlive = true;
            this.shape.Position = this.position;
            this.shape.FillColor = Color.Red;

            this.laser = new RectangleShape(new Vector2f(3, 20));
            this.laser.FillColor = Color.Red;
            this.isShooting = false;
        }

        public bool laserCollide(Vector2f laserPosition)
        {
            if (this.isAlive &&
                laserPosition.Y <= (this.position.Y + this.shape.Size.Y) && 
                laserPosition.Y >= this.position.Y &&
                laserPosition.X <= (this.position.X + this.shape.Size.X) &&
                laserPosition.X >= this.position.X)
            {
                this.isAlive = false;
                return true;
            }
            return false;
        }

        public void shoot()
        {
            if (!this.isShooting)
            {
                this.isShooting = true;
                this.laser.Position = new SFML.System.Vector2f(this.position.X + 10 - (3.0f / 2), this.position.Y);
            }
        }
    }
}
