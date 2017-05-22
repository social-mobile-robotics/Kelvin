using System;
using System.Windows.Threading;

namespace Kelvin.Infrastructure.Services {

    // for ChasisStateMachine and KinectDataProvider
    public class ClockGenerationService {

        private DispatcherTimer timer;

        public Action NextClockTime;

        public void Start() => timer.Start();
        public void Stop() => timer.Stop();

        public ClockGenerationService() {
            timer = new DispatcherTimer(DispatcherPriority.Input);
            timer.Interval = TimeSpan.FromSeconds(1.0 / 30.0);
            timer.Tick += (s, e) => NextClockTime?.Invoke();
        }
    }
}