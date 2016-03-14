using System.Drawing;


using Robocode.Util;
using System;
using System.Net.Http.Headers;

namespace Dr.Robo
{
	public class Seek : State
	{
		private double _targetBearing;

		public Seek() : base("Seek")
		{
			// Intentionally left blank.
		}


		// Called once when we transition into this state.
		public override void EnterState()
		{
			_BodyColor = Color.Green; _GunColor = Color.Green; _RadarColor = Color.Green; _BulletColor = Color.Green; _ScanArColor = Color.Green;

			base.EnterState();
			_targetBearing = Robot.Enemy.BearingDegrees;
			Robot.SetTurnRight(Robot.Enemy.BearingDegrees);
			Robot.SetAhead(100);
		}


		public override string ProcessState()
		{
			DoScanOnRobot();
			
			if (Robot.Enemy.Distance <= 70)
			{
				
				return "Shoot";
			}
			Console.WriteLine(Robot.Energy);
			if (Robot.Energy<50)
			{
				return "Flee";
			}


			return "Seek";
			
		}
	}
}
