using System;
using System.Collections.Generic;

namespace z2
{
    class z2
    {

        public static void Main(string[] args)
        {

        }
    }
    public interface IShape{}
    
    public class Square : IShape
    {
        public int Side { get; set; }
    }
    
    public class Circle : IShape {
        public double Radius {get; set;}
        public double GetArea() {
            return System.Math.PI * Radius * Radius;
        }
 
    }
    public interface IFactoryWorker
    {
        bool Parameter(string name, params object[] parameters);

        IShape Create(params object[] parameters);
    }
    
    public class CircleWorker : IFactoryWorker {
        public bool Parameter(string name, params object[] parameters)
        {
            return name.Equals("Circle") && parameters.Length == 1 && parameters[0] is double;
        }

        public IShape Create(params object[] parameters)
        {
            return new Circle() {Radius = (int) parameters[0]};
        }
    }

    public class SquareWorker : IFactoryWorker
    {
        public bool Parameter(string name, params object[] parameters)
        {
            return name.Equals("Square") && parameters.Length == 1;
        }
        public IShape Create(params object[] parameters)
        {
            return new Square() { Side = (int)parameters[0] };
        }

    }
	
	public interface IShapeFactory
    {
        void AddWorker(IFactoryWorker worker);
        IShape CreateShape(string shapeName, params object[] parameters);
    }
	
    public class ShapeFactory : IShapeFactory
    {
        private readonly List<IFactoryWorker> _workers;

        public ShapeFactory()
        {
            _workers = new List<IFactoryWorker>();
            _workers.Add(new SquareWorker());
        }
        public void AddWorker(IFactoryWorker worker)
        {
            _workers.Add(worker);
        }
        public IShape CreateShape(string type, params object[] parameters)
        {
            foreach (IFactoryWorker worker in _workers)
            {
                if (worker.Parameter(type,parameters))
                {
                    IShape newShape = worker.Create(parameters);
                    return newShape;
                }

            }
            return null;
        }
    }


}