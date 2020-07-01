﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalysis
{
    public class MoodAnalyserException : Exception
    {
       public string message;
       public enum TypeOfException
       {
            NULL_POINTER_EXCEPTION,EMPTY_STRING_EXCEPTION, NO_CLASS_FOUND, NO_CONSTRUCTOR_FOUND,OBJECT_NOT_CREATED,
            NO_CONSTRUCTOR_WITH_SUCH_PARAMETER

        }


        public TypeOfException exceptionType;
       

        public MoodAnalyserException(TypeOfException typeOfException, string message) : base(message)
        {
            
            this.message = message;
        }

       
    }
}
