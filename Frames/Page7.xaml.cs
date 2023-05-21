using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace AetherLauncher.Frames
{
    /// <summary>
    /// Page7.xaml 的交互逻辑
    /// </summary>
    public partial class Page7 : Page
    {
        public Page7()
        {
            InitializeComponent();
        }

   

        private void TextBlock_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
   
            Process.Start(new ProcessStartInfo("https://space.bilibili.com/666714573") { UseShellExecute = true });

        }


        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
    
            Process.Start(new ProcessStartInfo("https://space.bilibili.com/3089593") { UseShellExecute = true });

        }

        private void TextBlock_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://space.bilibili.com/250989068") { UseShellExecute = true });

        }

        private void TextBlock_MouseDown_3(object sender, MouseButtonEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://space.bilibili.com/1484690146") { UseShellExecute = true });

        }

        private void TextBlock_MouseDown_4(object sender, MouseButtonEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://space.bilibili.com/666714573") { UseShellExecute = true });


        }

        

        private void TextBlock_MouseDown_6(object sender, MouseButtonEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://space.bilibili.com/23311040") { UseShellExecute = true });

        }

        private void TextBlock_MouseDown_7(object sender, MouseButtonEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://space.bilibili.com/787851") { UseShellExecute = true });

        }

      

        private void TextBlock_MouseDown_9(object sender, MouseButtonEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://space.bilibili.com/34590220") { UseShellExecute = true });

        }

        private void TextBlock_MouseDown_10(object sender, MouseButtonEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://space.bilibili.com/248109460") { UseShellExecute = true });

        }

        private void TextBlock_MouseDown_11(object sender, MouseButtonEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://space.bilibili.com/3493273354111039") { UseShellExecute = true });

        }

        private void TextBlock_MouseDown_12(object sender, MouseButtonEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://space.bilibili.com/35723238") { UseShellExecute = true });

        }

        private void tieba_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://tieba.baidu.com/f?ie=utf-8&kw=%E5%B9%BB%E7%81%B5AI%E7%BB%98%E7%94%BB%E7%9B%92%E5%AD%90&fr=search") { UseShellExecute = true });

        }
    }
}
