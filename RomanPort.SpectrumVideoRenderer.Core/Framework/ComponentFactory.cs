using Newtonsoft.Json.Linq;
using RomanPort.SpectrumVideoRenderer.Core.Components;
using RomanPort.SpectrumVideoRenderer.Core.Framework.ComponentRegistration;
using RomanPort.SpectrumVideoRenderer.Core.Framework.Saved;
using System;
using System.Collections.Generic;
using System.Text;

namespace RomanPort.SpectrumVideoRenderer.Core.Framework
{
    public static class ComponentFactory
    {
        public static SpectrumVideoComponent MakeComponent(CanvasContext ctx, SpectrumVideoComponentConfig cfg)
        {
            //Get info
            ComponentInfo info = GetComponentInfo(cfg.tag);

            //Construct
            return (SpectrumVideoComponent)Activator.CreateInstance(info.type, ctx, cfg.config);
        }

        public static ComponentInfo GetComponentInfo(string tag)
        {
            if (components.ContainsKey(tag))
                return components[tag];
            else
                throw new Exception("Component tag not registered: " + tag);
        }

        public static bool TryGetComponentName(string tag, out string name)
        {
            if (components.ContainsKey(tag))
            {
                name = components[tag].name;
                return true;
            } else
            {
                name = tag + " (Unknown)";
                return false;
            }
        }

        public static Dictionary<string, ComponentInfo> components = new Dictionary<string, ComponentInfo>();

        public static void RegisterComponent(string tag, ComponentInfo info)
        {
            components.Add(tag, info);
        }

        static ComponentFactory()
        {
            //Register built-in, common components
            ComponentMpxSpectrum.RegisterSelf();
            ComponentPadding.RegisterSelf();
            ComponentRDSBar.RegisterSelf();
            ComponentRDSLabel.RegisterSelf();
            ComponentSpectrum.RegisterSelf();
            ComponentWaterfall.RegisterSelf();
        }
    }

    public delegate SpectrumVideoComponent ComponentFactoryCreateCallback(CanvasContext ctx, JObject cfg);
}
