using System.Collections.Generic;

using TriangleIntersection.Geometry;

namespace TriangleIntersection.Intersection
{
  internal static class IdentifyIntersectionVertexes
  {
    public static bool IsIntersection(Triangle triangleA, Triangle triangleB)
    {
      if (PointsTriangleIntersection(triangleA.GetPoints(), triangleB))
        return true;

      if (PointsTriangleIntersection(triangleB.GetPoints(), triangleA))
        return true;

      return false;
    }

    private static bool PointsTriangleIntersection(List<Point> points, Triangle triangleB)
    {
      var plane = triangleB.GetPlane;

      foreach (var point in points)
      {
        if (plane.IsPointOnPlane(point) && PointBelongTriangle(point, triangleB))
        {
          return true;
        }
      }

      return false;
    }

    private static bool PointBelongTriangle(Point point, Triangle triangle)
    {
      var edgeAB = triangle.B - triangle.A;
      var edgeAC = triangle.C - triangle.A;
      var edgeAP = point - triangle.A;
      var edgeCP = point - triangle.C;

      var normal = triangle.GetPlane.Normal;

      var areaABP = Vector.VectorProduct(edgeAB, edgeAP) * normal;
      var areaABC = normal * normal;

      var baryV = areaABP / areaABC;

      if (baryV < 0 || Сomparison.IsMore(baryV, 1))
        return false;

      var areaCAP = Vector.VectorProduct(edgeAC, edgeCP) * normal;
      var baryU = - areaCAP / areaABC;

      if (baryU < 0 || Сomparison.IsMore(baryU + baryV, 1))
        return false;

      return true;
    }

  }
}
