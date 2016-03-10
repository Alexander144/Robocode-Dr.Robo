using ExampleSetup.Robocode;
using Santom;

namespace ExampleSetup.AI_States
{
	public class Shoot : State
	{
		private Point2D _targetPosition;
		public Shoot()
			: base("Shoot")
		{
			// Intentionally left blank.
		}
		public override void EnterState()
		{
			base.EnterState();

			_targetPosition = Robot.Enemy.Position;

			Robot.SetTurnGunRight(Robot.Enemy.BearingDegrees);
			Robot.Fire(2);
		}

		public override string ProcessState()
		{
			return null;
		}
	}
}
