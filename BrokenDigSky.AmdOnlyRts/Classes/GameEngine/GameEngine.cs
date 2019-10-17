using System;
using System.Collections.Generic;

namespace AMDOnlyRTS.Contracts.Data.Classes.GameEngine
{

    public class GameEngine {
        
        public ulong GameClock { get; set; }

        public Dictionary<ulong, Action> ActionQueue;


        public void Update() {

        }

    }

}