using Newtonsoft.Json.Linq;
using RomanPort.SpectrumVideoRenderer.Core.Framework;
using RomanPort.SpectrumVideoRenderer.Core.Framework.ComponentRegistration;
using RomanPort.SpectrumVideoRenderer.Core.Framework.Saved;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RomanPort.SpectrumVideoRenderer.GUI.Components
{
    public partial class ComponentConfigDialog : Form
    {
        public ComponentConfigDialog(SpectrumVideoComponentConfig component)
        {
            this.component = component;
            InitializeComponent();
        }

        private const int WIDTH_PADDING = 10;

        private SpectrumVideoComponentConfig component;

        private void ComponentConfigDialog_Load(object sender, EventArgs e)
        {
            //Get component info
            ComponentInfo info = ComponentFactory.GetComponentInfo(component.tag);

            //Set title
            Name = "Configure " + info.name;

            //Create each setting
            foreach (var o in info.options)
            {
                //Add label
                Label label = new Label();
                label.Text = o.name;
                label.Height = 13;
                mainPanel.Controls.Add(label);

                //Add the option itself
                Control option;
                switch(o.type)
                {
                    case ComponentOptionType.Text:
                        option = new TextBox();
                        ((TextBox)option).Text = UtilReadConfigValue<string>(component.config, o.id, o.defaultValue);
                        ((TextBox)option).TextChanged += TextComponentChanged;
                        break;
                    case ComponentOptionType.Integer:
                        option = new NumericUpDown();
                        ((NumericUpDown)option).Minimum = 0;
                        ((NumericUpDown)option).Maximum = int.MaxValue;
                        ((NumericUpDown)option).Value = UtilReadConfigValue<long>(component.config, o.id, Convert.ToInt64(o.defaultValue));
                        ((NumericUpDown)option).ValueChanged += IntegerComponentChanged;
                        break;
                    case ComponentOptionType.Frequency:
                        option = new NumericUpDown();
                        ((NumericUpDown)option).Minimum = int.MinValue;
                        ((NumericUpDown)option).Maximum = int.MaxValue;
                        ((NumericUpDown)option).ThousandsSeparator = true;
                        ((NumericUpDown)option).Increment = 1000;
                        ((NumericUpDown)option).Value = UtilReadConfigValue<long>(component.config, o.id, Convert.ToInt64(o.defaultValue));
                        ((NumericUpDown)option).ValueChanged += IntegerComponentChanged;
                        break;
                    case ComponentOptionType.Slider:
                        option = new TrackBar();
                        ((TrackBar)option).Minimum = 0;
                        ((TrackBar)option).Maximum = 100;
                        ((TrackBar)option).TickFrequency = 10;
                        ((TrackBar)option).Value = (int)(UtilReadConfigValue<float>(component.config, o.id, o.defaultValue) * 100);
                        ((TrackBar)option).ValueChanged += SliderComponentChanged;
                        break;
                    default:
                        throw new Exception("Unknown component type.");
                }

                //Apply option
                option.Tag = o.id;
                mainPanel.Controls.Add(option);
                option.Width = mainPanel.Width - WIDTH_PADDING;
            }
        }

        private void TextComponentChanged(object sender, EventArgs e)
        {
            TextBox option = (TextBox)sender;
            component.config[(string)option.Tag] = option.Text;
        }

        private void IntegerComponentChanged(object sender, EventArgs e)
        {
            NumericUpDown option = (NumericUpDown)sender;
            component.config[(string)option.Tag] = option.Value;
        }

        private void SliderComponentChanged(object sender, EventArgs e)
        {
            TrackBar option = (TrackBar)sender;
            component.config[(string)option.Tag] = option.Value / 100f;
        }

        private T UtilReadConfigValue<T>(JObject obj, string key, object defaultValue)
        {
            if (!obj.ContainsKey(key))
                return (T)defaultValue;
            else
                return (T)Convert.ChangeType(obj[key], typeof(T));
        }

        private void mainPanel_SizeChanged(object sender, EventArgs e)
        {
            foreach (var c in mainPanel.Controls)
                ((Control)c).Width = mainPanel.Width - WIDTH_PADDING;
        }
    }
}
