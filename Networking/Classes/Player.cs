using System;
using AmdOnlyRts.Domain.Interfaces.Networking;

namespace AmdOnlyRts.Networking.Classes
{
  public class Player : INetPlayer
  {
    public string DisplayName { get; set; }
    public Guid PlayerId { get; set; }
    public string Name { get; set; }
    public string Team { get; set; }
  }
}