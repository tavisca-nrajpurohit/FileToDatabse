using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace FileToDBProgram
{
    public class DatabaseService
    {
        private string configuration = "server=localhost;user id=root;database=filetodb;password=root";
        private MySqlConnection con;

        public void Connect()
        {
            this.con = new MySqlConnection(configuration);
            this.con.Open();
            Console.WriteLine("Database Connected! ");
        }

        public void Disconnect()
        {
            con.Close();
            Console.WriteLine("Database Disconnected! ");
        }
        public void MakeTable()
        {
            MySqlCommand cmd = new MySqlCommand("create table if not exists fileToDbTest (DataID INT NOT NULL AUTO_INCREMENT, RegionID VARCHAR(256) NOT NULL, RegionName VARCHAR(256) NOT NULL, RegionNameLong VARCHAR(256) NOT NULL, Latitude VARCHAR(256) NOT NULL, Longitude VARCHAR(256) NOT NULL, SubClassification VARCHAR(100) NOT NULL, PRIMARY KEY ( DataID ));", this.con);

            int result = cmd.ExecuteNonQuery();

            Console.WriteLine("Database Created! Rows Affected:" + result);
            cmd.Dispose();
        }

        public void DeleteTable()
        {
            MySqlCommand cmd = new MySqlCommand("DROP TABLE fileToDbTest;", this.con);

            int result = cmd.ExecuteNonQuery();

            Console.WriteLine("Database Created! Rows Affected:" + result);
            cmd.Dispose();

        }


        public void InsertData(PointOfInterest item)
        {
            MySqlCommand cmd = new MySqlCommand("insert into fileToDbTest (RegionID,RegionName,RegionNameLong,Latitude,Longitude,SubClassification) values (\"" + item.RegionID + "\",\"" + item.RegionName + "\",\"" + item.RegionNameLong + "\",\"" + item.Latitude + "\",\"" + item.Longitude + "\",\"" + item.SubClassification + "\");", this.con);

            int result = cmd.ExecuteNonQuery();

            Console.WriteLine("Database Inserted! Rows Affected:" + result);
            cmd.Dispose();
        }

        public void InsertCompleteData(List<PointOfInterest> items)
        {
            string cmdString = "insert into fileToDbTest(RegionID, RegionName, RegionNameLong, Latitude, Longitude, SubClassification) ";
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine(i);
                PointOfInterest item = items[i];
                if (i == 0)
                {
                    cmdString += "values (\"" + item.RegionID + "\",\"" + item.RegionName + "\",\"" + item.RegionNameLong + "\",\"" + item.Latitude + "\",\"" + item.Longitude + "\",\"" + item.SubClassification + "\")";
                }
                else
                {
                    cmdString += ",(\"" + item.RegionID + "\",\"" + item.RegionName + "\",\"" + item.RegionNameLong + "\",\"" + item.Latitude + "\",\"" + item.Longitude + "\",\"" + item.SubClassification + "\")";
                }

            }

            cmdString += ";";
            MySqlCommand cmd = new MySqlCommand(cmdString, this.con);

            int result = cmd.ExecuteNonQuery();

            Console.WriteLine("Database Inserted! Rows Affected:" + result);
            cmd.Dispose();
        }
    }
}
