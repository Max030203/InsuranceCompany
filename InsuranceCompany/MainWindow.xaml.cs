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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InsuranceCompany
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel model;
        public MainWindow(DataModel data, UserRole user)
        {
            InitializeComponent();
            model = new MainViewModel(data, user);    
            this.DataContext = model;
        }

        private void UpdateAgreements(object sender, RoutedEventArgs e)
        {
            model.UpdateAgrement();
        }

        private void RemoveAgreements(object sender, RoutedEventArgs e)
        {
            model.RemoveAgrement();
        }

        private void UpdateInsuranceTypes(object sender, RoutedEventArgs e)
        {
            model.UpdateInsuranceTypes();
        }

        private void RemoveInsuranceTypes(object sender, RoutedEventArgs e)
        {
            model.RemoveInsuranceTypes();
        }

        private void UpdateBranch(object sender, RoutedEventArgs e)
        {
            model.UpdateBranch();
        }

        private void RemoveBranch(object sender, RoutedEventArgs e)
        {
            model.RemoveBranch();
        }

        private void UpdateUser(object sender, RoutedEventArgs e)
        {
            model.UpdateUser();
        }

        private void RemoveUser(object sender, RoutedEventArgs e)
        {
            model.RemoveUser();
        }
        private void UpdateUserRole(object sender, RoutedEventArgs e)
        {
            model.UpdateUserRoles();
        }

        private void RemoveUserRole(object sender, RoutedEventArgs e)
        {
            model.RemoveUserRole();
        }
    }
}
