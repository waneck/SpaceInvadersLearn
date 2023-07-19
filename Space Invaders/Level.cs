using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    public class Level
    {
        public const int SPEED = 100;
        public const int LASER_SPEED = 300;

        public Vector2f windowSize;

        public Random random;
        public Enemy[] enemies;
        public Player player;

        public int lives = 3;

        public float elapsedTime;

        public bool gameOver;

        public Shape gameOverShape;

        public Level(Vector2f windowSize)
        {
            this.player = new Player(this, new Vector2f(30, 380));
            this.enemies = new Enemy[19 * 6];
            this.random = new Random();

            for (var index = 0; index < enemies.Length; index++)
            {
                int row = index / 19;
                int column = index % 19;
                enemies[index] = new Enemy(this, new SFML.System.Vector2f(30 + (20 + 10) * column, 80 + (20 + 10) * row));
            }
            this.gameOverShape = new RectangleShape(new Vector2f(200, 200));
            this.gameOverShape.FillColor = Color.Red;

            this.windowSize = windowSize;
        }

        public void DecrementLife()
        {
            if (this.lives > 0)
            {
                this.lives--;
                this.player.Position = new Vector2f(30, 380);
            } 
            else
            {
                gameOver = true;
            }
        }

        public void Update(float deltaTime)
        {
            if (!gameOver)
            {
                player.Update(deltaTime);
            }
            foreach (var enemy in enemies)
            {
                enemy.Update(deltaTime);
            }

            elapsedTime += deltaTime;
        }

        public void Draw(RenderWindow window)
        {
            player.Draw(window);
            foreach (var enemy in enemies)
            {
                enemy.Draw(window);
            }

            if (gameOver)
            {
                // new Text("GAME OVER", new Font())
                window.Draw(this.gameOverShape);
            }
        }
    }
}
