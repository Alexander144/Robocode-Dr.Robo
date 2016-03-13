using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Robocode;
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
			
			Console.WriteLine(_targetDistance);
		
			/*if (_targetDistance <700 && _targetDistance >-700)
			{
				return "Shoot";
			}*/
			
			return "Arrive";
		}
	}
}
