using InsuranceCompany.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.ViewModel
{
    public class AgrementViewModel : BaseViewModel
    {
        private Agreement _agrement;
        private InsuranceType _selectInsuranceType;

        public Agreement Agreement
        { 
            get => _agrement;
            set
            {
                _agrement = value;
                OnProperty("Agreement");
            }
        }
        public InsuranceType SelectInsuranceType
        {
            get => _selectInsuranceType;
            set
            {
                _selectInsuranceType = value;
                Agreement.InsuranceType = value;
                Agreement.InsuranceTypeID = value.ID;

                OnProperty("SelectInsuranceType");
            }
        }

        public AgrementViewModel(DataModel data, string action, Agreement agreement)
        {
            IsClose = false;
            Data = data;
            Action = action;

            if (agreement == null)
            {
                Agreement = new Agreement()
                {
                    Date = DateTime.Now
                };

                SelectInsuranceType = Data.InsuranceTypes[0];
            }
            else
            {
                Agreement = new Agreement();

                Agreement.ID = agreement.ID;
                Agreement.Code = agreement.Code;
                Agreement.User = agreement.User;
                Agreement.UserID = agreement.UserID;
                Agreement.TariffRate = agreement.TariffRate;
                Agreement.Summa = agreement.Summa;
                Agreement.Date = agreement.Date;
                Agreement.InsuranceType = agreement.InsuranceType;
                Agreement.InsuranceTypeID = agreement.InsuranceTypeID;

                SelectInsuranceType = agreement.InsuranceType;
            }
        }

        public override void Execute()
        {
            if(Agreement.Code == "" || Agreement.Summa == 0 || Agreement.TariffRate == 0 || Agreement.Summa < 0 || Agreement.TariffRate < 0)
            {
                Message("Не все поля заполненные корректно");
                return;
            }
            IsClose = true;

            Close();
        }
    }
}
