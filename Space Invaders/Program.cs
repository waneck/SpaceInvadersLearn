// See https://aka.ms/new-console-template for more information
using SFML.Graphics;
using SFML.Window;

Console.WriteLine("Hello, Juniors!");
Console.WriteLine("Space invaders game");

var window = new RenderWindow(new VideoMode(640, 480), "Space Invaders!");

var circle = new SFML.Graphics.CircleShape(10);
circle.Position = new SFML.System.Vector2f(30, 380);

window.Draw(circle);
window.Display();

const int SPEED = 5;

var laser = new SFML.Graphics.RectangleShape(new SFML.System.Vector2f(3, 20));
laser.FillColor = Color.Yellow;
var shooting = false;

while (true)
{
    //circle.Position = new SFML.System.Vector2f(circle.Position.X + 5, circle.Position.Y);
    if (Keyboard.IsKeyPressed(Keyboard.Key.Left) && circle.Position.X >= 10)
    {
        circle.Position = new SFML.System.Vector2f(circle.Position.X - SPEED, circle.Position.Y);
    } else if (Keyboard.IsKeyPressed(Keyboard.Key.Right) && circle.Position.X <= (640 - 20 - 10))
    {
        circle.Position = new SFML.System.Vector2f(circle.Position.X + SPEED, circle.Position.Y);
    } else if (Keyboard.IsKeyPressed(Keyboard.Key.Space) && !shooting)
    {
        shooting = true;
        laser.Position = new SFML.System.Vector2f(circle.Position.X + 10 - (3.0f / 2), circle.Position.Y);
    }

    if (shooting)
    {
        laser.Position = new SFML.System.Vector2f(laser.Position.X, laser.Position.Y - 10);
        if (laser.Position.Y < 0)
        {
            shooting = false;
        }
    }
    window.Clear();
    window.Draw(circle);
    if (shooting)
    {
        window.Draw(laser);
    }
    window.Display();
    System.Threading.Thread.Sleep(1000 / 60);
}


Console.ReadLine();
