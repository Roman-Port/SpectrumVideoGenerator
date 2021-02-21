using Newtonsoft.Json;
using RomanPort.SpectrumVideoRenderer.Core;
using RomanPort.SpectrumVideoRenderer.Core.Framework.Saved;
using RomanPort.SpectrumVideoRenderer.Core.Outputs;
using System;
using System.IO;
using System.Threading;

namespace RomanPort.SpectrumVideoRenderer.CLI
{
    class Program
    {
        static int Main(string[] args)
        {
            //Get the filename to the config file
            if(args.Length != 1)
            {
                Console.WriteLine("Invalid usage. Please specify the path to the project file.");
                return -1;
            }

            //Load project file
            SpectrumVideoProjectConfig project = JsonConvert.DeserializeObject<SpectrumVideoProjectConfig>(File.ReadAllText(args[0]));

            //Begin processing each canvas
            start = DateTime.UtcNow;
            SpectrumVideoCanvasMultithread[] canvases = new SpectrumVideoCanvasMultithread[project.canvases.Count];
            for (int i = 0; i<project.canvases.Count; i++)
            {
                SpectrumVideoCanvasMultithread canvas = new SpectrumVideoCanvasMultithread(project.canvases[i], new FfmpegOutputProvider());
                canvases[i] = canvas;
                canvas.Start();
            }

            //Continuously update the UI
            while(true)
            {
                Console.SetCursorPosition(0, 0);
                for (int i = 0; i < canvases.Length; i++)
                    UpdateLine(canvases[i]);
                Thread.Sleep(10);
            }

            return 0;
        }

        private static readonly char[] SPINNER_FRAMES = new char[] { '|', '/', '-', '\\' };
        private static DateTime start;

        private static void UpdateLine(SpectrumVideoCanvas canvas)
        {
            //Get frame count
            int frame = canvas.ComputedFrames;
            int frameCount = (int)canvas.TotalFrames;
            
            //Create status string
            string status = $"[{SPINNER_FRAMES[frame % SPINNER_FRAMES.Length]}] Rendering \"{canvas.Label}\"... (frame {frame}/{frameCount}, {(int)(((float)frame / frameCount) * 100)}%, {EstimateTime((float)frame / frameCount)} remaining) ";

            //Create progress bar
            int progressBarWidth = Console.WindowWidth - status.Length - 3;
            if(progressBarWidth > 3)
            {
                int progressBarProgress = (int)(((float)frame / frameCount) * progressBarWidth);
                status += "[";
                for (int i = 0; i < progressBarProgress; i++)
                    status += "=";
                status += ">";
                for (int i = progressBarProgress + 1; i < progressBarWidth; i++)
                    status += " ";
                status += "]";
            }

            //Write
            Console.WriteLine(status);
        }

        private static string EstimateTime(float progress)
        {
            double secondsTotal = (DateTime.UtcNow - start).TotalSeconds / progress;
            long secondsRemaining = (long)(secondsTotal - (DateTime.UtcNow - start).TotalSeconds);
            return $"{((secondsRemaining / 60) / 60).ToString().PadLeft(2, '0')}:{((secondsRemaining / 60) % 60).ToString().PadLeft(2, '0')}:{(secondsRemaining % 60).ToString().PadLeft(2, '0')}";
        }
    }
}
