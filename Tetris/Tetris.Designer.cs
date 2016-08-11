namespace Tetris
{
    partial class Tetris
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tetris));
            this.GameGrid_Panel = new System.Windows.Forms.Panel();
            this.GameInformation_Panel = new System.Windows.Forms.Panel();
            this.hold_Block_Label = new System.Windows.Forms.Label();
            this.hold_Block_Panel = new System.Windows.Forms.Panel();
            this.score_textBox = new System.Windows.Forms.TextBox();
            this.lines_textBox = new System.Windows.Forms.TextBox();
            this.level_textBox = new System.Windows.Forms.TextBox();
            this.Play_Pause_Label = new System.Windows.Forms.Label();
            this.level_Label = new System.Windows.Forms.Label();
            this.lines_Label = new System.Windows.Forms.Label();
            this.score_Label = new System.Windows.Forms.Label();
            this.nextBlock_Panel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.next_Block_Label = new System.Windows.Forms.Label();
            this.SinglePlayer_GamePanel = new System.Windows.Forms.Panel();
            this.block_Panel = new System.Windows.Forms.Panel();
            this.nextBlock4_Panel = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.nextBlock3_Panel = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.nextBlock2_Panel = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.highScoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu_Panel = new System.Windows.Forms.Panel();
            this.multiPlayer_Label = new System.Windows.Forms.Label();
            this.quitGame_Label = new System.Windows.Forms.Label();
            this.loadGame_Label = new System.Windows.Forms.Label();
            this.newGame_Label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TetrisLogo = new System.Windows.Forms.PictureBox();
            this.GameInformation_Panel.SuspendLayout();
            this.nextBlock_Panel.SuspendLayout();
            this.SinglePlayer_GamePanel.SuspendLayout();
            this.block_Panel.SuspendLayout();
            this.nextBlock4_Panel.SuspendLayout();
            this.nextBlock3_Panel.SuspendLayout();
            this.nextBlock2_Panel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.mainMenu_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TetrisLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // GameGrid_Panel
            // 
            this.GameGrid_Panel.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.GameGrid_Panel.Location = new System.Drawing.Point(293, 0);
            this.GameGrid_Panel.Name = "GameGrid_Panel";
            this.GameGrid_Panel.Size = new System.Drawing.Size(350, 700);
            this.GameGrid_Panel.TabIndex = 0;
            this.GameGrid_Panel.Paint += new System.Windows.Forms.PaintEventHandler(this.GameGrid_Panel_Paint);
            // 
            // GameInformation_Panel
            // 
            this.GameInformation_Panel.BackColor = System.Drawing.Color.Black;
            this.GameInformation_Panel.Controls.Add(this.hold_Block_Label);
            this.GameInformation_Panel.Controls.Add(this.hold_Block_Panel);
            this.GameInformation_Panel.Controls.Add(this.score_textBox);
            this.GameInformation_Panel.Controls.Add(this.lines_textBox);
            this.GameInformation_Panel.Controls.Add(this.level_textBox);
            this.GameInformation_Panel.Controls.Add(this.Play_Pause_Label);
            this.GameInformation_Panel.Controls.Add(this.level_Label);
            this.GameInformation_Panel.Controls.Add(this.lines_Label);
            this.GameInformation_Panel.Controls.Add(this.score_Label);
            this.GameInformation_Panel.Font = new System.Drawing.Font("Papyrus", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameInformation_Panel.Location = new System.Drawing.Point(646, 0);
            this.GameInformation_Panel.Name = "GameInformation_Panel";
            this.GameInformation_Panel.Size = new System.Drawing.Size(284, 700);
            this.GameInformation_Panel.TabIndex = 1;
            // 
            // hold_Block_Label
            // 
            this.hold_Block_Label.AutoSize = true;
            this.hold_Block_Label.BackColor = System.Drawing.Color.Transparent;
            this.hold_Block_Label.Font = new System.Drawing.Font("Papyrus", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hold_Block_Label.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.hold_Block_Label.Location = new System.Drawing.Point(26, 17);
            this.hold_Block_Label.Name = "hold_Block_Label";
            this.hold_Block_Label.Size = new System.Drawing.Size(229, 58);
            this.hold_Block_Label.TabIndex = 6;
            this.hold_Block_Label.Text = "Hold Block";
            // 
            // hold_Block_Panel
            // 
            this.hold_Block_Panel.Location = new System.Drawing.Point(3, 78);
            this.hold_Block_Panel.Name = "hold_Block_Panel";
            this.hold_Block_Panel.Size = new System.Drawing.Size(275, 104);
            this.hold_Block_Panel.TabIndex = 11;
            // 
            // score_textBox
            // 
            this.score_textBox.BackColor = System.Drawing.Color.Black;
            this.score_textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.score_textBox.Cursor = System.Windows.Forms.Cursors.No;
            this.score_textBox.Font = new System.Drawing.Font("Papyrus", 33.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.score_textBox.ForeColor = System.Drawing.Color.Yellow;
            this.score_textBox.Location = new System.Drawing.Point(3, 239);
            this.score_textBox.MaxLength = 10;
            this.score_textBox.Name = "score_textBox";
            this.score_textBox.ReadOnly = true;
            this.score_textBox.Size = new System.Drawing.Size(278, 71);
            this.score_textBox.TabIndex = 10;
            this.score_textBox.TabStop = false;
            this.score_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.score_textBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textBox_MouseDown);
            // 
            // lines_textBox
            // 
            this.lines_textBox.BackColor = System.Drawing.Color.Black;
            this.lines_textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lines_textBox.Cursor = System.Windows.Forms.Cursors.No;
            this.lines_textBox.ForeColor = System.Drawing.Color.Yellow;
            this.lines_textBox.Location = new System.Drawing.Point(6, 381);
            this.lines_textBox.Name = "lines_textBox";
            this.lines_textBox.ReadOnly = true;
            this.lines_textBox.Size = new System.Drawing.Size(278, 76);
            this.lines_textBox.TabIndex = 9;
            this.lines_textBox.TabStop = false;
            this.lines_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.lines_textBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textBox_MouseDown);
            // 
            // level_textBox
            // 
            this.level_textBox.BackColor = System.Drawing.Color.Black;
            this.level_textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.level_textBox.Cursor = System.Windows.Forms.Cursors.No;
            this.level_textBox.ForeColor = System.Drawing.Color.Yellow;
            this.level_textBox.Location = new System.Drawing.Point(3, 523);
            this.level_textBox.Name = "level_textBox";
            this.level_textBox.ReadOnly = true;
            this.level_textBox.Size = new System.Drawing.Size(278, 76);
            this.level_textBox.TabIndex = 8;
            this.level_textBox.TabStop = false;
            this.level_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.level_textBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textBox_MouseDown);
            // 
            // Play_Pause_Label
            // 
            this.Play_Pause_Label.AutoSize = true;
            this.Play_Pause_Label.ForeColor = System.Drawing.Color.Red;
            this.Play_Pause_Label.Location = new System.Drawing.Point(82, 611);
            this.Play_Pause_Label.Name = "Play_Pause_Label";
            this.Play_Pause_Label.Size = new System.Drawing.Size(0, 76);
            this.Play_Pause_Label.TabIndex = 7;
            this.Play_Pause_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Play_Pause_Label.Click += new System.EventHandler(this.Play_Pause_Label_Click);
            this.Play_Pause_Label.MouseEnter += new System.EventHandler(this.Play_Pause_Label_MouseEnter);
            this.Play_Pause_Label.MouseLeave += new System.EventHandler(this.Play_Pause_Label_MouseLeave);
            // 
            // level_Label
            // 
            this.level_Label.AutoSize = true;
            this.level_Label.BackColor = System.Drawing.Color.Transparent;
            this.level_Label.Font = new System.Drawing.Font("Papyrus", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.level_Label.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.level_Label.Location = new System.Drawing.Point(100, 469);
            this.level_Label.Name = "level_Label";
            this.level_Label.Size = new System.Drawing.Size(105, 51);
            this.level_Label.TabIndex = 3;
            this.level_Label.Text = "Level";
            // 
            // lines_Label
            // 
            this.lines_Label.AutoSize = true;
            this.lines_Label.BackColor = System.Drawing.Color.Transparent;
            this.lines_Label.Font = new System.Drawing.Font("Papyrus", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lines_Label.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lines_Label.Location = new System.Drawing.Point(100, 327);
            this.lines_Label.Name = "lines_Label";
            this.lines_Label.Size = new System.Drawing.Size(105, 51);
            this.lines_Label.TabIndex = 2;
            this.lines_Label.Text = "Lines";
            // 
            // score_Label
            // 
            this.score_Label.AutoSize = true;
            this.score_Label.BackColor = System.Drawing.Color.Transparent;
            this.score_Label.Font = new System.Drawing.Font("Papyrus", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.score_Label.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.score_Label.Location = new System.Drawing.Point(86, 185);
            this.score_Label.Name = "score_Label";
            this.score_Label.Size = new System.Drawing.Size(119, 51);
            this.score_Label.TabIndex = 1;
            this.score_Label.Text = "Score";
            // 
            // nextBlock_Panel
            // 
            this.nextBlock_Panel.BackColor = System.Drawing.Color.Transparent;
            this.nextBlock_Panel.Controls.Add(this.panel1);
            this.nextBlock_Panel.Location = new System.Drawing.Point(3, 66);
            this.nextBlock_Panel.Name = "nextBlock_Panel";
            this.nextBlock_Panel.Size = new System.Drawing.Size(275, 104);
            this.nextBlock_Panel.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 110);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(275, 104);
            this.panel1.TabIndex = 6;
            // 
            // next_Block_Label
            // 
            this.next_Block_Label.AutoSize = true;
            this.next_Block_Label.BackColor = System.Drawing.Color.Transparent;
            this.next_Block_Label.Font = new System.Drawing.Font("Papyrus", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.next_Block_Label.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.next_Block_Label.Location = new System.Drawing.Point(31, 14);
            this.next_Block_Label.Name = "next_Block_Label";
            this.next_Block_Label.Size = new System.Drawing.Size(226, 58);
            this.next_Block_Label.TabIndex = 0;
            this.next_Block_Label.Text = "Next Block";
            // 
            // SinglePlayer_GamePanel
            // 
            this.SinglePlayer_GamePanel.Controls.Add(this.GameInformation_Panel);
            this.SinglePlayer_GamePanel.Controls.Add(this.GameGrid_Panel);
            this.SinglePlayer_GamePanel.Controls.Add(this.block_Panel);
            this.SinglePlayer_GamePanel.Location = new System.Drawing.Point(14, 32);
            this.SinglePlayer_GamePanel.Name = "SinglePlayer_GamePanel";
            this.SinglePlayer_GamePanel.Size = new System.Drawing.Size(933, 703);
            this.SinglePlayer_GamePanel.TabIndex = 2;
            // 
            // block_Panel
            // 
            this.block_Panel.Controls.Add(this.nextBlock4_Panel);
            this.block_Panel.Controls.Add(this.nextBlock3_Panel);
            this.block_Panel.Controls.Add(this.nextBlock2_Panel);
            this.block_Panel.Controls.Add(this.next_Block_Label);
            this.block_Panel.Controls.Add(this.nextBlock_Panel);
            this.block_Panel.Location = new System.Drawing.Point(3, 3);
            this.block_Panel.Name = "block_Panel";
            this.block_Panel.Size = new System.Drawing.Size(284, 697);
            this.block_Panel.TabIndex = 6;
            this.block_Panel.Paint += new System.Windows.Forms.PaintEventHandler(this.block_Panel_Paint);
            // 
            // nextBlock4_Panel
            // 
            this.nextBlock4_Panel.BackColor = System.Drawing.Color.Transparent;
            this.nextBlock4_Panel.Controls.Add(this.panel5);
            this.nextBlock4_Panel.Location = new System.Drawing.Point(3, 444);
            this.nextBlock4_Panel.Name = "nextBlock4_Panel";
            this.nextBlock4_Panel.Size = new System.Drawing.Size(275, 104);
            this.nextBlock4_Panel.TabIndex = 9;
            // 
            // panel5
            // 
            this.panel5.Location = new System.Drawing.Point(0, 110);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(275, 104);
            this.panel5.TabIndex = 6;
            // 
            // nextBlock3_Panel
            // 
            this.nextBlock3_Panel.BackColor = System.Drawing.Color.Transparent;
            this.nextBlock3_Panel.Controls.Add(this.panel4);
            this.nextBlock3_Panel.Location = new System.Drawing.Point(3, 334);
            this.nextBlock3_Panel.Name = "nextBlock3_Panel";
            this.nextBlock3_Panel.Size = new System.Drawing.Size(275, 104);
            this.nextBlock3_Panel.TabIndex = 8;
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(0, 110);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(275, 104);
            this.panel4.TabIndex = 6;
            // 
            // nextBlock2_Panel
            // 
            this.nextBlock2_Panel.BackColor = System.Drawing.Color.Transparent;
            this.nextBlock2_Panel.Controls.Add(this.panel3);
            this.nextBlock2_Panel.Location = new System.Drawing.Point(3, 224);
            this.nextBlock2_Panel.Name = "nextBlock2_Panel";
            this.nextBlock2_Panel.Size = new System.Drawing.Size(275, 104);
            this.nextBlock2_Panel.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(0, 110);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(275, 104);
            this.panel3.TabIndex = 6;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.highScoresToolStripMenuItem,
            this.controlsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(959, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.saveGameToolStripMenuItem,
            this.loadGameToolStripMenuItem,
            this.toolStripMenuItem1,
            this.playToolStripMenuItem,
            this.pauseToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.newGameToolStripMenuItem.Text = "New Game (Ctrl+N)";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // saveGameToolStripMenuItem
            // 
            this.saveGameToolStripMenuItem.Name = "saveGameToolStripMenuItem";
            this.saveGameToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.saveGameToolStripMenuItem.Text = "Save Game (Ctrl+S)";
            this.saveGameToolStripMenuItem.Click += new System.EventHandler(this.saveGameToolStripMenuItem_Click);
            // 
            // loadGameToolStripMenuItem
            // 
            this.loadGameToolStripMenuItem.Name = "loadGameToolStripMenuItem";
            this.loadGameToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.loadGameToolStripMenuItem.Text = "Load Game (Ctrl+L)";
            this.loadGameToolStripMenuItem.Click += new System.EventHandler(this.loadGameToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(176, 6);
            // 
            // playToolStripMenuItem
            // 
            this.playToolStripMenuItem.Name = "playToolStripMenuItem";
            this.playToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.playToolStripMenuItem.Text = "Play (P)";
            this.playToolStripMenuItem.Click += new System.EventHandler(this.playToolStripMenuItem_Click);
            // 
            // pauseToolStripMenuItem
            // 
            this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            this.pauseToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.pauseToolStripMenuItem.Text = "Pause (P)";
            this.pauseToolStripMenuItem.Click += new System.EventHandler(this.pauseToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(176, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.exitToolStripMenuItem.Text = " Quit (Ctrl+Q)";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // highScoresToolStripMenuItem
            // 
            this.highScoresToolStripMenuItem.Name = "highScoresToolStripMenuItem";
            this.highScoresToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.highScoresToolStripMenuItem.Text = "High Scores";
            this.highScoresToolStripMenuItem.Click += new System.EventHandler(this.highScoresToolStripMenuItem_Click);
            // 
            // controlsToolStripMenuItem
            // 
            this.controlsToolStripMenuItem.Name = "controlsToolStripMenuItem";
            this.controlsToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.controlsToolStripMenuItem.Text = "Controls";
            this.controlsToolStripMenuItem.Click += new System.EventHandler(this.controlsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // mainMenu_Panel
            // 
            this.mainMenu_Panel.Controls.Add(this.multiPlayer_Label);
            this.mainMenu_Panel.Controls.Add(this.quitGame_Label);
            this.mainMenu_Panel.Controls.Add(this.loadGame_Label);
            this.mainMenu_Panel.Controls.Add(this.newGame_Label);
            this.mainMenu_Panel.Controls.Add(this.label1);
            this.mainMenu_Panel.Controls.Add(this.TetrisLogo);
            this.mainMenu_Panel.Location = new System.Drawing.Point(158, 27);
            this.mainMenu_Panel.Name = "mainMenu_Panel";
            this.mainMenu_Panel.Size = new System.Drawing.Size(674, 718);
            this.mainMenu_Panel.TabIndex = 4;
            // 
            // multiPlayer_Label
            // 
            this.multiPlayer_Label.AutoSize = true;
            this.multiPlayer_Label.Font = new System.Drawing.Font("Papyrus", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.multiPlayer_Label.ForeColor = System.Drawing.Color.Blue;
            this.multiPlayer_Label.Location = new System.Drawing.Point(193, 538);
            this.multiPlayer_Label.Name = "multiPlayer_Label";
            this.multiPlayer_Label.Size = new System.Drawing.Size(280, 76);
            this.multiPlayer_Label.TabIndex = 6;
            this.multiPlayer_Label.Text = "Multiplayer";
            this.multiPlayer_Label.MouseClick += new System.Windows.Forms.MouseEventHandler(this.multiPlayer_Label_MouseClick);
            this.multiPlayer_Label.MouseEnter += new System.EventHandler(this.multiPlayer_Label_MouseEnter);
            this.multiPlayer_Label.MouseLeave += new System.EventHandler(this.multiPlayer_Label_MouseLeave);
            // 
            // quitGame_Label
            // 
            this.quitGame_Label.AutoSize = true;
            this.quitGame_Label.Font = new System.Drawing.Font("Papyrus", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitGame_Label.ForeColor = System.Drawing.Color.Blue;
            this.quitGame_Label.Location = new System.Drawing.Point(263, 614);
            this.quitGame_Label.Name = "quitGame_Label";
            this.quitGame_Label.Size = new System.Drawing.Size(143, 76);
            this.quitGame_Label.TabIndex = 5;
            this.quitGame_Label.Text = "Quit";
            this.quitGame_Label.MouseClick += new System.Windows.Forms.MouseEventHandler(this.quitGame_Label_MouseClick);
            this.quitGame_Label.MouseEnter += new System.EventHandler(this.quitGame_Label_MouseEnter);
            this.quitGame_Label.MouseLeave += new System.EventHandler(this.quitGame_Label_MouseLeave);
            // 
            // loadGame_Label
            // 
            this.loadGame_Label.AutoSize = true;
            this.loadGame_Label.Font = new System.Drawing.Font("Papyrus", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadGame_Label.ForeColor = System.Drawing.Color.Blue;
            this.loadGame_Label.Location = new System.Drawing.Point(193, 457);
            this.loadGame_Label.Name = "loadGame_Label";
            this.loadGame_Label.Size = new System.Drawing.Size(293, 76);
            this.loadGame_Label.TabIndex = 4;
            this.loadGame_Label.Text = "Load Game";
            this.loadGame_Label.MouseClick += new System.Windows.Forms.MouseEventHandler(this.loadGame_Label_MouseClick);
            this.loadGame_Label.MouseEnter += new System.EventHandler(this.loadGame_Label_MouseEnter);
            this.loadGame_Label.MouseLeave += new System.EventHandler(this.loadGame_Label_MouseLeave);
            // 
            // newGame_Label
            // 
            this.newGame_Label.AutoSize = true;
            this.newGame_Label.Font = new System.Drawing.Font("Papyrus", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newGame_Label.ForeColor = System.Drawing.Color.Blue;
            this.newGame_Label.Location = new System.Drawing.Point(193, 386);
            this.newGame_Label.Name = "newGame_Label";
            this.newGame_Label.Size = new System.Drawing.Size(277, 76);
            this.newGame_Label.TabIndex = 2;
            this.newGame_Label.Text = "New Game";
            this.newGame_Label.MouseClick += new System.Windows.Forms.MouseEventHandler(this.newGame_Label_MouseClick);
            this.newGame_Label.MouseEnter += new System.EventHandler(this.newGame_Label_MouseEnter);
            this.newGame_Label.MouseLeave += new System.EventHandler(this.newGame_Label_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // TetrisLogo
            // 
            this.TetrisLogo.Image = global::Tetris.Properties.Resources.tetris;
            this.TetrisLogo.Location = new System.Drawing.Point(61, 30);
            this.TetrisLogo.Name = "TetrisLogo";
            this.TetrisLogo.Size = new System.Drawing.Size(546, 341);
            this.TetrisLogo.TabIndex = 0;
            this.TetrisLogo.TabStop = false;
            // 
            // Tetris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(959, 747);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.mainMenu_Panel);
            this.Controls.Add(this.SinglePlayer_GamePanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Tetris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tetris";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Tetris_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tetris_KeyDown);
            this.GameInformation_Panel.ResumeLayout(false);
            this.GameInformation_Panel.PerformLayout();
            this.nextBlock_Panel.ResumeLayout(false);
            this.SinglePlayer_GamePanel.ResumeLayout(false);
            this.block_Panel.ResumeLayout(false);
            this.block_Panel.PerformLayout();
            this.nextBlock4_Panel.ResumeLayout(false);
            this.nextBlock3_Panel.ResumeLayout(false);
            this.nextBlock2_Panel.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.mainMenu_Panel.ResumeLayout(false);
            this.mainMenu_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TetrisLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel GameGrid_Panel;
        private System.Windows.Forms.Panel GameInformation_Panel;
        private System.Windows.Forms.Panel SinglePlayer_GamePanel;
        private System.Windows.Forms.Panel nextBlock_Panel;
        private System.Windows.Forms.Label level_Label;
        private System.Windows.Forms.Label lines_Label;
        private System.Windows.Forms.Label score_Label;
        private System.Windows.Forms.Label next_Block_Label;
        private System.Windows.Forms.Label Play_Pause_Label;
        private System.Windows.Forms.TextBox level_textBox;
        private System.Windows.Forms.TextBox score_textBox;
        private System.Windows.Forms.TextBox lines_textBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.Panel mainMenu_Panel;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem playToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.PictureBox TetrisLogo;
        private System.Windows.Forms.Label newGame_Label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label quitGame_Label;
        private System.Windows.Forms.Label loadGame_Label;
        private System.Windows.Forms.ToolStripMenuItem highScoresToolStripMenuItem;
        private System.Windows.Forms.Panel block_Panel;
        private System.Windows.Forms.Label hold_Block_Label;
        private System.Windows.Forms.Panel hold_Block_Panel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel nextBlock2_Panel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel nextBlock4_Panel;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel nextBlock3_Panel;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlsToolStripMenuItem;
        private System.Windows.Forms.Label multiPlayer_Label;
    }
}