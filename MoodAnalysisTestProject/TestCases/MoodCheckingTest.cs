using MoodAnalysis;
using MoodAnalysis.FactoryPattern;
using NUnit.Framework;
using System;
using System.Reflection;

namespace MoodAnalysisTestProject
{
    public class MoodCheckingTest
    {
        MoodAnalyser analyser;
        [OneTimeSetUp]
        public void Setup()
        {
            analyser = new MoodAnalyser();
        }

        [Test]
        public void Test_For_Sad_Mood_Test()
        {
            string message = "I Am So Sad ";
            string currentMood = "SAD";
            string result = analyser.AnalyseMood(message);           
            Assert.AreEqual(currentMood, result);
        }

        [Test]
        public void Test_For_Happy_Mood_Test()
        {
            string message = "I Am So Happy";
            string currentMood = "HAPPY";
            string result = analyser.AnalyseMood(message);         
            Assert.AreEqual(currentMood, result);
        }

        [Test]
        public void Test_For_Null_Response_Test()
        {
            try
            {
                string result = analyser.AnalyseMood(null);              
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(MoodAnalyserException.TypeOfException.NULL_POINTER_EXCEPTION, e.exceptionType);
            }
        }

        [Test]
        public void Test_For_Empty_Message_Test()
        {
            try
            {
                string result = analyser.AnalyseMood("");               
            }
            catch(MoodAnalyserException e)
            {
                Assert.AreEqual (MoodAnalyserException.TypeOfException.EMPTY_STRING_EXCEPTION,e.exceptionType);
            }
        }

        [Test]
        public void Mood_Analyser_Contructor_Checker_Test()
        {
            string className = "MoodAnalyser";
            MoodAnalyserFactory<MoodAnalyser> factory = new MoodAnalyserFactory<MoodAnalyser>();
            ConstructorInfo constrInfo = factory.ConstructorCreator();
            object instanceOfClass = factory.InstanceCreator(className, constrInfo);
            Assert.IsInstanceOf(typeof(MoodAnalyser), instanceOfClass);
        }

        [Test]
        public void Improper_Class_Haandeling_Test()
        {
            try
            {
                string imProperClassName = "Mood";
                MoodAnalyserFactory<MoodAnalyser> factory = new MoodAnalyserFactory<MoodAnalyser>();
                ConstructorInfo constrInfo = factory.ConstructorCreator();
                object instanceOfClass = factory.InstanceCreator(imProperClassName, constrInfo);                
            }
            catch(MoodAnalyserException e)
            {
                Assert.AreEqual(MoodAnalyserException.TypeOfException.NO_CLASS_FOUND, e.exceptionType);
            }
        }

        [Test]
        public void Improper_Constructor_Haandeling_Test()
        {
            try
            {
                string constructorOfClass = "MoodAnalysis.MoodAnalyserException";
                string className = "MoodAnalyser";
                MoodAnalyserFactory<MoodAnalyser> factory = new MoodAnalyserFactory<MoodAnalyser>();
                ConstructorInfo constrInfo = factory.ConstructorCreator(constructorOfClass);
                object instanceOfClass = factory.InstanceCreator(className, constrInfo);
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(MoodAnalyserException.TypeOfException.NO_CONSTRUCTOR_FOUND, e.exceptionType);
            }
        }

        [Test]
        public void Mood_Analyser_Parameterised_Constructor_Check_Test()
        {
            string message = "here i am in sad mood";
            string className = "MoodAnalyser";
            MoodAnalyser analysis = new MoodAnalyser(message);
            MoodAnalyserFactory<MoodAnalyser> factory = new MoodAnalyserFactory<MoodAnalyser>();
            ConstructorInfo constrInfo = factory.ConstructorCreator(1);
            object instanceOfClass = factory.InstanceCreator(className, constrInfo, message);
            Assert.IsInstanceOf(typeof(MoodAnalyser), instanceOfClass);
        }

        [Test]
        public void Improper_Class_Name_For_Parametersed_Constructor_Test()
        {
            try
            {
                string message = "here i am in happy mood";
                string className = "Mood";
                MoodAnalyser analysis = new MoodAnalyser(message);
                MoodAnalyserFactory<MoodAnalyser> factory = new MoodAnalyserFactory<MoodAnalyser>();
                ConstructorInfo constrInfo = factory.ConstructorCreator(1);
                object instanceOfClass = factory.InstanceCreator(className, constrInfo,message);               
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(MoodAnalyserException.TypeOfException.NO_CLASS_FOUND, e.exceptionType);
            }
        }

        [Test]
        public void Improper_Constructor_For_Parameterised_Constructor_Test()
        {
            try
            {
                string message = "here i am in happy mood";
                string imProperConstructor = "MoodAnalysis.MoodAnalyser";
                string className = "MoodAnalyser";
                MoodAnalyser analysis = new MoodAnalyser(message);
                MoodAnalyserFactory<MoodAnalyser> factory = new MoodAnalyserFactory<MoodAnalyser>();
                ConstructorInfo constrInfo = factory.ConstructorCreator(imProperConstructor);
                object instanceOfClass = factory.InstanceCreator(className, constrInfo, message);               
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(MoodAnalyserException.TypeOfException.NO_CONSTRUCTOR_FOUND, e.exceptionType);
            }
        }

        [Test]
        public void Call_Method_Using_Reflection_Test()
        {
            string latestMood = "HAPPY";
            MoodAnalyserFactory<MoodAnalyser> factory = new MoodAnalyserFactory<MoodAnalyser>();
            object genratedObject = factory.CallTheMethod(latestMood);
            Assert.AreEqual(latestMood, genratedObject);
        }


    }
}