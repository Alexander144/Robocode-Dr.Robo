using System.Drawing;


using Robocode.Util;
using System;
using System.Net.Http.Headers;

namespace Dr.Robo
{
	public class Seek : State
	{
		private double _distance;
		private double _maxprediction;
		private double _prediction;
		private double _speed;
		private double _targetBearing;
		private double _targetVelocity;

		public Seek() : base("Seek")
		{
			// Intentionally left blank.
		}


		// Called once when we transition into this state.
		public override void EnterState()
		{
			_BodyColor = Color.Green;
			_GunColor = Color.Green;
			_RadarColor = Color.Green;
			_BulletColor = Color.Green;
			_ScanArColor = Color.Green;

			base.EnterState();
			_targetBearing = Robot.Enemy.BearingDegrees;
			_speed = Robot.Velocity;

			_maxprediction = Robot.Enemy.Position.length();
			_distance = Robot.Enemy.Distance;
			_targetVelocity = Robot.Enemy.Velocity;

		}


		public override string ProcessState()
		{
			bool HitWall = WallAvoider();
			DoScanOnRobot();
			Console.WriteLine(HitWall);
			if (HitWall == false)
			{
				if (_speed <= Robot.Enemy.Distance/_maxprediction)
				{
					_prediction = _maxprediction;
					
				}

				else
				{
					_prediction = _distance/_speed;
				}


				Robot.SetTurnRight(_targetBearing);
				Robot.SetAhead(_prediction);

				if (Robot.Enemy.Distance <= 70)
				{
				if (Robot.Energy < 50)
				{
					return "Flee";
				}

					return "Shoot";
				
				}
				if (Robot.Energy < 50)
				{
					return "Flee";
				}

				return "Seek";

			}
			else
			{
				Robot.SetTurnRight(60);
				Robot.SetAhead(40);
				return "Seek";
			}
		}
	}
}
