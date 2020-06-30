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
        public void Test_For_Sad_Mood()
        {
            string result = analyser.AnalyseMood("I Am So Sad ");
            Assert.AreEqual("SAD", result);
        }

        [Test]
        public void Test_For_Happy_Mood()
        {
            string result = analyser.AnalyseMood("I am Happy");
            Assert.AreEqual("HAPPY", result);
        }

        [Test]
        public void Test_For_Null_Response()
        {
            try
            {
                analyser.AnalyseMood(null);
            }
            catch (MoodAnalyserException e)
            {

                Assert.AreEqual(MoodAnalyserException.TypeOfException.NULL_POINTER_EXCEPTION, e.exceptionType);
            }
        }

        [Test]
        public void Test_For_Empty_Message()
        {
            try
            {
                analyser.AnalyseMood("");
            }
            catch(MoodAnalyserException e)
            {
                Assert.AreEqual (MoodAnalyserException.TypeOfException.EMPTY_STRING_EXCEPTION,e.exceptionType);
            }
        }

        [Test]
        public void Mood_Analyser_Contructor_Checker()
        {          
            MoodAnalyserFactory<MoodAnalyser> factory = new MoodAnalyserFactory<MoodAnalyser>();
            ConstructorInfo constrInfo = factory.ConstructorChecker();
            object constructor = factory.InstanceChecker("MoodAnalyser", constrInfo);
            Assert.IsInstanceOf(typeof(MoodAnalyser), constructor);
        }

    }
}