using RomanPort.SpectrumVideoRenderer.Core.Framework;
using RomanPort.SpectrumVideoRenderer.Core.Framework.Saved;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RomanPort.SpectrumVideoRenderer.GUI.Components.Lists
{
    public class ComponentListView : ConfigComponentListView<SpectrumVideoComponentConfig>
    {
        protected override Dictionary<string, object> ItemTypes
        {
            get
            {
                Dictionary<string, object> info = new Dictionary<string, object>();
                foreach (var i in ComponentFactory.components)
                    info.Add(i.Value.name, i.Key);
                return info;
            }
        }

        protected override SpectrumVideoComponentConfig ConstructItem(object itemType)
        {
            return new SpectrumVideoComponentConfig
            {
                config = new Newtonsoft.Json.Linq.JObject(),
                tag = (string)itemType
            };
        }

        protected override void ShowConfigureDialog(SpectrumVideoComponentConfig item)
        {
            ComponentConfigDialog dialog = new ComponentConfigDialog(item);
            dialog.ShowDialog();
        }
    }
}
