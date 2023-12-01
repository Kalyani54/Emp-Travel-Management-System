using ClassLibrary2_ClassModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClassLibrary2_BAL
{
    public interface IREQ_BAL
    {
        int RaiseRequest_BAL(int reqId, int empID, string fromLocation, string toLocation, DateTime date, ApproveStatus approve, BookingStatus bookingStatus);

        int EditRequest_BAL(Travel2 travelRequest);

        int DeleteRequest_BAL(int reqId);

        int ApproveRequest_BAL(int travel_id, ApproveStatus appStatus);
        int ConfirmRequest_BAL(int travel_id, BookingStatus bookStatus);

        void ViewAllRequest_BAL();

        Travel2 GetRequestById_BAL(int reqID);

        void ViewPendingApproveRequest_BAL();

        bool HasPendingRequests_BAL();

        void ViewForBooking_BAL();

        void JoinViewAll_BAL();
    }
}
