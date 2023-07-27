using SFML.Graphics;
using SFML.System;
using Space_Invaders.Components;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    internal class EditorLevel
    {
        public static void CreateScene()
        {
            var laser = new GameObject();
            var laserSprite = new Sprite(new RectangleShape(new SFML.System.Vector2f(3, 20)));
            laser.AddComponent(new SpriteRenderer(laserSprite));
            var laserComponent = new Laser();
            laser.AddComponent(laserComponent);

            var elaser = new GameObject();
            var elaserSprite = new Sprite(new RectangleShape(new SFML.System.Vector2f(3, 20)));
            elaser.AddComponent(new SpriteRenderer(elaserSprite));
            var elaserComponent = new Laser();
            elaserComponent.Up = false;
            elaser.AddComponent(elaserComponent);

            var enemy = new GameObject(new SFML.System.Vector2f(30 , 80));
            var enemySprite = new Sprite(new RectangleShape(new Vector2f(20, 20)));
            enemy.AddComponent(new SpriteRenderer(enemySprite));
            var enemyComponent = new Components.Enemy();
            enemyComponent.laser = elaserComponent;
            enemy.AddComponent(enemyComponent);


            var playerGO = new GameObject(new Vector2f(30, 380));
            var playerSprite = new Sprite(new CircleShape(10));
            var playerSR = new SpriteRenderer(playerSprite);
            playerGO.AddComponent(playerSR);
            var playerComponent = new Components.Player();
            playerComponent.laser = laserComponent;
            playerGO.AddComponent(playerComponent);
        }
    }
}
