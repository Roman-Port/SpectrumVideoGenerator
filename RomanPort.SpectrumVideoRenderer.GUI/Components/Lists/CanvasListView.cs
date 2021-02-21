using RomanPort.LibSDR.Components.IO.WAV;
using RomanPort.SpectrumVideoRenderer.Core.Framework.Saved;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RomanPort.SpectrumVideoRenderer.GUI.Components.Lists
{
    public class CanvasListView : ConfigListView<SpectrumVideoCanvasConfig>
    {
        protected override SpectrumVideoCanvasConfig CreateNewItem()
        {
            //Show file dialog
            OpenFileDialog fd = new OpenFileDialog();
            fd.Title = "Open IQ Files";
            fd.Filter = "IQ Files (*.wav, *.*)|*.wav;*.*";
            if (fd.ShowDialog() != DialogResult.OK)
                return null;

            //Get the file config
            SpectrumVideoFileConfig file;
            if (WavFileReader.IdentifyWavFile(fd.FileName, out WavFileInfo info))
            {
                file = new SpectrumVideoFileConfig
                {
                    pathname = fd.FileName
                };
            } else
            {
                SampleFormatPromptForm prompt = new SampleFormatPromptForm();
                if (prompt.ShowDialog() != DialogResult.OK)
                    return null;
                file = new SpectrumVideoFileConfig
                {
                    pathname = fd.FileName,
                    raw_format = prompt.SampleFormat,
                    raw_rate = prompt.SampleRate
                };
            }

            //Create new 
            return new SpectrumVideoCanvasConfig
            {
                source = file
            };
        }

        protected override void ShowConfigureDialog(SpectrumVideoCanvasConfig item)
        {
            CanvasEditor editor = new CanvasEditor(item);
            editor.ShowDialog();
        }
    }
}
