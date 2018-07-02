using MediaToolkit;
using MediaToolkit.Model;
using MediaToolkit.Options;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using VideoLibrary;

namespace YoutubeAudioDownloader
{
    public class Downloader
    {
        public delegate void ProgressUpdateCallback(object sender, ProgressUpdateEventArgs eventArgs);

        public event ProgressUpdateCallback UpdateEvent;
        
        public void StartDownload(DownloadReservation download)
        {
            var source = download.SaveDir;
            var youtube = YouTube.Default;
            var vid = youtube.GetVideo(download.VideoURL);

            var tmp = Path.GetTempFileName();
            var name = Path.Combine(source, download.Name);
            var uri = vid.Uri;
            
            var buffer = new byte[8192];
            var cur = 0L;

            var request = (HttpWebRequest)WebRequest.Create(uri);

            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            using (var fs = File.Open(tmp, FileMode.Create))
            {
                var total = response.ContentLength;
                while (true)
                {
                    var r = stream.Read(buffer, 0, 8192);
                    if (r == 0)
                        break;
                    cur += r;
                    fs.Write(buffer, 0, r);
                    UpdateEvent?.Invoke(this, new ProgressUpdateEventArgs(total, cur, 0, download));
                }
            }

            var inputFile = new MediaFile { Filename = tmp };
            var outputFile = new MediaFile { Filename = $"{name}.mp3" };
            var option = new ConversionOptions() { AudioSampleRate = AudioSampleRate.Hz44100 };

            using (var engine = new Engine())
            {
                engine.ConversionCompleteEvent += (s, e) =>
                {
                    File.Delete(tmp);
                };
                engine.ConvertProgressEvent += (s, e) =>
                {
                    var totalTT = e.TotalDuration.TotalMilliseconds;
                    var curTT = e.TotalDuration.TotalMilliseconds / e.ProcessedDuration.TotalMilliseconds;
                    UpdateEvent?.Invoke(this, new ProgressUpdateEventArgs((long)totalTT, (long)curTT, 1, download));
                };
                engine.GetMetadata(inputFile);
                UpdateEvent?.Invoke(this, new ProgressUpdateEventArgs(1, 0, 1, download));
                engine.Convert(inputFile, outputFile, option);
                UpdateEvent?.Invoke(this, new ProgressUpdateEventArgs(1, 1, 1, download));
            }
            UpdateEvent?.Invoke(this, new ProgressUpdateEventArgs(1, 1, 2, download));
        }
    }


    public class ProgressUpdateEventArgs : EventArgs
    {
        public ProgressUpdateEventArgs(long contentMax, long current, int mode, DownloadReservation downloadReservation)
        {
            ContentMax = contentMax;
            Current = current;
            Mode = mode;
            DownloadReservation = downloadReservation;
        }

        public long ContentMax { get; }

        public long Current { get; }

        public int Mode { get; }

        public DownloadReservation DownloadReservation { get; }
    }

    
}
