using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace YourMouseMaster
{
    class SimulationInfo
    {
        // counter
        public int IterationCounter;
        public int StepsCounter;
        public long MillisecondsCounter;
        public Stopwatch SimStopWatch;

        // max-settings
        public int MaxIterations;
        public int MaxSteps;
        public int MaxMilliseconds;

        public SimulationInfo()
        {
            IterationCounter = 0;
            MillisecondsCounter = 0;
            SimStopWatch = new Stopwatch();
            Reset();
        }

        public void Reset()
        {
            StepsCounter = 0;
            IterationCounter = 0;
            MillisecondsCounter = 0;
            SimStopWatch.Stop();
            SimStopWatch.Reset();

            // max settings
            MaxIterations= -1;
            MaxSteps= -1;
            MaxMilliseconds= -1;
        }
    }

}
