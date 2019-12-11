using System;
using System.Collections.Generic;

namespace FileToDBProgram
{
    class Parser
    {
        public List<PointOfInterest> ParseDataToObjects(string data)
        {
            List<PointOfInterest> dataList = new List<PointOfInterest>();
            string[] dataArray = data.Split('\n');
            for (int i = 1; i < dataArray.Length; i++)
            {
                string[] dataItems = dataArray[i].Split('|');
                PointOfInterest item = new PointOfInterest(dataItems[0],
                    dataItems[1], dataItems[2], dataItems[3], dataItems[4], dataItems[5]);
                dataList.Add(item);
            }
            Console.WriteLine("Data Parsed! Number of Objects Created: " + dataList.Count);
            return dataList;
        }
    }
}
