using System;
using System.Reflection;


namespace MoodAnalysis.FactoryPattern
{
    public class MoodAnalyserFactory<E>
    {
        public ConstructorInfo ConstructorCreator()
        {
            try
            {
                Type type = typeof(E);               
                ConstructorInfo[] constructor = type.GetConstructors();
                return constructor[0];
            }
            catch (MoodAnalyserException)
            {
                throw new MoodAnalyserException(MoodAnalyserException.TypeOfException.NO_CLASS_FOUND, "No such class found");
            }
        }

        public ConstructorInfo ConstructorCreator(string className)
        {
            try
            {
                Type type = Type.GetType(className);
                ConstructorInfo[] constructor = type.GetConstructors();
                return constructor[1];
            }
            catch (MoodAnalyserException)
            {
                throw new MoodAnalyserException(MoodAnalyserException.TypeOfException.NO_CLASS_FOUND, "No such class found");
            }
        }

        public ConstructorInfo ConstructorCreator(int numberOfParameters)
        {
            try
            {
                Type type = typeof(E);
                
                ConstructorInfo[] constructor = type.GetConstructors();
                foreach(ConstructorInfo index in constructor)
                {
                    int numberOfParam = index.GetParameters().Length;                   
                    while(numberOfParam == numberOfParameters)
                    {
                        return index;
                    }
                }
                return constructor[0];
            }
            catch (MoodAnalyserException)
            {
                throw new MoodAnalyserException(MoodAnalyserException.TypeOfException.NO_CLASS_FOUND, "No such class found");
            }
        }
     

        public object InstanceCreator(string className, ConstructorInfo constructor)
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
                E reflectionGenratedObject = Activator.CreateInstance<E>();               
                return reflectionGenratedObject;
            }
            catch (MoodAnalyserException e)
            {
              
                return e.Message;
            }
            
        }

        public object InstanceCreator(string className, ConstructorInfo constructor,string message)
        {
            try
            {
                Type type = typeof(E);
                if (className != type.Name)
                {
                    throw new MoodAnalyserException(MoodAnalyserException.TypeOfException.NO_CLASS_FOUND, "No such class found");
                }
                if (constructor != type.GetConstructors()[1])
                {
                    throw new MoodAnalyserException(MoodAnalyserException.TypeOfException.NO_CONSTRUCTOR_FOUND, "No such method found");
                }
                object reflectionGenratedObject = Activator.CreateInstance(type,message);
                return reflectionGenratedObject;
            }
            catch (MoodAnalyserException e)
            {

                return e.Message;
            }
        }

        public object CallTheMethod(string currntMood)
        {
            MoodAnalyser analyser = new MoodAnalyser(currntMood);
            object generatedObject = analyser.AnalyseMood();
            return generatedObject;
        }

    }
}


