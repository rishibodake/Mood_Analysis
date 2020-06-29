using System;

namespace MoodAnalysis
{
    public class MoodAnalyser
    {
        static void Main(string[] args)
        {
            
        }

        public string AnalyseMood(string message)
        {
            if (message.ToLower().Contains("sad"))
            {
                return "SAD";
            }
            else if(message.ToLower().Contains("happy"))
            {
                return "HAPPY";
            }
            else
            {
                return "Not Sure About Mood";
            }
        }
    }
}
