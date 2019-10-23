using System;
using System.Collections.Generic;
using System.Linq;
using AmdOnlyRts.Domain.Interfaces.GameEngine.Game;
using AmdOnlyRts.Domain.Interfaces.Networking;
using Newtonsoft.Json;

namespace AmdOnlyRts.Networking.Classes
{
    public class NetLobby : ILobby
    {
        public NetLobby()
        {
            _players = new List<IPlayer>();
            _netPlayers = new Dictionary<string, NetPlayer>();
        }
        [JsonIgnore]
        private IEnumerable<IPlayer> _players;
        
        [JsonIgnore]
        public IEnumerable<IPlayer> Players => _players;
        private Dictionary<string, NetPlayer> _netPlayers;

        public Dictionary<string, NetPlayer> NetPlayers
        {
            get => _netPlayers;
            set
            {
                _netPlayers = value;
                _players = value.Values.Select(x=>(IPlayer)x);
            }
        }
        public Guid GameId { get; set; }
        public string DisplayName { get; set; }
    }
}