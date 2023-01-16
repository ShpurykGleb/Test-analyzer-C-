using System.Linq;
using System.Threading.Tasks;

namespace CSharpTextAnalyzer.Models
{
    //Class that counts delimiters in text
    public class DelimitersCounterModel : DelimitersArrayAbstractModel
    {
        //Method that counts delimiters in text
        public async Task<int> DelimitersCountAsync(string text) => text.Where(x => _delimiters.Contains(x)).ToList().Count;
    }
}
