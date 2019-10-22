using System;
using System.Collections.Generic;
using System.IO;
using AmdOnlyRts.Core.Classes.GameEngine.GameObject.Resource;
using AmdOnlyRts.Core.Classes.GameEngine.GameObject.Structure;
using AmdOnlyRts.Core.Classes.GameEngine.GameObject.Unit;
using AmdOnlyRts.Core.LuaHelp;
using AmdOnlyRts.Domain.Interfaces.GameEngine.Mod;


namespace AmdOnlyRts.Core.Classes.GameEngine.Mod
{
	public class Mod : IMod
	{
		public string Name { get; set; }
		public Dictionary<Type, List<object>> Data { get; set; }


		public Mod(string Name)
		{
			this.Name = Name;

			Data = new Dictionary<Type, List<object>>();

			Data.Add(typeof(Unit), new List<object>());
			Data.Add(typeof(Resource), new List<object>());
			Data.Add(typeof(Structure), new List<object>());
			
		}


		public void ReadLuaFiles()
		{
			string ModPath = Directory.GetCurrentDirectory() + @"\Mods\" + Name + @"\";

			//For Each Concrete Class
			foreach (var obj in Data)
			{
				if (!Directory.Exists(ModPath + obj.Key.Name))
				{
					Console.WriteLine("No folder: " + ModPath + obj.Key.Name);
					continue;
				}

				//Find all files in mod pack
				foreach (string file in Directory.GetFiles(ModPath + obj.Key.Name))
				{
					//Create a class:
					var tempobj = Activator.CreateInstance(obj.Key);

					//Generate a generic from the current concrete class type
					var luaHelperT = typeof(LuaHelper);
					var luaMethod = luaHelperT.GetMethod("GetClassFromLua");
					var generic = luaMethod.MakeGenericMethod(tempobj.GetType());
					//Invoke the generic on the concrete class
					var luaHelper = new LuaHelper();
					obj.Value.Add(generic.Invoke(luaHelper, new object[] { file }));
				}
			}
		}


		public List<T> GetObjects<T>()
		{
			List<T> objs = new List<T>();

			foreach(var obj in Data[typeof(T)])
			{
				objs.Add((T)obj);
			}

			return objs;
		}
	}
}
