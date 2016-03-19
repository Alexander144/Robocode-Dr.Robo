using Robocode.Util;
using System;

namespace PG4500_2016_Exam1
{
	public class Shoot : State
	{	
		private Point2D _targetPosition;

		private double _targetEnergy;
		private double _targetDistance;
		private double _targetBearing;

		public Shoot()
			: base("Shoot")
		{
			_targetPosition = null;
			_targetDistance = 0;
			_targetBearing = 0;
		}
		public override void EnterState()
		{
			base.EnterState();
		
			_targetPosition = Robot.Enemy.Position;
			_targetBearing = Robot.Enemy.BearingDegrees;
			_targetDistance = Robot.DistanceRemaining;
			_targetEnergy = Robot.Enemy.Energy;

			//Får ut verdien for retningen motstanderen er + retningen roboten er i.
			double absoluteBearing = Robot.Heading + _targetBearing;
			//Her brukter vi notmalrelativeangledegress for å finne den korteste veien til retningen du vil bevege deg til.
			double bearingToEnemy = Utils.NormalRelativeAngleDegrees(absoluteBearing - Robot.GunHeading);

			//Beveger seg til retningen motstanderen er, hvis ikke den retningen er 0, da er den i sikte
			if (Math.Abs(bearingToEnemy) < 0)
			{
				Robot.TurnGunRight(bearingToEnemy);
			}

			else
			{
				Robot.TurnGunRight(bearingToEnemy);
			}


		}

		public override string ProcessState()
		{
			//Hvis radaren er låst på motstandaren så skyter den.
			if (Robot.Enemy.LockOn == true)
			{
				Robot.Fire(3);
			}
			return "DefaultState";
		}
	}
}
