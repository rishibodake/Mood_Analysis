using System;
using System.Reflection;


namespace MoodAnalysis.FactoryPattern
{
    public class MoodAnalyserFactory<E>
    {
        public ConstructorInfo ConstructorChecker()
        {
            try
            {
                Type type = typeof(E);                
                ConstructorInfo[] constructor = type.GetConstructors();
                return constructor[0];
            }
            catch (Exception e)
            {
                throw new MoodAnalyserException(MoodAnalyserException.TypeOfException.NO_CLASS_FOUND, "No such class found");
            }
        }

        public object InstanceChecker(string className, ConstructorInfo constructor)
        {
            try
            {
                Type type = typeof(E);              
                if (className != type.Name)
                {
                    throw new MoodAnalyserException(MoodAnalyserException.TypeOfException.NO_CLASS_FOUND, "No such class found");
                }
                if (constructor != type.GetConstructors()[0])
                {
                    throw new MoodAnalyserException(MoodAnalyserException.TypeOfException.NO_CONSTRUCTOR_FOUND, "No such method found");
                }
                E ReturnObject = Activator.CreateInstance<E>();               
                return ReturnObject;
            }
            catch (MoodAnalyserException e)
            {
                return e.Message;
            }
        }
    }
}


