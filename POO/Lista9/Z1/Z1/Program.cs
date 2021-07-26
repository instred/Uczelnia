using System;
using System.Collections.Generic;
using System.Reflection;

namespace Z1 {

    public class SimpleContainer {

        public void RegisterType<T>(bool sgt) where T : class {
            Type type = typeof(T);
            var constructorInfo = FindConstructor(type);
            if (sgt) {
                _instanceCreators[type] = new SingletonCreator(constructorInfo);
            } else {
                _instanceCreators[type] = new ObjectCreator(constructorInfo);
            }
        }

        public void RegisterType<TFrom, TO>(bool sgt) where TO : TFrom {
            var typeFrom = typeof(TFrom);
            var typeTo = typeof(TO);

            var constructorInfo = FindConstructor(typeTo);
            if (sgt) {
                _instanceCreators[typeFrom] = new SingletonCreator(constructorInfo);
            } else {
                _instanceCreators[typeFrom] = new ObjectCreator(constructorInfo);
            }
        }

        public T Resolve<T>() where T : class
        {
            while (true)
            {
                var type = typeof(T);
                var objectCreator = GetCreator(type);

                if (objectCreator != null) return (T) objectCreator.CreateObject();
                if (type.IsAbstract || type.IsInterface)
                {
                    string @class = type.IsAbstract ? "abstract class" : "interface";
                    string format = string.Format("unregistered {1} type {0}", type, @class);
                    throw new Exception(format);
                }

                RegisterType<T>(false);
            }
        }
        private static ConstructorInfo FindConstructor(Type type)
        {
            return type.GetConstructor(new Type[] { });
        }

        private interface IObjectCreator {
            object CreateObject();
        }
        
        private IObjectCreator GetCreator(Type type) {
            return type != null && _instanceCreators.TryGetValue(type, value: out var creator) 
                ? creator 
                : null;
        }

        private class SingletonCreator : IObjectCreator {
            private object _instance;
            private readonly ConstructorInfo _constructorInfo;

            public SingletonCreator(ConstructorInfo constructorInfo) {
                _constructorInfo = constructorInfo;
            }

            public object CreateObject()
            {
                return _instance ?? (_instance = _constructorInfo.Invoke(new object[] { }));
            }            
        }
        private readonly Dictionary<Type, IObjectCreator> _instanceCreators;
        public SimpleContainer() {
            _instanceCreators = new Dictionary<Type, IObjectCreator>();
        }
        private class ObjectCreator : IObjectCreator {
            private readonly ConstructorInfo _constructor;

            public ObjectCreator(ConstructorInfo constructor) {
                _constructor = constructor;
            }

            public object CreateObject() => _constructor.Invoke(new object[] {});
        }
    }
    public class Exception : System.Exception {
        public Exception()
            : base("Unregistered interface type") {}

        public Exception(string exception)
            : base(exception) {}
    }

    public static class Example
    {
        public static void Main()
        {
            ;
        }
    }
}