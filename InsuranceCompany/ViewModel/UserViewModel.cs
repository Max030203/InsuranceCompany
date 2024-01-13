using InsuranceCompany.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.ViewModel
{
    public class UserViewModel : BaseViewModel
    {
        private User _user;
        private Branch _selectBranch;
       
        public User User
        {
            get => _user;
            set
            {
                _user = value;
                OnProperty("User");
            }
        }
        public Branch SelectBranch
        {
            get => _selectBranch;
            set
            {
                _selectBranch = value;
                User.Branch = value;
                User.BranchID = value.ID;
                OnProperty("SelectBranch");
            }
        }

        public UserViewModel(DataModel data, string action, User user)
        {
            IsClose = false;

            Data = data;
            Action = action;

            if(user == null)
            {
                User = new User();
                SelectBranch = Data.Branches[0];
            }
            else 
            {
                User = new User()
                {
                    ID = user.ID,
                    BranchID = user.BranchID,
                    Branch = user.Branch,
                    Surname = user.Surname,
                    Name = user.Name,
                    Patronymic = user.Patronymic
                };

                SelectBranch = user.Branch;
            }
        }

        public override void Execute()
        {
            if(User.Surname == "" || User.Name == "" || User.Patronymic == "")
            {
                Message("Не все поля заполнены");
                return;
            }

            IsClose = true;
            Close();
        }
    }
}
