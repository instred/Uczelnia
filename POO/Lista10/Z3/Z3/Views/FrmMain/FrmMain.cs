using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Z3.Model;

namespace Z3.Views.FrmMain
{
    public partial class FrmMain : Form, IFrmMain
    {
        public FrmMainPresenter Presenter { get; set; }

        public FrmMain()
        {
            InitializeComponent();
        }

        public void ShowNonModal()
        {
            Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmMainPresenter.ShowFrmAddItemDialog();
        }

        public void InitializeData(IEnumerable<Person> persons)
        {
            lstPerson.Items.Clear();
            lstPerson.Columns.Clear();

            lstPerson.Columns.Add("Name", 60);
            lstPerson.Columns.Add("Surname", -2);

            foreach (var person in persons)
            {
                var li = lstPerson.Items.Add(person.Name);
                li.SubItems.Add(person.Surname);
                li.Tag = person.Id;
            }
        }
    }
}
