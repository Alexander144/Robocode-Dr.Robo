using System.Drawing;



namespace PG4500_2016_Exam1
{
	public class Flee : State
	{
		private Point2D _targetPosition;

		private double _energy;

		private double _targetDistance;
		private double _targetBearing;
		private double _targetEnergy;

		public Flee()
			: base("Flee")
		{
			_targetPosition = null;
			_energy = 0;
			_targetDistance = 0;
			_targetBearing = 0;
			_targetEnergy = 0;
		}

		public override void EnterState()
		{
			_BodyColor = Color.Yellow;
			_GunColor = Color.Yellow;
			_RadarColor = Color.Yellow;
			_BulletColor = Color.Yellow;
			_ScanArColor = Color.Yellow;

			base.EnterState();
			
			_energy = Robot.Energy;

			_targetPosition = Robot.Enemy.Position;
			_targetDistance = Robot.Enemy.Distance;
			_targetBearing = Robot.Enemy.BearingDegrees;
			_targetEnergy = Robot.Enemy.Energy;
		}


		public override string ProcessState()
		{
			bool HitWall = WallAvoider();

			DoScanOnRobot();

			if (HitWall == false)
			{
				//Hvis motstanderen er langt unna, beveger den seg bakover. Hvis den er nærme, bytt retning. 
				if (_targetDistance >= 250)
				{
					//Hvis targetbearing er mindre enn 10 grader, så bevege det til høyere til den når under 10 grader. For å kontrollere at den beveger seg en vei.
					if (!(_targetBearing >= 10)) {
						Robot.SetTurnRight(_targetBearing);
					}
				}

				else
				{

					if (!(_targetBearing >= 10))
					{
						Robot.SetTurnRight(_targetBearing - 180);
					}
				}
				//Hvis du har mer enegi enn motstanderen, så er det ikke noe vits å flykte.
				if (!(_targetEnergy > _energy + (_energy * (_targetEnergy / 100))))
				{
					return "DefaultState";
				}

				Robot.SetBack(20);
				return "Flee";
			}

			else
			{
				Robot.SetTurnRight(40);
				Robot.SetAhead(30);
				return "Flee";

			}
		}
	}
}
