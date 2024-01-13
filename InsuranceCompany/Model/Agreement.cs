using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace InsuranceCompany.Model
{
    public class Agreement : Entity
    {
        public string Code { get; set; }
        public DateTime Date { get; set; }
        public double Summa { get; set; }
        public double TariffRate { get; set; }
        public int UserID { get; set; }
        public int InsuranceTypeID { get; set; }

        [XmlIgnore]
        public User User { get; set; }
        [XmlIgnore]
        public InsuranceType InsuranceType { get; set; }

    }
}
