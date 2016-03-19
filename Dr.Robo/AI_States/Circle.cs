using System.Drawing;
using System;

namespace PG4500_2016_Exam1
{
	public class Circle : State
	{
		private double _battleFieldHeight;
		private double _battleFieldWidth;

		private int _direction;
		private double _velocity;
		private double _energy;
		private double _heading;
		private double _maxprediction;
		private double _prediction;
		private double _speed;
		private double _targetDistance;
		
		private Point2D _Posistion;

		private double _targetBearing;
		private double _targetVelocity;
		
		public Circle() : base("Circle")
		{
			_battleFieldHeight = 0;
			_battleFieldWidth = 0;
			_direction = 0;
			_targetDistance = 0;
			_heading = 0;
			_maxprediction = 0;
			_Posistion = null;
			_prediction = 0;
			_speed = 0;
			_targetBearing = 0;
			_targetVelocity = 0;
			_velocity = 0;
			_energy = 0;
		}


		// Called once when we transition into this state.
		public override void EnterState()
		{
			_BodyColor = Color.Purple;
			_GunColor = Color.Purple;
			_RadarColor = Color.Purple;
			_BulletColor = Color.Purple;
			_ScanArColor = Color.Purple;

			base.EnterState();

			_Posistion = new Point2D(Robot.X,Robot.Y);
			
			_speed = Robot.Velocity;
			_velocity = Robot.Velocity;
			_heading = Robot.Heading;
			_direction = 1;
			_energy = Robot.Energy;

			_battleFieldWidth = Robot.BattleFieldWidth;
			_battleFieldHeight = Robot.BattleFieldHeight;
			
			_maxprediction = Robot.Enemy.Position.length();
			_targetBearing = Robot.Enemy.BearingDegrees;
			_targetDistance = Robot.Enemy.Distance;
			_targetVelocity = Robot.Enemy.Velocity;
		}


		public override string ProcessState()
		{
			bool HitWall = WallAvoider();
			DoScanOnRobot();
			if (HitWall == false)
			{
				//Hvis den treffer veggen, så er velocity 0. Ved å gange med *-1 gjør at den vil bevege seg i motsatt retning.
				if (_velocity == 0)
				{
					_direction = _direction *-1;
				}
				//Beveger roboten sideveis, i sirkel runt motstanderen. 
				Robot.SetTurnRight(_targetBearing + 90);
				Robot.SetAhead(8*_direction);

				//Droppes energien eller avstand, gå tilbake til defaultstate
				if (_energy < 60 || _targetDistance > 400)
				{
					return "DefaultState";
				}
				//Er motstanderens sin fart mindre en 5, så bytter den til shootstate
				if (_targetVelocity <= 5)
				{
					return "Shoot";
				}
				else
				{
					return "Circle";
				}
				
			}
			else
			{
				Robot.SetTurnRight(60);
				Robot.SetAhead(40);
				return "Circle";
			}
		}
	}
}
