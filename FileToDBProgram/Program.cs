using System;
using System.Collections.Generic;

namespace FileToDBProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName;
            Console.WriteLine("Hello World!");
            DatabaseService db = new DatabaseService();
            db.Connect();
            db.DeleteTable();
            db.MakeTable();
            //File path = "C:\Users\nrajpurohit\Downloads\PointOfInterestCoordinatesList.txt"
            Console.WriteLine("Input the Path to the file to be read-");
            fileName = Console.ReadLine();

            FileReader fr = new FileReader();
            string resultstr = fr.ReadFile(fileName);
            Parser parser = new Parser();

            List<PointOfInterest> list = parser.ParseDataToObjects(resultstr);

            db.InsertCompleteData(list);
            db.Disconnect();
        }

    }
}
