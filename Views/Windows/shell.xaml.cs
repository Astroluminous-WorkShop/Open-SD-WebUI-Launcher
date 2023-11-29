using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using Wpf.Ui.Controls;
using static 光源AI绘画盒子.initialize;//这里引入全局参数库
namespace 光源AI绘画盒子.Views.Windows
{

    public partial class shell : UiWindow
    {

        public string 启动文件 = "launch.py";//这里是默认的启动文件
        string cpuname = "";
        string Machinename = "";
        string systemType = "";
        float memorysize = 1;
        int memorynum = 1;
        string gpuname = "";
        private DispatcherTimer _timer;
        private Process _process;
        private Process 启动魔法;

        public shell()
        {

            InitializeComponent();
            GetSystemInfo();
            参数列表 = "";

            string 设备支持列表 = "";
            async Task GetSystemInfo()
            {
                cpuname = await Task.Run(() => hardinfo.GetCpuName());
                Machinename = await Task.Run(() => hardinfo.GetComputerName());
                systemType = await Task.Run(() => hardinfo.GetSystemType());

                memorysize = await Task.Run(() => hardinfo.GetPhysicalMemory());
                memorynum = await Task.Run(() => hardinfo.MemoryNumberCount());
                gpuname = await Task.Run(() => hardinfo.GPUName());
                标准输出流.AppendText("StableDiffusionWebUI正在启动，请耐心等待" + Environment.NewLine);
                标准输出流.AppendText("光源AI绘画启动核心版本：3.0.5-7 2023/11/16" + Environment.NewLine);
                标准输出流.AppendText("关注bilibili@Ray_Source光源 获取最新支持" + Environment.NewLine);

                标准输出流.AppendText("<光源AI绘画启动器核心 | [硬件检测]>" + Environment.NewLine);
                标准输出流.AppendText("CPU信息：" + cpuname + Environment.NewLine);
                标准输出流.AppendText("系统名称：" + Machinename + "   系统类型：" + systemType + Environment.NewLine);
                标准输出流.AppendText("内存信息：" + memorynum + " 插槽" + "  共计" + memorysize + " GB" + Environment.NewLine);
                标准输出流.AppendText("显卡信息：" + gpuname + Environment.NewLine);

            }
            //这里开始从initilize中被处理过的参数变量进行初始化
            if (浏览器启动 == true)
            {
                参数列表 += " --autolaunch";

            }
            if (分享WebUI到公网 == true) { 参数列表 += " --autolaunch --share"; }
            if (关闭模型hash计算 == true) { 参数列表 += " --no-hashing"; }
            if (无卡调试模式 == true) { 参数列表 += " --UItest"; }


            if (A卡模式 == true)
            {
                参数列表 += " --precision full --upcast-sampling --device-name directml --use-cpu interrogate --no-gradio-queue --opt-sub-quad-attention ";
            }
            if (N卡模式 == true)
            {
                if (XF加速模式 == true)
                {
                    参数列表 += " --xformers --xformers-flash-attention ";
                }
                else
                {
                    参数列表 += " --opt-channelslast --no-gradio-queue --opt-sdp-no-mem-attention ";

                }
            }
            if (使用CPU进行推理 == true) { 参数列表 = " --autolaunch --use-cpu all --precision full --no-half --skip-torch-cuda-test"; }
            //if (_WebUI显存压力优化设置 == "低")
            //{
            //    参数列表 = " --autolaunch --lowvram";
            //}
            //if (_WebUI显存压力优化设置 == "中")
            //{
            //    参数列表 = " --autolaunch --medvram";
            //}
            try
            {




                //这里开始创建启动进程

                标准输出流.Text = "";
                标准报错流.Text = "";
                //下面开始施法！！！！


                启动魔法 = new Process();
                ProcessStartInfo startinfo = new ProcessStartInfo();
                string 启动参数 = 参数列表;
                startinfo.FileName = 工作路径 + @"\Python3.10\python.exe"/*initialize.工作路径+ @"\webui-user.bat"*/;
                startinfo.Arguments = 工作路径 + @"\launch.py" + 参数列表;
                startinfo.WorkingDirectory = 工作路径;

                startinfo.EnvironmentVariables["GIT"] = 工作路径 + @"\Git\mingw64\libexec\git-core\git.exe";
                startinfo.EnvironmentVariables["PYTHON"] = 工作路径 + @"\Python3.10\python.exe";
                startinfo.EnvironmentVariables["TRANSFORMERS_CACHE"] = 工作路径 + @"\deploy\.cache\huggingface\transformers";
                startinfo.EnvironmentVariables["GIT_PYTHON_REFRESH"] = "quiet";
                startinfo.EnvironmentVariables["HUGGINGFACE_HUB_CACHE"] = 工作路径 + @"\deploy\.cache\huggingface\hub";
                startinfo.EnvironmentVariables["GIT_SSL_NO_VERIFY"] = "true";


                startinfo.RedirectStandardOutput = true;
                startinfo.RedirectStandardError = true;
                startinfo.CreateNoWindow = true;
                startinfo.UseShellExecute = false;//不使用终端打开

                启动魔法.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);//绑定标准输出流的事件处理函数
                启动魔法.ErrorDataReceived += new DataReceivedEventHandler(ErrorHandler);//绑定标准错误流的事件处理函数
                启动魔法.StartInfo = startinfo;
                启动魔法.Start();//启动进程
                启动魔法.BeginOutputReadLine();//开始读取输出流
                启动魔法.BeginErrorReadLine();//开始读取错误流
                _process = Process.GetProcessesByName("光源AI绘画盒子")[0];
                _timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) }; // 设置每秒更新一次  
                _timer.Tick += TimerTick;
                _timer.Start();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("请选择正确WebUI的工作路径");
            }
        }

        private void TimerTick(object sender, EventArgs e)
        {
            var cpuUsage = _process.TotalProcessorTime.TotalSeconds;
            var memoryUsage = _process.WorkingSet64 / (1024 * 1024); // 转换为MB  
            string text = $"CPU 内核时间: {cpuUsage}  |  内存使用： {memoryUsage}MB";
            系统占用.Dispatcher.Invoke(() => 系统占用.Text = text); // 在UI线程更新TextBlock  
        }



        int ExtractProgress(string text)
        {
            int nums = 1;
            Match match = Regex.Match(text, @"\s*(\d+)%");
            string matchedString = match.Groups[1].Value; // 提取括号中的内容  
            try { nums = int.Parse(matchedString); }
            catch { }

            return nums;// 将提取的字符串转为整数   
        }




        int ExtractProgressf2(string text)
        {
            Match match = Regex.Match(text, @"\s*(\d+)%");
            string matchedString = match.Groups[1].Value; // 提取括号中的内容  

            return int.Parse(matchedString); // 将提取的字符串转为整数  
        }

        string ExtractTimeInfo(string text)
        {
            // 找到最后一个 [ 的索引  
            int index = text.LastIndexOf("[");
            if (index != -1)
            {
                // 提取 [ 和下一个 ] 之间的信息  
                string timeInfo = text.Substring(index, text.IndexOf("]", index) - index + 1);
                return timeInfo;
            }
            return ""; // 如果未找到 [，则返回空字符串  
        }
        private void OutputHandler(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {

                Dispatcher.Invoke(() =>
                {

                    if (e.Data.Contains("Total progress"))
                    {
                        Thickness movemargin = new Thickness(0, 0, 0, 60);
                        处理进度条.Visibility = Visibility.Visible;
                        滚动面板.Margin = movemargin;

                        string text = e.Data;
                        int totalProgress = ExtractProgress(text);
                        string timeInfo = ExtractTimeInfo(text);

                        // 设置进度条的值  
                        总输出进度.Value = totalProgress;
                        所有任务进度.Text = "所有任务进度：" + totalProgress + "%";
                        // 在文本块中显示时间信息  
                        总输出信息.Text = timeInfo;

                    }
                    if (!e.Data.Contains("Total progress"))
                    {
                        标准输出流.AppendText(e.Data + Environment.NewLine);
                        标准输出流.ScrollToEnd();
                    }


                });
            }
        }
        private void ErrorHandler(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                Dispatcher.Invoke(() =>
                {
                    if (!e.Data.Contains("%"))
                    {
                        标准输出流.AppendText(e.Data + Environment.NewLine);
                        滚动面板.ScrollToEnd();
                    }
                    if (e.Data.Contains("%"))
                    {

                        string text = e.Data;
                        int totalProgress = ExtractProgressf2(text);
                        string timeInfo = ExtractTimeInfo(text);

                        // 设置进度条的值  
                        当前输出进度.Value = totalProgress;
                        当前任务进度.Text = "当前任务进度：" + totalProgress + "%";
                        // 在文本块中显示时间信息  
                        当前输出信息.Text = timeInfo;

                    }

                    if (e.Data.Contains(" git_clone(stable_diffusion_repo, repo_dir('stable-diffusion-stability-ai'), \"Stable Diffusion\", stable_diffusion_commit_hash)"))//
                    {
                        标准报错流.AppendText("" + Environment.NewLine);
                        标准报错流.AppendText("<光源AI绘画启动器核心 | [操作提示]>：这个错误提示表明在执行Git命令时出现了问题" + Environment.NewLine);
                        标准报错流.AppendText("要解决这个问题，你可以尝试以下几个步骤：" + Environment.NewLine);
                        标准报错流.AppendText("1,确保Git已经正确安装并配置在你的计算机上。你可以检查Git的安装路径和环境变量是否正确设置。" + Environment.NewLine);
                        标准报错流.AppendText("2,检查Git仓库的路径是否正确。根据错误信息中的路径，请确保该路径存在并且是一个有效的Git仓库。" + Environment.NewLine);
                        标准报错流.AppendText("3,检查Git命令的语法和参数是否正确。根据错误信息中的命令，它应该是正确的。但是，如果有任何拼写错误或参数错误，可能会导致执行失败。" + Environment.NewLine);
                        标准报错流.AppendText(" " + Environment.NewLine);
                    }
                    if (e.Data.Contains("There is not enough GPU video memory available!"))
                    {
                        标准输出流.AppendText("GPU显存不足，请适当减小图片尺寸等相关参数。" + Environment.NewLine);
                    }
                    if (e.Data.Contains("HTTPSConnectionPool(host='huggingface.co', port=443"))
                    {
                        标准报错流.AppendText("" + Environment.NewLine);
                        标准报错流.AppendText("        <光源AI绘画启动器核心 [级别：重要]>：连接超时，请断开网络连接以修复" + Environment.NewLine);
                        标准报错流.AppendText("" + Environment.NewLine);
                    }
                    if (e.Data.Contains("fatal: not a git repository (or any of the parent directories): .git"))
                    {
                        标准报错流.AppendText("" + Environment.NewLine);
                        标准报错流.AppendText("        <光源AI绘画启动器核心 [级别：可忽略]>：这个错误提示表示当前目录不是一个Git仓库，或者其父目录中没有找到.git文件夹。请确保在正确的Git仓库目录下执行此命令。\r\n\r\n" + Environment.NewLine);
                        标准报错流.AppendText("" + Environment.NewLine);
                    }

                });
            }
        }
        protected override void OnClosed(EventArgs e)
        {//在控制台关闭后结束跑图用的Python进程
            base.OnClosed(e);
            启动魔法.Kill();
            //启动魔法.WaitForExit();//屏蔽掉这些是因为可能导致主窗口卡死
            //启动魔法 = null;


        }
    }
}

