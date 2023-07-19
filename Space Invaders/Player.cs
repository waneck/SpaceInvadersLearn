using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    public class Player
    {
        private Level level;
        private CircleShape shape;
        private bool shooting;
        private Shape laser;

        public Vector2f Position 
        { 
            get
            {
                return this.shape.Position;
            } 
            set { this.shape.Position = value; }
        }

        public Player(Level level, Vector2f startingPosition)
        {
            this.level = level;
            shape = new CircleShape(10);
            shape.Position = startingPosition;
            laser = new RectangleShape(new SFML.System.Vector2f(3, 20));
            laser.FillColor = Color.Yellow;
        }

        public void AddToPositionX(float amount)
        {
            this.shape.Position = new Vector2f(this.shape.Position.X + amount, this.shape.Position.Y);
        }

        public bool LaserCollide(Vector2f laserPosition)
        {
            if (laserPosition.Y <= (this.Position.Y + this.shape.Radius * 2) && 
                laserPosition.Y >= this.Position.Y &&
                laserPosition.X <= (this.Position.X + this.shape.Radius * 2) &&
                laserPosition.X >= this.Position.X)
            {
                this.level.DecrementLife();
                return true;
            }
            return false;
        }

        public void Update(float deltaTime)
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Left) && shape.Position.X >= 10)
            {
                AddToPositionX(-Level.SPEED * deltaTime);
            } else if (Keyboard.IsKeyPressed(Keyboard.Key.Right) && shape.Position.X <= (640 - 20 - 10))
            {
                AddToPositionX(Level.SPEED * deltaTime);
            } else if (Keyboard.IsKeyPressed(Keyboard.Key.Space) && !shooting)
            {
                shooting = true;
                laser.Position = new SFML.System.Vector2f(shape.Position.X + 10 - (3.0f / 2), shape.Position.Y);
            }

            if (shooting)
            {
                laser.Position = new Vector2f(laser.Position.X, laser.Position.Y - Level.LASER_SPEED * deltaTime);
                if (laser.Position.Y < 0)
                {
                    shooting = false;
                }

                foreach (var enemy in level.enemies)
                {
                    if (enemy.LaserCollide(laser.Position))
                    {
                        this.shooting = false;
                    }
                }
            }
        }

        public void Draw(RenderWindow window)
        {
            window.Draw(this.shape);
            if (this.shooting)
            {
                window.Draw(this.laser);
            }
        }
    }
}
