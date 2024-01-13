using InsuranceCompany.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.ViewModel
{
    public class InsuranceTypeViewModel : BaseViewModel
    {
        private InsuranceType _insuranceType;

        public InsuranceType InsuranceType
        {
            get => _insuranceType;
            set
            {
                _insuranceType = value;
                OnProperty("InsuranceType");
            }
        }

        public InsuranceTypeViewModel(DataModel data, string action, InsuranceType insuranceType)
        {
            IsClose = false;

            Data = data;
            Action = action;
            if(insuranceType == null)
            {
                InsuranceType = new InsuranceType();
            }
            else
            {
                InsuranceType = new InsuranceType()
                {
                    ID = insuranceType.ID,
                    Code = insuranceType.Code,
                    Title = insuranceType.Title,
                    Percent = insuranceType.Percent
                };
            }
        }

        public override void Execute()
        {
            if(InsuranceType.Code == "" || InsuranceType.Title == "" || InsuranceType.Percent == 0)
            {
                Message("Не все поля заполнены");
                return;
            }

            IsClose = true;
            Close();
        }
    }
}
