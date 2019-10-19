using System;
using System.Threading.Tasks;

namespace AmdOnlyRts.Domain.Interfaces.Networking
{
  public interface IConnection : IDisposable
  {
		Task ConnectLocalAsync();
		Task ConnectDedicatedAsync();
		Task DisconnectAsync();
    Guid ConnectionId { get; }
    Task<long> PingAsync();
    Task SendActionAsync(long gameTime, IAction action);
    Task<(long gameTime, IAction action)> GetNextAction();
    Task SyncronizeAsync(long gameTime);
  }
}
