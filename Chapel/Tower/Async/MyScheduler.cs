namespace Tower.Async
{
    public class MyScheduler : TaskScheduler
    {
        private readonly LinkedList<Task> _tasks = new LinkedList<Task>();

        protected override IEnumerable<Task>? GetScheduledTasks()
        {
            bool lockTaken = false;
            try
            {
                Monitor.TryEnter(_tasks, ref lockTaken);
                if (lockTaken) return _tasks;
                else throw new NotSupportedException();
            }
            finally
            {
                if (lockTaken) Monitor.Exit(_tasks);
            }
        }

        private void NotifyThreadPoolOfPendingWork()
        {
            ThreadPool.QueueUserWorkItem(_ =>
            {
                try
                {
                    while (true)
                    {
                        Task item;
                        lock (_tasks)
                        {
                            if (_tasks.Count == 0)
                            {
                                break;
                            }

                            item = _tasks.First.Value;
                            _tasks.RemoveFirst();
                        }

                        base.TryExecuteTask(item);
                    }
                }
                finally { }
            }, null);
        }

        protected override void QueueTask(Task task)
        {
            lock (_tasks)
            {
                _tasks.AddLast(task);
                this.NotifyThreadPoolOfPendingWork();
            }
        }

        protected sealed override bool TryDequeue(Task task)
        {
            lock (_tasks) return _tasks.Remove(task);
        }

        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            if (taskWasPreviouslyQueued)
                if (TryDequeue(task))
                    return base.TryExecuteTask(task);
                else
                    return false;
            else
                return base.TryExecuteTask(task);
        }
    }
}
