using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Numerics;
using System.Runtime.InteropServices;
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
using System.Xml.Linq;
using Wpf.Ui.Appearance;
using Wpf.Ui.Controls;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace 光源AI绘画盒子.Views.Windows
{
    /// <summary>
    /// model_content.xaml 的交互逻辑
    /// </summary>
    public partial class Model_content

    {
        string _UUID = "";
        string _模型名称 = "";
        string _模型封面地址 = "";
        string _模型作者名称 = "";
        string _模型作者头像地址 = "";
        string _模型种类名称 = "";

        string _modelType = "";
        string _modelname = "";
        string _modelVersionId = "";
        string _modelSource = "";
        string _modelSourceName = "";
        string _modelSourceSize = "";
        string _modelSourceHash = "";
        public Model_content(string uuid, string nickname, string avatar, string modelType, string imageURL)
        {
            InitializeComponent();
            if (initialize.背景颜色 == "Mica")
            {

                modelwindow.WindowBackdropType = BackgroundType.Mica;
                主题背景图.Opacity = 0;


            }
            if (initialize.背景颜色 == "Acrylic")
            {
                modelwindow.WindowBackdropType = BackgroundType.Acrylic;
                主题背景图.Opacity = 0;

            }
            if (initialize.背景颜色 == "Tabbed")
            {
                modelwindow.WindowBackdropType = BackgroundType.Tabbed;
                主题背景图.Opacity = 0;

            }
            if (initialize.背景颜色 == "Auto")
            {
                modelwindow.WindowBackdropType = BackgroundType.Auto;
                主题背景图.Opacity = 0;

            }
            if (initialize.背景颜色 == "None")
            {
                modelwindow.WindowBackdropType = BackgroundType.None;
                主题背景图.Opacity = 0;

            }
            if (initialize.背景颜色 == "Picture")
            {




                图片亮度.Value = initialize.背景亮度;
                主题背景图.Opacity = 图片亮度.Value / 100;
                string imagepath = initialize.背景图片; // 获取选择的文件路径+文件名  
                ImageSource imageSource = new BitmapImage(new Uri(imagepath)); // 设置Image的ImageSource为选择的图片  
                主题背景图.ImageSource = imageSource; // 将选择的图片显示在Image控件中  


            }
            //从拿到的UUID创建post请求
            _UUID = uuid;
            _模型作者名称 = nickname;
            _模型封面地址 = imageURL;
            _模型作者头像地址 = avatar;
            _模型种类名称 = modelType;
            _modelType = modelType;
            作者名称.Text = "模型作者：" + _模型作者名称;
            模型类型.Text = "模型类型：" + _模型种类名称;
            _GetModelDetals(_UUID);//开始执行异步任务
            LoadImageFromUrl(imageURL, avatar);
        }
        void LoadImageFromUrl(string imageUrl, string avatar)//开始加载模型封面图和作者头像
        {
            try
            {
                BitmapImage 模型封面图 = new BitmapImage(new Uri(imageUrl));
                模型封面.ImageSource = 模型封面图;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);//开发中调试窗口
            }
            try
            {
                BitmapImage 作者头像图 = new BitmapImage(new Uri(avatar));
                作者头像.ImageSource = 作者头像图;
            }
            catch (
            Exception ex)
            {

            }
        }
        async Task _GetModelDetals(string uuid)
        {
            try//避免404等情况崩掉，顺便catch error
            {
                string _Uri = "https://liblib-api.vibrou.com/api/www/model/getByUuid/" + uuid;
                var client = new HttpClient();
                var request = new HttpRequestMessage();
                request.RequestUri = new Uri(_Uri);
                request.Method = HttpMethod.Post;

                request.Headers.Add("Accept", "*/*");
                request.Headers.Add("User-Agent", "Open-SD-WebUI-Launcher");

                var response = await client.SendAsync(request);
                var result = await response.Content.ReadAsStringAsync();
                //返回值.Text = result;

                //开始解析返回值
                var JObjectlist = JObject.Parse(result)["data"] as JObject;//这个用来读取模型的一些基础信息
                _模型名称 = JObjectlist["name"].ToString();

                模型名称.Text = _模型名称.ToString();
                string 模型富文本简介内容 = JObjectlist["remark"].ToString();
                string utf8text = "meta charset =\"UTF-8\"";//使用UTF8格式化富文本
                string htmlContent = "<" + utf8text + ">" + 模型富文本简介内容;
                富文本简介.Source = new Uri("data:text/html," + htmlContent);


                //开始解析模型的版本有多少个，并分别展示
                var JArraylist = JObject.Parse(result)["data"]["versions"] as JArray;//这个用来解析模型的多个版本

                string json = JArraylist.ToString();

                List<Dictionary<string, object>> infolist = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(json);
                try
                {
                    for (int i = 0; i < infolist.Count; i++)
                    {

                        _modelname = infolist[i]["name"].ToString();

                        string _Attachment = infolist[i]["attachment"].ToString();//这是一个嵌套的{}对象，这样解析


                        var JObjectlist3 = JObject.Parse(_Attachment) as JObject;//这个用来读取模型的一些基础信息
                        _modelVersionId = JObjectlist3["modelVersionId"].ToString();
                        _modelSourceName = JObjectlist3["modelSourceName"].ToString();
                        _modelSource = JObjectlist3["modelSource"].ToString();
                        string size = JObjectlist3["modelSourceSize"].ToString();
                        BigInteger numsize = BigInteger.Parse(size) / 64 / 64 / 64 / 4;//单位化为MB
                        _modelSourceSize = numsize.ToString();
                        _modelSourceHash = JObjectlist3["modelSourceHash"].ToString();
                        model_download_list model_Download_List = new model_download_list(_UUID, _模型名称, _modelname, _modelVersionId, _modelSourceName, _modelSource, _modelSourceSize, _modelSourceHash, _modelType);
                        模型下载列表.Children.Add(model_Download_List);
                    }
                }
                catch (Exception ex)
                {
                    报错指示器.Visibility = Visibility.Visible;
                    报错指示器.Text = "该模型下载未开放";

                }









            }
            catch (Exception ex)//捕获异常拿去调试或者控制404一类的UI动画逻辑
            {
                System.Windows.MessageBox.Show(ex.Message);//开发中调试窗口
            }
        }


    }
}
