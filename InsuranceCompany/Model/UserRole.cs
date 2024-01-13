using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace InsuranceCompany.Model
{
    public class UserRole : Entity
    {
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public string Login {  get; set; }
        public string Password { get; set; }

        [XmlIgnore]
        public User User { get; set; }
        [XmlIgnore]
        public Role Role { get; set; }
    }
}
