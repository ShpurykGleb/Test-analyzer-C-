using System;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpTextAnalyzer.Models
{
    //Class that counts word in text, find max occuring word and his count, and also classic text nausea
    public class WordCounterModel : DelimitersArrayAbstractModel
    {
        //Method that counts word in text
        public async Task<int> WordCountAsync(string text) => text.Split(_delimiters, StringSplitOptions.RemoveEmptyEntries).Length;

        //Method that find max occuring word in text
        public async Task<string> GetMaxOccuringWordAsync(string text)
        {
            var words = text.Split(_delimiters, StringSplitOptions.RemoveEmptyEntries).GroupBy(x => x)
                              .Select(x => new { Count = x.Count(), Word = x.Key })
                              .OrderByDescending(x => x.Count);

            string result = "";
            foreach (var word in words)
            {
                result = word.Word;
                break;
            }

            if (result.Length > 15)
            {
                result = result.Substring(0, 15) + "...";
            }

            return result;
        }

        //Method that find count of max occuring word in text
        public async Task<int> GetMaxOccuringWordCountAsync(string text)
        {
            var words = text.Split(_delimiters, StringSplitOptions.RemoveEmptyEntries).GroupBy(x => x)
                              .Select(x => new { Count = x.Count(), Word = x.Key })
                              .OrderByDescending(x => x.Count);

            int result = 0;
            foreach (var word in words)
            {
                result = word.Count;
                break;
            }

            return result;
        }

        //Method that find classic text nausea
        public async Task<string> GetClassicTextNauseaAsync(string text)
        {
            int count = await GetMaxOccuringWordCountAsync(text);

            return string.Format("{0:F2}", Math.Sqrt(count));
        }
    }
}
