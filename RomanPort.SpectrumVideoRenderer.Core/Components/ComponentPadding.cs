using Newtonsoft.Json.Linq;
using RomanPort.SpectrumVideoRenderer.Core.Framework;
using RomanPort.SpectrumVideoRenderer.Core.Framework.ComponentRegistration;
using System;
using System.Collections.Generic;
using System.Text;

namespace RomanPort.SpectrumVideoRenderer.Core.Components
{
    public class ComponentPadding : SpectrumVideoComponent
    {
        public ComponentPadding(CanvasContext ctx, JObject cfg) : base(ctx)
        {
            height = UtilReadConfigValue(cfg, "height", 200);
            color = new UnsafeColor (
                UtilReadConfigValue<byte>(cfg, "r", 0),
                UtilReadConfigValue<byte>(cfg, "g", 0),
                UtilReadConfigValue<byte>(cfg, "b", 0)
            );
        }

        internal static void RegisterSelf()
        {
            ComponentFactory.RegisterComponent("PADDING", new ComponentInfo
            {
                name = "Padding",
                description = "Simply a block of color to pad between components.",
                type = typeof(ComponentPadding),
                options = new List<ComponentOption>
                {
                    new ComponentOption
                    {
                        id = "height",
                        name = "Height of the component.",
                        defaultValue = 100,
                        type = ComponentOptionType.Integer
                    },
                    new ComponentOption
                    {
                        id = "r",
                        name = "Color of the background, red channel. (0-255)",
                        defaultValue = 0,
                        type = ComponentOptionType.Integer
                    },
                    new ComponentOption
                    {
                        id = "g",
                        name = "Color of the background, green channel. (0-255)",
                        defaultValue = 0,
                        type = ComponentOptionType.Integer
                    },
                    new ComponentOption
                    {
                        id = "b",
                        name = "Color of the background, blue channel. (0-255)",
                        defaultValue = 0,
                        type = ComponentOptionType.Integer
                    }
                }
            });
        }

        private int height;
        private UnsafeColor color;

        public override int Height => height;

        public override void Dispose()
        {
            
        }

        public override void Init()
        {
            
        }

        public override unsafe void InitFrame(UnsafeColor* ptr)
        {
            Fill(ptr, color);
        }

        public override unsafe void RenderFrame(UnsafeColor* ptr)
        {
            
        }
    }
}
