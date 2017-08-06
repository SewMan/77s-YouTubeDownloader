using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
