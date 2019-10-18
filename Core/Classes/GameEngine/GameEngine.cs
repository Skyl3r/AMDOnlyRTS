using System;
using System.Collections.Generic;

namespace AMDOnlyRTS.Core.GameEngine
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