using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace InsuranceCompany.Model
{
    public class UserSalary : Entity
    {
        public int UserID { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public double Salary { get; set; }

        [XmlIgnore]
        public User User { get; set; }

        [XmlIgnore]
        public string GetPeriod
        {
            get
            {
                switch (Month)
                {
                    case 1: return $"Январь {Year}";
                    case 2: return $"Февраль {Year}";
                    case 3: return $"Март {Year}";
                    case 4: return $"Апрель {Year}";
                    case 5: return $"Май {Year}";
                    case 6: return $"Июнь {Year}";
                    case 7: return $"Июль {Year}";
                    case 8: return $"Август {Year}";
                    case 9: return $"Сентябрь {Year}";
                    case 10: return $"Октябрь {Year}";
                    case 11: return $"Ноябрь {Year}";
                    case 12: return $"Декабрь {Year}";
                    default: return "";
                }
            }
        }
    }
}
