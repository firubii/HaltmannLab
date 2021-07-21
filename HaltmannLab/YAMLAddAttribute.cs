using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HaltmannLab
{
    public partial class YAMLAddAttribute : Form
    {
        // All of this is placeholder for when i get a better object editor in

        public int comboBoxIndex = 0;
        public string attrName = "";

        public YAMLAddAttribute()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBoxIndex = comboBox1.SelectedIndex;
            attrName = comboBox1.Text + " " + textBox1.Text;
            DialogResult = DialogResult.OK;
        }
    }
}
