using RomanPort.SpectrumVideoRenderer.Framework.Generator;
using RomanPort.SpectrumVideoRenderer.Framework.Generator.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanPort.SpectrumVideoRenderer.Framework.Saved
{
    public class SavedViewData
    {
        public int sampleRate;
        
        //General info
        public string name;
        public string outputPath;

        //General settings
        public int imageWidth;
        public int fftSize;
        public long offset;
        public long decimation;

        //RDS Bar
        public bool rdsBarEnabled;

        //Spectrum
        public bool spectrumEnabled;
        public int spectrumHeight;
        public int spectrumRange;
        public int spectrumOffset;
        public float spectrumAttack;
        public float spectrumDecay;

        //Waterfall
        public bool waterfallEnabled;
        public int waterfallHeight;
        public int waterfallSpeed;
        public float waterfallAttack;
        public float waterfallDecay;

        //Audio
        public bool audioEnabled;
        public long audioBandwidth;
        public long audioOutputSampleRate;
        public SavedDataDemodulator audioDemodulator;

        //MPX spectrum
        public bool mpxEnabled;
        public int mpxHeight;
        public int mpxRange;
        public int mpxOffset;
        public float mpxAttack;
        public float mpxDecay;

        public static SavedViewData GetDefault(int sampleRate)
        {
            return new SavedViewData
            {
                sampleRate = sampleRate,
                name = "",
                outputPath = "",
                imageWidth = 600,
                fftSize = 2048,
                offset = 0,
                decimation = 1,
                rdsBarEnabled = true,
                spectrumEnabled = true,
                spectrumHeight = 300,
                spectrumRange = 80,
                spectrumOffset = 0,
                spectrumAttack = 0.242f,
                spectrumDecay = 0.111f,
                waterfallEnabled = true,
                waterfallHeight = 500,
                waterfallSpeed = 1,
                waterfallAttack = 0.4f,
                waterfallDecay = 0.2f,
                audioEnabled = true,
                audioBandwidth = 200000,
                audioOutputSampleRate = 48000,
                audioDemodulator = SavedDataDemodulator.BCAST_FM_STEREO,
                mpxEnabled = true,
                mpxHeight = 200,
                mpxRange = 100,
                mpxOffset = 0,
                mpxAttack = 0.283f,
                mpxDecay = 0.354f
            };
        }

        public List<BaseViewComponent> CreateComponents(float bandwidth, out int width, out int height)
        {
            //Set up initial vars
            width = imageWidth;
            height = 0;
            List<BaseViewComponent> response = new List<BaseViewComponent>();

            //Create each if requested
            if (rdsBarEnabled)
            {
                response.Add(new ComponentRDSBar(width));
                height += ComponentRDSBar.RDS_BAR_HEIGHT;
            }
            if(spectrumEnabled)
            {
                response.Add(new ComponentSpectrum(bandwidth, width, spectrumHeight));
                height += spectrumHeight;
            }
            if (waterfallEnabled)
            {
                response.Add(new ComponentWaterfall(width, waterfallHeight));
                height += waterfallHeight;
            }
            if (mpxEnabled)
            {
                response.Add(new ComponentMpxSpectrum(bandwidth, width, mpxHeight));
                height += mpxHeight;
            }

            return response;
        }
    }
}
