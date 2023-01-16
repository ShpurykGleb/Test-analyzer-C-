using CSharpTextAnalyzer.Models;

namespace TestTextAnalyzator
{
    //Class that conducts the tests of LetterCounterModel
    public class LetterCounterModelTest
    {
        //Test GetLowLettersCountAsync
        [Fact]
        public async void TestGetLowLettersCountAsync()
        {
            using (LetterCounterModel letterCounterModel = new LetterCounterModel())
            {
                string textToTest = "Hello, my name is lala!";
                int expectedResult = 16;

                int result = await letterCounterModel.GetLowLettersCountAsync(textToTest);

                Assert.Equal(expectedResult, result);
            }
        }

        //Test GetBigLettersCountAsync
        [Fact]
        public async void TestGetBigLettersCountAsync()
        {
            using (LetterCounterModel letterCounterModel = new LetterCounterModel())
            {
                string textToTest = "Hello, my name is lala!";
                int expectedResult = 1;

                int result = await letterCounterModel.GetBigLettersCountAsync(textToTest);

                Assert.Equal(expectedResult, result);
            }
        }
    }
}
