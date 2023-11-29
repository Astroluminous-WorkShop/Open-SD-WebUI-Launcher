using System;
using System.Threading.Tasks;
using System.Windows.Controls;
using Wpf.Ui.Common.Interfaces;
using 光源AI绘画盒子;
using 光源AI绘画盒子.Views.Windows;
namespace 光源AI绘画盒子.Views.Pages
{
    /// <summary>
    /// Interaction logic for DataView.xaml
    /// </summary>
    public partial class DataPage : INavigableView<ViewModels.DataViewModel>
    {
        public ViewModels.DataViewModel ViewModel
        {
            get;
        }

        public DataPage(ViewModels.DataViewModel viewModel)
        {
            ViewModel = viewModel;
            InitializeComponent();
            GetSystemInfo();

            if (_显卡类型 == "Radeon")
            {
                A卡优化.IsChecked = true;
                启用XF.IsEnabled = false;
                N卡优化.IsEnabled = false;
            }
            if (_显卡类型 == "NVIDIA")
            {
                N卡优化.IsChecked = true;
                A卡优化.IsEnabled = false;
                if (XF加速模式 == true) { 启用XF.IsChecked = true; }

            }

        }
        public async void GetSystemInfo()//异步获取计算机硬件信息
        {
            string cpuname = await Task.Run(() => hardinfo.GetCpuName());
            string Machinename = await Task.Run(() => hardinfo.GetComputerName());
            string systemType = await Task.Run(() => hardinfo.GetSystemType());

            float memorysize = await Task.Run(() => hardinfo.GetPhysicalMemory());
            int memorynum = await Task.Run(() => hardinfo.MemoryNumberCount());
            string gpuname = await Task.Run(() => hardinfo.GPUName());

            计算机CPU信息.Text = "CPU信息：" + cpuname;
            计算机名称类型.Text = "系统名称：" + Machinename + "   系统类型：" + systemType;
            计算机内存信息.Text = "内存信息：" + memorynum + " 插槽" + "  共计" + memorysize + " GB";
            计算机显卡信息.Text = "显卡信息：" + gpuname;
        }

        //这里是一些开关的控制器组件
        private void 启动后自动打开浏览器开关_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            if (浏览器启动 == false)
            {
                浏览器启动 = true;
            }
            else
            {
                浏览器启动 = false;
            }
        }





        private void 使用CPU进行推理_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (使用CPU进行推理.IsChecked == true)
            {
                使用CPU进行推理 = true;
            }
            else
            {
                使用CPU进行推理 = false;
            }
        }

        private void 关闭模型hash计算_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (关闭模型hash计算.IsChecked == true)
            {
               
            }
            else
            {
      
            }
        }

        private void 无卡调试模式_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (无卡调试模式.IsChecked == true)
            {
             
            }
            else
            {
                
            }
        }

        private void WebUI显存压力优化设置_DropDownClosed(object sender, EventArgs e)
        {
            if (WebUI显存压力优化设置.SelectedIndex == 0)
            {
                _WebUI显存压力优化设置 = "低";
            }
            if (WebUI显存压力优化设置.SelectedIndex == 1)
            {
                _WebUI显存压力优化设置 = "中";

            }
            if (WebUI显存压力优化设置.SelectedIndex == 2)
            {
                _WebUI显存压力优化设置 = " ";

            }
        }

        private void 性能优化器配置面板_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            性能优化器开关面版.Show();
        }

        private void 自动优化_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            
        }

        private void N卡优化_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (N卡模式 == false)
            {
                N卡模式 = true;
            }
            else
            {
                N卡模式 = false;
            }
        }

        private void A卡优化_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (A卡模式 == false)
            {
                A卡模式 = true;

            }
            else
            {
                A卡模式 = false;


            }
        }

        private void 启用XF_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (XF加速模式 == false)
            {
                XF加速模式 = true;
            }
            else
            {
                XF加速模式 = false;
            }
        }

        private void 分享WebUI到公网_Click(object sender, System.Windows.RoutedEventArgs e)
        {
           
        }
    }
}
