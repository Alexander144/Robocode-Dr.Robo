using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dr.Robo.Robocode
{
	public class FiniteStateMachine
	{
		private readonly State[] _States;
		private readonly Queue<State> _transitionQueue;

		public FiniteStateMachine(State[] stateToUse)
		{
			_States = stateToUse;
			_transitionQueue = new Queue<State>();
			
		}
	}
}
