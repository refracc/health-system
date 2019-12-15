using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    /// <summary>
    /// This class is a sub-class of Person, it contains all the methods required to handle a client.
    /// </summary>
    public class Client : Person
    {
        /// <summary>
        /// The main way of storing all Client objects.
        /// </summary>
        private static Dictionary<int, Client> clientList = new Dictionary<int, Client>();

        /// <summary>
        /// Private constructor -- Cannot be referenced outside this class.
        /// </summary>
        private Client() { }

        /// <summary>
        /// Responsible for publically getting the Id of a client, yet you cannot set it outwith this class.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// The main (and only) constructor which allows you to create a new client for the system.
        /// </summary>
        /// <param name="id">The ID of the client</param>
        /// <param name="forename">The Forename of the client</param>
        /// <param name="surname">The Surname of the client</param>
        /// <param name="address1">The Address Line 1 of the client</param>
        /// <param name="address2">The Address Line 2 of the client</param>
        /// <param name="lat">The Latitude of the client</param>
        /// <param name="lon">The Longitude of the client</param>
        public Client(int id, string forename, string surname, string address1, string address2, double lat, double lon)
        {
            Id = id;
            Forename = forename;
            Surname = surname;
            Address1 = address1;
            Address2 = address2;
            Lat = lat;
            Lon = lon;

            clientList.Add(Id, this);
        }

        /// <summary>
        /// This is the method responsible for returning the list of clients as a single string.
        /// </summary>
        /// <returns>All clients which are to be placed on a new line in the UI (delimited by \n)</returns>
        public static string ListAllClients()
        {
            string res = "-----[ Client ]-----\n";
            foreach (KeyValuePair<int, Client> clients in clientList)
            {
                res += clients.Value + "\n";
            }

            return res;
        }

        /// <summary>
        /// The method which is able to return the full list of clients as a dictionary.
        /// </summary>
        /// <returns>The dictionary containing the clients</returns>
        public static Dictionary<int, Client> GetClientList() => clientList;
        
        /// <summary>
        /// New ToString method which utilises the base ToString method.
        /// </summary>
        /// <returns>A description of the client delimited by semi-colons (;)</returns>
        public override string ToString() => Id + ";" + base.ToString();
    }
}
