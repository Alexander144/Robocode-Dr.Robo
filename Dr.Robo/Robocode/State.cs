using Robocode;
using Robocode.Util;
using System;
using System.Drawing;

namespace PG4500_2016_Exam1
{
	public abstract class State
	{
	
		//Variabler, alle states arver de variabelene som setter hvilken farge staten skal være i.
		protected AdvancedRobotEx Robot;

		protected Color _BodyColor;
		protected Color _GunColor;
		protected Color _RadarColor;
		protected Color _BulletColor;
		protected Color _ScanArColor;

		private double _PointToEnemy;
		private double _absoluteBearing;
		private double _battleFieldHeight;
		private double _battleFieldWidth;


		// Tok i bruk properties, for ID som tar å settes etter hvilken states du er i.
		public string Id { get; private set; }
		

		//Setter id på den staten som sendes inn via statemachine.
		protected State(string stateName)
		{
			Id = stateName;
		}


		//Får ourRobot fra finiteStatemachine, kan bruke robot sinde metoder fra alle states.
		public virtual void Init(AdvancedRobotEx ourRobot)
		{
			Robot = ourRobot;
		}
	
		//En metode som alle states kan hente, den scanner roboten og peker den veien den andre roboten er. Hvis den ikke finner noen, så scannern den rundt seg til den finner noe.
		public virtual bool DoScanOnRobot()
		{

			//Hvis radaren har funnet en enemy så locker den enemyen
			if (Robot.Enemy.LockOn == true)
			{
				//Tar imot gradene som er fra robotoen og i forhold til robotens fiende
				_absoluteBearing = Robot.Heading + Robot.Enemy.BearingDegrees;
				//Tar imot gradene radaren må flytte seg, ved at vi regner ut total gradene - roboten sin radar sikt i grader
				_PointToEnemy = Utils.NormalRelativeAngleDegrees(_absoluteBearing - Robot.RadarHeading);

				//Bestemmer scanne området
				double ScanArea = Math.Min(Math.Atan(34 / Robot.Enemy.Distance), Rules.RADAR_TURN_RATE);

				//Dette gjør sånn at hvis ikke radaren er locket inn, så scanner den områder enten høyere eller venstre i forhold til hvor motstanderen gikk
				_PointToEnemy += _PointToEnemy < 0 ? -ScanArea : ScanArea;

				//Hvis den ikke finner roboten etter 34 enheter, så setter den lockon false for å ta en ny scan av banen
				if (_PointToEnemy < 60 || _PointToEnemy > 60)
				{
					Robot.Enemy.LockOn = false;
				}
			
				if (Robot.Enemy.Distance > 300)
				{
					Robot.Enemy.CloseToRobot = false;
				}
				Robot.TurnRadarRight(_PointToEnemy);
				
				return true;
			}
			else
			{
				Robot.TurnRadarRight(20);
				return false;
			}
		}
		//Denne metoden skal prøve å gjøre sånn at roboten ikke kjører i veggen.
		public virtual bool WallAvoider()
		{
			_battleFieldWidth = Robot.BattleFieldWidth;
			_battleFieldHeight = Robot.BattleFieldHeight;
			if (Robot.X > _battleFieldWidth - 50 || Robot.Y > _battleFieldHeight - 50 || Robot.X < 50 ||
			   Robot.Y < 50)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		//Denne staten har alle statene, den setter da farge på roboten.
		public virtual void EnterState() 
		{
			Robot.SetColors(_BodyColor, _GunColor, _RadarColor, _BulletColor, _ScanArColor);
		}


		//Har valgt å ha denne metoden her selv om jeg ikke bruker den, kan være nyttig hvis jeg vil bruke den senere.
		public virtual void ExitState()
		{
			// Left Blank
		}


		//Er abstract fordi alle states har sin egen unike processState.
		public abstract string ProcessState();
	
	}
}
