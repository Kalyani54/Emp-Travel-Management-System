using ClassLibrary2_ClassModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary2_DAL;


namespace ClassLibrary2_BAL
{
    public class REQ_BAL : IREQ_BAL
    {
        private static readonly REQ_DAL ticket = new REQ_DAL();
        public int RaiseRequest_BAL(int reqId, int empID, string fromLocation, string toLocation, DateTime date, ApproveStatus approve, BookingStatus bookingStatus)
        {
            ticket.RaiseRequest_DAL(reqId, empID, fromLocation, toLocation, date);
            return 1;
        }

        public int EditRequest_BAL(Travel2 travelRequest)
        {
            ticket.EditRequest_DAL(travelRequest);
            return 1;
        }

        public int DeleteRequest_BAL(int reqId)
        {
            ticket.DeleteRequest_DAL(reqId);
            return 1;
        }

        public int ApproveRequest_BAL(int travel_id, ApproveStatus appStatus)
        {
            ticket.ApproveRequest_DAL(travel_id, appStatus);
            return 1;
        }
        public int ConfirmRequest_BAL(int travel_id, BookingStatus bookStatus)
        {
            ticket.ConfirmRequest_DAL(travel_id, bookStatus, CurrentStatus.Open);
            return 1;
        }

        public void ViewAllRequest_BAL()
        {
            ticket.ViewAllRequest();
        }

        public Travel2 GetRequestById_BAL(int reqID)
        {
            Travel2 TravelReq = ticket.GetRequestById_DAL(reqID);

            return TravelReq;

        }
        public void ViewPendingApproveRequest_BAL()
        {
            ticket.ViewPendingApproveRequest_DAL();
        }
        public bool HasPendingRequests_BAL()
        {
            return ticket.HasPendingRequests_DAL();
        }
        public void ViewForBooking_BAL()
        {
            ticket.ViewForBooking_DAL();
        }

        public void JoinViewAll_BAL()
        {
            ticket.JoinViewAll_DAL();
        }
    }
}
