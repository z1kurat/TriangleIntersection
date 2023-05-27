using System;
using System.Windows;

namespace TriangleIntersection.Geometry
{
  internal class Point
  {
    private double _x;
    private double _y;
    private double _z;

    public bool IsValid;

    public double X { get { return _x; } }
    public double Y { get { return _y; } }
    public double Z { get { return _z; } }

    public Point(double x, double y, double z, bool isValid = true)
    {
      _x = x;
      _y = y;
      _z = z;

      IsValid = isValid;
    }

    #region Operators

    public static Vector operator -(Point end, Point start)
    {
      var origin = start;
      var direction = new Point(end.X - start.X, end.Y - start.Y, end.Z - start.Z);

      return new Vector(origin, direction);
    }

    public static Point operator +(Point lhs, Point rhs)
    {
      return new Point(lhs.X + rhs.X, lhs.Y + rhs.Y, lhs.Z + rhs.Z);
    }

    public static Point operator /(Point point, double scal)
    {
      if (scal == 0)
        return UnsetPoint;

      return new Point(point.X / scal, point.Y / scal, point.Z / scal);
    }

    public static Point operator *(Point point, double scal)
    {
      return new Point(point.X * scal, point.Y * scal, point.Z * scal);
    }

    #endregion

    #region Functional

    public static Vector RadiusVector(Point point)
    {
      return point - ZeroPoint;
    }

    public static bool IsEquals(Point pointA, Point pointB)
    {
      var isEqualsX = Сomparison.IsEquals(pointA.X, pointB.X);
      var isEqualsY = Сomparison.IsEquals(pointA.Y, pointB.Y);
      var isEqualsZ = Сomparison.IsEquals(pointA.Z, pointB.Z);

      return isEqualsX && isEqualsY && isEqualsZ;
    }

    #endregion

    #region Declaration Value

    public static Point UnsetPoint => new Point(Double.NaN, Double.NaN, Double.NaN, false);

    public static Point ZeroPoint => new Point(0, 0, 0);
    
    #endregion

  }
}
