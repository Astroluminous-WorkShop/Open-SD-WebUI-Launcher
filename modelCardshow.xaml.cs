using 光源AI绘画盒子.Views.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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
using 光源AI绘画盒子.Views.Windows;

namespace 光源AI绘画盒子
{
    /// <summary>
    /// modelCardshow.xaml 的交互逻辑
    /// </summary>
    public partial class modelCardshow : UserControl
    {

        string 模型_UUID = "";
        string _nickname = "";
        string _avatar = "";
        string _modelType = "";
        string _imageURL = "";
        public modelCardshow(string modelname, string imageUrl, string nickname, string avatar, string modelTypeName, string uuid)
        {
            InitializeComponent();


            //模型名称.Text = modelName;
            LoadImageFromUrl(imageUrl, avatar);
            void LoadImageFromUrl(string imageUrl, string avatar)
            {
                //HttpClient client1 = new HttpClient();

                //var imageBytes1 = await client1.GetByteArrayAsync(imageUrl);
                //var image1 = new BitmapImage();
                //image1.BeginInit();
                //image1.CacheOption = BitmapCacheOption.OnLoad;
                //image1.CreateOptions = BitmapCreateOptions.DelayCreation;
                //image1.StreamSource = new MemoryStream(imageBytes1);
                //image1.EndInit();

                // 将图片设置为Image控件的Source
                // 
                try
                {
                    BitmapImage 模型封面图 = new BitmapImage(new Uri(imageUrl));
                    模型封面.ImageSource = 模型封面图;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);//开发中调试窗口

                }

                try
                {
                    BitmapImage 作者头像图 = new BitmapImage(new Uri(avatar));
                    作者头像.ImageSource = 作者头像图;

                }
                catch (
                Exception ex)
                {
                    MessageBox.Show(ex.Message);//开发中调试窗口
                }

            }

            模型名称.Text = modelname;
            模型类型.Text = modelTypeName;
            作者名称.Text = nickname;
            模型_UUID = uuid;
            _nickname = nickname;
            _avatar = avatar;
            _modelType = modelTypeName;
            _imageURL = imageUrl;
        }

        private void _modelCard_Click(object sender, RoutedEventArgs e)
        {


            Model_content model_Content = new Model_content(模型_UUID, _nickname, _avatar, _modelType, _imageURL);//继续传递模型的UUID参数，以便在详情页中继续请求简介/下载地址等
            model_Content.Show();

        }
    }
}
