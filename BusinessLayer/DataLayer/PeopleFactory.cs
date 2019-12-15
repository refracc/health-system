using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using BusinessLayer;

namespace DataLayer
{
    /// <summary>
    /// This class is not declared public as it is only required to be called through the LoadSingleton class, which will only utilises 1 instance of the class.
    /// So it doesn't take up many resources when not in use.
    /// 
    /// The Factory pattern is made of use here to create many objects from files in CSV format which are delimited by semi-colons (;).
    /// </summary>
    class PeopleFactory
    {
        /// <summary>
        /// This method is the core of object creation from the CSV files.
        /// </summary>
        /// <param name="type">Can be any of the types of object required by the system and loads CSV a file of the same name.</param>
        public void FactoryMethod(string type)
        {
            if (type == "client")
            {
                string path = type + ".csv";
                string[] lines = File.ReadAllLines(path);

                foreach (string line in lines)
                {
                    string[] col = line.Split(';');
                    Client c = new Client(int.Parse(col[0]), col[1], col[2], col[3], col[4], double.Parse(col[5]), double.Parse(col[6]));
                }
            }
            else if (type == "staff")
            {
                string path = type + ".csv";
                string[] lines = File.ReadAllLines(path);

                foreach (string line in lines)
                {
                    string[] col = line.Split(';');
                    Staff s = new Staff(int.Parse(col[0]), col[3], col[4], col[5], col[1], col[2], double.Parse(col[6]), double.Parse(col[7]));
                }
            }
            else if (type == "visit")
            {
                string path = type + ".csv";
                string[] lines = File.ReadAllLines(path);

                foreach (string line in lines)
                {
                    string[] col = line.Split(';');
                    string[] cell = col[0].Split(',');

                    if (col[0].Length == 1)
                    {
                        Visit v = new Visit(new int[1] { int.Parse(cell[0]) }, int.Parse(col[1]), int.Parse(col[2]), DateTime.Parse(col[3], System.Globalization.CultureInfo.InvariantCulture));
                    } else if (col[0].Length == 3)
                    {
                        Visit v = new Visit(new int[2] { int.Parse(cell[0]), int.Parse(cell[1]) }, int.Parse(col[1]), int.Parse(col[2]), DateTime.Parse(col[3], System.Globalization.CultureInfo.InvariantCulture));
                    }
                }
            }
        }
    }
}
