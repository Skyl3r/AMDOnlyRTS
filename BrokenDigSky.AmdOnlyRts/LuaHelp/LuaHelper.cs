using System;
using System.IO;
using NLua;

namespace AMDOnlyRTS.GameEngine.LuaHelp
{
	public class LuaHelper
	{

		public T GetClassFromLua<T>(string pathToLua) where T : new()
		{
			//Verify Lua file referenced exists
			if (!File.Exists(pathToLua))
				throw new Exception("Lua file does not exist");

			//Initiate Lua and execute file
			Lua state = new Lua();
			state.DoFile(pathToLua);


			//Create object
			T obj = new T();

			//Get properties
			var interfaceType = typeof(T);
			var variables = interfaceType.GetProperties();

			foreach (var property in variables)
			{
				//Check if this property was set in Lua
				if (state[property.Name] == null)
					continue;

				
				//Set it in the class
				property.SetValue(obj, state[property.Name]);
			}
			
			return obj;
		}

	}
}
