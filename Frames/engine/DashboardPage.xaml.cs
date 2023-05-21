using AetherLauncher.Frames.Windows;
using System;
using System.Collections.Generic;
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
using static AetherLauncher.MainWindow;
using static AetherLauncher.initialize;
using System.IO;
using System.ComponentModel;
using System.Diagnostics;
using static AetherLauncher.Frames.engine.DashboardPage;
using System.Windows.Controls;

using System.Text.Json;
using System.Windows.Controls.Primitives;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Win32Interop.Enums;

namespace AetherLauncher.Frames.engine
{
    /// <summary>
    /// DashboardPage.xaml 的交互逻辑
    /// </summary>
    public partial class DashboardPage : System.Windows.Controls.Page
    {
        private string argsshow;
        public List<string> list1 { get; set; }
        private List<string> List2 = new List<string>();
        public List<string> list0 { get; set; }
        public DashboardPage()
        {
            InitializeComponent();

            list1 = new List<string> {
        " --autolaunch",
        " --no-half",
        " --no-half-vae",
        " --medvram",
        " --lowvram",
        " --share",
        " --upcast-sampling",
        " --xformers",
        " --force-enable-xformers",
        " --reinstall-xformers",
        " --xformers-flash-attention",
        " --disable-safe-unpickle",
        " --use-cpu all",
        " --skip-torch-cuda-test",
        " --precision full",
        " --precision autocast",
        " --opt-split-attention",
        " --opt-split-attention-invokeai",
        " --opt-split-attention-v1",
        " --opt-sub-quad-attention",
        " --opt-channelslast",
        " --no-hashing",

    };
            list0 = new List<string> {
        "启动时自动在系统的默认浏览器中打开 WebUI URL",
        "禁用半精度计算，仅用于解决GTX16/MX系列黑图问题，会导致大量显存占用",
        "禁用半精度VAE",
        "实现稳定的扩散模型优化，以牺牲一点速度来实现较低的VRM使用率，与--lowvram冲突",
        "实现稳定的扩散模型优化，以牺牲大量速度来实现非常低的VRM使用率，与--medvram冲突",
        "使用 share=True 对于 gradio 并使 UI 可通过他们的网站访问",
        "向上采样，与--no-half冲突。通常产生与 --no-half 类似的结果，性能更好，同时使用更少的内存。",
        "为交叉注意力层启用 Xformer,加速运算并减少显存占用，一般yu下一条同时使用",
        "为交叉注意力层启用 Xformers，无论检查代码是否认为您可以运行它;如果这不起作用，请不要进行错误报告",
        "强制重新安装 Xformers。对升级很有用 - 但在升级后将其删除，否则您将永久重新安装 xformers。",
        "启用具有闪光注意功能的 xformer 以提高重现性（仅支持 SD2.x 或变体）",
        "禁用检查 PyTorch 模型是否存在恶意代码，这可能导致你的计算机受到攻击",
        "使用 CPU 运算 一般用于显卡不支持的情况 同时也要添加下一条--skip-torch-cuda-test 与下下一条--precision full",
        "跳过CUDA检测，在不支持CUDA的情况下使用，添加上一条的同时也要添加本条",
        "在此精度下进行评估",
        "在此精度下进行评估",
        "强制启用 Doggettx 的交叉注意力层优化。默认情况下，它对启用 cuda 的系统处于打开状态",
        "强制启用 InvokeAI 的交叉注意力层优化。默认情况下，当 cuda 不可用时，它处于打开状态。",
        "启用旧版本的分散注意力优化，该优化不会消耗它可以找到的所有VRAM功能",
        "实现内存高效的亚二次交叉注意力层优化",
        "为 4D 张量启用替代布局，可能仅在具有张量核心（16xx 及更高）的 Nvidia 卡上实现更快的推理",
        "为 4D 张量启用替代布局，可能仅在具有张量核心（16xx 及更高）的 Nvidia 卡上实现更快的推理",

};


            string filePath = @"C:\aetherlaunther\startpath.txt";

            // 如果文件存在，读取其中的内容到startpath全局变量中
            if (File.Exists(filePath))
            {
                工作路径展示.Text = File.ReadAllText(filePath);
            } 
     
            string filePath3 = @"C:\aetherlaunther\pythonpath.txt";

            // 如果文件存在，读取其中的内容到startpath全局变量中
            if (File.Exists(filePath3))
            {
                Python路径展示.Text = File.ReadAllText(filePath);
            }
            string filePath2 = @"C:\aetherlaunther\commands.txt";
            if (File.Exists(filePath2))
            {
                // 如果文件存在，读取其中的内容到startpath全局变量中
                命令列表 = File.ReadAllText(filePath2);
                选择指令展示器.Text = 命令列表;


            }

            DataContext = this;


        }

        private void 命令列表滚动_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            指令简介滚动.ScrollToVerticalOffset(e.VerticalOffset);
        }

        private void 指令简介滚动_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            命令列表滚动.ScrollToVerticalOffset(e.VerticalOffset);
        }
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;

            List2.Add(textBlock.Text);
            命令列表 = string.Join("", List2);
            File.WriteAllText(@"C:\aetherlaunther\commands.txt", 命令列表);
            选择指令展示器.Text = 命令列表;

        }


        private void 清空已选指令_MouseDown(object sender, MouseButtonEventArgs e)
        {
            List2.Clear();
            选择指令展示器.Text = string.Join("", List2);
            命令列表 = string.Join("", List2);
            File.WriteAllText(@"C:\aetherlaunther\commands.txt", 命令列表);
        }

        private void 管理工作路径_MouseDown(object sender, MouseButtonEventArgs e)
        {
            选择文件夹();
            //工作路径展示.Text = 启动路径;
            工作路径展示.Text = 启动路径;
        }




   

        private void 一键启动_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string 启动术式 = "";


            if (启动后自动打开浏览器检查.IsChecked == true)
            {
                启动术式 += "--autolaunch ";
            }
            if (启动后分享公网检查.IsChecked == true)
            {
                if (File.Exists("C:\\aetherlaunther\\gradioAcc.json"))
                {
                    //var jf = File.ReadAllText("gradioAcc.json");
                    //List<GradioAcc> gradioAcc = JsonSerializer.Deserialize<List<GradioAcc>>(jf, jsonOptions);

                    //启动术式 += " --gradio-auth ";
                    //for (int i = 0; i < gradioAcc.Count; i++)
                    //{
                    //    启动术式 += gradioAcc[i].Name + ":" + gradioAcc[i].Pass;
                    //    if (i != gradioAcc.Count - 1)
                    //    {
                    //        启动术式 += ",";
                    //    }
                    //}
                }
                else { 启动术式 += "--share "; }
            }
            if (theme.SelectedIndex == 0)
            {
                if (theme.SelectedIndex == 1)
                {
                    启动术式 += "--theme light ";
                }
                else
                {
                    启动术式 += "--theme dark ";
                }
            }
            启动术式 += "--port " + port.Text.Trim() + " ";
            if (host.Text.Length > 0) { 启动术式 += "--listen " + host.Text.Trim() + " "; }
            string 启动文件 = "";
            if (启动模式检查.IsChecked == true)
            {
                启动文件 = 启动路径 + @"\webui.py";
            }
            else
            {
                启动文件 = 启动路径 + @"\launch.py";
            }
            if (xatten.SelectedIndex != 0)//加载Xatten加速方案
            {
                启动术式 += ((ComboBoxItem)xatten.Items[xatten.SelectedIndex]).Content.ToString().Split(" ")[0] + " ";
            }
            if (theme.SelectedIndex != 0)
            {
                if (theme.SelectedIndex == 1)
                {
                    启动术式 += "--theme light ";
                }
                else
                {
                    启动术式 += "--theme dark ";
                }
            }
            if (this.gpumem.SelectedIndex == 0)
            {
                启动术式 += " --lowvram ";
            }
            else if (this.gpumem.SelectedIndex == 1)
            {
                启动术式 += " --medvram ";
            }
            标准输出流.Text = "";
            标准报错流.Text = "";
            //下面开始施法！！！！
            Process 启动魔法 = new Process();
            ProcessStartInfo startinfo = new ProcessStartInfo();
            startinfo.FileName =pythonPath+"python.exe"/*pythonPath*/;
            startinfo.Arguments = /*"-noexit -c"  + " " +*/ 启动文件 + " " + 启动术式 + 命令列表;
            startinfo.Verb = "r";
            startinfo.EnvironmentVariables["git"] = Environment.GetEnvironmentVariable("git");
            //startinfo.WorkingDirectory = "..\\";
            startinfo.RedirectStandardOutput = true;
            startinfo.RedirectStandardError = true;
            //startinfo.UseShellExecute = false;//不使用终端打开
            启动魔法.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);//绑定标准输出流的事件处理函数
            启动魔法.ErrorDataReceived += new DataReceivedEventHandler(ErrorHandler);//绑定标准错误流的事件处理函数
            启动魔法.StartInfo = startinfo;
            启动魔法.Start();//启动进程
            启动魔法.BeginOutputReadLine();//开始读取输出流
            启动魔法.BeginErrorReadLine();//开始读取错误流


        }
        private void OutputHandler(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                Dispatcher.Invoke(() =>
                {

                    标准输出流.AppendText(e.Data + Environment.NewLine);
                    标准输出流.ScrollToEnd();
                });
            }
        }
        private void ErrorHandler(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                Dispatcher.Invoke(() =>
                {
                    标准报错流.AppendText(e.Data + Environment.NewLine);
                    标准报错流.ScrollToEnd();
                });
            }
        }

        private void API账号管理_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ApiManager WindowMain = new ApiManager();
            WindowMain.Show();
        }

        private void Gradio账号管理_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void 管理Python路径_MouseDown(object sender, MouseButtonEventArgs e)
        {
            选择Python所在文件夹();
            Python路径展示.Text = pythonPath;
        }
    }
}
