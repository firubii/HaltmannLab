namespace HaltmannLab
{
    partial class NewLevel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sizeW = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.sizeH = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.createLevel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bg = new System.Windows.Forms.TextBox();
            this.tileset = new System.Windows.Forms.TextBox();
            this.bgm = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sizeW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeH)).BeginInit();
            this.SuspendLayout();
            // 
            // sizeW
            // 
            this.sizeW.Location = new System.Drawing.Point(83, 33);
            this.sizeW.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.sizeW.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sizeW.Name = "sizeW";
            this.sizeW.Size = new System.Drawing.Size(78, 20);
            this.sizeW.TabIndex = 7;
            this.sizeW.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Width";
            // 
            // sizeH
            // 
            this.sizeH.Location = new System.Drawing.Point(83, 7);
            this.sizeH.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.sizeH.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sizeH.Name = "sizeH";
            this.sizeH.Size = new System.Drawing.Size(78, 20);
            this.sizeH.TabIndex = 5;
            this.sizeH.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Height";
            // 
            // createLevel
            // 
            this.createLevel.Location = new System.Drawing.Point(118, 153);
            this.createLevel.Name = "createLevel";
            this.createLevel.Size = new System.Drawing.Size(75, 23);
            this.createLevel.TabIndex = 8;
            this.createLevel.Text = "Create";
            this.createLevel.UseVisualStyleBackColor = true;
            this.createLevel.Click += new System.EventHandler(this.createLevel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Background";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Tileset";
            // 
            // bg
            // 
            this.bg.Location = new System.Drawing.Point(83, 59);
            this.bg.Name = "bg";
            this.bg.Size = new System.Drawing.Size(215, 20);
            this.bg.TabIndex = 13;
            this.bg.Text = "LampMount";
            // 
            // tileset
            // 
            this.tileset.Location = new System.Drawing.Point(83, 86);
            this.tileset.Name = "tileset";
            this.tileset.Size = new System.Drawing.Size(215, 20);
            this.tileset.TabIndex = 14;
            this.tileset.Text = "GrassNeo";
            // 
            // bgm
            // 
            this.bgm.Location = new System.Drawing.Point(83, 112);
            this.bgm.Name = "bgm";
            this.bgm.Size = new System.Drawing.Size(215, 20);
            this.bgm.TabIndex = 16;
            this.bgm.Text = "BGM_LP_TTNORMAL1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "BGM";
            // 
            // NewLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 177);
            this.Controls.Add(this.bgm);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tileset);
            this.Controls.Add(this.bg);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.createLevel);
            this.Controls.Add(this.sizeW);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.sizeH);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NewLevel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Level";
            this.Load += new System.EventHandler(this.NewLevel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sizeW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown sizeW;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown sizeH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button createLevel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox bg;
        private System.Windows.Forms.TextBox tileset;
        private System.Windows.Forms.TextBox bgm;
        private System.Windows.Forms.Label label4;
    }
}