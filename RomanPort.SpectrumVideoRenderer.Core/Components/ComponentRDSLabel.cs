using Newtonsoft.Json.Linq;
using RomanPort.SimpleFontRenderer;
using RomanPort.SpectrumVideoRenderer.Core.Components.Base;
using RomanPort.SpectrumVideoRenderer.Core.Framework;
using RomanPort.SpectrumVideoRenderer.Core.Framework.ComponentRegistration;
using System;
using System.Collections.Generic;
using System.Text;

namespace RomanPort.SpectrumVideoRenderer.Core.Components
{
    public class ComponentRDSLabel : BaseComponentRDS
    {
        public ComponentRDSLabel(CanvasContext ctx, JObject cfg) : base(ctx, cfg)
        {
            label = UtilReadConfigValue(cfg, "label", "");
            subTextA = UtilReadConfigValue(cfg, "subtitle_a", "");
            subTextB = UtilReadConfigValue(cfg, "subtitle_b", "");
        }

        internal static void RegisterSelf()
        {
            ComponentFactory.RegisterComponent("RDS_LABEL", new ComponentInfo
            {
                name = "RDS Label",
                description = "A larger box with a title, subtitle, and RDS PS and RT in it.",
                type = typeof(ComponentRDSLabel),
                options = new List<ComponentOption>
                {
                    new ComponentOption
                    {
                        id = "label",
                        name = "Large title text",
                        defaultValue = "",
                        type = ComponentOptionType.Text
                    },
                    new ComponentOption
                    {
                        id = "subtitle_a",
                        name = "Subtitle top line",
                        defaultValue = "",
                        type = ComponentOptionType.Text
                    },
                    new ComponentOption
                    {
                        id = "subtitle_b",
                        name = "Subtitle bottom line",
                        defaultValue = "",
                        type = ComponentOptionType.Text
                    },
                    new ComponentOption
                    {
                        id = "demodulator_label",
                        name = "Demodulator Label (MUST be WBFM)",
                        defaultValue = "",
                        type = ComponentOptionType.Text
                    }
                }
            });
        }

        private string label;
        private string subTextA;
        private string subTextB;

        private bool invalidated = true;

        private const int BORDER_WIDTH = 1;
        private const int PADDING = 15;
        private const int TITLE_HEIGHT = 30;
        private const int TITLE_MARGIN_RIGHT = PADDING;
        private const int TITLE_MARGIN_BOTTOM = PADDING;
        private const int RDS_MARGIN_TOP = PADDING;
        private const int RDS_LABEL_HEIGHT = 0;
        private const int RDS_TEXT_HEIGHT = 15;
        private const int RDS_HEIGHT = RDS_LABEL_HEIGHT + RDS_TEXT_HEIGHT;
        private const int TOTAL_HEIGHT = PADDING + TITLE_HEIGHT + TITLE_MARGIN_BOTTOM + RDS_MARGIN_TOP + RDS_HEIGHT + PADDING;

        private const byte RDS_RT_BACKGROUND_BRIGHTNESS = 15;
        private static readonly FontColor RDS_RT_TEXT_BACKGROUND = new FontColor((float)RDS_RT_BACKGROUND_BRIGHTNESS / byte.MaxValue);
        private const byte RDS_PS_BACKGROUND_BRIGHTNESS = 25;
        private static readonly FontColor RDS_PS_TEXT_BACKGROUND = new FontColor((float)RDS_PS_BACKGROUND_BRIGHTNESS / byte.MaxValue);

        private const int RDS_LABEL_OFFSET = PADDING + TITLE_HEIGHT + TITLE_MARGIN_BOTTOM + RDS_MARGIN_TOP;
        private static readonly int PS_OFFSET = PADDING + FontStore.SYSTEM_REGULAR_15.MeasureWidth(8) + PADDING + PADDING;

        public override int Height => TOTAL_HEIGHT;

        public override void Init()
        {
            base.Init();

            //Bind
            RdsDecoder.OnPsBufferUpdated += RdsDecoder_BufferUpdated;
            RdsDecoder.OnRtBufferUpdated += RdsDecoder_BufferUpdated;
        }

        private void RdsDecoder_BufferUpdated(LibSDR.Components.Digital.RDS.RDSClient client, char[] buffer)
        {
            invalidated = true;
        }

        public override unsafe void InitFrame(UnsafeColor* ptr)
        {
            //Render background for RDS
            FillArea(ptr, 0, Height - RDS_HEIGHT - PADDING - RDS_MARGIN_TOP, Width, PADDING + RDS_MARGIN_TOP + RDS_HEIGHT, new UnsafeColor(RDS_RT_BACKGROUND_BRIGHTNESS, RDS_RT_BACKGROUND_BRIGHTNESS, RDS_RT_BACKGROUND_BRIGHTNESS));
            FillArea(ptr, 0, Height - RDS_HEIGHT - PADDING - RDS_MARGIN_TOP, PS_OFFSET - PADDING, PADDING + RDS_MARGIN_TOP + RDS_HEIGHT, new UnsafeColor(RDS_PS_BACKGROUND_BRIGHTNESS, RDS_PS_BACKGROUND_BRIGHTNESS, RDS_PS_BACKGROUND_BRIGHTNESS));
            
            //Render border
            FillArea(ptr, 0, 0, Width, BORDER_WIDTH, UnsafeColor.WHITE);
            FillArea(ptr, 0, Height - BORDER_WIDTH, Width, BORDER_WIDTH, UnsafeColor.WHITE);
            FillArea(ptr, 0, 0, BORDER_WIDTH, Height, UnsafeColor.WHITE);
            FillArea(ptr, Width - BORDER_WIDTH, 0, BORDER_WIDTH, Height, UnsafeColor.WHITE);

            //Render title
            ctx.TextRenderer.RenderRawBox(
                ctx.TextRenderer.GetOffsetPixel(ptr, PADDING, PADDING),
                new char[][] { label.ToCharArray() },
                FontStore.SYSTEM_BOLD_20,
                FontAlignHorizontal.Left,
                FontAlignVertical.Center,
                Width - PADDING - PADDING,
                TITLE_HEIGHT,
                new FontColor(1),
                new FontColor(0)
            );

            //Get left offset
            int offsetLeft = PADDING + FontStore.SYSTEM_BOLD_20.MeasureWidth(label.Length) + TITLE_MARGIN_RIGHT;

            //Render sub texts
            ctx.TextRenderer.RenderRawBox(
                ctx.TextRenderer.GetOffsetPixel(ptr, offsetLeft, PADDING),
                new char[][] { subTextA.ToCharArray(), subTextB.ToCharArray() },
                FontStore.SYSTEM_REGULAR_15,
                FontAlignHorizontal.Left,
                FontAlignVertical.Center,
                Width - offsetLeft - PADDING,
                TITLE_HEIGHT,
                new FontColor(0.8f),
                new FontColor(0)
            );
        }

        public override unsafe void RenderFrame(UnsafeColor* ptr)
        {
            //If not invalidated, ignore
            if (!invalidated)
                return;
            
            //Move the pointer down to the beginning of the RDS bar
            ptr += (Width * (RDS_LABEL_OFFSET + RDS_LABEL_HEIGHT));

            //Render PS name
            ctx.TextRenderer.RenderRawBox(
                ctx.TextRenderer.GetOffsetPixel(ptr, PADDING, 0),
                new char[][] { RdsDecoder.psBuffer },
                FontStore.SYSTEM_REGULAR_15,
                FontAlignHorizontal.Left,
                FontAlignVertical.Center,
                FontStore.SYSTEM_REGULAR_15.MeasureWidth(8),
                RDS_HEIGHT,
                new FontColor(1),
                RDS_PS_TEXT_BACKGROUND
            );

            //Render RT
            ctx.TextRenderer.RenderRawBox(
                ctx.TextRenderer.GetOffsetPixel(ptr, PS_OFFSET, 0),
                new char[][] { RdsDecoder.rtBuffer },
                FontStore.SYSTEM_NARROW_15,
                FontAlignHorizontal.Left,
                FontAlignVertical.Center,
                Width - PS_OFFSET - PADDING,
                RDS_HEIGHT,
                new FontColor(0.85f),
                RDS_RT_TEXT_BACKGROUND
            );

            //Set invalidated flag
            invalidated = false;
        }

        public override void Dispose()
        {
            
        }
    }
}
