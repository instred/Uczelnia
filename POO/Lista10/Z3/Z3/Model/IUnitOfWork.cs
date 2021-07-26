using System;

namespace Z3.Model
{
    public interface IUnitOfWork : IDisposable
    {
        IPersonRepository Person { get; }
        new void Dispose();
    }
}
