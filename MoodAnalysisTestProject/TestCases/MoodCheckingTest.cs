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
            string result = analyser.AnalyseMood("I Am So Sad ");
            string mood = "SAD";
            Assert.AreEqual(mood, result);
        }

        [Test]
        public void Test_For_Happy_Mood_Test()
        {
            string result = analyser.AnalyseMood("I am Happy");
            string mood = "HAPPY";
            Assert.AreEqual(mood, result);
        }

        [Test]
        public void Test_For_Null_Response_Test()
        {
            try
            {
                string result = analyser.AnalyseMood(null);
                string mood = "HAPPY";
               // Assert.AreEqual(mood, result);
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
                string mood = "HAPPY";
                //Assert.AreEqual(mood, result);
            }
            catch(MoodAnalyserException e)
            {
                Assert.AreEqual (MoodAnalyserException.TypeOfException.EMPTY_STRING_EXCEPTION,e.exceptionType);
            }
        }

        [Test]
        public void Mood_Analyser_Contructor_Checker_Test()
        {          
            MoodAnalyserFactory<MoodAnalyser> factory = new MoodAnalyserFactory<MoodAnalyser>();
            ConstructorInfo constrInfo = factory.ConstructorCreator();
            object instanceOfClass = factory.InstanceCreator("MoodAnalyser", constrInfo);
            Assert.IsInstanceOf(typeof(MoodAnalyser), instanceOfClass);
        }

        [Test]
        public void Improper_Class_Haandeling_Test()
        {
            try
            {               
                MoodAnalyserFactory<MoodAnalyser> factory = new MoodAnalyserFactory<MoodAnalyser>();
                ConstructorInfo constrInfo = factory.ConstructorCreator();
                object instanceOfClass = factory.InstanceCreator("Mood", constrInfo);
                //Assert.IsInstanceOf(typeof(MoodAnalyser), instanceOfClass);
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
                MoodAnalyserFactory<MoodAnalyser> factory = new MoodAnalyserFactory<MoodAnalyser>();
                ConstructorInfo constrInfo = factory.ConstructorCreator("MoodAnalysis.MoodAnalyser");
                object instanceOfClass = factory.InstanceCreator("MoodAnalyser", constrInfo);
                //Assert.IsInstanceOf(typeof(MoodAnalyser), instanceOfClass);
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(MoodAnalyserException.TypeOfException.NO_CONSTRUCTOR_FOUND, e.exceptionType);
            }
        }

        [Test]
        public void Mood_Analyser_Parameterised_Constructor_Check_Test()
        {
            MoodAnalyser analysis = new MoodAnalyser("here i am in sad mood");
            MoodAnalyserFactory<MoodAnalyser> factory = new MoodAnalyserFactory<MoodAnalyser>();
            ConstructorInfo constrInfo = factory.ConstructorCreator(1);
            object instanceOfClass = factory.InstanceCreator("MoodAnalyser", constrInfo, "here i am in sad mood ");
            Assert.IsInstanceOf(typeof(MoodAnalyser), instanceOfClass);
        }

        [Test]
        public void Improper_Class_Name_For_Parametersed_Constructor_Test()
        {
            try
            {
                MoodAnalyser analysis = new MoodAnalyser("here i am in happy mood");
                MoodAnalyserFactory<MoodAnalyser> factory = new MoodAnalyserFactory<MoodAnalyser>();
                ConstructorInfo constrInfo = factory.ConstructorCreator(1);
                object instanceOfClass = factory.InstanceCreator("Mood", constrInfo, "here i am in happy mood");               
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
                MoodAnalyser analysis = new MoodAnalyser("here i am in happy mood");
                MoodAnalyserFactory<MoodAnalyser> factory = new MoodAnalyserFactory<MoodAnalyser>();
                ConstructorInfo constrInfo = factory.ConstructorCreator("MoodAnalysis.MoodAnalyser");
                object instanceOfClass = factory.InstanceCreator("MoodAnalyser", constrInfo, "here i am in happy mood");               
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(MoodAnalyserException.TypeOfException.NO_CONSTRUCTOR_FOUND, e.exceptionType);
            }
        }


    }
}