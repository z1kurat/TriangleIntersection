using System;

using TriangleIntersection.Intersection;

namespace TriangleIntersection
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Test();
      Console.ReadKey();
    }

    static void Test()
    {
      // Is Plane Intersect
      Console.WriteLine("Test1 " + (TrianglesIntersection.AreIntersected(new double[] { 1, 1, 1, 4, 5, 1, 4, 1, 1, 2, 0, 1, 2, 5, 1, 4, 3, 10 }) ? "OK\n" : "Error\n"));
      // Is Pane Match
      Console.WriteLine("Test2 " + (TrianglesIntersection.AreIntersected(new double[] { 1, 1, 1, 4, 5, 1, 4, 1, 1, 4, 1, 1, 4, 5, 1, 10, 2, 5 }) ? "OK\n" : "Error\n"));
      // Is Plane Intersect
      Console.WriteLine("Test3 " + (TrianglesIntersection.AreIntersected(new double[] { 1, 1, 1, 4, 5, 1, 4, 1, 1, 4, 1, 1, 5, 5, 1, 10, 2, 2 }) ? "OK\n" : "Error\n"));
      // Is Plane Parallel
      Console.WriteLine("Test4 " + (TrianglesIntersection.AreIntersected(new double[] { 1, 1, 1, 4, 5, 2, 4, 1, 1, 4, 1, 5, 5, 5, 8, 10, 2, 9 }) ? "Error\n" : "OK\n"));
      // Is Pane Match
      Console.WriteLine("Test5 " + (TrianglesIntersection.AreIntersected(new double[] { 1, 2, 1, 4, 2, 5, 4, 2, 1, 15, 2, 2, 5, 2, 5, 17, 2, 29 }) ? "Error\n" : "OK\n"));
      // Is Pane Match
      Console.WriteLine("Test6 " + (TrianglesIntersection.AreIntersected(new double[] { 1, 1, 1, 2, 2, 2, 3, 3, 3, 15, 2, 2, 5, 2, 5, 17, 2, 29 }) ? "Error\n" : "OK\n"));
      //  Is Pane Degenerate
      Console.WriteLine("Test7 " + (TrianglesIntersection.AreIntersected(new double[] { 1, 1, 1, 2, 2, 2, 3, 3, 3, 8, 8, 8, 9, 9, 9, 10, 10, 10 }) ? "Error\n" : "OK\n"));
      //  Is Pane Degenerate
      Console.WriteLine("Test8 " + (TrianglesIntersection.AreIntersected(new double[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 8, 8, 8, 9, 9, 9, 10, 10, 10 }) ? "Error\n" : "OK\n"));
      //  Is Pane Degenerate
      Console.WriteLine("Test9 " + (TrianglesIntersection.AreIntersected(new double[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 9, 9, 9, 10, 10, 10 }) ? "OK\n" : "Error\n"));
      // Is Plane Intersect
      Console.WriteLine("Test10 " + (TrianglesIntersection.AreIntersected(new double[] { 0, 0, 0, 0, 5, 0, 8, 0, 0, 6, -4, -2, 6, 8, 3, 6, 8, -2}) ? "OK\n" : "Error\n"));
      // Is Plane Intersect
      Console.WriteLine("Test11 " + (TrianglesIntersection.AreIntersected(new double[] { 0, 0, 0, 0, 5, 0, 3, 0, 0, 6, -4, -2, 6, 8, 3, 6, 8, -2}) ? "Error\n" : "OK\n"));
      // Is Plane Intersect
      Console.WriteLine("Test12 " + (TrianglesIntersection.AreIntersected(new double[] { 1, 1, 1, 0, 2, 5, 3, -1, 4, 1, 1, 1, 3, -1, 4, 4, 2, 1}) ? "OK\n" : "Error\n"));
      // Is Pane Match
      Console.WriteLine("Test13 " + (TrianglesIntersection.AreIntersected(new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1 }) ? "Error\n" : "OK\n"));
      // Is Pane Match
      Console.WriteLine("Test14 " + (TrianglesIntersection.AreIntersected(new double[] { -5, 0, 0, 0.1, 3, 0, 2, -6, 5, 2, -6, 5, -5, 0, 0, -3.03, -5.92, 3.5}) ? "OK\n" : "Error\n"));
      // Is Pane Match
      Console.WriteLine("Test15 " + (TrianglesIntersection.AreIntersected(new double[] { -5, 0, 0, 0.1, 3, 0, 2, -6, 5, -5, 0, 0, -3.03, -5.92, 3.5, -8.22, -1.99, 0.05}) ? "OK\n" : "Error\n"));
      // Is Pane Match
      Console.WriteLine("Test16 " + (TrianglesIntersection.AreIntersected(new double[] { -5, 0, 0, 0.1, 3, 0, 2, -6, 5, -2.39, -9.26, 5.34, -5.54, -0.41, 0.04, -6.12, -5.44, 2.36}) ? "Error\n" : "OK\n"));
      // Is Pane Parallel
      Console.WriteLine("Test17 " + (TrianglesIntersection.AreIntersected(new double[] { -5, 0, 0, 0.1, 3, 0, 2, -6, 5, -5, 0, 1, 0.1, 3, 1, 2, -6, 6 }) ? "Error\n" : "OK\n"));
      // Is Pane Match
      Console.WriteLine("Test18 " + (TrianglesIntersection.AreIntersected(new double[] { -5, 0, 0, 0.1, 3, 0, 2, -6, 5, 0.1, 3, 0, 2, -6, 5, 1.18, -2.13, 2.85 }) ? "OK\n" : "Error\n"));
      // Is Pane Degenerate
      Console.WriteLine("Test19 " + (TrianglesIntersection.AreIntersected(new double[] { -5, 0, 0, 0.1, 3, 0, 2, -6, 5, -0.52, -1.27, 1.93, -0.52, -1.27, 1.93, -0.52, -1.27, 1.93 }) ? "Error\n" : "Ok\n"));
      // Is Plane Intersect
      Console.WriteLine("Test20 " + (TrianglesIntersection.AreIntersected(new double[] { -5, 0, 0, 0.1, 3, 0, 2, -6, 5, -5, 0, 1, 0.1, 3, 1, 1.5, 1.5, 2.5 }) ? "Error\n" : "OK\n"));
      // Is Pane Degenerate
      Console.WriteLine("Test21 " + (TrianglesIntersection.AreIntersected(new double[] { 1, 1, 1, 4, 5, 1, 4, 1, 1, 0, 0, 0, 1, 1, 1, 2, 2, 2 }) ? "OK\n" : "Error\n"));
      // Is Pane Degenerate
      Console.WriteLine("Test22 " + (TrianglesIntersection.AreIntersected(new double[] { 1, 2, 3, 4, 2, 5, 4, 2, 1, 3, 2, 3, 3, 2, 3, 3, 2, 3 }) ? "OK\n" : "Error\n"));
      // Is Pane Intersect
      Console.WriteLine("Test23 " + (TrianglesIntersection.AreIntersected(new double[] { 1, 2, 3, 4, 2, 5, 4, 2, 1, 3, 2, 3, 4, 3, 5, 4, 3, 2 }) ? "OK\n" : "Error\n"));
      // Is Pane Intersect
      Console.WriteLine("Test24 " + (TrianglesIntersection.AreIntersected(new double[] { 1, 2, 3, 4, 2, 5, 4, 2, 1, 3, 2, 10, 4, 3, 5, 4, 3, 2 }) ? "Error\n" : "OK\n"));
      // Is Pane Intersect
      Console.WriteLine("Test25 " + (TrianglesIntersection.AreIntersected(new double[] { 0.19344, 0.80494, 0.39276, 0.34754, 0.99968, 0.25362, 0.64816, 0.19478, 0.06675, 0.45370, 0.98502, 0.32804, 0.43745, 0.32572, 0.11317, 0.91430, 0.30600, 0.46486 }) ? "OK\n" : "Error\n"));
      // Is Pane Intersect
      Console.WriteLine("Test26 " + (TrianglesIntersection.AreIntersected(new double[] { 0.22563, 0.01906, 0.69866, 0.26814, 0.13577, 0.45518, 0.72768, 0.91179, 0.22990, 0.96529, 0.02128, 0.11582, 0.90725, 0.11045, 0.36959, 0.19672, 0.23977, 0.65370 }) ? "OK\n" : "Error\n"));
      // Is Pane Intersect
      Console.WriteLine("Test27 " + (TrianglesIntersection.AreIntersected(new double[] { 0, 0, 0, 2, 0, 0, 0, 0, 2, 0, 0, 1, 2, 0, 1, 0, 0, -3 }) ? "OK\n" : "Error\n"));
      // Is Pane Intersect
      Console.WriteLine("Test28 " + (TrianglesIntersection.AreIntersected(new double[] { 0, 0, 0, 2, 0, 1, 0, 2, 2, 0, 0, 0, -2, 0, 0, 0, -2, 0 }) ? "OK\n" : "Error\n"));
      // Is Pane Intersect
      Console.WriteLine("Test29 " + (TrianglesIntersection.AreIntersected(new double[] { 1, 1, 0, 2, 2, 0, 2, 2, 0, 0, 0, 0, 5, 0, 0, 0, 5, 0 }) ? "OK\n" : "Error\n"));
      // Is Pane Intersect
      Console.WriteLine("Test30 " + (TrianglesIntersection.AreIntersected(new double[] { 1, 1, 0, 1, 1, 0, 1, 1, 0, 0, 0, 0, 3, 0, 0, 0, 3, 0 }) ? "OK\n" : "Error\n"));
      // Is Pane Degenerate
      Console.WriteLine("Test31 " + (TrianglesIntersection.AreIntersected(new double[] { 0, 0, 0, 2, 2, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1 }) ? "OK\n" : "Error\n"));
      // Is Pane Degenerate
      Console.WriteLine("Test32 " + (TrianglesIntersection.AreIntersected(new double[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }) ? "OK\n" : "Error\n"));
      // Is Pane Degenerate
      Console.WriteLine("Test33 " + (TrianglesIntersection.AreIntersected(new double[] { 1, 1, 1, -1, -1, -1, -1, -1, -1, 2, 2, 2, 5, 5, 5, 5, 5, 5 }) ? "Error\n" : "OK\n"));
      // Is Pane Degenerate
      Console.WriteLine("Test34 " + (TrianglesIntersection.AreIntersected(new double[] { 1, 1, 1, -1, -1, -1, -1, -1, -1, -2, -2, 2, -2, -2, 2, 2, 2, -2 }) ? "OK\n" : "Error\n"));
      // Is Pane Degenerate
      Console.WriteLine("Test35 " + (TrianglesIntersection.AreIntersected(new double[] { 1, 1, 1, 5, 5, 5, 6, 6, 6, 2, 2, 2, 3, 3, 3, 4, 4, 4 }) ? "OK\n" : "Error\n"));
      // Is Pane Degenerate
      Console.WriteLine("Test36 " + (TrianglesIntersection.AreIntersected(new double[] { 1, 1, 2, 5, 5, 6, 6, 6, 7, 2, 2, 2, 3, 3, 3, 4, 4, 4 }) ? "Error\n" : "OK\n"));
    }

  }
}
