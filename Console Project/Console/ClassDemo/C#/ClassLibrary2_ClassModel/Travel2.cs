
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2_ClassModel
{

    public enum ApproveStatus { Approved, Not_Approved, Pending };
    public enum BookingStatus { Available, Not_Available, Pending };

    public enum CurrentStatus { Open, Closed };
    public class Travel2
    {
        public int reqID { get; set; }

        public int EmpId { get; set; }
        public string fromLocation { get; set; }
        public string toLocation { get; set; }

        public DateTime Date { get; set; }

        public ApproveStatus approve { get; set; }
        public BookingStatus bookingStatus { get; set; }

        public CurrentStatus currentStatus { get; set; }


    }
}