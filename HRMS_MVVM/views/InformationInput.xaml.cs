using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using HRMS_MVVM.viewModels;

namespace HRMS_MVVM.views
{
    /// <summary>
    /// InformationInput.xaml 的交互逻辑
    /// </summary>
    public partial class InformationInput : CustomWindow
    {
        public InformationInput()
        {
            InitializeComponent();
            this.DataContext = new InformationInputViewModel();
            DependencyPropertyDescriptor descriptor = DependencyPropertyDescriptor.FromProperty(MainWindow.CloseStateProperty, typeof(MainWindow));
            descriptor.AddValueChanged(this, CloseStatePropertyChanged);
            //关闭后事件
            //this.Closed += InformationInput_Closed;
            //关闭前事件
            //this.Closing += InformationInput_Closing;
        }

        //关闭前事件处理程序
        //private void InformationInput_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        //{
        //    MessageBox.Show("quedingguanbi");
        //}

        //关闭后事件处理程序
        //private void InformationInput_Closed(object sender, EventArgs e)
        //{
        //    MessageBox.Show("guanbile");
        //}

        private void CloseStatePropertyChanged(object sender, EventArgs e)
        {
            if (this.CloseState == 0)
            {
                this.Close();
            }
        }
    }
}
