using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dr.Robo.Robocode
{
	public abstract class State
	{
		public string Id { get; private set; }

		protected State(string stateName)
		{
			Id = stateName;
		}
	}
}
