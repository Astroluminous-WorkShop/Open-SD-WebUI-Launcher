﻿using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
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
using static 光源AI绘画盒子.initialize;

using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Threading;

using Microsoft.Web.WebView2.Core.DevToolsProtocolExtension;
using static System.Net.Mime.MediaTypeNames;
using 光源AI绘画盒子;
using 光源AI绘画盒子.Views.Windows;

namespace 光源AI绘画盒子.Views.Pages
{
    /// <summary>
    /// webpp.xaml 的交互逻辑
    /// </summary>
    public partial class webpp
    {
        //这里指定下载进度条的默认值
        public delegate void ProgressBarSetter(double value);
        public void SetProgressBar(double value)
        {
            progressBar.Value = value;

        }
        public string speedInfo = "";
        public async void GetSystemInfo()
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
        string downloadUrl = "https://liblibai-online.vibrou.com/web/SD_WebUI_Pack/2.0.9.7z";
        string Packname = "WebUIpackcatch.7z";//这里指定默认下载名称
        private int progress = 0;

        private long _downloadedBytes = 0;
        private long _totalBytes = 0;
        private DateTime _startTime;
        DateTime startTime = DateTime.Now;
        long totalBytesRead = 0;


        public webpp()
        {
            InitializeComponent();
            GetSystemInfo();
            double freeSpaceGB = GetFreeSpaceGB(工作路径);
            磁盘剩余显示.Text = $"磁盘剩余空间：{freeSpaceGB:0.00} GB";
            if (freeSpaceGB == 0)
            {
                磁盘剩余显示.Text = $"";

                磁盘剩余显示.Text += "";
                return;
            }
            // 读取工作路径然后展示
            CheckStartPathFile();
            CheckPythonPathFile();
            CheckgitPathFile();
            CheckVENVPathFile();


            //检查WebUI安装状态
            已下载WebUI = CheckWebUIdownloaded();
            已安装WebUI = CheckWebUIinstelled();
            已解压WebUI = CheckWebUIunzip();
            if (已下载WebUI == true)
            {
                if (已解压WebUI == false)//未解压：解压安装组控件
                {
                    if (已安装WebUI == false)
                    {
                        下载组.Visibility = Visibility.Collapsed;//隐藏下载组控件
                        解压组.Visibility = Visibility.Visible;//显示解压组控件
                    }
                    if (已安装WebUI == true)
                    {
                        WebUI下载按钮.Content = "一键启动";
                    }
                }
                if (已解压WebUI == true)
                {
                    if (已安装WebUI == false)
                    {
                        下载组.Visibility = Visibility.Collapsed;//隐藏下载组控件
                        安装组.Visibility = Visibility.Visible;//显示解压组控件
                    }
                    if (已安装WebUI == true)
                    {
                        WebUI下载按钮.Content = "一键启动";
                    }
                }

            }
            if (已下载WebUI == false)
            {

                if (已解压WebUI == false)//未解压：解压安装组控件
                {

                    if (已安装WebUI == false)
                    {
                        WebUI下载按钮.Content = "一键下载";

                    }
                    if (已安装WebUI == true)
                    {
                        WebUI下载按钮.Content = "一键启动";
                    }
                }
                if (已解压WebUI == true)
                {

                    if (已安装WebUI == false)
                    {
                        磁盘剩余显示.Text += "未安装WebUI ";

                        下载组.Visibility = Visibility.Collapsed;//隐藏下载组控件
                        安装组.Visibility = Visibility.Visible;//显示解压组控件
                    }
                    if (已安装WebUI == true)
                    {
                        WebUI下载按钮.Content = "一键启动";
                    }
                }

            }



            工作路径展示.Text = 工作路径;
            Python路径展示.Text = pythonPath;
            Git路径展示.Text = gitPath;
            VENV路径展示.Text = venvPath;




        }



        private void 运行路径选择_Click(object sender, RoutedEventArgs e)
        {
            选择工作路径();
            //检查WebUI安装状态
            已下载WebUI = CheckWebUIdownloaded();
            已安装WebUI = CheckWebUIinstelled();
            已解压WebUI = CheckWebUIunzip();
            if (已下载WebUI == true)
            {
                if (已解压WebUI == false)//未解压：解压安装组控件
                {
                    if (已安装WebUI == false)
                    {
                        下载组.Visibility = Visibility.Collapsed;//隐藏下载组控件
                        解压组.Visibility = Visibility.Visible;//显示解压组控件
                    }
                    if (已安装WebUI == true)
                    {
                        WebUI下载按钮.Content = "一键启动";
                    }
                }
                if (已解压WebUI == true)
                {
                    if (已安装WebUI == false)
                    {
                        下载组.Visibility = Visibility.Collapsed;//隐藏下载组控件
                        安装组.Visibility = Visibility.Visible;//显示解压组控件
                    }
                    if (已安装WebUI == true)
                    {
                        WebUI下载按钮.Content = "一键启动";
                    }
                }

            }
            if (已下载WebUI == false)
            {

                if (已解压WebUI == false)//未解压：解压安装组控件
                {

                    if (已安装WebUI == false)
                    {
                        WebUI下载按钮.Content = "一键下载";

                    }
                    if (已安装WebUI == true)
                    {
                        WebUI下载按钮.Content = "一键启动";
                    }
                }
                if (已解压WebUI == true)
                {

                    if (已安装WebUI == false)
                    {
                        磁盘剩余显示.Text += "未安装WebUI ";

                        下载组.Visibility = Visibility.Collapsed;//隐藏下载组控件
                        安装组.Visibility = Visibility.Visible;//显示解压组控件
                    }
                    if (已安装WebUI == true)
                    {
                        WebUI下载按钮.Content = "一键启动";
                    }
                }

            }
            工作路径展示.Text = 工作路径;
            double freeSpaceGB = GetFreeSpaceGB(工作路径);
            磁盘剩余显示.Text = $"磁盘剩余空间：{freeSpaceGB:0.00} GB";
            if (freeSpaceGB < 5)
            {
                磁盘剩余显示.Text += "磁盘空间不足";
                return;
            }


        }

        private void Python路径选择_Click(object sender, RoutedEventArgs e)
        {
            选择Python路径();
            Python路径展示.Text = pythonPath;
        }

        private void Git路径选择_Click(object sender, RoutedEventArgs e)
        {
            选择Git路径();
            Git路径展示.Text = gitPath;
        }

        private void VENV路径选择_Click(object sender, RoutedEventArgs e)
        {
            选择VENV路径();
            VENV路径展示.Text = venvPath;
        }

        bool is_downloaded = false;

        //开始下载
        private void Download_Click(object sender, RoutedEventArgs e)
        {


            if (已下载WebUI == false && 已安装WebUI == false && 已解压WebUI == false)
            {
                if (is_downloaded == false)
                {
                    try
                    {
                        if (Directory.Exists(工作路径))
                        {

                        }
                        else
                        {
                            Directory.CreateDirectory(工作路径);
                        }
                        WebUI下载按钮.IsEnabled = false;

                        string modelpath = System.IO.Path.Combine(工作路径, Packname);
                        WebRequest request = WebRequest.Create(downloadUrl);
                        WebResponse respone = request.GetResponse();
                        progressBar.Maximum = respone.ContentLength;

                        ThreadPool.QueueUserWorkItem((obj) =>
                        {
                            Stream netStream = respone.GetResponseStream();


                            Stream fileStream = new FileStream(modelpath, FileMode.Create);
                            byte[] read = new byte[1024];
                            long progressBarValue = 0;
                            int realReadLen = netStream.Read(read, 0, read.Length);
                            while (realReadLen > 0)
                            {
                                fileStream.Write(read, 0, realReadLen);
                                progressBarValue += realReadLen;
                                progressBar.Dispatcher.BeginInvoke(new ProgressBarSetter(SetProgressBar), progressBarValue);
                                realReadLen = netStream.Read(read, 0, read.Length);

                                // 计算下载速度和已下载的文件大小/文件总大小
                                DateTime currentTime = DateTime.Now;
                                double elapsedSeconds = (currentTime - startTime).TotalSeconds;
                                if (elapsedSeconds > 0)
                                {
                                    double downloadSpeed = totalBytesRead / elapsedSeconds / 1024; // KB/s
                                    if (downloadSpeed > 0)
                                    {
                                        speedInfo = $" 当前速度：{downloadSpeed:F2}  KB/s";
                                        WebUI下载按钮.Dispatcher.BeginInvoke(new Action(() => WebUI下载按钮.Content = speedInfo), null);

                                    }


                                }
                                totalBytesRead += realReadLen;

                            }
                            netStream.Close();
                            fileStream.Close();



                            // 释放线程
                            ThreadPool.QueueUserWorkItem((obj) => { }, null);
                            // 文件下载完成后，释放下载按钮的Dispatcher
                            WebUI下载按钮.Dispatcher.BeginInvoke(new Action(() => WebUI下载按钮.Content = speedInfo), null);
                            WebUI下载按钮.Dispatcher.BeginInvoke(new Action(() =>
                            {
                                double freeSpaceGB = GetFreeSpaceGB(工作路径);
                                磁盘剩余显示.Text = $"磁盘剩余空间：{freeSpaceGB:0.00} GB";
                                if (freeSpaceGB < 5)
                                {
                                    磁盘剩余显示.Text += "磁盘空间不足";
                                    return;
                                }
                                WebUI下载按钮.Content = speedInfo;
                                下载组.Visibility = Visibility.Collapsed;
                                WebUI下载按钮.Content = "下载完成,保存在:" + 工作路径 + " 点击解压";
                                string filePath = 工作路径 + @"\WebUIpackcatch.7z";
                                if (File.Exists(filePath))
                                {
                                    // 如果文件存在，将其改名为WebUIpack.7z  
                                    string renamedFilePath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(filePath), "WebUIpack.7z");
                                    File.Move(filePath, renamedFilePath);
                                    MessageBox.Show("文件已成功重命名！");
                                }
                                string filePath2 = 工作路径 + @"\WebUIpack.7z";
                                if (File.Exists(filePath2))
                                {
                                    {
                                        WebUI下载按钮.IsEnabled = true;
                                        is_downloaded = true;
                                        已下载WebUI = true;
                                        解压组.Visibility = Visibility.Visible;
                                    }
                                }
                            }), null);
                        }, null);




                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("请先选择WebUI的工作路径");
                    }
                }


            }
            if (已安装WebUI == true)
            {
                WebUI下载按钮.Content = "一键启动";
                //AI,启动！
                shell Shell = new shell();//shell会自动读取initilize中的参数变量
                Shell.Show();

            }


        }

        private void 打开部署文件夹_Click(object sender, RoutedEventArgs e)
        {
            //用文件资源管理器打开工作路径
            Process.Start("explorer.exe", 工作路径);
        }




        private async void WebUI安装按钮_Click(object sender, RoutedEventArgs e)
        {

            // 设置7zip.exe的路径，确保路径是正确的  
            string SevenZipPath = @"7z.exe";
            标准输出流.Text = "";
            // 创建一个新的进程  
            Process 解压魔法 = new Process();
            ProcessStartInfo 解压术式 = new ProcessStartInfo();

            解压术式.FileName = SevenZipPath;
            解压术式.Arguments = $"x -y {工作路径 + "//WebUIpack.7z"} -o{工作路径}";
            解压术式.UseShellExecute = false;
            解压术式.RedirectStandardOutput = true;
            解压术式.CreateNoWindow = true;
            解压术式.RedirectStandardOutput = true;
            解压术式.RedirectStandardError = true;
            解压魔法.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);//绑定标准输出流的事件处理函数
            解压魔法.ErrorDataReceived += new DataReceivedEventHandler(ErrorHandler);//绑定标准错误流的事件处理函数
            解压魔法.StartInfo = 解压术式;
            // 启动
            解压魔法.Start();
            WebUI安装按钮.IsEnabled = false;
            WebUI安装按钮.Content = "正在解压资源，请不要关闭窗口";
            解压魔法.BeginOutputReadLine();//开始读取输出流
            解压魔法.BeginErrorReadLine();//开始读取错误流




        }

        private void OutputHandler(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                Dispatcher.Invoke(() =>
                {

                    标准输出流.Text += e.Data + Environment.NewLine;
                    命令行区域.ScrollToEnd();
                    if (标准输出流.Text.Contains("Everything is Ok"))
                    {
                        解压组.Visibility = Visibility.Collapsed;
                        安装组.Visibility = Visibility.Visible;
                        double freeSpaceGB = GetFreeSpaceGB(工作路径);
                        磁盘剩余显示.Text = $"磁盘剩余空间：{freeSpaceGB:0.00} GB";
                        if (freeSpaceGB < 5)
                        {
                            磁盘剩余显示.Text += "磁盘空间不足";
                            return;
                        }
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
                    标准报错流.Text += e.Data + Environment.NewLine;
                    命令行区域.ScrollToEnd();

                });
            }
        }

        private async void WebUI复制按钮_Click(object sender, RoutedEventArgs e)
        {
            WebUI复制按钮.Content = "正在拼命安装，请稍候....";
            WebUI复制按钮.IsEnabled = false;
            // 源文件夹路径  
            string sourceDirectory = 工作路径 + @"\2.0.9\stable-diffusion-webui";
            // 目标文件夹路径  
            string destinationDirectory = 工作路径;
            // 使用异步方法移动文件夹  
            try
            {
                await MoveFolderAsync(sourceDirectory, destinationDirectory);
            }
            catch (Exception ex)
            {
                // 处理或显示异常信息  
            }

            安装组.Visibility = Visibility.Collapsed;
            下载组.Visibility = Visibility.Visible;
            WebUI下载按钮.Content = "一键启动";
            已安装WebUI = true;

        }

        private double GetFreeSpaceGB(string path)
        {
            if (string.IsNullOrEmpty(path))
            {


                return 0;
            }
            else
            {
                DriveInfo drive = new DriveInfo(path);
                long freeSpaceBytes = drive.AvailableFreeSpace;
                long backw = freeSpaceBytes / (1024 * 1024 * 1024);

                return backw;
            }
        }



        public async static Task MoveFolderAsync(string sourcePath, string destPath)
        {
            if (Directory.Exists(sourcePath))
            {
                if (!Directory.Exists(destPath))
                {
                    //目标目录不存在则创建  
                    try
                    {
                        Directory.CreateDirectory(destPath);
                    }
                    catch (Exception ex)
                    {

                    }
                }

                //获得源文件下所有文件  
                List<string> files = new List<string>(Directory.GetFiles(sourcePath));
                foreach (var file in files)
                {
                    string destFile = System.IO.Path.Combine(new string[] { destPath, System.IO.Path.GetFileName(file) });
                    //覆盖模式  
                    if (File.Exists(destFile))
                    {
                        File.Delete(destFile);
                    }
                    await Task.Run(() => File.Move(file, destFile));
                }

                //获得源文件下所有目录文件  
                List<string> folders = new List<string>(Directory.GetDirectories(sourcePath));
                foreach (var folder in folders)
                {
                    string destDir = System.IO.Path.Combine(new string[] { destPath, System.IO.Path.GetFileName(folder) });
                    //Directory.Move必须要在同一个根目录下移动才有效，不能在不同卷中移动。  
                    //Directory.Move(folder, destDir);  
                    await Task.Run(() => MoveFolderAsync(folder, destDir));
                }
            }
            else
            {

            }
        }
    }
}
