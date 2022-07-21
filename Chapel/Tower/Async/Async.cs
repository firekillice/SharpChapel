namespace Tower.Async
{
    public static class HelloAsync
    {
        public static void FirstView()
        {
            Console.WriteLine($"main thread {Task.CurrentId},{Thread.CurrentThread.ManagedThreadId}");

            Action<object> action = (object obj) =>
            {
               //Thread.Sleep(2000);
                Console.WriteLine($"single action {Task.CurrentId},{obj},{Thread.CurrentThread.ManagedThreadId}");
                
            };
            Task t1 = new(action, "alpha");
            t1.Start();

            Task t2 = Task.Factory.StartNew(action, "beta");
            t2.Wait();

            String taskData = "delta";
            Task t3 = Task.Run(() =>
            {
                Console.WriteLine("Task={0}, obj={1}, Thread={2}", Task.CurrentId, taskData, Thread.CurrentThread.ManagedThreadId);
            });
            t3.Wait();

            Task t4 = new Task(action, "gamma");
            t4.RunSynchronously();
            t4.Wait();

            MultiDispatch();
        }

        public static void MultiDispatch()
        {
            for (var i = 0; i < 10000; i++)
            {
                var j = i;
                Task.Run(() => { Console.WriteLine($"index:{j}taskId:{ Task.CurrentId } threadid {Thread.CurrentThread.ManagedThreadId}"); });
            }
        }

        public static void ViewSchedule()
        {
            var myscheduler = new MyScheduler();
            var factory = new TaskFactory(myscheduler);
            for (var i = 0; i < 10000; i++)
            {
                var j = i;
                factory.StartNew(() => { Console.WriteLine($"index:{j}taskId:{ Task.CurrentId } threadid {Thread.CurrentThread.ManagedThreadId}"); });
            }
        }



    }
}
