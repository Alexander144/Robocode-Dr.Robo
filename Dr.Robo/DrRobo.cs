using System;
using System.Drawing;
using ExampleSetup.Robocode;
using Robocode;
using Robocode.Util;
using Dr.Robo;
using ExampleSetup.AI_States;
using Santom;

// ReSharper disable once CheckNamespace
namespace Dr.Robo
{
	// ReSharper disable once InconsistentNaming
	public class DrRobo : AdvancedRobotEx
	{
		// P R I V A T E / P R O T E C T E D   V A R S
		// -------------------------------------------

		private readonly FiniteStateMachine _fsm;
		
		private double moveDirection;
		// P U B L I C   M E T H O D S 
		// ---------------------------

		public DrRobo()
		{
			// Defining the possible states for this fsm. (Also, the 1st one listed becomes the default state.)
			_fsm = new FiniteStateMachine(new State[] { new DrvIdle(), new DrvEngage(),new Shoot() });
		}


		public override void Run()
		{
			InitBot();
			while (true)
			{



				_fsm.Update();
				Execute();
				/*if (Energy<20)
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
			}
			/*InitBot();

			// Loop forever. (Exiting run means no more robot fun for us!)
			while (true)
			{

				// TODO: Students, make better code for turning radar, right?
				SetTurnRadarRight(10);

				// The state machine doing its "magic".
				_fsm.Update();

				// Execute any current actions. NOTE: This sometimes triggers a blocking call internally, so this should be the last thing we do in a turn!
				Execute();
			}
			// ReSharper disable once FunctionNeverReturns*/
		}


		public override void OnScannedRobot(ScannedRobotEvent scanData)
		{
			EnemyData data = new EnemyData(scanData);
			

			if (Others == 1)
			{
				if (scanData.Heading >= Heading)
				{
					TurnLeft(45);
				}
				else { TurnRight(45); }
			}
		/*	double absoluteBearing = Heading + scanData.Bearing;
			double BearingToGun = Utils.NormalAbsoluteAngleDegrees(absoluteBearing - GunHeading);
			Vector2D ToShoot = CalculateTargetVector(HeadingRadians, absoluteBearing, scanData.Distance);
                
				double posistion = (ToShoot.X * ToShoot.X) + (ToShoot.Y * ToShoot.Y);
				posistion = Math.Sqrt(posistion);
				TurnGunRight(scanData.Distance);
			if (Math.Abs(BearingToGun) < 3)
			{
			
				if (Math.Abs(GunHeat) < 1)
				{
					Fire(3);
				}

			}
			else
			{
			TurnGunLeft(BearingToGun);
			}


			if (BearingToGun == 0)
			{
				Scan();
			}
		*/

			/*// Storing data about scan time and Enemy for later use.
			Vector2D offset = CalculateTargetVector(HeadingRadians, scanData.BearingRadians, scanData.Distance);
			Point2D position = new Point2D(offset.X + X, offset.Y + Y);
			Enemy.SetEnemyData(scanData, position);

			// If we're out of energy, don't bother swapping states, as that will just make runtime bugs.
			if (!Energy.IsCloseToZero())
			{
				_fsm.Queue("Engage");
			}*/
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
		}


		/// <summary>
		/// Method to find Vector2D from Robot to Target, according to the battlefield coordinate system.
		/// </summary>
		private Vector2D CalculateTargetVector(double ownHeadingRadians, double bearingToTargetRadians, double distance)
		{
			double battlefieldRelativeTargetAngleRadians = Utils.NormalRelativeAngle(ownHeadingRadians + bearingToTargetRadians);
			Vector2D targetVector = new Vector2D(Math.Sin(battlefieldRelativeTargetAngleRadians) * distance,
												 Math.Cos(battlefieldRelativeTargetAngleRadians) * distance);
			return targetVector;
		}


	}
}
