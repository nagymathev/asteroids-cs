using System.Numerics;
using static System.Single;

namespace Asteroids;

public class GameObject
{
    private Vector2 _position;
    private Vector2 _velocity;
    private Vector2 _forward;
    private float _speed;

    public GameObject(Vector2 pos, float speed)
    {
        _position = pos;
        _speed = speed;
        _velocity = new Vector2(0, 0);
        _forward = new Vector2(0, 1);
    }

    // public Vector2 RotateByDegrees(float deg)
    // {
    //     float _rad = (deg / 180) * Pi;
    //     float _x = _forward.X * Cos(_rad) - _forward.Y * Sin(_rad);
    //     float _y = _forward.X * Sin(_rad) + _forward.Y * Cos(_rad);
    //     return new Vector2(_x, _y);
    // }
    
    public void RotateByDegrees(float deg)
    {
        float _rad = deg * Pi / 180;
        _forward.X = _forward.X * Cos(_rad) - _forward.Y * Sin(_rad);
        _forward.Y = _forward.X * Sin(_rad) + _forward.Y * Cos(_rad);
        _forward = Vector2.Normalize(_forward);
    }

    public Vector2 Position
    {
        get => _position;
        set => _position = value;
    }

    public Vector2 Velocity
    {
        get => _velocity;
        set => _velocity = value;
    }
    
    public Vector2 Forward
    {
        get => _forward;
        set => _forward = value;
    }

    public float Speed
    {
        get => _speed;
        set => _speed = value;
    }
}