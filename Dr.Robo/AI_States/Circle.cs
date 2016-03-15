using System.Drawing;


using Robocode.Util;
using System;
using System.Net.Http.Headers;

namespace Dr.Robo
{
	public class Circle : State
	{
		private double _battleFieldHeight;
		private double _battleFieldWidth;
		private double _distance;
		private double _maxprediction;
		private Point2D _Posistion;
		private double _prediction;
		private double _speed;
		private double _targetBearing;
		private double _targetVelocity;

		public Circle() : base("Circle")
		{
			// Intentionally left blank.
		}


		// Called once when we transition into this state.
		public override void EnterState()
		{
			_BodyColor = Color.Purple; _GunColor = Color.Purple; _RadarColor = Color.Purple; _BulletColor = Color.Purple; _ScanArColor = Color.Purple;

			base.EnterState();
			_targetBearing = Robot.Enemy.BearingDegrees;
			_speed = Robot.Velocity;
			_Posistion = new Point2D(Robot.X,Robot.Y);
			_maxprediction = Robot.Enemy.Position.length();
			_distance = Robot.Enemy.Distance;
			_targetVelocity = Robot.Enemy.Velocity;
			_battleFieldWidth = Robot.BattleFieldWidth;
			_battleFieldHeight = Robot.BattleFieldHeight;

		}


		public override string ProcessState()
		{
			DoScanOnRobot();
			if (_Posistion.X>_battleFieldWidth-50 || _Posistion.Y>_battleFieldHeight-50 || _Posistion.X < 50 || _Posistion.Y < 50)
			{
				return "DefaultState";
			}


			return "Circle";
			
		}
	}
}
