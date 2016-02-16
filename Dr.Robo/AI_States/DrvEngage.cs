using System.Drawing;
using ExampleSetup.Robocode;
using Santom;

namespace ExampleSetup.AI_States
{
	public class DrvEngage : State
	{
		private Point2D _targetPosition;


		public DrvEngage()
			: base("Engage")
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
			if (Robot.DistanceCompleted()) {
				retState = "Idle";
			} else {
				Robot.DrawLineAndTarget(Color.LightGreen, new Point2D(Robot.X, Robot.Y), _targetPosition);
			}

			return retState;
		}
	}
}
