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
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    [Serializable]
    public class FallingBlock
    {
        #region Fields
        //Blocks
        private int block1_Row;
        private int block1_Col;
        private int block2_Row;
        private int block2_Col;
        private int block3_Row;
        private int block3_Col;
        private int block4_Row;
        private int block4_Col;
        //Ghost Blocks
        private int gBlock1_Row;
        private int gBlock1_Col;
        private int gBlock2_Row;
        private int gBlock2_Col;
        private int gBlock3_Row;
        private int gBlock3_Col;
        private int gBlock4_Row;
        private int gBlock4_Col;

        private int blockNum;
        private int blockState;
        private int[,] grid;
        private Color[] PenColors;
        private Boolean LOCK;
        #endregion
        #region Constructor
        public FallingBlock(int b1_row, int b1_col, int b2_row, int b2_col, int b3_row, int b3_col, int b4_row, int b4_col, int passedInBlockNum, int passedInBlockState, int[,] passedInGameGrid, Color[] colorsPassedIn)
        {
            this.block1_Row = b1_row;
            this.block1_Col = b1_col;
            this.block2_Row = b2_row;
            this.block2_Col = b2_col;
            this.block3_Row = b3_row;
            this.block3_Col = b3_col;
            this.block4_Row = b4_row;
            this.block4_Col = b4_col;
            this.blockNum = passedInBlockNum;
            this.blockState = passedInBlockState;
            this.grid = passedInGameGrid;
            this.PenColors = colorsPassedIn;
            this.LOCK = false;
        }

        public int GetBlockID()
        {
            return this.blockNum;
        }

        private void findGhostBlock()
        {
            this.gBlock1_Row = this.block1_Row;
            this.gBlock1_Col = this.block1_Col;
            this.gBlock2_Row = this.block2_Row;
            this.gBlock2_Col = this.block2_Col;
            this.gBlock3_Row = this.block3_Row;
            this.gBlock3_Col = this.block3_Col;
            this.gBlock4_Row = this.block4_Row;
            this.gBlock4_Col = this.block4_Col;
            while(lowerGhostBlock());
        }

        private Boolean lowerGhostBlock()
        {
            Boolean moved = false;
                if ((gBlock1_Row + 1) < 20 && (gBlock2_Row + 1) < 20 && (gBlock3_Row + 1) < 20 && (gBlock4_Row + 1) < 20)
                {
                    if (grid[(gBlock1_Row + 1), gBlock1_Col] == 0 && grid[(gBlock2_Row + 1), gBlock2_Col] == 0 && grid[(gBlock3_Row + 1), gBlock3_Col] == 0 && grid[(gBlock4_Row + 1), gBlock4_Col] == 0)
                    {
                        moved = true;
                        gBlock1_Row++;
                        gBlock2_Row++;
                        gBlock3_Row++;
                        gBlock4_Row++;
                    }
            }
            return moved;
        }
        #endregion
        #region Block Spawn
        public bool CanSpawn()
        {
            if (grid[block1_Row, block1_Col] == 0 && grid[block2_Row, block2_Col] == 0 && grid[block3_Row, block3_Col] == 0 && grid[block4_Row, block4_Col] == 0)
            {
                return true;
            }
            return false;
        }
        #endregion
        #region Block Moving
            #region Lateral Movement
        //Returns true if Block was Able to move, else returns false
        public bool ShiftBlockLeft(Graphics g)
        {
            if (!LOCK)
            {
                LOCK = true;
            }
            else
            {
                while (LOCK) ;
            }
            bool moved = false;
            if ((block1_Col - 1) >= 0 && (block2_Col - 1) >= 0 && (block3_Col - 1) >= 0 && (block4_Col - 1) >= 0)
            {
                if (grid[block1_Row, block1_Col - 1] == 0 && grid[block2_Row, block2_Col - 1] == 0 && grid[block3_Row, block3_Col - 1] == 0 && grid[block4_Row, block4_Col - 1] == 0)
                {
                    int[] blocks = new int[16] { block1_Row, block1_Col, block2_Row, block2_Col, block3_Row, block3_Col, block4_Row, block4_Col, gBlock1_Row, gBlock1_Col, gBlock2_Row, gBlock2_Col, gBlock3_Row, gBlock3_Col, gBlock4_Row, gBlock4_Col };
                    ClearBlock(g, blocks);
                    moved = true;
                    block1_Col--;
                    block2_Col--;
                    block3_Col--;
                    block4_Col--;
                    DrawBlock(g);
                }
            }
            LOCK = false;
            return moved;
        }

        //Returns true if Block was able to move, else returns false
        public bool ShiftBlockRight(Graphics g)
        {
            if (!LOCK)
            {
                LOCK = true;
            }
            else
            {
                while (LOCK) ;
            }
            bool moved = false;
            if ((block1_Col + 1) < 10 && (block2_Col + 1) < 10 && (block3_Col + 1) < 10 && (block4_Col + 1) < 10)
            {
                if (grid[block1_Row, block1_Col + 1] == 0 && grid[block2_Row, block2_Col + 1] == 0 && grid[block3_Row, block3_Col +1] == 0 && grid[block4_Row, block4_Col + 1] == 0)
                {
                    int[] blocks = new int[16] { block1_Row, block1_Col, block2_Row, block2_Col, block3_Row, block3_Col, block4_Row, block4_Col, gBlock1_Row, gBlock1_Col, gBlock2_Row, gBlock2_Col, gBlock3_Row, gBlock3_Col, gBlock4_Row, gBlock4_Col };
                    ClearBlock(g, blocks);
                    moved = true;
                    block1_Col++;
                    block2_Col++;
                    block3_Col++;
                    block4_Col++;
                    DrawBlock(g);
                }
            }
            LOCK = false;
            return moved;
        }
            #endregion
            #region Vertical Movement
        public bool ShiftBlockDown(Graphics g)
        {
            if (!this.LOCK)
            {
                this.LOCK = true;
            }
            else
            {
                while (this.LOCK) ;
            }
            bool moved = false;
            if ((block1_Row + 1) < 20 && (block2_Row + 1) < 20 && (block3_Row + 1) < 20 && (block4_Row + 1) < 20)
            {
                if (grid[(block1_Row + 1), block1_Col] == 0 && grid[(block2_Row + 1), block2_Col] == 0 && grid[(block3_Row + 1), block3_Col] == 0 && grid[(block4_Row + 1), block4_Col] == 0)
                {
                    int[] blocks = new int[16] { block1_Row, block1_Col, block2_Row, block2_Col, block3_Row, block3_Col, block4_Row, block4_Col, gBlock1_Row, gBlock1_Col, gBlock2_Row, gBlock2_Col, gBlock3_Row, gBlock3_Col, gBlock4_Row, gBlock4_Col };
                    ClearBlock(g, blocks);
                    moved = true;
                    block1_Row++;
                    block2_Row++;
                    block3_Row++;
                    block4_Row++;
                    DrawBlock(g);
                }
            }
            this.LOCK = false;
            return moved;
        }
        
        //Returns true if Block was placed, else returns false
        public void Settle()
        {
            grid[block1_Row, block1_Col] = blockNum;
            grid[block2_Row, block2_Col] = blockNum;
            grid[block3_Row, block3_Col] = blockNum;
            grid[block4_Row, block4_Col] = blockNum;
        }

        public Boolean BlockFall(Graphics g)
        {
            if (!LOCK)
            {
                LOCK = true;
            }
            else
            {
                while (LOCK) ;
            }
            Boolean fell = false;
            int[] blocks = new int[16] { block1_Row, block1_Col, block2_Row, block2_Col, block3_Row, block3_Col, block4_Row, block4_Col, gBlock1_Row, gBlock1_Col, gBlock2_Row, gBlock2_Col, gBlock3_Row, gBlock3_Col, gBlock4_Row, gBlock4_Col };
            ClearBlock(g, blocks);
            while (lowerBlock()) ;
            Settle();
            DrawBlock(g);
            LOCK = false;
            return fell;
        }

        public Boolean canFall()
        {
            Boolean fall = false;
            if ((block1_Row + 1) < 20 && (block2_Row + 1) < 20 && (block3_Row + 1) < 20 && (block4_Row + 1) < 20)
            {
                if (grid[(block1_Row + 1), block1_Col] == 0 && grid[(block2_Row + 1), block2_Col] == 0 && grid[(block3_Row + 1), block3_Col] == 0 && grid[(block4_Row + 1), block4_Col] == 0)
                {
                    fall = true;
                }
            }
            return fall;
        }

        //Helper Method to BlockFall
        private Boolean lowerBlock()
        {
            Boolean moved = false;
            if ((block1_Row + 1) < 20 && (block2_Row + 1) < 20 && (block3_Row + 1) < 20 && (block4_Row + 1) < 20)
            {
                if (grid[(block1_Row + 1), block1_Col] == 0 && grid[(block2_Row + 1), block2_Col] == 0 && grid[(block3_Row + 1), block3_Col] == 0 && grid[(block4_Row + 1), block4_Col] == 0)
                {
                    moved = true;
                    block1_Row++;
                    block2_Row++;
                    block3_Row++;
                    block4_Row++;
                }
            }
            return moved;
        }
            #endregion
        #endregion
        #region Rotation
            #region Clockwise
        //Returns true if Block was able to rotate, else returns false
        public bool RotateBlockClockWise(Graphics g)
        {
            if (!LOCK)
            {
                LOCK = true;
            }
            else
            {
                while (LOCK) ;
            }
            bool rotated = false;
            switch (this.blockNum)
            {
                #region case 1
                case 1:
                    {
                        //  Block 1
                        //  [X][X][ ]    [ ][ ][X]    [ ][ ][ ]    [ ][X][ ]
                        //  [ ][X][X]    [ ][X][X]    [X][X][ ]    [X][X][ ]
                        //  [ ][ ][ ]    [ ][X][ ]    [ ][X][X]    [X][ ][ ]   
                        //   State 1      State 2      State 3      State 4
                        if(this.blockState == 1)
                        {
                            //    State 1 to State 2
                            //  [X][X][ ]    [ ][ ][X]
                            //  [ ][X][X]    [ ][X][X]
                            //  [ ][ ][ ]    [ ][X][ ]
                            try
                            {
                                if ( grid[block3_Row, block3_Col] == 0 && grid[block3_Row, block3_Col + 1] == 0 && grid[block3_Row - 1, block3_Col + 1] == 0 && grid[block3_Row + 1, block3_Col] == 0)
                                {
                                    int[] blocks = new int[16] { block1_Row, block1_Col, block2_Row, block2_Col, block3_Row, block3_Col, block4_Row, block4_Col, gBlock1_Row, gBlock1_Col, gBlock2_Row, gBlock2_Col, gBlock3_Row, gBlock3_Col, gBlock4_Row, gBlock4_Col };
                                    ClearBlock(g, blocks);
                                    this.block1_Col += 2;
                                    this.block2_Row += 1;
                                    this.block2_Col += 1;
                                    this.block4_Row += 1;
                                    this.block4_Col -= 1;
                                    this.blockState = 2;
                                    DrawBlock(g);
                                    rotated = true;
                                }
                            }
                            catch
                            {
                                this.LOCK = false;
                                return false;
                            }
                        }
                        else if(this.blockState == 2)
                        {
                            //    State 2 to State 3
                            //  [ ][ ][X]    [ ][ ][ ]
                            //  [ ][X][X]    [X][X][ ]
                            //  [ ][X][ ]    [ ][X][X]
                            try
                            {
                                if ( grid[block3_Row, block3_Col] == 0 && grid[block3_Row + 1, block3_Col] == 0 && grid[block3_Row, block3_Col - 1] == 0 && grid[block3_Row + 1, block3_Col + 1] == 0)
                                {
                                    int[] blocks = new int[16] { block1_Row, block1_Col, block2_Row, block2_Col, block3_Row, block3_Col, block4_Row, block4_Col, gBlock1_Row, gBlock1_Col, gBlock2_Row, gBlock2_Col, gBlock3_Row, gBlock3_Col, gBlock4_Row, gBlock4_Col };
                                    ClearBlock(g, blocks);
                                    this.block1_Row += 2;
                                    this.block2_Row += 1;
                                    this.block2_Col -= 1;
                                    this.block4_Row -= 1;
                                    this.block4_Col -= 1;
                                    this.blockState = 3;
                                    DrawBlock(g);
                                    rotated = true;
                                }
                            }
                            catch
                            {
                                this.LOCK = false;
                                return false;
                            }
                        }
                        else if(this.blockState == 3)
                        {
                            //    State 3 to State 4
                            //  [ ][ ][ ]    [ ][X][ ]
                            //  [X][X][ ]    [X][X][ ]
                            //  [ ][X][X]    [X][ ][ ]
                            try
                            {
                                if ( grid[block3_Row, block3_Col] == 0 && grid[block3_Row - 1, block3_Col] == 0 && grid[block3_Row, block3_Col - 1] == 0 && grid[block3_Row + 1, block3_Col - 1] == 0)
                                {
                                    int[] blocks = new int[16] { block1_Row, block1_Col, block2_Row, block2_Col, block3_Row, block3_Col, block4_Row, block4_Col, gBlock1_Row, gBlock1_Col, gBlock2_Row, gBlock2_Col, gBlock3_Row, gBlock3_Col, gBlock4_Row, gBlock4_Col };
                                    ClearBlock(g, blocks);
                                    this.block1_Col -= 2;
                                    this.block2_Row -= 1;
                                    this.block2_Col -= 1;
                                    this.block4_Row -= 1;
                                    this.block4_Col += 1;
                                    this.blockState = 4;
                                    DrawBlock(g);
                                    rotated = true;
                                }
                            }
                            catch
                            {
                                this.LOCK = false;
                                return false;
                            }
                        }
                        else if (this.blockState == 4)
                        {
                            //    State 4 to State 1
                            //  [ ][X][ ]    [X][X][ ]
                            //  [X][X][ ]    [ ][X][X]
                            //  [X][ ][ ]    [ ][ ][ ]
                            try
                            {
                                if ( grid[block3_Row, block3_Col] == 0 && grid[block3_Row - 1, block3_Col] == 0 && grid[block3_Row - 1, block3_Col - 1] == 0 && grid[block3_Row, block3_Col + 1] == 0)
                                {
                                    int[] blocks = new int[16] { block1_Row, block1_Col, block2_Row, block2_Col, block3_Row, block3_Col, block4_Row, block4_Col, gBlock1_Row, gBlock1_Col, gBlock2_Row, gBlock2_Col, gBlock3_Row, gBlock3_Col, gBlock4_Row, gBlock4_Col };
                                    ClearBlock(g, blocks);
                                    this.block1_Row -= 2;
                                    this.block2_Row -= 1;
                                    this.block2_Col += 1;
                                    this.block4_Row += 1;
                                    this.block4_Col += 1;
                                    this.blockState = 1;
                                    DrawBlock(g);
                                    rotated = true;
                                }
                            }
                            catch
                            {
                                this.LOCK = false;
                                return false;
                            }
                        }
                        break;
                    }
                #endregion
                #region case 2
                case 2:
                    {
                        //  Block 2
                        //  [ ][X][X]    [ ][X][ ]    [ ][ ][ ]    [X][ ][ ]
                        //  [X][X][ ]    [ ][X][X]    [ ][X][X]    [X][X][ ]
                        //  [ ][ ][ ]    [ ][ ][X]    [X][X][ ]    [ ][X][ ]
                        //   State 1      State 2      State 3      State 4
                        if (this.blockState == 1)
                        {
                            //    State 1 to State 2
                            //  [ ][X][X]    [ ][X][ ]
                            //  [X][X][ ]    [ ][X][X]
                            //  [ ][ ][ ]    [ ][ ][X]
                            try
                            {
                                if (grid[block3_Row, block3_Col] == 0 && grid[block3_Row - 1, block3_Col] == 0 && grid[block3_Row + 1, block3_Col + 1] == 0 && grid[block3_Row, block3_Col + 1] == 0)
                                {
                                    int[] blocks = new int[16] { block1_Row, block1_Col, block2_Row, block2_Col, block3_Row, block3_Col, block4_Row, block4_Col, gBlock1_Row, gBlock1_Col, gBlock2_Row, gBlock2_Col, gBlock3_Row, gBlock3_Col, gBlock4_Row, gBlock4_Col };
                                    ClearBlock(g, blocks);
                                    this.block1_Row += 1;
                                    this.block1_Col += 1;
                                    this.block2_Row += 2;
                                    this.block4_Row -= 1;
                                    this.block4_Col += 1;
                                    this.blockState = 2;
                                    DrawBlock(g);
                                    rotated = true;
                                }
                            }
                            catch
                            {
                                this.LOCK = false;
                                return false;
                            }
                        }
                        else if (this.blockState == 2)
                        {
                            //    State 2 to State 3
                            //  [ ][X][ ]    [ ][ ][ ]
                            //  [ ][X][X]    [ ][X][X]
                            //  [ ][ ][X]    [X][X][ ]
                            try
                            {
                                if (grid[block3_Row, block3_Col] == 0 && grid[block3_Row, block3_Col + 1] == 0 && grid[block3_Row + 1, block3_Col] == 0 && grid[block3_Row + 1, block3_Col - 1] == 0)
                                {
                                    int[] blocks = new int[16] { block1_Row, block1_Col, block2_Row, block2_Col, block3_Row, block3_Col, block4_Row, block4_Col, gBlock1_Row, gBlock1_Col, gBlock2_Row, gBlock2_Col, gBlock3_Row, gBlock3_Col, gBlock4_Row, gBlock4_Col };
                                    ClearBlock(g, blocks);
                                    this.block1_Col -= 1;
                                    this.block1_Row += 1;
                                    this.block2_Col -= 2;
                                    this.block4_Row += 1;
                                    this.block4_Col += 1;
                                    this.blockState = 3;
                                    DrawBlock(g);
                                    rotated = true;
                                }
                            }
                            catch
                            {
                                this.LOCK = false;
                                return false;
                            }
                        }
                        else if (this.blockState == 3)
                        {
                            //    State 3 to State 4
                            //  [ ][ ][ ]    [X][ ][ ]
                            //  [ ][X][X]    [X][X][ ]
                            //  [X][X][ ]    [ ][X][ ]
                            try
                            {
                                if (grid[block3_Row, block3_Col] == 0 && grid[block3_Row, block3_Col - 1] == 0 && grid[block3_Row + 1, block3_Col] == 0 && grid[block3_Row - 1, block3_Col - 1] == 0)
                                {
                                    int[] blocks = new int[16] { block1_Row, block1_Col, block2_Row, block2_Col, block3_Row, block3_Col, block4_Row, block4_Col, gBlock1_Row, gBlock1_Col, gBlock2_Row, gBlock2_Col, gBlock3_Row, gBlock3_Col, gBlock4_Row, gBlock4_Col };
                                    ClearBlock(g, blocks);
                                    this.block1_Row -= 1;
                                    this.block1_Col -= 1;
                                    this.block2_Row -= 2;
                                    this.block4_Row += 1;
                                    this.block4_Col -= 1;
                                    this.blockState = 4;
                                    DrawBlock(g);
                                    rotated = true;
                                }
                            }
                            catch
                            {
                                this.LOCK = false;
                                return false;
                            }
                        }
                        else if (this.blockState == 4)
                        {
                            //    State 4 to State 1
                            //  [X][ ][ ]    [ ][X][X]
                            //  [X][X][ ]    [X][X][ ]
                            //  [ ][X][ ]    [ ][ ][ ]
                            try
                            {
                                if (grid[block3_Row, block3_Col] == 0 && grid[block3_Row, block3_Col - 1] == 0 && grid[block3_Row - 1, block3_Col] == 0 && grid[block3_Row - 1, block3_Col + 1] == 0)
                                {
                                    int[] blocks = new int[16] { block1_Row, block1_Col, block2_Row, block2_Col, block3_Row, block3_Col, block4_Row, block4_Col, gBlock1_Row, gBlock1_Col, gBlock2_Row, gBlock2_Col, gBlock3_Row, gBlock3_Col, gBlock4_Row, gBlock4_Col };
                                    ClearBlock(g, blocks);
                                    this.block1_Col += 1;
                                    this.block1_Row -= 1;
                                    this.block2_Col += 2;
                                    this.block4_Row -= 1;
                                    this.block4_Col -= 1;
                                    this.blockState = 1;
                                    DrawBlock(g);
                                    rotated = true;
                                }
                            }
                            catch
                            {
                                this.LOCK = false;
                                return false;
                            }
                        }
                        break;
                    }
                #endregion
                #region Case 3
                case 3:
                    {
                        //  Block 3
                        //  [X][ ][ ]    [ ][X][X]    [ ][ ][ ]    [ ][X][ ]
                        //  [X][X][X]    [ ][X][ ]    [X][X][X]    [ ][X][ ]
                        //  [ ][ ][ ]    [ ][X][ ]    [ ][ ][X]    [X][X][ ]
                        //   State 1      State 2      State 3      State 4
                        if (this.blockState == 1)
                        {
                            //    State 1 to State 2
                            //  [X][ ][ ]    [ ][X][X]
                            //  [X][X][X]    [ ][X][ ]
                            //  [ ][ ][ ]    [ ][X][ ]
                            try
                            {
                                if (grid[block3_Row, block3_Col] == 0 && grid[block3_Row - 1, block3_Col] == 0 && grid[block3_Row - 1, block3_Col + 1] == 0 && grid[block3_Row + 1, block3_Col] == 0)
                                {
                                    int[] blocks = new int[16] { block1_Row, block1_Col, block2_Row, block2_Col, block3_Row, block3_Col, block4_Row, block4_Col, gBlock1_Row, gBlock1_Col, gBlock2_Row, gBlock2_Col, gBlock3_Row, gBlock3_Col, gBlock4_Row, gBlock4_Col };
                                    ClearBlock(g, blocks);
                                    this.block1_Col += 2;
                                    this.block2_Row -= 1;
                                    this.block2_Col += 1;
                                    this.block4_Row += 1;
                                    this.block4_Col -= 1;
                                    this.blockState = 2;
                                    DrawBlock(g);
                                    rotated = true;
                                }
                            }
                            catch
                            {
                                this.LOCK = false;
                                return false;
                            }
                        }
                        else if (this.blockState == 2)
                        {
                            //    State 2 to State 3
                            //  [ ][X][X]    [ ][ ][ ]
                            //  [ ][X][ ]    [X][X][X]
                            //  [ ][X][ ]    [ ][ ][X]
                            try
                            {
                                if (grid[block3_Row, block3_Col] == 0 && grid[block3_Row, block3_Col - 1] == 0 && grid[block3_Row + 1, block3_Col + 1] == 0 && grid[block3_Row, block3_Col + 1] == 0)
                                {
                                    int[] blocks = new int[16] { block1_Row, block1_Col, block2_Row, block2_Col, block3_Row, block3_Col, block4_Row, block4_Col, gBlock1_Row, gBlock1_Col, gBlock2_Row, gBlock2_Col, gBlock3_Row, gBlock3_Col, gBlock4_Row, gBlock4_Col };
                                    ClearBlock(g, blocks);
                                    this.block1_Row += 2;
                                    this.block2_Row += 1;
                                    this.block2_Col += 1;
                                    this.block4_Row -= 1;
                                    this.block4_Col -= 1;
                                    this.blockState = 3;
                                    DrawBlock(g);
                                    rotated = true;
                                }
                            }
                            catch
                            {
                                this.LOCK = false;
                                return false;
                            }
                        }
                        else if (this.blockState == 3)
                        {
                            //    State 3 to State 4
                            //  [ ][ ][ ]    [ ][X][ ]
                            //  [X][X][X]    [ ][X][ ]
                            //  [ ][ ][X]    [X][X][ ]
                            try
                            {
                                if (grid[block3_Row, block3_Col] == 0 && grid[block3_Row - 1, block3_Col] == 0 && grid[block3_Row + 1, block3_Col - 1] == 0 && grid[block3_Row + 1, block3_Col] == 0)
                                {
                                    int[] blocks = new int[16] { block1_Row, block1_Col, block2_Row, block2_Col, block3_Row, block3_Col, block4_Row, block4_Col, gBlock1_Row, gBlock1_Col, gBlock2_Row, gBlock2_Col, gBlock3_Row, gBlock3_Col, gBlock4_Row, gBlock4_Col };
                                    ClearBlock(g, blocks);
                                    this.block1_Col -= 2;
                                    this.block2_Row += 1;
                                    this.block2_Col -= 1;
                                    this.block4_Row -= 1;
                                    this.block4_Col += 1;
                                    this.blockState = 4;
                                    DrawBlock(g);
                                    rotated = true;
                                }
                            }
                            catch
                            {
                                this.LOCK = false;
                                return false;
                            }
                        }
                        else if (this.blockState == 4)
                        {
                            //    State 4 to State 1
                            //  [ ][X][ ]    [X][ ][ ]
                            //  [ ][X][ ]    [X][X][X]
                            //  [X][X][ ]    [ ][ ][ ]
                            try
                            {
                                if (grid[block3_Row, block3_Col] == 0 && grid[block3_Row, block3_Col - 1] == 0 && grid[block3_Row - 1, block3_Col - 1] == 0 && grid[block3_Row, block3_Col + 1] == 0)
                                {
                                    int[] blocks = new int[16] { block1_Row, block1_Col, block2_Row, block2_Col, block3_Row, block3_Col, block4_Row, block4_Col, gBlock1_Row, gBlock1_Col, gBlock2_Row, gBlock2_Col, gBlock3_Row, gBlock3_Col, gBlock4_Row, gBlock4_Col };
                                    ClearBlock(g, blocks);
                                    this.block1_Row -= 2;
                                    this.block2_Row -= 1;
                                    this.block2_Col -= 1;
                                    this.block4_Row += 1;
                                    this.block4_Col += 1;
                                    this.blockState = 1;
                                    DrawBlock(g);
                                    rotated = true;
                                }
                            }
                            catch
                            {
                                this.LOCK = false;
                                return false;
                            }
                        }
                        break;
                    }
                #endregion
                #region Case 4
                case 4:
                    {
                        //  Block 4
                        //  [ ][ ][X]    [ ][X][ ]    [ ][ ][ ]    [X][X][ ]
                        //  [X][X][X]    [ ][X][ ]    [X][X][X]    [ ][X][ ]
                        //  [ ][ ][ ]    [ ][X][X]    [X][ ][ ]    [ ][X][ ]
                        //   State 1      State 2      State 3      State 4
                        if (this.blockState == 1)
                        {
                            //    State 1 to State 2
                            //  [ ][ ][X]    [ ][X][ ]
                            //  [X][X][X]    [ ][X][ ]
                            //  [ ][ ][ ]    [ ][X][X]
                            try
                            {
                                if (grid[block3_Row, block3_Col] == 0 && grid[block3_Row + 1, block3_Col + 1] == 0 && grid[block3_Row + 1, block3_Col] == 0 && grid[block3_Row - 1, block3_Col] == 0)
                                {
                                    int[] blocks = new int[16] { block1_Row, block1_Col, block2_Row, block2_Col, block3_Row, block3_Col, block4_Row, block4_Col, gBlock1_Row, gBlock1_Col, gBlock2_Row, gBlock2_Col, gBlock3_Row, gBlock3_Col, gBlock4_Row, gBlock4_Col };
                                    ClearBlock(g, blocks);
                                    this.block1_Row += 2;
                                    this.block2_Row -= 1;
                                    this.block2_Col += 1;
                                    this.block4_Row += 1;
                                    this.block4_Col -= 1;
                                    this.blockState = 2;
                                    DrawBlock(g);
                                    rotated = true;
                                }
                            }
                            catch
                            {
                                this.LOCK = false;
                                return false;
                            }
                        }
                        else if (this.blockState == 2)
                        {
                            //    State 2 to State 3
                            //  [ ][X][ ]    [ ][ ][ ]
                            //  [ ][X][ ]    [X][X][X]
                            //  [ ][X][X]    [X][ ][ ]
                            try
                            {
                                if (grid[block3_Row, block3_Col] == 0 && grid[block3_Row, block3_Col - 1] == 0 && grid[block3_Row + 1, block3_Col - 1] == 0 && grid[block3_Row, block3_Col + 1] == 0)
                                {
                                    int[] blocks = new int[16] { block1_Row, block1_Col, block2_Row, block2_Col, block3_Row, block3_Col, block4_Row, block4_Col, gBlock1_Row, gBlock1_Col, gBlock2_Row, gBlock2_Col, gBlock3_Row, gBlock3_Col, gBlock4_Row, gBlock4_Col };
                                    ClearBlock(g, blocks);
                                    this.block1_Col -= 2;
                                    this.block2_Row += 1;
                                    this.block2_Col += 1;
                                    this.block4_Row -= 1;
                                    this.block4_Col -= 1;
                                    this.blockState = 3;
                                    DrawBlock(g);
                                    rotated = true;
                                }
                            }
                            catch
                            {
                                this.LOCK = false;
                                return false;
                            }
                        }
                        else if (this.blockState == 3)
                        {
                            //    State 3 to State 4
                            //  [ ][ ][ ]    [X][X][ ]
                            //  [X][X][X]    [ ][X][ ]
                            //  [X][ ][ ]    [ ][X][ ]
                            try
                            {
                                if (grid[block3_Row, block3_Col] == 0 && grid[block3_Row - 1, block3_Col - 1] == 0 && grid[block3_Row - 1, block3_Col] == 0 && grid[block3_Row + 1, block3_Col] == 0)
                                {
                                    int[] blocks = new int[16] { block1_Row, block1_Col, block2_Row, block2_Col, block3_Row, block3_Col, block4_Row, block4_Col, gBlock1_Row, gBlock1_Col, gBlock2_Row, gBlock2_Col, gBlock3_Row, gBlock3_Col, gBlock4_Row, gBlock4_Col };
                                    ClearBlock(g, blocks);
                                    this.block1_Row -= 2;
                                    this.block2_Row += 1;
                                    this.block2_Col -= 1;
                                    this.block4_Row -= 1;
                                    this.block4_Col += 1;
                                    this.blockState = 4;
                                    DrawBlock(g);
                                    rotated = true;
                                }
                            }
                            catch
                            {
                                this.LOCK = false;
                                return false;
                            }
                        }
                        else if (this.blockState == 4)
                        {
                            //    State 4 to State 1
                            //  [X][X][ ]    [ ][ ][X]
                            //  [ ][X][ ]    [X][X][X]
                            //  [ ][X][ ]    [ ][ ][ ]
                            try
                            {
                                if (grid[block3_Row, block3_Col] == 0 && grid[block3_Row, block3_Col - 1] == 0 && grid[block3_Row, block3_Col + 1] == 0 && grid[block3_Row - 1, block3_Col + 1] == 0)
                                {
                                    int[] blocks = new int[16] { block1_Row, block1_Col, block2_Row, block2_Col, block3_Row, block3_Col, block4_Row, block4_Col, gBlock1_Row, gBlock1_Col, gBlock2_Row, gBlock2_Col, gBlock3_Row, gBlock3_Col, gBlock4_Row, gBlock4_Col };
                                    ClearBlock(g, blocks);
                                    this.block1_Col += 2;
                                    this.block2_Row -= 1;
                                    this.block2_Col -= 1;
                                    this.block4_Row += 1;
                                    this.block4_Col += 1;
                                    this.blockState = 1;
                                    DrawBlock(g);
                                    rotated = true;
                                }
                            }
                            catch
                            {
                                this.LOCK = false;
                                return false;
                            }
                        }
                        break;
                    }
                #endregion
                #region Case 5
                case 5:
                    {
                        //  Block 5
                        //  [ ][X]  ]    [ ][X][ ]    [ ][ ][ ]    [ ][X][ ]
                        //  [X][X][X]    [ ][X][X]    [X][X][X]    [X][X][ ]
                        //  [ ][ ][ ]    [ ][X][ ]    [ ][X][ ]    [ ][X][ ]
                        //   State 1      State 2      State 3      State 4
                        if (this.blockState == 1)
                        {
                            //    State 1 to State 2
                            //  [ ][X][ ]    [ ][X][ ]
                            //  [X][X][X]    [ ][X][X]
                            //  [ ][ ][ ]    [ ][X][ ]
                            try
                            {
                                if (grid[block3_Row, block3_Col] == 0 && grid[block3_Row - 1, block3_Col] == 0 && grid[block3_Row, block3_Col + 1] == 0 && grid[block3_Row + 1, block3_Col] == 0)
                                {
                                    int[] blocks = new int[16] { block1_Row, block1_Col, block2_Row, block2_Col, block3_Row, block3_Col, block4_Row, block4_Col, gBlock1_Row, gBlock1_Col, gBlock2_Row, gBlock2_Col, gBlock3_Row, gBlock3_Col, gBlock4_Row, gBlock4_Col };
                                    ClearBlock(g, blocks);
                                    this.block1_Row += 1;
                                    this.block1_Col += 1;
                                    this.block2_Row -= 1;
                                    this.block2_Col += 1;
                                    this.block4_Row += 1;
                                    this.block4_Col -= 1;
                                    this.blockState = 2;
                                    DrawBlock(g);
                                    rotated = true;
                                }
                            }
                            catch
                            {
                                this.LOCK = false;
                                return false;
                            }
                        }
                        else if (this.blockState == 2)
                        {
                            //    State 2 to State 3
                            //  [ ][X][ ]    [ ][ ][ ]
                            //  [ ][X][X]    [X][X][X]
                            //  [ ][X][ ]    [ ][X][ ]
                            try
                            {
                                if (grid[block3_Row, block3_Col] == 0 && grid[block3_Row + 1, block3_Col] == 0 && grid[block3_Row, block3_Col + 1] == 0 && grid[block3_Row, block3_Col - 1] == 0)
                                {
                                    int[] blocks = new int[16] { block1_Row, block1_Col, block2_Row, block2_Col, block3_Row, block3_Col, block4_Row, block4_Col, gBlock1_Row, gBlock1_Col, gBlock2_Row, gBlock2_Col, gBlock3_Row, gBlock3_Col, gBlock4_Row, gBlock4_Col };
                                    ClearBlock(g, blocks);
                                    this.block1_Row += 1;
                                    this.block1_Col -= 1;
                                    this.block2_Row += 1;
                                    this.block2_Col += 1;
                                    this.block4_Row -= 1;
                                    this.block4_Col -= 1;
                                    this.blockState = 3;
                                    DrawBlock(g);
                                    rotated = true;
                                }
                            }
                            catch
                            {
                                this.LOCK = false;
                                return false;
                            }
                        }
                        else if (this.blockState == 3)
                        {
                            //    State 3 to State 4
                            //  [ ][ ][ ]    [ ][X][ ]
                            //  [X][X][X]    [X][X][ ]
                            //  [ ][X][ ]    [ ][X][ ]
                            try
                            {
                                if (grid[block3_Row, block3_Col] == 0 && grid[block3_Row, block3_Col - 1] == 0 && grid[block3_Row + 1, block3_Col] == 0 && grid[block3_Row - 1, block3_Col] == 0)
                                {
                                    int[] blocks = new int[16] { block1_Row, block1_Col, block2_Row, block2_Col, block3_Row, block3_Col, block4_Row, block4_Col, gBlock1_Row, gBlock1_Col, gBlock2_Row, gBlock2_Col, gBlock3_Row, gBlock3_Col, gBlock4_Row, gBlock4_Col };
                                    ClearBlock(g, blocks);
                                    this.block1_Row -= 1;
                                    this.block1_Col -= 1;
                                    this.block2_Row += 1;
                                    this.block2_Col -= 1;
                                    this.block4_Row -= 1;
                                    this.block4_Col += 1;
                                    this.blockState = 4;
                                    DrawBlock(g);
                                    rotated = true;
                                }
                            }
                            catch
                            {
                                this.LOCK = false;
                                return false;
                            }
                        }
                        else if (this.blockState == 4)
                        {
                            //    State 4 to State 1
                            //  [ ][X][ ]    [ ][X][ ]
                            //  [X][X][ ]    [X][X][X]
                            //  [ ][X][ ]    [ ][ ][ ]
                            try
                            {
                                if (grid[block3_Row, block3_Col] == 0 && grid[block3_Row - 1, block3_Col] == 0 && grid[block3_Row, block3_Col - 1] == 0 && grid[block3_Row, block3_Col + 1] == 0)
                                {
                                    int[] blocks = new int[16] { block1_Row, block1_Col, block2_Row, block2_Col, block3_Row, block3_Col, block4_Row, block4_Col, gBlock1_Row, gBlock1_Col, gBlock2_Row, gBlock2_Col, gBlock3_Row, gBlock3_Col, gBlock4_Row, gBlock4_Col };
                                    ClearBlock(g, blocks);
                                    this.block1_Row -= 1;
                                    this.block1_Col += 1;
                                    this.block2_Row -= 1;
                                    this.block2_Col -= 1;
                                    this.block4_Row += 1;
                                    this.block4_Col += 1;
                                    this.blockState = 1;
                                    DrawBlock(g);
                                    rotated = true;
                                }
                            }
                            catch
                            {
                                this.LOCK = false;
                                return false;
                            }
                        }
                        break;
                    }
                #endregion
                #region Case 6
                case 6:
                    {
                        //Does Not Rotate
                        break;
                    }
                #endregion
                #region Case 7
                case 7:
                    {
                        //  Block 7
                        //  [ ][ ][X][ ]    [ ][ ][ ][ ]    [ ][X][ ][ ]    [ ][ ][ ][ ]
                        //  [ ][ ][X][ ]    [ ][ ][ ][ ]    [ ][X][ ][ ]    [X][X][X][X]
                        //  [ ][ ][X][ ]    [X][X][X][X]    [ ][X][ ][ ]    [ ][ ][ ][ ]
                        //  [ ][ ][X][ ]    [ ][ ][ ][ ]    [ ][X][ ][ ]    [ ][ ][ ][ ]
                        //     State 1         State 2         State 3         State 4
                        if (this.blockState == 1)
                        {
                            //       State 1 to State 2
                            //  [ ][ ][X][ ]    [ ][ ][ ][ ]
                            //  [ ][ ][X][ ]    [ ][ ][ ][ ]
                            //  [ ][ ][X][ ]    [X][X][X][X]
                            //  [ ][ ][X][ ]    [ ][ ][ ][ ]
                            try
                            {
                                if (grid[block1_Row + 2, block1_Col + 1] == 0 && grid[block2_Row + 1, block2_Col] == 0 && grid[block3_Row, block3_Col - 1] == 0 && grid[block4_Row - 1, block4_Col - 2] == 0)
                                {
                                    int[] blocks = new int[16] { block1_Row, block1_Col, block2_Row, block2_Col, block3_Row, block3_Col, block4_Row, block4_Col, gBlock1_Row, gBlock1_Col, gBlock2_Row, gBlock2_Col, gBlock3_Row, gBlock3_Col, gBlock4_Row, gBlock4_Col };
                                    ClearBlock(g, blocks);
                                    this.block1_Row += 2;
                                    this.block1_Col += 1;
                                    this.block2_Row += 1;
                                    this.block3_Col -= 1;
                                    this.block4_Row -= 1;
                                    this.block4_Col -= 2;
                                    this.blockState = 2;
                                    DrawBlock(g);
                                    rotated = true;
                                }
                            }
                            catch
                            {
                                this.LOCK = false;
                                return false;
                            }
                        }
                        else if (this.blockState == 2)
                        {
                            //       State 2 to State 3
                            //  [ ][ ][ ][ ]    [ ][X][ ][ ]
                            //  [ ][ ][ ][ ]    [ ][X][ ][ ]
                            //  [X][X][X][X]    [ ][X][ ][ ]
                            //  [ ][ ][ ][ ]    [ ][X][ ][ ]
                            try
                            {
                                if (grid[block1_Row + 1, block1_Col - 2] == 0 && grid[block2_Row, block2_Col - 1] == 0 && grid[block3_Row - 1, block3_Col] == 0 && grid[block4_Row - 2, block4_Col + 1] == 0)
                                {
                                    int[] blocks = new int[16] { block1_Row, block1_Col, block2_Row, block2_Col, block3_Row, block3_Col, block4_Row, block4_Col, gBlock1_Row, gBlock1_Col, gBlock2_Row, gBlock2_Col, gBlock3_Row, gBlock3_Col, gBlock4_Row, gBlock4_Col };
                                    ClearBlock(g, blocks);
                                    this.block1_Row += 1;
                                    this.block1_Col -= 2;
                                    this.block2_Col -= 1;
                                    this.block3_Row -= 1;
                                    this.block4_Row -= 2;
                                    this.block4_Col += 1;
                                    this.blockState = 3;
                                    DrawBlock(g);
                                    rotated = true;
                                }
                            }
                            catch
                            {
                                this.LOCK = false;
                                return false;
                            }
                        }
                        else if (this.blockState == 3)
                        {
                            //       State 3 to State 4
                            //  [ ][X][ ][ ]    [ ][ ][ ][ ]
                            //  [ ][X][ ][ ]    [X][X][X][X]
                            //  [ ][X][ ][ ]    [ ][ ][ ][ ]
                            //  [ ][X][ ][ ]    [ ][ ][ ][ ]
                            try
                            {
                                if (grid[block1_Row - 2, block1_Col - 1] == 0 && grid[block2_Row - 1, block2_Col] == 0 && grid[block3_Row, block3_Col + 1] == 0 && grid[block4_Row + 1, block4_Col + 2] == 0)
                                {
                                    int[] blocks = new int[16] { block1_Row, block1_Col, block2_Row, block2_Col, block3_Row, block3_Col, block4_Row, block4_Col, gBlock1_Row, gBlock1_Col, gBlock2_Row, gBlock2_Col, gBlock3_Row, gBlock3_Col, gBlock4_Row, gBlock4_Col };
                                    ClearBlock(g, blocks);
                                    this.block1_Row -= 2;
                                    this.block1_Col -= 1;
                                    this.block2_Row -= 1;
                                    this.block3_Col += 1;
                                    this.block4_Row += 1;
                                    this.block4_Col += 2;
                                    this.blockState = 4;
                                    DrawBlock(g);
                                    rotated = true;
                                }
                            }
                            catch
                            {
                                this.LOCK = false;
                                return false;
                            }
                        }
                        else if (this.blockState == 4)
                        {
                            //       State 4 to State 1
                            //  [ ][ ][ ][ ]    [ ][ ][X][ ]
                            //  [X][X][X][X]    [ ][ ][X][ ]
                            //  [ ][ ][ ][ ]    [ ][ ][X][ ]
                            //  [ ][ ][ ][ ]    [ ][ ][X][ ]
                            try
                            {
                                if (grid[block1_Row - 1, block1_Col + 2] == 0 && grid[block2_Row, block2_Col + 1] == 0 && grid[block3_Row + 1, block3_Col] == 0 && grid[block4_Row + 2, block4_Col - 1] == 0)
                                {
                                    int[] blocks = new int[16] { block1_Row, block1_Col, block2_Row, block2_Col, block3_Row, block3_Col, block4_Row, block4_Col, gBlock1_Row, gBlock1_Col, gBlock2_Row, gBlock2_Col, gBlock3_Row, gBlock3_Col, gBlock4_Row, gBlock4_Col };
                                    ClearBlock(g, blocks);
                                    this.block1_Row -= 1;
                                    this.block1_Col += 2;
                                    this.block2_Col += 1;
                                    this.block3_Row += 1;
                                    this.block4_Row += 2;
                                    this.block4_Col -= 1;
                                    this.blockState = 1;
                                    DrawBlock(g);
                                    rotated = true;
                                }
                            }
                            catch
                            {
                                this.LOCK = false;
                                return false;
                            }
                        }
                        break;
                    }
                #endregion
            }
            LOCK = false;
            return rotated;
        }
            #endregion
            #region Counter Clockwise
        //Returns true if Block was able to rotate, else returns false
        public bool RotateBlockCounterClockWise(Graphics g)
        {
            if (!LOCK)
            {
                LOCK = true;
            }
            else
            {
                while (LOCK) ;
            }
            bool rotated = false;
            switch (this.blockNum)
            {
                #region case 1
                case 1:
                    {
                        //  Block 1
                        //  [X][X][ ]    [ ][ ][X]    [ ][ ][ ]    [ ][X][ ]
                        //  [ ][X][X]    [ ][X][X]    [X][X][ ]    [X][X][ ]
                        //  [ ][ ][ ]    [ ][X][ ]    [ ][X][X]    [X][ ][ ]   
                        //   State 1      State 2      State 3      State 4
                        if (this.blockState == 1)
                        {
                            //    State 1 to State 4
                            //  [X][X][ ]    [ ][X][ ]
                            //  [ ][X][X]    [X][X][ ]
                            //  [ ][ ][ ]    [X][ ][ ]
                            try
                            {
                                if (grid[block3_Row, block3_Col] == 0 && grid[block3_Row - 1, block3_Col] == 0 && grid[block3_Row + 1, block3_Col - 1] == 0 && grid[block3_Row, block3_Col - 1] == 0)
                                {
                                    int[] blocks = new int[16] { block1_Row, block1_Col, block2_Row, block2_Col, block3_Row, block3_Col, block4_Row, block4_Col, gBlock1_Row, gBlock1_Col, gBlock2_Row, gBlock2_Col, gBlock3_Row, gBlock3_Col, gBlock4_Row, gBlock4_Col };
                                    ClearBlock(g, blocks);
                                    this.block1_Row += 2;
                                    this.block2_Row += 1;
                                    this.block2_Col -= 1;
                                    this.block4_Row -= 1;
                                    this.block4_Col -= 1;
                                    this.blockState = 4;
                                    DrawBlock(g);
                                    rotated = true;
                                }
                            }
                            catch
                            {
                                this.LOCK = false;
                                return false;
                            }
                        }
                        else if (this.blockState == 2)
                        {
                            //    State 2 to State 1
                            //  [ ][ ][X]    [X][X][ ]
                            //  [ ][X][X]    [ ][X][X]
                            //  [ ][X][ ]    [ ][ ][ ]
                            try
                            {
                                if (grid[block3_Row, block3_Col] == 0 && grid[block3_Row, block3_Col + 1] == 0 && grid[block3_Row - 1, block3_Col - 1] == 0 && grid[block3_Row - 1, block3_Col] == 0)
                                {
                                    int[] blocks = new int[16] { block1_Row, block1_Col, block2_Row, block2_Col, block3_Row, block3_Col, block4_Row, block4_Col, gBlock1_Row, gBlock1_Col, gBlock2_Row, gBlock2_Col, gBlock3_Row, gBlock3_Col, gBlock4_Row, gBlock4_Col };
                                    ClearBlock(g, blocks);
                                    this.block1_Col -= 2;
                                    this.block2_Row -= 1;
                                    this.block2_Col -= 1;
                                    this.block4_Row -= 1;
                                    this.block4_Col += 1;
                                    this.blockState = 1;
                                    DrawBlock(g);
                                    rotated = true;
                                }
                            }
                            catch
                            {
                                this.LOCK = false;
                                return false;
                            }
                        }
                        else if (this.blockState == 3)
                        {
                            //    State 3 to State 2
                            //  [ ][ ][ ]    [ ][ ][X]
                            //  [X][X][ ]    [ ][X][X]
                            //  [ ][X][X]    [ ][X][ ]
                            try
                            {
                                if (grid[block3_Row, block3_Col] == 0 && grid[block3_Row - 1, block3_Col] == 0 && grid[block3_Row, block3_Col + 1] == 0 && grid[block3_Row - 1, block3_Col + 1] == 0)
                                {
                                    int[] blocks = new int[16] { block1_Row, block1_Col, block2_Row, block2_Col, block3_Row, block3_Col, block4_Row, block4_Col, gBlock1_Row, gBlock1_Col, gBlock2_Row, gBlock2_Col, gBlock3_Row, gBlock3_Col, gBlock4_Row, gBlock4_Col };
                                    ClearBlock(g, blocks);
                                    this.block1_Row -= 2;
                                    this.block2_Row -= 1;
                                    this.block2_Col += 1;
                                    this.block4_Row += 1;
                                    this.block4_Col += 1;
                                    this.blockState = 2;
                                    DrawBlock(g);
                                    rotated = true;
                                }
                            }
                            catch
                            {
                                this.LOCK = false;
                                return false;
                            }
                        }
                        else if (this.blockState == 4)
                        {
                            //    State 4 to State 3
                            //  [ ][X][ ]    [ ][ ][ ]
                            //  [X][X][ ]    [X][X][ ]
                            //  [X][ ][ ]    [ ][X][X]
                            try
                            {
                                if (grid[block3_Row, block3_Col] == 0 && grid[block3_Row, block3_Col - 1] == 0 && grid[block3_Row + 1, block3_Col] == 0 && grid[block3_Row + 1, block3_Col + 1] == 0)
                                {
                                    int[] blocks = new int[16] { block1_Row, block1_Col, block2_Row, block2_Col, block3_Row, block3_Col, block4_Row, block4_Col, gBlock1_Row, gBlock1_Col, gBlock2_Row, gBlock2_Col, gBlock3_Row, gBlock3_Col, gBlock4_Row, gBlock4_Col };
                                    ClearBlock(g, blocks);
                                    this.block1_Col += 2;
                                    this.block2_Row += 1;
                                    this.block2_Col += 1;
                                    this.block4_Row += 1;
                                    this.block4_Col -= 1;
                                    this.blockState = 3;
                                    DrawBlock(g);
                                    rotated = true;
                                }
                            }
                            catch
                            {
                                this.LOCK = false;
                                return false;
                            }
                        }
                        break;
                    }
                #endregion
                #region case 2
                case 2:
                    {
                        //  Block 2
                        //  [ ][X][X]    [ ][X][ ]    [ ][ ][ ]    [X][ ][ ]
                        //  [X][X][ ]    [ ][X][X]    [ ][X][X]    [X][X][ ]
                        //  [ ][ ][ ]    [ ][ ][X]    [X][X][ ]    [ ][X][ ]
                        //   State 1      State 2      State 3      State 4
                        if (this.blockState == 1)
                        {
                            //    State 1 to State 4
                            //  [ ][X][X]    [X][ ][ ]
                            //  [X][X][ ]    [X][X][ ]
                            //  [ ][ ][ ]    [ ][X][ ]
                            try
                            {
                                if (grid[block3_Row, block3_Col] == 0 && grid[block3_Row, block3_Col - 1] == 0 && grid[block3_Row - 1, block3_Col - 1] == 0 && grid[block3_Row + 1, block3_Col] == 0)
                                {
                                    int[] blocks = new int[16] { block1_Row, block1_Col, block2_Row, block2_Col, block3_Row, block3_Col, block4_Row, block4_Col, gBlock1_Row, gBlock1_Col, gBlock2_Row, gBlock2_Col, gBlock3_Row, gBlock3_Col, gBlock4_Row, gBlock4_Col };
                                    ClearBlock(g, blocks);
                                    this.block1_Col -= 1;
                                    this.block1_Row += 1;
                                    this.block2_Col -= 2;
                                    this.block4_Row += 1;
                                    this.block4_Col += 1;
                                    this.blockState = 4;
                                    DrawBlock(g);
                                    rotated = true;
                                }
                            }
                            catch
                            {
                                this.LOCK = false;
                                return false;
                            }
                        }
                        else if (this.blockState == 2)
                        {
                            //    State 2 to State 1
                            //  [ ][X][ ]    [ ][X][X]
                            //  [ ][X][X]    [X][X][ ]
                            //  [ ][ ][X]    [ ][ ][ ]
                            try
                            {
                                if (grid[block3_Row, block3_Col] == 0 && grid[block3_Row - 1, block3_Col] == 0 && grid[block3_Row, block3_Col - 1] == 0 && grid[block3_Row - 1, block3_Col + 1] == 0)
                                {
                                    int[] blocks = new int[16] { block1_Row, block1_Col, block2_Row, block2_Col, block3_Row, block3_Col, block4_Row, block4_Col, gBlock1_Row, gBlock1_Col, gBlock2_Row, gBlock2_Col, gBlock3_Row, gBlock3_Col, gBlock4_Row, gBlock4_Col };
                                    ClearBlock(g, blocks);
                                    this.block1_Col -= 1;
                                    this.block1_Row -= 1;
                                    this.block2_Row -= 2;
                                    this.block4_Row += 1;
                                    this.block4_Col -= 1;
                                    this.blockState = 1;
                                    DrawBlock(g);
                                    rotated = true;
                                }
                            }
                            catch
                            {
                                this.LOCK = false;
                                return false;
                            }
                        }
                        else if (this.blockState == 3)
                        {
                            //    State 3 to State 2
                            //  [ ][ ][ ]    [ ][X][ ]
                            //  [ ][X][X]    [ ][X][X]
                            //  [X][X][ ]    [ ][ ][X]
                            try
                            {
                                if (grid[block3_Row, block3_Col] == 0 && grid[block3_Row, block3_Col + 1] == 0 && grid[block3_Row - 1, block3_Col] == 0 && grid[block3_Row + 1, block3_Col + 1] == 0)
                                {
                                    int[] blocks = new int[16] { block1_Row, block1_Col, block2_Row, block2_Col, block3_Row, block3_Col, block4_Row, block4_Col, gBlock1_Row, gBlock1_Col, gBlock2_Row, gBlock2_Col, gBlock3_Row, gBlock3_Col, gBlock4_Row, gBlock4_Col };
                                    ClearBlock(g, blocks);
                                    this.block1_Row -= 1;
                                    this.block1_Col += 1;
                                    this.block2_Col += 2;
                                    this.block4_Row -= 1;
                                    this.block4_Col -= 1;
                                    this.blockState = 2;
                                    DrawBlock(g);
                                    rotated = true;
                                }
                            }
                            catch
                            {
                                this.LOCK = false;
                                return false;
                            }
                        }
                        else if (this.blockState == 4)
                        {
                            //    State 4 to State 3
                            //  [X][ ][ ]    [ ][ ][ ]
                            //  [X][X][ ]    [ ][X][X]
                            //  [ ][X][ ]    [X][X][ ]
                            try
                            {
                                if (grid[block3_Row, block3_Col] == 0 && grid[block3_Row + 1, block3_Col] == 0 && grid[block3_Row + 1, block3_Col - 1] == 0 && grid[block3_Row, block3_Col + 1] == 0)
                                {
                                    int[] blocks = new int[16] { block1_Row, block1_Col, block2_Row, block2_Col, block3_Row, block3_Col, block4_Row, block4_Col, gBlock1_Row, gBlock1_Col, gBlock2_Row, gBlock2_Col, gBlock3_Row, gBlock3_Col, gBlock4_Row, gBlock4_Col };
                                    ClearBlock(g, blocks);
                                    this.block1_Col += 1;
                                    this.block1_Row += 1;
                                    this.block2_Row += 2;
                                    this.block4_Row -= 1;
                                    this.block4_Col += 1;
                                    this.blockState = 3;
                                    DrawBlock(g);
                                    rotated = true;
                                }
                            }
                            catch
                            {
                                this.LOCK = false;
                                return false;
                            }
                        }
                        break;
                    }
                #endregion
                #region Case 3
                case 3:
                    {
                        //  Block 3
                        //  [X][ ][ ]    [ ][X][X]    [ ][ ][ ]    [ ][X][ ]
                        //  [X][X][X]    [ ][X][ ]    [X][X][X]    [ ][X][ ]
                        //  [ ][ ][ ]    [ ][X][ ]    [ ][ ][X]    [X][X][ ]
                        //   State 1      State 2      State 3      State 4
                        if (this.blockState == 1)
                        {
                            //    State 1 to State 4
                            //  [X][ ][ ]    [ ][X][ ]
                            //  [X][X][X]    [ ][X][ ]
                            //  [ ][ ][ ]    [X][X][ ]
                            try
                            {
                                if (grid[block3_Row, block3_Col] == 0 && grid[block3_Row + 1, block3_Col - 1] == 0 && grid[block3_Row + 1, block3_Col] == 0 && grid[block3_Row - 1, block3_Col] == 0)
                                {
                                    int[] blocks = new int[16] { block1_Row, block1_Col, block2_Row, block2_Col, block3_Row, block3_Col, block4_Row, block4_Col, gBlock1_Row, gBlock1_Col, gBlock2_Row, gBlock2_Col, gBlock3_Row, gBlock3_Col, gBlock4_Row, gBlock4_Col };
                                    ClearBlock(g, blocks);
                                    this.block1_Row += 2;
                                    this.block2_Row += 1;
                                    this.block2_Col += 1;
                                    this.block4_Row -= 1;
                                    this.block4_Col -= 1;
                                    this.blockState = 4;
                                    DrawBlock(g);
                                    rotated = true;
                                }
                            }
                            catch
                            {
                                this.LOCK = false;
                                return false;
                            }
                        }
                        else if (this.blockState == 2)
                        {
                            //    State 2 to State 1
                            //  [ ][X][X]    [X][ ][ ]
                            //  [ ][X][ ]    [X][X][X]
                            //  [ ][X][ ]    [ ][ ][ ]
                            try
                            {
                                if (grid[block3_Row, block3_Col] == 0 && grid[block3_Row, block3_Col - 1] == 0 && grid[block3_Row - 1, block3_Col - 1] == 0 && grid[block3_Row, block3_Col + 1] == 0)
                                {
                                    int[] blocks = new int[16] { block1_Row, block1_Col, block2_Row, block2_Col, block3_Row, block3_Col, block4_Row, block4_Col, gBlock1_Row, gBlock1_Col, gBlock2_Row, gBlock2_Col, gBlock3_Row, gBlock3_Col, gBlock4_Row, gBlock4_Col };
                                    ClearBlock(g, blocks);
                                    this.block1_Col -= 2;
                                    this.block2_Row += 1;
                                    this.block2_Col -= 1;
                                    this.block4_Row -= 1;
                                    this.block4_Col += 1;
                                    this.blockState = 1;
                                    DrawBlock(g);
                                    rotated = true;
                                }
                            }
                            catch
                            {
                                this.LOCK = false;
                                return false;
                            }
                        }
                        else if (this.blockState == 3)
                        {
                            //    State 3 to State 2
                            //  [ ][ ][ ]    [ ][X][X]
                            //  [X][X][X]    [ ][X][ ]
                            //  [ ][ ][X]    [ ][X][ ]
                            try
                            {
                                if (grid[block3_Row, block3_Col] == 0 && grid[block3_Row - 1, block3_Col] == 0 && grid[block3_Row - 1, block3_Col + 1] == 0 && grid[block3_Row + 1, block3_Col] == 0)
                                {
                                    int[] blocks = new int[16] { block1_Row, block1_Col, block2_Row, block2_Col, block3_Row, block3_Col, block4_Row, block4_Col, gBlock1_Row, gBlock1_Col, gBlock2_Row, gBlock2_Col, gBlock3_Row, gBlock3_Col, gBlock4_Row, gBlock4_Col };
                                    ClearBlock(g, blocks);
                                    this.block1_Row -= 2;
                                    this.block2_Row -= 1;
                                    this.block2_Col -= 1;
                                    this.block4_Row += 1;
                                    this.block4_Col += 1;
                                    this.blockState = 2;
                                    DrawBlock(g);
                                    rotated = true;
                                }
                            }
                            catch
                            {
                                this.LOCK = false;
                                return false;
                            }
                        }
                        else if (this.blockState == 4)
                        {
                            //    State 4 to State 3
                            //  [ ][X][ ]    [ ][ ][ ]
                            //  [ ][X][ ]    [X][X][X]
                            //  [X][X][ ]    [ ][ ][X]
                            try
                            {
                                if (grid[block3_Row, block3_Col] == 0 && grid[block3_Row, block3_Col - 1] == 0 && grid[block3_Row + 1, block3_Col + 1] == 0 && grid[block3_Row, block3_Col + 1] == 0)
                                {
                                    int[] blocks = new int[16] { block1_Row, block1_Col, block2_Row, block2_Col, block3_Row, block3_Col, block4_Row, block4_Col, gBlock1_Row, gBlock1_Col, gBlock2_Row, gBlock2_Col, gBlock3_Row, gBlock3_Col, gBlock4_Row, gBlock4_Col };
                                    ClearBlock(g, blocks);
                                    this.block1_Col += 2;
                                    this.block2_Row -= 1;
                                    this.block2_Col += 1;
                                    this.block4_Row += 1;
                                    this.block4_Col -= 1;
                                    this.blockState = 3;
                                    DrawBlock(g);
                                    rotated = true;
                                }
                            }
                            catch
                            {
                                this.LOCK = false;
                                return false;
                            }
                        }
                        break;
                    }
                #endregion
                #region Case 4
                case 4:
                    {
                        //  Block 4
                        //  [ ][ ][X]    [ ][X][ ]    [ ][ ][ ]    [X][X][ ]
                        //  [X][X][X]    [ ][X][ ]    [X][X][X]    [ ][X][ ]
                        //  [ ][ ][ ]    [ ][X][X]    [X][ ][ ]    [ ][X][ ]
                        //   State 1      State 2      State 3      State 4
                        if (this.blockState == 1)
                        {
                            //    State 1 to State 4
                            //  [ ][ ][X]    [X][X][ ]
                            //  [X][X][X]    [ ][X][ ]
                            //  [ ][ ][ ]    [ ][X][ ]
                            try
                            {
                                if (grid[block3_Row, block3_Col] == 0 && grid[block3_Row - 1, block3_Col - 1] == 0 && grid[block3_Row - 1, block3_Col] == 0 && grid[block3_Row + 1, block3_Col] == 0)
                                {
                                    int[] blocks = new int[16] { block1_Row, block1_Col, block2_Row, block2_Col, block3_Row, block3_Col, block4_Row, block4_Col, gBlock1_Row, gBlock1_Col, gBlock2_Row, gBlock2_Col, gBlock3_Row, gBlock3_Col, gBlock4_Row, gBlock4_Col };
                                    ClearBlock(g, blocks);
                                    this.block1_Col -= 2;
                                    this.block2_Row += 1;
                                    this.block2_Col += 1;
                                    this.block4_Row -= 1;
                                    this.block4_Col -= 1;
                                    this.blockState = 4;
                                    DrawBlock(g);
                                    rotated = true;
                                }
                            }
                            catch
                            {
                                this.LOCK = false;
                                return false;
                            }
                        }
                        else if (this.blockState == 2)
                        {
                            //    State 2 to State 1
                            //  [ ][X][ ]    [ ][ ][X]
                            //  [ ][X][ ]    [X][X][X]
                            //  [ ][X][X]    [ ][ ][ ]
                            try
                            {
                                if (grid[block3_Row, block3_Col] == 0 && grid[block3_Row, block3_Col - 1] == 0 && grid[block3_Row, block3_Col + 1] == 0 && grid[block3_Row - 1, block3_Col + 1] == 0)
                                {
                                    int[] blocks = new int[16] { block1_Row, block1_Col, block2_Row, block2_Col, block3_Row, block3_Col, block4_Row, block4_Col, gBlock1_Row, gBlock1_Col, gBlock2_Row, gBlock2_Col, gBlock3_Row, gBlock3_Col, gBlock4_Row, gBlock4_Col };
                                    ClearBlock(g, blocks);
                                    this.block1_Row -= 2;
                                    this.block2_Row += 1;
                                    this.block2_Col -= 1;
                                    this.block4_Row -= 1;
                                    this.block4_Col += 1;
                                    this.blockState = 1;
                                    DrawBlock(g);
                                    rotated = true;
                                }
                            }
                            catch
                            {
                                this.LOCK = false;
                                return false;
                            }
                        }
                        else if (this.blockState == 3)
                        {
                            //    State 3 to State 2
                            //  [ ][ ][ ]    [ ][X][ ]
                            //  [X][X][X]    [ ][X][ ]
                            //  [X][ ][ ]    [ ][X][X]
                            try
                            {
                                if (grid[block3_Row, block3_Col] == 0 && grid[block3_Row - 1, block3_Col] == 0 && grid[block3_Row + 1, block3_Col] == 0 && grid[block3_Row + 1, block3_Col + 1] == 0)
                                {
                                    int[] blocks = new int[16] { block1_Row, block1_Col, block2_Row, block2_Col, block3_Row, block3_Col, block4_Row, block4_Col, gBlock1_Row, gBlock1_Col, gBlock2_Row, gBlock2_Col, gBlock3_Row, gBlock3_Col, gBlock4_Row, gBlock4_Col };
                                    ClearBlock(g, blocks);
                                    this.block1_Col += 2;
                                    this.block2_Row -= 1;
                                    this.block2_Col -= 1;
                                    this.block4_Row += 1;
                                    this.block4_Col += 1;
                                    this.blockState = 2;
                                    DrawBlock(g);
                                    rotated = true;
                                }
                            }
                            catch
                            {
                                this.LOCK = false;
                                return false;
                            }
                        }
                        else if (this.blockState == 4)
                        {
                            //    State 4 to State 3
                            //  [X][X][ ]    [ ][ ][ ]
                            //  [ ][X][ ]    [X][X][X]
                            //  [ ][X][ ]    [X][ ][ ]
                            try
                            {
                                if (grid[block3_Row, block3_Col] == 0 && grid[block3_Row, block3_Col - 1] == 0 && grid[block3_Row, block3_Col + 1] == 0 && grid[block3_Row + 1, block3_Col - 1] == 0)
                                {
                                    int[] blocks = new int[16] { block1_Row, block1_Col, block2_Row, block2_Col, block3_Row, block3_Col, block4_Row, block4_Col, gBlock1_Row, gBlock1_Col, gBlock2_Row, gBlock2_Col, gBlock3_Row, gBlock3_Col, gBlock4_Row, gBlock4_Col };
                                    ClearBlock(g, blocks);
                                    this.block1_Row += 2;
                                    this.block2_Row -= 1;
                                    this.block2_Col += 1;
                                    this.block4_Row += 1;
                                    this.block4_Col -= 1;
                                    this.blockState = 3;
                                    DrawBlock(g);
                                    rotated = true;
                                }
                            }
                            catch
                            {
                                this.LOCK = false;
                                return false;
                            }
                        }
                        break;
                    }
                #endregion
                #region Case 5
                case 5:
                    {
                        //  Block 5
                        //  [ ][X]  ]    [ ][X][ ]    [ ][ ][ ]    [ ][X][ ]
                        //  [X][X][X]    [ ][X][X]    [X][X][X]    [X][X][ ]
                        //  [ ][ ][ ]    [ ][X][ ]    [ ][X][ ]    [ ][X][ ]
                        //   State 1      State 2      State 3      State 4
                        if (this.blockState == 1)
                        {
                            //    State 1 to State 4
                            //  [ ][X][ ]    [ ][X][ ]
                            //  [X][X][X]    [X][X][ ]
                            //  [ ][ ][ ]    [ ][X][ ]
                            try
                            {
                                if (grid[block3_Row, block3_Col] == 0 && grid[block3_Row, block3_Col - 1] == 0 && grid[block3_Row - 1, block3_Col] == 0 && grid[block3_Row + 1, block3_Col] == 0)
                                {
                                    int[] blocks = new int[16] { block1_Row, block1_Col, block2_Row, block2_Col, block3_Row, block3_Col, block4_Row, block4_Col, gBlock1_Row, gBlock1_Col, gBlock2_Row, gBlock2_Col, gBlock3_Row, gBlock3_Col, gBlock4_Row, gBlock4_Col };
                                    ClearBlock(g, blocks);
                                    this.block1_Row += 1;
                                    this.block1_Col -= 1;
                                    this.block2_Row += 1;
                                    this.block2_Col += 1;
                                    this.block4_Row -= 1;
                                    this.block4_Col -= 1;
                                    this.blockState = 4;
                                    DrawBlock(g);
                                    rotated = true;
                                }
                            }
                            catch
                            {
                                this.LOCK = false;
                                return false;
                            }
                        }
                        else if (this.blockState == 2)
                        {
                            //    State 2 to State 1
                            //  [ ][X][ ]    [ ][X][ ]
                            //  [ ][X][X]    [X][X][X]
                            //  [ ][X][ ]    [ ][ ][ ]
                            try
                            {
                                if (grid[block3_Row, block3_Col] == 0 && grid[block3_Row - 1, block3_Col] == 0 && grid[block3_Row, block3_Col + 1] == 0 && grid[block3_Row, block3_Col - 1] == 0)
                                {
                                    int[] blocks = new int[16] { block1_Row, block1_Col, block2_Row, block2_Col, block3_Row, block3_Col, block4_Row, block4_Col, gBlock1_Row, gBlock1_Col, gBlock2_Row, gBlock2_Col, gBlock3_Row, gBlock3_Col, gBlock4_Row, gBlock4_Col };
                                    ClearBlock(g, blocks);
                                    this.block1_Row -= 1;
                                    this.block1_Col -= 1;
                                    this.block2_Row += 1;
                                    this.block2_Col -= 1;
                                    this.block4_Row -= 1;
                                    this.block4_Col += 1;
                                    this.blockState = 1;
                                    DrawBlock(g);
                                    rotated = true;
                                }
                            }
                            catch
                            {
                                this.LOCK = false;
                                return false;
                            }
                        }
                        else if (this.blockState == 3)
                        {
                            //    State 3 to State 2
                            //  [ ][ ][ ]    [ ][X][ ]
                            //  [X][X][X]    [ ][X][X]
                            //  [ ][X][ ]    [ ][X][ ]
                            try
                            {
                                if (grid[block3_Row, block3_Col] == 0 && grid[block3_Row, block3_Col + 1] == 0 && grid[block3_Row + 1, block3_Col] == 0 && grid[block3_Row - 1, block3_Col] == 0)
                                {
                                    int[] blocks = new int[16] { block1_Row, block1_Col, block2_Row, block2_Col, block3_Row, block3_Col, block4_Row, block4_Col, gBlock1_Row, gBlock1_Col, gBlock2_Row, gBlock2_Col, gBlock3_Row, gBlock3_Col, gBlock4_Row, gBlock4_Col };
                                    ClearBlock(g, blocks);
                                    this.block1_Row -= 1;
                                    this.block1_Col += 1;
                                    this.block2_Row -= 1;
                                    this.block2_Col -= 1;
                                    this.block4_Row += 1;
                                    this.block4_Col += 1;
                                    this.blockState = 2;
                                    DrawBlock(g);
                                    rotated = true;
                                }
                            }
                            catch
                            {
                                this.LOCK = false;
                                return false;
                            }
                        }
                        else if (this.blockState == 4)
                        {
                            //    State 4 to State 3
                            //  [ ][X][ ]    [ ][ ][ ]
                            //  [X][X][ ]    [X][X][X]
                            //  [ ][X][ ]    [ ][X][ ]
                            try
                            {
                                if (grid[block3_Row, block3_Col] == 0 && grid[block3_Row + 1, block3_Col] == 0 && grid[block3_Row, block3_Col - 1] == 0 && grid[block3_Row, block3_Col + 1] == 0)
                                {
                                    int[] blocks = new int[16] { block1_Row, block1_Col, block2_Row, block2_Col, block3_Row, block3_Col, block4_Row, block4_Col, gBlock1_Row, gBlock1_Col, gBlock2_Row, gBlock2_Col, gBlock3_Row, gBlock3_Col, gBlock4_Row, gBlock4_Col };
                                    ClearBlock(g, blocks);
                                    this.block1_Row += 1;
                                    this.block1_Col += 1;
                                    this.block2_Row -= 1;
                                    this.block2_Col += 1;
                                    this.block4_Row += 1;
                                    this.block4_Col -= 1;
                                    this.blockState = 3;
                                    DrawBlock(g);
                                    rotated = true;
                                }
                            }
                            catch
                            {
                                this.LOCK = false;
                                return false;
                            }
                        }
                        break;
                    }
                #endregion
                #region Case 6
                case 6:
                    {
                        //Does Not Rotate
                        break;
                    }
                #endregion
                #region Case 7
                case 7:
                    {
                        //  Block 7
                        //  [ ][ ][X][ ]    [ ][ ][ ][ ]    [ ][X][ ][ ]    [ ][ ][ ][ ]
                        //  [ ][ ][X][ ]    [ ][ ][ ][ ]    [ ][X][ ][ ]    [X][X][X][X]
                        //  [ ][ ][X][ ]    [X][X][X][X]    [ ][X][ ][ ]    [ ][ ][ ][ ]
                        //  [ ][ ][X][ ]    [ ][ ][ ][ ]    [ ][X][ ][ ]    [ ][ ][ ][ ]
                        //     State 1         State 2         State 3         State 4
                        if (this.blockState == 1)
                        {
                            //       State 1 to State 4
                            //  [ ][ ][X][ ]    [ ][ ][ ][ ]
                            //  [ ][ ][X][ ]    [X][X][X][X]
                            //  [ ][ ][X][ ]    [ ][ ][ ][ ]
                            //  [ ][ ][X][ ]    [ ][ ][ ][ ]
                            try
                            {
                                if (grid[block1_Row + 1, block1_Col - 2] == 0 && grid[block2_Row, block2_Col - 1] == 0 && grid[block3_Row - 1, block3_Col ] == 0 && grid[block4_Row - 2, block4_Col + 1] == 0)
                                {
                                    int[] blocks = new int[16] { block1_Row, block1_Col, block2_Row, block2_Col, block3_Row, block3_Col, block4_Row, block4_Col, gBlock1_Row, gBlock1_Col, gBlock2_Row, gBlock2_Col, gBlock3_Row, gBlock3_Col, gBlock4_Row, gBlock4_Col };
                                    ClearBlock(g, blocks);
                                    this.block1_Row += 1;
                                    this.block1_Col -= 2;
                                    this.block2_Col -= 1;
                                    this.block3_Row -= 1;
                                    this.block4_Row -= 2;
                                    this.block4_Col += 1;
                                    this.blockState = 4;
                                    DrawBlock(g);
                                    rotated = true;
                                }
                            }
                            catch
                            {
                                this.LOCK = false;
                                return false;
                            }
                        }
                        else if (this.blockState == 2)
                        {
                            //       State 2 to State 1
                            //  [ ][ ][ ][ ]    [ ][ ][X][ ]
                            //  [ ][ ][ ][ ]    [ ][ ][X][ ]
                            //  [X][X][X][X]    [ ][ ][X][ ]
                            //  [ ][ ][ ][ ]    [ ][ ][X][ ]
                            try
                            {
                                if (grid[block1_Row - 2, block1_Col - 1] == 0 && grid[block2_Row - 1, block2_Col] == 0 && grid[block3_Row - 1, block3_Col + 1] == 0 && grid[block4_Row + 1, block4_Col + 2] == 0)
                                {
                                    int[] blocks = new int[16] { block1_Row, block1_Col, block2_Row, block2_Col, block3_Row, block3_Col, block4_Row, block4_Col, gBlock1_Row, gBlock1_Col, gBlock2_Row, gBlock2_Col, gBlock3_Row, gBlock3_Col, gBlock4_Row, gBlock4_Col };
                                    ClearBlock(g, blocks);
                                    this.block1_Row -= 2;
                                    this.block1_Col -= 1;
                                    this.block2_Row -= 1;
                                    this.block3_Col += 1;
                                    this.block4_Row += 1;
                                    this.block4_Col += 2;
                                    this.blockState = 1;
                                    DrawBlock(g);
                                    rotated = true;
                                }
                            }
                            catch
                            {
                                this.LOCK = false;
                                return false;
                            }
                        }
                        else if (this.blockState == 3)
                        {
                            //       State 3 to State 2
                            //  [ ][X][ ][ ]    [ ][ ][ ][ ]
                            //  [ ][X][ ][ ]    [ ][ ][ ][ ]
                            //  [ ][X][ ][ ]    [X][X][X][X]
                            //  [ ][X][ ][ ]    [ ][ ][ ][ ]
                            try
                            {
                                if (grid[block1_Row - 1, block1_Col + 2] == 0 && grid[block2_Row, block2_Col + 1] == 0 && grid[block3_Row + 1, block3_Col] == 0 && grid[block4_Row + 2, block4_Col - 1] == 0)
                                {
                                    int[] blocks = new int[16] { block1_Row, block1_Col, block2_Row, block2_Col, block3_Row, block3_Col, block4_Row, block4_Col, gBlock1_Row, gBlock1_Col, gBlock2_Row, gBlock2_Col, gBlock3_Row, gBlock3_Col, gBlock4_Row, gBlock4_Col };
                                    ClearBlock(g, blocks);
                                    this.block1_Row -= 1;
                                    this.block1_Col += 2;
                                    this.block2_Col += 1;
                                    this.block3_Row += 1;
                                    this.block4_Row += 2;
                                    this.block4_Col -= 1;
                                    this.blockState = 2;
                                    DrawBlock(g);
                                    rotated = true;
                                }
                            }
                            catch
                            {
                                this.LOCK = false;
                                return false;
                            }
                        }
                        else if (this.blockState == 4)
                        {
                            //       State 4 to State 3
                            //  [ ][ ][ ][ ]    [ ][X][ ][ ]
                            //  [X][X][X][X]    [ ][X][ ][ ]
                            //  [ ][ ][ ][ ]    [ ][X][ ][ ]
                            //  [ ][ ][ ][ ]    [ ][X][ ][ ]
                            try
                            {
                                if (grid[block1_Row + 2, block1_Col + 1] == 0 && grid[block2_Row + 1, block2_Col] == 0 && grid[block3_Row, block3_Col - 1] == 0 && grid[block4_Row - 1, block4_Col -2 ] == 0)
                                {
                                    int[] blocks = new int[16] { block1_Row, block1_Col, block2_Row, block2_Col, block3_Row, block3_Col, block4_Row, block4_Col, gBlock1_Row, gBlock1_Col, gBlock2_Row, gBlock2_Col, gBlock3_Row, gBlock3_Col, gBlock4_Row, gBlock4_Col };
                                    ClearBlock(g, blocks);
                                    this.block1_Row += 2;
                                    this.block1_Col += 1;
                                    this.block2_Row += 1;
                                    this.block3_Col -= 1;
                                    this.block4_Row -= 1;
                                    this.block4_Col -= 2;
                                    this.blockState = 3;
                                    DrawBlock(g);
                                    rotated = true;
                                }
                            }
                            catch
                            {
                                this.LOCK = false;
                                return false;
                            }
                        }
                        break;
                    }
                #endregion
            }
            LOCK = false;
            return rotated;
        }
            #endregion
        #endregion
        #region Block Painting
        private void ClearBlock(Graphics g, int[] blocks)
        {
            
            Pen color = new Pen(Color.MediumSlateBlue);
            SolidBrush brush = new SolidBrush(Color.MediumSlateBlue);
            g.DrawRectangle(color, (blocks[1] * 35) + 1, (blocks[0] * 35) + 1, 34, 34);
            g.FillRectangle(brush, (blocks[1] * 35) + 1, (blocks[0] * 35) + 1, 34, 34);
            g.DrawRectangle(color, (blocks[3] * 35) + 1, (blocks[2] * 35) + 1, 34, 34);
            g.FillRectangle(brush, (blocks[3] * 35) + 1, (blocks[2] * 35) + 1, 34, 34);
            g.DrawRectangle(color, (blocks[5] * 35) + 1, (blocks[4] * 35) + 1, 34, 34);
            g.FillRectangle(brush, (blocks[5] * 35) + 1, (blocks[4] * 35) + 1, 34, 34);
            g.DrawRectangle(color, (blocks[7] * 35) + 1, (blocks[6] * 35) + 1, 34, 34);
            g.FillRectangle(brush, (blocks[7] * 35) + 1, (blocks[6] * 35) + 1, 34, 34);
            //Ghost Block
            g.DrawRectangle(color, (blocks[9] * 35) + 1, (blocks[8] * 35) + 1, 34, 34);
            g.FillRectangle(brush, (blocks[9] * 35) + 1, (blocks[8] * 35) + 1, 34, 34);
            g.DrawRectangle(color, (blocks[11] * 35) + 1, (blocks[10] * 35) + 1, 34, 34);
            g.FillRectangle(brush, (blocks[11] * 35) + 1, (blocks[10] * 35) + 1, 34, 34);
            g.DrawRectangle(color, (blocks[13] * 35) + 1, (blocks[12] * 35) + 1, 34, 34);
            g.FillRectangle(brush, (blocks[13] * 35) + 1, (blocks[12] * 35) + 1, 34, 34);
            g.DrawRectangle(color, (blocks[15] * 35) + 1, (blocks[14] * 35) + 1, 34, 34);
            g.FillRectangle(brush, (blocks[15] * 35) + 1, (blocks[14] * 35) + 1, 34, 34);
        }

        public void DrawBlock(Graphics g)
        {
            //Ghost Block
            findGhostBlock();
            Pen color = new Pen(Color.White, 1);
            SolidBrush brush = new SolidBrush(Color.Teal);
            g.DrawRectangle(color, (gBlock1_Col * 35) + 1, (gBlock1_Row * 35) + 1, 34, 34);
            g.FillRectangle(brush, (gBlock1_Col * 35) + 1, (gBlock1_Row * 35) + 1, 34, 34);
            g.DrawRectangle(color, (gBlock2_Col * 35) + 1, (gBlock2_Row * 35) + 1, 34, 34);
            g.FillRectangle(brush, (gBlock2_Col * 35) + 1, (gBlock2_Row * 35) + 1, 34, 34);
            g.DrawRectangle(color, (gBlock3_Col * 35) + 1, (gBlock3_Row * 35) + 1, 34, 34);
            g.FillRectangle(brush, (gBlock3_Col * 35) + 1, (gBlock3_Row * 35) + 1, 34, 34);
            g.DrawRectangle(color, (gBlock4_Col * 35) + 1, (gBlock4_Row * 35) + 1, 34, 34);
            g.FillRectangle(brush, (gBlock4_Col * 35) + 1, (gBlock4_Row * 35) + 1, 34, 34);
            //Block
            color = new Pen(Color.White, 1);
            brush = new SolidBrush(PenColors[blockNum]);
            g.DrawRectangle(color, (block1_Col * 35) + 1, (block1_Row * 35) + 1, 34, 34);
            g.FillRectangle(brush, (block1_Col * 35) + 1, (block1_Row * 35) + 1, 34, 34);
            g.DrawRectangle(color, (block2_Col * 35) + 1, (block2_Row * 35) + 1, 34, 34);
            g.FillRectangle(brush, (block2_Col * 35) + 1, (block2_Row * 35) + 1, 34, 34);
            g.DrawRectangle(color, (block3_Col * 35) + 1, (block3_Row * 35) + 1, 34, 34);
            g.FillRectangle(brush, (block3_Col * 35) + 1, (block3_Row * 35) + 1, 34, 34);
            g.DrawRectangle(color, (block4_Col * 35) + 1, (block4_Row * 35) + 1, 34, 34);
            g.FillRectangle(brush, (block4_Col * 35) + 1, (block4_Row * 35) + 1, 34, 34);
        }
        #endregion
    }
}