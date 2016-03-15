using Dr.Robo;
using Robocode;
using Robocode.Util;
using System;
using System.Drawing;

namespace Dr.Robo
{
	/// <summary>
	/// Base class for states in the FSM. Should be inherited from.
	/// version: 1.0
	/// author: Tomas Sandnes - santom@westerdals.no
	/// </summary>
	public abstract class State
	{
		// P R I V A T E / P R O T E C T E D   V A R S
		// -------------------------------------------

		protected AdvancedRobotEx Robot;
		public Color _BodyColor;
		public Color _GunColor;
		public Color _RadarColor;
		public Color _BulletColor;
		public Color _ScanArColor;
		protected double _PointToEnemy;
		protected double _absoluteBearing;
		private double _battleFieldHeight;
		private double _battleFieldWidth;


		// P R O P E R T I E S
		// -------------------

		public string Id { get; private set; }
		public EnemyData EnemyTrueLock { get; private set; }


		// P U B L I C   M E T H O D S 
		// ---------------------------

		/// <summary>
		/// Constructor.
		/// </summary>
		protected State(string stateName)
		{
			Id = stateName;
		}


		/// <summary>
		/// Setting robot reference - should be called by owning FSM.
		/// </summary>
		public virtual void Init(AdvancedRobotEx ourRobot)
		{
			Robot = ourRobot;
		}


		/// <summary>
		/// Called repeatedly during Update() in the "owning" StateMachine, as long as there are queued states.
		/// </summary>
		public virtual bool DoScanOnRobot()
		{

			//Hvis radaren har funnet en enemy så locker den enemyen
			if (Robot.Enemy.LockOn == true)
			{
				//tar imot gradene som er fra robotoen og i forhold til robotens fiende
				_absoluteBearing = Robot.Heading + Robot.Enemy.BearingDegrees;
				//tar imot gradene radaren må flyye seg, ved at vi regner ut total gradene - roboten sin radar sikt i grader
				_PointToEnemy = Utils.NormalRelativeAngleDegrees(_absoluteBearing - Robot.RadarHeading);

				//Bestemmer scanne området
				double ScanArea = Math.Min(Math.Atan(34 / Robot.Enemy.Distance), Rules.RADAR_TURN_RATE);

				//Dette gjør sånn at hvis ikke radaren er locket inn, så scanner den områder enten høyere eller venstre i forhold til hvor motstanderen gik
				_PointToEnemy += _PointToEnemy < 0 ? -ScanArea : ScanArea;

				//Hvis den ikke finner roboten etter 5 enheter, så setter den lockon false for å ta en ny scan av banen
				if (_PointToEnemy < 60 || _PointToEnemy > 60)
				{
					Robot.Enemy.LockOn = false;
				}
				
				Robot.TurnRadarRight(_PointToEnemy);
				
				return true;
			}
			else
			{
				Robot.TurnRadarRight(20);
				Robot.Scan();
				return false;
			}
		}

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
		/// <summary>
		/// Called once when we transition into this state.
		/// </summary>
		public virtual void EnterState() 
		{
			Robot.SetColors(_BodyColor, _GunColor, _RadarColor, _BulletColor, _ScanArColor);
			//Robot.Out.WriteLine("{0,6} [{1}] entered.", Robot.Time, Id);
		}


		/// <summary>
		/// Called once when we transition out of this state.
		/// </summary>
		public virtual void ExitState()
		{
			// Intentionally left blank.
		}


		/// <summary>
		/// Called once for every Update() in the "owning" StateMachine, as long as this state is queued or it is the active one with an empty queue.
		/// </summary>
		public abstract string ProcessState();
	
	}
}
