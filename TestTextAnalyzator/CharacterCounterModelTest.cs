using CSharpTextAnalyzer.Models;

namespace TestTextAnalyzator
{
    //Class that conducts the tests of CharacterCounterModel
    public class CharacterCounterModelTest
    {
        //Test GetCharactersCountWithSpacesAsync
        [Fact]
        public async void TestGetCharactersCountWithSpacesAsync()
        {
            using (CharacterCounterModel characterCounterModel = new CharacterCounterModel())
            {
                string textToTest = "Hello, my name is lala!";
                int expectedResult = textToTest.Length;

                int result = await characterCounterModel.GetCharactersCountWithSpacesAsync(textToTest);

                Assert.Equal(expectedResult, result);
            }
        }

        //Test GetCharactersCountWithoutSpacesAsync
        [Fact]
        public async void TestGetCharactersCountWithoutSpacesAsync()
        {
            using (CharacterCounterModel characterCounterModel = new CharacterCounterModel())
            {
                string textToTest = "Hello, my name is lala!";
                int expectedResult = textToTest.Length - 4;

                int result = await characterCounterModel.GetCharactersCountWithoutSpacesAsync(textToTest);

                Assert.Equal(expectedResult, result);
            }
        }
    }
}
