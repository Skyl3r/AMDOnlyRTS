using BrokenDigSky.AmdOnlyRts.Domain.Interfaces.GameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMDOnlyRTS.Contracts.Data.Classes.GameEngine
{

    public class GameEngine {
        public ulong GameClock { get; set; }

        public Dictionary<ulong, Action> ActionQueue;

    }

}