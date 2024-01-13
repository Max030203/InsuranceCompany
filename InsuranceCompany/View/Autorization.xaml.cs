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
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Window
    {
        AutorizationViewModel model;
        public Autorization()
        {
            InitializeComponent();
            model = new AutorizationViewModel();
            this.DataContext = model;

            if (model.Show == null)
                model.Show = new Action(this.Show);

            if(model.Hide == null)
                model.Hide = new Action(this.Hide);
        }
    }
}
