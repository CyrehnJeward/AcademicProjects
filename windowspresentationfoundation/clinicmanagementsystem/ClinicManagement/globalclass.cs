using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    class globalclass
    {
        public static string username { get; set; }
        public static byte[] imageloc { get; set; }
        public static string idnum { get; set; }

        public static string staffID { get; set; }

        public static ClinicManagementDBDataContext clinic = new ClinicManagementDBDataContext(Properties.Settings.Default.FinalClinicMSConnectionString1);

    }
}
