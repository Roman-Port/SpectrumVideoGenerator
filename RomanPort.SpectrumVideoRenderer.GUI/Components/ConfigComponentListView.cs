using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RomanPort.SpectrumVideoRenderer.GUI.Components
{
    public abstract class ConfigComponentListView<T> : ConfigListView<T>
    {
        protected abstract Dictionary<string, object> ItemTypes { get; }
        protected abstract T ConstructItem(object itemType);

        protected override T CreateNewItem()
        {
            //Prompt user to select from the item types
            ConfigListAddDialog prompt = new ConfigListAddDialog(Label, ItemTypes);
            if (prompt.ShowDialog() != DialogResult.OK)
                return default(T);

            //Construct item
            T item = ConstructItem(prompt.SelectedObject);
            if (item == null)
                return default(T);

            return item;
        }
    }
}
