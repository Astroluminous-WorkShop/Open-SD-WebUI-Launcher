using 光源AI绘画盒子.ViewModels;
using 光源AI绘画盒子.Views.Pages;
using Microsoft.Web.WebView2.Wpf;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Wpf.Ui.Appearance;
using Wpf.Ui.Controls.Interfaces;
using Wpf.Ui.Mvvm.Contracts;
using static 光源AI绘画盒子.initialize;
using static Microsoft.Web.WebView2.Core.DevToolsProtocolExtension.Page;
using Application = System.Windows.Application;

namespace 光源AI绘画盒子.Views.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 



    public partial class MainWindow : INavigationWindow
    {

        public ViewModels.MainWindowViewModel ViewModel
        {
            get;
        }

        public MainWindow(ViewModels.MainWindowViewModel viewModel, IPageService pageService, INavigationService navigationService)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();
            GetSystemInfo();
            CheckStartPathFile();//从log读取工作路径
            if (File.Exists(@".AI_launther_log\UIalpha.txt"))
            {
                string alphaStringent = File.ReadAllText(@".AI_launther_log\UIalpha.txt");
                背景亮度 = int.Parse(alphaStringent);
                图片亮度.Value = int.Parse(alphaStringent);
            }

            async void GetSystemInfo()
            {

                string gpuname = await Task.Run(() => hardinfo.GPUName());


                _GPUname = gpuname;//开始对GPUname判断
                if (_GPUname.Contains("Radeon"))
                {
                    _显卡类型 = "Radeon";
                    A卡模式 = true;
                    XF加速模式 = false;

                }
                if (_GPUname.Contains("NVIDIA"))
                {
                    _显卡类型 = "NVIDIA";
                    N卡模式 = true;
                    XF加速模式 = true;

                }

                //计算机名称类型.Text = "系统名称：" + Machinename + "   系统类型：" + systemType;
                //计算机内存信息.Text = "内存信息：" + memorynum + " 插槽" + "  共计" + memorysize + " GB";
                //计算机显卡信息.Text = "显卡信息：" + gpuname;
            }
            basewindow.WindowBackdropType = BackgroundType.Mica;
            if (Theme.GetAppTheme() == ThemeType.Dark)
            {
                Dark.IsChecked = true;
            }
            else
            {
                Light.IsChecked = true;
            }
            if (File.Exists(@".AI_launther_log\UI.txt"))
            {
                // 如果文件存在，读取其中的内容到gitpath全局变量中
                背景颜色 = File.ReadAllText(@".AI_launther_log\UI.txt");
                if (File.Exists(@".AI_launther_log\UIpicture.txt"))
                {
                    // 如果文件存在，读取其中的内容到gitpath全局变量中
                    背景图片 = File.ReadAllText(@".AI_launther_log\UIpicture.txt");
                }



                if (背景颜色 == "Mica")
                {
                    basewindow.WindowBackdropType = BackgroundType.Mica;
                    主题背景图.Opacity = 0;
                    Mica.IsChecked = true;

                }
                if (背景颜色 == "Acrylic")
                {
                    basewindow.WindowBackdropType = BackgroundType.Acrylic;
                    主题背景图.Opacity = 0;
                    Acrylic.IsChecked = true;
                }
                if (背景颜色 == "Tabbed")
                {
                    basewindow.WindowBackdropType = BackgroundType.Tabbed;
                    主题背景图.Opacity = 0;
                    Tabbed.IsChecked = true;
                }
                if (背景颜色 == "Auto")
                {
                    basewindow.WindowBackdropType = BackgroundType.Auto;
                    主题背景图.Opacity = 0;
                    Auto.IsChecked = true;
                }
                if (背景颜色 == "None")
                {
                    basewindow.WindowBackdropType = BackgroundType.None;
                    主题背景图.Opacity = 0;
                    None.IsChecked = true;
                }
                if (背景颜色 == "Picture")
                {
                    Picture.IsChecked = true;
                    if (File.Exists(@".AI_launther_log\UIalpha.txt"))
                    {
                        string alphaStringent = File.ReadAllText(@".AI_launther_log\UIalpha.txt");
                        背景亮度 = int.Parse(alphaStringent);

                        图片亮度.Value = int.Parse(alphaStringent);
                        主题背景图.Opacity = 图片亮度.Value / 100; ;
                        string imagepath = 背景图片; // 获取选择的文件路径+文件名  
                        ImageSource imageSource = new BitmapImage(new Uri(imagepath)); // 设置Image的ImageSource为选择的图片  
                        主题背景图.ImageSource = imageSource; // 将选择的图片显示在Image控件中  

                    }
                }
            }

            SetPageService(pageService);

            navigationService.SetNavigationControl(RootNavigation);

            _loadpage();
            //在启动的时候判断是否下载与安装SDwebUI
            已下载WebUI = CheckWebUIdownloaded();
            已安装WebUI = CheckWebUIinstelled();
            已解压WebUI = CheckWebUIunzip();
        }



        async Task _loadpage()
        {
            // 加载页的背景图计时器
            await Task.Delay(TimeSpan.FromSeconds(3));

            // 在UI线程中更改grid的visibility  
            Dispatcher.Invoke(() =>
            {
                开屏画面.Visibility = Visibility.Collapsed;
                主显示区.Visibility = Visibility.Visible;
            });
        }

        #region INavigationWindow methods

        public System.Windows.Controls.Frame GetFrame()
            => RootFrame;

        public INavigation GetNavigation()
            => RootNavigation;

        public bool Navigate(Type pageType)
            => RootNavigation.Navigate(pageType);

        public void SetPageService(IPageService pageService)
            => RootNavigation.PageService = pageService;

        public void ShowWindow()
            => Show();

        public void CloseWindow()
            => Close();

        #endregion INavigationWindow methods

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            File.WriteAllText(@".AI_launther_log\UIalpha.txt", 图片亮度.Value.ToString());
            File.WriteAllText(@".AI_launther_log\UI.txt", 背景颜色);
            File.WriteAllText(@".AI_launther_log\UIpicture.txt", 背景图片);
            Application.Current.Shutdown();

        }

        private void 一键启动按钮_Click(object sender, RoutedEventArgs e)
        {
            //检查WebUI安装状态
            已下载WebUI = CheckWebUIdownloaded();
            已安装WebUI = CheckWebUIinstelled();
            已解压WebUI = CheckWebUIunzip();

            //通过对是否安装webUI已安装的判断做出提示安装或直接启动的操作
            if (已安装WebUI == false)
            {
                //探出flyout提示用户去安装
                安装提示.Show();
            }
            if (已安装WebUI == true)
            {
                //AI,启动！
                shell Shell = new shell();//shell会自动读取initilize中的参数变量
                Shell.Show();

            }




        }

        private void 主题切换_Click(object sender, RoutedEventArgs e)
        {
            主题设置区.Show();
            //if (basewindow.WindowBackdropType == BackgroundType.Mica)
            //{
            //    basewindow.WindowBackdropType = BackgroundType.Acrylic;
            //    主题背景图.Opacity = 0;
            //    initialize.背景颜色 = "Acrylic";

            //    File.WriteAllText(@".AI_launther_log\UI.txt", "Acrylic");

            //}

            //else
            //{
            //    basewindow.WindowBackdropType = BackgroundType.Mica;
            //    主题背景图.Opacity = 0;
            //    initialize.背景颜色 = "Mica";
            //    File.WriteAllText(@".AI_launther_log\UI.txt", "Mica");

            //}

            //{
            // 

            //}
            //else
            //{
            //    Wpf.Ui.Appearance.Theme.Apply(ThemeType.Dark);
            //}


        }


        //下面是主题效果
        private void Mica_Click(object sender, RoutedEventArgs e)
        {
            basewindow.WindowBackdropType = BackgroundType.Mica;
            背景颜色 = "Mica";

            主题背景图.Opacity = 0;

        }

        private void Acrylic_Click(object sender, RoutedEventArgs e)
        {
            basewindow.WindowBackdropType = BackgroundType.Acrylic;
            背景颜色 = "Acrylic";

            主题背景图.Opacity = 0;

        }

        private void Tabbed_Click(object sender, RoutedEventArgs e)
        {
            basewindow.WindowBackdropType = BackgroundType.Tabbed;
            背景颜色 = "Tabbed";

            主题背景图.Opacity = 0;
        }

        private void Auto_Click(object sender, RoutedEventArgs e)
        {
            basewindow.WindowBackdropType = BackgroundType.Auto;
            背景颜色 = "Auto";

            主题背景图.Opacity = 0;
        }

        private void None_Click(object sender, RoutedEventArgs e)
        {
            basewindow.WindowBackdropType = BackgroundType.None;
            背景颜色 = "None";

            主题背景图.Opacity = 0;
        }

        private void Picture_Click(object sender, RoutedEventArgs e)
        {
            主题背景图.Opacity = 图片亮度.Value / 100;
            背景颜色 = "Picture";
            string imagepath = 背景图片; // 获取选择的文件路径+文件名  
            ImageSource imageSource = new BitmapImage(new Uri(imagepath)); // 设置Image的ImageSource为选择的图片  
            主题背景图.ImageSource = imageSource; // 将选择的图片显示在Image控件中  
        }

        private void 图片亮度_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            主题背景图.Opacity = 图片亮度.Value / 100;
            背景亮度 = (int)图片亮度.Value;
        }

        private void 图片亮度_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            主题背景图.Opacity = 图片亮度.Value / 100;
            背景亮度 = (int)图片亮度.Value;
        }

        private void 图片亮度_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            主题背景图.Opacity = 图片亮度.Value / 100;
            背景亮度 = (int)图片亮度.Value;
        }

        private void 选择背景图片_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
            ofd.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png"; // 只允许选择图片文件  
            if (ofd.ShowDialog() == true) // 用户选择了一个文件并点击了“确定”按钮  
            {
                背景图片 = ofd.FileName;
                string imagepath = ofd.FileName; // 获取选择的文件路径+文件名  
                ImageSource imageSource = new BitmapImage(new Uri(imagepath)); // 设置Image的ImageSource为选择的图片  
                主题背景图.ImageSource = imageSource; // 将选择的图片显示在Image控件中  
            }
        }

        private void Dark_Click(object sender, RoutedEventArgs e)
        {
            Theme.Apply(ThemeType.Dark);
        }

        private void Light_Click(object sender, RoutedEventArgs e)
        {
            Theme.Apply(ThemeType.Light);
        }
    }
}