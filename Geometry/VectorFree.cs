using System;

namespace TriangleIntersection.Geometry
{
  internal class VectorFree
  {
    protected Point _direction;

    public Point Direction { get { return _direction; } }

    public VectorFree(Point direction)
    {
      _direction = direction;
    }

    #region Functional

    public double Length => Math.Sqrt(LengthSquared);
    public double LengthSquared => this * this;
    public virtual bool IsValid => _direction.IsValid;

    public static VectorFree VectorProduct(VectorFree lhs, VectorFree rhs)
    {
      var x = lhs.Direction.Y * rhs.Direction.Z - lhs.Direction.Z * rhs.Direction.Y;
      var y = lhs.Direction.Z * rhs.Direction.X - lhs.Direction.X * rhs.Direction.Z;
      var z = lhs.Direction.X * rhs.Direction.Y - lhs.Direction.Y * rhs.Direction.X;

      return new VectorFree(new Point(x, y, z));
    }

    public static bool IsEquals(VectorFree lhs, VectorFree rhs)
    {
      var equalsX = Сomparison.IsEquals(lhs.Direction.X, rhs.Direction.X);
      var equalsY = Сomparison.IsEquals(lhs.Direction.Y, rhs.Direction.Y);
      var equalsZ = Сomparison.IsEquals(lhs.Direction.Z, rhs.Direction.Z);

      return equalsX && equalsY && equalsZ;
    }

    #endregion

    #region Operators

    public static double operator *(VectorFree lhs, VectorFree rhs)
    {
      return lhs.Direction.X * rhs.Direction.X + lhs.Direction.Y * rhs.Direction.Y + lhs.Direction.Z * rhs.Direction.Z;
    }

    public static VectorFree operator *(VectorFree vector, double scal)
    {
      return new VectorFree(vector.Direction * scal);
    }

    public static Point operator +(Point point, VectorFree vector)
    {
      return point + vector.Direction;
    }

    #endregion

    #region Declaration Value

    public static VectorFree ZeroVectorFree => new VectorFree(Point.ZeroPoint);
    public static VectorFree VectorFreeX => new VectorFree(new Point(1, 0, 0));
    public static VectorFree VectorFreeY => new VectorFree(new Point(0, 1, 0));
    public static VectorFree VectorFreeZ => new VectorFree(new Point(0, 0, 1));

    #endregion

  }
}
