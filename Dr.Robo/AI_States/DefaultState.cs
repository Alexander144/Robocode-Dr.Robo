using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExampleSetup.Robocode;
using Robocode;
using Santom;

namespace Dr.Robo.Robocode.States
{
	public class DefaultState : State
	{
		private Point2D _targetBearing;
		private Color _BodyColor = Color.Purple;
		private Color _GunColor = Color.LightGreen;
		private Color _RadarColor = Color.Purple;
		private Color _BulletColor = Color.Gold;
		private Color _ScanArColor = Color.Pink;

		public DefaultState() : base("DefaultState")
		{
			Robot.SetColors(_BodyColor, _GunColor, _RadarColor, _BulletColor, _ScanArColor);
		}
		public override void EnterState()
		{
			base.EnterState();
			


		}
		public override string ProcessState()
		{
			// switch directions if we've stopped
			double enemyBearing = Robot.Enemy.BearingDegrees.GetHashCode();
			double myVelocity = Robot.Velocity.GetHashCode();
		

			// circle our enemy
			Robot.SetTurnRight(enemyBearing + 90);
			string retState = null;
			if (Robot.Enemy.Energy > 2)
			{
				retState = "Shoot";

			}
			if (Robot.DistanceCompleted())
			{
				retState = "Idle";
			}
			else {
			
			}

			return retState;
		}
	}
}
