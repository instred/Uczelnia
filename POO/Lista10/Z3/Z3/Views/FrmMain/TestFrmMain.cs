using System.Collections.Generic;
using System.Linq;
using Z3.Model;

namespace Z3.Views.FrmMain
{
    public class TestFrmMain : IFrmMain
    {
        public FrmMainPresenter Presenter { get; set; }

        private IEnumerable<Person> _persons;

        public void InitializeData(IEnumerable<Person> persons)
        {
            _persons = persons;
        }

        public void ShowNonModal()
        {
            throw new System.NotImplementedException();
        }


        public int NumberOfPersons => _persons.Count();
    }
}
