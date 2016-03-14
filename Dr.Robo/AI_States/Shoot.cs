using System.Drawing;
using Robocode.Util;
using System;

namespace Dr.Robo
{
	public class Shoot : State
	{	
		//Rød for angrep
		private double _targetBearing;
		

		private Point2D _targetPosition;
		private double _targetEnergy;
		private double _targetDistance;

		public Shoot()
			: base("Shoot")
		{
			// Intentionally left blank.
		}
		public override void EnterState()
		{
			base.EnterState();
		
			_targetPosition = Robot.Enemy.Position;
			_targetBearing = Robot.Enemy.BearingDegrees;
			_targetDistance = Robot.DistanceRemaining;
			_targetEnergy = Robot.Enemy.Energy;


			Console.WriteLine(Robot.Enemy.Distance);
			double absoluteBearing = Robot.Heading + _targetBearing;
			double bearingToEnemy = Utils.NormalRelativeAngleDegrees(absoluteBearing - Robot.GunHeading);

			// If it's close enough, fire!
			if (Math.Abs(bearingToEnemy) <= 0)
			{
				Robot.TurnGunRight(bearingToEnemy);



			}
			else
			{
				// otherwise just set the gun to turn.
				// Note:  This will have no effect until we call scan()
				Robot.TurnGunRight(bearingToEnemy);


			}


		}

		public override string ProcessState()
		{
			
		

			
			Robot.Fire(3);
			return "DefaultState";
		}
	}
}
