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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static AetherLauncher.initialize;
using AetherLauncher.Frames;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Windows.Threading;
using Win32Interop.Enums;
using AetherLauncher;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics;

namespace AetherLauncher.Frames
{
    /// <summary>
    /// Page1.xaml 的交互逻辑
    /// </summary>
    public partial class Page1 : Page
    {



        public Page1()
        {
            InitializeComponent();

            initialize.相册计数();
       

           
        }





        private void 打开WebUI文件夹_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", 启动路径);
        }

        private void 打开文生图文件夹_MouseDown(object sender, MouseButtonEventArgs e)
        {
           string 文生图文件路径 = 启动路径 + "\\outputs\\txt2img-images";
            System.Diagnostics.Process.Start("explorer.exe", 文生图文件路径);
        }

        private void 打开图生图文件夹_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string 图生图文件路径 = 启动路径 + "\\outputs\\img2img-images";
            System.Diagnostics.Process.Start("explorer.exe", 图生图文件路径);
        }
        
        private void 统计生成图片数量_MouseDown(object sender, MouseButtonEventArgs e)
        {
            initialize.相册计数();
            图片数量展示.Text = "图片数量："+相册图片数量;
        }

       

        private void Canvas_MouseEnter(object sender, MouseEventArgs e)
        {
            Can1.Visibility = Visibility.Visible;

        }

        private void Canvas_MouseLeave(object sender, MouseEventArgs e)
        {
            Can1.Visibility = Visibility.Hidden;
        }

        private void Can1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo("https://www.bilibili.com/video/BV1H24y147wu/") { UseShellExecute = true });
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }

        private void 打开SD模型文件夹_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string SD模型文件路径 = 启动路径 + "\\models\\Stable-diffusion";
            System.Diagnostics.Process.Start("explorer.exe", SD模型文件路径);
        }

        private void 打开lora模型文件夹_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string LORA模型文件路径 = 启动路径 + "\\models\\Lora";
            System.Diagnostics.Process.Start("explorer.exe", LORA模型文件路径);
        }

        private void 打开VAE模型文件夹_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string VAE模型文件路径 = 启动路径 + "\\models\\VAE";
            System.Diagnostics.Process.Start("explorer.exe", VAE模型文件路径);

        }

        private void 打开EMB模型文件夹_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string EMB模型文件路径 = 启动路径 + "\\embeddings";
            System.Diagnostics.Process.Start("explorer.exe", EMB模型文件路径);

        }

        private void 打开HYP模型文件夹_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string HYP模型文件路径 = 启动路径 + "\\models\\hypernetworks";
            System.Diagnostics.Process.Start("explorer.exe", HYP模型文件路径);

        }

        private void 打开扩展模型文件夹_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string VAE模型文件路径 = 启动路径 + "\\extensions";
            System.Diagnostics.Process.Start("explorer.exe", VAE模型文件路径);

        }
    }
}
