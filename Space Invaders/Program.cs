// See https://aka.ms/new-console-template for more information
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using Space_Invaders;

Console.WriteLine("Hello, Juniors!");
Console.WriteLine("Space invaders game");

RenderWindow window = new RenderWindow(new VideoMode(640, 480), "Space Invaders!");

CircleShape player = new CircleShape(10);
Vector2f playerPosition = new Vector2f(30, 380);
player.Position = playerPosition;

const int SPEED = 100;
const int LASER_SPEED = 300;

RectangleShape laser = new RectangleShape(new SFML.System.Vector2f(3, 20));
var laserPosition = new SFML.System.Vector2f(0, 0);
laser.FillColor = Color.Yellow;
var shooting = false;

var enemies = new Enemy[19 * 6];

for (var index = 0; index < enemies.Length; index++)
{
    int row = index / 19;
    int column = index % 19;
    enemies[index] = new Enemy(new SFML.System.Vector2f(30 + (20 + 10) * column, 80 + (20 + 10) * row));
}

var clock = new Clock();

float elapsedTime = 0.0f;

while (true)
{
    var deltaTime = clock.Restart().AsSeconds();

    elapsedTime += deltaTime;
    //player.Position = new SFML.System.Vector2f(player.Position.X + 5, player.Position.Y);
    if (Keyboard.IsKeyPressed(Keyboard.Key.Left) && playerPosition.X >= 10)
    {
        playerPosition.X -= SPEED * deltaTime;
        player.Position = playerPosition;
    } else if (Keyboard.IsKeyPressed(Keyboard.Key.Right) && playerPosition.X <= (640 - 20 - 10))
    {
        playerPosition.X += SPEED * deltaTime;
        player.Position = playerPosition;
    } else if (Keyboard.IsKeyPressed(Keyboard.Key.Space) && !shooting)
    {
        shooting = true;
        laserPosition = new SFML.System.Vector2f(playerPosition.X + 10 - (3.0f / 2), playerPosition.Y);
    }

    if (shooting)
    {
        laserPosition.Y -= LASER_SPEED * deltaTime;
        laser.Position = laserPosition;

        for (var index = 0; index < enemies.Length; index++)
        {
            if (enemies[index].laserCollide(laserPosition))
            {
                shooting = false;
            }

            if ( ((int)elapsedTime) % 5 == 0)
            {
                enemies[index].shoot();
            }

            if (enemies[index].isShooting)
            {
                enemies[index].laser.Position = new Vector2f(enemies[index].laser.Position.X, enemies[index].laser.Position.Y + LASER_SPEED * deltaTime);
            }
        }

        if (laserPosition.Y < 0)
        {
            shooting = false;
        }
    }
    window.Clear();
    window.Draw(player);
    for (var index = 0; index < enemies.Length; index++)
    {
        if (enemies[index].isAlive)
        {
            window.Draw(enemies[index].shape);
        }
        if (enemies[index].isShooting)
        {
            window.Draw(enemies[index].laser);
        }
    }
    if (shooting)
    {
        window.Draw(laser);
    }
    window.DispatchEvents();
    window.Display();
}


Console.ReadLine();
