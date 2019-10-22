using System.Collections.Generic;

namespace AmdOnlyRts.Domain.Interfaces.GameEngine.GameObject
{
	public interface ICreatable
	{

        // In Game Time
		int BuildTime { get; set; }

        List<IResourceRequirement> Requirements { get; set; }

        List<IGameObject> Creates { get; set; }
        
        
    }
}
