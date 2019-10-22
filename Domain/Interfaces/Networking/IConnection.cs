using System;
using System.Threading.Tasks;

namespace AmdOnlyRts.Domain.Interfaces.Networking
{
    public interface IConnection : IDisposable
    {
        Task DisconnectAsync();
        ILobby CurrentLobby { get; }
        Task SendActionAsync(long gameTime, IAction action);
        Task<(long gameTime, IAction action)> GetNextAction();
    }
}