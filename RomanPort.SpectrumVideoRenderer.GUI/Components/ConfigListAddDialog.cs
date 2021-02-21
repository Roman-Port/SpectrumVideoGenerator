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
    public partial class ConfigListAddDialog : Form
    {
        public ConfigListAddDialog(string name, Dictionary<string, object> data)
        {
            InitializeComponent();
            Name = "Add " + name;
            foreach(var d in data)
            {
                values.Add(d.Value);
                listBox.Items.Add(d.Key);
            }
        }

        private List<object> values = new List<object>();

        public object SelectedObject { get => values[listBox.SelectedIndex]; }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled = listBox.SelectedIndex != -1;
        }
    }
}
