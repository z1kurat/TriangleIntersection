using System.Collections.Generic;

namespace TriangleIntersection.Geometry
{
  internal class Triangle
  {
    private Point _a;
    private Point _b;
    private Point _c;

    public Point A { get { return _a; } }
    public Point B { get { return _b; } }
    public Point C { get { return _c; } }

    public Triangle(Point a, Point b, Point c) 
    {
      _a = a;
      _b = b;
      _c = c;
    }

    #region Functional

    public bool IsValid => _a.IsValid && _b.IsValid && _c.IsValid;

    public Plane GetPlane => new Plane(A, B, C);

    public List<Point> GetPoints()
    {
      var points = new List<Point>
      {
        A,
        B,
        C
      };

      return points;
    }

    #endregion

  }
}
