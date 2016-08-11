/**
 * 
 * Michael Lutch
 * CSCD 371, Winter 2013
 * Final Project
 * 
 * Tetris
 * 
**/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Media;

namespace Tetris
{
    public partial class Tetris : Form
    {
        #region NamePrompt(Nested Class)
        public static class Prompt
        {
            public static string ShowDialog()
            {
                Form prompt = new Form();
                prompt.Width = 300;
                prompt.Height = 150;
                prompt.Text = "New HighScore!!!";
                Label enterNameLabel = new Label() { Left = 50, Top = 20, Text = "Enter Your Name:" };
                TextBox input_TextBox = new TextBox() { Left = 50, Top = 50, Width = 200 };
                Button confirmation = new Button() { Text = "Ok", Left = 150, Width = 100, Top = 70 };
                confirmation.Click += (sender, e) => { prompt.Close(); };
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(enterNameLabel);
                prompt.Controls.Add(input_TextBox);
                prompt.ShowDialog();
                return input_TextBox.Text;
            }
        }
        #endregion
        #region GameData(Nested Class) [Serializable]
        [Serializable]
        public class GameData
        {
            #region Fields
            public int BLOCK_SPAWN = 400;
            public int STARTING_BLOCKFALL_SPEED = 500;
            public int[,] gameGrid { get; set; }
            public Color[] blockRGB { get; set; }
            public int blockFallSpeed { get; set; } //in milliseconds
            public bool playing { get; set; }
            public bool paused { get; set; }
            public FallingBlock block { get; set; }
            public Queue<int> nextBlockID { get; set; }
            public int hold_Block { get; set; }
            public Random rand { get; set; }
            public int score { get; set; }
            public int linesCompleted { get; set; }
            public int linesTillLevelUp { get; set; }
            public int level { get; set; }
            public Boolean held { get; set; }
            #endregion
            public GameData()  
            {

            }
        }
        #endregion
        #region Fields
        private GameData data;
        private HighScores highScores;
        private System.Timers.Timer gameTimer;
        private System.Timers.Timer blockSpawnTimer;
        #endregion
        #region Constructor/GUI Controlls
            #region Tetris Form Constructor
        public Tetris()
        {
            //System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            //Stream soundStream= new MemoryStream();
            //SoundPlayer player = new SoundPlayer(soundStream);
            //player.Play();
            //player.SoundLocation = "Tetris.023.mp3";
            //player.Play();

            data = new GameData();
            UpdateStyles();
            InitializeHighScore();
            InitializeBlockRGB();
            InitializeComponent();
            data.rand = new Random();
            data.blockFallSpeed = 500;
            this.SinglePlayer_GamePanel.Hide();
            data.playing = false;
            data.paused = false;
            this.Play_Pause_Label.Text = "Start";
            data.block = null;
            this.gameTimer = new System.Timers.Timer();
            this.gameTimer.Elapsed += new System.Timers.ElapsedEventHandler(UpdateBlocks);
            this.blockSpawnTimer = new System.Timers.Timer();
            this.blockSpawnTimer.Interval = data.BLOCK_SPAWN;
            this.blockSpawnTimer.Elapsed += new System.Timers.ElapsedEventHandler(SpawnBlock);
            CheckForIllegalCrossThreadCalls = false;
        }
        #endregion
            #region Initializing Game Grid/Block Colors/High Scores
        private void InitializeGameGrid()
        {
            data.gameGrid = new int[20,10];
            for (int x = 0; x < 20; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    data.gameGrid[x, y] = 0;
                }
            }
        }

        private void InitializeBlockRGB()
        {
            Color[] colors = new Color[8];
            colors[0] = Color.MediumSlateBlue;
            colors[1] = Color.Red;
            colors[2] = Color.Blue;
            colors[3] = Color.Green;
            colors[4] = Color.Yellow;
            colors[5] = Color.Gold;
            colors[6] = Color.Black;
            colors[7] = Color.Brown;
            data.blockRGB = colors;
        }

        private void InitializeHighScore()
        {
            if (File.Exists("HighScores.bin"))
            {
                using (Stream stream = File.Open("HighScores.bin", FileMode.Open))
                {
                    try
                    {
                        if (stream == null)
                            MessageBox.Show("");
                        BinaryFormatter bin = new BinaryFormatter();
                        highScores = (HighScores)bin.Deserialize(stream);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error Loading High Scores\n" + ex.Message);
                    }
                }
            }
            else
            {
                this.highScores = new HighScores();
                highScores.AddNewHighScore("AI", 1000);
                highScores.AddNewHighScore("AI", 2000);
                highScores.AddNewHighScore("AI", 3000);
                highScores.AddNewHighScore("AI", 4000);
                highScores.AddNewHighScore("AI", 5000);
                highScores.AddNewHighScore("AI", 6000);
                highScores.AddNewHighScore("AI", 7000);
                highScores.AddNewHighScore("AI", 8000);
                highScores.AddNewHighScore("AI", 9000);
                highScores.AddNewHighScore("AI", 10000);
            }
        }
        #endregion
            #region Timer Events
        private void UpdateBlocks(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (data.block != null)
            {
                if (data.block.ShiftBlockDown(this.GameGrid_Panel.CreateGraphics()))
                {
                    this.blockSpawnTimer.Stop();
                }
                else
                {
                    this.blockSpawnTimer.Start();
                }
            }
        }

        private void SpawnBlock(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (data.block.canFall())
            {
                this.blockSpawnTimer.Stop();
            }
            if (!data.block.canFall())
            {
                this.gameTimer.Stop();
                this.blockSpawnTimer.Stop();
                if (data.block != null)
                {
                    data.block.Settle();
                }
                data.held = false;
                data.block = null;
                GamegridRefresh();
                ShiftLinesDown();
                CreateBlock(0);
            }
        }
        #endregion
            #region Game Information Panel Click Events
        private void textBox_MouseDown(object sender, MouseEventArgs e)
        {
            this.GameGrid_Panel.Focus();
        }

        private void Play_Pause_Label_Click(object sender, EventArgs e)
        {
            if (data.playing)
            {
                if (!data.paused)
                {
                    Pause();
                    data.paused = true;
                }
                else if (data.paused)
                {
                    Resume();
                    data.paused = false;
                }
            }
            else if (!data.playing)
            {
                this.Play_Pause_Label.Text = "Pause";
                gameStart();
                data.playing = true;
                data.paused = false;
            }
        }

        private void Play_Pause_Label_MouseEnter(object sender, EventArgs e)
        {
            this.Play_Pause_Label.ForeColor = Color.Blue;
        }

        private void Play_Pause_Label_MouseLeave(object sender, EventArgs e)
        {
            this.Play_Pause_Label.ForeColor = Color.Red;
        }
        #endregion
            #region Form Closing
        private void Tetris_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (Stream stream = File.Open("HighScores.bin", FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, highScores);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Saving High Scores\n" + ex.Message);
            }
        }
            #endregion
        #endregion
        #region Game Mechanics
            #region Start/Stop Game
        private void gameStart()
        {
            InitializeGameGrid();
            GamegridRefresh();
            data.nextBlockID = new Queue<int>();
            data.blockFallSpeed = data.STARTING_BLOCKFALL_SPEED;
            data.score = 0;
            data.held = false;
            data.linesCompleted = 0;
            data.linesTillLevelUp = 10;
            data.level = 1;
            data.playing = true;
            data.block = null;
            GamegridRefresh();
            data.hold_Block = 0;
            this.hold_Block_Panel.Refresh();
            this.score_textBox.Text = "" + data.score;
            this.lines_textBox.Text = "" + data.linesCompleted;
            this.level_textBox.Text = "" + data.level;
            this.gameTimer.Interval = data.blockFallSpeed;
            NextBlock();
            CreateBlock(0);
            this.gameTimer.Start();
        }

        private void Stop()
        {
            MessageBox.Show("Game Over!");
            data.playing = false;
            data.paused = false;
            this.Play_Pause_Label.Text = "Start";
            data.block = null;
            data.held = false;
            this.gameTimer.Stop();
            this.blockSpawnTimer.Stop();
            InitializeGameGrid();
            this.GamegridRefresh();
            this.nextBlock_Panel.Refresh();
            this.nextBlock2_Panel.Refresh();
            this.nextBlock3_Panel.Refresh();
            this.nextBlock4_Panel.Refresh();
            this.hold_Block_Panel.Refresh();
            if (this.highScores.NewHighScore(data.score))
            {
                string name = Prompt.ShowDialog();
                this.highScores.AddNewHighScore(name, data.score);
            }
        }
            #endregion
            #region Play/Pause Game
        private void Pause()
        {
            this.gameTimer.Stop();
            this.Play_Pause_Label.Text = "Play";
            this.pauseToolStripMenuItem.Enabled = false;
            this.playToolStripMenuItem.Enabled = true;
            data.paused = true;
        }

        private void Resume()
        {
            this.gameTimer.Start();
            this.Play_Pause_Label.Text = "Pause";
            this.pauseToolStripMenuItem.Enabled = true;
            this.playToolStripMenuItem.Enabled = false;
            data.paused = false;
        }
        #endregion
            #region Save/Load Game
        private void LoadGame()
        {
            try
            {
                using (Stream stream = File.Open("SaveGame.bin", FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    data = (GameData)bin.Deserialize(stream);
                    GamegridRefresh();
                    data.playing = true;
                    data.paused = false;
                    this.Play_Pause_Label.Text = "Pause";
                    this.score_textBox.Text = "" + data.score;
                    this.level_textBox.Text = "" + data.level;
                    this.lines_textBox.Text = "" + data.linesCompleted;
                    this.gameTimer.Interval = data.blockFallSpeed;
                    DrawNextBlock(data.nextBlockID.Peek(), this.nextBlock_Panel.CreateGraphics(), 0);
                    DrawNextBlock(data.hold_Block, this.hold_Block_Panel.CreateGraphics(), 1);
                    if (data.block != null)
                    {
                        data.block.DrawBlock(this.GameGrid_Panel.CreateGraphics());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Loading Game\n No Save File\n" + ex.Message);
            }
        }

        private void SaveGame()
        {
            Pause();
            try
            {
                using (Stream stream = File.Open("SaveGame.bin", FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, data);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Saving Game\n" + ex.Message);
            }
            Resume();
        }
        #endregion
            #region Block Handling
        private void NextBlock()
        {
            if (data.nextBlockID.Count != 5)
            {
                for (int i = 1 ; i <= (5 - data.nextBlockID.Count); i++)
                {
                    data.nextBlockID.Enqueue(data.rand.Next(7) + 1);
                }
            }
            //data.nextBlockID = 3;
            int x = 1;
            foreach (int value in data.nextBlockID)
            {
                if (x == 1)
                {
                    DrawNextBlock(value, this.nextBlock_Panel.CreateGraphics(), 0);
                    x++;
                }
                else if (x == 2)
                {
                   DrawNextBlock(value, this.nextBlock2_Panel.CreateGraphics(), 2);
                    x++;
                }
                else if (x == 3)
                {
                    DrawNextBlock(value, this.nextBlock3_Panel.CreateGraphics(), 3);
                    x++;
                }
                else if (x == 4)
                {
                    DrawNextBlock(value, this.nextBlock4_Panel.CreateGraphics(), 4);
                    x++;
                }
            }
        }

        private void Hold()
        {
            if (!data.held)
            {
                if (data.block != null)
                {
                    if (data.hold_Block == 0)
                    {
                        this.gameTimer.Stop();
                        data.hold_Block = data.block.GetBlockID();
                        data.block = null;
                        GamegridRefresh();
                        DrawNextBlock(data.hold_Block, this.hold_Block_Panel.CreateGraphics(), 1);
                        CreateBlock(0);
                    }
                    else
                    {
                        this.gameTimer.Stop();
                        int temp = data.hold_Block;
                        data.hold_Block = data.block.GetBlockID();
                        data.block = null;
                        GamegridRefresh();
                        DrawNextBlock(data.hold_Block, this.hold_Block_Panel.CreateGraphics(), 1);
                        CreateBlock(temp);
                    }
                }
            }
        }

        private void CreateBlock(int block)
        {
            Graphics g = this.GameGrid_Panel.CreateGraphics();
            this.blockSpawnTimer.Stop();
            int spawn;
            if (block == 0)
            {
                spawn = data.nextBlockID.Dequeue();
            }
            else
            {
                spawn = block;
            }
            if(!data.paused)
            {
                switch (spawn)
                {
                    #region Block 1
                    case 1:
                        {
                            data.block = new FallingBlock(0, 4, 0, 5, 1, 5, 1, 6, 1, 1, data.gameGrid, data.blockRGB);//(1,5) MidPoint, block 3
                            if (block == 0)
                            {
                                NextBlock();
                            }
                            if (data.block.CanSpawn())
                            {
                                data.block.DrawBlock(this.GameGrid_Panel.CreateGraphics());
                                this.gameTimer.Start();
                            }
                            else
                            {
                                Stop();
                            }
                            break;
                        }
                    #endregion
                    #region Block 2
                    case 2:
                        {
                            data.block = new FallingBlock(0, 5, 0, 6, 1, 5, 1, 4, 2, 1, data.gameGrid, data.blockRGB);//(1,5) MidPoint, block 3
                            if (block == 0)
                            {
                                NextBlock();
                            }
                            if (data.block.CanSpawn())
                            {
                                data.block.DrawBlock(this.GameGrid_Panel.CreateGraphics());
                                this.gameTimer.Start();
                            }
                            else
                            {
                                Stop();
                            }
                            break;
                        }
                    #endregion
                    #region Block 3
                    case 3:
                        {
                            data.block = new FallingBlock(0, 4, 1, 4, 1, 5, 1, 6, 3, 1, data.gameGrid, data.blockRGB);//(1,5) MidPoint, block 3
                            if (block == 0)
                            {
                                NextBlock();
                            }
                            if (data.block.CanSpawn())
                            {
                                data.block.DrawBlock(this.GameGrid_Panel.CreateGraphics());
                                this.gameTimer.Start();
                            }
                            else
                            {
                                Stop();
                            }
                            break;
                        }
                    #endregion
                    #region Block 4
                    case 4:
                        {
                            data.block = new FallingBlock(0, 6, 1, 4, 1, 5, 1, 6, 4, 1, data.gameGrid, data.blockRGB);//(1,5) MidPoint, block 3
                            if (block == 0)
                            {
                                NextBlock();
                            }
                            if (data.block.CanSpawn())
                            {
                                data.block.DrawBlock(this.GameGrid_Panel.CreateGraphics());
                                this.gameTimer.Start();
                            }
                            else
                            {
                                Stop();
                            }
                            break;
                        }
                    #endregion
                    #region Block 5
                    case 5:
                        {
                            data.block = new FallingBlock(0, 5, 1, 4, 1, 5, 1, 6, 5, 1, data.gameGrid, data.blockRGB);//(1,5) MidPoint, block 3
                            if (block == 0)
                            {
                                NextBlock();
                            }
                            if (data.block.CanSpawn())
                            {
                                data.block.DrawBlock(this.GameGrid_Panel.CreateGraphics());
                                this.gameTimer.Start();
                            }
                            else
                            {
                                Stop();
                            }
                            break;
                        }
                    #endregion
                    #region Block 6
                    case 6:
                        {
                            data.block = new FallingBlock(0, 4, 0, 5, 1, 4, 1, 5, 6, 1, data.gameGrid, data.blockRGB);//Does Not Rotate
                            if (block == 0)
                            {
                                NextBlock();
                            }
                            if (data.block.CanSpawn())
                            {
                                data.block.DrawBlock(this.GameGrid_Panel.CreateGraphics());
                                this.gameTimer.Start();
                            }
                            else
                            {
                                Stop();
                            }
                            break;
                        }
                    #endregion
                    #region Block 7
                    case 7:
                        {
                            data.block = new FallingBlock(0, 5, 1, 5, 2, 5, 3, 5, 7, 1, data.gameGrid, data.blockRGB);
                            if (block == 0)
                            {
                                NextBlock();
                            }
                            if (data.block.CanSpawn())
                            {
                                data.block.DrawBlock(this.GameGrid_Panel.CreateGraphics());
                                this.gameTimer.Start();
                            }
                            else
                            {
                                Stop();
                            }
                            break;
                        }
                    #endregion
                }
            }
        }
        #endregion
            #region GameGrid Manipulation/Updating
        private void ShiftLinesDown()
        {
            int lines = 0;
            for (int x = 19; x >= 0; x--)
            {
                if(CheckLine(x))
                {
                    for (int y = x; y >= 0; y--)
                    {
                        if (y == 0)
                        {
                            data.gameGrid[y, 0] = 0;
                            data.gameGrid[y, 1] = 0;
                            data.gameGrid[y, 2] = 0;
                            data.gameGrid[y, 3] = 0;
                            data.gameGrid[y, 4] = 0;
                            data.gameGrid[y, 5] = 0;
                            data.gameGrid[y, 6] = 0;
                            data.gameGrid[y, 7] = 0;
                            data.gameGrid[y, 8] = 0;
                            data.gameGrid[y, 9] = 0;
                        }
                        else
                        {
                            data.gameGrid[y, 0] = data.gameGrid[y - 1, 0];
                            data.gameGrid[y, 1] = data.gameGrid[y - 1, 1];
                            data.gameGrid[y, 2] = data.gameGrid[y - 1, 2];
                            data.gameGrid[y, 3] = data.gameGrid[y - 1, 3];
                            data.gameGrid[y, 4] = data.gameGrid[y - 1, 4];
                            data.gameGrid[y, 5] = data.gameGrid[y - 1, 5];
                            data.gameGrid[y, 6] = data.gameGrid[y - 1, 6];
                            data.gameGrid[y, 7] = data.gameGrid[y - 1, 7];
                            data.gameGrid[y, 8] = data.gameGrid[y - 1, 8];
                            data.gameGrid[y, 9] = data.gameGrid[y - 1, 9];
                        }
                    }
                    lines++;
                    x++;
                }
            }
            data.linesCompleted += lines;
            if (lines == 1)
            {
                data.score += 100 * data.level;
            }
            else if (lines == 2)
            {
                data.score += 250 * data.level;
            }
            else if (lines == 3)
            {
                data.score += 400 * data.level;
            }
            else if (lines == 4)
            {
                data.score += 550 * data.level;
            }
            GamegridRefresh();
            this.score_textBox.Text = "" + data.score;
            this.lines_textBox.Text = "" + data.linesCompleted;
            data.linesTillLevelUp -= lines;
            if (data.linesTillLevelUp <= 0 && data.level != 10)
            {
                data.linesTillLevelUp = 10;
                data.level++;
                this.level_textBox.Text = "" + data.level;
                data.blockFallSpeed -= (int)(data.blockFallSpeed * .25);
                this.gameTimer.Interval = data.blockFallSpeed;
            }
        }

        private bool CheckLine(int row)
        {
            bool completed = true;
            for (int x = 0; x < 10; x++)
            {
                if (data.gameGrid[row, x] == 0)
                {
                    completed = false;
                    break;
                }
            }
            return completed;
        }
        #endregion
        #endregion
        #region Painting
        private void block_Panel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen color = new Pen(Color.LightBlue, 2);
            g.DrawEllipse(color, 0, 0, 275, 175);
        }

        private void GameGrid_Panel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Brown, 2);
            g.DrawLine(pen, 0, 0, 350, 0);
            g.DrawLine(pen, 0, 0, 0, 700);
            g.DrawLine(pen, 0, 700, 350, 700);
            g.DrawLine(pen, 350, 0, 350, 700);
        }

        private void GamegridRefresh()
        {
            Graphics g = this.GameGrid_Panel.CreateGraphics();
            for (int x = 0; x < 20; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    if (data.gameGrid[x, y] != 0)
                    {
                        g.DrawRectangle(new Pen(Color.White), (y * 35) + 1, (x * 35) + 1, 34, 34);
                        g.FillRectangle(new SolidBrush(data.blockRGB[data.gameGrid[x, y]]), (y * 35) + 1, (x * 35) + 1, 34, 34);
                    }
                    else
                    {
                        g.DrawRectangle(new Pen(data.blockRGB[data.gameGrid[x, y]]), (y * 35) + 1, (x * 35) + 1, 34, 34);
                        g.FillRectangle(new SolidBrush(data.blockRGB[data.gameGrid[x, y]]), (y * 35) + 1, (x * 35) + 1, 34, 34);
                    }
                }
            }
        }

        private void DrawNextBlock(int blockID, Graphics g, int panel)
        {
            if (blockID != 0)
            {
                if (panel == 0)
                {
                    this.nextBlock_Panel.Refresh();
                }
                else if (panel == 1)
                {
                    this.hold_Block_Panel.Refresh();
                }
                else if (panel == 2)
                {
                    this.nextBlock2_Panel.Refresh();
                }
                else if (panel == 3)
                {
                    this.nextBlock3_Panel.Refresh();
                }
                else if (panel == 4)
                {
                    this.nextBlock4_Panel.Refresh();
                }
                Pen color = new Pen(Color.White, 1);
                SolidBrush brush = new SolidBrush(data.blockRGB[blockID]);
                int[] blockArray = null;
                switch (blockID)
                {
                    case 0:
                        {
                            break;
                        }
                    case 1:
                        {
                            blockArray = new int[9] { 1, 0, 2, 0, 3, 1, 3, 1, 4 };
                            break;
                        }
                    case 2:
                        {
                            blockArray = new int[9] { 2, 1, 2, 1, 3, 0, 3, 0, 4 };
                            break;
                        }
                    case 3:
                        {
                            blockArray = new int[9] { 3, 0, 2, 1, 2, 1, 3, 1, 4 };
                            break;
                        }
                    case 4:
                        {
                            blockArray = new int[9] { 4, 1, 2, 1, 3, 1, 4, 0, 4 };
                            break;
                        }
                    case 5:
                        {
                            blockArray = new int[9] { 5, 1, 2, 1, 3, 0, 3, 1, 4 };
                            break;
                        }
                    case 6:
                        {
                            blockArray = new int[9] { 6, 0, 2, 0, 3, 1, 2, 1, 3 };
                            break;
                        }
                    case 7:
                        {
                            blockArray = new int[9] { 7, 1, 2, 1, 3, 1, 4, 1, 5 };
                            break;
                        }
                }
                if (blockArray != null)
                {
                    g.DrawRectangle(color, (blockArray[2] * 35) + 1, (blockArray[1] * 35) + 1, 34, 34);
                    g.FillRectangle(brush, (blockArray[2] * 35) + 1, (blockArray[1] * 35) + 1, 34, 34);
                    g.DrawRectangle(color, (blockArray[4] * 35) + 1, (blockArray[3] * 35) + 1, 34, 34);
                    g.FillRectangle(brush, (blockArray[4] * 35) + 1, (blockArray[3] * 35) + 1, 34, 34);
                    g.DrawRectangle(color, (blockArray[6] * 35) + 1, (blockArray[5] * 35) + 1, 34, 34);
                    g.FillRectangle(brush, (blockArray[6] * 35) + 1, (blockArray[5] * 35) + 1, 34, 34);
                    g.DrawRectangle(color, (blockArray[8] * 35) + 1, (blockArray[7] * 35) + 1, 34, 34);
                    g.FillRectangle(brush, (blockArray[8] * 35) + 1, (blockArray[7] * 35) + 1, 34, 34);
                }
            }
        }
        #endregion
        #region Keyboard Event Handler
        private void Tetris_KeyDown(object sender, KeyEventArgs e)
        {
            //MessageBox.Show(e.KeyCode.ToString());
            if (this.SinglePlayer_GamePanel.Visible)
            {
                
            }
            if (e.Control)
            {
                if (e.KeyCode.ToString() == "N") //New Game
                {
                    this.mainMenu_Panel.Hide();
                    this.SinglePlayer_GamePanel.Show();
                    Stop();
                    gameStart();
                }
                else if (e.KeyCode.ToString() == "S") //Start game
                {
                    if(data.playing)
                        SaveGame();
                }
                else if (e.KeyCode.ToString() == "L") //Load Game
                {
                    this.mainMenu_Panel.Hide();
                    this.SinglePlayer_GamePanel.Show();
                    LoadGame();
                }
                else if (e.KeyCode.ToString() == "Q") //Quit Game
                {
                    Application.Exit();
                }
            }
            if (data.playing)
            {
                if (e.KeyCode.ToString() == "Left")
                {
                    if (data.block != null && !data.paused)
                    {
                        data.block.ShiftBlockLeft(this.GameGrid_Panel.CreateGraphics());
                    }
                }
                else if (e.KeyCode.ToString() == "Home")
                {
                    if (data.level != 10)
                    {
                        data.level++;
                        data.blockFallSpeed -= (int)(data.blockFallSpeed * .25);
                        this.gameTimer.Interval = data.blockFallSpeed;
                        this.level_textBox.Text = "" + data.level;
                    }
                }
                else if (e.KeyCode.ToString() == "ShiftKey")
                {
                    Hold();
                    data.held = true;
                }
                else if (e.KeyCode.ToString() == "Right")
                {
                    if (data.block != null && !data.paused)
                    {
                        data.block.ShiftBlockRight(this.GameGrid_Panel.CreateGraphics());
                    }
                }
                else if (e.KeyCode.ToString() == "Space")
                {
                    if (data.block != null && !data.paused)
                    {
                        this.gameTimer.Stop();
                        data.block.BlockFall(this.GameGrid_Panel.CreateGraphics());
                        
                        this.blockSpawnTimer.Start();
                    }
                }
                else if (e.KeyCode.ToString() == "Up")
                {
                    if (data.block != null && !data.paused)
                    {
                        data.block.RotateBlockCounterClockWise(this.GameGrid_Panel.CreateGraphics());
                    }
                }
                else if (e.KeyCode.ToString() == "Down")
                {
                    if (data.block != null && !data.paused)
                    {
                        data.block.RotateBlockClockWise(this.GameGrid_Panel.CreateGraphics());
                    }
                }
                else if (e.KeyCode.ToString() == "P")
                {
                    if (data.playing)
                    {
                        if (!data.paused)
                        {
                            this.Play_Pause_Label.Text = "Paused";
                            Pause();
                            data.paused = true;
                        }
                        else if (data.paused)
                        {
                            this.Play_Pause_Label.Text = "Play";
                            Resume();
                            data.paused = false;
                        }
                    }
                }
                else if (e.KeyCode.ToString() == "R")
                {
                    if (data.playing)
                    {
                        GamegridRefresh();
                    }
                }
            }
        }
        #endregion
        #region Menu Controls
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.mainMenu_Panel.Hide();
            this.SinglePlayer_GamePanel.Show();
            gameStart();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Michael Lutch\nCSCD 371, Winter 2013\nFinal Project");
        }

        private void controlsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Left:\tMove Block Left\nRight:\tMove Block Right\nUp:\tRotate Block Counter ClockWise\nDown:\tRotate Block ClockWise\n-\nP:\tPlay or Pause\nShift:\tHold Block\nSpace:\tBlock Fall\nHome:\tLevel Up\nR:\tRefresh\nCtrl+N:\tNew Game\n-\nCtrl+Q:\tQuit\nCtrl+S:\tSave Game\nCtrl+L:\tLoad Game");
        }

        private void saveGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (data.playing)
            {
                SaveGame();
            }
        }

        private void loadGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.mainMenu_Panel.Hide();
            this.SinglePlayer_GamePanel.Show();
            LoadGame();
        }

        private void playToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (data.playing)
            {
                if (data.paused)
                {
                    Resume();
                }
            }
        }

        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (data.playing)
            {
                if (!data.paused)
                {
                    Pause();
                }
            }
        }

        private void highScoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HighScoresForm scores = new HighScoresForm(highScores);
            scores.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion
        #region Main Menu
        private void newGame_Label_MouseEnter(object sender, EventArgs e)
        {
            this.newGame_Label.ForeColor = Color.Red;
        }

        private void newGame_Label_MouseLeave(object sender, EventArgs e)
        {
            this.newGame_Label.ForeColor = Color.Blue;
        }

        private void newGame_Label_MouseClick(object sender, MouseEventArgs e)
        {
            this.mainMenu_Panel.Hide();
            this.SinglePlayer_GamePanel.Show();
        }

        private void loadGame_Label_MouseEnter(object sender, EventArgs e)
        {
            this.loadGame_Label.ForeColor = Color.Red;
        }

        private void loadGame_Label_MouseLeave(object sender, EventArgs e)
        {
            this.loadGame_Label.ForeColor = Color.Blue;
        }

        private void loadGame_Label_MouseClick(object sender, MouseEventArgs e)
        {
            this.loadGame_Label.ForeColor = Color.Yellow;
            this.mainMenu_Panel.Hide();
            this.SinglePlayer_GamePanel.Show();
            LoadGame();
        }

        private void multiPlayer_Label_MouseEnter(object sender, EventArgs e)
        {
            this.multiPlayer_Label.ForeColor = Color.Red;
        }

        private void multiPlayer_Label_MouseLeave(object sender, EventArgs e)
        {
            this.multiPlayer_Label.ForeColor = Color.Blue;
        }

        private void multiPlayer_Label_MouseClick(object sender, MouseEventArgs e)
        {
            System.Net.IPAddress[] localIPs = System.Net.Dns.GetHostAddresses(System.Net.Dns.GetHostName());
            String result = "";
            foreach (System.Net.IPAddress ip in localIPs)
            {
                result += ip.ToString() + "\n";
            }
            MessageBox.Show(result);
        }

        private void quitGame_Label_MouseEnter(object sender, EventArgs e)
        {
            this.quitGame_Label.ForeColor = Color.Red;
        }

        private void quitGame_Label_MouseLeave(object sender, EventArgs e)
        {
            this.quitGame_Label.ForeColor = Color.Blue;
        }

        private void quitGame_Label_MouseClick(object sender, MouseEventArgs e)
        {
            this.quitGame_Label.ForeColor = Color.Yellow;
            Application.Exit();
        }
        #endregion
    }
}