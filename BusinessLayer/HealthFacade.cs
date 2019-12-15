using System;
using DataLayer;

namespace BusinessLayer
{
    /// <summary>
    /// This is the Facade class given to me by Dr Neil Urquhart. It is used as the main API between the system and the UI.
    /// </summary>
    public class HealthFacade
    {
        /// <summary>
        /// This is the method called from the MainWindow class and is designed to add a new member of staff to the system when called.
        /// </summary>
        /// <param name="id">The member of staff's ID</param>
        /// <param name="firstName">The member of staff's forename</param>
        /// <param name="surname">The member of staff's surname</param>
        /// <param name="address1">The member of staff's address line 1</param>
        /// <param name="address2">The member of staff's address line 2</param>
        /// <param name="category">The member of staff's category</param>
        /// <param name="baseLocLat">The member of staff's building location latitude</param>
        /// <param name="baseLocLon">The member of staff's building location longitude</param>
        /// <returns>True: Member of staff can be added. False: There was an error in adding the member of staff.</returns>
        public Boolean addStaff(int id, string firstName, string surname, string address1, string address2, string category, double baseLocLat, double baseLocLon)
        {
            try
            {
                Staff s = new Staff(id, firstName, surname, address1, address2, category, baseLocLat, baseLocLon);
                return true;
            } catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// This method is called from MainWindow and is designed to add a new client to the system.
        /// </summary>
        /// <param name="id">The client's ID</param>
        /// <param name="firstName">The client's forename</param>
        /// <param name="surname">The client's surname</param>
        /// <param name="address1">The client's address line 1</param>
        /// <param name="address2">The client's address line 2</param>
        /// <param name="locLat">The client's house location latitude</param>
        /// <param name="locLon">The client's house location longitude</param>
        /// <returns>True: Client can be added. False: There was an error in adding the client.</returns>
        public Boolean addClient(int id, string firstName, string surname, string address1, string address2, double locLat, double locLon)
        {
            try
            {
                Client c = new Client(id, firstName, surname, address1, address2, locLat, locLon);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// This method is called from MainWindow and is designed to add valid visits to the system.
        /// </summary>
        /// <param name="staff">An array of integers of staff IDs</param>
        /// <param name="patient">An integer which is the client ID</param>
        /// <param name="type">The type of visit that is required</param>
        /// <param name="dateTime">The date and time of the visit</param>
        /// <returns>True: The visit is fine and doesn't clash. False: There is an issue with the visit (clashes, invalid client/staff)</returns>
        public Boolean addVisit(int[] staff, int patient, int type, DateTime dateTime)
        {
            Visit v = new Visit(staff, patient, type, dateTime);
            return true;
        }

        /// <summary>
        /// This method is called from MainWindow to return the full list of staff.
        /// </summary>
        /// <returns>The full staff list split by new lines delimited by \n</returns>
        public string getStaffList() => Staff.ListAllStaff();

        /// <summary>
        /// This method is designed to return the full list of clients
        /// </summary>
        /// <returns>The full list of clients split by new lines delimited by \n</returns>
        public string getClientList() => Client.ListAllClients();

        /// <summary>
        /// This method will return the full list of valid visits.
        /// </summary>
        /// <returns>A full list of valid visits, split by new line and delimited by \n.</returns>
        public string getVisitList() => Visit.ListAllVisits();

        /// <summary>
        /// This method is designed to clear all data in the system.
        /// </summary>
        public void clear()
        {
            Staff.GetStaffList().Clear();
            Client.GetClientList().Clear();
            Visit.GetVisitList().Clear();
        }

        /// <summary>
        /// This method is designed to load all the required data into the system from CSV files using a Singleton loading class.
        /// </summary>
        /// <returns>True: The files were found and everything works. False: It probably can't find the files.</returns>
        public Boolean load()
        {
            LoadSingleton load = LoadSingleton.Instance;

            load.LoadType("client");
            load.LoadType("staff");
            load.LoadType("visit");
            return true;
        }

        /// <summary>
        /// This method is designed to save all the required data from the system into CSV files using a Singleton saving class.
        /// </summary>
        /// <returns>True: The files were found and everything works. False: It probably can't find the files.</returns>
        public Boolean save()
        {
            SaveSingleton save = SaveSingleton.Instance;

            save.SaveType("client");
            save.SaveType("staff");
            save.SaveType("visit");
            return true;
        }

    }
}
