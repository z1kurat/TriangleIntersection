using System.Collections.Generic;
using System.Linq;

using TriangleIntersection.Geometry;

namespace TriangleIntersection.Intersection
{
  internal static class TrianglesIntersection
  {
    private static readonly int COORDINATES_COUNT = 18;

    static public bool AreIntersected(double[] coordinates)
    {
      if (!IsCorrectCoordinates(coordinates))
        return false;

      var triangleA = GetTriangle(Enumerable.Range(0, coordinates.Length / 2).Select(i => coordinates[i]).ToList());
      var triangleB = GetTriangle(Enumerable.Range(coordinates.Length / 2, coordinates.Length / 2).Select(i => coordinates[i]).ToList());

      var planeTriangleA = triangleA.GetPlane;
      var planeTriangleB = triangleB.GetPlane;

      switch (Plane.MutualArrangementPlanes(planeTriangleA, planeTriangleB))
      {
        case Status.IsPlaneParallel: 
          return false;

        case Status.IsBothPaneDegenerate:
          return IdentifyIntersectionSegment.IsIntersection(triangleA, triangleB);

        case Status.IsPaneMatch:
        case Status.IsPlaneIntersect:
        case Status.IsOnePaneDegenerate:
          return IdentifyIntersectionTriangles.IsIntersection(triangleA, triangleB);

        default: return false;
      }

    }

    private static Triangle GetTriangle(List<double> coordinates)
    {
      //with a cycle, it would be much worse...
      var a = new Point(coordinates[0], coordinates[1], coordinates[2]);
      var b = new Point(coordinates[3], coordinates[4], coordinates[5]);
      var c = new Point(coordinates[6], coordinates[7], coordinates[8]);

      return new Triangle(a, b, c);
    }

    private static bool IsCorrectCoordinates(double[] coordinates)
    {
      return coordinates.Length == COORDINATES_COUNT;
    }

  }
}
