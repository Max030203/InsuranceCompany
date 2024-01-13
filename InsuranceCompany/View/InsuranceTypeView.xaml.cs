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
    /// Логика взаимодействия для InsuranceTypeView.xaml
    /// </summary>
    public partial class InsuranceTypeView : Window
    {
        public InsuranceTypeViewModel Model { get; set; }
        public InsuranceTypeView(DataModel data, string action, InsuranceType insuranceType)
        {
            InitializeComponent();
            Model = new InsuranceTypeViewModel(data, action, insuranceType);
            this.DataContext = Model;

            if(Model.Close == null)
                Model.Close = new Action(this.Close);
        }
    }
}
