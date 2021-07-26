
using System.Collections.Generic;


namespace Z3.Model
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetAll();
        void Insert(Person person);
    }
}
