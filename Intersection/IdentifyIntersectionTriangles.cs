using TriangleIntersection.Geometry;

namespace TriangleIntersection.Intersection
{
  internal static class IdentifyIntersectionTriangles
  {
    public static bool IsIntersection(Triangle triangleA, Triangle triangleB)
    {
      if (IdentifyIntersectionVertexes.IsIntersection(triangleA, triangleB))
        return true;

      if (RaysTriangleIntersection(triangleA, triangleB))
        return true;

      if (RaysTriangleIntersection(triangleB, triangleA))
        return true;

      return false;
    }

    private static bool RaysTriangleIntersection(Triangle triangleA, Triangle triangleB)
    {
      var length = -1.0;

      var rayAB = triangleA.B - triangleA.A;
      var rayBC = triangleA.C - triangleA.B;
      var rayCA = triangleA.A - triangleA.C;

      var normalRayAB = rayAB.Normalize();
      var normalRayBC = rayBC.Normalize();
      var normalRayCA = rayCA.Normalize();

      if (RayTriangleIntersection(normalRayAB, triangleB, out length) && IsBelongsTriangle(length, rayAB))
        return true;

      if (RayTriangleIntersection(normalRayBC, triangleB, out length) && IsBelongsTriangle(length, rayBC))
        return true;

      if (RayTriangleIntersection(normalRayCA, triangleB, out length) && IsBelongsTriangle(length, rayCA))
        return true;

      return false;
    }

    private static bool RayTriangleIntersection(Vector ray, Triangle triangle, out double rayT)
    {
      rayT = -1;

      var edgeAB = triangle.B - triangle.A;
      var edgeAC = triangle.C - triangle.A;

      var rayDirection = Point.RadiusVector(ray.Direction).Free;

      var subDeterminat = VectorFree.VectorProduct(rayDirection, edgeAC);
      var determinat = edgeAB * subDeterminat;

      if (Сomparison.IsEquals(determinat, 0))
        return false;

      var originRayToTrangleA = ray.Origin - triangle.A;
      var baryU = (originRayToTrangleA * subDeterminat) / determinat;

      if (baryU < 0 || Сomparison.IsMore(baryU, 1))
        return false;

      var subToCalculateBaryV = VectorFree.VectorProduct(originRayToTrangleA, edgeAB);
      var baryV = (rayDirection * subToCalculateBaryV) / determinat;

      if (baryV < 0 || Сomparison.IsMore(baryU + baryV, 1))
        return false;

      rayT = (edgeAC * subToCalculateBaryV) / determinat;

      return true;
    }

    private static bool IsBelongsTriangle(double length, Vector edge)
    {
      return length >= 0 && Сomparison.IsLessOrEquals(length, edge.Length);
    }

  }
}
