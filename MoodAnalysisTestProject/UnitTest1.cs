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
            string result = analyser.AnalyseMood("I Am So Sad");
            Assert.AreEqual("SAD", result);
        }
    }
}