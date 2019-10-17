using BrokenDigSky.AmdOnlyRts.Domain.Interfaces.GameEngine.Mod;
using System.Collections.Generic;

namespace AMDOnlyRTS.Contracts.Data.Classes.GameEngine.Mod
{
	public class FolderStructure : IFolderStructure
	{
		public Dictionary<string, string> folders
		{
			get { return folders; }
			set { folders = value; }
		}

		public FolderStructure()
		{
			folders = new Dictionary<string, string>();
			
			//SET DEFAULT STRUCTURE
			folders.Add("AirUnit", "/units/air");
			folders.Add("LandUnit", "/units/land");
			folders.Add("NavalUnit", "/units/naval");

			folders.Add("Garrison", "/structure/garrison");
			folders.Add("StaticDefense", "/structure/staticdefense");
			folders.Add("Structure", "/structure");
			folders.Add("AirFactory", "/structure/unitfactory/air");
			folders.Add("LandFactory", "/structure/unitfactory/land");
			folders.Add("NavalFactory", "/structure/unitfactory/naval");


			folders.Add("Energy", "/structure/resourcecollector/energy");
			folders.Add("Supply", "/structure/resourcecollector/supply");
			folders.Add("Mass", "/structure/resourcecollector/mass");
		}
	}
}
