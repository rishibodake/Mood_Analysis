using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalysis
{
    public class MoodAnalyserException : Exception
    {
        enum Check
        {

        }
        public MoodAnalyserException(string message) : base(message)
        {
        }

        public MoodAnalyserException(string message, Exception innerException) : base(message, innerException)
        {
            
        }
    }
}
