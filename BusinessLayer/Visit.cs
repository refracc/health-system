using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    /// <summary>
    /// This class is responsible for managing everything to do with arranged visits between clients and staff.
    /// </summary>
    public class Visit
    {
        /// <summary>
        /// Private constructor -- Cannot be called from outwith this class and cannot construct a blank visit object.
        /// </summary>
        private Visit() {}

        /// <summary>
        /// A list of all valid visits.
        /// </summary>
        private static List<Visit> visits = new List<Visit>();

        /// <summary>
        /// An array of size 1 or 2 of staff IDs
        /// </summary>
        public int[] Staffs { get; }

        /// <summary>
        /// The client ID (Client and Patient are used interchangeably).
        /// Cannot be set from outwith this class.
        /// </summary>
        public int Patient { get; }

        /// <summary>
        /// The visit type required.
        /// Cannot be set from outwith the class.
        /// </summary>
        public int Type { get; }

        /// <summary>
        /// The date and time for the appointment.
        /// Cannot be set from outwith the class.
        /// </summary>
        public DateTime DateTime { get; }

        /// <summary>
        /// The only valid way to create a new Visit object is via this constructor.
        /// </summary>
        /// <param name="staff">An array of staff IDs</param>
        /// <param name="patient">The client ID</param>
        /// <param name="type">The type of visit required</param>
        /// <param name="dateTime">The date & time of the appointment</param>
        public Visit(int[] staff, int patient, int type, DateTime dateTime)
        {
            Staffs = staff;
            Patient = patient;
            Type = type;
            DateTime = dateTime;
            if (Client.GetClientList().ContainsKey(patient))
            {
                if (type == VisitTypes.assessment
                    || type == VisitTypes.bath
                    || type == VisitTypes.meal
                    || type == VisitTypes.medication)
                {
                    if (staff.Length == 1)
                    {
                        if (Staff.GetStaffList().ContainsKey(staff[0]))
                        {
                            if (type == VisitTypes.medication
                                && Staff.GetStaffList()[staff[0]].Category.Equals("Community Nurse"))
                            {
                                visits.Add(this);
                            }
                            else if (type == VisitTypes.meal
                                && Staff.GetStaffList()[staff[0]].Category.Equals("Care Worker"))
                            {
                                visits.Add(this);
                            }
                            else
                            {
                                throw new Exception("Staff/Client mismatch.");
                            }
                        }
                        else
                        {
                            throw new Exception("Inappropriate staff ID");
                        }
                    }
                    else if (staff.Length == 2)
                    {
                        if (Staff.GetStaffList().ContainsKey(staff[0])
                            && Staff.GetStaffList().ContainsKey(staff[1]))
                        {
                            if (type == VisitTypes.assessment
                                && Staff.GetStaffList()[staff[0]].Category.Equals("Social Worker")
                                    && Staff.GetStaffList()[staff[1]].Category.Equals("General Practitioner")
                                || (Staff.GetStaffList()[staff[1]].Category.Equals("Social Worker")
                                    && Staff.GetStaffList()[staff[0]].Category.Equals("General Practitioner")))
                            {
                                visits.Add(this);
                            }
                            else if (type == VisitTypes.bath
                              && Staff.GetStaffList()[staff[0]].Category.Equals("Care Worker")
                              && Staff.GetStaffList()[staff[1]].Category.Equals("Care Worker"))
                            {
                                visits.Add(this);
                            }
                        }
                        else
                        {
                            throw new Exception("Inappropriate staff ID");
                        }
                    }
                }
                else
                {
                    throw new Exception("Invalid visit type");
                }
            } else
            {
                throw new Exception("Invalid client ID");
            }
        }

        /// <summary>
        /// A method which gives you access to the list of valid visits.
        /// </summary>
        /// <returns>The list of valid visits</returns>
        public static List<Visit> GetVisitList() => visits;

        /// <summary>
        /// A method which will return a complete list of valid visits.
        /// </summary>
        /// <returns>The completed list of valid vists, seperated by new lines, delimited by \n</returns>
        public static string ListAllVisits()
        {
            string res = "\n-----[ Visits ]-----\n";
            foreach (Visit v in visits)
            {
                res += v + "\n";
            }
            return res;
        }

        /// <summary>
        /// Overridden ToString method.
        /// </summary>
        /// <returns>The visit as a string, with each field delimited by a semi-colon (;).</returns>
        public override string ToString()
        {
            string s = null;
            
            if (Staffs.Length == 1)
            {
                s += Staffs[0];
            } else if (Staffs.Length == 2)
            {
                s += Staffs[0] + "," + Staffs[1];
            }
            
            return s + ";" + Patient + ";" + Type + ";" + DateTime;   
        }
    }
}
