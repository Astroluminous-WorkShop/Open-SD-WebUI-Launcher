using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
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

using static System.Net.Mime.MediaTypeNames;

namespace AetherLauncher.Frames
{
    /// <summary>
    /// Page2.xaml 的交互逻辑
    /// </summary>
   
    public partial class Page2 : Page
    {
        //private string argsshow;

        //public List<string> list1 { get; set; }
        //private List<string> List2 = new List<string>();
        //public List<string> list0 { get; set; }
        //这里存放介绍
        System.Windows.Controls.Frame frameA = new Frame() { Content = new Frames.engine.DashboardPage() };//命令行
        System.Windows.Controls.Frame frameB = new Frame() { Content = new Frames.engine.WebUIVerManage() };//命令行
        System.Windows.Controls.Frame frameD = new Frame() { Content = new Frames.engine.ExtsManage() };//命令行
        System.Windows.Controls.Frame frameC = new Frame() { Content = new Frames.engine.ModelsManage() };//命令行
        System.Windows.Controls.Frame frameE = new Frame() { Content = new Frames.engine.envControl() };//命令行



        public Page2()
        {
           
            InitializeComponent();
            LauncherPage.Content = frameA;
            参数管理选项卡.Background = new SolidColorBrush(Color.FromArgb(128, 255, 255, 255));

        }
        private void 参数管理选项卡_MouseDown(object sender, MouseButtonEventArgs e)
        {
            LauncherPage.Content = frameA;
            参数管理选项卡.Background = new SolidColorBrush(Color.FromArgb(128, 255, 255, 255));
            版本管理选项卡.Background = new SolidColorBrush(Color.FromArgb(64, 255, 255, 255));
            模型管理选项卡.Background = new SolidColorBrush(Color.FromArgb(64, 255, 255, 255));
            扩展管理选项卡.Background = new SolidColorBrush(Color.FromArgb(64, 255, 255, 255));
            环境管理选项卡.Background = new SolidColorBrush(Color.FromArgb(64, 255, 255, 255));

        }


        private void 版本管理选项卡_MouseDown(object sender, MouseButtonEventArgs e)
        {
            LauncherPage.Content = frameB;
            参数管理选项卡.Background = new SolidColorBrush(Color.FromArgb(64, 255, 255, 255));
            版本管理选项卡.Background = new SolidColorBrush(Color.FromArgb(128, 255, 255, 255));
            模型管理选项卡.Background = new SolidColorBrush(Color.FromArgb(64, 255, 255, 255));
            扩展管理选项卡.Background = new SolidColorBrush(Color.FromArgb(64, 255, 255, 255));
            环境管理选项卡.Background = new SolidColorBrush(Color.FromArgb(64, 255, 255, 255));

        }

        private void 模型管理选项卡_MouseDown(object sender, MouseButtonEventArgs e)
        {
            LauncherPage.Content = frameC;
            参数管理选项卡.Background = new SolidColorBrush(Color.FromArgb(64, 255, 255, 255));
            版本管理选项卡.Background = new SolidColorBrush(Color.FromArgb(64, 255, 255, 255));
            模型管理选项卡.Background = new SolidColorBrush(Color.FromArgb(128, 255, 255, 255));
            扩展管理选项卡.Background = new SolidColorBrush(Color.FromArgb(64, 255, 255, 255));
            环境管理选项卡.Background = new SolidColorBrush(Color.FromArgb(64, 255, 255, 255));

        }

        private void 扩展管理选项卡_MouseDown(object sender, MouseButtonEventArgs e)
        {
            LauncherPage.Content = frameD;
            参数管理选项卡.Background = new SolidColorBrush(Color.FromArgb(64, 255, 255, 255));
            版本管理选项卡.Background = new SolidColorBrush(Color.FromArgb(64, 255, 255, 255));
            模型管理选项卡.Background = new SolidColorBrush(Color.FromArgb(64, 255, 255, 255));
            扩展管理选项卡.Background = new SolidColorBrush(Color.FromArgb(128, 255, 255, 255));
            环境管理选项卡.Background = new SolidColorBrush(Color.FromArgb(64, 255, 255, 255));

        }

        private void 环境管理选项卡_MouseDown(object sender, MouseButtonEventArgs e)
        {
            LauncherPage.Content = frameE;
            参数管理选项卡.Background = new SolidColorBrush(Color.FromArgb(64, 255, 255, 255));
            版本管理选项卡.Background = new SolidColorBrush(Color.FromArgb(64, 255, 255, 255));
            模型管理选项卡.Background = new SolidColorBrush(Color.FromArgb(64, 255, 255, 255));
            扩展管理选项卡.Background = new SolidColorBrush(Color.FromArgb(64, 255, 255, 255));
            环境管理选项卡.Background = new SolidColorBrush(Color.FromArgb(128, 255, 255, 255));
            
        }
    }




    }



//    list1 = new List<string> {
//        "--autolaunch",
//        "--no-half",
//        "--no-half-vae",
//        "--medvram",
//        "--lowvram",
//        "--share",
//        "--upcast-sampling",
//        "--xformers",
//        "--force-enable-xformers",
//        "--reinstall-xformers",
//        "--xformers-flash-attention",
//        "--disable-safe-unpickle",
//        "--use-cpu all",
//        "--skip-torch-cuda-test",
//        "--precision full",
//        "--precision autocast",
//        "--opt-split-attention",
//        "--opt-split-attention-invokeai",
//        "--opt-split-attention-v1",
//        "--opt-sub-quad-attention",
//        "--opt-channelslast",
//        "",
//        "",
//    };
//    list0 = new List<string> {
//        "启动时自动在系统的默认浏览器中打开 WebUI URL",
//        "禁用半精度计算，仅用于解决GTX16/MX系列黑图问题，会导致大量显存占用",
//        "禁用半精度VAE",
//        "实现稳定的扩散模型优化，以牺牲一点速度来实现较低的VRM使用率，与--lowvram冲突",
//        "实现稳定的扩散模型优化，以牺牲大量速度来实现非常低的VRM使用率，与--medvram冲突",
//        "使用 share=True 对于 gradio 并使 UI 可通过他们的网站访问",
//        "向上采样，与--no-half冲突。通常产生与 --no-half 类似的结果，性能更好，同时使用更少的内存。",
//        "为交叉注意力层启用 Xformer,加速运算并减少显存占用，一般yu下一条同时使用",
//        "为交叉注意力层启用 Xformers，无论检查代码是否认为您可以运行它;如果这不起作用，请不要进行错误报告",
//        "强制重新安装 Xformers。对升级很有用 - 但在升级后将其删除，否则您将永久重新安装 xformers。",
//        "启用具有闪光注意功能的 xformer 以提高重现性（仅支持 SD2.x 或变体）",
//        "禁用检查 PyTorch 模型是否存在恶意代码，这可能导致你的计算机受到攻击",
//        "使用 CPU 运算 一般用于显卡不支持的情况 同时也要添加下一条--skip-torch-cuda-test 与下下一条--precision full",
//        "跳过CUDA检测，在不支持CUDA的情况下使用，添加上一条的同时也要添加本条",
//        "在此精度下进行评估",
//        "在此精度下进行评估",
//        "强制启用 Doggettx 的交叉注意力层优化。默认情况下，它对启用 cuda 的系统处于打开状态",
//        "强制启用 InvokeAI 的交叉注意力层优化。默认情况下，当 cuda 不可用时，它处于打开状态。",
//        "启用旧版本的分散注意力优化，该优化不会消耗它可以找到的所有VRAM功能",
//        "实现内存高效的亚二次交叉注意力层优化",
//        "为 4D 张量启用替代布局，可能仅在具有张量核心（16xx 及更高）的 Nvidia 卡上实现更快的推理",
//        "",
//        "",
//};




//    DataContext = this;
//}

//private void Border_MouseDown(object sender, MouseButtonEventArgs e)
//{

//}
//private void 命令列表滚动_ScrollChanged(object sender, ScrollChangedEventArgs e)
//{
//    指令简介滚动.ScrollToVerticalOffset(e.VerticalOffset);
//}

//private void 指令简介滚动_ScrollChanged(object sender, ScrollChangedEventArgs e)
//{
//    命令列表滚动.ScrollToVerticalOffset(e.VerticalOffset);
//}



//private void 添加按钮_MouseDown(object sender, MouseButtonEventArgs e)
//{





//}

//private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
//{
//    TextBlock textBlock = sender as TextBlock;

//List2.Add(textBlock.Text);
//    string 命令列表字符串来自自定义 = string.Join(" ", List2 );

//    选择指令展示器.Text =命令列表字符串来自自定义 ;

//}

//private void 恢复按钮_MouseDown(object sender, MouseButtonEventArgs e)
//{
//    List2.Clear();
//    选择指令展示器.Text = string.Join("", List2);
//}

//private void 保存按钮_MouseDown(object sender, MouseButtonEventArgs e)
//{

//}

//private void 保存按钮_MouseMove(object sender, MouseEventArgs e)
//{

//}

//private void 保存按钮_MouseLeave(object sender, MouseEventArgs e)
//{

//}
//}

//自定义命令

//public class List3Converter : IValueConverter
//{
//    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
//    {
//        int index = System.Convert.ToInt32(value) - 1;
//        if (index >= 0 && index < list3.Count)
//        {
//            return list3[index];
//        }
//        return "";
//    }
//    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
//    {
//        throw new NotImplementedException();
//    }

//    private List<double> list3 = new List<double> { 9.0, 8.0, 7.0, 6.0 };
//}


