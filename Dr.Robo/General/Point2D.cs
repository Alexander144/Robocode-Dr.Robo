using System;

namespace PG4500_2016_Exam1
{
	public class Point2D
	{
		public double X { get; set; }
		public double Y { get; set; }

		public Point2D()
		{
			// Setter verdien til 0, bare god skikk ;)
			Zero();
		}

		public Point2D(Point2D cloneMe)
		{
			X = cloneMe.X;
			Y = cloneMe.Y;
		}

		public Point2D(double xVal, double yVal)
		{
			X = xVal;
			Y = yVal;
		}

		public void Zero()
		{
			X = 0.0;
			Y = 0.0;
		}
		//Henter ut lengden av vektoren roboten beveger seg.
		public double length()
		{
			double Length = Math.Sqrt((X * X) + (Y * Y));
			return Length;
		}
	}
}