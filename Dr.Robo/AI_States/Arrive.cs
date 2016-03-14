using System.Drawing;


using Robocode.Util;
using System;
using System.Net.Http.Headers;

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
		private double _targetEnergy;
		private Point2D _targetVelocity;

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

			_targetPosition = Robot.Enemy.Position;
			_targetBearing = Robot.Enemy.BearingDegrees;
			_targetDistance = Robot.Enemy.Distance;
			_targetEnergy = Robot.Enemy.Energy;
			

		}


		public override string ProcessState()
		{
			
			/*Point2D direction = _targetPosition - new Point2D(Robot.X, Robot.Y);
			double distance = direction.length();

			if (distance<_targetDistance)
			{
				return "Arrive";
			}

			if (distance>50)
			{
				Robot.Ahead(8);
			}
			else { Robot.Ahead(8*distance/50);}
			_targetVelocity = direction;*/
			


			return "Arrive";
		}
	}
}
