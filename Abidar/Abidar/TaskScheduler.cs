using System.Collections.Generic;
using System.Xml;

namespace Abidar
{
    public partial class TaskScheduler
    {
        public static List<Task> _tasks = null;
        private XmlNodeList _nodes = null;

        public TaskScheduler(XmlNodeList nodes)
        {
            this._nodes = nodes;
            Initialize();
        }

        public void StartTasks()
        {
            foreach (Task task in _tasks)
            {
                if (!task.IsRunning)
                    task.Start();
            }
        }

        public void StopTasks()
        {
            foreach (Task task in _tasks)
            {
                task.Stop();
            }
        }
    }
}
