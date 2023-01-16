using CSharpTextAnalyzer.Controllers;
using System;
using System.Windows.Controls;

namespace CSharpTextAnalyzer.View
{
    //Class that uses for showing results of analyzing text
    internal class ViewResults : IDisposable
    {
        //Standart constructor
        public ViewResults() { }

        //Method that shows results of analyzing text
        public async void ShowResultsOfAnalyzingText(Label labelWordCountResult, Label labelMaxOccuringWordResult, Label labelMaxOccuringWordCountResult,
            Label labelClassicTextNauseaResult, Label labelNumberOfCharactersWithSpacesResult, Label labelNumberOfCharactersWithoutSpacesResult,
            Label labelNumberOfDelimitersResult, Label labelMaxOccuringCharacterResult, Label labelCountOfMaxOccuringCharacterResult,
            Label labelBigLetterCountResult, Label labelLowLetterCountResult, string text)
        {
            using (ResultController resultController = new ResultController())
            {
                resultController.GetResultsOfAnalyzing(text);

                labelWordCountResult.Content = resultController.WordCount;
                labelMaxOccuringWordResult.Content = resultController.MaxOccuringWord;
                labelMaxOccuringWordCountResult.Content = resultController.MaxOccuringWordCount;
                labelClassicTextNauseaResult.Content = resultController.ClassicTextNausea;
                labelNumberOfCharactersWithSpacesResult.Content = resultController.CharactersCountWithSpaces;
                labelNumberOfCharactersWithoutSpacesResult.Content = resultController.CharactersCountWithoutSpaces;
                labelNumberOfDelimitersResult.Content = resultController.DelimitesCount;
                labelMaxOccuringCharacterResult.Content = resultController.MaxOccuringChar;
                labelCountOfMaxOccuringCharacterResult.Content = resultController.MaxOccuringCharCount;
                labelBigLetterCountResult.Content = resultController.BigLettersCount;
                labelLowLetterCountResult.Content = resultController.LowLettersCount;
            }
        }

        //Destructor
        public void Dispose() { }
    }
}
