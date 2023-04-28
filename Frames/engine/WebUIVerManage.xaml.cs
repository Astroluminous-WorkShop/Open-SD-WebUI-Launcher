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
using System.Windows.Navigation;
using System.Windows.Shapes;
using AetherLauncher.Frames.Windows;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text.Json;
using Win32Interop.Structs;
using static AetherLauncher.initialize;
using System.IO;

using Wpf.Ui.Common.Interfaces;
namespace AetherLauncher.Frames.engine
{
    /// <summary>
    /// WebUIVerManage.xaml 的交互逻辑
    /// </summary>
    public partial class WebUIVerManage
    {
        public struct CommitItem
        {
            public int Id { get; set; }
            public string Hash { get; set; }
            public string Message { get; set; }
            public string Date { get; set; }
            public string Tag { get; set; }

            public bool Enable { get; set; }

            public bool Checked { get; set; }

        }
        //public string currHash;
        //public List<TagItem> tags;
        //public List<CommitItem> commits;
        //public ObservableCollection<CommitItem> CommiteCollection = new();
        //public ObservableCollection<CommitItem> CommiteTagCollection = new();


        public WebUIVerManage()
        {
            //Process process = new Process();
            //ProcessStartInfo startInfo = new ProcessStartInfo();
            //startInfo.FileName = @"powershell.exe";
            //startInfo.Arguments = " -c \"git\\bin\\git.exe log --oneline --pretty='%h^^%s^^%cd' --date=\"short\" -n 1\"";
            //startInfo.UseShellExecute = false;
            //startInfo.RedirectStandardOutput = true;
            //startInfo.RedirectStandardError = false;
            //startInfo.CreateNoWindow = true;
            //startInfo.WorkingDirectory = "..\\";

            //process.StartInfo = startInfo;
            //process.Start();
            //process.WaitForExit();

            //string msg = process.StandardOutput.ReadToEnd();
            //currHash = msg.Split("^^")[0];

            //process = new Process();
            //startInfo = new ProcessStartInfo();
            //startInfo.FileName = @"powershell.exe";
            //startInfo.Arguments = " -c \"git\\bin\\git.exe remote -v";
            //startInfo.UseShellExecute = false;
            //startInfo.RedirectStandardOutput = true;
            //startInfo.RedirectStandardError = false;
            //startInfo.CreateNoWindow = true;
            //startInfo.WorkingDirectory = "..\\";

            //process.StartInfo = startInfo;
            //process.Start();
            //process.WaitForExit();

            //string msg2 = process.StandardOutput.ReadToEnd();

        
            InitializeComponent();

            //lblCurrHash.Content = currHash;
            //lblCurrDate.Content = msg.Split("^^")[2];
            //lblCurrMessage.Content = msg.Split("^^")[1];
            //lblCurrGit.Content = msg2.Split("\\n")[0].Split(" ")[0];

            //commit.ItemsSource = CommiteCollection;
            //commit2.ItemsSource = tags;
        }
        //private void InitializeData()
        //{
        //    if (!File.Exists("codetag.json"))
        //    {
        //        var sw = File.CreateText("codetag.json");
        //        sw.WriteLine("[]");
        //        sw.Close();
        //    }
        //    var jsonOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);
        //    var jf = File.ReadAllText("codetag.json");
        //    tags = JsonSerializer.Deserialize<List<TagItem>>(jf, jsonOptions);

        //    Process process = new Process();
        //    ProcessStartInfo startInfo = new ProcessStartInfo();
        //    startInfo.FileName = @"powershell.exe";
        //    startInfo.Arguments = " -c \"git\\bin\\git.exe --no-pager log origin/master --pretty='%h^^%s^^%cd' --date=\"short\" -n 1000\"";
        //    startInfo.UseShellExecute = false;
        //    startInfo.RedirectStandardOutput = true;
        //    startInfo.RedirectStandardError = true;
        //    startInfo.CreateNoWindow = true;
        //    startInfo.WorkingDirectory = "..\\";

        //    process.StartInfo = startInfo;

        //    int idx = 0;
        //    commits = new List<CommitItem>();
        //    process.ErrorDataReceived += new DataReceivedEventHandler(delegate (object sender, DataReceivedEventArgs e)
        //    {

        //    });
        //    process.OutputDataReceived += new DataReceivedEventHandler(delegate (object sender, DataReceivedEventArgs e)
        //    {
        //        if (e.Data == null) return;
        //        CommitItem item1 = new CommitItem();
        //        string[] itemarr = e.Data.Split("^^");
        //        if (itemarr.Length < 3)
        //        {
        //            return;
        //        }
        //        item1.Hash = itemarr[0];
        //        item1.Message = itemarr[1];
        //        item1.Date = itemarr[2];
        //        item1.Id = idx++;
        //        item1.Enable = true;
        //        item1.Checked = false;

        //        for (int j = 0; j < tags.Count(); j++)
        //        {
        //            if (item1.Hash == tags[j].Hash)
        //            {
        //                item1.Tag = tags[j].Tag;
        //            }
        //        }

        //        if (currHash == item1.Hash)
        //        {
        //            item1.Enable = false;
        //            item1.Checked = true;
        //        }

        //        commits.Add(item1);
        //    });

        //    process.Start();
        //    process.BeginErrorReadLine();
        //    process.BeginOutputReadLine();
        //    process.WaitForExit();

        //    for (int i = 0; i < commits.Count(); i++)
        //    {
        //        CommiteCollection.Add(commits[i]);
        //    }
        //}
        //private void setup_Click(object sender, RoutedEventArgs e)
        //{
        //    Button btn = (Button)sender;
        //    string hash = btn.Tag.ToString();

        //    Process process = new Process();
        //    ProcessStartInfo startInfo = new ProcessStartInfo();
        //    startInfo.FileName = @"powershell.exe";
        //    startInfo.Arguments = " -c \"git\\bin\\git.exe reset --hard; git\\bin\\git.exe checkout " + hash;
        //    startInfo.UseShellExecute = false;
        //    startInfo.RedirectStandardOutput = true;
        //    startInfo.CreateNoWindow = true;
        //    startInfo.WorkingDirectory = "..\\";

        //    process.StartInfo = startInfo;
        //    process.Start();
        //    process.WaitForExit();

        //    string msg = process.StandardOutput.ReadToEnd();
        //    Debug.WriteLine(msg);

        //    CommiteCollection.Clear();
        //    CommiteTagCollection.Clear();

        //    process = new Process();
        //    startInfo = new ProcessStartInfo();
        //    startInfo.FileName = @"powershell.exe";
        //    startInfo.Arguments = " -c \"git\\bin\\git.exe log --oneline --pretty='%h^^%s^^%cd' --date=\"short\" -n 1\"";
        //    startInfo.UseShellExecute = false;
        //    startInfo.RedirectStandardOutput = true;
        //    startInfo.RedirectStandardError = false;
        //    startInfo.CreateNoWindow = true;
        //    startInfo.WorkingDirectory = "..\\";

        //    process.StartInfo = startInfo;
        //    process.Start();
        //    process.WaitForExit();

        //    msg = process.StandardOutput.ReadToEnd();
        //    currHash = msg.Split("^^")[0];

        //    process = new Process();
        //    startInfo = new ProcessStartInfo();
        //    startInfo.FileName = @"powershell.exe";
        //    startInfo.Arguments = " -c \"git\\bin\\git.exe remote -v";
        //    startInfo.UseShellExecute = false;
        //    startInfo.RedirectStandardOutput = true;
        //    startInfo.RedirectStandardError = false;
        //    startInfo.CreateNoWindow = true;
        //    startInfo.WorkingDirectory = "..\\";

        //    process.StartInfo = startInfo;
        //    process.Start();
        //    process.WaitForExit();

        //    string msg2 = process.StandardOutput.ReadToEnd();

        //    InitializeData();

        //    lblCurrHash.Content = currHash;
        //    lblCurrDate.Content = msg.Split("^^")[2];
        //    lblCurrMessage.Content = msg.Split("^^")[1];
        //    lblCurrGit.Content = msg2.Split("\\n")[0].Split(" ")[0];

        //    commit.ItemsSource = CommiteCollection;
        //    commit2.ItemsSource = tags;
        //}
        //private void tag_Click(object sender, RoutedEventArgs e)
        //{
        //    Button btn = (Button)sender;
        //    int Id = int.Parse(btn.Tag.ToString());

        //    TagInput tag1 = new TagInput();
        //    bool? dialogResult = tag1.ShowDialog();

        //    switch (dialogResult)
        //    {
        //        case true:
        //            var jsonOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);
        //            byte[] jsonbyte;
        //            for (int i = 0; i < tags.Count(); i++)
        //            {
        //                if (tags[i].Hash == CommiteCollection[Id].Hash)
        //                {
        //                    tags[i].Tag = tag1.tag;
        //                    tags[i].Hash = CommiteCollection[Id].Hash;
        //                    tags[i].Message = CommiteCollection[Id].Message;
        //                    tags[i].Date = CommiteCollection[Id].Date;

        //                    jsonbyte = JsonSerializer.SerializeToUtf8Bytes(tags, jsonOptions);
        //                    File.WriteAllBytes("codetag.json", jsonbyte);

        //                    CommiteCollection.Clear();
        //                    CommiteTagCollection.Clear();

        //                    InitializeData();

        //                    commit.ItemsSource = CommiteCollection;
        //                    commit2.ItemsSource = tags;
        //                    return;
        //                }
        //            }

        //            TagItem ti = new TagItem();
        //            ti.Tag = tag1.tag;
        //            ti.Hash = CommiteCollection[Id].Hash;
        //            ti.Message = CommiteCollection[Id].Message;
        //            ti.Date = CommiteCollection[Id].Date;

        //            tags.Add(ti);
        //            jsonbyte = JsonSerializer.SerializeToUtf8Bytes(tags, jsonOptions);
        //            File.WriteAllBytes("codetag.json", jsonbyte);

        //            CommiteCollection.Clear();
        //            CommiteTagCollection.Clear();

        //            InitializeData();

        //            commit.ItemsSource = CommiteCollection;
        //            commit2.ItemsSource = tags;
        //            break;
        //        case false:
        //            // User canceled dialog box
        //            break;
        //        default:
        //            // Indeterminate
        //            break;
        //    }
        //}
        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    Process.Start("Explorer.exe", 启动路径);
        //}
        //private void UpdateCode_Click(object sender, RoutedEventArgs e)
        //{
        //    Process process = new Process();
        //    ProcessStartInfo startInfo = new ProcessStartInfo();
        //    startInfo.FileName = @"powershell.exe";
        //    startInfo.Arguments = " -c \"git\\bin\\git.exe remote update ; git\\bin\\git.exe status -uno";
        //    startInfo.UseShellExecute = false;
        //    startInfo.RedirectStandardOutput = true;
        //    startInfo.CreateNoWindow = true;
        //    startInfo.WorkingDirectory = "..\\";

        //    process.StartInfo = startInfo;
        //    process.Start();
        //    process.WaitForExit();

        //    string msg = process.StandardOutput.ReadToEnd();
        //    Debug.WriteLine(msg);
        //    if (msg.Contains("Your branch is behind"))
        //    {
        //        MessageBoxResult result = MessageBox.Show("代码需要更新！", "消息", MessageBoxButton.YesNo);
        //        if (result == MessageBoxResult.Yes)
        //        {
        //            Process process2 = new Process();
        //            ProcessStartInfo startInfo2 = new ProcessStartInfo();
        //            startInfo2.FileName = @"powershell.exe";
        //            startInfo2.Arguments = " -c \"git\\bin\\git.exe pull origin master";
        //            startInfo2.UseShellExecute = false;
        //            startInfo2.RedirectStandardOutput = true;
        //            startInfo2.CreateNoWindow = true;
        //            startInfo2.WorkingDirectory = "..\\";

        //            process2.StartInfo = startInfo2;
        //            process2.Start();
        //            process2.WaitForExit();

        //            CommiteCollection.Clear();
        //            CommiteTagCollection.Clear();

        //            InitializeData();

        //            commit.ItemsSource = CommiteCollection;
        //            commit2.ItemsSource = tags;
        //        }

        //    }
        //    else
        //    {
        //        MessageBox.Show("代码已经是最新的！");
        //    }
        //}


    }
    //public class TagItem
    //{
    //    public string Hash { get; set; }

    //    public string Message { get; set; }

    //    public string Date { get; set; }

    //    public string Tag { get; set; }
    //}

}
