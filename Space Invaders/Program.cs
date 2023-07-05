// See https://aka.ms/new-console-template for more information
using SFML.Graphics;
using SFML.System;
using SFML.Window;

Console.WriteLine("Hello, Juniors!");
Console.WriteLine("Space invaders game");

var window = new RenderWindow(new VideoMode(640, 480), "Space Invaders!");

var player = new SFML.Graphics.CircleShape(10);
var playerPosition = new SFML.System.Vector2f(30, 380);
player.Position = playerPosition;

const int SPEED = 100;
const int LASER_SPEED = 300;

var laser = new SFML.Graphics.RectangleShape(new SFML.System.Vector2f(3, 20));
var laserPosition = new SFML.System.Vector2f(0, 0);
laser.FillColor = Color.Yellow;
var shooting = false;

var enemy = new SFML.Graphics.RectangleShape(new SFML.System.Vector2f(20, 20));
var enemyPosition = new SFML.System.Vector2f(30, 80);
enemy.Position = enemyPosition;
enemy.FillColor = Color.Red;

var clock = new Clock();

while (true)
{
    var deltaTime = clock.Restart().AsSeconds();
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

        if (laserPosition.Y <= (enemyPosition.Y + enemy.Size.Y) && 
            laserPosition.Y >= enemyPosition.Y &&
            laserPosition.X <= (enemyPosition.X + enemy.Size.X) &&
            laserPosition.X >= enemyPosition.X)
        {
            enemyPosition.X = -100;
            enemyPosition.Y = -100;
            enemy.Position = enemyPosition;
            shooting = false;
        }

        if (laserPosition.Y < 0)
        {
            shooting = false;
        }
    }
    window.Clear();
    window.Draw(player);
    window.Draw(enemy);
    if (shooting)
    {
        window.Draw(laser);
    }
    window.DispatchEvents();
    window.Display();
}


Console.ReadLine();
