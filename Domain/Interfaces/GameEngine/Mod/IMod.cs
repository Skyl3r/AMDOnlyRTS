using System;
using System.Collections.Generic;

namespace AmdOnlyRts.Domain.Interfaces.GameEngine.Mod
{
	public interface IMod
	{
		string Name { get; set; }
		Dictionary<Type, List<Object>> Data { get; set; }

		void ReadLuaFiles();
	}
}
