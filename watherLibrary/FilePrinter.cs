using System;
using System.IO;
namespace weatherLibrary
{
    public class FilePrinter : IPrinter
    {
        private string filename;

        public FilePrinter(string filename)
        {
            this.filename = filename;
        }

        public void SetFilename(string filename)
        {
            this.filename = filename;
        }

        public void Print(string message)
        {
            using (StreamWriter streamWriter = new StreamWriter(filename))
            {
                streamWriter.WriteLine(message);
            }
        }
    }
}
