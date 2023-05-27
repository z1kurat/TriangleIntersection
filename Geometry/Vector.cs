

namespace TriangleIntersection.Geometry
{
  internal class Vector : VectorFree
  {
    private Point _origin;

    public Point Origin { get { return _origin; } }

    public Vector(Point origin, Point direction) : base(direction)
    {
      _origin = origin;
    }

    #region Functional

    public override bool IsValid => _origin.IsValid && _direction.IsValid;
    public VectorFree Free => new VectorFree(_direction);

    public Vector Normalize()
    {
      var normalizeDirection = _direction / Length;
      if (!normalizeDirection.IsValid)
        return new Vector(Point.UnsetPoint, Point.UnsetPoint);

        return new Vector(_origin, normalizeDirection);
    }

    #endregion
  }
}
