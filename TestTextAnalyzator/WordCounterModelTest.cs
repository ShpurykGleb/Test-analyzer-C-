using CSharpTextAnalyzer.Models;

namespace TestTextAnalyzator
{
    //Class that conducts the tests of WordCounterModel
    public class WordCounterModelTest
    {
        //Test WordCountAsync
        [Fact]
        public async void TestWordCountAsync()
        {
            using (WordCounterModel wordCounterModel = new WordCounterModel())
            {
                string textToTest = "Hello, my name is lala!";
                int expectedResult = 5;

                int result = await wordCounterModel.WordCountAsync(textToTest);

                Assert.Equal(expectedResult, result);
            }
        }

        //Test GetMaxOccuringWordAsync
        [Fact]
        public async void TestGetMaxOccuringWordAsync()
        {
            using (WordCounterModel wordCounterModel = new WordCounterModel())
            {
                string textToTest = "Hello, my name is lala lala lala!";
                string expectedResult = "lala";

                string result = await wordCounterModel.GetMaxOccuringWordAsync(textToTest);

                Assert.Equal(expectedResult, result);
            }
        }

        //Test GetMaxOccuringWordCountAsync
        [Fact]
        public async void TestGetMaxOccuringWordCountAsync()
        {
            using (WordCounterModel wordCounterModel = new WordCounterModel())
            {
                string textToTest = "Hello, my name is lala lala lala!";
                int expectedResult = 3;

                int result = await wordCounterModel.GetMaxOccuringWordCountAsync(textToTest);

                Assert.Equal(expectedResult, result);
            }
        }

        //Test GetClassicTextNauseaAsync
        [Fact]
        public async void TestGetClassicTextNauseaAsync()
        {
            using (WordCounterModel wordCounterModel = new WordCounterModel())
            {
                string textToTest = "Hello, my name is is is is is is is is is lala!";
                string expectedResult = "3,00";

                string result = await wordCounterModel.GetClassicTextNauseaAsync(textToTest);

                Assert.Equal(expectedResult, result);
            }
        }
    }
}