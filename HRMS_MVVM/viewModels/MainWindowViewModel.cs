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
    class MainWindowViewModel : NotificationParent
    {
        private Dictionary<Object, bool> available = new Dictionary<object, bool>();
        private InformationInput informationInput;
        private InformationEdit informationEdit;

        #region 命令属性
        public DelegateCommand dataInputCommand { get; set; }
        public DelegateCommand dataEditCommand { get; set; }
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

        #region 构造函数,初始化命令
        public MainWindowViewModel()
        {
            #region 初始化命令
            this.dataInputCommand = new DelegateCommand(new Action<object>(dataInputExecute), new Func<Object, bool>(dataInputCanExecute));
            this.dataEditCommand = new DelegateCommand(new Action<object>(dataEditExecute), new Func<Object, bool>(dataEditCanExecute));
            this.dataQueryCommand = new DelegateCommand(new Action<object>(dataQueryExecute), new Func<Object, bool>(dataQueryCanExecute));
            this.loginCommand = new DelegateCommand(new Action<object>(loginExecute), new Func<Object, bool>(loginCanExecute));
            this.logoutCommand = new DelegateCommand(new Action<object>(logoutExecute), new Func<Object, bool>(logoutCanExecute));
            this.switchCommand1 = new DelegateCommand(new Action<object>(switch1Execute), new Func<Object, bool>(switch1CanExecute));
            this.switchCommand2 = new DelegateCommand(new Action<object>(switch2Execute), new Func<Object, bool>(switch2CanExecute));
            this.newCommand = new DelegateCommand(new Action<object>(newExecute), new Func<Object, bool>(newCanExecute));
            this.saveCommand = new DelegateCommand(new Action<object>(saveExecute), new Func<Object, bool>(saveCanExecute));
            this.closeCommand = new DelegateCommand(new Action<object>(closeExecute));
            #endregion
            
        }
        #endregion

        #region dataInput
        //处理命令的可用状态
        public bool dataInputCanExecute(Object parameter)
        {
            //如果子窗体被调用过，且处于不可用状态（已经关闭),则命令可用，否则不可用
            if (this.informationInput != null)
            {
                if (this.informationInput.CurrentState == 1 )
                {
                    return false;
                } 
            }
            return true;
        }

        public void dataInputExecute(Object parameter)
        {
            this.informationInput = new InformationInput();
            this.informationInput.ShowDialog();
        }
        #endregion

        #region dataEdit
        //处理命令的可用状态
        public bool dataEditCanExecute(Object parameter)
        {
            //如果子窗体被调用过，且处于不可用状态（已经关闭),则命令可用，否则不可用
            if (this.informationEdit != null)
            {
                if (this.informationEdit.CurrentState == 1)
                {
                    return false;
                }
            }
            return true;
        }

        public void dataEditExecute(Object parameter)
        {
            this.informationEdit = new InformationEdit();
            this.informationEdit.ShowDialog();
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
        
        public void closeExecute(Object parameter)
        {
            this.CanClose = 0;
            //this.informationInput.CloseState = 0;
        }
        #endregion
    }
}
