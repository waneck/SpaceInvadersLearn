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
        private Level level;
        private RectangleShape shape;
        private Vector2f position;
        private bool isAlive;

        private RectangleShape laser;
        private bool isShooting;
        private int timeLastRolledForShooting = -1;

        public Enemy(Level level, Vector2f inPosition)
        {
            this.level = level;
            this.shape = new SFML.Graphics.RectangleShape(new SFML.System.Vector2f(20, 20));
            this.position = inPosition;
            this.isAlive = true;
            this.shape.Position = this.position;
            this.shape.FillColor = Color.Red;

            this.laser = new RectangleShape(new Vector2f(3, 20));
            this.laser.FillColor = Color.Red;
            this.isShooting = false;
        }

        public bool LaserCollide(Vector2f laserPosition)
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

        public void Shoot()
        {
            if (!this.isShooting)
            {
                this.isShooting = true;
                this.laser.Position = new SFML.System.Vector2f(this.position.X + 10 - (3.0f / 2), this.position.Y);
            }
        }

        public void Update(float deltaTime)
        {
            if (timeLastRolledForShooting != ((int) this.level.elapsedTime))
            {
                timeLastRolledForShooting = ((int) this.level.elapsedTime);
                if (level.random.Next(0, 50) == 0)
                {
                    this.Shoot();
                }
            }

            if (this.isShooting)
            {
                this.laser.Position = new Vector2f(this.laser.Position.X, this.laser.Position.Y + Level.LASER_SPEED * deltaTime);
                if (this.laser.Position.Y > this.level.windowSize.Y)
                {
                    this.isShooting = false;
                }

                if (this.level.player.LaserCollide(this.laser.Position))
                {
                    this.isShooting = false;
                }
            }
        }

        public void Draw(RenderWindow window)
        {
            if (this.isAlive)
            {
                window.Draw(this.shape);
            }
            if (this.isShooting)
            {
                window.Draw(this.laser);
            }
        }
    }
}
