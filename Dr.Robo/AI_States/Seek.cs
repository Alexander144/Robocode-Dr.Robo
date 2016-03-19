using System.Drawing;
using System;

namespace PG4500_2016_Exam1
{
	public class Seek : State
	{
		private double _targetDistance;
		private double _energy;
		private double _maxprediction;
		private double _prediction;
		private double _speed;
		private double _targetBearing;
		private double _targetVelocity;

		public Seek() : base("Seek")
		{
			_targetDistance = 0;
			_energy = 0;
			_maxprediction = 0;
			_prediction = 0;
			_speed = 0;
			_targetBearing = 0;
			_targetVelocity = 0;
		}


		// Called once when we transition into this state.
		public override void EnterState()
		{
			_BodyColor = Color.Green;
			_GunColor = Color.Green;
			_RadarColor = Color.Green;
			_BulletColor = Color.Green;
			_ScanArColor = Color.Green;

			base.EnterState();
			_targetBearing = Robot.Enemy.BearingDegrees;
			_speed = Robot.Velocity;

			_maxprediction = Robot.Enemy.Position.length();
			
			_energy = Robot.Energy;

			_targetDistance = Robot.Enemy.Distance;
			_targetVelocity = Robot.Enemy.Velocity;
		}


		public override string ProcessState()
		{
			//Henter inn wallAvoideren som retunerer true hvis den er nærheten av veggen eller false hvis den ikke er det.
			//DoScanOnRobot beveger radaren etter fienden og scanner hvis den ikke har noen i sikte.
			bool HitWall = WallAvoider();
			DoScanOnRobot();
		
			if (HitWall == false)
			{
				//Hvis speed er mindre en avstand fra motstanderen / avstand
				Console.WriteLine("maxpred er " + _maxprediction);
				
				if (_speed <= _targetDistance/_maxprediction)
				{
					_prediction = _maxprediction;
					
				}

				else
				{
					_prediction = _targetDistance/_speed;
				}


				Robot.SetTurnRight(_targetBearing);
				Robot.SetAhead(_prediction);
				//Er den innenfor 70 i avstand og den beveger seg mindre enn 5, så skal den skyte.
				if (_targetDistance <= 70 && _targetVelocity <= 5)
				{

					Robot.Enemy.CloseToRobot = true;
					return "Shoot";				
				}
				

				return "Seek";

			}
			else
			{
				Robot.SetTurnRight(60);
				Robot.SetAhead(40);
				return "Seek";
			}
		}
	}
}
