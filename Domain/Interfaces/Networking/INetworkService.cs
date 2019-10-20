
using System;

namespace AmdOnlyRts.Domain.Interfaces.Networking
{
	public interface INetworkService
	{
    IConnection CreateLanGame(int port);
    IConnection CreatePublicGame();
    IConnection ConnectToServer(string address, int port);
    IConnection JoinDirectGame(string address, int port);
	}
}
