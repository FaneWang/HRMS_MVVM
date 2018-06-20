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
using System.Windows.Navigation;
using System.Windows.Shapes;
using HRMS_MVVM.viewModels;
using HRMS_MVVM.views;

namespace HRMS_MVVM
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : CustomWindow
    {
        private Page1 page1;
        private Page2 page2;

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
            DependencyPropertyDescriptor descriptor = DependencyPropertyDescriptor.FromProperty(MainWindow.CloseStateProperty,typeof(MainWindow));
            descriptor.AddValueChanged(this, CloseStatePropertyChanged);
        }
        
        //接受viewmodel造成isEnabled变化关闭窗口
        private void CloseStatePropertyChanged(object sender, EventArgs e)
        {
            if (this.CloseState == 0)
            {
                this.Close();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (page1 == null)
            {
                page1 = new Page1();
            }

            frame.Content = page1;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (page2 == null)
            {
                page2 = new Page2();
            }

            frame.Content = page2;
        }

        //private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        //{
        //    this.IsEnabled = false;
        //}
    }
}
