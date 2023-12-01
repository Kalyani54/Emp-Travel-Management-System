using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary2_BAL;
using ClassLibrary2_ClassModel;

namespace ClassLibrary_Menu1
{
    public class Menu
    {
        private static readonly EMP_BAL _empBAL = new EMP_BAL();
        private static readonly REQ_BAL _ticketBAL = new REQ_BAL();
		public static void ShowMain()
		{
			Console.WriteLine("********************************************************************************");
			Console.WriteLine("                                     Main Menu");
			Console.WriteLine("********************************************************************************");
			int choices;
			Console.WriteLine("Select Choice");
			Console.WriteLine("1. Manage Employee");
			Console.WriteLine("2. Manage Travel Request");
			Console.WriteLine("3. Exit Application");

			if (int.TryParse(Console.ReadLine(), out choices))
			{
				switch (choices)
				{
					case 1:
						Console.Clear();
						ShowEmployeeManagement();
						break;
					case 2:
						Console.Clear();
						ShowTravelManagement();
						break;
					case 3:
						Environment.Exit(0);
						break;
					default:
						Console.WriteLine("Invalid choice");
						ShowMain();
						break;
				}
			}
			else
			{
				Console.WriteLine("Invalid input. Please enter a number.");
				ShowMain();
			}
		}

		public static void ShowEmployeeManagement()
		{
			Console.WriteLine("-------------------------------------------");
			Console.WriteLine("Manage Employee");
			Console.WriteLine("-------------------------------------------");
			Console.WriteLine("enter your process: ");
			Console.WriteLine("1. Add\n2. Edit\n3. Delete\n4. View\n5. Go Back\n6. Exit");
			Console.WriteLine("Enter a number (1-5) for the process.");
			int choice;

			if (int.TryParse(Console.ReadLine(), out choice))
			{
				switch (choice)
				{
					case 1:
						Console.Clear();
						ShowAddEmployee();
						break;

					case 2:
						Console.Clear();
						ShowEditEmployee();
						break;

					case 3:
						Console.Clear();
						ShowDeleteEmployee();
						break;

					case 4:
						Console.Clear();
						ShowAllEmployee();
						break;
					case 5:
						Console.Clear();
						ShowMain();
						break;
					case 6:
						Console.WriteLine("Exiting the application. Goodbye!");
						Environment.Exit(0);
						break;
					default:
						Console.WriteLine("Invalid Choice");
						ShowEmployeeManagement();
						break;
				}
			}
			else
			{
				Console.WriteLine("Invalid input. Please enter a valid number.");
				ShowEmployeeManagement();
			}
		}

		public static void ShowTravelManagement()
        {
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Manage Travel Request");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Enter your choice");
            Console.WriteLine("1. Raise Travel Request \n2. Edit Travel Request \n3. Delete Travel Request  \n4. Approve Travel Request  \n5. Confirm Booking  \n6. View All Travel Request \n7. Go Back \n8. Exit");
            int choice2;

			if (int.TryParse(Console.ReadLine(), out choice2)) 
			{
				switch (choice2)
				{
					case 1:
						Console.Clear();
						ShowRaiseTravelRequest();
						break;
					case 2:
						Console.Clear();
						ShowEditTravelRequest();
						break;
					case 3:
						Console.Clear();
						ShowDeleteTravelRequest();
						break;
					case 4:
						Console.Clear();
						ShowApproveTravelRequest();
						break;
					case 5:
						Console.Clear();
						ShowConfirmBooking();
						break;
					case 6:
						Console.Clear();
						ShowViewAllTravelRequest();
						break;
					case 7:
						Console.Clear();
						ShowMain();
						return;
					case 8:

						Console.WriteLine("Exiting the application. Goodbye!");
						Environment.Exit(0);

						break;
					default:
						Console.WriteLine("Invalid Choice");
						ShowTravelManagement();
						break;
				}
			}
			else
			{
				Console.WriteLine("Invalid input. Please enter a valid number.");
				ShowTravelManagement();
			}


		}

        public static void ShowAddEmployee()
        {
            try
            {

                int EmployeeID;
                string FirstName;
                string LastName;
                int Contact;
                string Address;
                string Dept;
                DateTime DOB;
                Console.WriteLine("Add Employee Details");
                Console.WriteLine("Enter Employee Id");
                EmployeeID = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Employee FirstName");
                FirstName = Console.ReadLine();
                Console.WriteLine("Enter Employee LastName");
                LastName = Console.ReadLine();
                Console.WriteLine("Enter Employee Contact");
                Contact = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Employee Address");
                Address = (Console.ReadLine());
                Console.WriteLine("Enter Employee Department");
                Dept = Console.ReadLine();
                Console.WriteLine("Enter Employee DOB");
                DOB = DateTime.Parse(Console.ReadLine());

                EMP_BAL employee = new EMP_BAL();
                employee.AddEmployee_BAl(EmployeeID, FirstName, LastName, Contact, Address, Dept, DOB);
                _empBAL.ViewEmployee_BAL();
                ShowEmployeeManagement();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }



        }

		public static void ShowEditEmployee()
		{
			try
			{
				Console.WriteLine("----------------------------");
				Console.WriteLine("Edit Employee");
				Console.WriteLine("----------------------------");

				Console.WriteLine("Display all Employees:");
				_empBAL.ViewEmployee_BAL();

				Console.WriteLine("Enter Employee Id to edit (or '0' to go back):");
				if (int.TryParse(Console.ReadLine(), out int employeeID))
				{
					if (employeeID == 0)
					{
						Console.WriteLine("Going back to Employee Management.");
						ShowEmployeeManagement(); // Go back to the Employee Management menu
						return;
					}

					// Get the employee to change from BAL
					Employee2 emp_to_change = _empBAL.GetEmployeeById_BAL(employeeID);
					if (emp_to_change != null)
					{
						Console.WriteLine("Request found. Editing Employee ID: " + employeeID);
						while (true)
						{
							Console.WriteLine("1. First Name\n2. Last Name\n3. Contact\n4. Address\n5. Department\n6. DOB\n7. Go Back To Employee Management\n8. Exit");
							Console.WriteLine("Enter field number to edit:");

							if (int.TryParse(Console.ReadLine(), out int choice))
							{
								switch (choice)
								{
									// Editing options
									case 1:
										Console.WriteLine("Enter Employee FirstName:");
										emp_to_change.FirstName = Console.ReadLine();
										break;
									case 2:
										Console.WriteLine("Enter Employee LastName:");
										emp_to_change.LastName = Console.ReadLine();
										break;
									case 3:
										Console.WriteLine("Enter Employee Contact:");
										if (int.TryParse(Console.ReadLine(), out int contact))
										{
											emp_to_change.Contact = contact;
										}
										else
										{
											Console.WriteLine("Invalid contact format. Please enter a number.");
										}
										break;
									case 4:
										Console.WriteLine("Enter Employee Address:");
										emp_to_change.Address = Console.ReadLine();
										break;
									case 5:
										Console.WriteLine("Enter Employee Department:");
										emp_to_change.Dept = Console.ReadLine();
										break;
									case 6:
										Console.WriteLine("Enter Employee DOB:");
										if (DateTime.TryParse(Console.ReadLine(), out DateTime dob))
										{
											emp_to_change.DOB = dob;
										}
										else
										{
											Console.WriteLine("Invalid date format.");
										}
										break;
									case 7:
										ShowEmployeeManagement();
										return; // Return to the Employee Management menu
									case 8:
										Console.WriteLine("Exit");
										return; // Exit the Edit Employee menu
									default:
										Console.WriteLine("Invalid Choice");
										break;
								}

								_empBAL.ViewEmployee_BAL();
							}
							else
							{
								Console.WriteLine("Invalid choice. Please enter a number.");
							}
						}
					}
					else
					{
						Console.WriteLine("Employee not found with Employee ID: " + employeeID);
						ShowEditEmployee();
					}
				}
				else
				{
					Console.WriteLine("Invalid Employee ID. Please enter a number.");
					ShowEditEmployee();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("An error occurred: " + ex.Message);
			}
		}

		public static void ShowDeleteEmployee()
		{
			try
			{
				Console.WriteLine("----------------------------");
				Console.WriteLine("Delete Employee");
				Console.WriteLine("----------------------------");

				Console.WriteLine("Display all Employees:");
				_empBAL.ViewEmployee_BAL();

				Console.WriteLine("Enter Employee Id to delete (or '0' to go back):");
				if (int.TryParse(Console.ReadLine(), out int employeeID))
				{
					if (employeeID == 0)
					{
						Console.WriteLine("Going back to Employee Management.");
						ShowEmployeeManagement(); // Go back to the Employee Management menu
						return;
					}

					// Check if the employee with the specified ID exists
					Employee2 emp_to_delete = _empBAL.GetEmployeeById_BAL(employeeID);
					if (emp_to_delete != null)
					{
						_empBAL.DeleteEmployee_BAl(employeeID);
						Console.WriteLine("Employee with ID " + employeeID + " has been deleted.");
					}
					else
					{
						Console.WriteLine("Employee not found with Employee ID: " + employeeID);
						ShowDeleteEmployee();
					}

					ShowEmployeeManagement();
				
				}
				else
				{
					Console.WriteLine("Invalid Employee ID. Please enter a number.");
					ShowDeleteEmployee();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("An error occurred: " + ex.Message);
			}
		}

		public static void ShowAllEmployee()
        {

            Console.WriteLine("List of all Employees");

            _empBAL.ViewEmployee_BAL();
            ShowEmployeeManagement();




        }

		public static void ShowRaiseTravelRequest()
		{
			try
			{
				int empID;
				int reqID;
				string fromLocation;
				string toLocation;
				DateTime date;
				ApproveStatus approve;
				BookingStatus booking;

				Console.WriteLine("--------  Raise a Ticket  ----------");

				Console.WriteLine("Request ID:");
				if (int.TryParse(Console.ReadLine(), out reqID))
				{
					Console.WriteLine("Enter Employee Id:");
					if (int.TryParse(Console.ReadLine(), out empID))
					{
						Console.WriteLine("Enter Origin Location:");
						fromLocation = Console.ReadLine();
						Console.WriteLine("Enter Destination Location:");
						toLocation = Console.ReadLine();
						Console.WriteLine("Enter Date (YYYY-MM-DD):");
						if (DateTime.TryParse(Console.ReadLine(), out date))
						{
							_ticketBAL.RaiseRequest_BAL(reqID, empID, fromLocation, toLocation, date, approve = ApproveStatus.Pending, booking = BookingStatus.Pending);
							_ticketBAL.ViewAllRequest_BAL();
							ShowTravelManagement();
						}
						else
						{
							Console.WriteLine("Invalid date format. Please enter a valid date (YYYY-MM-DD).");
							ShowRaiseTravelRequest();
						}
					}
					else
					{
						Console.WriteLine("Invalid Employee ID. Please enter a number.");
						ShowRaiseTravelRequest();
					}
				}
				else
				{
					Console.WriteLine("Invalid Request ID. Please enter a number.");
					ShowRaiseTravelRequest();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("An error occurred: " + ex.Message);
			}
		}


		public static void ShowEditTravelRequest()
		{
			try
			{
				Console.WriteLine("----------------------------");
				Console.WriteLine("Edit Travel Request");
				Console.WriteLine("----------------------------");

				while (true)
				{
					Console.WriteLine("Display all Travel Requests:");
					_ticketBAL.ViewAllRequest_BAL();
					Console.WriteLine("Enter Request Id to edit (or '0' to go back):");

					if (int.TryParse(Console.ReadLine(), out int reqID))
					{
						if (reqID == 0)
						{
							Console.WriteLine("Going back to Travel Management.");
							ShowTravelManagement(); // Go back to the Travel Management menu
						}
						else
						{
							Travel2 req_to_change = _ticketBAL.GetRequestById_BAL(reqID);
							if (req_to_change != null)
							{
								Console.WriteLine("Request found. Editing Request ID: " + reqID + " Enter another request ID.");
								while (true)
								{
									Console.WriteLine("1. Origin Location\n2. Destination Location\n3. Date\n4. Go Back\n5. Exit");
									Console.WriteLine("Enter field number:");

									if (int.TryParse(Console.ReadLine(), out int choice))
									{
										switch (choice)
										{
											// Editing options
											case 1:
												Console.WriteLine("Enter Origin Location:");
												req_to_change.fromLocation = Console.ReadLine();
												break;
											case 2:
												Console.WriteLine("Enter Destination Location:");
												req_to_change.toLocation = Console.ReadLine();
												break;
											case 3:
												Console.WriteLine("Enter Date:");
												if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
												{
													req_to_change.Date = date;
												}
												else
												{
													Console.WriteLine("Invalid date format.");
												}
												break;
											// Navigation options
											case 4:
												Console.WriteLine("Go Back");
                                                ShowTravelManagement();
												return; // Return to the previous menu
											case 5:
												Console.WriteLine("Exit");
												return; // Exit the Edit Travel Request menu
											default:
												Console.WriteLine("Invalid Choice");
												break;
										}

										_ticketBAL.ViewAllRequest_BAL();
									}
									else
									{
										Console.WriteLine("Invalid choice. Please enter a number.");
									}
								}
							}
							else
							{
								Console.WriteLine("Request not found with Request ID: " + reqID);
							}
						}
					}
					else
					{
						Console.WriteLine("Invalid Request ID. Please enter a number.");
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("An error occurred: " + ex.Message);
			}
		}

		public static void ShowDeleteTravelRequest()
        {
            try
            {


                _ticketBAL.ViewAllRequest_BAL();
                Console.WriteLine("Delete Travel Request");
                Console.Write("Enter the Request ID to delete: ");
				int requestID;
				
				if (int.TryParse(Console.ReadLine(), out requestID)) {
					_ticketBAL.DeleteRequest_BAL(requestID);
				}
				else{
					Console.WriteLine("Invalid Request ID. Please enter a number.");
					ShowDeleteTravelRequest();
					ShowTravelManagement();
				}

				

            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }

        }

        public static void ShowViewAllTravelRequest()
        {
            Console.WriteLine("Viewing All Travel Requests");
            // _ticketBAL.ViewAllRequest_BAL();
            _ticketBAL.JoinViewAll_BAL();
            ShowTravelManagement();

        }

		public static void ShowApproveTravelRequest()
		{
			try
			{
				_ticketBAL.ViewPendingApproveRequest_BAL();

				// Check if there are any pending requests
				if (!_ticketBAL.HasPendingRequests_BAL())
				{
					Console.WriteLine("No pending requests to approve.");
					ShowTravelManagement();
					return;
				}

				Console.WriteLine("Enter request id to change status:");
				if (int.TryParse(Console.ReadLine(), out int reqID))
				{
					Travel2 req_to_approve = _ticketBAL.GetRequestById_BAL(reqID);
					if (req_to_approve != null)
					{
						Console.WriteLine("1. Approved\n2. Not Approved\n3. Go Back");

						int choice;
                       if (int.TryParse(Console.ReadLine(), out choice)) {
							ApproveStatus approve = ApproveStatus.Pending;

							switch (choice)
							{
								case 1:
									approve = ApproveStatus.Approved;
									break;
								case 2:
									approve = ApproveStatus.Not_Approved;
									break;
								case 3:
									Console.WriteLine("Go Back");
									ShowTravelManagement();
									return;
							}
							_ticketBAL.ApproveRequest_BAL(reqID, approve);
							_ticketBAL.ViewAllRequest_BAL();
							ShowTravelManagement();
						}
						else
						{
							Console.WriteLine("Invalid Request ID. Please enter a number.");
							ShowApproveTravelRequest();
						}


					}
					else
					{
						Console.WriteLine("Request not found with Request ID: " + reqID);
					}
				}
				else
				{
					Console.WriteLine("Invalid Request ID. Please enter a number.");
					ShowApproveTravelRequest();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("An error occurred: " + ex.Message);
			}
		}

		public static void ShowConfirmBooking()
		{
			try
			{
				_ticketBAL.ViewForBooking_BAL();
				Console.WriteLine("Enter request id to change status (or '0' to go back):");
				if (int.TryParse(Console.ReadLine(), out int reqID))
				{
					if (reqID == 0)
					{
						Console.WriteLine("Going back to Travel Management.");
						ShowTravelManagement(); // Go back to the Travel Management menu
						return;
					}

					// Check if the request ID exists
					Travel2 req_to_change = _ticketBAL.GetRequestById_BAL(reqID);
					if (req_to_change == null)
					{
						Console.WriteLine("Request not found with Request ID: " + reqID);
						ShowConfirmBooking();
						return;
					}

					Console.WriteLine("1. Available\n2. Not Available\n3. Go Back");
					if (int.TryParse(Console.ReadLine(), out int choice))
					{
						BookingStatus book = BookingStatus.Not_Available;
						switch (choice)
						{
							case 1:
								book = BookingStatus.Available;
								break;
							case 2:
								book = BookingStatus.Not_Available;
								break;
							case 3:
								Console.WriteLine("Go Back");
								ShowTravelManagement();
								return;
							default:
								Console.WriteLine("Invalid choice. Please enter 1, 2, or 3.");
								return;
						}
						_ticketBAL.ConfirmRequest_BAL(reqID, book);
						_ticketBAL.ViewAllRequest_BAL();
						ShowTravelManagement();
					}
					else
					{
						Console.WriteLine("Invalid choice. Please enter a number");
						ShowConfirmBooking();
					}
				}
				else
				{
					Console.WriteLine("Invalid Request ID. Please enter a valid number.");
					ShowConfirmBooking();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("An error occurred: " + ex.Message);
			}
		}


	}
}
