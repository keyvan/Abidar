using System;
using System.Xml;

namespace Abidar
{
    public partial class Task
    {
        System.Timers.Timer timer = null;

        public string Name { get; set; }

        public Type TaskType { get; set; }

        public bool IsRunning { get; set; }

        public bool Enabled { get; set; }

        public DateTime LastRunTime { get; set; }

        public bool IsLastRunSuccessful { get; set; }

        public double Interval { get; set; }

        public bool Stopped { get; set; }

        public XmlNode ConfigurationNode { get; set; }

        public Priority Priority { get; set; }

        public Task(double interval)
        {
            this.Interval = interval;
            Initialize();
        }

        public void Start()
        {
            this.Stopped = false;
            this.StartTask();
        }

        public void Stop()
        {
            this.Stopped = true;
        }
    }
}
