using System;

namespace MoodAnalysis
{
    public class MoodAnalyser
    {
        static void Main(string[] args)
        {
        }
        public MoodAnalyser()
        {

        }

        public string AnalyseMood(string message)
        {
            try
            {
                if (message.ToLower().Contains("sad"))
                {
                    return "SAD";
                }
                else if (message.ToLower().Contains("happy"))
                {
                    return "HAPPY";
                }
                else
                {
                    return "Not Sure About Mood";
                }
            }
            catch (NullReferenceException e)
            {
                return "HAPPY";
            }
            
        }
    }
}
