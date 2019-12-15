using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    /// <summary>
    /// This is an abstract class for handling all standard person characteristics. This class is designed to NOT be instantiated.
    /// </summary>
    public abstract class Person
    {
        /// <summary>
        /// The person's forename
        /// </summary>
        public string Forename { get; set; }

        /// <summary>
        /// The person's surname
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// The person's address line 1
        /// </summary>
        public string Address1 { get; set; }
        
        /// <summary>
        /// The person's address line 2
        /// </summary>
        public string Address2 { get; set; }

        /// <summary>
        /// The person's latitude
        /// </summary>
        public double Lat { get; set; }

        /// <summary>
        /// The person's longitude
        /// </summary>
        public double Lon { get; set; }

        /// <summary>
        /// Overridden ToString method which is overriden in Staff and Client.
        /// </summary>
        /// <returns>Provides a base ToString method</returns>
        public override string ToString() => Forename + ";" + Surname + ";" + Address1 + ";" + Address2 + ";" + Lat + ";" + Lon;
    }
}
