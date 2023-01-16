using System;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpTextAnalyzer.Models
{
    //Class that counts bid and low letter in text
    public class LetterCounterModel : IDisposable
    {
        //Method that counts big letter in text
        public async Task<int> GetBigLettersCountAsync(string text) => text.Where(x => char.IsUpper(x)).Count();

        //Method that counts low letter in text
        public async Task<int> GetLowLettersCountAsync(string text) => text.Where(x => char.IsLower(x)).Count();

        //Destructor
        public void Dispose() { }
    }
}
