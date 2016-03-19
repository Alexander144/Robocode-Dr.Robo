using System;

namespace PG4500_2016_Exam1
{
	public static class MathHelpers
	{

		public static bool IsCloseTo(this double lhs, double rhs, double tolerance = 0.00001)
		{
			// Define the tolerance for variation in their values. (As a fraction of the lhs value.)
			double difference = Math.Abs(lhs * tolerance);

			// Compare the values. 
			if (Math.Abs(lhs - rhs) <= difference) {
				return true;
			}
			return false;
		}

		public static bool IsCloseToZero(this double value, double tolerance = 0.00001)
		{
			return (Math.Abs(value) <= tolerance);
		}
		public static Point2D project(Point2D sourceLocation, double angle, double length)
		{
			return new Point2D(sourceLocation.X + Math.Sin(angle) * length,
					sourceLocation.Y + Math.Cos(angle) * length);
		}
		public static double absoluteBearing(Point2D source, Point2D target)
		{
			return Math.Atan2(target.X - source.X, target.Y - source.Y);
		}

	}
}
