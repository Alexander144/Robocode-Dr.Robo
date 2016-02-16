using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robocode;
using Robocode.Util;
using Dr.Robo.Robocode;
using System.Drawing;
using System.Drawing.Printing;


namespace Dr.Robo
{
	public class DrRobo : AdvancedRobot
	{
		private readonly FiniteStateMachine _fsm;
		public State[] state;

		public DrRobo()
	    {
		    _fsm = new FiniteStateMachine(state);
	    }

		public override void Run()
		{
			while (true)
			{
				SetColors(_BodyColor, _GunColor, _RadarColor, _BulletColor, _ScanArColor);
				if (go == true)
				{
					SetTurnRadarLeft(4);
				}
				Ahead(10);
				_GunColor = Color.LightGreen;
				Execute();
			}
		}

		public override void OnScannedRobot(ScannedRobotEvent scanData)
		{
			double x = RadarHeading;
			go = false;
			_GunColor = Color.Gold;
			SetTurnLeft(x);
			SetTurnGunLeft(x);
			SetTurnRadarLeft(Heading-Heading);
			Fire(2);
		}
	}
}
