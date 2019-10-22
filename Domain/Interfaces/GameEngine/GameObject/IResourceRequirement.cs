
using AmdOnlyRts.Domain.Interfaces.GameEngine.GameObject.Resource;

namespace AmdOnlyRts.Domain.Interfaces.GameEngine.GameObject
{
	public interface IResourceRequirement
	{

        IResource Resource { get; set; }

        int RequiredQuantity { get; set; }
        bool DepletesQuantity { get; set; }
        
    }
}
