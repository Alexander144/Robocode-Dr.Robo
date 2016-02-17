using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExampleSetup.Robocode;
using Robocode;

namespace Dr.Robo.Robocode.States
{
	public class DefaultState : State
	{
		private Color _BodyColor = Color.Purple;
		private Color _GunColor = Color.LightGreen;
		private Color _RadarColor = Color.Purple;
		private Color _BulletColor = Color.Gold;
		private Color _ScanArColor = Color.Pink;

		public DefaultState() : base("DefaultState")
		{
			Robot.SetColors(_BodyColor, _GunColor, _RadarColor, _BulletColor, _ScanArColor);
		}

		public override string ProcessState()
		{
			throw new NotImplementedException();
		}
	}
}
