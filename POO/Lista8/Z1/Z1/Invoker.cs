using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


namespace z1
{

    public class Invoker
    {
        private const int QueueSize = 5;
        private readonly Queue<ICommand> _queue = new();
        private const int MinGeneratorSleepTime = 1500;
        private const int MaxGeneratorSleepTime = 2500;

        private const int MinDispatcherSleepTime = 4500;
        private const int MaxDispatcherSleepTime = 5500;

        private void Generate()
        {
            while (true)
            {
                var random = new Random(Guid.NewGuid().GetHashCode());
                ICommand command = (random.Next() % 4) switch
                {
                    0 => new FileMethods.DownloadFtpCommand("FTP Address " + random.Next()),
                    1 => new FileMethods.DownloadHttpCommand("HTTP Address " + random.Next()),
                    2 => new FileMethods.CreateFileCommand("PATH NUMBER " + random.Next()),
                    _ => new FileMethods.CopyFileCommand(random.Next().ToString(), random.Next().ToString())
                };
                AddCommand(command);
                Thread.Sleep(random.Next(MinGeneratorSleepTime,MaxGeneratorSleepTime));
            }
        }
        
        private void Dispatch()
        {
            while (true)
            {
                var rand = new Random(Guid.NewGuid().GetHashCode());
                var command = GetCommand();
                command.Execute();
                Thread.Sleep(rand.Next(MinDispatcherSleepTime, MaxDispatcherSleepTime));
            }
   
        }
        private void AddCommand(ICommand command)
        {
            lock (this)
            {
                while (_queue.Count() > QueueSize)
                {
                    Monitor.Wait(this,300);
                }

                Console.WriteLine("Generuję dane");
                _queue.Enqueue(command);
            }

        }
        
        private ICommand GetCommand()
        {
            lock (this)
            {
                while (_queue.Count == 0)
                {
                    Monitor.Wait(this,500);
                }
                return _queue.Dequeue();
            }
        }
        
        public void Run()
        {
            var generator = new Thread(Generate);
            var dis1 = new Thread(Dispatch);
            var dis2 = new Thread(Dispatch);



            generator.Start();
            dis1.Start();
            dis2.Start();

            generator.Join();
            dis1.Join();
            dis2.Join();

        }
    }
}