using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS_MVVM.common
{
    class NotificationParent : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void raisePropertyChanged(string name)
        {
            if (PropertyChanged != null)    
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
