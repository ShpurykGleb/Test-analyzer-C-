using System;
using System.Threading.Tasks;

namespace CSharpTextAnalyzer.Models
{
    //Class that finds max occuring character in text and his count
    public class MaxOccuringCharCounterModel : IDisposable
    {
        //ASCII table size
        private readonly int ASCII_SIZE = 256;

        // Create array to keep the count of individual characters
        private readonly int[] count;

        //Text property for work
        public string Text { get; set; }

        //Parametric constructor
        public MaxOccuringCharCounterModel(string text)
        {
            count = new int[ASCII_SIZE];

            Text = text;

            for (int i = 0; i < Text.Length; i++)
            {
                count[Text[i]]++;
            }
        }

        //Method that find count of max occuring character in text
        public async Task<int> GetMaxOccuringCharCountAsync()
        {
            int max = -1; // Initialize max count

            // Traversing through the string and
            // maintaining the count of each character
            for (int i = 0; i < Text.Length; i++)
            {
                if (max < count[Text[i]])
                {
                    max = count[Text[i]];
                }
            }

            return max;
        }

        //Method that find max occuring character in text
        public async Task<char> GetMaxOccuringCharAsync()
        {
            int max = -1; // Initialize max count
            char result = ' '; // Initialize result

            // Traversing through the string and
            // maintaining the count of each character
            for (int i = 0; i < Text.Length; i++)
            {
                if (max < count[Text[i]])
                {
                    max = count[Text[i]];
                    result = Text[i];
                }
            }

            return result;
        }

        //Destructor
        public void Dispose() { }
    }
}
