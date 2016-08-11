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

namespace Tetris
{
    public partial class HighScoresForm : Form
    {
        public HighScoresForm(HighScores scoresPassedIn)
        {
            InitializeComponent();

            this.highScores_TextBox.Text = scoresPassedIn.ToString();
        }
    }
}