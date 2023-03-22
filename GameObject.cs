using System.Numerics;

namespace Asteroids;

public class GameObject
{
    private Vector2 _position;
    private Vector2 _direction;
    private Vector2 _forward;
    private float _speed;

    public Vector2 Position
    {
        get => _position;
        set => _position = value;
    }

    public Vector2 Direction
    {
        get => _direction;
        set => _direction = value;
    }

    public Vector2 Forward => _forward;

    public float Speed
    {
        get => _speed;
        set => _speed = value;
    }
}