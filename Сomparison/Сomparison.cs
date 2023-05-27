using System;

namespace TriangleIntersection
{
  internal static class Сomparison
  {
    private static readonly double EPSILON = Double.Epsilon;

    public static bool IsEquals(double lhs, double rhs)
    {
      return Math.Abs(lhs - rhs) <= EPSILON;
    }

    public static bool IsLessOrEquals(double lhs, double rhs)
    {
      return lhs <= rhs + EPSILON;
    }

    public static bool IsMore(double lhs, double rhs)
    {
      return !IsLessOrEquals(lhs, rhs);
    }

    public static bool IsLess(double lhs, double rhs)
    {
      return lhs < rhs + EPSILON;
    }

    public static bool IsMoreOrEquals(double lhs, double rhs)
    {
      return !IsLess(lhs, rhs);
    }

  }
}
