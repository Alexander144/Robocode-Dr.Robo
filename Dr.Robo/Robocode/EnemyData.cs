using Robocode;
using Robocode.Util;


namespace PG4500_2016_Exam1
{
	public class EnemyData
	{

		// Properties
		
		public long Time { get; set; }  // Time (turn) of currently stored scan.

		// Enemy stuff
		public string Name { get; set; }  // Name of enemy.
		public double BearingRadians { get; set; }  // Bearing from us to enemy, in radians.
		public double BearingDegrees { get { return Utils.ToDegrees(BearingRadians); } set { BearingRadians = Utils.ToRadians(value); } }  // Bearing from us to enemy, in degrees.
		public double Distance { get; set; }  // Distance from us to enemy.
		public double Energy { get; set; }  // Energy of enemy.
		public Point2D Position { get; set; }  // Position of enemy, in battlefield x y coordinates.
		public double Velocity { get; set; }  // Velocity of enemy.
		public double Acceleration { get; set; }  // How fast our enemy changes speed. (Calculated by comparing values over 2 scans.)
		public double HeadingRadians { get; set; }  // Heading of enemy, in radians.
		public double HeadingDegrees { get { return Utils.ToDegrees(HeadingRadians); } set { HeadingRadians = Utils.ToRadians(value); } }  // Heading of enemy, in degrees.
		public double TurnRateRadians { get; set; }  // How fast our enemy turns, in radians (change of heading per turn). (Calculated by comparing values over 2 scans.)
		public double TurnRateDegrees { get { return Utils.ToDegrees(TurnRateRadians); } set { TurnRateRadians = Utils.ToRadians(value); } }  // How fast our enemy turns, in degrees (change of heading per turn). (Calculated by comparing values over 2 scans.)
		public bool LockOn{ get; set; }
		public bool CloseToRobot { get; set; }

		// Public Methods
		
		public EnemyData()
		{
			Time = 0;
			Name = null;
			BearingRadians = 0.0;
			Distance = 0.0;
			Energy = 0.0;
			Position = new Point2D();
			Velocity = 0.0;
			Acceleration = 0.0;
			HeadingRadians = 0.0;
			TurnRateRadians = 0.0;
			LockOn = false;
			CloseToRobot = false;
		}

		public EnemyData(EnemyData cloneMe)
		{
			Time = cloneMe.Time;
			Name = cloneMe.Name;
			BearingRadians = cloneMe.BearingRadians;
			Distance = cloneMe.Distance;
			Energy = cloneMe.Energy;
			Position = new Point2D(cloneMe.Position);
			Velocity = cloneMe.Velocity;
			Acceleration = cloneMe.Acceleration;
			HeadingRadians = cloneMe.HeadingRadians;
			TurnRateRadians = cloneMe.TurnRateRadians;
		}

		public void Clear() 
		{ 
			Time = 0;
			Name = null;
			BearingRadians = 0.0;
			Distance = 0.0;
			Energy = 0.0;
			Position.Zero();
			Velocity = 0.0;
			Acceleration = 0.0;
			HeadingRadians = 0.0;
			TurnRateRadians = 0.0;
		}
		public void SetEnemyData(ScannedRobotEvent newEnemyData,
								 Point2D newPosition)
		{
			// First we set the stuff that depends on last updates' values:
			long deltaTime = newEnemyData.Time - Time;
			TurnRateRadians = Utils.NormalRelativeAngle(newEnemyData.HeadingRadians - HeadingRadians) / deltaTime;
			Acceleration = (newEnemyData.Velocity - Velocity) / deltaTime;

			// General data:
			Time = newEnemyData.Time;
			
			// Compared-to-us data:
			BearingRadians = newEnemyData.BearingRadians;
			Distance = newEnemyData.Distance;

			// Enemy specific data:
			Name = newEnemyData.Name;
			Energy = newEnemyData.Energy;
			Position = newPosition;
			Velocity = newEnemyData.Velocity;
			HeadingRadians = newEnemyData.HeadingRadians;

			//La til en LockOn, som blir true vær gang radaren har gått over motstanderne.
			LockOn = true;
		}
	}
}