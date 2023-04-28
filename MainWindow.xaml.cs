using AetherLauncher.Frames;
using System.IO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Win32Interop.Enums;
using System.Windows.Forms;

using static AetherLauncher.Frames.Page2;
using static AetherLauncher.initialize;
using static AetherLauncher.Frames.engine.DashboardPage;
using AetherLauncher.Frames.engine;

namespace AetherLauncher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 



    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();
            MainPage.Content = frame1;
            initialize. 获取程序同目录路径();
            initialize.CheckDirectory();//对类库中的创建工作目录进行初始化
            initialize.CheckCommandline();//对类库中的检查保存的的路径进行加载
            initialize.CheckStartPathFile();//对读取设置的启动目录路径进行初始化
            initialize.相册计数();//获取相册数量
            IntPtr hWnd = new WindowInteropHelper(GetWindow(this)).EnsureHandle();
            var attribute = DWMWINDOWATTRIBUTE.DWMWA_WINDOW_CORNER_PREFERENCE;
            var preference = DWM_WINDOW_CORNER_PREFERENCE.DWMWCP_ROUND;
            DwmSetWindowAttribute(hWnd, attribute, ref preference, sizeof(uint));

            if (路径状态 == "1") { 引导之路径选择页面.Visibility= Visibility.Visible; }
            if (路径状态 == "1") { 用户协议.Visibility= Visibility.Visible; }
            


        }

        
        







        public enum DWMWINDOWATTRIBUTE
        {
            DWMWA_WINDOW_CORNER_PREFERENCE = 33
        }

        public enum DWM_WINDOW_CORNER_PREFERENCE
        {
            DWMWCP_DEFAULT = 1,//让系统决定是否对窗口采用圆角设置
            DWMWCP_DONOTROUND = 0,//绝不对窗口采用圆角设置
            DWMWCP_ROUND = 2,//适当时采用圆角设置
            DWMWCP_ROUNDSMALL = 2//是当时可采用半径较小的圆角设置
        }

        [DllImport("dwmapi.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern long DwmSetWindowAttribute(IntPtr hwnd,
                                                     DWMWINDOWATTRIBUTE attribute,
                                                     ref DWM_WINDOW_CORNER_PREFERENCE pvAttribute,
                                                     uint cbAttribute);

        //这里对所有的Page页面进行初始化，以便后续调用
        Frame frame1 = new Frame() { Content = new Frames.Page1()};
        Frame frame2 = new Frame() { Content = new Frames.Page2()};
        Frame frame3 = new Frame() { Content = new Frames.Page3()};
        Frame frame4 = new Frame() { Content = new Frames.Page4()};
        Frame frame5 = new Frame() { Content = new Frames.Page5()};
        Frame frame6 = new Frame() { Content = new Frames.Page6()};
        Frame frame7 = new Frame() { Content = new Frames.Page7()};
         
        //这里对硬件信息进行初始化




        //主页面整体控制部分

      
        
        //以下部分负责页面frame切换
        private void 工具栏01_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainPage.Content = frame1;
            buttom_color_changed.ChangeSets1();

            工具栏11.Visibility = Visibility.Visible;
            工具栏12.Visibility = Visibility.Hidden;
            工具栏13.Visibility = Visibility.Hidden;
            工具栏14.Visibility = Visibility.Hidden;
            工具栏15.Visibility = Visibility.Hidden;
            工具栏16.Visibility = Visibility.Hidden;
            工具栏17.Visibility = Visibility.Hidden;

        }

        private void 工具栏02_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainPage.Content = frame2;
            工具栏11.Visibility = Visibility.Hidden;
            工具栏12.Visibility = Visibility.Visible;
            工具栏13.Visibility = Visibility.Hidden;
            工具栏14.Visibility = Visibility.Hidden;
            工具栏15.Visibility = Visibility.Hidden;
            工具栏16.Visibility = Visibility.Hidden;
            工具栏17.Visibility = Visibility.Hidden;
          
            
        }

        private void 工具栏03_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainPage.Content = frame3;
            工具栏11.Visibility = Visibility.Hidden;
            工具栏12.Visibility = Visibility.Hidden;
            工具栏13.Visibility = Visibility.Visible;
            工具栏14.Visibility = Visibility.Hidden;
            工具栏15.Visibility = Visibility.Hidden;
            工具栏16.Visibility = Visibility.Hidden;
            工具栏17.Visibility = Visibility.Hidden;

        }

        private void 工具栏04_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainPage.Content = frame4;
            工具栏11.Visibility = Visibility. Hidden;
            工具栏12.Visibility = Visibility.Hidden;
            工具栏13.Visibility = Visibility.Hidden;
            工具栏14.Visibility = Visibility.Visible;
            工具栏15.Visibility = Visibility.Hidden;
            工具栏16.Visibility = Visibility.Hidden;
            工具栏17.Visibility = Visibility.Hidden;

        }

        private void 工具栏05_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainPage.Content = frame5;
            工具栏11.Visibility = Visibility.Hidden;
            工具栏12.Visibility = Visibility.Hidden;
            工具栏13.Visibility = Visibility.Hidden;
            工具栏14.Visibility = Visibility.Hidden;
            工具栏15.Visibility = Visibility.Visible;
            工具栏16.Visibility = Visibility.Hidden;
            工具栏17.Visibility = Visibility.Hidden;

        }

        private void 工具栏06_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainPage.Content = frame6;
            工具栏11.Visibility = Visibility.Hidden;
            工具栏12.Visibility = Visibility.Hidden;
            工具栏13.Visibility = Visibility.Hidden;
            工具栏14.Visibility = Visibility.Hidden;
            工具栏15.Visibility = Visibility.Hidden;
            工具栏16.Visibility = Visibility.Visible;
            工具栏17.Visibility = Visibility.Hidden;

        }

        private void 工具栏07_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainPage.Content = frame7;
            工具栏11.Visibility = Visibility.Hidden;
            工具栏12.Visibility = Visibility.Hidden;
            工具栏13.Visibility = Visibility.Hidden;
            工具栏14.Visibility = Visibility.Hidden;
            工具栏15.Visibility = Visibility.Hidden;
            工具栏16.Visibility = Visibility.Hidden;
            工具栏17.Visibility = Visibility.Visible;
        }

        private void 最小化按钮_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void 关闭按钮_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void 侧边栏_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = this;
            mainWindow.DragMove();
        }

        private void 侧边栏_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
          
            e.Handled = true;
        }

        private void 顶部栏_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = this;
            mainWindow.DragMove();
        }

        private void 顶部栏_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }

        

        
        

        private   void 路径选择按钮_MouseDown(object sender, MouseButtonEventArgs e)
        {

            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = "请选择WebUI工作目录";
            if (folder.ShowDialog()== System.Windows.Forms.DialogResult.OK)
            {
                启动路径 = folder.SelectedPath;
                File.WriteAllText(@"C:\aetherlaunther\startpath.txt", 启动路径);
                启动路径展示.Text ="当前选则路径是："+ 启动路径;
                
                完成路径选则按钮.Visibility= Visibility.Visible;
                
            }

            




            //OpenFileDialog openFile= new OpenFileDialog();
            ////openFile.DefaultExt = "";指定默认扩展名
            ////openFile.FileName = "";默认打开扩展名
            ////openFile.Filter = "";//只允许扩展名
            ////openFile.InitialDirectory = "";//初始化目录
            //openFile.Multiselect= false;//是否允许多选
            //openFile.RestoreDirectory= true;//其他目录，下次打开还是
            //openFile.Title = "请选择WebUI的工作目录";
            //openFile.ShowDialog();
            ////选则获取到的文件





        }

        private void 完成路径选则按钮_MouseDown(object sender, MouseButtonEventArgs e)
        {
            引导之路径选择页面.Visibility = Visibility.Hidden;

        }

        private void 启动按钮_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void 不同意协议按钮_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void 同意协议按钮_MouseDown(object sender, MouseButtonEventArgs e)
        {
            用户协议.Visibility = Visibility.Hidden;
        }
    }
}
