using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    /// <summary>
    /// This class is a sub-type of Person, which contains all methods required to handle the storage and manipulation of staff.
    /// </summary>
    public class Staff : Person
    {
        /// <summary>
        /// Private Dictionary which stores all the staff objects in the system.
        /// </summary>
        private static Dictionary<int, Staff> staffList = new Dictionary<int, Staff>();

        /// <summary>
        /// The member of staff's ID which can only set from within this class.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// The member of staff's category, which can only be set from within this class.
        /// </summary>
        public string Category { get; }

        /// <summary>
        /// Private constructor, can only be called from within the class and refuses an empty constructor when instantiating a new staff object.
        /// </summary>
        private Staff() {}

        /// <summary>
        /// The only way to properly instantiate a new staff object. Saves it in the staff dictionary.
        /// </summary>
        /// <param name="id">The member of staff's ID</param>
        /// <param name="forename">The member of staff's forename</param>
        /// <param name="surname">The member of staff's surname</param>
        /// <param name="address1">The member of staff's address line 1</param>
        /// <param name="address2">The member of staff's address line 2</param>
        /// <param name="category">The member of staff's category -- which job they do</param>
        /// <param name="lat">The member of staff's work building latitude</param>
        /// <param name="lon">The member of staff's work building longitude</param>
        public Staff(int id, string forename, string surname, string address1, string address2, string category, double lat, double lon)
        {
            Id = id;
            Forename = forename;
            Surname = surname;
            Address1 = address1;
            Address2 = address2;
            Category = category;
            Lat = lat;
            Lon = lon;

            staffList.Add(id, this);
        }

        /// <summary>
        /// This method uses the dictionary to return a complete list of all staff.
        /// </summary>
        /// <returns>A complete list of staff currently in the system, which is separated by new lines, delimited by \n.</returns>
        public static string ListAllStaff()
        {
            string res = "-----[ Staff ]-----\n";
            foreach (KeyValuePair<int, Staff> staff in staffList)
            {
                res += staff.Value + "\n";
            }
            return res;
        }

        /// <summary>
        /// Public mthod for making use of the dictionary of staff.
        /// </summary>
        /// <returns>The active dictionary of staff.</returns>
        public static Dictionary<int, Staff> GetStaffList() => staffList;

        /// <summary>
        /// Overridden ToString method from the Person class. Which is modified to contain the staff ID & category before calling the base method.
        /// </summary>
        /// <returns>The staff object as a string.</returns>
        public override string ToString() => Id + ";" + Category + ";" + base.ToString();
    }
}
