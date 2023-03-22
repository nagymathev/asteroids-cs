using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;
using static Raylib_cs.KeyboardKey;

namespace Asteroids;

static class Asteroids
{
    public static void Main()
    {
        InitWindow(800, 480, "Asteroids");

        GameObject player = new GameObject(new Vector2(GetScreenWidth() / 2, GetScreenHeight() / 2), 10.0f);

        while (!WindowShouldClose())
        {
            if (IsKeyDown(KEY_W)) player.Velocity -= player.Forward * player.Speed * GetFrameTime();
            if (IsKeyDown(KEY_S)) player.Velocity += player.Forward * player.Speed * GetFrameTime();
            if (IsKeyDown(KEY_A)) player.RotateByDegrees(-100 * GetFrameTime());
            if (IsKeyDown(KEY_D)) player.RotateByDegrees(100 * GetFrameTime());
            player.Velocity = Vector2.Clamp(player.Velocity, new Vector2(-10, -10), new Vector2(10, 10));
            player.Position += player.Velocity * player.Speed * GetFrameTime();
            
            BeginDrawing();
                ClearBackground(Color.BLACK);
                DrawCircleV(player.Position, 2.0f, Color.BLUE);
                DrawText(player.Forward.ToString(), 100, 100, 15, Color.GRAY);
                DrawLineV(player.Position, player.Position - player.Forward * 25, Color.RED);
                DrawTriangleLines(
                    player.Position - new Vector2(0, 30),
                    player.Position + new Vector2(-15, 25),
                    player.Position + new Vector2(15, 25),
                    Color.GOLD
                    );
            
            EndDrawing();
        }
        CloseWindow();
    }
}