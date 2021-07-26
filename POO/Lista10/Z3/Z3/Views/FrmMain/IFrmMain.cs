using System.Collections.Generic;
using Z3.Model;

namespace Z3.Views.FrmMain
{
    public interface IFrmMain
    {
        FrmMainPresenter Presenter { get; set; }
        void InitializeData(IEnumerable<Person> persons);
        void ShowNonModal();
    }
}
