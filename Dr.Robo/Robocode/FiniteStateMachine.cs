using System;
using System.Collections.Generic;
using Dr.Robo;
using Robocode;

namespace Dr.Robo
{
	/// <summary>
	/// Generic Finite State Machine class, for hardcoded FSMs.
	/// version: 1.0
	/// author: Tomas Sandnes - santom@westerdals.no
	/// </summary>
	public class FiniteStateMachine
	{
		// P R I V A T E / P R O T E C T E D   V A R S
		// -------------------------------------------

		private const int SpinCount = 10;  // Max number of state transitions in one round before we trigger spin.
		private readonly State[] _possibleStates;
		private State _currentState;
		private State _nextState;
		private string SwitchState = null;
		
	
		// P U B L I C   M E T H O D S 
		// ---------------------------

		/// <summary>
		/// Constructor.
		/// </summary>
		public FiniteStateMachine(State[] statesToUse)
		{
			_possibleStates = statesToUse;
		}


		/// <summary>
		/// Note: Init method MUST be called prior to the first call to Update() !!!
		/// </summary>
		public void Init(AdvancedRobotEx ourRobot) 
		{
			// Init all the states
			foreach (State state in _possibleStates) {
				state.Init(ourRobot);
			}
			// Set the first state in the array as the current state when the FSM is init'ed.
			_currentState = _possibleStates[0];
			_nextState = _possibleStates[0];
			
		}


		/// <summary>
		/// Return current state's Id.
		/// </summary>
		public string GetCurrentStateId()
		{
			return _currentState.Id;
			
		}




		/// <summary>
		/// Go through the state queue, processing each queued state once. (If no states are queued, process the current state once instead.)
		/// </summary>
		public void Update()
		{
			Console.WriteLine(_currentState);
			_currentState.EnterState();
		  SwitchState = _currentState.ProcessState();
			
				foreach (var EachState in _possibleStates)
				{
				if (EachState.Id == SwitchState && !(SwitchState == _currentState.Id))
				{

					_currentState = EachState;

				}
				else
				{
					_currentState.ProcessState();
				}
			}
		}

	}
}
