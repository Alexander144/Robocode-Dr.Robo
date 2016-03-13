using System.Drawing;


using Robocode.Util;
using System;

namespace Dr.Robo
{
	public class Arrive : State
	{
		
	

		private Point2D _targetPosition;
		private double _gunTurnAmt;
		private double _targetBearing;
		private double _targetDistance;
		private double _gunTurn;
		private string _targetName;
		private int count;
		private string trackName = null;

		public Arrive()
			: base("Arrive")
		{
			// Intentionally left blank.
		}


		// Called once when we transition into this state.
		public override void EnterState()
		{
			_BodyColor = Color.Green; _GunColor = Color.Green; _RadarColor = Color.Green; _BulletColor = Color.Green; _ScanArColor = Color.Green;

			base.EnterState();

			Console.WriteLine("Dette er inni ARRIVE" + Robot.Enemy.BearingDegrees);

			_targetPosition = Robot.Enemy.Position;
			_targetBearing = Robot.Enemy.BearingDegrees;
			_targetDistance = Robot.DistanceRemaining;
			_targetName = Robot.Enemy.Name;
			_gunTurnAmt = Utils.NormalRelativeAngleDegrees(_targetBearing + (Robot.Heading - Robot.RadarHeading));
		}


		public override string ProcessState()
		{
			double absoluteBearing = Robot.Heading + _targetBearing;
			double bearingToEnemy = Utils.NormalRelativeAngleDegrees(absoluteBearing - Robot.Heading);
			Console.WriteLine(bearingToEnemy);
			// If it's close enough, fire!
			if (Math.Abs(bearingToEnemy) <= 0)
			{
				Robot.TurnRight(bearingToEnemy);



			}
			else
			{
				// otherwise just set the gun to turn.
				// Note:  This will have no effect until we call scan()
				Robot.TurnRight(bearingToEnemy);

			}
			if (bearingToEnemy == 0) {
				Robot.Ahead(100);
			}
				return "DefaultState";
		}
	}
}
