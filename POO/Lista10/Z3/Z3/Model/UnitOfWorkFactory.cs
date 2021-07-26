using System;

namespace Z3.Model
{
    public static class UnitOfWorkFactory
    {
        private static Func<IUnitOfWork> _provider;

        public static void SetProvider( Func<IUnitOfWork> provider )
        {
            _provider = provider;
        }

        public static IUnitOfWork Create()
        {
            return _provider();
        }
    }
}
