using System;
using System.Threading.Tasks;

namespace CSharpTextAnalyzer.Models
{
    //Class that counts character in text
    public class CharacterCounterModel : IDisposable
    {
        //Method that counts charactes in text with spaces
        public async Task<int> GetCharactersCountWithSpacesAsync(string text) => text.Length;

        //Method that counts charactes in text without spaces
        public async Task<int> GetCharactersCountWithoutSpacesAsync(string text) => text.Replace(" ", "").Length;

        //Destructor
        public void Dispose() { }
    }
}
