using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KPRLVL;

namespace HaltmannLab
{
    public partial class StageSettings : Form
    {
        public Stage stage;
        public string bg;
        public string tileset;

        public StageSettings()
        {
            InitializeComponent();
        }

        private void StageSettings_Load(object sender, EventArgs e)
        {
            unk1.Text = stage.Unk_1.ToString();
            unk2.Text = stage.Unk_2.ToString();
            unk3.Text = stage.Unk_3.ToString();
            unk4.Text = stage.Unk_4.ToString();
            unk5.Text = stage.Unk_5.ToString();
            unk6.Text = stage.Unk_6.ToString();
            unk7.Text = stage.Unk_7.ToString();
            unk8.Text = stage.Unk_8.ToString();
            unk9.Text = stage.Unk_9.ToString();
            unk10.Text = stage.Unk_10.ToString();
            unk11.Text = stage.Unk_11.ToString();
            unk12.Text = stage.Unk_12.ToString();
            unk13.Text = stage.Unk_13.ToString();
            unk14.Text = stage.Unk_14.ToString();
            bgm.Text = stage.BGM;
            unkString.Text = stage.Unk_String;
            bgText.Text = bg;
            tileText.Text = tileset;
        }

        private void save_Click(object sender, EventArgs e)
        {
            stage.Unk_1 = uint.Parse(unk1.Text);
            stage.Unk_2 = uint.Parse(unk2.Text);
            stage.Unk_3 = uint.Parse(unk3.Text);
            stage.Unk_4 = uint.Parse(unk4.Text);
            stage.Unk_5 = uint.Parse(unk5.Text);
            stage.Unk_6 = uint.Parse(unk6.Text);
            stage.Unk_7 = uint.Parse(unk7.Text);
            stage.Unk_8 = uint.Parse(unk8.Text);
            stage.Unk_9 = uint.Parse(unk9.Text);
            stage.Unk_10 = uint.Parse(unk10.Text);
            stage.Unk_11 = uint.Parse(unk11.Text);
            stage.Unk_12 = uint.Parse(unk12.Text);
            stage.Unk_13 = uint.Parse(unk13.Text);
            stage.Unk_14 = uint.Parse(unk14.Text);
            stage.BGM = bgm.Text;
            stage.Unk_String = unkString.Text;
            bg = bgText.Text;
            tileset = tileText.Text;
            DialogResult = DialogResult.OK;
        }
    }
}
