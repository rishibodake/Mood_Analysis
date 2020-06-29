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

                Assert.AreEqual("Null Pointer", e.Message);
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
                Assert.AreEqual ("Message Can Not Be Empty", e.Message);
            }
        }
    }
}