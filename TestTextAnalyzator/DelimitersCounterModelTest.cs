using CSharpTextAnalyzer.Models;

namespace TestTextAnalyzator
{
    //Class that conducts the tests of DelimitersCounterModel
    public class DelimitersCounterModelTest
    {
        //Test DelimitersCountAsync
        [Fact]
        public async void TestDelimitersCountAsync()
        {
            using (DelimitersCounterModel delimitersCounterModel = new DelimitersCounterModel())
            {
                string textToTest = "Hello, my name is lala!";
                int expectedResult = 6;

                int result = await delimitersCounterModel.DelimitersCountAsync(textToTest);

                Assert.Equal(expectedResult, result);
            }
        }

    }
}
