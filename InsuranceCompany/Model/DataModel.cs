using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.Model
{
    public class DataModel
    {
        public ObservableCollection<Agreement> Agreements { get; set; }
        public ObservableCollection<Branch> Branches { get; set; }
        public ObservableCollection<InsuranceType> InsuranceTypes { get; set; }
        public ObservableCollection<Role> Roles { get; set; }
        public ObservableCollection<User> Users { get; set; }
        public ObservableCollection<UserRole> UserRoles { get; set; }
        public ObservableCollection<UserSalary> UserSalarys { get; set;}
    }
}
