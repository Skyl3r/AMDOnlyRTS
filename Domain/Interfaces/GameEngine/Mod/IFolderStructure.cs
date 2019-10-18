using System.Collections.Generic;


namespace AmdOnlyRts.Domain.Interfaces.GameEngine.Mod
{
	public interface IFolderStructure
	{
		Dictionary<string, string> folders { get; set; }
	}
}
