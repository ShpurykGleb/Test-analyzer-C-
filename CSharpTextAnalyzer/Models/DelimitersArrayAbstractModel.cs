using System;

namespace CSharpTextAnalyzer.Models
{
    //Abstract class for inheritance, that includes array with delimiters
    public abstract class DelimitersArrayAbstractModel : IDisposable
    {
        //Array with delimiters
        public readonly char[] _delimiters;

        //Standart constructor
        public DelimitersArrayAbstractModel()
        {
            _delimiters = new char[] { ' ', '.', ',', ';', ':',
                                       '!', '?', '-', '"', '(', ')',
                                       '%', '&', '^', '|', '/', '\\',
                                       '@','<','>' };
        }

        //Parametric constructor
        public DelimitersArrayAbstractModel(char[] delimiters)
        {
            _delimiters = delimiters;
        }

        //Destructor
        public void Dispose() { }
    }
}
