using System;
using System.Collections.Generic;

namespace AMDOnlyRTS.Contracts.Data.Classes.GameEngine
{

    public class GameEngine {
        
        public Dictionary<long, Action> ActionQueue;

        public GameClock gameClock;

        public GameEngine() {
            gameClock.OnTick += OnTick;
            
        }

        public void Update() {

        }

        public void OnTick(long currentTime) {
            
        }
    }

}