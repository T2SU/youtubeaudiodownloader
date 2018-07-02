
namespace YoutubeAudioDownloader
{
    public class DownloadReservation
    {
        public DownloadReservation(string saveDir, string videoURL, string name)
        {
            SaveDir = saveDir;
            VideoURL = videoURL;
            Name = name;
            VideoID = URLParser.ExtractVideoID(videoURL);
        }
        public string SaveDir { get; }

        public string VideoURL { get; }

        public string Name { get; }

        public string VideoID { get; }

        public override string ToString()
        {
            return $"{Name} ({VideoID})";
        }
    }
}
