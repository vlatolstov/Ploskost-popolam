using System;
using System.Drawing;
using System.Linq;

namespace Ploskost_popolam
{
    class Program
    {
        static void Main(string[] args)
        {
            Point[] points1 = new Point[2] { new Point(1, 2), new Point(5, 2) };
            Console.WriteLine(EqualHalfPlanes(points1));

            Point[] points2 = new Point[4] { new Point(1, 2), new Point(5, 2), new Point(4,3), new Point(5,3) };
            Console.WriteLine(EqualHalfPlanes(points2));

            Point[] points3 = new Point[4] { new Point(1, 1), new Point(5, 1), new Point(-1,4), new Point(7,4)};
            Console.WriteLine(EqualHalfPlanes(points3));
        }

        static bool EqualHalfPlanes(Point[] points)
        {
            var averageX = points.Average(p => p.X);
            var leftPoints = points.Where(p => p.X <= averageX).OrderBy(p => p.Y);
            var rightPoints = points.Where(p => p.X > averageX).OrderBy(p => p.Y);
            
            if (leftPoints.Count() != rightPoints.Count()
                && leftPoints.Select(p => p.Y).SequenceEqual(rightPoints.Select(p => p.Y))) 
                return false;

            for (int i = 0; i < rightPoints.Count(); i++)
            {
                if (averageX - leftPoints.ElementAt(i).X != rightPoints.ElementAt(i).X - averageX) return false;
            }
            return true;
        }
    }
}
