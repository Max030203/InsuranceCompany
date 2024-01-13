using GalaSoft.MvvmLight.Command;
using InsuranceCompany.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InsuranceCompany.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private DataModel _data;

        public Action Close { get; set; }
        public string Action { get; set; }
        public bool IsClose { get; set; } = false;

        public DataModel Data
        {
            get => _data;
            set
            {
                _data = value;
                OnProperty("Data");
            }
        }

        public void Message(string message)
        {
            MessageBox.Show(message);
        }

        public virtual void Execute()
        {

        }

        public RelayCommand ExecuteCommand => new RelayCommand(Execute);

        #region Event
        public virtual event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnProperty(params string[] propertyNames)
        {
            if (PropertyChanged != null)
            {
                foreach (string propertyName in propertyNames) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                PropertyChanged(this, new PropertyChangedEventArgs("HasError"));
            }
        }
        #endregion
    }
}
