using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS_MVVM.commands;
using HRMS_MVVM.common;

namespace HRMS_MVVM.viewModels
{
    class InformationInputViewModel:NotificationParent
    {
        #region 数据属性，处理窗口关闭事件
        private int canClose = 1;
        public int CanClose
        {
            get
            {
                return canClose;
            }
            set
            {
                canClose = value;
                this.raisePropertyChanged("CanClose");
            }
        }
        #endregion

        #region 定义命令属性
        public DelegateCommand closeCommand { get; set; }
        #endregion

        public InformationInputViewModel()
        {
            this.closeCommand = new DelegateCommand(new Action<object>(closeExecute), new Func<Object, bool>(closeCanExecute));
        }

        #region close命令改变CanClose属性
        public bool closeCanExecute(Object parameter)
        {
            return true;
        }

        public void closeExecute(Object parameter)
        {
            this.CanClose = 0;
        }
        #endregion
    }
}
