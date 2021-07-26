using z2;

namespace testy
{
    [TestFixture]
    public class Testy
    {
        [Test]
        public void Test1()
        {
            ShapeFactory factory = new ShapeFactory();

            IShape square = factory.CreateShape("Square", 4);
            IShape circle = factory.CreateShape("Circle", 5 );

            Assert.IsNotNull(square);
            Assert.IsNull(circle);
            Assert.AreNotEqual(square, circle);

        }
    }
}
        