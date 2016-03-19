using System;
using System.Drawing;
using Robocode;


namespace PG4500_2016_Exam1
{
	public class AdvancedRobotEx : AdvancedRobot 
	{

		// Properties
	
		public EnemyData Enemy { get; set; }  // Stored info about our current radar target. (Wiped each round/match.)


		// Public Methods
		
		public AdvancedRobotEx()
		{
			Enemy = new EnemyData();
		}


		public bool DistanceCompleted()
		{
			return Math.Abs(DistanceRemaining).IsCloseToZero();
		}


		public bool TurnCompleted()
		{
			return Math.Abs(TurnRemaining).IsCloseToZero();
		}

		public void DrawLineAndTarget(Color drawColor, Point2D start, Point2D end)
		{
			// Set color to a semi-transparent one.
			Color halfTransparent = Color.FromArgb(128, drawColor);
			// Draw line and rectangle.
			Graphics.DrawLine(new Pen(halfTransparent), (int)start.X, (int)start.Y, (int)end.X, (int)end.Y);
			Graphics.FillRectangle(new SolidBrush(halfTransparent), (int)(end.X - 17.5), (int)(end.Y - 17.5), 36, 36);
		}

		public void DrawRobotIndicator(Color drawColor, Point2D target)
		{
			// Set color to a semi-transparent one.
			Color halfTransparent = Color.FromArgb(128, drawColor);
			// Draw rectangle at target.
			Graphics.FillRectangle(new SolidBrush(halfTransparent), (int)(target.X - 26.5), (int)(target.Y - 26.5), 54, 54);
		}

		public override void OnRobotDeath(RobotDeathEvent deadRobot)
		{
			if (deadRobot.Name == Enemy.Name) {
				Enemy.Clear();
			}
		}

		public override void OnBulletHit(BulletHitEvent hitData)
		{
			if (Enemy.Name == hitData.VictimName) {
				Enemy.Energy = hitData.VictimEnergy;
			}
		}
	}
}
