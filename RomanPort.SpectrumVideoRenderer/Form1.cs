using RomanPort.LibSDR.Framework.Components.IO.WAV;
using RomanPort.SpectrumVideoRenderer.Framework.Generator;
using RomanPort.SpectrumVideoRenderer.Framework.Saved;
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

namespace RomanPort.SpectrumVideoRenderer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public WavFileReader Reader { get => file; }
        public int BufferSize { get => file.SampleRate / fps; }

        private WavFileReader file;
        private int fps = 30;

        private void Form1_Load(object sender, EventArgs e)
        {
            //Load file
            file = new WavFileReader(new FileStream(@"C:\Users\Roman\Desktop\Unpacked IQ\92500000Hz KQRS-FM - Bob Seger - Against the Wind.wav", FileMode.Open));

            //Load default data
            spectrumConfig.LoadInfo(SavedViewData.GetDefault(file.SampleRate), this);
        }

        private void btnRender_Click(object sender, EventArgs e)
        {
            //Get parameters
            ViewGenerator generator = spectrumConfig.GetGenerator();

            //Create window and start
            RenderingForm renderer = new RenderingForm(file, generator);
            renderer.ShowDialog();
        }
    }
}
