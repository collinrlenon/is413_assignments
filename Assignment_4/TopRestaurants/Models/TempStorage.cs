using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TopRestaurants.Models
{
    //Storage class
    public class TempStorage
    {
        private static List<FormModel> applications = new List<FormModel>();

        public static IEnumerable<FormModel> Applications => applications;

        public static void AddApplication(FormModel application)
        {
            applications.Add(application);
        }
    }
}
