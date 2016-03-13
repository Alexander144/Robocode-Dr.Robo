using System.Drawing;

using Santom;

namespace Dr.Robo
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
			if (Robot.Enemy.Energy > 2)
			{
				retState = "Shoot";

			}
			if (Robot.DistanceCompleted()) {
				retState = "Idle";
			} else {
				Robot.DrawLineAndTarget(Color.LightGreen, new Point2D(Robot.X, Robot.Y), _targetPosition);
			}   /*if (Energy<20)
				{
					Fire(1);
				}
				TurnGunRight(2);

				if (Others > 1)
				{
					Ahead(100);
				}
				else { }
				if ((X > BattleFieldWidth-50)||(X<50)) {
					double turn = 360 - Heading;
					TurnLeft(turn);
				}
				if ((Y > BattleFieldHeight - 100)||(Y<50))
				{
					double turn = 360 - Heading;
					TurnLeft(turn);
				}*/

			return retState;
		}
	}
}
