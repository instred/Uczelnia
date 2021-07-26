using Z3.Views.FrmAddItem;
using Z3.Views.FrmMain;

namespace Z3.Views
{
    public class ViewFactory
    {
        private static IViewFactory _provider;

        public static void SetProvider( IViewFactory provider )
        {
            _provider = provider;
        }

        public static IFrmAddItem CreateFrmAddItem()
        {
            return _provider.CreateFrmAddItem();
        }

        public static IFrmMain CreateFrmMain()
        {
            return _provider.CreateFrmMain();
        }
    }

    public interface IViewFactory
    {
        IFrmAddItem CreateFrmAddItem();
        IFrmMain CreateFrmMain();
    }
}
