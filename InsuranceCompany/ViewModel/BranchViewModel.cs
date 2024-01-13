using InsuranceCompany.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.ViewModel
{
    public class BranchViewModel : BaseViewModel
    {
        private Branch _branch;

        public Branch Branch
        {
            get => _branch;
            set
            {
                _branch = value;
                OnProperty("Branch");
            }
        }

        public BranchViewModel(DataModel data, string action, Branch branch)
        {
            Data = data;
            Action = action;
            IsClose = false;

            if(branch == null)
            {
                Branch = new Branch();
            }
            else
            {
                Branch = new Branch()
                {
                    Address = branch.Address,
                    ID = branch.ID,
                    Code = branch.Code,
                    Phone = branch.Phone,
                    Title = branch.Title
                };
            }
        }

        public override void Execute()
        {
            if(Branch.Code == "" ||  Branch.Phone == "" || Branch.Address == "" || Branch.Title == "")
            {
                Message("Не все поля заполнены");
                return;
            }

            IsClose = true;
            Close();
        }
    }
}
