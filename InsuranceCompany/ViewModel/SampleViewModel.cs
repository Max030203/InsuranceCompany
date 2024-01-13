using InsuranceCompany.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.ViewModel
{
    public class SampleViewModel : BaseViewModel
    {
        private Role _role;

        public Role Role
        {
            get => _role;
            set
            {
                _role = value;
                OnProperty("Role");
            }
        }

        public SampleViewModel(DataModel data, string action, Role role)
        {
            IsClose = false;
            Data = data;
            Action = action;

            if(role == null)
            {
                Role = new Role();
            }
            else
            {
                Role = new Role()
                {
                    ID = role.ID,
                    Name = role.Name
                };
            }
        }

        public override void Execute()
        {
            if(Role.Name == "")
            {
                Message("Имя не заполнено");
                return;
            }

            IsClose = true;
            Close();
            Close();
        }
    }
}
