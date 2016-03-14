using System.Drawing;

using Santom;

namespace Dr.Robo
{
	public class Flee : State
	{
		private Point2D _targetPosition;


		public Flee()
			: base("Flee")
		{
			// Intentionally left blank.
		}


		// Called once when we transition into this state.
		public override void EnterState()
		{
			_BodyColor = Color.Yellow; _GunColor = Color.Yellow; _RadarColor = Color.Yellow; _BulletColor = Color.Yellow; _ScanArColor = Color.Yellow;
			base.EnterState();

			_targetPosition = Robot.Enemy.Position;

			Robot.SetTurnRight(Robot.Enemy.BearingDegrees);
			Robot.SetBack(200);
		}


		public override string ProcessState()
		{
			DoScanOnRobot();
			
			return "Flee";
		}
	}
}
