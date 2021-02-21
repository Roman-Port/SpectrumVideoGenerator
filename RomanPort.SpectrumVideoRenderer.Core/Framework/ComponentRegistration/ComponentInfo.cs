using System;
using System.Collections.Generic;
using System.Text;

namespace RomanPort.SpectrumVideoRenderer.Core.Framework.ComponentRegistration
{
    public class ComponentInfo
    {
        public string name;
        public string description;
        public Type type;
        public List<ComponentOption> options;
    }
}
