using NUnit.Framework;
using Z1;

namespace UnitTest {

    public class Tests {

        class Foo {}
        class ABar : AbstractBar {}
        class ABar2 : AbstractBar {}
        abstract class AbstractBar {}
        interface IBar {}
        class Bar3 : IBar {}

        [Test]
        public void Singleton() {
           var simpleContainer = new SimpleContainer();
           simpleContainer.RegisterType<Foo>(true);
           var resolve = simpleContainer.Resolve<Foo>();
           var foo = simpleContainer.Resolve<Foo>();

            Assert.That(resolve, Is.EqualTo(foo));
        }

        [Test]
        public void Unregistered() {
            var simpleContainer = new SimpleContainer();
            var resolve = simpleContainer.Resolve<Foo>();
            
            Assert.IsInstanceOf(typeof(Foo), resolve);
        }


        [Test]
        public void UnregisteredAbstract() {
            var simpleContainer = new SimpleContainer();

            Assert.Throws<Exception>(
                () => simpleContainer.Resolve<AbstractBar>()
            );
        }

        [Test]
        public void AbstractSingleton() {
            var simpleContainer = new SimpleContainer();
            simpleContainer.RegisterType<AbstractBar, ABar>(true);
        
            var resolve = simpleContainer.Resolve<AbstractBar>();
            var foo = simpleContainer.Resolve<AbstractBar>();

            Assert.IsInstanceOf(typeof(ABar), resolve);
            Assert.IsInstanceOf(typeof(ABar), foo);
            Assert.That(resolve, Is.EqualTo(foo));
        }

        [Test]
        public void Abstract() {
            var simpleContainer = new SimpleContainer();
            simpleContainer.RegisterType<AbstractBar, ABar2>(false);

            var resolve = simpleContainer.Resolve<AbstractBar>();
            Assert.IsInstanceOf(typeof(ABar2), resolve);
        }



        [Test]
        public void Interface() {
            var simpleContainer = new SimpleContainer();
            simpleContainer.RegisterType<IBar, Bar3>(true);
        
            var resolve = simpleContainer.Resolve<IBar>();
            var foo = simpleContainer.Resolve<IBar>();

            Assert.IsInstanceOf(typeof(Bar3), resolve);
            Assert.IsInstanceOf(typeof(Bar3), foo);
            Assert.That(resolve, Is.EqualTo(foo));
        }
        
        [Test]
        public void ChangeAType() {
            var simpleContainer = new SimpleContainer();
            simpleContainer.RegisterType<AbstractBar, ABar>(false);
            var resolve = simpleContainer.Resolve<AbstractBar>();

            simpleContainer.RegisterType<AbstractBar, ABar2>(false);
            
            var foo = simpleContainer.Resolve<AbstractBar>();

            Assert.IsInstanceOf(typeof(ABar), resolve);
            Assert.IsInstanceOf(typeof(ABar2), foo);
        }
        
    }
}