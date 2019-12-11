using System;
using System.IO;

namespace FileToDBProgram
{
    class FileReader
    {
        public string ReadFile(string pathToFile)
        {
            try
            {
                using (StreamReader sr = new StreamReader(pathToFile))
                {
                    String line = sr.ReadToEnd();
                    return line;
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read");
                return (e.Message);
            }
        }
    }
}
