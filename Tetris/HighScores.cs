using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    [Serializable]
    public class HighScores
    {
        #region HighScoreEntry(Nested Class) [Serializable]
        [Serializable]
        public class HighScoreEntry : IComparable
        {
            public int score { get; set; }
            public String name { get; set; }

            public HighScoreEntry(int scorePassedIn, String namePassedIn)
            {
                this.score = scorePassedIn;
                this.name = namePassedIn;
            }

            public override String ToString()
            {
                String result = String.Format("{0, 15:N0} {1,15}", this.score, this.name);
                return result;
            }

            public int CompareTo(Object obj)
            {
                if (obj == null)
                {
                    return 1;
                }
                HighScoreEntry passedInEntry = obj as HighScoreEntry;
                if (passedInEntry != null)
                    return this.score.CompareTo(passedInEntry.score);
                else
                    throw new ArgumentException("Object is not a HighScoreEntry");
            }
        }
        #endregion
        
        private HighScoreEntry[] highScores;

        public HighScores()
        {
            this.highScores = new HighScoreEntry[10];
        }

        public Boolean NewHighScore(int score)
        {
            return score > highScores[9].score;
        }

        public Boolean AddNewHighScore(String name, int score)
        {
            Boolean added = false;
            HighScoreEntry newHighScore = new HighScoreEntry(score, name);
            if(highScores.Length < 10)
            {
                this.highScores[this.highScores.Length - 1] = newHighScore;
                added = true;
            }
            else if (highScores.Length == 10)
            {
                Array.Sort(highScores);
                this.highScores[0] = newHighScore;
                added = true;
            }
            Array.Sort(this.highScores);
            Array.Reverse(this.highScores);
            return added;
        }

        public override string ToString()
        {
            String result = "";

            result = result + "  1 : " + this.highScores[0] + "\n";
            result = result + "  2 : " + this.highScores[1] + "\n";
            result = result + "  3 : " + this.highScores[2] + "\n";
            result = result + "  4 : " + this.highScores[3] + "\n";
            result = result + "  5 : " + this.highScores[4] + "\n";
            result = result + "  6 : " + this.highScores[5] + "\n";
            result = result + "  7 : " + this.highScores[6] + "\n";
            result = result + "  8 : " + this.highScores[7] + "\n";
            result = result + "  9 : " + this.highScores[8] + "\n";
            result = result + "10 : " + this.highScores[9];

            return result;
        }
    }
}