using System.Collections.Generic;
using System.Linq;

using TriangleIntersection.Geometry;

namespace TriangleIntersection.Intersection
{
  internal static class IdentifyIntersectionSegment
  {
    private static readonly int IsPoint = 1;

    public static bool IsIntersection(Triangle triangleA, Triangle triangleB)
    {
      var commanPoints = new List<Point>();
      commanPoints.AddRange(triangleA.GetPoints());
      commanPoints.AddRange(triangleB.GetPoints());

      var uniquePointsA = GetUniquePoints(triangleA.GetPoints());
      var uniquePointsB = GetUniquePoints(triangleB.GetPoints());
      var uniqueCommanPoints = GetUniquePoints(commanPoints);

      if (uniquePointsA.Count + uniquePointsB.Count != uniqueCommanPoints.Count)
        return true;

      var segmentPointsA = GetSegmentPoints(uniquePointsA);
      var segmentPointsB = GetSegmentPoints(uniquePointsB);

      if (uniquePointsA.Count == IsPoint)
        return PointToLineSegmentIntersection(uniquePointsA.First(), segmentPointsB);

      if (uniquePointsB.Count == IsPoint)
        return PointToLineSegmentIntersection(uniquePointsB.First(), segmentPointsA);

      return LineToLineSegmentIntersection(segmentPointsA, segmentPointsB);
    }

    #region Preparing points
    private static List<Point> GetUniquePoints(List<Point> points)
    {
      var uniquePoints = new List<Point>();

      foreach (var point in points)
      {
        if (uniquePoints.Exists(x => Point.IsEquals(x, point)))
          continue;

        uniquePoints.Add(point);
      }

      return uniquePoints;
    }

    /// <summary>
    /// Return points start and end segment
    /// </summary>
    /// <param name="points">List all points</param>
    /// <returns></returns>
    private static List<Point> GetSegmentPoints(List<Point> points)
    {
      points.Sort((pointA, pointB) =>
      {
        if (!Сomparison.IsEquals(pointA.Z, pointB.Z))
          return pointA.Z > pointB.Z ? 1 : -1;

        if (!Сomparison.IsEquals(pointA.X, pointB.X))
          return pointA.X > pointB.X ? 1 : -1;

        if (!Сomparison.IsEquals(pointA.Y, pointB.Y))
          return pointA.Y > pointB.Y ? 1 : -1;

        return 0;
      });

      var min = points.First();
      var max = points.Last();

      return new List<Point> { min, max };
    }

    #endregion

    #region Point to line segment intersection

    private static bool PointToLineSegmentIntersection(Point point, List<Point> pointsA)
    {
      var origin = pointsA.First();
      var endSegment = pointsA.Last();

      var direction = endSegment - origin;
      var subParametr = point - origin;

      var parametrX = SetParametr(subParametr.Direction.X, direction.Direction.X, out var isZeroToZeroX);
      var parametrY = SetParametr(subParametr.Direction.Y, direction.Direction.Y, out var isZeroToZeroY);
      var parametrZ = SetParametr(subParametr.Direction.Z, direction.Direction.Z, out var isZeroToZeroZ);

      var isEqualsParametr = IsEqualsParametr(parametrX, parametrY, isZeroToZeroX || isZeroToZeroY);
      isEqualsParametr &= IsEqualsParametr(parametrX, parametrZ, isZeroToZeroX || isZeroToZeroZ);
      isEqualsParametr &= IsEqualsParametr(parametrY, parametrZ, isZeroToZeroY || isZeroToZeroZ);

      return isEqualsParametr && IsParametrsBelongsSegment(parametrX, parametrY, parametrZ);
    }

    private static double SetParametr(double numerator, double denominator, out bool isZeroToZero)
    {
      isZeroToZero = false;
      if (Сomparison.IsEquals(numerator, 0) && Сomparison.IsEquals(denominator, 0))
      {
        isZeroToZero = true;
        denominator = 1;
      }

      return numerator / denominator;
    }

    private static bool IsParametrsBelongsSegment(double parametrX, double parametrY, double parametrZ)
    {
      return IsBelongsSegment(parametrX) && IsBelongsSegment(parametrY) && IsBelongsSegment(parametrZ);
    }

    private static bool IsEqualsParametr(double parametrA, double parametrB, bool IsZeroToZero)
    {
      return Сomparison.IsEquals(parametrA, parametrB) || IsZeroToZero;
    }

    #endregion

    #region Line to line segment intersection

    private static bool LineToLineSegmentIntersection(List<Point> pointsA, List<Point> pointsB)
    {
      var p1 = pointsA.First();
      var p2 = pointsA.Last();

      var p3 = pointsB.First();
      var p4 = pointsB.Last();

      var vP13 = p1 - p3;
      var vP43 = p4 - p3;
      var vP21 = p2 - p1;

      var vectorProductDirection = VectorFree.VectorProduct(vP21, vP43);
      var isLineCoDirection = VectorFree.IsEquals(vectorProductDirection, VectorFree.ZeroVectorFree);

      if (isLineCoDirection)
        return LineToLineCoDirectionIntersection(pointsA, pointsB);

      var scalarP13P43 = vP13 * vP43;
      var scalarP43P21 = vP43 * vP21;
      var scalarP13P21 = vP13 * vP21;

      var scalarP43P43 = vP43 * vP43;
      var scalarP21P21 = vP21 * vP21;

      var parametrFirstSegment = (scalarP13P43 * scalarP43P21 - scalarP13P21 * scalarP43P43) / (scalarP21P21 * scalarP43P43 - scalarP43P21 * scalarP43P21);
      var parametrSecondSegment = (scalarP13P43 + parametrFirstSegment * scalarP43P21) / scalarP43P43;

      var pA = p1 + vP21 * parametrFirstSegment;
      var pB = p3 + vP43 * parametrSecondSegment;
      var vAB = pB - pA;

      return IsBelongsSegment(parametrFirstSegment) && IsBelongsSegment(parametrSecondSegment) && Сomparison.IsEquals(vAB.LengthSquared, 0);
    }

    private static bool LineToLineCoDirectionIntersection(List<Point> pointsA, List<Point> pointsB)
    {
      var isLineLiesToB = PointToLineSegmentIntersection(pointsA.First(), pointsB) || PointToLineSegmentIntersection(pointsA.Last(), pointsB);
      if (isLineLiesToB)
        return true;
      
      var isLineLiesToA = PointToLineSegmentIntersection(pointsB.First(), pointsA) || PointToLineSegmentIntersection(pointsB.Last(), pointsA);
      if (isLineLiesToA)
        return true;

      return false;
    }

    private static bool IsBelongsSegment(double parametr)
    {
      return parametr >= 0 && Сomparison.IsLessOrEquals(parametr, 1);
    }

    #endregion

  }
}
