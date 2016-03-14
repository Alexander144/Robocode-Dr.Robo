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

		public DefaultState() : base("DefaultState")
		{
			
		}
		public override void EnterState()
		{
			_BodyColor = Color.Purple; _GunColor = Color.LightGreen; _RadarColor = Color.Purple; _BulletColor = Color.Gold; _ScanArColor = Color.Pink;
			base.EnterState();
		
			


		}
		public override string ProcessState()
		{
			bool Scanned = DoScanOnRobot();
			if (Scanned == true)
			{
				return "Seek";
			}
			return base.ToString();

		}
	}
}
