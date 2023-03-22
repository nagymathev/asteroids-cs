using Raylib_cs;

namespace Asteroids;

static class Asteroids
{
    public static void Main()
    {
        Raylib.InitWindow(800, 480, "Hello World");

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.BLACK);
            Raylib.EndDrawing();
        }
        Raylib.CloseWindow();
    }
}