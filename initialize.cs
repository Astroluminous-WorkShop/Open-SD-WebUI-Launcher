﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Management;
using System.Windows;
using System.Globalization;

using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using Wpf.Ui.Appearance;
using Wpf.Ui.Controls.Interfaces;
using Wpf.Ui.Mvvm.Contracts;
namespace 光源AI绘画盒子
{

    class initialize//这里负责整个启动器的初始化，也是回复默认设置
    {





        public static bool CheckDirectory()//首先查找启动器所在目录是否有工作目录，在启动器所在目录创建工作目录
        {
            if (Directory.Exists(@".AI_launther_log"))
            {
                return true;
            }
            else
            {
                Directory.CreateDirectory(@".AI_launther_log");
                return false;
            }
        }
        public static string 背景颜色 = "";
        public static string 背景图片 = "";
        public static int 背景亮度 = 0;
        //下面确定SD_WebUI是否已经安装
        public static bool 已下载WebUI = false;
        public static bool 已解压WebUI = false;
        public static bool 已安装WebUI = false;
        //下面是一些启动选项的具体操作
        public static bool 浏览器启动 = true;
        public static bool 启动api = false;
        public static bool 使用快速启动 = false;
        public static bool 分享WebUI到公网 = false;
        public static bool 使用CPU进行推理 = false;
        public static bool 关闭模型hash计算 = false;
        public static bool 无卡调试模式 = false;
        public static bool XF加速模式 = true;
        public static bool 自动加速模式 = true;
        public static bool A卡模式 = false;
        public static bool N卡模式 = false;
        //下面是一些参数的字符串预设

        public static string _WebUI性能优化器 = "";
        public static string _显卡类型 = "";
        public static string _WebUI显存压力优化设置 = "";
        public static string _WebUI主题颜色 = "";
        public static string _WebUI启动地址 = "";
        public static string _WebUI启动端口 = "";



        //下面是一些路径管理的具体实现
        public static string 工作路径 = "";
        public static string pythonPath = "";
        public static string gitPath = "";
        public static string venvPath = "";

        public static string 命令列表 = "";
        public static string 程序所在目录 = "";
        public static string 路径状态 = "0";
        //下面是全局硬件判断
        public static string _cpuname = "";
        public static string _GPUname = "";
        public static string 相册图片数量;

        public static string 参数列表 = "";//所有启动时传递的参数挂到这里，全局可编辑与访问


        public static void 选择工作路径()
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = "请选择WebUI工作目录，至少保留25GB硬盘空间";
            if (folder.ShowDialog() == DialogResult.OK)
            {
                工作路径 = folder.SelectedPath;
                File.WriteAllText(@".AI_launther_log\startpath.txt", 工作路径);

            }
        }
        public static void 选择Python路径()
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = "请选择Python所在目录，要求python版本3.10.x";
            if (folder.ShowDialog() == DialogResult.OK)
            {
                pythonPath = folder.SelectedPath;
                File.WriteAllText(@".AI_launther_log\pythonpath.txt", pythonPath);

            }
        }
        public static void 选择Git路径()
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = "请选择Git.exe所在目录";
            if (folder.ShowDialog() == DialogResult.OK)
            {
                gitPath = folder.SelectedPath;
                File.WriteAllText(@".AI_launther_log\gitpath.txt", gitPath);

            }
        }
        public static void 选择VENV路径()
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = "请选择虚拟环境所在目录";
            if (folder.ShowDialog() == DialogResult.OK)
            {
                venvPath = folder.SelectedPath;
                File.WriteAllText(@".AI_launther_log\venvpath.txt", venvPath);

            }
        }
        public static void 获取程序同目录路径()
        {
            // 获取程序所在目录
            程序所在目录 = Directory.GetCurrentDirectory();
        }
        public static bool CheckWebUIdownloaded() //检查WebUI是否下载
        {
            string instellPath = 工作路径 + @"\WebUIpack.7z";
            if (File.Exists(instellPath))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool CheckWebUIunzip() //检查WebUI是否解压
        {
            string instellPath = 工作路径 + @"\2.0.9\stable-diffusion-webui\webui-user.bat";
            if (File.Exists(instellPath))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public static bool CheckWebUIinstelled() //检查WebUI是否安装
        {
            string instellPath = 工作路径 + @"\webui-user.bat";
            if (File.Exists(instellPath))
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        public static void CheckCommandline()//这里在初始化后从log里读取保存的args
        {
            string filePath = @".AI_launther_log\argspath.txt";
            if (File.Exists(filePath))
            {
                // 如果文件存在，读取其中的内容到startpath全局变量中
                命令列表 = File.ReadAllText(filePath);

            }
        }
        public static void CheckStartPathFile()//这里在初始化后从log里读取工作路径
        {
            string filePath = @".AI_launther_log\startpath.txt";
            if (File.Exists(filePath))
            {
                // 如果文件存在，读取其中的内容到startpath全局变量中
                工作路径 = File.ReadAllText(filePath);

            }
            else
            {
                // 如果文件不存在，创建文件并将默认值写入
                路径状态 = "1";
            }


        }
        public static void CheckPythonPathFile()//这里在初始化后从log里读取python路径
        {
            string filePath = @".AI_launther_log\pythonpath.txt";
            if (File.Exists(filePath))
            {
                // 如果文件存在，读取其中的内容到pythonpath全局变量中
                pythonPath = File.ReadAllText(filePath);
            }
        }
        public static void CheckgitPathFile()//这里在初始化后从log里读取git路径
        {
            string filePath = @".AI_launther_log\gitpath.txt";
            if (File.Exists(filePath))
            {
                // 如果文件存在，读取其中的内容到gitpath全局变量中
                gitPath = File.ReadAllText(filePath);
            }
        }
        public static void CheckVENVPathFile()//这里在初始化后从log里读取VENV的路径
        {
            string filePath = @".AI_launther_log\venvpath.txt";
            if (File.Exists(filePath))
            {
                // 如果文件存在，读取其中的内容到venvpath全局变量中
                venvPath = File.ReadAllText(filePath);
            }
        }



        public static void 相册计数()
        {

            string 相册路径 = 工作路径 + "\\outputs";
            if (!Directory.Exists(相册路径))
            {
                // 如果不存在，将"未找到相册"赋值给A1
                相册图片数量 = "未找到相册";


            }
            else//相册计数功能
            {
                int imageFileCount = 0;
                // 遍历outputs文件夹及其子文件夹
                foreach (string directory in Directory.GetDirectories(相册路径, "*", SearchOption.AllDirectories))
                {
                    // 遍历当前目录下的所有文件
                    foreach (string file in Directory.GetFiles(directory))
                    {
                        // 获取文件后缀名
                        string extension = Path.GetExtension(file);
                        // 判断是否为图片文件
                        if (extension == ".png" || extension == ".jpg" || extension == ".jpeg" || extension == ".gif")
                        {
                            // 如果是图片文件，图片文件数量加1
                            imageFileCount++;
                        }
                    }
                }
                // 将图片文件数量写入变量AI
                int AI = imageFileCount;
                相册图片数量 = AI.ToString();

            }
        }








    }
}
