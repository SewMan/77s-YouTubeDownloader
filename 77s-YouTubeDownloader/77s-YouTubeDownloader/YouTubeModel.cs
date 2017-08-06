using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExtractor;

//Instead
//download(fileurl,locations,videotypes)...
//We make
//download(YouTubeVideoModel)
//To avoid complicated methods

namespace _77s_YouTubeDownloader
{
    public class YouTubeModel
    {
        public IEnumerable<VideoInfo> videoInfo { get; set; }
        public string folderPath { get; set; } //Store the folder designated in folder browser
        public string link { get; set; } //YouTube link typed in
        public string filePath { get; set; } //Store the folder location designated earlier + the name and file extention
        public VideoInfo Vide { get; set; } //YouTubeExtractor object- contains the info about the file to be downloaded
    }

    public class YouTubeVideoModel : YouTubeModel
    {
        public VideoDownloader videoDownloaderType { get; set; }
        //This is the object that cointains the execute method, so we can download files

        //DownloadFinished: event we can handle when a download is finished
        //We'll use this to enable access to interface after it's disabled while a file downloads
        //WE'll disable all buttons while the video is being downloaded

        //DownloadProgressChange: event we can use to update progress bar as a video downloads
    }

    public class YouTubeAudioModel : YouTubeModel
    {
        public AudioDownloader audioDownloaderType { get; set; }
        //This is the object that cointains the execute method, so we can download files

        //DownloadFinished: event we can handle when a download is finished
        //We'll use this to enable access to interface after it's disabled while a file downloads
        //WE'll disable all buttons while the audio is being downloaded

        //DownloadProgressChange: event we can use to update progress bar as a audio downloads
    }
}
