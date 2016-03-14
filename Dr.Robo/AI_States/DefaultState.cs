using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Robocode;
using Robocode.Util;
using Santom;

namespace Dr.Robo.Robocode.States
{
	public class DefaultState : State
	{
		private Point2D _targetBearing;
		private Point2D _targetPosistion;
		private double _targetDistance;
		

		public DefaultState() : base("DefaultState")
		{
			
		}
		public override void EnterState()
		{
			_BodyColor = Color.Purple; _GunColor = Color.LightGreen; _RadarColor = Color.Purple; _BulletColor = Color.Gold; _ScanArColor = Color.Pink;
			base.EnterState();
			_targetPosistion = Robot.Enemy.Position;
			_targetDistance = Robot.Enemy.Distance;
			


		}
		public override string ProcessState()
		{
			if (Robot.Enemy.LockOn == true)
			{
				double absoluteBearing = Robot.Heading + Robot.Enemy.BearingDegrees;
				double moveRadarToEnemy = absoluteBearing - Robot.RadarHeading;
				Robot.TurnRadarRight(Utils.NormalRelativeAngle(moveRadarToEnemy));
				Robot.Scan();
			}
			else
			{
				Robot.TurnRadarRight(20);
			}

			return base.ToString();

		}
	}
}
