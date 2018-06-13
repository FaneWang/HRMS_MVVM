using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HRMS_MVVM
{
    public class CustomWindow:Window
    {
        #region 窗口当前状态，指示窗口关闭
        public int CurrentState
        {
            get { return (int)GetValue(CurrentStateProperty); }
            set {
                SetValue(CurrentStateProperty, value);
            }
        }

        public static readonly DependencyProperty CurrentStateProperty = DependencyProperty.Register("CurrentState", typeof(int), typeof(CustomWindow));
        #endregion

        #region 关闭指示状态
        public int CloseState
        {
            get { return (int)GetValue(CloseStateProperty); }
            set
            {
                SetValue(CloseStateProperty, value);
            }
        }

        public static readonly DependencyProperty CloseStateProperty = DependencyProperty.Register("CloseState", typeof(int), typeof(CustomWindow));
        #endregion
    }
}
