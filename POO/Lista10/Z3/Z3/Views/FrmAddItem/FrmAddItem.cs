using System;
using System.Windows.Forms;
using Z3.Model;

namespace Z3.Views.FrmAddItem
{
    public partial class FrmAddItem : Form, IFrmAddItem
    {
        public FrmAddItem()
        {
            InitializeComponent();
        }

        public FrmAddItemPresenter Presenter { get; set; }

        public void ShowModal()
        {
            ShowDialog();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            var name = txtName.Text;
            var surname = txtSurname.Text;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname)) return;
            var person = new Person {Name = name, Surname = surname};
            FrmAddItemPresenter.AddNewPerson(person);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
