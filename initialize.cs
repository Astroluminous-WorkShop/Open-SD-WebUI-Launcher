using AetherLauncher.Frames.engine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using static AetherLauncher.Frames.engine.DashboardPage;
using static AetherLauncher.MainWindow;
using System.Diagnostics;
using System.Management;

using System.Globalization;

using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;



namespace AetherLauncher
{
    class initialize//这里负责整个启动器的初始化，也是回复默认设置
    {


        
        


















        public static bool CheckDirectory()//首先查找C盘是否有工作目录C:/aetherlaunther，在C盘创建工作目录
        {
            if (Directory.Exists(@"C:\aetherlaunther"))
            {
                return true; // 首先需要引入System.IO命名空间，以便使用Directory类来操作文件夹。
          //使用Directory.Exists方法检查C:/ aetherlaunther文件夹是否存在，如果存在则返回notfirststart = true，否则执行步骤3。
          //使用Directory.CreateDirectory方法在C盘创建名为aetherlaunther的文件夹
            }
            else
            {
                Directory.CreateDirectory(@"C:\aetherlaunther");
                return false;
            }
        }
        public static string 启动路径="";
        public static string 命令列表="";
        public static string 路径状态="0";
        public static string pythonPath = "";
        public static string gitPath;
        public static string 相册图片数量;

        public static void 选择文件夹()
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = "请选择WebUI工作目录，至少保留25GB硬盘空间";
            if (folder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                启动路径 = folder.SelectedPath;
                File.WriteAllText(@"C:\aetherlaunther\startpath.txt", 启动路径);

            }
        }
        public static void 选择Python所在文件夹()
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = "请选择Python所在目录，要求3.10.x";
            if (folder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pythonPath = folder.SelectedPath;
                File.WriteAllText(@"C:\aetherlaunther\pythonpath.txt", pythonPath);

            }
        }
        public static void 获取程序同目录路径()
        {
             // 获取程序所在目录
                string 程序所在目录 = Directory.GetCurrentDirectory();
            gitPath = Environment.GetEnvironmentVariable("ProgrameFiles")+@"\Git\bin";


        }

        
        public static void CheckCommandline()
        {
            string filePath = @"C:\aetherlaunther\commands.txt";
            if (File.Exists(filePath))
            {
                // 如果文件存在，读取其中的内容到startpath全局变量中
                命令列表 = File.ReadAllText(filePath);
                
            }
        }



            public  static void CheckStartPathFile()
        {
            string filePath = @"C:\aetherlaunther\startpath.txt";
            if (File.Exists(filePath))
            {
                // 如果文件存在，读取其中的内容到startpath全局变量中
                启动路径 = File.ReadAllText(filePath);
                
    }
            else
            {
                // 如果文件不存在，创建文件并将默认值写入
                路径状态= "1";
                
                
            }

           
        }
            public  static void CheckPythonPathFile()
        {
            string filePath = @"C:\aetherlaunther\pythonpath.txt";
            if (File.Exists(filePath))
            {
                // 如果文件存在，读取其中的内容到startpath全局变量中
                pythonPath = File.ReadAllText(filePath);
                
    }
   

           
        }
        
        public static void 相册计数()
        {

            string 相册路径 = 启动路径 + "\\outputs";
                if (!Directory.Exists(相册路径))
                {
                    // 如果不存在，将"未找到相册"赋值给A1
                    相册图片数量 = "未找到相册";


                }
                else//相册计数功能
                {
                    int imageFileCount = 0;
                    // 遍历outputs文件夹及其子文件夹
                    foreach (string directory in Directory.GetDirectories(相册路径, "*", System.IO.SearchOption.AllDirectories))
                    {
                        // 遍历当前目录下的所有文件
                        foreach (string file in Directory.GetFiles(directory))
                        {
                            // 获取文件后缀名
                            string extension = System.IO.Path.GetExtension(file);
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
