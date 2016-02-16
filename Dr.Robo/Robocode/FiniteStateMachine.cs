using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dr.Robo.Robocode.States;


namespace Dr.Robo.Robocode
{
	public class FiniteStateMachine
	{
		private readonly State[] _States;
		private readonly Queue<State> _transitionQueue;

		public FiniteStateMachine(State[] stateToUse)
		{
			stateToUse = new State[1];
			_transitionQueue = new Queue<State>();

			_transitionQueue.Enqueue(stateToUse[1] = new DefaultState());

			UseState();
		}

		private void UseState()
		{
			
		}
	}
}
