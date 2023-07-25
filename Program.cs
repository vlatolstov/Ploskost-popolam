using System;
using System.Drawing;
using System.Linq;

namespace Ploskost_popolam
{
    class Program
    {
        static void Main(string[] args)
        {
            Point[] points1 = new Point[3] { new Point(1, 1), new Point(2, 2), new Point(3, 3) };
            Console.WriteLine(EqualHalfPlanes(points1) + " Answer is false");

            Point[] points2 = new Point[4] { new Point(1, 1), new Point(6, 1), new Point(0, 1), new Point(5, 1) };
            Console.WriteLine(EqualHalfPlanes(points2) + " Answer is true");

            Point[] points3 = new Point[6] { new Point(1, 1), new Point(6, 1), new Point(0, 1), new Point(5, 1), new Point(4, 2), new Point(2, 3) };
            Console.WriteLine(EqualHalfPlanes(points3) + " Answer is false");

            Point[] points4 = new Point[4] { new Point(1, 1), new Point(6, 1), new Point(0, 1), new Point(5, 1) };
            Console.WriteLine(EqualHalfPlanes(points4) + " Answer is true");

            Point[] points5 = new Point[2] { new Point(1, 1), new Point(2, 2) };
            Console.WriteLine(EqualHalfPlanes(points5) + " Answer is false");

            Point[] points6 = new Point[2] { new Point(1, 2), new Point(5, 2) };
            Console.WriteLine(EqualHalfPlanes(points6) + " Answer is true");

            Point[] points7 = new Point[4] { new Point(1, 2), new Point(5, 2), new Point(4, 3), new Point(5, 3) };
            Console.WriteLine(EqualHalfPlanes(points7) + " Answer is false");

            Point[] points8 = new Point[3] { new Point(1, 2), new Point(5, 2), new Point(3, 3) };
            Console.WriteLine(EqualHalfPlanes(points8) + " Answer is true");
        }

        static bool EqualHalfPlanes(Point[] points)
        {
            var averageX = points.Average(p => p.X);
            var leftPoints = points.Where(p => p.X <= averageX).OrderBy(p => p.Y);
            var rightPoints = points.Where(p => p.X > averageX).OrderBy(p => p.Y);

            if (leftPoints.Count() != rightPoints.Count()
                || !leftPoints.Select(p => p.Y).SequenceEqual(rightPoints.Select(p => p.Y)))
                return false;

            for (int i = 0; i < rightPoints.Count(); i++)
            {
                if (averageX - leftPoints.OrderBy(p=>p.X).ElementAt(i).X != rightPoints.OrderByDescending(p => p.X).ElementAt(i).X - averageX) return false;
            }
            return true;
        }
    }
}
