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
using System.Windows.Shapes;
using Wpf.Ui.Controls;

namespace AetherLauncher.Frames.Windows
{
    /// <summary>
    /// TagInput.xaml 的交互逻辑
    /// </summary>
    public partial class TagInput : Window
    {
        public string tag { get; set; }
        public TagInput()
        {
            InitializeComponent();
        }

        public void OK_Click(object sender, RoutedEventArgs e)
        {
            this.tag = tagname.Text;
            this.DialogResult = true;
        }

        public void Cancle_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
