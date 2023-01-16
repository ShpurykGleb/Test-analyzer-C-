using CSharpTextAnalyzer.Models;

namespace TestTextAnalyzator
{
    //Class that conducts the tests of MaxOccutingCharCounterModel
    public class MaxOccutingCharCounterModelTest
    {
        //Test GetMaxOccuringCharAsync
        [Fact]
        public async void TestGetMaxOccuringCharAsync()
        {
            string textToTest = "Hello, my name is lala!";

            using (MaxOccuringCharCounterModel maxOccuringCharCounterModel = new MaxOccuringCharCounterModel(textToTest))
            {              
                char expectedResult = 'l';

                char result = await maxOccuringCharCounterModel.GetMaxOccuringCharAsync();

                Assert.Equal(expectedResult, result);
            }
        }

        //Test GetMaxOccuringCharCountAsync
        [Fact]
        public async void TestGetMaxOccuringCharCountAsync()
        {
            string textToTest = "Hello, my name is lala!";

            using (MaxOccuringCharCounterModel maxOccuringCharCounterModel = new MaxOccuringCharCounterModel(textToTest))
            {
                int expectedResult = 4;

                int result = await maxOccuringCharCounterModel.GetMaxOccuringCharCountAsync();

                Assert.Equal(expectedResult, result);
            }
        }


    }
}