using CSharpTextAnalyzer.Models;
using System;

namespace CSharpTextAnalyzer.Controllers
{
    //Class that get results of analyzing text from models
    internal class ResultController : IDisposable
    {
        //Results
        public int CharactersCountWithSpaces { get; set; }
        public int CharactersCountWithoutSpaces { get; set; }
        public int DelimitesCount { get; set; }
        public int BigLettersCount { get; set; }
        public int LowLettersCount { get; set; }
        public int WordCount { get; set; }
        public int MaxOccuringCharCount { get; set; }
        public int MaxOccuringWordCount { get; set; }
        public char MaxOccuringChar { get; set; }
        public string MaxOccuringWord { get; set; }
        public string ClassicTextNausea { get; set; }

        //Standart constructor
        public ResultController() { }

        //Method that get results of analyzing text
        public async void GetResultsOfAnalyzing(string text)
        {
            using (WordCounterModel wordCounterModel = new WordCounterModel())
            {
                WordCount = await wordCounterModel.WordCountAsync(text);
                MaxOccuringWord = await wordCounterModel.GetMaxOccuringWordAsync(text);
                MaxOccuringWordCount = await wordCounterModel.GetMaxOccuringWordCountAsync(text);
                ClassicTextNausea = await wordCounterModel.GetClassicTextNauseaAsync(text);
            }

            using (CharacterCounterModel characterCounterModel = new CharacterCounterModel())
            {
                CharactersCountWithSpaces = await characterCounterModel.GetCharactersCountWithSpacesAsync(text);
                CharactersCountWithoutSpaces = await characterCounterModel.GetCharactersCountWithoutSpacesAsync(text);
            }

            using (DelimitersCounterModel delimitersCounterModel = new DelimitersCounterModel())
            {
                DelimitesCount = await delimitersCounterModel.DelimitersCountAsync(text);
            }

            using (MaxOccuringCharCounterModel maxOccuringCharCounterModel = new MaxOccuringCharCounterModel(text))
            {
                MaxOccuringChar = await maxOccuringCharCounterModel.GetMaxOccuringCharAsync();
                MaxOccuringCharCount = await maxOccuringCharCounterModel.GetMaxOccuringCharCountAsync();
            }

            using (LetterCounterModel letterCounterModel = new LetterCounterModel())
            {
                BigLettersCount = await letterCounterModel.GetBigLettersCountAsync(text);
                LowLettersCount = await letterCounterModel.GetLowLettersCountAsync(text);
            }
        }

        //Destructor
        public void Dispose() { }
    }
}
