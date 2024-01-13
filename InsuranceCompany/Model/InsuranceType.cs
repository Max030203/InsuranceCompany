using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.Model
{
    public class InsuranceType : Entity
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public double Percent {  get; set; }
    }
}
