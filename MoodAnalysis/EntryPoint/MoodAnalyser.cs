﻿using MoodAnalysis.FactoryPattern;
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
                    throw new MoodAnalyserException(MoodAnalyserException.TypeOfException.EMPTY_STRING_EXCEPTION, "Message Can Not Be Empty");
                }
                else if(message == null)
                {
                    throw new MoodAnalyserException(MoodAnalyserException.TypeOfException.NULL_POINTER_EXCEPTION, "Null Value");
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
            catch (Exception e)
            {
               return e.Message;
            }           
        }
    }
}
