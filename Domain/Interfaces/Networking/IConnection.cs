using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmdOnlyRts.Domain.Interfaces.Networking
{
  public interface IConnection : IDisposable
  {
		Task ConnectLocalAsync();
		Task ConnectDedicatedAsync();
		Task DisconnectAsync();
    Task<IEnumerable<ILobby>> GetLobbyListing();
    Guid ConnectionId { get; }
    ILobby CurrentLobby { get; }
    Task SendActionAsync(long gameTime, IAction action);
    Task<(long gameTime, IAction action)> GetNextAction();
  }
}
