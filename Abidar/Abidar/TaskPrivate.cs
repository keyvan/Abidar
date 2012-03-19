using System;
using System.Reflection;
using System.Threading;
using System.Timers;

namespace Abidar
{
    public partial class Task
    {
        private void Initialize()
        {
            this.Stopped = false;
            this.Enabled = true;

            timer = new System.Timers.Timer(this.Interval);
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Enabled = true;
        }

        private void StartTask()
        {
            if (!this.Stopped)
            {
                Thread thread = new Thread(new ThreadStart(Execute));
                thread.Start();
            }
        }

        private void Execute()
        {
            try
            {
                this.IsRunning = true;

                this.LastRunTime = DateTime.Now;

                MethodInfo method = this.TaskType.GetMethod("Execute");
                object[] arguments = { this.ConfigurationNode };

                object obj = Activator.CreateInstance(this.TaskType);

                method.Invoke(obj, new object[] { this.ConfigurationNode });

                this.IsLastRunSuccessful = true;
            }
            catch
            {
                this.IsLastRunSuccessful = false;
            }
            finally
            {
                this.IsRunning = false;
            }
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (!this.IsRunning)
                StartTask();
        }
    }
}
