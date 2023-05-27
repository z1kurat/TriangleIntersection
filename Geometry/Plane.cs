

namespace TriangleIntersection.Geometry
{
  internal class Plane
  {
    private Point _origin;
    private VectorFree _normal;

    public Point Origin { get { return _origin; } }
    public VectorFree Normal { get { return _normal;} }

    public Plane(Point a, Point b, Point c)
    {
      var AB = b - a;
      var BC = c - a;

      _origin = b;
      _normal = VectorFree.VectorProduct(AB.Free, BC.Free);
    }

    #region Functional

    public bool IsPointOnPlane(Point point)
    {
      var vectorOnPlane = point - _origin;
      var scalarProduct = vectorOnPlane.Free * _normal;
      
      return Сomparison.IsEquals(scalarProduct, 0);
    }

    public static Status MutualArrangementPlanes(Plane lhs, Plane rhs)
    {
      var normalPlaneA = lhs.Normal;
      var normalPlaneB = rhs.Normal;

      if (VectorFree.IsEquals(normalPlaneA, VectorFree.ZeroVectorFree) && VectorFree.IsEquals(normalPlaneB, VectorFree.ZeroVectorFree))
        return Status.IsBothPaneDegenerate;

      if (VectorFree.IsEquals(normalPlaneA, VectorFree.ZeroVectorFree) && VectorFree.IsEquals(normalPlaneB, VectorFree.ZeroVectorFree))
        return Status.IsOnePaneDegenerate;

      var vectorProduct = VectorFree.VectorProduct(normalPlaneA, normalPlaneB);
      var isCoDirected = VectorFree.IsEquals(vectorProduct, VectorFree.ZeroVectorFree);

      if (!isCoDirected)
        return Status.IsPlaneIntersect;

      var existCommonPoint = lhs.IsPointOnPlane(rhs.Origin);

      if (existCommonPoint)
        return Status.IsPaneMatch;

      return Status.IsPlaneParallel;
    }

    #endregion
  }
}
