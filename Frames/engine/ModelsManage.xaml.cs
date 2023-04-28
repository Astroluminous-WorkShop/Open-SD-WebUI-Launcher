using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
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
using static AetherLauncher.MainWindow;
using static AetherLauncher.initialize;
using Wpf.Ui.Controls;
using static AetherLauncher.Frames.Page4;

namespace AetherLauncher.Frames.engine
{
    /// <summary>
    /// ModelsManage.xaml 的交互逻辑
    /// </summary>
    public partial class ModelsManage
    {
        //public ObservableCollection<Embedding> HysCollection = new();
        //public ObservableCollection<Embedding> EmbCollection = new();
        //public ObservableCollection<CheckPoint> CksCollection = new();
        //public ObservableCollection<CheckPoint> CksOnlineCollection = new();
        //public ObservableCollection<CheckPoint> VaesCollection = new();
        //public ObservableCollection<CheckPoint> VaesOnlineCollection = new();
        //public ObservableCollection<CheckPoint> LorasCollection = new();

        //public ModelsManage()
        //{
        //    InitializeComponent();
        //    CheckStartPathFile();
        //}
        //private void ckptOnline_Uncheck(object sender, RoutedEventArgs e)
        //{
        //    var jsonOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);
        //    var jf = File.ReadAllText(@"ckpts.json");
        //    List<CheckPointOnline> ckpts = JsonSerializer.Deserialize<List<CheckPointOnline>>(jf, jsonOptions);

        //    for (int i = 0; i < ckpts.Count(); i++)
        //    {
        //        for (int j = 0; j < CksCollection.Count(); j++)
        //        {
        //            if (ckpts[i].Name == CksCollection[j].Name)
        //            {
        //                CksCollection.RemoveAt(j);
        //            }
        //        }
        //    }
        //}
        //private void ckptOnline_Click(object sender, EventArgs e)
        //{
        //    var jsonOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);
        //    var jf = File.ReadAllText(@"ckpts.json");
        //    List<CheckPointOnline> ckpts = JsonSerializer.Deserialize<List<CheckPointOnline>>(jf, jsonOptions);

        //    for (int i = 0; i < ckpts.Count(); i++)
        //    {
        //        bool hasExist = false;
        //        for (int j = 0; j < CksCollection.Count(); j++)
        //        {
        //            if (ckpts[i].Name == CksCollection[j].Name)
        //            {
        //                hasExist = true;
        //            }
        //        }
        //        if (hasExist == false)
        //        {
        //            CheckPoint ck = new CheckPoint();
        //            ck.Name = ckpts[i].Name;
        //            ck.Desc = ckpts[i].Desc;
        //            ck.URL = ckpts[i].Url;
        //            ck.isLocal = false;
        //            ck.isRemote = true;
        //            CksCollection.Add(ck);
        //        }
        //    }
        //}
        //private void ckptLocal_Uncheck(object sender, RoutedEventArgs e)
        //{
        //    for (int j = 0; j < CksCollection.Count(); j++)
        //    {
        //        if (CksCollection[j].isLocal)
        //        {
        //            CksCollection.RemoveAt(j);
        //        }
        //    }
        //}

        //private void VAEOnline_Uncheck(object sender, RoutedEventArgs e)
        //{
        //    var jsonOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);
        //    var jf = File.ReadAllText(@"vaes.json");
        //    List<CheckPointOnline> ckpts = JsonSerializer.Deserialize<List<CheckPointOnline>>(jf, jsonOptions);

        //    for (int i = 0; i < ckpts.Count(); i++)
        //    {
        //        for (int j = 0; j < VaesCollection.Count(); j++)
        //        {
        //            if (ckpts[i].Name == VaesCollection[j].Name)
        //            {
        //                VaesCollection.RemoveAt(j);
        //            }
        //        }
        //    }
        //}
        //private void VAEOnline_Click(object sender, EventArgs e)
        //{
        //    var jsonOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);
        //    var jf = File.ReadAllText(@"vaes.json");
        //    List<CheckPointOnline> ckpts = JsonSerializer.Deserialize<List<CheckPointOnline>>(jf, jsonOptions);

        //    for (int i = 0; i < ckpts.Count(); i++)
        //    {
        //        bool hasExist = false;
        //        for (int j = 0; j < VaesCollection.Count(); j++)
        //        {
        //            if (ckpts[i].Name == VaesCollection[j].Name)
        //            {
        //                hasExist = true;
        //            }
        //        }
        //        if (hasExist == false)
        //        {
        //            CheckPoint ck = new CheckPoint();
        //            ck.Name = ckpts[i].Name;
        //            ck.Desc = ckpts[i].Desc;
        //            ck.URL = ckpts[i].Url;
        //            ck.isLocal = false;
        //            ck.isRemote = true;

        //            VaesCollection.Add(ck);
        //        }
        //    }
        //    vaes.ItemsSource = VaesCollection;
        //}
        //private void VAELocal_Uncheck(object sender, RoutedEventArgs e)
        //{
        //    for (int j = 0; j < VaesCollection.Count(); j++)
        //    {
        //        if (VaesCollection[j].isLocal)
        //        {
        //            VaesCollection.RemoveAt(j);
        //        }
        //    }
        //}
        //private void VAEDownload_Click(object sender, RoutedEventArgs e)
        //{
        //    System.Windows.Controls.Button btn = (System.Windows.Controls.Button)sender;
        //    var http_url = btn.Tag.ToString();
        //    var save = 启动路径 + "\\models\\vae\\" + http_url.Split("/")[http_url.Split("/").Length - 1]; ;

        //    WebResponse response = null;
        //    WebRequest request = WebRequest.Create(http_url);
        //    response = request.GetResponse();
        //    if (response == null) return;
        //    pbDown.Maximum = response.ContentLength;
        //    ThreadPool.QueueUserWorkItem((obj) =>
        //    {
        //        Stream netStream = response.GetResponseStream();
        //        Stream fileStream = new FileStream(save, FileMode.Create);
        //        byte[] read = new byte[1024];
        //        long progressBarValue = 0;
        //        int realReadLen = netStream.Read(read, 0, read.Length);
        //        while (realReadLen > 0)
        //        {
        //            fileStream.Write(read, 0, realReadLen);
        //            progressBarValue += realReadLen;
        //            pbDownVae.Dispatcher.BeginInvoke(new ProgressBarSetter(SetProgressBar2), progressBarValue);
        //            realReadLen = netStream.Read(read, 0, read.Length);
        //        }
        //        netStream.Close();
        //        fileStream.Close();
        //    }, null);
        //}
        //private void Download_Click(object sender, RoutedEventArgs e)
        //{
        //    System.Windows.Controls.Button btn = (System.Windows.Controls.Button)sender;
        //    var http_url = btn.Tag.ToString();
        //    //var http_url = "https://huggingface.co/runwayml/stable-diffusion-v1-5/resolve/main/v1-5-pruned-emaonly.safetensors";
        //    var save = 启动路径 + "\\models\\stable-diffusion" + http_url.Split("/")[http_url.Split("/").Length - 1]; ;

        //    WebResponse response = null;
        //    WebRequest request = WebRequest.Create(http_url);
        //    response = request.GetResponse();
        //    if (response == null) return;
        //    pbDown.Maximum = response.ContentLength;
        //    ThreadPool.QueueUserWorkItem((obj) =>
        //    {
        //        Stream netStream = response.GetResponseStream();
        //        Stream fileStream = new FileStream(save, FileMode.Create);
        //        byte[] read = new byte[1024];
        //        long progressBarValue = 0;
        //        int realReadLen = netStream.Read(read, 0, read.Length);
        //        while (realReadLen > 0)
        //        {
        //            fileStream.Write(read, 0, realReadLen);
        //            progressBarValue += realReadLen;
        //            pbDown.Dispatcher.BeginInvoke(new ProgressBarSetter(SetProgressBar), progressBarValue);
        //            realReadLen = netStream.Read(read, 0, read.Length);
        //        }
        //        netStream.Close();
        //        fileStream.Close();
        //    }, null);
        //}
        //public delegate void ProgressBarSetter(double value);
        //public void SetProgressBar(double value)
        //{
        //    //显示进度条
        //    pbDown.Value = value;
        //    //显示百分比
        //    label1.Content = (value / pbDown.Maximum) * 100 + "%";
        //}
        //public void SetProgressBar2(double value)
        //{
        //    //显示进度条
        //    pbDownVae.Value = value;
        //    //显示百分比
        //    labelVae.Content = (value / pbDown.Maximum) * 100 + "%";
        //}
        //private void ckptLocal_Click(object sender, EventArgs e)
        //{
        //    SD_CKPT_Info();
        //}
        //private void VAELocal_Click(object sender, EventArgs e)
        //{
        //    //VaesCollection.Clear();
        //    //var dir = new DirectoryInfo("..\\models\\vae");
        //    //FileInfo[] files = dir.GetFiles();

        //    //foreach (FileInfo fInfo in files)
        //    //{
        //    //    if (fInfo.Extension != ".ckpt" && fInfo.Extension != ".safetensors") continue;

        //    //    DateTime date = fInfo.CreationTime;
        //    //    FileStream fileStream = fInfo.Open(FileMode.Open, FileAccess.Read);
        //    //    fileStream.Position = 0;
        //    //    fileStream.Close();

        //    //    CheckPoint ck = new CheckPoint();
        //    //    ck.Name = fInfo.Name;
        //    //    ck.Date = date;
        //    //    ck.Size = fInfo.Length / 1024;

        //    //    VaesCollection.Add(ck);
        //    //}

        //    //vaes.ItemsSource = VaesCollection;
        //}
        //private void OpenCkpt_Click(object sender, EventArgs e)
        //{
        //    Process.Start("Explorer.exe",
        //        启动路径 + "\\models\\stable-diffusion");
        //}
        //private void OpenVAE_Click(object sender, RoutedEventArgs e)
        //{
        //    Process.Start("Explorer.exe",
        //       启动路径 + "\\models\\vae");
        //}
        //private void OpenEmb_Click(object sender, RoutedEventArgs e)
        //{
        //    Process.Start("Explorer.exe",
        //       启动路径 + "\\embeddings");
        //}
        //private void OpenHys_Click(object sender, RoutedEventArgs e)
        //{
        //    Process.Start("Explorer.exe",
        //       启动路径 + "\\models\\hypernetworks");
        //}
        //private void OpenLoRA_Click(object sender, RoutedEventArgs e)
        //{
        //    Process.Start("Explorer.exe",
        //       启动路径 + "\\models\\lora");
        //}
        //private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (e.Source is TabControl)
        //    {
        //        Debug.WriteLine(tabs.SelectedIndex);
        //        if (tabs.SelectedIndex == 0)
        //        {
        //            CksCollection.Clear();

        //            SD_CKPT_Info();

        //            cks.ItemsSource = CksCollection;
        //        }
        //        else if (tabs.SelectedIndex == 1)
        //        {
        //            EmbCollection.Clear();
        //            var dir = new DirectoryInfo(启动路径 + "\\embeddings");
        //            FileInfo[] files = dir.GetFiles();

        //            foreach (FileInfo fInfo in files)
        //            {
        //                if (fInfo.Extension != ".pt" && fInfo.Extension != ".safetensors") continue;

        //                DateTime date = fInfo.CreationTime;
        //                FileStream fileStream = fInfo.Open(FileMode.Open, FileAccess.Read);
        //                fileStream.Position = 0;
        //                fileStream.Close();

        //                Embedding ck = new Embedding();
        //                ck.Name = fInfo.Name;
        //                ck.Date = date;
        //                ck.Size = fInfo.Length / 1024;

        //                EmbCollection.Add(ck);
        //            }

        //            embs.ItemsSource = EmbCollection;
        //        }
        //        else if (tabs.SelectedIndex == 2)
        //        {
        //            HysCollection.Clear();
        //            var dir = new DirectoryInfo(启动路径 + "\\models\\hypernetworks");
        //            FileInfo[] files = dir.GetFiles();

        //            foreach (FileInfo fInfo in files)
        //            {
        //                if (fInfo.Extension != ".pt" && fInfo.Extension != ".safetensors") continue;

        //                DateTime date = fInfo.CreationTime;
        //                FileStream fileStream = fInfo.Open(FileMode.Open, FileAccess.Read);
        //                fileStream.Position = 0;
        //                fileStream.Close();

        //                Embedding ck = new Embedding();
        //                ck.Name = fInfo.Name;
        //                ck.Date = date;
        //                ck.Size = fInfo.Length / 1024;

        //                HysCollection.Add(ck);
        //            }

        //            hys.ItemsSource = HysCollection;
        //        }
        //        else if (tabs.SelectedIndex == 3)
        //        {
        //            VaesCollection.Clear();
        //            var dir = new DirectoryInfo(启动路径 + "\\models\\vae");
        //            FileInfo[] files = dir.GetFiles();

        //            foreach (FileInfo fInfo in files)
        //            {
        //                if (fInfo.Extension != ".ckpt" && fInfo.Extension != ".safetensors") continue;

        //                DateTime date = fInfo.CreationTime;
        //                FileStream fileStream = fInfo.Open(FileMode.Open, FileAccess.Read);
        //                fileStream.Position = 0;
        //                fileStream.Close();

        //                CheckPoint ck = new CheckPoint();
        //                ck.Name = fInfo.Name;
        //                ck.Date = date;
        //                ck.Size = fInfo.Length / 1024 / 1024;

        //                VaesCollection.Add(ck);
        //            }

        //            vaes.ItemsSource = VaesCollection;
        //        }
        //        else if (tabs.SelectedIndex == 4)
        //        {
        //            LorasCollection.Clear();
        //            var dir = new DirectoryInfo(启动路径 + "\\models\\lora");
        //            FileInfo[] files = dir.GetFiles();

        //            foreach (FileInfo fInfo in files)
        //            {
        //                if (fInfo.Extension != ".ckpt" && fInfo.Extension != ".safetensors") continue;

        //                DateTime date = fInfo.CreationTime;
        //                FileStream fileStream = fInfo.Open(FileMode.Open, FileAccess.Read);
        //                fileStream.Position = 0;
        //                fileStream.Close();

        //                CheckPoint ck = new CheckPoint();
        //                ck.Name = fInfo.Name;
        //                ck.Date = date;
        //                ck.Size = fInfo.Length / 1024 / 1024;

        //                LorasCollection.Add(ck);
        //            }

        //            loras.ItemsSource = LorasCollection;
        //        }
        //    }
        //}
        //public void SD_CKPT_Info()
        //{

        //    string filePath = @"C:\aetherlaunther\startpath.txt";
        //    if (File.Exists(filePath))
        //    {
        //        // 如果文件存在，读取其中的内容到startpath全局变量中
        //        启动路径 = File.ReadAllText(filePath);

        //    }
        //    var dir1 = new DirectoryInfo(启动路径 + @"\models\stable-diffusion");
        //     FileInfo[] files = dir1.GetFiles(); 
        //    using (SHA256 mySHA256 = SHA256.Create())
        //    {
        //        int idx = 0;
        //        try
        //        {

        //            foreach (FileInfo fInfo in files)
        //            {
        //                try
        //                {
        //                    if (fInfo.Extension != ".ckpt" && fInfo.Extension != ".safetensors") continue;

        //                    DateTime date = fInfo.CreationTime;
        //                    FileStream fileStream = fInfo.Open(FileMode.Open, FileAccess.Read);
        //                    fileStream.Position = 0;
        //                    //计算fileStream的hash。
        //                    //byte[] hashValue = mySHA256.ComputeHash(fileStream);

        //                    //// 将文件的名称和散列值写入控制台。
        //                    ////Console.Write($"{fInfo.Name}: ");
        //                    ////PrintByteArray(hashValue);
        //                    //string shorthash = "";
        //                    //for (int i = 0; i < 5; i++)
        //                    //{
        //                    //    shorthash += $"{hashValue[i]:X2}";
        //                    //}
        //                    //Debug.WriteLine(shorthash);
        //                    fileStream.Close();

        //                    CheckPoint ck = new CheckPoint();
        //                    ck.Name = fInfo.Name;
        //                    ck.ShortHash = "";
        //                    ck.Date = date;
        //                    ck.Index = idx++;
        //                    ck.isLocal = true;
        //                    ck.isRemote = false;
        //                    ck.Size = fInfo.Length / 1024 / 1024;

        //                    CksCollection.Add(ck);
        //                }
        //                catch (IOException e)
        //                {
        //                    Debug.WriteLine($"I/O Exception: {e.Message}");
        //                }
        //                catch (UnauthorizedAccessException e)
        //                {
        //                    Debug.WriteLine($"Access Exception: {e.Message}");
        //                }
        //            }
        //        }
        //        catch
        //        {

        //        }
        //    }
        //}
        //public class CheckPoint
        //{
        //    public int Index { get; set; }
        //    public string Name { get; set; }
        //    public string Desc { get; set; }
        //    public long Size { get; set; }
        //    public DateTime Date { get; set; }
        //    public string URL { get; set; }
        //    public string ShortHash { get; set; }
        //    public bool isLocal { get; set; }
        //    public bool isRemote { get; set; }
        //}
        //public class CheckPointOnline
        //{
        //    public string Name { get; set; }
        //    public string Desc { get; set; }
        //    public string Hash { get; set; }
        //    public string Url { get; set; }
        //}
        //public class Embedding
        //{
        //    public string Name { get; set; }
        //    public string Desc { get; set; }
        //    public long Size { get; set; }
        //    public DateTime Date { get; set; }
        //}
        //public static void PrintByteArray(byte[] array)
        //{
        //    for (int i = 0; i < array.Length; i++)
        //    {
        //        Debug.Write($"{array[i]:X2}");
        //        if ((i % 4) == 3) Debug.Write(" ");
        //    }
        //    Debug.WriteLine("");
        //}

       
    }
}
