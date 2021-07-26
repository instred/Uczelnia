using System;
using System.Threading;

namespace z1
{
    public class Singleton
    {
        private static Singleton _instance;

        private Singleton()
        {
        }

        public static Singleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }
            
            return _instance;
        }
    }

    public class ThreadSingleton
    {
        private static readonly ThreadLocal<ThreadSingleton> LocalInstance = new ThreadLocal<ThreadSingleton>();
        private ThreadSingleton()
        {
        
        }

        public static ThreadSingleton GetInstance()
        {
            if (LocalInstance.Value == null)
            {
                LocalInstance.Value = new ThreadSingleton();
            }
            return LocalInstance.Value;
        }
    }

    public class FiveSecondSingleton
    {
        private static FiveSecondSingleton _instance;
        private static DateTime _timer;
        private FiveSecondSingleton()
        {
        }

        public static FiveSecondSingleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new FiveSecondSingleton();
                _timer = DateTime.Now;
            }
            else
            {
                var interval = DateTime.Now - _timer;
                if (interval.Seconds < 5) return _instance;
                _instance = new FiveSecondSingleton();
                _timer = DateTime.Now;
            }
            return _instance;
        }
    }
}