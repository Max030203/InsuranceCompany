using GalaSoft.MvvmLight.Command;
using InsuranceCompany.Model;
using InsuranceCompany.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InsuranceCompany.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        #region Private
        private User _inputUser;

        private ObservableCollection<Agreement> _agreements;
        private ObservableCollection<Branch> _branches;
        private ObservableCollection<InsuranceType> _insuranceTypes;
        private ObservableCollection<Role> _roles;
        private ObservableCollection<User> _users;
        private ObservableCollection<UserRole> _userRoles;
        private ObservableCollection<UserSalary> _userSalarys;

        private string _findAgreement;
        private string _findBranch;
        private string _findInsuranceType;
        private string _findUser;
        private string _findUserRole;
        private string _findUserSalary;

        private Agreement _selectAgreement;
        private Branch _selectBranch;
        private InsuranceType _selectInsuranceType;
        private User _selectUser;
        private UserRole _selectUserRole;

        private Visibility _isAdmin = Visibility.Visible;
        #endregion

        #region Public
        public Visibility IsAdmin
        {
            get => _isAdmin;
            set
            {
                _isAdmin = value;
                OnProperty("IsAdmin");
            }
        }

        public ObservableCollection<Agreement> Agreements
        {
            get => _agreements;
            set
            {
                _agreements = value;
                OnProperty("Agreements");
            }
        }
        public ObservableCollection<Branch> Branches
        {
            get => _branches;
            set
            {
                _branches = value;
                OnProperty("Branches");
            }
        }
        public ObservableCollection<InsuranceType> InsuranceTypes
        {
            get => _insuranceTypes;
            set
            {
                _insuranceTypes = value;
                OnProperty("InsuranceTypes");
            }
        }
        public ObservableCollection<Role> Roles
        {
            get => _roles;
            set
            {
                _roles = value;
                OnProperty("Roles");
            }
        }
        public ObservableCollection<User> Users
        {
            get => _users;
            set
            {
                _users = value;
                OnProperty("Users");
            }
        }
        public ObservableCollection<UserRole> UserRoles
        {
            get => _userRoles;
            set
            {
                _userRoles = value;
                OnProperty("UserRoles");
            }
        }
        public ObservableCollection<UserSalary> UserSalarys
        {
            get => _userSalarys;
            set
            {
                _userSalarys = value;
                OnProperty("UserSalarys");
            }
        }

        public string FindAgreement
        {
            get => _findAgreement;
            set
            {
                _findAgreement = value;

                if(IsAdmin == Visibility.Visible) 
                {
                    Agreements = new ObservableCollection<Agreement>(Data.Agreements.Where(x => x.Code.ToLower().Contains(value.ToLower()) ||
                    x.Date.ToShortDateString().ToLower().Contains(value.ToLower()) || x.Summa.ToString().Contains(value.ToLower()) ||
                    x.TariffRate.ToString().Contains(value.ToLower()) || x.User.Surname.ToLower().Contains(value.ToLower()) ||
                    x.User.Name.ToLower().Contains(value.ToLower()) || x.User.Patronymic.ToLower().Contains(value.ToLower()) ||
                    x.User.Branch.Title.ToLower().Contains(value.ToLower())).ToList());
                }
                else
                {
                    Agreements = new ObservableCollection<Agreement>(Data.Agreements.Where(x => (x.Code.ToLower().Contains(value.ToLower()) ||
                    x.Date.ToShortDateString().ToLower().Contains(value.ToLower()) || x.Summa.ToString().Contains(value.ToLower()) ||
                    x.TariffRate.ToString().Contains(value.ToLower()) || x.User.Surname.ToLower().Contains(value.ToLower()) ||
                    x.User.Name.ToLower().Contains(value.ToLower()) || x.User.Patronymic.ToLower().Contains(value.ToLower()) ||
                    x.User.Branch.Title.ToLower().Contains(value.ToLower())) && x.UserID == _inputUser.ID).ToList());
                }

                OnProperty("FindAgreement");
            }
        }
        public string FindBranch
        {
            get => _findBranch;
            set
            {
                _findBranch = value;

                Branches = new ObservableCollection<Branch>(Data.Branches.Where(x => x.Code.ToLower().Contains(value.ToLower()) ||
                x.Title.ToLower().Contains(value.ToLower())));

                OnProperty("FindBranch");
            }
        }
        public string FindInsuranceType
        {
            get => _findInsuranceType;
            set
            {
                _findInsuranceType = value;

                InsuranceTypes = new ObservableCollection<InsuranceType>(Data.InsuranceTypes.Where(x => x.Code.ToLower().Contains(value.ToLower()) ||
                x.Title.ToLower().Contains(value.ToLower())));

                OnProperty("FindInsuranceType");
            }
        }
        public string FindUser
        {
            get => _findUser;
            set
            {
                _findUser = value;

                Users = new ObservableCollection<User>(Data.Users.Where(x => x.Surname.ToLower().Contains(value.ToLower()) ||
                x.Name.ToLower().Contains(value.ToLower()) || x.Patronymic.ToLower().Contains(value.ToLower()) ||
                x.Branch.Title.ToLower().Contains(value.ToLower())).ToList());

                OnProperty("FindUser");
            }
        }
        public string FindUserRole
        {
            get => _findUserRole;
            set
            {
                _findUserRole = value;

                UserRoles = new ObservableCollection<UserRole>(Data.UserRoles.Where(x => x.User.Surname.ToLower().Contains(value.ToLower()) ||
                x.User.Name.ToLower().Contains(value.ToLower()) || x.User.Patronymic.ToLower().Contains(value.ToLower()) ||
                x.Role.Name.ToLower().Contains(value.ToLower())).ToList());

                OnProperty("FindUserRole");
            }
        }
        public string FindUserSalary
        {
            get => _findUserSalary;
            set
            {
                _findUserSalary = value;

                UserSalarys = new ObservableCollection<UserSalary>(Data.UserSalarys.Where(x => x.User.Surname.ToLower().Contains(value.ToLower()) ||
                x.User.Name.ToLower().Contains(value.ToLower()) || x.User.Patronymic.ToLower().Contains(value.ToLower()) ||
                x.GetPeriod.ToLower().Contains(value.ToLower()) || x.Salary.ToString().ToLower().Contains(value.ToLower())).ToList());

                OnProperty("FindUserSalary");
            }
        }

        public Agreement SelectAgreement
        {
            get => _selectAgreement;
            set
            {
                _selectAgreement = value;
                OnProperty("SelectAgreement");
            }
        }
        public Branch SelectBranch
        { 
            get => _selectBranch;
            set
            {
                _selectBranch = value;
                OnProperty("SelectBranch");
            }
        }
        public InsuranceType SelectInsuranceType
        {
            get => _selectInsuranceType;
            set
            {
                _selectInsuranceType = value;
                OnProperty("SelectInsuranceType");
            }
        }
        public User SelectUser
        {
            get => _selectUser;
            set
            {
                _selectUser = value;
                OnProperty("SelectUser");
            }
        }
        public UserRole SelectUserRole
        {
            get => _selectUserRole;
            set
            {
                _selectUserRole = value;
                OnProperty("SelectUserRole");
            }
        }
        #endregion

        public MainViewModel(DataModel data, UserRole user)
        {
            Data = data;

            Branches = Data.Branches;
            Users = Data.Users;

            Users.ToList().ForEach(x =>
            {
                x.Branch = Data.Branches.First(y => x.BranchID == y.ID);
            });

            if (user.RoleID == 1)
                Agreements = new ObservableCollection<Agreement>(Data.Agreements.Where(x => x.UserID == user.UserID).ToList());
            else Agreements = Data.Agreements;

            Agreements.ToList().ForEach(x =>
            {
                x.User = Data.Users.First(y => y.ID == x.UserID);
                x.InsuranceType = Data.InsuranceTypes.First(y => y.ID == x.InsuranceTypeID);
            });

            UserRoles = Data.UserRoles;

            UserRoles.ToList().ForEach(x =>
            {
                x.User = Data.Users.First(y => y.ID == x.UserID);
                x.Role = Data.Roles.First(y => y.ID == x.RoleID);
            });
                    
            UserSalarys = Data.UserSalarys;

            UserSalarys.ToList().ForEach(x =>
            {
                x.User = Data.Users.First(y => y.ID == x.UserID);
            });

            InsuranceTypes = Data.InsuranceTypes;

            _inputUser = Data.Users.First(x => x.ID == user.UserID);

            if (user.RoleID == 2)
                IsAdmin = Visibility.Visible;
            else IsAdmin = Visibility.Hidden;
        }

        public void RemoveAgrement()
        {      
            UserSalary temp = Data.UserSalarys.First(x => x.UserID == SelectAgreement.UserID
            && x.Month == SelectAgreement.Date.Month && x.Year == SelectAgreement.Date.Year);
            temp.Salary -= (SelectAgreement.Summa * SelectAgreement.TariffRate) * (SelectAgreement.InsuranceType.Percent/100);

            if(temp.Salary == 0)
                Data.UserSalarys.Remove(temp);

            Data.Agreements.Remove(SelectAgreement);
            FindAgreement = "";
            FindUserSalary = "";

            XmlWorker.Save(Data);
        }
        public void UpdateAgrement()
        {
            AgrementView update = new AgrementView(Data, "Обновить", SelectAgreement);
            update.ShowDialog();

            if (update.Model.IsClose == true)
            {
                Data.Agreements[Data.Agreements.IndexOf(SelectAgreement)] = update.Model.Agreement;

                CalculateSallary();

                FindAgreement = "";
                FindUserSalary = "";
            }
        }

        private void CalculateSallary()
        {
            Data.UserSalarys = new ObservableCollection<UserSalary>();

            Data.Agreements.ToList().ForEach(x =>
            {
                UserSalary salary = Data.UserSalarys.FirstOrDefault(y => y.UserID == x.UserID
                && y.Month == x.Date.Month && y.Year == x.Date.Year);

                if (salary == null)
                {
                    UserSalary tempSalary = new UserSalary()
                    {
                        ID = Data.UserSalarys.Count() == 0 ? 1 : Data.UserSalarys.Last().ID + 1,
                        Month = x.Date.Month,
                        Year = x.Date.Year,
                        Salary = (x.Summa * x.TariffRate) * (x.InsuranceType.Percent/100),
                        User = x.User,
                        UserID = x.User.ID
                    };

                    Data.UserSalarys.Add(tempSalary);
                }
                else
                {
                    salary.Salary += (x.Summa * x.TariffRate) * (x.InsuranceType.Percent / 100);
                }
            });

            XmlWorker.Save(Data);
        }

        private void AddAgrement()
        {
            AgrementView add = new AgrementView(Data, "Добавить", null);
            add.ShowDialog();

            if (add.Model.IsClose == true)
            {
                Agreement temp = add.Model.Agreement;

                temp.ID = Data.Agreements.Count() == 0 ? 1 : Data.Agreements.Last().ID + 1;
                temp.UserID = _inputUser.ID;
                temp.User = _inputUser;

                UserSalary salary = Data.UserSalarys.FirstOrDefault(x => x.UserID == _inputUser.ID
                && x.Month == temp.Date.Month && x.Year == temp.Date.Year);

                if(salary == null)
                {
                    UserSalary tempSalary = new UserSalary()
                    {
                        ID = Data.UserSalarys.Count() == 0 ? 1 : Data.UserSalarys.Last().ID + 1,
                        Month = temp.Date.Month,
                        Year = temp.Date.Year,
                        Salary = (temp.Summa * temp.TariffRate) * (temp.InsuranceType.Percent/100),
                        User = _inputUser,
                        UserID = _inputUser.ID
                    };

                    Data.UserSalarys.Add(tempSalary);
                }
                else
                {
                    salary.Salary += (temp.Summa * temp.TariffRate) * (temp.InsuranceType.Percent / 100);
                }


                Data.Agreements.Add(add.Model.Agreement);
                FindAgreement = "";
                FindUserSalary = "";

                XmlWorker.Save(Data);
            }
        }

        public void RemoveBranch()
        {
            List<User> users = Data.Users.Where(x => x.BranchID == SelectBranch.ID).ToList();
            users.ForEach(x =>
            {
                Data.UserRoles.Where(y => y.UserID == x.ID).ToList().ForEach(y => Data.UserRoles.Remove(y));
                Data.Agreements.Where(y => y.UserID == x.ID).ToList().ForEach(y => Data.Agreements.Remove(y));

                Data.Users.Remove(x);
            });

            FindUser = "";
            FindUserRole = "";
            FindAgreement = "";
            FindBranch = "";

            Data.Branches.Remove(SelectBranch);

            XmlWorker.Save(Data);
        }
        public void UpdateBranch()
        {
            BranchView update = new BranchView(Data, "Обновить", SelectBranch);
            update.ShowDialog();

            if(update.Model.IsClose == true)
            {
                Data.Branches[Data.Branches.IndexOf(SelectBranch)] = update.Model.Branch;
                FindBranch = "";
                XmlWorker.Save(Data);
            }
        }

        public void AddBranch()
        {
            BranchView add = new BranchView(Data, "Добавить", null);
            add.ShowDialog();

            if(add.Model.IsClose == true) 
            {
                add.Model.Branch.ID = Data.Branches.Count() == 0 ? 1 : Data.Branches.Last().ID + 1;
                Data.Branches.Add(add.Model.Branch);
                FindBranch = "";
                XmlWorker.Save(Data);
            }
        }

        public void RemoveInsuranceTypes()
        {
            List<Agreement> agreements = Data.Agreements.Where(x => x.InsuranceTypeID == SelectInsuranceType.ID).ToList();
            agreements.ForEach(x => Data.Agreements.Remove(x));

            Data.InsuranceTypes.Remove(SelectInsuranceType);

            XmlWorker.Save(Data);

            FindAgreement = "";
            FindInsuranceType = "";
        }
        public void UpdateInsuranceTypes()
        {
            InsuranceTypeView update = new InsuranceTypeView(Data, "Обновить", SelectInsuranceType);
            update.ShowDialog();

            if (update.Model.IsClose == true)
            {
                Data.InsuranceTypes[Data.InsuranceTypes.IndexOf(SelectInsuranceType)] = update.Model.InsuranceType;
                FindInsuranceType = "";
                XmlWorker.Save(Data);
            }
        }

        private void AddInsuranceTypes()
        {
            InsuranceTypeView add = new InsuranceTypeView(Data, "Добавить", null);
            add.ShowDialog();

            if(add.Model.IsClose == true) 
            {
                add.Model.InsuranceType.ID = Data.InsuranceTypes.Count() == 0 ? 1 : Data.InsuranceTypes.Last().ID + 1;
                Data.InsuranceTypes.Add(add.Model.InsuranceType);
                XmlWorker.Save(Data);
                FindInsuranceType = "";
            }
        }

        public void RemoveUser()
        {
            List<Agreement> agreements = Data.Agreements.Where(x => x.UserID == SelectUser.ID).ToList();
            agreements.ForEach(x => Data.Agreements.Remove(x));
            List<UserRole> userRoles = Data.UserRoles.Where(x => x.UserID == SelectUser.ID).ToList();
            userRoles.ForEach(x => Data.UserRoles.Remove(x));
            List<UserSalary> userSalaries = Data.UserSalarys.Where(x => x.UserID == SelectUser.ID).ToList();
            userSalaries.ForEach(x => Data.UserSalarys.Remove(x));

            Data.Users.Remove(SelectUser);

            XmlWorker.Save(Data);

            FindAgreement = "";
            FindUserRole = "";
            FindUserSalary = "";
            FindUser = "";
        }
        public void UpdateUser()
        {
            UserView update = new UserView(Data, "Обновить", SelectUser);
            update.ShowDialog();

            if(update.Model.IsClose == true)
            {
                Data.Users[Data.Users.IndexOf(SelectUser)] = update.Model.User;
                FindUser = "";
                FindUserRole = "";
                FindUserSalary = "";
                XmlWorker.Save(Data);
            }
        }

        private void AddUser()
        {
            UserView add = new UserView(Data, "Добавить", null);
            add.ShowDialog();

            if (add.Model.IsClose == true)
            {
                add.Model.User .ID = Data.Users.Count() == 0 ? 1 : Data.Users.Last().ID + 1;
                Data.Users.Add(add.Model.User);
                XmlWorker.Save(Data);
                FindUser = "";
            }
        }

        public void RemoveUserRole()
        {
            Data.UserRoles.Remove(SelectUserRole);
            XmlWorker.Save(Data);

            FindUserRole = "";
        }
        public void UpdateUserRoles() 
        {
            UserRoleView update = new UserRoleView(Data, "Обновить", SelectUserRole);
            update.ShowDialog();

            if(update.Model.IsClose == true) 
            {
                Data.UserRoles[Data.UserRoles.IndexOf(SelectUserRole)] = update.Model.UserRole;
                FindUserRole = "";
                XmlWorker.Save(Data);
            }
        }

        private void AddUserRole()
        {
            UserRoleView add = new UserRoleView(Data, "Добавить", null);
            add.ShowDialog();

            if(add.Model.IsClose == true)
            {
                add.Model.UserRole.ID = Data.UserRoles.Count() == 0 ? 1 : Data.UserRoles.Last().ID + 1;
                Data.UserRoles.Add(add.Model.UserRole);

                FindUserRole = "";
                XmlWorker.Save(Data);
            }
        }

        public RelayCommand AddAgrementCommand => new RelayCommand(AddAgrement);
        public RelayCommand AddBranchCommand => new RelayCommand(AddBranch);
        public RelayCommand AddInsuranceTypeCommand => new RelayCommand(AddInsuranceTypes);
        public RelayCommand AddUserCommand => new RelayCommand(AddUser);
        public RelayCommand AddUserRoleCommand => new RelayCommand(AddUserRole);
    }
}
