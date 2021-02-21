using Newtonsoft.Json.Linq;
using RomanPort.LibSDR.Components.Digital.RDS;
using RomanPort.LibSDR.Components.FFT;
using RomanPort.LibSDR.Demodulators;
using RomanPort.LibSDR.Demodulators.Analog.Broadcast;
using RomanPort.SimpleFontRenderer;
using RomanPort.SpectrumVideoRenderer.Core.ComponentResources;
using RomanPort.SpectrumVideoRenderer.Core.Framework;
using RomanPort.SpectrumVideoRenderer.Core.Framework.ComponentRegistration;
using RomanPort.SpectrumVideoRenderer.Core.Framework.Text;
using System;
using System.Collections.Generic;
using System.Text;

namespace RomanPort.SpectrumVideoRenderer.Core.Components
{
    public unsafe class ComponentRDSBar : SpectrumVideoComponent
    {
        public ComponentRDSBar(CanvasContext ctx, JObject cfg) : base(ctx)
        {
            demodulatorLabel = UtilReadConfigValue<string>(cfg, "demodulator_label", null);
        }

        internal static void RegisterSelf()
        {
            ComponentFactory.RegisterComponent("RDS_BAR", new ComponentInfo
            {
                name = "RDS Bar",
                description = "A small RDS bar that shows the PS name and the RT.",
                type = typeof(ComponentRDSBar),
                options = new List<ComponentOption>
                {
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

        public const int HEIGHT = 40;
        public const int STATUS_MARGIN_HORIZ = 5;
        public const int STATUS_MARGIN_VERT = 8;
        public const int STATUS_PADDING = 7;
        public const int PADDING_PS = 15;
        public const int PADDING_RT = 10;

        public const int PADDING_LEFT = 20;
        public const int PADDING_STATUS_TOP = 5;
        public const int PADDING_STATUS_HORIZ = 10;

        private volatile bool redrawNeeded = true;
        private WbFmDemodulator demodulator;
        private RDSDecoder rds;
        private string demodulatorLabel;

        public override int Height => HEIGHT;

        public override void Init()
        {
            //Get RDS client
            this.demodulator = (WbFmDemodulator)ctx.FindComponentResource<AudioResource>(x => x.Label == demodulatorLabel).Demodulator;
            this.demodulator.OnStereoDetected += Demodulator_OnStereoDetected;
            rds = this.demodulator.UseRds();
            rds.OnPsBufferUpdated += OnRdsUpdated;
            rds.OnRtBufferUpdated += OnRdsUpdated;
            rds.OnSyncStateChanged += Rds_OnSyncStateChanged;
        }

        private void Demodulator_OnStereoDetected(bool stereoDetected)
        {
            redrawNeeded = true;
        }

        private void Rds_OnSyncStateChanged(bool sync)
        {
            redrawNeeded = true;
        }

        private void OnRdsUpdated(RDSClient client, char[] buffer)
        {
            redrawNeeded = true;
        }

        public override void InitFrame(UnsafeColor* ptr)
        {
            
        }

        public override void RenderFrame(UnsafeColor* ptr)
        {
            if (redrawNeeded)
                RedrawFrame(ptr);
        }

        private void RedrawFrame(UnsafeColor* ptr)
        {
            //Render indicators
            int offsetRight = PADDING_STATUS_HORIZ;
            offsetRight += DrawStatusIndicator(ptr, offsetRight, demodulator.StereoDetected, 'S', 'T', 'E', 'R', 'E', 'O');
            offsetRight += DrawStatusIndicator(ptr, offsetRight, rds.IsRdsSynced, 'R', 'D', 'S');

            //Render PS name
            int offsetLeft = FontStore.SYSTEM_REGULAR_15.MeasureWidth(8) + PADDING_PS + PADDING_PS;
            ctx.TextRenderer.RenderRawBox(
                ctx.TextRenderer.GetOffsetPixel(ptr, 0, 0),
                new char[][] { rds.psBuffer },
                FontStore.SYSTEM_REGULAR_15,
                FontAlignHorizontal.Center,
                FontAlignVertical.Center,
                offsetLeft,
                HEIGHT,
                new FontColor(1),
                new FontColor(0.12f)
            );

            //Render RT text
            ctx.TextRenderer.RenderRawBox(
                ctx.TextRenderer.GetOffsetPixel(ptr, offsetLeft + PADDING_RT, 0),
                new char[][] { rds.rtBuffer },
                FontStore.SYSTEM_NARROW_15,
                FontAlignHorizontal.Left,
                FontAlignVertical.Center,
                Width - offsetLeft - offsetRight - PADDING_RT - PADDING_RT + PADDING_STATUS_HORIZ,
                HEIGHT,
                new FontColor(1),
                new FontColor(0)
            );

            //Update state
            redrawNeeded = false;
        }

        private int DrawStatusIndicator(UnsafeColor* ptr, int offset, bool active, params char[] name)
        {
            //Layout
            int statusWidth = FontStore.SYSTEM_NARROW_BOLD_15.MeasureWidth(name.Length) + STATUS_PADDING + STATUS_PADDING;

            //Render
            FontColor color = active ? new FontColor(1) : new FontColor(0.4f);
            ctx.TextRenderer.RenderRawBox(
                ctx.TextRenderer.GetOffsetPixel(ptr, Width - offset - statusWidth, STATUS_MARGIN_VERT),
                new char[][] { name },
                FontStore.SYSTEM_NARROW_BOLD_15,
                FontAlignHorizontal.Center,
                FontAlignVertical.Center,
                statusWidth,
                HEIGHT - STATUS_MARGIN_VERT - STATUS_MARGIN_VERT,
                new FontColor(0),
                color
            );

            return statusWidth + STATUS_MARGIN_HORIZ;
        }

        public override void Dispose()
        {
            
        }
    }
}
