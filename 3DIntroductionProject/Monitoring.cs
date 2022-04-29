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

        private long[] _monitors;
        private double[] _timeSpentComparisons;

        private int _refreshInterval = 10;
        #endregion

        public double FPS { get { return _framesPerSecond; } }

        public double[] TimeSpentComparisons { get { return _timeSpentComparisons; } }

        public Monitoring()
        {
            _startTime = NanoTime();
            _monitors = new long[5];
            _timeSpentComparisons = new double[5];
        }

        #region Instance Methods
        public void FramePassed()
        {
            _frames++;
            _currentTime = NanoTime();
            long timePassed = _currentTime - _startTime;
            for(int i = 0; i < 5; i++)
            {
                _timeSpentComparisons[i] = (double)_monitors[0] / (double)timePassed;
            }

            if(_frames >= _refreshInterval)
            {
                _framesPerSecond = 1000000000 * _frames / (double)(_currentTime - _startTime);
                Refresh();
            }
        }

        public void Refresh()
        {
            _frames = 0;
            _startTime = NanoTime();
            _currentTime = NanoTime();
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

        public void Log(int index)
        {
            if(index == 0)
            {
                _monitors[0] += _startTime - NanoTime();
            }
            else
            {
                _monitors[index] += _monitors[index - 1] - NanoTime();
            }
        }
        #endregion
    }
}
