using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokenDigSky.AmdOnlyRts.Domain.Interfaces.GameEngine
{
	public interface IGameObject
	{

		string Name { get; set; }
		string Description { get; set; } 

		void OnSelected();

	}
}
