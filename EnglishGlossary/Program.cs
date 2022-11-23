using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using IronOcr;
using static IronOcr.OcrResult;

namespace EnglishGlossary
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var ocr = new IronTesseract();
            string filePath = @"C:\Users\Ivailo\Downloads\EnglishGlossary-master\EnglishGlossary-master\ocrImages\book1.pdf";
            using (var input = new OcrInput(filePath))
            {
                var result = ocr.Read(input);
                string[] text = result.Text.Split('[');
                List<string> listOfWords = new List<string>();
                foreach (var word in text)
                {
                    int idx = word.LastIndexOf('\n');

                    if (idx != -1)
                    {
                        var rsult = word.Substring(idx + 1);
                        listOfWords.Add(rsult);
                    }
                }
                //path to save new file
                string listOfWordsPath = @"C:\Users\Ivailo\Downloads\EnglishGlossary-master\EnglishGlossary-master\ReadyToUseTextFiles\listofWords.txt";
                File.WriteAllLines(listOfWordsPath, listOfWords);
            }
        }
    }
}