using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace RomanPort.SpectrumVideoRenderer.Core.Framework.Saved
{
    public class SpectrumVideoComponentConfig
    {
        public string tag;
        public JObject config = new JObject();

        public override string ToString()
        {
            ComponentFactory.TryGetComponentName(tag, out string name);
            return name;
        }
    }
}
