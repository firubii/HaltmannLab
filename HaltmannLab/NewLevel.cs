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
    public partial class NewLevel : Form
    {
        public Level level;

        public NewLevel()
        {
            InitializeComponent();
        }

        private void NewLevel_Load(object sender, EventArgs e)
        {
            
        }

        private void createLevel_Click(object sender, EventArgs e)
        {
            level = new Level();

            level.Height = (uint)sizeH.Value;
            level.Width = (uint)sizeW.Value;

            Collision c = new Collision();
            Block b = new Block();
            Decoration d = new Decoration();
            b.ID = -1;
            d.Shape = -1;
            d.WaterShape = 0;
            d.Group = -1;

            for (int i = 0; i < level.Height * level.Width; i++)
            {
                level.TileCollision.Add(c);
                level.TileBlock.Add(b);
                level.BLandDecoration.Add(d);
                level.MLandDecoration.Add(d);
                level.FLandDecoration.Add(d);
            }

            level.Background = bg.Text;
            level.Tileset = tileset.Text;
            level.StageData.BGM = bgm.Text;

            DialogResult = DialogResult.OK;
        }
    }
}
