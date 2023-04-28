using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace AetherLauncher
{
    internal class text_color_change
    {
        public static void ChangeTextColor(TextBlock textblock)
        {
            textblock.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        } public static void BackTextColor(TextBlock textblock)
        {
            textblock.Foreground = new SolidColorBrush(Color.FromArgb(255, 170, 173, 224));
        }
    }
    internal class GUIcolor
    {
        dynamic phantomUIcolor1Background = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));//背景色
        dynamic phantomUIcolor2Mosemove = new SolidColorBrush(Color.FromArgb(64, 255, 255, 255));//鼠标放置颜色
        dynamic phantomUIcolor3Mousedown = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));//鼠标点击后颜色

    }






    internal class buttom_color_changed
    {
        public static void ChangeSets1() {
            
        }
        public static void ChangeSets2() { }
        public static void ChangeSets3() { }
        public static void ChangeSets4() { }
        public static void ChangeSets5() { }
        public static void ChangeSets6() { }
    }
}
