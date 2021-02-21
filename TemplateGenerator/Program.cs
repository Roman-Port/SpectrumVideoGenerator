using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace TemplateGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Load template and info
            Preset[] presets = JsonConvert.DeserializeObject<Preset[]>(File.ReadAllText("presets.json"));
            JObject template = (JObject)JsonConvert.DeserializeObject<JObject>(File.ReadAllText("template.sdpf"))["canvases"][0];

            //Fill templates
            JObject output = new JObject();
            JArray outputArr = new JArray();
            output["canvases"] = outputArr;
            foreach(var p in presets)
            {
                var entry = (JObject)template.DeepClone();
                FillTemplate(entry, p);
                outputArr.Add(entry);
            }

            //Save
            File.WriteAllText("output.sdpf", JsonConvert.SerializeObject(output));
        }

        static void FillTemplate(JObject canvas, Preset info)
        {
            canvas["label"] = info.call;
            canvas["baseband"]["freqOffset"] = info.offset;
            canvas["audio_outputs"][0]["outputFilename"] = "C:\\Users\\Roman\\Desktop\\EAS Video\\export\\" + info.call + ".wav";
            canvas["video_output"]["filename"] = "C:\\Users\\Roman\\Desktop\\EAS Video\\export\\" + info.call + ".mp4";
            canvas["components"][0]["config"]["label"] = info.call + "-FM";
            canvas["components"][0]["config"]["subtitle_a"] = info.sub_a;
            canvas["components"][0]["config"]["subtitle_b"] = info.sub_b;
            canvas["components"][2]["config"]["centerFreq"] = 93700000 - info.offset;
        }
    }

    class Preset
    {
        public string call;
        public string sub_a;
        public string sub_b;
        public int offset;
    }
}
