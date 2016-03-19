namespace PG4500_2016_Exam1
{

	public class FiniteStateMachine
	{
		private readonly State[] _possibleStates;
		private State _currentState;
		//Har heller en Switchstate som bytter mellom statene.
		private string SwitchState = null;
		
		//Setter alle statene som ble sent fra main/DrRobo til _possiblestates
		public FiniteStateMachine(State[] statesToUse)
		{
			_possibleStates = statesToUse;
		}
		//Tar imot ourRobot fra main og sender den inn i vær states.
		public void Init(AdvancedRobotEx ourRobot)
		{
			foreach (State state in _possibleStates) {
				state.Init(ourRobot);
			}
			// Setter nåværende state til å bli første state som blir sent inn.
			_currentState = _possibleStates[0];

		}

		public string GetCurrentStateId()
		{
			return _currentState.Id;
			
		}
		//Sjekker for vær state i possible state om switchstate er en annen state en nåværende state, hvis den er så bytter den til staten switchstate har fått retur verdi.
		//Hvis ikke switchstate er en annen state, så kjører den staten som er nåværende.
		public void Update()
		{
			foreach (var each in _possibleStates)
			{

				if (SwitchState == each.Id && SwitchState != _currentState.Id)
				{
					_currentState = each;
					_currentState.EnterState();
				}

				else
				{
					_currentState.EnterState();
				}
			
			}
			SwitchState	= _currentState.ProcessState();
		}
	}
}
