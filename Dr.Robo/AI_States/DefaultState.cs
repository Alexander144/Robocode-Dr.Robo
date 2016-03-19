using System.Drawing;

namespace PG4500_2016_Exam1
{
	public class DefaultState : State
	{
		private double _Energy;
		private double _targetEnergy;
		private bool _targetCloseToRobot;
		

		public DefaultState() : base("DefaultState")
		{
			
		}
		public override void EnterState()
		{
			_BodyColor = Color.Purple;
			_GunColor = Color.LightGreen;
			_RadarColor = Color.Purple;
			_BulletColor = Color.Gold;
			_ScanArColor = Color.Pink;

			base.EnterState();

			_Energy = Robot.Energy;

			_targetEnergy = Robot.Enemy.Energy;
			_targetCloseToRobot = Robot.Enemy.CloseToRobot;

		}
		public override string ProcessState()
		{
			bool Scanned = DoScanOnRobot();
			//Hvis motstanderen sin energi er større en energien til roboten, plus energien med motstanderen prosentes liv av ditt liv, prøv fluktstate.
			if (_targetEnergy>_Energy+(_Energy*(_targetEnergy/100)))
			{
				return "Flee";
			}
			//Bytt til circlestate hvis du er nærme nok
			if (_targetCloseToRobot == true)
			{
				return "Circle";
			}
			//Hvis har funnet en motstander og energien er riktig og hvis du ikke er nærme roboten, så gå til seek state.
			if (Scanned == true && !(_targetEnergy > _Energy + (_Energy * (_targetEnergy / 100))) && _targetCloseToRobot == false)
			{
				return "Seek";
			}
			
			return base.ToString();

		}
	}
}
