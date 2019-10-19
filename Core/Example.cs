using AmdOnlyRts.Core.Classes.GameEngine.GameObject.Unit;
using AmdOnlyRts.Core.Classes.GameEngine.Mod;
using AmdOnlyRts.Core.LuaHelp;
using AmdOnlyRts.Networking;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmdOnlyRts.Core
{
	class Example
	{

		//public static void Main()
		//{

			//NetClient client = new NetClient("TestName", 9612);
			//client.SendMessage("HEEEELLLOOO");
			//client.OnMessageReceive += ReceivedMessage;

			//Console.ReadKey();

		//}

		public void ReceivedMessage(string message)
		{
			Console.WriteLine(message);
		}

		void Test()
		{
			/*

			Mod m = new Mod("FirstTest");
			m.ReadLuaFiles();

			//Example getting air units:
			List<AirUnit> airUnits = m.GetObjects<AirUnit>();

			foreach(AirUnit airUnit in airUnits)
			{
				Console.WriteLine("Found Air Unit: ");
				Console.WriteLine("Name: " + airUnit.Name);
				Console.WriteLine("Description: " + airUnit.Description);
				Console.WriteLine(" ");
			}
			*/
		}
	}
}
