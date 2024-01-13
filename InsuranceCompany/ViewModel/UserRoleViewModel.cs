using InsuranceCompany.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.ViewModel
{
    public class UserRoleViewModel : BaseViewModel
    {
        private UserRole _userRole;
        private Role _selectRole;
        private User _selectUser;

        public UserRole UserRole
        {
            get => _userRole;
            set
            {
                _userRole = value;
                OnProperty("UserRole");
            }
        }
        public Role SelectRole
        {
            get => _selectRole;
            set
            {
                _selectRole = value;
                UserRole.Role = value;
                UserRole.RoleID = value.ID;
                OnProperty("SelectRole");
            }
        }
        public User SelectUser
        {
            get => _selectUser;
            set
            {
                _selectUser = value;
                UserRole.User = value;
                UserRole.UserID = value.ID;
                OnProperty("SelectUser");
            }
        }

        public UserRoleViewModel(DataModel data, string action, UserRole useRole)
        {
            IsClose = false;

            Data = data;
            Action = action;

            if(useRole == null)
            {
                UserRole = new UserRole();
                SelectRole = Data.Roles[0];
                SelectUser = Data.Users[0];
            }
            else
            {
                UserRole = new UserRole()
                {
                    ID = useRole.ID,
                    Role = useRole.Role,
                    RoleID = useRole.RoleID,
                    User = useRole.User,
                    UserID = useRole.UserID,
                    Login = useRole.Login,
                    Password = useRole.Password
                };

                SelectRole = useRole.Role;
                SelectUser = useRole.User;
            }
        }

        public override void Execute()
        {
            if(UserRole.Login == "" || UserRole.Password == "")
            {
                Message("Не все поля заполнены");
                return;
            }

            IsClose = true;
            Close();
        }
    }
}
