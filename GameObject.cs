using System.Numerics;
using static System.Single;

namespace Asteroids;

public class GameObject
{
    public Vector2 Position;
    public Vector2 Velocity;
    public float Angle;
    public float Accelaration;

    public GameObject(Vector2 pos, float accelaration)
    {
        Position = pos;
        Accelaration = accelaration;
        Velocity = new Vector2(0, 0);
        Angle = 0;
    }

    public void RotateByDegrees(float deg)
    {
        float _rad = deg * Pi / 180;
        Angle += _rad;
    }

    public Vector2 Forward
    {
        get => new Vector2(0, -1).RotateAroundPoint(Angle, new Vector2(0, 0));
    }
}