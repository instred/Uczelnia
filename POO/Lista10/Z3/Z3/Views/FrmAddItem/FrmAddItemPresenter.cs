using Z3.Model;

namespace Z3.Views.FrmAddItem
{
    public class FrmAddItemPresenter
    {
        private readonly IFrmAddItem _view;
        public FrmAddItemPresenter( IFrmAddItem view )
        {
            _view = view;
            _view.Presenter = this;
        }

        public void ShowMe()
        {
            _view.ShowModal();
        }

        public static void AddNewPerson( Person person )
        {
            using var uow = UnitOfWorkFactory.Create();
            uow.Person.Insert(person);

            EventAggregator.Instance.Publish<PersonAddedNotification>();
        }
    }
}
