using System;
using System.Drawing;

using Santom;

namespace Dr.Robo
{
	public class Flee : State
	{
		private double _targetDistance;
		private Point2D _targetPosition;
		private double _targetBearing;
		private double _Energy;

		public Flee()
			: base("Flee")
		{
			// Intentionally left blank.
		}


		// Called once when we transition into this state.
		public override void EnterState()
		{
			_BodyColor = Color.Yellow;
			_GunColor = Color.Yellow;
			_RadarColor = Color.Yellow;
			_BulletColor = Color.Yellow;
			_ScanArColor = Color.Yellow;
			base.EnterState();

			_targetPosition = Robot.Enemy.Position;
			_targetDistance = Robot.Enemy.Distance;
			_targetBearing = Robot.Enemy.BearingDegrees;
			_Energy = Robot.Energy;
		}


		public override string ProcessState()
		{
			bool HitWall = WallAvoider();
			DoScanOnRobot();
			if (HitWall == false)
			{
				if (_targetDistance >= 250)
				{
					Robot.SetTurnRight(_targetBearing);
				}
				else
				{
					Robot.SetTurnRight(_targetBearing - 180);

				}
				Console.WriteLine(_targetDistance);
				if (_Energy < 30)
				{
					//return "Circle";
				}

				Robot.SetBack(200);
				return "Flee";
			}
			else
			{
				Robot.SetTurnRight(40);
				Robot.SetAhead(30);
				return "Flee";

			}
		}
	}
}
