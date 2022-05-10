using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DIntroductionProject
{
    internal class Monitoring
    {
        #region Fields
        private long _startTime = 0;
        private long _currentTime = 0;
        private int _frames = 0;
        private double _framesPerSecond = 0;

        private readonly int  _refreshInterval = 50;
        #endregion

        public double FPS { get { return _framesPerSecond; } }
        public int FramesElapsed { get { return _frames; } }

        public Monitoring()
        {
            _startTime = NanoTime();
            //_monitors = new long[5];
            //_timeSpentComparisons = new double[5];
        }

        #region Instance Methods
        public void FramePassed()
        {
            _frames++;
            if(_frames == _refreshInterval)
            {
                _currentTime = NanoTime();
                _framesPerSecond = 1000000000d * (double)_frames / (double)(_currentTime - _startTime);
                
                _frames = 0;
                _startTime = NanoTime();
            }
        }

        /// <summary>
        /// Accurate measurement of System time used for determining frame rate.
        /// </summary>
        /// <returns>System time in nanoseconds</returns>
        private long NanoTime()
        {
            long nano = 10000L * System.Diagnostics.Stopwatch.GetTimestamp();
            nano /= TimeSpan.TicksPerMillisecond;
            nano *= 100L;
            return nano;
        }
        #endregion
    }
}
