using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AetherLauncher.Frames.Windows
{
   
    public class ApiList
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public string Pass { get; set; }
    }
    /// <summary>
    /// ApiManager.xaml 的交互逻辑
    /// </summary>
    public partial class ApiManager : Window
    {
        
        public List<ApiList> apiList;
        public ObservableCollection<ApiList> apiCollection = new();

        public ApiManager()
        {
            InitializeComponent();
            if (!File.Exists("C:\\aetherlaunther\\apiManager.json"))
            {
                var sw = File.CreateText("C:\\aetherlaunther\\apiManager.json");
                sw.WriteLine("[]");
                sw.Close();
            }
            var jsonOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);
            var jf = File.ReadAllText("C:\\aetherlaunther\\apiManager.json");
            apiList = JsonSerializer.Deserialize<List<ApiList>>(jf, jsonOptions);

            for (int i = 0; i < apiList.Count(); i++)
            {
                apiList[i].Index = i;
                apiCollection.Add(apiList[i]);
            }

            accs.ItemsSource = apiCollection;
        }


        private void 最小化按钮_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void 关闭按钮_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
        private void 顶部栏_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //MainWindow mainWindow = this;
            this.DragMove();
        }

        private void 顶部栏_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }

       
        private void addAcc_Click(object sender, MouseButtonEventArgs e)
        {
            ApiList acc = new ApiList();
            acc.Name = username.Text;
            acc.Pass = pass.Text;
            apiList.Add(acc);

            var jsonOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);
            byte[] jsonbyte = JsonSerializer.SerializeToUtf8Bytes(apiList, jsonOptions);
            File.WriteAllBytes("C:\\aetherlaunther\\apiManager.json", jsonbyte);

            apiCollection.Clear();
            var jf = File.ReadAllText("C:\\aetherlaunther\\apiManager.json");
            apiList = JsonSerializer.Deserialize<List<ApiList>>(jf, jsonOptions);

            for (int i = 0; i < apiList.Count(); i++)
            {
                apiList[i].Index = i;
                apiCollection.Add(apiList[i]);
            }

            accs.ItemsSource = apiCollection;
        }
        private void delAcc_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button btn = (System.Windows.Controls.Button)sender;
            int idx = (int)btn.Tag;

            apiList.RemoveAt(idx);
            var jsonOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);
            byte[] jsonbyte = JsonSerializer.SerializeToUtf8Bytes(apiList, jsonOptions);
            File.WriteAllBytes("apiManager.json", jsonbyte);

            apiCollection.Clear();
            var jf = File.ReadAllText("C:\\aetherlaunther\\apiManager.json");
            apiList = JsonSerializer.Deserialize<List<ApiList>>(jf, jsonOptions);

            for (int i = 0; i < apiList.Count(); i++)
            {
                apiList[i].Index = i;
                apiCollection.Add(apiList[i]);
            }

            accs.ItemsSource = apiCollection;
        }

    }

}
