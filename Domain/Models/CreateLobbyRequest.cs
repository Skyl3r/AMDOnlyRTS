using System;
using AmdOnlyRts.Domain.Enums;
using AmdOnlyRts.Domain.Interfaces.Networking;

namespace AmdOnlyRts.Domain.Models
{
  public class CreateLobbyRequest
  {
    public GameType GameType { get; set; }
    public INetPlayer Player { get; set;}
    public string Name { get; set; }
  }
}
