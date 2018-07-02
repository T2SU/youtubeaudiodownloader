using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace YoutubeAudioDownloader
{
    public static class URLParser
    {
        private static readonly Regex regex;

        static URLParser()
        {
            regex = new Regex(@"(?i)(?:http)(?i)s?:\/\/(?:www\.)?youtube(?:-nocookie)?\.com\/(?:watch)?\?.*?v=(.+)", RegexOptions.Compiled);
        }

        public static string ExtractVideoID(string url)
        {
            Match match = regex.Match(url);
            if (!match.Success)
                return null;

            var val = match.Groups[1].Value;
            var i = val.IndexOf('&');
            if (i < 0)
                return val;

            return val.Substring(0, i);
        }

    }
}
