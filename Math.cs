using System.Numerics;
using System.Reflection;
using static System.Single;

namespace Asteroids;

public static class Math
{
    public static Vector2 RotateAroundPoint(this Vector2 point, float _rad, Vector2 origin)
    {
        Vector2 delta = point - origin;
        float _x = delta.X * Cos(_rad) - delta.Y * Sin(_rad) + origin.X;
        float _y = delta.X * Sin(_rad) + delta.Y * Cos(_rad) + origin.Y;
        return new Vector2(_x, _y);
    }
    
    public static Vector2[] RotatePointsAroundPoint(this Vector2[] points, Vector2 origin, float deg)
    {
        Vector2[] newPoints = new Vector2[points.Length];
        for (int i = 0; i < points.Length; i++)
        {
            newPoints[i] = RotateAroundPoint(points[i], deg, origin);
        }
        return newPoints;
    }
}