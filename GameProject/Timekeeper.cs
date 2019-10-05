using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    public class Timekeeper
    {
        public DateTime gameStart { get; set; }
        public DateTime gameEnd { get; set; }
        public TimeSpan gameTime { get; set; }
        public TimeSpan beginner { get; set; }
        public TimeSpan intermediate { get; set; }
        public TimeSpan expert { get; set; }

        public void startTimer()
        {
            gameStart = DateTime.Now;
        }

        public void stopTimer()
        {
            gameEnd = DateTime.Now;
        }

        public TimeSpan deltaTime()
        {
            return DateTime.Now - gameStart;
        }

        public TimeSpan getGameTime()
        {
            return gameEnd - gameStart;
        }

        public void logTime(int level, Timekeeper timer)
        {
            string key = "";
            string time = "";

            TimeSpan gameTime = timer.getGameTime();

            switch (level)
            {
                case 1:
                    key = "beginnerScore";
                    break;
                case 2:
                    key = "intermediateScore";
                    break;
                case 3:
                    key = "expertScore";
                    break;
                default:
                    key = "defaultScore";
                    break;
            }

            //Convert the time into a string with a standardized format of hh:mm:ss
            time = $"{standardize(gameTime.Hours)}:{standardize(gameTime.Minutes)}:{standardize(gameTime.Seconds)}";
            
            if (compareTimes(time, Properties.Highscores.Default[key].ToString()))
            {
                Properties.Highscores.Default[key] = time;
                Properties.Highscores.Default.Save();
            }
        }

        //Ensures that the returned string contans a two-digit representation of the value passed
        private string standardize(int i)
        {
            return i < 10 ? "0" + i : i.ToString();
        }

        //Compares two strings to determine if the time encoded in t1 is less than that in t2.
        //Times are expected as positive integer values separated by : in the form hh:mm:ss
        private bool compareTimes(string t1, string t2)
        {
            //Is either empty?
            if (t1 == "" || t1 == null || t2 == null || t2 == "")
            {
                return false;
            }

            //Are they identical?
            if (t1.Equals(t2))
            {
                return false;
            }

            //Is there no previous time set?
            if (t2 == "00:00:00")
            {
                return true;
            }

            //Split the strings for comparison
            string[] sub1 = t1.Split(':');
            string[] sub2 = t2.Split(':');

            if (int.Parse(sub1[0]) <= int.Parse(sub2[0]))
            {
                if (int.Parse(sub1[1]) <= int.Parse(sub2[1]))
                {
                    if (int.Parse(sub1[2]) < int.Parse(sub2[2]))
                        return true;
                }
            }

             return false;
        }
    }
}
