using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    /// <summary>
    /// This was originally in the HealthFacade class, however I moved it out as I found it clunky and untidy.
    /// </summary>
    public static class VisitTypes
    {
        /// <summary>
        /// These are all integer variables which are assigned values to correspond with visit types.
        /// </summary>
        public const int assessment = 0;
        public const int medication = 1;
        public const int bath = 2;
        public const int meal = 3;
    }
}
