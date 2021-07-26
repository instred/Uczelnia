using System;
using Z3.Model;
using Z3.Views.FrmAddItem;

namespace Z3.Views.FrmMain
{
    public class FrmMainPresenter : IDisposable, ISubscriber<PersonAddedNotification>
    {
        private readonly IFrmMain _view;
        public FrmMainPresenter( IFrmMain view )
        {
            _view = view;
            _view.Presenter = this;

            InitializeData();

            EventAggregator.Instance.AddSubscriber(this);
        }

        public void Dispose()
        {
            EventAggregator.Instance.RemoveSubscriber(this);
        }

        private void InitializeData()
        {
            using var uow = UnitOfWorkFactory.Create();
            _view.InitializeData(uow.Person.GetAll());
        }

        public void ShowMe()
        {
            _view.ShowNonModal();
        }

        public static FrmAddItemPresenter ShowFrmAddItemDialog()
        {
            var frmAddItem = ViewFactory.CreateFrmAddItem();
            var frmAddItemPresenter = new FrmAddItemPresenter(frmAddItem);
            frmAddItemPresenter.ShowMe();

            return frmAddItemPresenter;
        }

        void ISubscriber<PersonAddedNotification>.Handle()
        {
            InitializeData();
        }

    }
}
