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
            

            if (IsKeyDown(KEY_W)) player.Velocity += player.Forward * player.Accelaration * GetFrameTime();
            if (IsKeyDown(KEY_S)) player.Velocity -= player.Forward * player.Accelaration * GetFrameTime();
            if (IsKeyDown(KEY_A))
            {
                player.RotateByDegrees(-100 * GetFrameTime());
            }

            if (IsKeyDown(KEY_D))
            {
                player.RotateByDegrees(100 * GetFrameTime());
            }
            player.Velocity = Vector2.Clamp(player.Velocity, new Vector2(-10, -10), new Vector2(10, 10));
            player.Position += player.Velocity * player.Accelaration * GetFrameTime();
            Vector2[] points = CreateTrianglePoints(player.Position, 50.0f);
            points = points.RotatePointsAroundPoint(player.Position, player.Angle);

            BeginDrawing();
                ClearBackground(Color.BLACK);
                DrawCircleV(player.Position, 2.0f, Color.BLUE);
                DrawText(player.Forward.ToString(), 100, 100, 15, Color.GRAY);
                DrawLineV(player.Position, player.Position + player.Forward * 25, Color.RED);
                DrawTriangleLines(
                    points[0], points[1], points[2],
                    Color.LIME
                );
                DrawText(player.Velocity.Length().ToString() + "m/s", 200, 25, 13, Color.VIOLET);
                DrawText(player.Angle.ToString() + "deg", 200, 50, 13, Color.VIOLET);
            EndDrawing();
        }
        CloseWindow();
    }

    public static Vector2[] CreateTrianglePoints(Vector2 pos, float size)
    {
        Vector2[] points = new Vector2[3];
        points[0] = pos - new Vector2(0, size);
        points[1] = pos + new Vector2(-size / 2, size / 2);
        points[2] = pos + new Vector2(size / 2, size / 2);
        return points;
    }
}