using System;
using System.Diagnostics;
using System.Threading;
using z1;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    class UnitTestProject1
    {
        [Test]
        public void TestSingleton1()
        {
            Singleton sington1, sington2;
            sington1 = Singleton.GetInstance();
            sington2 = Singleton.GetInstance();
            
            Assert.IsNotNull(sington2);
            Assert.AreSame(sington1, sington2);
        }

        [Test]
        public void TestSingleton2()
        {
            Thread thread1, thread2;
            ThreadSingleton sington1, sington2;
            thread1 = new Thread(() =>
                {
                    sington1 = ThreadSingleton.GetInstance();
                }
            );
            thread2 = new Thread(() =>
                {
                    sington2 = ThreadSingleton.GetInstance();
                }
            );

            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();
            Assert.IsNotNull(sington1);
            Assert.IsNotNull(sington2);
            Assert.AreNotSame(sington1, sington2);
        }

        [Test]
        public void TestSingleton3()
        {
            var sington1 = FiveSecondSingleton.GetInstance();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            var sington2 = FiveSecondSingleton.GetInstance();
            Thread.Sleep(TimeSpan.FromSeconds(5));
            var sington3 = FiveSecondSingleton.GetInstance();

            Assert.AreSame(sington1, sington2);
            Assert.AreNotSame(sington1, sington3);
            Assert.AreNotSame(sington2, sington3);
        }
    }
}