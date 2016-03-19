using System.Drawing;

using Robocode;


namespace PG4500_2016_Exam1
{
	
	public class larale14_DrRobo : AdvancedRobotEx
	{

		//FinalStateMachine
		private readonly FiniteStateMachine _fsm;
	
		public larale14_DrRobo()
		{
			//Kjører statemachine og henter mulige states.
			_fsm = new FiniteStateMachine(new State[] { new DefaultState(),new Seek(),new Shoot(),new Flee(), new Circle()  });
		}


		public override void Run() { 
			//Run er main metoden, henter da InitBot metoden.
            InitBot();

			//Looper igjennom statmachinen og opptaterer den etter hvilken state den skal være.
			while (true)
			{
				_fsm.Update();
				Execute();
			}
		}
		//Denne metoden får inn data av andre roboter når radaren treffer de andre robotene.
		public override void OnScannedRobot(ScannedRobotEvent scanData)
		{
			//Tar imot retningen robot ligger i forhold til sin posisjon.
			double enemyAbsoluteBearing = HeadingRadians + scanData.BearingRadians; 
			//Tar imot lengden fra motstanderen til din robot.
            double enemyDistance = scanData.Distance;

			//Lagrer posisjonen som en Point2D, egen klasse som tar imot x og y posisjonen til roboten. 
			Point2D robotLocation = new Point2D(X, Y);
			//Regner ut hvor fiendens posisjon ved hjelp av MathHelpers klassen.
			Point2D enemyLocation =  MathHelpers.project(robotLocation, enemyAbsoluteBearing, enemyDistance);
			//Sender dataen videre til enemydata klassen og sender med informasjonen fra scan methoden og posisjonen til motstanderen.
			Enemy.SetEnemyData(scanData, enemyLocation);
	
		}

		//
		private void InitBot()
		{
			//Metoden InitBot initialisere roboten, den sender seg selv AdvancedRobotEx sånn at man kan bruke robot sine metoder videre.
			_fsm.Init(this);

			//Gun, Radar beveger seg uavhengig hvilken retning roboten beveger seg.
			IsAdjustGunForRobotTurn = true;
			IsAdjustRadarForGunTurn = true;
			IsAdjustRadarForRobotTurn = true;
		}
	}
}
