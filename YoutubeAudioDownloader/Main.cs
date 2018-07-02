using Microsoft.Win32;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoLibrary;

namespace YoutubeAudioDownloader
{
    public partial class Main : Form
    {
        private readonly object SyncRoot = new object();
        private readonly EventWaitHandle waitHandle;
        private bool stopped;
        private int lastMode;
        private DateTime lastUpdated;

        public Main()
        {
            InitializeComponent();
            waitHandle = new EventWaitHandle(false, EventResetMode.AutoReset);
            Thread thread = new Thread(new ThreadStart(Run));
            thread.Start();
            LoadSaveDir();
        }

        private void LoadSaveDir()
        {
            try
            {
                var reg = Registry.CurrentUser.OpenSubKey("Tensiya").OpenSubKey("YoutubeAudioDownloader");
                var val = reg.GetValue("SaveDir") as string;
                textSaveDir.Text = val;
            }
            catch { }
        }

        private void SaveSaveDir(string dir)
        {
            var reg = Registry.CurrentUser.CreateSubKey("Tensiya").CreateSubKey("YoutubeAudioDownloader");
            reg.SetValue("SaveDir", dir);
        }

        private void buttonBrowseSaveDir_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.Description = "저장할 디렉토리 선택";
                fbd.ShowNewFolderButton = true;
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    textSaveDir.Text = fbd.SelectedPath;
                    SaveSaveDir(fbd.SelectedPath);
                }
            }
        }

        private async void buttonDownload_Click(object sender, EventArgs e)
        {
            var url = textDownloadURL.Text;

            var youtube = YouTube.Default;
            buttonDownload.Enabled = false;

            var dir = textSaveDir.Text;
            if (!Directory.Exists(dir))
            {
                try
                {
                    Directory.CreateDirectory(dir);
                }
                catch
                {
                    MessageBox.Show($"{dir}\n\n잘못된 저장 경로 입니다. 경로를 다시 확인하세요.", "URL 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    buttonDownload.Enabled = true;
                    return;
                }
            }

            string name = null;
            try
            {
                var vid = await youtube.GetVideoAsync(url);
                name = vid.FullName;
            } 
            catch { }
            buttonDownload.Enabled = true;


            if (name == null)
            {
                MessageBox.Show($"{url}\n\n잘못된 유튜브 주소입니다.", "URL 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var arr = new string[] { " - YouTube", ".mp4", ".webm", ".flv" };
            foreach (var ar in arr)
                name = name.Replace(ar, "");
            
            lock (SyncRoot)
            {
                listDownloads.Items.Add(new DownloadReservation(textSaveDir.Text, url, name));
                waitHandle.Set();
            }
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            stopped = true;
            waitHandle.Set();
        }

        private void Run()
        {
            while (!stopped)
            {
                waitHandle.WaitOne();
                while (true)
                {
                    DownloadReservation res = null;
                    var a = BeginInvoke(new Action(() => {
                        lock (SyncRoot)
                        {
                            if (listDownloads.Items.Count > 0)
                            {
                                res = (DownloadReservation)listDownloads.Items[0];
                                listDownloads.Items.RemoveAt(0);
                            }
                        }
                    }));
                    a.AsyncWaitHandle.WaitOne();
                    if (res != null)
                    {
                        var downloader = new Downloader();
                        downloader.UpdateEvent += Downloader_UpdateEvent;
                        lastMode = -1;
                        downloader.StartDownload(res);
                        // MessageBox.Show(res.Name + "\n\n" + res.VideoURL);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        private void Downloader_UpdateEvent(object sender, ProgressUpdateEventArgs eventArgs)
        {
            BeginInvoke(new Action(() => {

                var now = DateTime.Now;

                if (lastMode == eventArgs.Mode && lastUpdated.AddMilliseconds(10) > now)
                    return;
                lastMode = eventArgs.Mode;
                lastUpdated = now;

                switch (eventArgs.Mode)
                {
                    case 0:
                        labelCurrentDownload.Text = $"[다운로드중] {eventArgs.DownloadReservation.Name}";
                        break;
                    case 1:
                        labelCurrentDownload.Text = $"[변환중] {eventArgs.DownloadReservation.Name}";
                        break;
                    case 2:
                        labelCurrentDownload.Text = $"[완료] {eventArgs.DownloadReservation.Name}";
                        break;
                }
                
                var max = 10000;
                var min = 0;
                var cur = (int) (eventArgs.Current * 10000L / eventArgs.ContentMax);

                progressDownload.Maximum = max;
                progressDownload.Minimum = min;
                progressDownload.Value = cur;
            }));
        }
    }
}
