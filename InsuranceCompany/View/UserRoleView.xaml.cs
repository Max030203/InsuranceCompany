using InsuranceCompany.Model;
using InsuranceCompany.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace InsuranceCompany.View
{
    /// <summary>
    /// Логика взаимодействия для UserRoleView.xaml
    /// </summary>
    public partial class UserRoleView : Window
    {
        public UserRoleViewModel Model { get; set; }
        public UserRoleView(DataModel data, string action, UserRole userRole)
        {
            InitializeComponent();
            Model = new UserRoleViewModel(data, action, userRole);
            this.DataContext = Model;

            if (Model.Close == null)
                Model.Close = new Action(this.Close);
        }
    }
}
