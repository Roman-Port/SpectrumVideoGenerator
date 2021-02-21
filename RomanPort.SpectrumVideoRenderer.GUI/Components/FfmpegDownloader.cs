using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RomanPort.SpectrumVideoRenderer.GUI.Components
{
    public partial class FfmpegDownloader : Form
    {
        public FfmpegDownloader()
        {
            InitializeComponent();
        }

        private const string FFMPEG_URL = "https://assets.romanport.com/static/libs/ffmpeg.exe.gz";
        private const long FFMPEG_SIZE = 52571520;
        private const string FFMPEG_HASH = "FB673E4510E4EC12F995EE9EAF37F3817C7C5A371E2EF52937B5776510EDA68D";

        private Thread workerThread;
        private volatile bool abort;

        private void FfmpegDownloader_Load(object sender, EventArgs e)
        {
            workerThread = new Thread(Worker);
            workerThread.IsBackground = true;
            workerThread.Start();
        }

        private void Worker()
        {
            using (FileStream file = new FileStream("ffmpeg.exe.tmp", FileMode.Create))
            {
                //Begin download
                var request = (HttpWebRequest)WebRequest.Create(FFMPEG_URL);
                request.Method = "GET";
                byte[] buffer = new byte[65536];
                double len = 0;
                using (var response = request.GetResponse())
                using (var webStream = response.GetResponseStream())
                using (var gzStream = new GZipStream(webStream, CompressionMode.Decompress))
                {
                    int read;
                    do
                    {
                        //Read
                        read = gzStream.Read(buffer, 0, buffer.Length);
                        len += read;

                        //Check
                        if (abort)
                            return;

                        //Update UI
                        Invoke((MethodInvoker)delegate
                        {
                            int progress = (int)((len / FFMPEG_SIZE) * 100);
                            if (progress > 100)
                                progress = 100;
                            statusText.Text = $"Downloading FFMPEG... ({progress}%)";
                            statusBar.Value = progress;
                        });

                        //Write
                        file.Write(buffer, 0, read);
                    } while (read != 0);
                }

                //Check
                if (abort)
                    return;

                //Calculate file hash
                Invoke((MethodInvoker)delegate
                {
                    statusText.Text = $"Verifying file integrity (SHA256)...";
                    statusBar.Value = 0;
                });
                file.Position = 0;
                byte[] hash;
                using (SHA256 sha = SHA256.Create())
                    hash = sha.ComputeHash(file);

                //Compare file hash
                bool ok = true;
                for (int i = 0; i < hash.Length; i++)
                    ok = ok && hash[i] == byte.Parse(FFMPEG_HASH.Substring(i * 2, 2), System.Globalization.NumberStyles.HexNumber);

                //Check
                if (abort)
                    return;

                //If passed, rename
                file.Close();
                Thread.Sleep(100);
                if (ok)
                    File.Move("ffmpeg.exe.tmp", "ffmpeg.exe");

                //Close
                Invoke((MethodInvoker)delegate
                {
                    DialogResult = ok ? DialogResult.OK : DialogResult.No;
                    Close();
                });
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            abort = true;
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FfmpegDownloader_FormClosing(object sender, FormClosingEventArgs e)
        {
            abort = true;
        }
    }
}
