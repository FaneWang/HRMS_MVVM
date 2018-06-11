using HRMS_MVVM.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HRMS_MVVM.commands;
using System.Windows;
using HRMS_MVVM.views;

namespace HRMS_MVVM.viewModels
{
    class MainWindowViewModel:NotificationParent
    {
        #region 命令属性
        public DelegateCommand dataInputCommand { get; set; }
        public DelegateCommand dataQueryCommand { get; set; }
        public DelegateCommand loginCommand { get; set; }
        public DelegateCommand logoutCommand { get; set; }
        public DelegateCommand switchCommand1 { get; set; }
        public DelegateCommand switchCommand2 { get; set; }
        public DelegateCommand newCommand { get; set; }
        public DelegateCommand saveCommand { get; set; }
        public DelegateCommand closeCommand { get; set; }
        #endregion

        #region 数据属性，处理窗口关闭事件
        private bool canClose = true;
        public bool CanClose {
            get {
                return canClose;
            }
            set
            {
                canClose = value;
                this.raisePropertyChanged("CanClose");
            }
        }
        #endregion

        #region 构造函数,初始化命令
        public MainWindowViewModel()
        {
            this.dataInputCommand = new DelegateCommand(new Action<object>(dataInputExecute),new Func<Object,bool>(dataInputCanExecute));
            this.dataQueryCommand = new DelegateCommand(new Action<object>(dataQueryExecute), new Func<Object, bool>(dataQueryCanExecute));
            this.loginCommand = new DelegateCommand(new Action<object>(loginExecute), new Func<Object, bool>(loginCanExecute));
            this.logoutCommand = new DelegateCommand(new Action<object>(logoutExecute), new Func<Object, bool>(logoutCanExecute));
            this.switchCommand1 = new DelegateCommand(new Action<object>(switch1Execute), new Func<Object, bool>(switch1CanExecute));
            this.switchCommand2 = new DelegateCommand(new Action<object>(switch2Execute), new Func<Object, bool>(switch2CanExecute));
            this.newCommand = new DelegateCommand(new Action<object>(newExecute), new Func<Object, bool>(newCanExecute));
            this.saveCommand = new DelegateCommand(new Action<object>(saveExecute), new Func<Object, bool>(saveCanExecute));
            this.closeCommand = new DelegateCommand(new Action<object>(closeExecute), new Func<Object, bool>(closeCanExecute));
        }
        #endregion

        #region dataInput
        public bool dataInputCanExecute(Object parameter)
        {
            return true;
        }

        public void dataInputExecute(Object parameter)
        {
            InformationInput informationInput = new InformationInput();
            informationInput.Show();
        }
        #endregion

        #region dataQuery
        public bool dataQueryCanExecute(Object parameter)
        {
            return true;
        }

        public void dataQueryExecute(Object parameter)
        {

        }
        #endregion

        #region login
        public bool loginCanExecute(Object parameter)
        {
            return true;
        }

        public void loginExecute(Object parameter)
        {

        }
        #endregion

        #region logout
        public bool logoutCanExecute(Object parameter)
        {
            return true;
        }

        public void logoutExecute(Object parameter)
        {

        }
        #endregion

        #region switch1
        public bool switch1CanExecute(Object parameter)
        {
            return true;
        }

        public void switch1Execute(Object parameter)
        {

        }
        #endregion

        #region switch2
        public bool switch2CanExecute(Object parameter)
        {
            return true;
        }

        public void switch2Execute(Object parameter)
        {

        }
        #endregion

        #region new
        public bool newCanExecute(Object parameter)
        {
            return true;
        }

        public void newExecute(Object parameter)
        {
            MessageBox.Show("新建");
        }
        #endregion

        #region save
        public bool saveCanExecute(Object parameter)
        {
            return true;
        }

        public void saveExecute(Object parameter)
        {
            MessageBox.Show("保存");
        }
        #endregion

        #region close命令改变CanClose属性
        public bool closeCanExecute(Object parameter)
        {
            return true;
        }

        public void closeExecute(Object parameter)
        {
            this.CanClose = false;
        }
        #endregion
    }
}
