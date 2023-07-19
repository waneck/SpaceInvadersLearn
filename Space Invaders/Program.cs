// See https://aka.ms/new-console-template for more information
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using Space_Invaders;

Console.WriteLine("Hello, Juniors!");
Console.WriteLine("Space invaders game");

RenderWindow window = new RenderWindow(new VideoMode(640, 480), "Space Invaders!");


var level = new Level(new Vector2f(640, 480));
var clock = new Clock();

while (true)
{
    var deltaTime = clock.Restart().AsSeconds();

    level.Update(deltaTime);

    window.Clear();
    level.Draw(window);
    window.DispatchEvents();
    window.Display();
}


Console.ReadLine();
