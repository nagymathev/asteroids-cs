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
        
        float SpawnTimer = 0.0f;
        List<GameObject> Asteroids = new List<GameObject>();
        
        float ShootTimer = 0.0f;
        List<GameObject> Bullets = new List<GameObject>();

        while (!WindowShouldClose())
        {
            SpawnTimer += GetFrameTime();
            ShootTimer += GetFrameTime();
            if (SpawnTimer >= 3.0f)
            {
                GameObject asteroid = new GameObject(new Vector2(GetRandomValue(0, GetScreenWidth()), GetRandomValue(0, GetScreenHeight())),
                    10.0f);
                asteroid.Velocity = new Vector2(GetRandomValue(-10, 10), GetRandomValue(-10, 10));
                Asteroids.Add(asteroid);
                SpawnTimer = 0.0f;
            }

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
            if (IsKeyDown(KEY_SPACE))
            {
                if (ShootTimer >= 0.5f)
                {
                    GameObject bullet = new GameObject(player.Position, 10.0f);
                    bullet.Velocity = player.Forward * 100;
                    Bullets.Add(bullet);
                    ShootTimer = 0.0f;
                }
            }
            player.Velocity = Vector2.Clamp(player.Velocity, new Vector2(-10, -10), new Vector2(10, 10));
            player.Position += player.Velocity * player.Accelaration * GetFrameTime();
            Vector2[] points = CreateTrianglePoints(player.Position, 50.0f);
            points = points.RotatePointsAroundPoint(player.Position, player.Angle);

            foreach (var asteroid in Asteroids)
            {
                asteroid.Position += asteroid.Velocity * asteroid.Accelaration * GetFrameTime();
            }

            var A = Asteroids;
            var B = Bullets;
            foreach (var asteroid in A)
            {
                foreach (var bullet in B)
                {
                    if (CheckCollisionCircles(asteroid.Position, 20.0f, bullet.Position, 5.0f))
                    {
                        A.Remove(asteroid);
                        B.Remove(bullet);
                        break;
                    }
                }
                break;
            }
            Asteroids = A;
            Bullets = B;

            BeginDrawing();
                ClearBackground(Color.BLACK);
                foreach (var asteroid in Asteroids)
                {
                    DrawCircleV(asteroid.Position, 20.0f, Color.GRAY);
                }
                foreach (var bullet in Bullets)
                {
                    bullet.Position += bullet.Velocity * bullet.Accelaration * GetFrameTime();
                    DrawCircleV(bullet.Position, 5.0f, Color.YELLOW);
                }
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