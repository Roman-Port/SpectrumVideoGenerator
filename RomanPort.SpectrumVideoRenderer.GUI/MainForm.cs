using Newtonsoft.Json;
using RomanPort.SpectrumVideoRenderer.Core.Framework.Saved;
using RomanPort.SpectrumVideoRenderer.GUI.Components;
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

namespace RomanPort.SpectrumVideoRenderer.GUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            LoadNewConfig(new SpectrumVideoProjectConfig());
        }

        private SpectrumVideoProjectConfig config;
        private string path;

        private const string PROJECT_FILTER = "Spectrum Video Projects (*.spdf)|*.spdf";

        public void LoadNewConfig(SpectrumVideoProjectConfig config, string path = null)
        {
            //Set
            this.config = config;
            this.path = path;

            //Apply
            canvasList.Configure(config.canvases);
        }

        private void btnRender_Click(object sender, EventArgs e)
        {
            //Validate
            if(!ValidateRender(out string error))
            {
                MessageBox.Show(error, "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Make form
            RenderForm worker = new RenderForm(config.canvases);

            //Hide this and render
            Hide();
            DialogResult status = worker.ShowDialog();

            //Show this and show status
            Show();
            if (status == DialogResult.OK)
                MessageBox.Show("Render was completed successfully!", "Render", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string ValidateRender()
        {
            if (!File.Exists("ffmpeg.exe") && new FfmpegDownloader().ShowDialog() != DialogResult.OK)
                return "FFMPEG failed to download. Try obtaining it manually.";
            if (config.canvases.Count == 0)
                return "No canvases are added.";
            foreach(var c in config.canvases)
            {
                if (c.video_output.filename == null)
                    return $"{c.label}: No video output filename is set.";
                if (c.components.Count == 0)
                    return $"{c.label}: No components are added.";
            }
            return null;
        }

        private bool ValidateRender(out string error)
        {
            error = ValidateRender();
            return error == null;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will clear all of your settings. Are you sure you want to make a new project?", "New Project", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;
            LoadNewConfig(new SpectrumVideoProjectConfig());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(path == null)
            {
                SaveFileDialog fd = new SaveFileDialog();
                fd.Title = "Save Project";
                fd.Filter = PROJECT_FILTER;
                if (fd.ShowDialog() != DialogResult.OK)
                    return;
                path = fd.FileName;
            }
            File.WriteAllText(path, JsonConvert.SerializeObject(config, Formatting.Indented));
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Title = "Open Project";
            fd.Filter = PROJECT_FILTER;
            if (fd.ShowDialog() != DialogResult.OK)
                return;
            LoadNewConfig(JsonConvert.DeserializeObject<SpectrumVideoProjectConfig>(File.ReadAllText(fd.FileName)), fd.FileName);
        }
    }
}
