using System.Diagnostics;

namespace AMDOnlyRTS.Contracts.Data.Classes.GameEngine
{
    public delegate void OnTick(long clock);

    public class GameClock {
        
        public event OnTick OnTick;
        private long CurrentGameTime;
        private int TickLength = 10; //Tick Length in MS

        private Stopwatch stopwatch;

        public GameClock() {
            stopwatch = new Stopwatch();
        }
        public GameClock(int tickLength) {
            stopwatch = new Stopwatch();
            TickLength = tickLength;
        }

        public void Start() {
            CurrentGameTime = 0;
            stopwatch.Start();
        }

        public void Update() {
            //Get current time in MS
            long currentMsTime = stopwatch.ElapsedMilliseconds;
            
            //Convert time to gametime
            long ActualGameTime = currentMsTime / TickLength;

            //Check if time is on next tick
            if(ActualGameTime > CurrentGameTime) {
                CurrentGameTime = ActualGameTime;
                OnTick(CurrentGameTime);
            }
        }
    }

}