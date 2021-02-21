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
    public delegate void ConfigListView_ChangedEventArgs<T>(ConfigListView<T> list);

    public abstract partial class ConfigListView<T> : UserControl
    {
        public ConfigListView()
        {
            InitializeComponent();
        }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public string Label { get => groupBox1.Text; set => groupBox1.Text = value; }
        public event ConfigListView_ChangedEventArgs<T> OnChanged;

        private List<T> collection;

        public void Configure(List<T> collection)
        {
            this.collection = collection;
            UpdateList();
        }

        protected abstract T CreateNewItem();
        protected abstract void ShowConfigureDialog(T item);

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Get
            T item = CreateNewItem();
            if (item == null)
                return;

            //Add
            collection.Add(item);

            //Show config
            ShowConfigureDialog(item);

            //Update
            OnChanged?.Invoke(this);
            UpdateList();
        }

        private void btnConfigure_Click(object sender, EventArgs e)
        {
            ShowConfigureDialog(collection[listBox.SelectedIndex]);

            //Update
            OnChanged?.Invoke(this);
            UpdateList();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            collection.RemoveAt(listBox.SelectedIndex);

            //Update
            OnChanged?.Invoke(this);
            UpdateList();
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnConfigure.Enabled = listBox.SelectedIndex != -1;
            btnRemove.Enabled = listBox.SelectedIndex != -1;
        }

        private void UpdateList()
        {
            listBox.BeginUpdate();
            int index = listBox.SelectedIndex;
            listBox.Items.Clear();
            foreach (var c in collection)
                listBox.Items.Add(c.ToString());
            if (listBox.Items.Count > index)
                listBox.SelectedIndex = index;
            listBox.EndUpdate();
            btnConfigure.Enabled = listBox.SelectedIndex != -1;
            btnRemove.Enabled = listBox.SelectedIndex != -1;
        }
    }
}
