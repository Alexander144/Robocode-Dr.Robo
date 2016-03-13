

namespace Dr.Robo
{
	public class DrvIdle : State
	{
		public DrvIdle()
			: base("Idle")
		{
			// Intentionally left blank.
		}


		public override string ProcessState()
		{
			Robot.Ahead(100);

			return "Shoot";
		}
	}
}
