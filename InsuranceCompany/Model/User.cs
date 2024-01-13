using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace InsuranceCompany.Model
{
    public class User : Entity
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public int BranchID { get; set; }

        [XmlIgnore]
        public Branch Branch { get; set; }
    }
}
