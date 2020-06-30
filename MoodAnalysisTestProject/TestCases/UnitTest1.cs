using MoodAnalysis;
using NUnit.Framework;

namespace MoodAnalysisTestProject
{
    public class Tests
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
        public void Mood_Analyser_Object_Checker()
        {
            MoodAnalyserFactory moodFactory = new MoodAnalyserFactory();
            object expected = new MoodAnalyser();
            object returnObject = moodFactory.GetInstance("MoodAnalyser", "MoodAnalyser");
            expected.Equals(returnObject);
            Assert.AreEqual(expected, returnObject);
        }
    }
}