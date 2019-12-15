using System;
using System.Collections.Generic;
using BusinessLayer;

namespace DataLayer
{
    public sealed class SaveSingleton
    {
        private SaveSingleton(){}

        private static readonly Lazy<SaveSingleton> saveSingleton = new Lazy<SaveSingleton>(() => new SaveSingleton());

        public static SaveSingleton Instance => saveSingleton.Value;

        public void SaveType(string type)
        {
            if (type == "staff")
            {
                List<string> staffOutput = new List<string>();

                foreach (KeyValuePair<int, Staff> staff in Staff.GetStaffList())
                {
                    staffOutput.Add(staff.Value.ToString());

                    System.IO.File.WriteAllLines(type + ".csv", staffOutput);
                }
            }
            else if (type == "client")
            {
                List<string> clientOutput = new List<string>();

                foreach (KeyValuePair<int, Client> clients in Client.GetClientList())
                {
                    clientOutput.Add(clients.Value.ToString());

                    System.IO.File.WriteAllLines(type + ".csv", clientOutput);
                }
            }
            else if (type == "visit")
            {
                List<string> visitOutput = new List<string>();

                foreach (Visit v in Visit.GetVisitList())
                {
                    visitOutput.Add(v.ToString());

                    System.IO.File.WriteAllLines(type + ".csv", visitOutputt);
                }
            }
        }
    }
}