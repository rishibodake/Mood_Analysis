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
            else
            {
                return "Not Sad For Sure";
            }
        }
    }
}
