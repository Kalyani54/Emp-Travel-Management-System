using ClassLibrary2_ClassModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2_DAL
{
    public interface IREQ_DAL
    {
        int RaiseRequest_DAL(int reqId, int empID, string fromLocation, string toLocation, DateTime date);

        int EditRequest_DAL(Travel2 travelRequest);

        int DeleteRequest_DAL(int reqId);

        int ApproveRequest_DAL(int travel_id, ApproveStatus appStatus);


        int ConfirmRequest_DAL(int travel_id, BookingStatus bookStatus, CurrentStatus current);

        void ViewAllRequest();
        Travel2 GetRequestById_DAL(int reqID);

        void ViewPendingApproveRequest_DAL();

        bool HasPendingRequests_DAL();

        void ViewForBooking_DAL();

        void JoinViewAll_DAL();
    }
}

