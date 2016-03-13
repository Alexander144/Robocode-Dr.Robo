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
			base.EnterState();

			_targetPosition = Robot.Enemy.Position;

			Robot.SetTurnRight(Robot.Enemy.BearingDegrees);
			Robot.SetAhead(200);
		}


		public override string ProcessState()
		{
			string retState = null;
			if (Robot.Enemy.Energy > 2)
			{
				retState = "Shoot";

			}
			if (Robot.DistanceCompleted()) {
				retState = "Idle";
			} else {
				Robot.DrawLineAndTarget(Color.LightGreen, new Point2D(Robot.X, Robot.Y), _targetPosition);
			}

			return retState;
		}
	}
}
