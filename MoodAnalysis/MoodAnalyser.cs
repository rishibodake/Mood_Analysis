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
                if(message.Length == 0)
                {
                    throw new MoodAnalyserException("Message Can Not Be Empty");
                }
                else if (message.ToLower().Contains("sad"))
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
                throw new MoodAnalyserException("Null Pointer");
            }
            
        }
    }
}
