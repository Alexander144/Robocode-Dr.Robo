using System;
using System.Drawing;

using Robocode;
using Robocode.Util;
using Dr.Robo;

using Dr.Robo.Robocode.States;

// ReSharper disable once CheckNamespace
namespace Dr.Robo
{
	// ReSharper disable once InconsistentNaming
	public class DrRobo : AdvancedRobotEx
	{
		// P R I V A T E / P R O T E C T E D   V A R S
		// -------------------------------------------

		private readonly FiniteStateMachine _fsm;
		private bool LockOn = false;
	
		
		
		// P U B L I C   M E T H O D S 
		// ---------------------------

		public DrRobo()
		{
			// Defining the possible states for this fsm. (Also, the 1st one listed becomes the default state.)
			_fsm = new FiniteStateMachine(new State[] { new DefaultState(),new Seek(),new Shoot(),new Flee()  });
		}


		public override void Run() { 


		
            InitBot();
			while (true)
			{
				_fsm.Update();
				Execute();
			
			}
		
		}


		public override void OnScannedRobot(ScannedRobotEvent scanData)
		{
			double enemyAbsoluteBearing = HeadingRadians + scanData.BearingRadians; 
            double enemyDistance = scanData.Distance;
			Point2D robotLocation = new Point2D(X, Y);
			Point2D enemyLocation =  MathHelpers.project(robotLocation, enemyAbsoluteBearing, enemyDistance);
			
			Enemy.SetEnemyData(scanData, enemyLocation);
	
		}


		// P R I V A T E   M E T H O D S
		// -----------------------------

		// Inits robot stuff (color and such).
		private void InitBot()
		{
		
			
			// Init the FSM.
			_fsm.Init(this);

			// Set some colors on our robot. (Body, gun, radar, bullet, and scan arc.)
			SetColors(Color.LightSlateGray, Color.DimGray, Color.Gray, Color.White, Color.LightPink);

			// NOTE: Total distance each element can move remains the same, whether these ones are true or false. 
			//       Example: Gun swivels a maximum of 20 degrees in addition to what the body swivels (if anything) 
			//       each turn, no matter what IsAdjustGunForRobotTurn is set to.
			IsAdjustGunForRobotTurn = true;
			IsAdjustRadarForGunTurn = true;
			IsAdjustRadarForRobotTurn = true;
		}


		/// <summary>
		/// Method to find Vector2D from Robot to Target, according to the battlefield coordinate system.
		/// </summary>
		/*private Vector2D CalculateTargetVector(double ownHeadingRadians, double bearingToTargetRadians, double distance)
		{
			double battlefieldRelativeTargetAngleRadians = Utils.NormalRelativeAngle(ownHeadingRadians + bearingToTargetRadians);
			Vector2D targetVector = new Vector2D(Math.Sin(battlefieldRelativeTargetAngleRadians) * distance,
												 Math.Cos(battlefieldRelativeTargetAngleRadians) * distance);
			return targetVector;
		}*/


	}
}
