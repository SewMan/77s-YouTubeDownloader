using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeExtractor;

namespace _77s_YouTubeDownloader
{
    public partial class frmYTDownloader : Form
    {
        public frmYTDownloader()
        {
            InitializeComponent();
            cboFileType.SelectedIndex = 0; //Set video as first choice
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); //Get desktop path
            folderBrowserDialog1.SelectedPath = folder; //Set desktop path for folder browser
            txtDownloadFolder.Text = folder;
        }

        private void btnDownloadFolder_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
                txtDownloadFolder.Text = folderBrowserDialog1.SelectedPath;
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            Tuple<bool, string> isLinkGood = ValidateLink();
            

            if (isLinkGood.Item1)
            {
                RestrictAcessibility();
                //Pass the validated link into the download method
                //so it can be assigned to the property int the YouTube video/audio model object
                EnableAcessibility();

                MessageBox.Show("Is it a good link?: " + isLinkGood.Item1);
            }


            //Get the link
        //    string link = "https://www.youtube.com/watch?v=c_Vl4T4Anc4";



            //Get the available video formats
           // IEnumerable<VideoInfo> videoInfos = DownloadUrlResolver.GetDownloadUrls(link); 
            
            //Select the first .mp4 video in 360p
           // VideoInfo video = videoInfos.First(info => info.VideoType == VideoType.Mp4 && info.Resolution == 360); 
            
            //If video has a decrypted signature- decipher it
          //  if(video.RequiresDecryption)
           //     DownloadUrlResolver.DecryptDownloadUrl(video);

            //Create the VideoDownloader
            //First argument- video to download, second argumet- path
          //  var videoDownloader = new VideoDownloader(video, Path.Combine(txtDownloadFolder.Text,video.Title+video.VideoExtension));
         //   videoDownloader.Execute();
        }

        private void EnableAcessibility()
        {
            lblFileName.Text = "";
            txtLink.Text = "";

            btnDownload.Enabled = true;
            btnDownloadFolder.Enabled = true;
            cboFileType.Enabled = true;
            txtDownloadFolder.Enabled = true;
            txtLink.Enabled = true;

            pgDownload.Value = 0; //Clear the progress bar
        }

        private void RestrictAcessibility()
        {
            btnDownload.Enabled = false;
            btnDownloadFolder.Enabled = false;
            cboFileType.Enabled = false;
            txtDownloadFolder.Enabled = false;
            txtLink.Enabled = false;
        }

        private Tuple<bool, string> ValidateLink()
        {
            string normalURL;

            if (!Directory.Exists(txtDownloadFolder.Text))
            {
                MessageBox.Show("Please enter a valid folder.");
                return Tuple.Create(false, "");
            }
            else if (DownloadUrlResolver.TryNormalizeYoutubeUrl((txtLink.Text), out normalURL))
               {
                  return Tuple.Create(true, normalURL);
               }
               else
               {
                    MessageBox.Show("Please enter a valid YouTube link.");
                    return Tuple.Create(false, "");
               }
        }
    }
}
