using RomanPort.SpectrumVideoRenderer.Core.Framework.Saved;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanPort.SpectrumVideoRenderer.GUI.Components.Lists
{
    public class AudioDemodulatorListView : ConfigComponentListView<SpectrumVideoDemodConfig>
    {
        protected override Dictionary<string, object> ItemTypes => new Dictionary<string, object>
        {
            {"Broadcast FM", "WBFM" }
        };

        protected override SpectrumVideoDemodConfig ConstructItem(object itemType)
        {
            return new SpectrumVideoDemodConfig
            {
                demodType = (string)itemType,
                demodBandwidth = 200000,
                label = "Default",
                outputFilename = "default.wav",
                outputSampleRate = 48000
            };
        }

        protected override void ShowConfigureDialog(SpectrumVideoDemodConfig item)
        {
            AudioConfigDialog dialog = new AudioConfigDialog(item);
            dialog.ShowDialog();
        }
    }
}
