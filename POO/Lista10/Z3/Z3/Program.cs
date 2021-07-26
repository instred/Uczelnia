using System;
using System.Configuration;
using System.Globalization;
using System.Windows.Forms;
using Z3.Model;
using Z3.Model.Impl;
using Z3.Views;
using Z3.Views.FrmAddItem;
using Z3.Views.FrmMain;

namespace Z3
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            CompositionRoot();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var frmMain = (TestFrmMain) ViewFactory.CreateFrmMain();
            using (var frmMainPresenter = new FrmMainPresenter(frmMain))
            {
                frmMainPresenter.ShowMe();

                var numberOfPersons = frmMain.NumberOfPersons;
                
                FrmMainPresenter.ShowFrmAddItemDialog();
                FrmAddItemPresenter.AddNewPerson(new Person()
                    {Name = DateTime.Now.ToString(CultureInfo.InvariantCulture), Surname = DateTime.Now.ToString(CultureInfo.InvariantCulture)});

                var newNumberOfPersons = frmMain.NumberOfPersons;
                
                Console.WriteLine("{0} {1}", numberOfPersons, newNumberOfPersons);
            }

            Console.ReadLine();


            static void CompositionRoot()
            {

                ViewFactory.SetProvider(new WindowsFormsViewFactory());



                ViewFactory.SetProvider(new TestViewFactory());



                UnitOfWorkFactory.SetProvider(() =>
                {
                    var cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
                    return new SqlUnitOfWork(cs);
                });
            }
        }

        private class WindowsFormsViewFactory : IViewFactory
        {
            public IFrmAddItem CreateFrmAddItem()
            {
                return new FrmAddItem();
            }

            public IFrmMain CreateFrmMain()
            {
                return new FrmMain();
            }
        }

        private class TestViewFactory : IViewFactory
        {
            public IFrmAddItem CreateFrmAddItem()
            {
                return new TestFrmAddItem();
            }

            public IFrmMain CreateFrmMain()
            {
                return new TestFrmMain();
            }
        }
    }
}