using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalysis
{
    public class MoodAnalyserException : Exception
    {
        public string message;
       public enum TypeOfException
        {
            NULL_POINTER_EXCEPTION,EMPTY_STRING_EXCEPTION, NO_CLASS_FOUND
        }


        public TypeOfException exceptionType;
        private TypeOfException eMPTY_STRING_EXCEPTION;
        private string v;

        public MoodAnalyserException(TypeOfException typeOfException, string message) : base(message)
        {
            this.exceptionType = exceptionType;
            this.message = message;
        }

       
    }
}
