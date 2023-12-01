using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary2_ClassModel;

namespace ClassLibrary2_DAL
{
    public class REQ_DAL : IREQ_DAL
    {
        EMP_DAL EMP_DAL = new EMP_DAL();
        List<Travel2> lsttravel = new List<Travel2>()
        {
            new Travel2(){ reqID=101, EmpId =1,fromLocation="pune",toLocation="hyd",Date=DateTime.Parse("01-05-2002"),approve=ApproveStatus.Approved,bookingStatus=BookingStatus.Not_Available ,currentStatus=CurrentStatus.Closed },
                new Travel2(){reqID=102,EmpId=2,fromLocation="pune",toLocation="mumbai",Date=DateTime.Parse("03-01-2001"),approve=ApproveStatus.Approved,bookingStatus=BookingStatus.Pending,currentStatus=CurrentStatus.Open},
                 new Travel2(){reqID=103,EmpId=3,fromLocation="pune",toLocation="chennai",Date=DateTime.Parse("02-04-1999"),approve=ApproveStatus.Pending,bookingStatus=BookingStatus.Pending,currentStatus=CurrentStatus.Open },
                  new Travel2(){reqID=104,EmpId=4,fromLocation="pune",toLocation="Noida",Date=DateTime.Parse("03-05-1990"),approve=ApproveStatus.Not_Approved,bookingStatus=BookingStatus.Pending,currentStatus=CurrentStatus.Closed}
        };
        
        public int RaiseRequest_DAL(int reqId, int empID, string fromLocation, string toLocation, DateTime date)
        {
            
           
            // Check if the request ID already exists
            if (lsttravel.Any(req => req.reqID == reqId))
            {
                Console.WriteLine("Request ID already exists. Please choose another.");
                return 0;
            }

			// Check if the employee ID exists
			if (!EMP_DAL.lstEmployees.Any(emp => emp.EmpId == empID))
			{
				Console.WriteLine("Employee ID does not exist. Please enter a valid Employee ID.");
				return 0;
			}
			lsttravel.Add(new Travel2 { reqID = reqId, EmpId = empID, fromLocation = fromLocation, toLocation = toLocation, Date = date, approve = ApproveStatus.Pending, bookingStatus = BookingStatus.Pending, currentStatus = CurrentStatus.Open });
            return 1;
        }
        
        
        public int EditRequest_DAL(Travel2 travelRequest)
        {
           
            Console.WriteLine("In Edit - DAL");

            Travel2 travelreq_Main = lsttravel.FirstOrDefault(X => X.reqID == travelRequest.reqID);

            if (travelreq_Main != null)
            {
                int index = lsttravel.IndexOf(travelreq_Main);

                // Check if the new employee ID already exists
                if (lsttravel.Any(req => req.EmpId == travelRequest.EmpId && req.reqID != travelRequest.reqID))
                {
                    Console.WriteLine("Employee ID already exists in another request. Please choose another employee ID.");
                    return 0;
                }

                lsttravel[index].EmpId = travelRequest.EmpId;
                lsttravel[index].toLocation = travelRequest.toLocation;
                lsttravel[index].fromLocation = travelRequest.fromLocation;
                lsttravel[index].Date = travelRequest.Date;

                return 1;
            }
            else
            {
                Console.WriteLine("Travel Request Id not found.");
                return 0;
            }
        }

        public int DeleteRequest_DAL(int reqId)
        {
            Travel2 ticket = lsttravel.FirstOrDefault(t => t.reqID == reqId);
            if (ticket != null)
            {
                lsttravel.Remove(ticket);
                Console.WriteLine("Data deleted successfully...");
            }
            else
            {
                Console.WriteLine("Travel Request Id not found");
                return 0;
            }
            ViewAllRequest();
            return 1;
        }

        public int ApproveRequest_DAL(int travel_id, ApproveStatus appStatus)
        {
            Console.WriteLine("Employee with request Id {0} Booking Confimed", travel_id);
            Travel2 travel = lsttravel.FirstOrDefault(x => x.reqID == travel_id);
            int index = lsttravel.IndexOf(travel);
            if (travel != null)
            {
                lsttravel[index].approve = appStatus;
                lsttravel[index].currentStatus = CurrentStatus.Open;
                if (appStatus == ApproveStatus.Not_Approved)
                {
                    lsttravel[index].currentStatus = CurrentStatus.Closed;
                }
                return -1;
            }
            else
            {
                Console.WriteLine($"Travel request with ID {travel_id} was not found.");
                return 1;
            }
        }

        public int ConfirmRequest_DAL(int travel_id, BookingStatus bookStatus, CurrentStatus current)
        {
            Console.WriteLine("Employee with request Id {0} Booking Confimed", travel_id);
            Travel2 travel = lsttravel.FirstOrDefault(x => x.reqID == travel_id);
            int index = lsttravel.IndexOf(travel);
            if (travel != null)
            {
                lsttravel[index].bookingStatus = bookStatus;
                current = CurrentStatus.Open;
                if (bookStatus == BookingStatus.Not_Available || bookStatus == BookingStatus.Available)
                {
                    lsttravel[index].currentStatus = CurrentStatus.Closed;
                }
                return 1;

            }
            else
            {
                Console.WriteLine($"Travel request with ID {travel_id} was not found.");
                return 1;
            }
          
        }
        public void ViewAllRequest()
        {
            Console.WriteLine("\n");
            Console.WriteLine("                                         ********** Travel Request Details  **********");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------------");

            Console.WriteLine("{0,-15} | {1,-15} | {2,-15} | {3,-15} | {4,-15} | {5,-15} | {6,-15} | {7,-15}", " Req ID ", "Emp ID", "From Location", " Destination", "Approve St", "Booking St", "current St", " Req Date");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------------");

            foreach (Travel2 req in lsttravel)
            {
                Console.WriteLine("{0,-15} | {1,-15} | {2,-15} | {3,-15} | {4,-15} | {5,-15} | {6,-15} | {7,-15}",
                    req.reqID, req.EmpId, req.fromLocation, req.toLocation, req.approve, req.bookingStatus, req.currentStatus, req.Date);
            }
        }


        public Travel2 GetRequestById_DAL(int reqID)

        {
            Travel2 TravelReq = lsttravel.FirstOrDefault(t => t.reqID == reqID);

            if (TravelReq != null)

            {

                return TravelReq;

            }

            return null;

        }

        public void JoinViewAll_DAL()
        {
            var queryMethodView = from emp in EMP_DAL.lstEmployees
                                  join req in lsttravel
                                  on emp.EmpId equals req.EmpId
                                  select new
                                  {
                                      EId = emp.EmpId,
                                      ReqId = req.reqID,
                                      EfirstName = emp.FirstName,
                                      ElastName = emp.LastName,
                                      EContact = emp.Contact,
                                      EAddress = emp.Address,
                                      EDept = emp.Dept,
                                      EDob = emp.DOB,
                                      Floc = req.fromLocation,
                                      Tloc = req.toLocation,
                                      ApproveStatus = req.approve,
                                      BookingStatus = req.bookingStatus,
                                      CurrentStatus = req.currentStatus


                                  };

            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,-14} | {1,-14} | {2,-14} | {3,-14} | {4,-14} | {5,-14} | {6,-14} | {7,-14} | {8,-14}", "| Emp ID", "| Req ID", "| First Name", "| Last Name", "| From Location", "| To Location", "| Approve St", "| Booking St", "| Current St");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------");

            foreach (var request in queryMethodView)
            {
                Console.WriteLine("{0,-14} | {1,-14} | {2,-14} | {3,-14} | {4,-14} | {5,-14} | {6,-14} | {7,-14} | {8,-14}", request.EId, request.ReqId, request.EfirstName, request.ElastName, request.Floc, request.Tloc, request.ApproveStatus, request.BookingStatus, request.CurrentStatus);
            }

        }
        public void ViewPendingApproveRequest_DAL()
        {
            Console.WriteLine("\n");
            Console.WriteLine("                                         ********** Travel Request Details  **********");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------------");

            Console.WriteLine("{0,-15} | {1,-15} | {2,-15} | {3,-15} | {4,-15} | {5,-15} | {6,-15} | {7,-15}", " Req ID ", "Emp ID", "From Location", " Destination", "Approve St", "Booking St", "current St", " Req Date");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------------");

            foreach (Travel2 req in lsttravel)
            {
                if (req.approve == ApproveStatus.Pending)
                {
                    Console.WriteLine("{0,-15} | {1,-15} | {2,-15} | {3,-15} | {4,-15} | {5,-15} | {6,-15} | {7,-15}",
                        req.reqID, req.EmpId, req.fromLocation, req.toLocation, req.approve, req.bookingStatus, req.currentStatus, req.Date);
                }
            }
        }


        public bool HasPendingRequests_DAL()
        {
            return lsttravel.Any(req => req.approve == ApproveStatus.Pending);
        }

        public void ViewForBooking_DAL()
        {
            Console.WriteLine("\n");
            Console.WriteLine("                                         ********** Travel Request Details  **********");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------------");

			Console.WriteLine("{0,-15} | {1,-15} | {2,-15} | {3,-15} | {4,-15} | {5,-15} | {6,-15} | {7,-15}", " Req ID ", "Emp ID", "From Location", " Destination", "Approve St", "Booking St", "current St", " Req Date");
			Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------------");

			foreach (Travel2 req in lsttravel)
            {
                if (req.approve == ApproveStatus.Approved && req.currentStatus == CurrentStatus.Open)
                {
					Console.WriteLine("{0,-15} | {1,-15} | {2,-15} | {3,-15} | {4,-15} | {5,-15} | {6,-15} | {7,-15}",
						req.reqID, req.EmpId, req.fromLocation, req.toLocation, req.approve, req.bookingStatus, req.currentStatus, req.Date);
				}
            }
        }


    }
}
