using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokenDigSky.AmdOnlyRts.Domain.Interfaces.GameEngine.Mod
{
	public interface IMod
	{
		string Name { get; set; }
		Dictionary<Type, List<Object>> Data { get; set; }

		void ReadLuaFiles();
	}
}
