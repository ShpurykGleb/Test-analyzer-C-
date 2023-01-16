using System;
using System.IO;
using System.Linq;

namespace CSharpTextAnalyzer.Models
{
    //Class that works with files with text
    internal class FileController
    {
        //Max text length in file
        private readonly static int _maxTextLength = 100000;

        //Static object of FileController
        private static FileController _fileController;

        //Private standart constructor
        private FileController() { }

        //Method that gives static object of FileController
        public FileController GetInstance()
        {
            if (_fileController is null)
            {
                _fileController = new FileController();
            }

            return _fileController;
        }

        //Method that read text from file
        public static string GetTextFromFile(string filePath)
        {
            string text = "";

            try
            {           
                using (StreamReader streamReader = new StreamReader(filePath))
                {
                    text = streamReader.ReadToEnd();

                    //If text is windows-1251 unicode
                    if (text.Where(x => (x >= 'а' && x <= 'я') || (x >= 'А' && x <= 'Я')).ToList().Count > 0)
                    {
                        text = "";
                    }
                }

                //If the text length is greater than the maximum, then the text will be cut off
                if (text.Length > _maxTextLength)
                {
                    text = text.Substring(0, _maxTextLength);
                }

                return text;
            }
            catch (Exception) //File read fail
            {
                return text;
            }
        }

    }
}
