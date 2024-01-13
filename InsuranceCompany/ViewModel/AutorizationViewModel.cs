using InsuranceCompany.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.ViewModel
{
    public class AutorizationViewModel : BaseViewModel
    {
        private UserRole _user;
        public Action Show {  get; set; }
        public Action Hide { get; set; }

        public UserRole User
        {
            get => _user;
            set
            {
                _user = value;
                OnProperty("User");
            }
        }

        public AutorizationViewModel()
        {
            Data = XmlWorker.Load();
            User = new UserRole();
        }

        public override void Execute()
        {
            if(User.Login == "" || User.Password == "")
            {
                Message("Не все поля заполнены");
                return;
            }

            UserRole temp = Data.UserRoles.FirstOrDefault(x => x.Login == User.Login && x.Password == User.Password);

            if(temp == null) 
            {
                Message("Не верный логин и/или пароль");
                return;
            }

            Hide();

            MainWindow main = new MainWindow(Data, temp);
            main.ShowDialog();

            Show();
        }
    }
}
