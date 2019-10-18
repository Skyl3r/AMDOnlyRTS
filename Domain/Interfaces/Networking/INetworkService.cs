
namespace AmdOnlyRts.Domain.Interfaces.Networking
{
	public interface INetworkService
	{
    IConnection CreateLanGame(int port);
    IConnection JoinDirectGame(string address, int port);
	}
}
