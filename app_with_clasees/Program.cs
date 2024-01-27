using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_with_clasees
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<Customer> customer_data = new List<Customer>();
            List<Planner> planner_data = new List<Planner>();
            List<Admin> admin_data = new List<Admin>();
            List<Users> user_data = new List<Users>();
           
            string[] planners = new string[100];
            
            string[] new_packs = new string[100];
            string[] new_pack_types = new string[100];
            string[] selected_planners = new string[100];
            string[] pack_status = new string[100];
          
            float[] prices = new float[100];
            int signInIdx = 0;
            int idx = 0;
            int customerIdx = 0;
            int plannersIdx = 3;
            string name = "";
            string date = "";
            string timee = "";
            string type = "4";
            string planner_type = "4";
            string exit = "1";
            int choosed_planner = 0;
            int[] planner_Index = new int[100];
            int[] customer_Index = new int[100];
            planners[0] = "Sam";
            new_packs[0] = "Nothing Special";
            new_pack_types[0] = "Birthday";
            pack_status[0] = "Approved";
            planner_Index[0] = 0;
            planners[1] = "Jazzy";
            new_packs[1] = "Nothing Special";
            new_pack_types[1] = "Wedding";
            pack_status[1] = "Approved";
            planner_Index[1] = 1;
            planners[2] = "Zoraiz";
            new_packs[2] = "Nothing Special";
            new_pack_types[2] = "Concert";
            pack_status[2] = "Approved";
            planner_Index[2] = 2;
            string packagesPath = "C:\\Hamna\\semester1\\PD\\businessapp\\pack2.txt";
            string usersPath = "C:\\Hamna\\semester1\\PD\\businessapp\\u2.txt";
            string EventsPath = "C:\\Hamna\\semester1\\PD\\businessapp\\event2.txt";
           // loadUsers(Usernames, passwords, roles, usersPath, ref idx);
            //loadPackages(planners, new_packs, new_pack_types, pack_status, planner_Index, prices, packagesPath, ref plannersIdx);
            //loadEvents(customerName, dates, times, Events, customers, booked, customer_Index, total_Bill, ref customerIdx, EventsPath, selected_planners);
            
            while (true)
            {
                Console.Clear();
                Printheader();
                print_intro();
                switch (loginMenu())
                {
                    case "1":
                        {
                            Console.Clear();
                            Printheader();
                            print_intro();
                            Console.SetCursorPosition(35, 25);
                            Console.WriteLine("---------------------------------------");
                            Console.SetCursorPosition(35, 26);
                            Console.WriteLine("             Enter Username:           ");
                            Console.SetCursorPosition(35, 27);
                            string username = Console.ReadLine();
                            Console.SetCursorPosition(35, 28);
                            Console.WriteLine("             Enter password:           ");
                            Console.SetCursorPosition(35, 29);
                            string password = Console.ReadLine();
                            string role = signin(user_data, username, password, idx, ref signInIdx);
                            Console.SetCursorPosition(35, 30);
                            Console.WriteLine("              Role: " + role);
                            Console.SetCursorPosition(35, 31);
                            Console.WriteLine("---------------------------------------");
                            Console.ReadKey();
                            exit = "1";
                            if (role == "Customer"|| role=="customer")
                            {
                                string events="", plannerName="";
                                float total_bill=0;
                                //string currentuser = username;
                                int count = 0;
                                while (exit != "0")
                                {
                                    switch (customerMenu())
                                    {
                                        case "1":
                                            if (plannersIdx == 0)
                                            {
                                                Console.WriteLine("THERE IS NO PLANNER YET.");
                                                Console.ReadKey();
                                                continue;
                                            }
                                           
                                            Console.Clear();
                                            Printheader();
                                            Console.WriteLine(" ");
                                            Console.WriteLine(" ");
                                            Console.WriteLine(" ");
                                            Console.WriteLine("     Enter your Name: ");
                                            name = Console.ReadLine();
                                            Console.WriteLine(" ");
                                            Console.WriteLine("     Enter the Date for Event(DD/MM/YY): ");
                                            date = Console.ReadLine();
                                            Console.WriteLine(" ");
                                            Console.WriteLine("     Enter the time of Event:(ToMorning/Evening) ");
                                            timee = Console.ReadLine();
                                            Console.SetCursorPosition(35, 23);
                                            Console.WriteLine("      _________________   ");
                                            Console.SetCursorPosition(35, 24);
                                            Console.WriteLine("       Types of Event:    ");
                                            Console.SetCursorPosition(35, 25);
                                            Console.WriteLine("      _________________   ");
                                            Console.WriteLine(" ");
                                            Console.WriteLine("        1: BIRTHDAY PARTY");
                                            Console.WriteLine("        2: WEDDING EVENTS");
                                            Console.WriteLine("        3: CONCERT");
                                            Console.WriteLine(" ");
                                            while (true)
                                            {
                                                Console.WriteLine("Select your required Type: ");
                                                switch (Console.ReadLine())
                                                {
                                                    case "1":
                                                        if (check_planner_exsist("Birthday", new_pack_types, pack_status, plannersIdx))
                                                        {
                                                            int x = 30;
                                                            int y = 38;
                                                            Console.Clear();
                                                            Printheader();
                                                            print_predefined_Birthday_Pack(30, 20);
                                                            print_bday_planner(planners, new_packs, new_pack_types, pack_status, prices, planner_Index, plannersIdx, ref x, ref y);
                                                            y += 10;
                                                            float bill = birthday(ref x, ref y, prices);
                                                            while (true)
                                                            {
                                                                Console.SetCursorPosition(x, y + 12);
                                                                Console.WriteLine("Which planner do you want to select(select on the basis of planner no):");
                                                                string planner = Console.ReadLine();
                                                                if (check_int(planner))
                                                                {
                                                                    choosed_planner = int.Parse(planner);
                                                                }
                                                                if (new_pack_types[choosed_planner] == "Birthday" && pack_status[choosed_planner] == "Approved")
                                                                {
                                                                    break;
                                                                }
                                                                Console.WriteLine("You choose wrong planner");
                                                            }
                                                            bill = prices[choosed_planner] + bill;
                                                            Console.WriteLine("");
                                                            Console.WriteLine("                                YOUR TOTAL BILL:" + bill);
                                                            events = "Birthday";
                                                            total_bill = bill;
                                                            customer_Index[customerIdx] = customerIdx;
                                                            Console.ReadKey();
                                                        }
                                                        else
                                                        {
                                                            Console.Clear();
                                                            Printheader();
                                                            Console.WriteLine(" ");
                                                            Console.WriteLine("There is no planner who is giving birthday package");
                                                            Console.ReadKey();
                                                        }
                                                        break;
                                                    case "2":
                                                        if (check_planner_exsist("Wedding", new_pack_types, pack_status, plannersIdx))
                                                        {
                                                            int x2 = 30;
                                                            int y2 = 85;
                                                            Console.Clear();
                                                            Printheader();
                                                            print_predefined_Wedd_Pack(30, 20);
                                                            print_wedd_planner(planners, new_packs, new_pack_types, pack_status, prices, planner_Index, plannersIdx, ref x2, ref y2);
                                                            y2 += 10;
                                                            float bill = wedding(ref x2, ref y2, prices);
                                                            while (true)
                                                            {
                                                                Console.SetCursorPosition(x2, y2 + 20);
                                                                Console.WriteLine("Which planner do you want to select(select on the basis of planner no)/(press 0 for no one):");
                                                                string planner2 = Console.ReadLine();
                                                                if (check_int(planner2))
                                                                {
                                                                    choosed_planner = int.Parse(planner2);
                                                                }
                                                                if (new_pack_types[choosed_planner] == "Wedding" && pack_status[choosed_planner] == "Approved")
                                                                {
                                                                    break;
                                                                }
                                                                Console.WriteLine("You choose wrong planner");
                                                            }
                                                            bill = prices[choosed_planner] + bill;
                                                            bill = prices[choosed_planner] + bill;
                                                            Console.WriteLine("");
                                                            Console.WriteLine("                                YOUR TOTAL BILL:" + bill);
                                                            events = "Wedding";
                                                            total_bill = bill;
                                                            customer_Index[customerIdx] = customerIdx;
                                                            Console.ReadKey();
                                                        }
                                                        else
                                                        {
                                                            Console.Clear();
                                                            Printheader();
                                                            Console.WriteLine("");
                                                            Console.WriteLine("There is no planner who is giving wedding package");
                                                            Console.ReadKey();
                                                        }
                                                        break;
                                                    case "3":
                                                        if (check_planner_exsist("Concert", new_pack_types, pack_status, plannersIdx))
                                                        {
                                                            int x3 = 30;
                                                            int y3 = 38;
                                                            Console.Clear();
                                                            Printheader();
                                                            print_predefined_Concert_Pack(30, 20);
                                                            print_concert_planner(planners, new_packs, new_pack_types, pack_status, prices, planner_Index, plannersIdx, ref x3, ref y3);
                                                            y3 += 10;
                                                            float bill = concert(ref x3, ref y3, prices);
                                                            while (true)
                                                            {
                                                                Console.SetCursorPosition(x3, y3 + 15);
                                                                Console.WriteLine("Which planner do you want to select(select on the basis of planner no)/(press 0 for no one):");
                                                                string planner3 = Console.ReadLine();
                                                                if (check_int(planner3))
                                                                {
                                                                    choosed_planner = int.Parse(planner3);
                                                                }
                                                                if (new_pack_types[choosed_planner] == "Concert" && pack_status[choosed_planner] == "Approved")
                                                                {
                                                                    break;
                                                                }
                                                                Console.WriteLine("You choose wrong planner");
                                                            }
                                                            bill = prices[choosed_planner] + bill;
                                                            bill = prices[choosed_planner] + bill;
                                                            Console.WriteLine(" ");
                                                            Console.WriteLine("                                YOUR TOTAL BILL:" + bill);
                                                            events = "Concert";
                                                            total_bill = bill;
                                                            customer_Index[customerIdx] = customerIdx;
                                                            Console.ReadKey();
                                                        }
                                                        else
                                                        {
                                                            Console.Clear();
                                                            Printheader();
                                                            Console.WriteLine(" ");
                                                            Console.WriteLine("There is no planner who is giving concert package");
                                                            Console.ReadKey();
                                                        }
                                                        break;
                                                    default:
                                                        goto IL_0892;
                                                }
                                                break;
                                            IL_0892:
                                                Console.WriteLine("there is no such type");
                                            }
                                            Console.WriteLine("Enter 0 to exit or 1 to book: ");
                                            exit = Console.ReadLine();
                                            plannerName = planners[choosed_planner];
                                            Customer booking = new Customer(username,password,name, events, date,timee,"Pending",plannerName,total_bill);
                                            customer_data.Add(booking);
                                            customerIdx++;
                                           // storeEvents(customerName, dates, times, Events, customers, booked, customer_Index, total_Bill, customerIdx, EventsPath, selected_planners);
                                            continue;
                                        case "2":
                                            {
                                                Console.Clear();
                                                Printheader();
                                                print_predefined_Birthday_Pack(30, 20);
                                                print_predefined_Wedd_Pack(30, 38);
                                                print_predefined_Concert_Pack(30, 105);
                                                Console.WriteLine("Enter Any Key to View the Packages offered by differnt planners.");
                                                Console.ReadKey();
                                                //bool flag2 = true;
                                                Console.Clear();
                                                Printheader();
                                                if (plannersIdx == 0)
                                                {
                                                    Console.WriteLine();
                                                    Console.WriteLine("                   THERE ARE NO PLANNERS YET!");
                                                    Console.WriteLine(" ");
                                                    Console.WriteLine("Enter any key to exit: ");
                                                    Console.ReadKey();
                                                }
                                                else
                                                {
                                                    print_new_packs(planners, new_packs, new_pack_types, pack_status, planner_Index, prices, plannersIdx);
                                                    Console.WriteLine(" ");
                                                    Console.WriteLine("Enter any key to exit: ");
                                                    Console.ReadKey();
                                                }
                                                continue;
                                            }
                                        case "3":
                                            Console.Clear();
                                            Printheader();
                                            Console.WriteLine(" ");
                                            Console.WriteLine(" ");
                                            view_Selected_CustomerEvents(customer_data, customer_Index, username, customerIdx, ref count);
                                            Console.WriteLine("Enter any key to Exit: ");
                                            Console.ReadKey();
                                            continue;
                                        case "4":
                                            while (true)
                                            {
                                                Console.Clear();
                                                Printheader();
                                                view_Selected_CustomerEvents(customer_data,  customer_Index, username, customerIdx, ref count);
                                                Console.WriteLine(" ");
                                                string edit_option = editMenu();
                                                if (edit_option == "0")
                                                {
                                                    break;
                                                }
                                                string sr;
                                                while (true)
                                                {
                                                    Console.WriteLine("Enter the SR number on which you want to edit: ");
                                                    sr = Console.ReadLine();
                                                    if (check_int(sr))
                                                    {
                                                        break;
                                                    }
                                                    Console.WriteLine("Entered Wrong Serial nmber.");
                                                }
                                                int serial = int.Parse(sr);
                                                if (customer_data[serial].status == "Pending" && customer_data[serial].Username == username)
                                                {
                                                    switch (edit_option)
                                                    {
                                                        case "1":
                                                            Console.WriteLine("Enter New Name: ");
                                                            customer_data[serial].CustomerName = Console.ReadLine();
                                                            break;
                                                        case "2":
                                                            Console.WriteLine("Enter New Date: ");
                                                            customer_data[serial].date = Console.ReadLine();
                                                            break;
                                                        case "3":
                                                            Console.WriteLine("Enter New Time: ");
                                                            customer_data[serial].time = Console.ReadLine();
                                                            break;
                                                        default:
                                                            Console.WriteLine("There is no other option.");
                                                            break;
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine(" ");
                                                    Console.WriteLine("           YOU CHOOSE WRONG SR NUMBER (you can only choose sr num written above)");
                                                }
                                            }
                                            Console.WriteLine(" ");
                                            Console.WriteLine(" ");
                                            //storeEvents(customerName, dates, times, Events, customers, booked, customer_Index, total_Bill, customerIdx, EventsPath, selected_planners);
                                            Console.ReadKey();
                                            continue;
                                        case "5":
                                            {
                                                Console.Clear();
                                                Printheader();
                                                view_Selected_CustomerEvents(customer_data, customer_Index, username, customerIdx, ref count);
                                                Console.WriteLine(" ");
                                               // bool flag = true;
                                                Console.WriteLine("Enter 1 to continue or 0 to exit");
                                                string end = Console.ReadLine();
                                                if (end == "0")
                                                {
                                                    continue;
                                                }
                                                string sr2;
                                                while (true)
                                                {
                                                    Console.WriteLine("Enter the SR number on which you want to del: ");
                                                    sr2 = Console.ReadLine();
                                                    if (check_int(sr2))
                                                    {
                                                        break;
                                                    }
                                                    Console.WriteLine("Entered Wrong Serial nmber.");
                                                }
                                                int serial2 = int.Parse(sr2);
                                                if (customer_data[serial2].status == "Pending" && customer_data[serial2].Username == username)
                                                {
                                                    for (int i = serial2; i < customerIdx; i++)
                                                    {
                                                        customer_data[i].CustomerName = customer_data[i+1].CustomerName;
                                                        customer_data[i].date = customer_data[i+1].date;
                                                        customer_data[i].time = customer_data[i+1].time;
                                                        customer_data[i].events = customer_data[i+1].events;
                                                        customer_data[i].status = customer_data[i+1].status;
                                                        customer_data[i].planner = customer_data[i+1].planner;
                                                        customer_data[i].bill = customer_data[i+1].bill;
                                                    }
                                                    customerIdx--;
                                                    //storeEvents(customerName, dates, times, Events, customers, booked, customer_Index, total_Bill, customerIdx, EventsPath, selected_planners);
                                                }
                                                else
                                                {
                                                    Console.WriteLine(" ");
                                                    Console.WriteLine("           YOU CHOOSE WRONG SR NUMBER (you can only choose sr num written above)");
                                                }
                                                Console.ReadKey();
                                                continue;
                                            }
                                        default:
                                            continue;
                                        case "6":
                                            break;
                                    }
                                    break;
                                }
                            }
                            else if (role == "Planner" || role == "planner")
                            {
                                exit = "1";
                                while (exit != "0")
                                {
                                    switch (plannerMenu())
                                    {
                                        case "1":
                                            {
                                                int count2 = 0;
                                                string currentuser = username;
                                                Console.Clear();
                                                Printheader();
                                                view_Selected_PlannerEvents(customer_data, currentuser, customerIdx, ref count2);
                                                Console.WriteLine(" ");
                                                Console.WriteLine(" ");
                                                if (count2 == 0)
                                                {
                                                    Console.WriteLine("                 THERE ARE NO CUSTOMERS YET!");
                                                    Console.ReadKey();
                                                    continue;
                                                }
                                                Console.WriteLine("Choose 1 for YES or 0 for NO");
                                                for (int j = 0; j < customerIdx + 1; j++)
                                                {
                                                    if (customer_data[j].status == "Pending" && selected_planners[j] == currentuser)
                                                    {
                                                        Console.WriteLine(" ");
                                                        Console.WriteLine("Do You Want to Add " + j + " Customer?");
                                                        string choose = Console.ReadLine();
                                                        if (choose == "1")
                                                        {
                                                            customer_data[j].status = "Booked";
                                                        }
                                                    }
                                                }
                                                Console.ReadKey();
                                                continue;
                                            }
                                        case "2":
                                            Console.Clear();
                                            Printheader();
                                            print_predefined_Birthday_Pack(30, 20);
                                            print_predefined_Wedd_Pack(30, 38);
                                            print_predefined_Concert_Pack(30, 105);
                                            Console.WriteLine(" ");
                                            Console.WriteLine("Enter Any Key to View the Packages offered by differnt planners.");
                                            Console.ReadKey();
                                            Console.Clear();
                                            Printheader();
                                            print_new_packs(planners, new_packs, new_pack_types, pack_status, planner_Index, prices, plannersIdx);
                                            Console.WriteLine("Enter any key to exit: ");
                                            Console.ReadKey();
                                            continue;
                                        case "3":
                                            {
                                                int count3 = 0;
                                                string currentuser = username;
                                                Console.Clear();
                                                Printheader();
                                                Console.WriteLine(" ");
                                                Console.WriteLine(" ");
                                                print_selected_planner_packages(planners, new_packs, new_pack_types, pack_status, planner_Index, currentuser, prices, plannersIdx, ref count3);
                                                if (count3 == 0)
                                                {
                                                    Console.WriteLine("                YOU HAVE NOT ADDED ANY PLANS YET!");
                                                    Console.ReadKey();
                                                }
                                                Console.ReadKey();
                                                continue;
                                            }
                                        case "4":
                                            {
                                                planners[plannersIdx] = username;
                                                Console.Clear();
                                                Printheader();
                                                Console.WriteLine(" ");
                                                Console.WriteLine("Press 1 to continue or 0 to exit:");
                                                string end2 = Console.ReadLine();
                                                if (end2 == "0")
                                                {
                                                    continue;
                                                }
                                                Console.SetCursorPosition(50, 19);
                                                Console.WriteLine("SELECT THE TYPE OF EVENT IN WHICH YOU WANT TO ADD PLAN.  ");
                                                Console.SetCursorPosition(50, 20);
                                                Console.WriteLine("      _________________   ");
                                                Console.SetCursorPosition(50, 21);
                                                Console.WriteLine("       Types of Event:    ");
                                                Console.SetCursorPosition(50, 22);
                                                Console.WriteLine("      _________________   ");
                                                Console.WriteLine(" ");
                                                Console.SetCursorPosition(50, 24);
                                                Console.WriteLine("        1: BIRTHDAY PARTY");
                                                Console.SetCursorPosition(50, 25);
                                                Console.WriteLine("        2: WEDDING EVENTS");
                                                Console.SetCursorPosition(50, 26);
                                                Console.WriteLine("        3: CONCERT");
                                                Console.WriteLine(" ");
                                                while (planner_type != "1" || planner_type != "2" || planner_type != "3")
                                                {
                                                    Console.SetCursorPosition(50, 28);
                                                    Console.WriteLine("Select your required Type: ");
                                                    planner_type = Console.ReadLine();
                                                    switch (planner_type)
                                                    {
                                                        case "1":
                                                            new_pack_types[plannersIdx] = "Birthday";
                                                            break;
                                                        case "2":
                                                            new_pack_types[plannersIdx] = "Wedding";
                                                            break;
                                                        case "3":
                                                            new_pack_types[plannersIdx] = "Concert";
                                                            break;
                                                        default:
                                                            continue;
                                                    }
                                                    break;
                                                }
                                                Console.SetCursorPosition(50, 29);
                                                Console.WriteLine("Enter the Specialities You want to add: ");
                                                string new_package = Console.ReadLine();
                                                new_packs[plannersIdx] = new_package;
                                                string price;
                                                while (true)
                                                {
                                                    Console.SetCursorPosition(50, 30);
                                                    Console.WriteLine("Enter the price of Your Package: ");
                                                    price = Console.ReadLine();
                                                    if (check_int(price))
                                                    {
                                                        break;
                                                    }
                                                    Console.SetCursorPosition(50, 34);
                                                    Console.WriteLine("Enter Wrong price, price must consist of numbers only");
                                                    Console.SetCursorPosition(83, 30);
                                                    Console.WriteLine("                             ");
                                                    Console.ReadKey();
                                                }
                                                Console.SetCursorPosition(50, 34);
                                                Console.WriteLine("                                                            ");
                                                Console.SetCursorPosition(50, 32);
                                                Console.WriteLine("Package Created");
                                                float p = float.Parse(price);
                                                prices[plannersIdx] = p;
                                                pack_status[plannersIdx] = "Pending";
                                                planner_Index[plannersIdx] = plannersIdx;
                                                plannersIdx++;
                                                storePackages(planners, new_packs, new_pack_types, pack_status, planner_Index, prices, packagesPath, ref plannersIdx);
                                                Console.ReadKey();
                                                continue;
                                            }
                                        case "5":
                                            {
                                                string currentuser =username;
                                                string end3 = "1";
                                                bool flag3 = true;
                                                int count4 = 0;
                                                Console.Clear();
                                                Printheader();
                                                print_selected_planner_packages(planners, new_packs, new_pack_types, pack_status, planner_Index, currentuser, prices, plannersIdx, ref count4);
                                                Console.WriteLine(" ");
                                                if (count4 == 0)
                                                {
                                                    Console.WriteLine(" ");
                                                    Console.WriteLine("                  YOU HAVE NOT ADDED ANY PLANS YET!");
                                                    Console.ReadKey();
                                                    continue;
                                                }
                                                Console.WriteLine("         press 1 to continue or 0 to exit");
                                                end3 = Console.ReadLine();
                                                if (end3 == "0")
                                                {
                                                    continue;
                                                }
                                                while (true)
                                                {
                                                    Console.WriteLine("Enter the SR number on which you want to del: ");
                                                    string sr3 = Console.ReadLine();
                                                    if (check_int(sr3))
                                                    {
                                                        int serial3 = int.Parse(sr3);
                                                        if (pack_status[serial3] == "Pending" && currentuser == planners[serial3])
                                                        {
                                                            for (int k = serial3; k < plannersIdx; k++)
                                                            {
                                                                planners[k] = planners[k + 1];
                                                                new_packs[k] = new_packs[k + 1];
                                                                new_pack_types[k] = new_pack_types[k + 1];
                                                                pack_status[k] = pack_status[k + 1];
                                                                prices[k] = prices[k + 1];
                                                            }
                                                            plannersIdx--;
                                                            storePackages(planners, new_packs, new_pack_types, pack_status, planner_Index, prices, packagesPath, ref plannersIdx);
                                                            break;
                                                        }
                                                        Console.WriteLine("      YOU ENTERED WRONG SR NUMBER     ");
                                                        Console.WriteLine("         press 1 to continue or 0 to exit");
                                                        sr3 = Console.ReadLine();
                                                        if (end3 == "0")
                                                        {
                                                            break;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("      YOU ENTERED WRONG SR NUMBER     ");
                                                        Console.WriteLine("         press 1 to continue or 0 to exit");
                                                        end3 = Console.ReadLine();
                                                        if (end3 == "0")
                                                        {
                                                            break;
                                                        }
                                                    }
                                                }
                                                Console.ReadKey();
                                                continue;
                                            }
                                        case "6":
                                            {
                                                string currentuser = username;
                                                int count5 = 0;
                                                Console.Clear();
                                                Printheader();
                                                view_Selected_PlannerEvents(customer_data, currentuser, customerIdx, ref count5);
                                                Console.WriteLine(" ");
                                                if (count5 == 0)
                                                {
                                                    Console.WriteLine("                 THERE ARE NO CUSTOMERS YET!");
                                                }
                                                Console.ReadKey();
                                                continue;
                                            }
                                        default:
                                            continue;
                                        case "7":
                                            break;
                                    }
                                    break;
                                }
                            }
                            else if (role == "admin" || role == "Admin")
                            {
                                exit = "1";
                                while (exit != "0")
                                {
                                    switch (adminMenu())
                                    {
                                        case "1":
                                            {
                                                Console.Clear();
                                                Printheader();
                                                print_new_packs(planners, new_packs, new_pack_types, pack_status, planner_Index, prices, plannersIdx);
                                                Console.WriteLine(" ");
                                                Console.WriteLine(" ");
                                                Console.WriteLine("Choose 1 for YES or 0 for NO");
                                                for (int l = 0; l < plannersIdx; l++)
                                                {
                                                    if (pack_status[l] == "Pending")
                                                    {
                                                        Console.WriteLine(" ");
                                                        Console.WriteLine("Do You Want to Approve " + l + " planners new package?");
                                                        string choose2 = Console.ReadLine();
                                                        if (choose2 == "1")
                                                        {
                                                            pack_status[l] = "Approved";
                                                        }
                                                        storePackages(planners, new_packs, new_pack_types, pack_status, planner_Index, prices, packagesPath, ref plannersIdx);
                                                    }
                                                }
                                                Console.WriteLine(" ");
                                                Console.WriteLine("                     NO pending packages!");
                                                Console.ReadKey();
                                                continue;
                                            }
                                        case "2":
                                            Console.Clear();
                                            Printheader();
                                            print_predefined_Birthday_Pack(30, 20);
                                            print_predefined_Wedd_Pack(30, 38);
                                            print_predefined_Concert_Pack(30, 105);
                                            Console.ReadKey();
                                            Console.Clear();
                                            Printheader();
                                            print_new_packs(planners, new_packs, new_pack_types, pack_status, planner_Index, prices, plannersIdx);
                                            Console.WriteLine("Enter any key to exit: ");
                                            Console.ReadKey();
                                            continue;
                                        case "3":
                                            {
                                                Console.Clear();
                                                Printheader();
                                                Console.WriteLine(" ");
                                                Console.WriteLine(" ");
                                                print_new_packs(planners, new_packs, new_pack_types, pack_status, planner_Index, prices, plannersIdx);
                                                Console.WriteLine("Enter the SR number on which you want to del: ");
                                                string sr4 = Console.ReadLine();
                                                if (check_int(sr4))
                                                {
                                                    int serial4 = int.Parse(sr4);
                                                    if (serial4 != 0 || serial4 != 1 || serial4 != 2)
                                                    {
                                                        for (int m = serial4; m < plannersIdx; m++)
                                                        {
                                                            planners[m] = planners[m + 1];
                                                            new_packs[m] = new_packs[m + 1];
                                                            new_pack_types[m] = new_pack_types[m + 1];
                                                            pack_status[m] = pack_status[m + 1];
                                                            prices[m] = prices[m + 1];
                                                        }
                                                        plannersIdx--;
                                                        storePackages(planners, new_packs, new_pack_types, pack_status, planner_Index, prices, "packages.txt", ref plannersIdx);
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("You can not delete this planner");
                                                }
                                                Console.ReadKey();
                                                continue;
                                            }
                                        case "4":
                                            Console.Clear();
                                            Printheader();
                                            Console.WriteLine(" ");
                                            Console.WriteLine(" ");
                                            printAllEvents(customer_data);
                                            Console.ReadKey();
                                            continue;
                                        default:
                                            continue;
                                        case "5":
                                            break;
                                    }
                                    break;
                                }
                            }
                            else
                            {
                                Console.ReadKey();
                            }
                            break;
                        }
                    case "2":
                        {
                            Console.Clear();
                            Printheader();
                            print_intro();
                            Console.SetCursorPosition(35, 25);
                            Console.WriteLine("---------------------------------------");
                            Console.SetCursorPosition(35, 26);
                            Console.WriteLine("             Enter Username:           ");
                            Console.SetCursorPosition(35, 27);
                            string username = Console.ReadLine();
                            Console.SetCursorPosition(35, 28);
                            Console.WriteLine("             Enter password:           ");
                            Console.SetCursorPosition(35, 29);
                            string password = Console.ReadLine();
                            Console.SetCursorPosition(35, 30);
                            Console.WriteLine("             Enter role(Customer/planner/Administrator):           ");
                            Console.SetCursorPosition(35, 31);
                            string role = Console.ReadLine();
                            Console.SetCursorPosition(35, 32);
                            Console.WriteLine("---------------------------------------");
                            if (signup(user_data, username, password, role, idx))
                            {
                                Store_Signup(role,username,password,user_data);                      
                                Console.WriteLine("SIGN UP Successfully");
                                Console.WriteLine("Enter any key to continue ");
                                Console.ReadKey();
                                idx++;
                               // storeUsers(Usernames, passwords, roles, usersPath, ref idx);
                            }
                            else
                            {
                                Console.WriteLine("SIGN UP Failure");
                                Console.WriteLine("TRY AGAIN.");
                                Console.WriteLine("check your entered data username and password must consist of 8 letters and must consist of numbers but less than 4");
                                Console.WriteLine("Enter any key to continue ");
                                Console.ReadKey();
                            }
                            break;
                        }
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static bool signup(List<Users> user_data, string username, string password, string role, int idx)
        {
            int ucheck = 0;
            int pcheck = 0;
            bool ans = true;
            if (idx == 0)
            {
                ans = true;
            }
            else if (username.Length <= 7 || password.Length <= 7)
            {
                ans = false;
            }
            else
            {
                for (int i = 0; i < user_data.Count; i++)
                {
                    if (username == user_data[i].username && password == user_data[i].password)
                    {
                        ans = false;
                        break;
                    }
                    if (role == "admin")
                    {
                        if (user_data[i].role == "admin")
                        {
                            ans = false;
                        }
                    }
                    else
                    {
                        ans = true;
                    }

                
                
                }

                for (int j = 0; j < username.Length; j++)
                {
                    if (username[j] == '1' || username[j] == '2' || username[j] == '3' || username[j] == '4' || username[j] == '5' || username[j] == '6' || username[j] == '7' || username[j] == '8' || username[j] == '9')
                    {
                        ucheck++;
                    }
                }
                for (int i = 0; i < password.Length; i++)
                {
                    if (password[i] == '1' || password[i] == '2' || password[i] == '3' || password[i] == '4' || password[i] == '5' || password[i] == '6' || password[i] == '7' || password[i] == '8' || password[i] == '9')
                    {
                        pcheck++;
                    }
                }
                if (ucheck == 0 || ucheck > 4 || pcheck == 0 || pcheck > 4)
                {
                    ans = false;
                }
            }
            return ans;
        }

        static string signin(List<Users> user_data, string username, string password, int idx, ref int signInIdx)
        {
            string ans = "";
            for (int i = 0; i < user_data.Count; i++)
            {
                if (username == user_data[i].username && password == user_data[i].password)
                {
                    ans = user_data[i].role;
                   
                    signInIdx = i;
                    break;
                }
                else
                {
                    ans = "NOT VALID ID!";
                }
                
            }
           
            return ans;
        }
        static void Store_Signup(string role,string username,string password,List<Users> user_data)
        {
            
                Users user = new Users(username, password,role);
                user_data.Add(user);
            
           
        }
        private static void storeUsers(string[] Usernames, string[] passwords, string[] roles, string filename, ref int idx)
        {
            StreamWriter usernamesFile = new StreamWriter(filename);
            for (int i = 0; i < idx; i++)
            {
                usernamesFile.WriteLine(Usernames[i] + "/" + passwords[i] + "/" + roles[i]);
            }
            usernamesFile.Flush();
            usernamesFile.Close();
        }

        private static void loadUsers(string[] Usernames, string[] passwords, string[] roles, string filename, ref int idx)
        {
            int i = 0;
            if (File.Exists(filename))
            {
                StreamReader usernamesFile = new StreamReader(filename);
                string record;
                while ((record = usernamesFile.ReadLine()) != null)
                {
                    Console.WriteLine(record);
                    if (record != "")
                    {
                        Usernames[i] = getword(record, 1);
                        passwords[i] = getword(record, 2);
                        roles[i] = getword(record, 3);
                        i++;
                    }
                }
                usernamesFile.Close();
                idx = i;
            }
            else
            {
                Console.WriteLine("NOt Exists");
            }
        }

        private static void storePackages(string[] planners, string[] new_packs, string[] new_pack_types, string[] pack_status, int[] planner_Index, float[] prices, string filename, ref int plannersIdx)
        {
            StreamWriter packagesFile = new StreamWriter(filename);
            for (int i = 0; i < plannersIdx; i++)
            {
                packagesFile.WriteLine(planner_Index[i] + "/" + planners[i] + "/" + new_pack_types[i] + "/" + new_packs[i] + "/" + prices[i] + "/" + pack_status[i]);
            }
            packagesFile.Flush();
            packagesFile.Close();
        }

        private static void loadPackages(string[] planners, string[] new_packs, string[] new_pack_types, string[] pack_status, int[] planner_Index, float[] prices, string filename, ref int plannersIdx)
        {
            int i = 0;
            if (File.Exists(filename))
            {
                StreamReader packages = new StreamReader(filename);
                string record;
                while ((record = packages.ReadLine()) != null)
                {
                    Console.WriteLine(record);
                    if (record != "")
                    {
                        string index = getword(record, 1);
                        planner_Index[i] = int.Parse(index);
                        planners[i] = getword(record, 2);
                        new_pack_types[i] = getword(record, 3);
                        new_packs[i] = getword(record, 4);
                        string prc = getword(record, 5);
                        prices[i] = float.Parse(prc);
                        pack_status[i] = getword(record, 6);
                        i++;
                    }
                }
                plannersIdx = i;
                packages.Close();
            }
            else
            {
                Console.WriteLine("NOt Exists");
            }
        }

        private static void storeEvents(string[] customerName, string[] dates, string[] times, string[] Events, string[] customers, string[] Booked, int[] customer_Index, float[] total_Bill, int customerIdx, string filename, string[] selected_planner)
        {
            StreamWriter eventsFile = new StreamWriter(filename);
            for (int i = 0; i < customerIdx; i++)
            {
                eventsFile.WriteLine(customer_Index[i] + "/" + customers[i] + "/" + customerName[i] + "/" + dates[i] + "/" + times[i] + "/" + Events[i] + "/" + selected_planner[i] + "/" + total_Bill[i] + "/" + Booked[i]);
            }
            eventsFile.Flush();
            eventsFile.Close();
        }

        private static void loadEvents(string[] customerName, string[] dates, string[] times, string[] Events, string[] customers, string[] Booked, int[] customer_Index, float[] total_Bill, ref int customerIdx, string filename, string[] selected_planner)
        {
            int i = 0;
            if (File.Exists(filename))
            {
                StreamReader packages = new StreamReader(filename);
                string record;
                while ((record = packages.ReadLine()) != null)
                {
                    Console.WriteLine(record);
                    if (record != "")
                    {
                        string index = getword(record, 1);
                        customer_Index[i] = int.Parse(index);
                        customers[i] = getword(record, 2);
                        customerName[i] = getword(record, 3);
                        dates[i] = getword(record, 4);
                        times[i] = getword(record, 5);
                        Events[i] = getword(record, 6);
                        selected_planner[i] = getword(record, 7);
                        string prc = getword(record, 8);
                        total_Bill[i] = float.Parse(prc);
                        Booked[i] = getword(record, 9);
                        i++;
                    }
                }
                customerIdx = i;
                packages.Close();
            }
            else
            {
                Console.WriteLine("NOt Exists");
            }
        }

        private static string getword(string record, int field)
        {
            int Count = 1;
            string item = "";
            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == '/')
                {
                    Count++;
                }
                else if (Count == field)
                {
                    item += record[x];
                }
            }
            return item;
        }

        private static string customerMenu()
        {
            Console.Clear();
            Printheader();
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("           1: Booking an Event: ");
            Console.WriteLine("           2: View detail of Events Packages:");
            Console.WriteLine("           3: View List of Booked Events: ");
            Console.WriteLine("           4: Edit Booking: ");
            Console.WriteLine("           5: Delete any Events: ");
            Console.WriteLine("           6: Exit: ");
            Console.WriteLine("           Select your requiremennt: ");
            return Console.ReadLine();
        }

        private static string plannerMenu()
        {
            Console.Clear();
            Printheader();
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("           1: Confirm Booking of Customer: ");
            Console.WriteLine("           2: View List of Events Packages:");
            Console.WriteLine("           3: View List of Your Created Packages:");
            Console.WriteLine("           4: Add List of New Package: ");
            Console.WriteLine("           5: Delete any Events: ");
            Console.WriteLine("           6: View your customers: ");
            Console.WriteLine("           7: Exit: ");
            Console.WriteLine("           Select your requiremennt: ");
            return Console.ReadLine();
        }

        private static string adminMenu()
        {
            Console.Clear();
            Printheader();
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("           1: Approve new package: ");
            Console.WriteLine("           2: View detail of Events Packages:");
            Console.WriteLine("           3: Delete any event: ");
            Console.WriteLine("           4: View List of Booked/Pending Events: ");
            Console.WriteLine("           5: Exit: ");
            Console.WriteLine("           Select your requiremennt: ");
            return Console.ReadLine();
        }

        private static string editMenu()
        {
            Console.WriteLine("                                     ----------------------------------------------------------");
            Console.WriteLine("                                                      WHAT DO YOU WANT TO EDIT");
            Console.WriteLine("                                     ----------------------------------------------------------");
            Console.WriteLine("                                     ----------------------------------------------------------");
            Console.WriteLine("                                                                1.NAME");
            Console.WriteLine("                                     ----------------------------------------------------------");
            Console.WriteLine("                                     ----------------------------------------------------------");
            Console.WriteLine("                                                                2.DATE");
            Console.WriteLine("                                     ----------------------------------------------------------");
            Console.WriteLine("                                     ----------------------------------------------------------");
            Console.WriteLine("                                                                3.TIME");
            Console.WriteLine("                                     ----------------------------------------------------------");
            Console.WriteLine(" ");
            Console.WriteLine("                                     Select any otion above given or '0' if you want to exit: ");
            return Console.ReadLine();
        }

        private static void view_Selected_CustomerEvents(List<Customer> customer_data ,int[] customers_Index, string currentuser, int customeridx,  ref int count)
        {
            int x = 19;
            int y = 20;
            Console.SetCursorPosition(x - 10, y - 1);
            Console.WriteLine("___________________________________________________________________________________________________________________________________________");
            Console.SetCursorPosition(x, y);
            Console.WriteLine(":NAME: ");
            Console.SetCursorPosition(x - 10, y);
            Console.WriteLine(":SR: ");
            Console.SetCursorPosition(x + 20, y);
            Console.WriteLine(":DATE:  ");
            Console.SetCursorPosition(x + 40, y);
            Console.WriteLine(":EVENT TYPE:      ");
            Console.SetCursorPosition(x + 60, y);
            Console.WriteLine(":TIME:  ");
            Console.SetCursorPosition(x + 80, y);
            Console.WriteLine(":Planner:  ");
            Console.SetCursorPosition(x + 100, y);
            Console.WriteLine(":Bill:  ");
            Console.SetCursorPosition(x + 120, y);
            Console.WriteLine(":Status: ");
            for (int i = 0; i < customer_data.Count; i++)
            {
                if (currentuser == customer_data[i].Username)
                {
                    y++;
                    Console.SetCursorPosition(x - 10, y);
                    Console.WriteLine("__________________________________________________________________________________________________________________________________________ ");
                    y++;
                    Console.SetCursorPosition(x - 10, y);
                    Console.WriteLine(customers_Index[i]);
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine(customer_data[i].CustomerName);
                    Console.SetCursorPosition(x + 20, y);
                    Console.WriteLine(customer_data[i].date);
                    Console.SetCursorPosition(x + 40, y);
                    Console.WriteLine(customer_data[i].events);
                    Console.SetCursorPosition(x + 60, y);
                    Console.WriteLine(customer_data[i].time);
                    Console.SetCursorPosition(x + 80, y);
                    Console.WriteLine(customer_data[i].planner);
                    Console.SetCursorPosition(x + 100, y);
                    Console.WriteLine(customer_data[i].bill);
                    Console.SetCursorPosition(x + 120, y);
                    Console.WriteLine(customer_data[i].status);
                    count++;
                }
            }
            Console.SetCursorPosition(x - 10, y + 1);
            Console.WriteLine("__________________________________________________________________________________________________________________________________________ ");
        }

        private static void view_Selected_PlannerEvents(List<Customer> customer_data, string currentuser, int customeridx, ref int count)
        {
            int x = 19;
            int y = 20;
            Console.SetCursorPosition(x - 10, y - 1);
            Console.WriteLine("___________________________________________________________________________________________________________________________________________");
           
            Console.SetCursorPosition(x, y);
            Console.WriteLine(":Planner:  ");
            Console.SetCursorPosition(x + 20, y);
            Console.WriteLine(":Customer NAME: ");
            Console.SetCursorPosition(x + 40, y);
            Console.WriteLine(":DATE:  ");
            Console.SetCursorPosition(x + 60, y);
            Console.WriteLine(":EVENT TYPE:      ");
            Console.SetCursorPosition(x + 80, y);
            Console.WriteLine(":TIME:  ");
            Console.SetCursorPosition(x + 100, y);
            Console.WriteLine(":Bill:  ");
            Console.SetCursorPosition(x + 120, y);
            Console.WriteLine(":Status: ");
            for (int i = 0; i < customeridx + 1; i++)
            {
                if (currentuser == customer_data[i].planner)
                {
                    y++;
                    Console.SetCursorPosition(x - 10, y);
                    Console.WriteLine("__________________________________________________________________________________________________________________________________________ ");
                    y++;
                   
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine(customer_data[i].planner);
                    Console.SetCursorPosition(x + 20, y);
                    Console.WriteLine(customer_data[i].CustomerName);
                    Console.SetCursorPosition(x + 40, y);
                    Console.WriteLine(customer_data[i].date);
                    Console.SetCursorPosition(x + 60, y);
                    Console.WriteLine(customer_data[i].events);
                    Console.SetCursorPosition(x + 80, y);
                    Console.WriteLine(customer_data[i].time);
                    Console.SetCursorPosition(x + 100, y);
                    Console.WriteLine(customer_data[i].bill);
                    Console.SetCursorPosition(x + 120, y);
                    Console.WriteLine(customer_data[i].status);
                    count++;
                }
            }
            Console.SetCursorPosition(x - 10, y + 1);
            Console.WriteLine("__________________________________________________________________________________________________________________________________________ ");
        }

        private static void print_selected_planner_packages(string[] planners, string[] new_pack, string[] new_pack_types, string[] pack_status, int[] planners_Index, string currentuser, float[] prices, int plannersIdx, ref int count)
        {
            int x = 30;
            int y = 20;
            Console.SetCursorPosition(x - 10, y - 1);
            Console.WriteLine("_______________________________________________________________________________________________");
            Console.SetCursorPosition(x - 10, y);
            Console.WriteLine(":SR:            ");
            Console.SetCursorPosition(x, y);
            Console.WriteLine(":NAMES:            ");
            Console.SetCursorPosition(x + 20, y);
            Console.WriteLine(":PACKAGE TYPES:            ");
            Console.SetCursorPosition(x + 40, y);
            Console.WriteLine(":SPECIALITIES:      ");
            Console.SetCursorPosition(x + 60, y);
            Console.WriteLine(":PRICES:      ");
            Console.SetCursorPosition(x + 80, y);
            Console.WriteLine(":STATUS:      ");
            for (int i = 0; i < plannersIdx; i++)
            {
                if (currentuser == planners[i])
                {
                    y++;
                    Console.SetCursorPosition(x - 10, y);
                    Console.WriteLine("______________________________________________________________________________________________ ");
                    y++;
                    Console.SetCursorPosition(x - 10, y);
                    Console.WriteLine(planners_Index[i]);
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine(planners[i]);
                    Console.SetCursorPosition(x + 20, y);
                    Console.WriteLine(new_pack_types[i]);
                    Console.SetCursorPosition(x + 40, y);
                    Console.WriteLine(new_pack[i]);
                    Console.SetCursorPosition(x + 60, y);
                    Console.WriteLine(prices[i]);
                    Console.SetCursorPosition(x + 80, y);
                    Console.WriteLine(pack_status[i]);
                    count++;
                }
            }
        }

        private static void printAllEvents(List<Customer> customer_data)
        {
            int x = 19;
            int y = 20;
            Console.SetCursorPosition(x - 10, y - 1);
            Console.WriteLine("____________________________________________________________________________________________________________________________________________");
           ;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(":NAME:            ");
            Console.SetCursorPosition(x + 20, y);
            Console.WriteLine(":DATE:            ");
            Console.SetCursorPosition(x + 40, y);
            Console.WriteLine(":EVENT TYPE:      ");
            Console.SetCursorPosition(x + 60, y);
            Console.WriteLine(":TIME:            ");
            Console.SetCursorPosition(x + 80, y);
            Console.WriteLine(":Bill:            ");
            Console.SetCursorPosition(x + 100, y);
            Console.WriteLine(":Planner:            ");
            Console.SetCursorPosition(x + 120, y);
            Console.WriteLine(":Status:            ");
            for (int i = 0; i < customer_data.Count; i++)
            {
                y++;
                Console.SetCursorPosition(x - 10, y);
                Console.WriteLine("___________________________________________________________________________________________________________________________________________ ");
                y++;
                Console.SetCursorPosition(x - 10, y);
               
                Console.WriteLine(customer_data[i].CustomerName);
                Console.SetCursorPosition(x + 20, y);
                Console.WriteLine(customer_data[i].date);
                Console.SetCursorPosition(x + 40, y);
                Console.WriteLine(customer_data[i].events);
                Console.SetCursorPosition(x + 60, y);
                Console.WriteLine(customer_data[i].time);
                Console.SetCursorPosition(x + 80, y);
                Console.WriteLine(customer_data[i].bill);
                Console.SetCursorPosition(x + 100, y);
                Console.WriteLine(customer_data[i].planner);
                Console.SetCursorPosition(x + 120, y);
                Console.WriteLine(customer_data[i].status);
            }
            Console.WriteLine("          ______________________________________________________________________________________________________________________________________");
        }

        private static void print_new_packs(string[] planners, string[] new_pack, string[] new_pack_types, string[] pack_status, int[] planners_Index, float[] prices, int plannersIdx)
        {
            int x = 30;
            int y = 20;
            Console.SetCursorPosition(x - 10, y - 1);
            Console.WriteLine("_______________________________________________________________________________________________");
            Console.SetCursorPosition(x - 10, y);
            Console.WriteLine(":SR:            ");
            Console.SetCursorPosition(x, y);
            Console.WriteLine(":NAMES:            ");
            Console.SetCursorPosition(x + 20, y);
            Console.WriteLine(":PACKAGE TYPES:            ");
            Console.SetCursorPosition(x + 40, y);
            Console.WriteLine(":SPECIALITIES:      ");
            Console.SetCursorPosition(x + 60, y);
            Console.WriteLine(":PRICES:      ");
            Console.SetCursorPosition(x + 80, y);
            Console.WriteLine(":STATUS:      ");
            for (int i = 0; i < plannersIdx; i++)
            {
                y++;
                Console.SetCursorPosition(x - 10, y);
                Console.WriteLine("______________________________________________________________________________________________ ");
                y++;
                Console.SetCursorPosition(x - 10, y);
                Console.WriteLine(planners_Index[i]);
                Console.SetCursorPosition(x, y);
                Console.WriteLine(planners[i]);
                Console.SetCursorPosition(x + 20, y);
                Console.WriteLine(new_pack_types[i]);
                Console.SetCursorPosition(x + 40, y);
                Console.WriteLine(new_pack[i]);
                Console.SetCursorPosition(x + 60, y);
                Console.WriteLine(prices[i]);
                Console.SetCursorPosition(x + 80, y);
                Console.WriteLine(pack_status[i]);
            }
            Console.WriteLine("                  ______________________________________________________________________________________________ ");
        }

        private static void print_bday_planner(string[] planners, string[] new_pack, string[] new_pack_types, string[] pack_status, float[] prices, int[] planners_Index, int plannersIdx, ref int x, ref int y)
        {
            Console.SetCursorPosition(x - 10, y - 1);
            Console.WriteLine("_______________________________________________________________________________________________");
            Console.SetCursorPosition(x - 10, y);
            Console.WriteLine(":SR:            ");
            Console.SetCursorPosition(x, y);
            Console.WriteLine(":NAMES:            ");
            Console.SetCursorPosition(x + 20, y);
            Console.WriteLine(":PACKAGE TYPES:            ");
            Console.SetCursorPosition(x + 40, y);
            Console.WriteLine(":SPECIALITIES:      ");
            Console.SetCursorPosition(x + 60, y);
            Console.WriteLine(":PRICES:      ");
            for (int i = 0; i < plannersIdx; i++)
            {
                if (new_pack_types[i] == "Birthday" && pack_status[i] == "Approved")
                {
                    y++;
                    Console.SetCursorPosition(x - 10, y);
                    Console.WriteLine("______________________________________________________________________________________________ ");
                    y++;
                    Console.SetCursorPosition(x - 10, y);
                    Console.WriteLine(planners_Index[i]);
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine(planners[i]);
                    Console.SetCursorPosition(x + 20, y);
                    Console.WriteLine(new_pack_types[i]);
                    Console.SetCursorPosition(x + 40, y);
                    Console.WriteLine(new_pack[i]);
                    Console.SetCursorPosition(x + 60, y);
                    Console.WriteLine(prices[i]);
                }
            }
        }

        private static void print_wedd_planner(string[] planners, string[] new_pack, string[] new_pack_types, string[] pack_status, float[] prices, int[] planners_Index, int plannersIdx, ref int x, ref int y)
        {
            Console.SetCursorPosition(x - 10, y - 1);
            Console.WriteLine("_______________________________________________________________________________________________");
            Console.SetCursorPosition(x - 10, y);
            Console.WriteLine(":SR:            ");
            Console.SetCursorPosition(x, y);
            Console.WriteLine(":NAMES:            ");
            Console.SetCursorPosition(x + 20, y);
            Console.WriteLine(":PACKAGE TYPES:            ");
            Console.SetCursorPosition(x + 40, y);
            Console.WriteLine(":SPECIALITIES:      ");
            Console.SetCursorPosition(x + 60, y);
            Console.WriteLine(":PRICES:      ");
            for (int i = 0; i < plannersIdx; i++)
            {
                if (new_pack_types[i] == "Wedding" && pack_status[i] == "Approved")
                {
                    y++;
                    Console.SetCursorPosition(x - 10, y);
                    Console.WriteLine("______________________________________________________________________________________________ ");
                    y++;
                    Console.SetCursorPosition(x - 10, y);
                    Console.WriteLine(planners_Index[i]);
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine(planners[i]);
                    Console.SetCursorPosition(x + 20, y);
                    Console.WriteLine(new_pack_types[i]);
                    Console.SetCursorPosition(x + 40, y);
                    Console.WriteLine(new_pack[i]);
                    Console.SetCursorPosition(x + 60, y);
                    Console.WriteLine(prices[i]);
                }
            }
        }

        private static void print_concert_planner(string[] planners, string[] new_pack, string[] new_pack_types, string[] pack_status, float[] prices, int[] planners_Index, int plannersIdx, ref int x, ref int y)
        {
            Console.SetCursorPosition(x - 10, y - 1);
            Console.WriteLine("_______________________________________________________________________________________________");
            Console.SetCursorPosition(x - 10, y);
            Console.WriteLine(":SR:            ");
            Console.SetCursorPosition(x, y);
            Console.WriteLine(":NAMES:            ");
            Console.SetCursorPosition(x + 20, y);
            Console.WriteLine(":PACKAGE TYPES:            ");
            Console.SetCursorPosition(x + 40, y);
            Console.WriteLine(":SPECIALITIES:      ");
            Console.SetCursorPosition(x + 60, y);
            Console.WriteLine(":PRICES:      ");
            for (int i = 0; i < plannersIdx; i++)
            {
                if (new_pack_types[i] == "Concert" && pack_status[i] == "Approved")
                {
                    y++;
                    Console.SetCursorPosition(x - 10, y);
                    Console.WriteLine("______________________________________________________________________________________________ ");
                    y++;
                    Console.SetCursorPosition(x - 10, y);
                    Console.WriteLine(planners_Index[i]);
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine(planners[i]);
                    Console.SetCursorPosition(x + 20, y);
                    Console.WriteLine(new_pack_types[i]);
                    Console.SetCursorPosition(x + 40, y);
                    Console.WriteLine(new_pack[i]);
                    Console.SetCursorPosition(x + 60, y);
                    Console.WriteLine(prices[i]);
                }
            }
        }

        private static float birthday(ref int x, ref int y, float[] prices)
        {
            float bill = 0f;
            Console.SetCursorPosition(x, y - 4);
            Console.WriteLine("-------------------------------------------------------- ");
            Console.SetCursorPosition(x, y - 3);
            Console.WriteLine("            FILL THE FORM FOR BOOKING: ");
            Console.SetCursorPosition(x, y - 2);
            Console.WriteLine("-------------------------------------------------------- ");
            Console.SetCursorPosition(x, y);
            Console.WriteLine("Enter Number of Persons: ");
            string no_persons = Console.ReadLine();
            int persons = int.Parse(no_persons);
            Console.SetCursorPosition(x, y + 2);
            Console.WriteLine("If You Want To Add Something Select options");
            Console.SetCursorPosition(x, y + 3);
            Console.WriteLine(" ");
            Console.SetCursorPosition(x, y + 4);
            Console.WriteLine("1: cupcakes                     500 Per Person   ");
            Console.SetCursorPosition(x, y + 5);
            Console.WriteLine("2: Arrangement of Magician      4,000            ");
            Console.SetCursorPosition(x, y + 6);
            Console.WriteLine("3: Dinner                       2,000 Per Person ");
            Console.SetCursorPosition(x, y + 8);
            Console.WriteLine("Choose '1' for Yes or '0' for No.");
            bill = persons * 2000;
            Console.SetCursorPosition(x, y + 10);
            Console.WriteLine("Do You Want to Add Cupcakes:");
            string additional = Console.ReadLine();
            if (additional == "1")
            {
                bill += (float)(persons * 500);
            }
            Console.SetCursorPosition(x, y + 12);
            Console.WriteLine("Do You Want to Add Magician:");
            additional = Console.ReadLine();
            if (additional == "1")
            {
                bill += 4000f;
            }
            Console.SetCursorPosition(x, y + 14);
            Console.WriteLine("Do You Want to Add Dinner:");
            additional = Console.ReadLine();
            if (additional == "1")
            {
                bill += (float)(persons * 2000);
            }
            return bill;
        }

        private static float wedding(ref int x, ref int y, float[] prices)
        {
            float bill = 0f;
            Console.SetCursorPosition(x, y - 4);
            Console.WriteLine("-------------------------------------------------------- ");
            Console.SetCursorPosition(x, y - 3);
            Console.WriteLine("            FILL THE FORM FOR BOOKING: ");
            Console.SetCursorPosition(x, y - 2);
            Console.WriteLine("-------------------------------------------------------- ");
            Console.SetCursorPosition(x, y);
            Console.WriteLine("Enter Number of Persons: ");
            string no_persons = Console.ReadLine();
            int persons = int.Parse(no_persons);
            bill = persons * 2000;
            Console.SetCursorPosition(x, y + 2);
            Console.WriteLine("Which FLOWERING package do you want to choose? Enter 1 or 2 or 3 or 4 (for nothing additional)");
            Console.WriteLine("Enter: ");
            switch (Console.ReadLine())
            {
                case "1":
                    bill += 5000f;
                    break;
                case "2":
                    bill += 6000f;
                    break;
                case "3":
                    bill += 5500f;
                    break;
            }
            Console.SetCursorPosition(x, y + 3);
            Console.WriteLine("Which PHOTOGRAPHY package do you want to choose? Enter 1 or 2 or 3 or 4 (for nothing )");
            switch (Console.ReadLine())
            {
                case "1":
                    bill += 3000f;
                    break;
                case "2":
                    bill += 4000f;
                    break;
                case "3":
                    bill += 6000f;
                    break;
            }
            Console.SetCursorPosition(x, y + 4);
            Console.WriteLine("Choose '1' for Yes or '0' for No.");
            Console.SetCursorPosition(x, y + 5);
            Console.WriteLine("Do You Want to Add Additional Appitizer:");
            string additionD = Console.ReadLine();
            if (additionD == "1")
            {
                bill += (float)(persons * 1000);
            }
            Console.SetCursorPosition(x, y + 6);
            Console.WriteLine("Do You Want to Add Additional dinner item :");
            additionD = Console.ReadLine();
            if (additionD == "1")
            {
                bill += (float)(persons * 1200);
            }
            Console.SetCursorPosition(x, y + 7);
            Console.WriteLine("Do You Want to Add Additional Dessert :");
            additionD = Console.ReadLine();
            if (additionD == "1")
            {
                bill += (float)(persons * 700);
            }
            return bill;
        }

        private static float concert(ref int x, ref int y, float[] prices)
        {
            float bill = 0f;
            Console.SetCursorPosition(x, y - 4);
            Console.WriteLine("-------------------------------------------------------- ");
            Console.SetCursorPosition(x, y - 3);
            Console.WriteLine("           FILL THE FORM FOR BOOKING: ");
            Console.SetCursorPosition(x, y - 2);
            Console.WriteLine("-------------------------------------------------------- ");
            Console.SetCursorPosition(x, y);
            Console.WriteLine("Enter Number of Persons:");
            string no_persons = Console.ReadLine();
            int persons = int.Parse(no_persons);
            while (true)
            {
                Console.SetCursorPosition(x, y + 1);
                Console.WriteLine("Enter your choice(1 for gold or 2 for platinum):");
                string additionC = Console.ReadLine();
                Console.WriteLine(" ");
                if (additionC == "1")
                {
                    bill += (float)(4000 * persons);
                    break;
                }
                if (additionC == "2")
                {
                    bill += (float)(3000 * persons);
                    break;
                }
                Console.WriteLine("Chooose any one");
            }
            Console.SetCursorPosition(x, y + 3);
            Console.WriteLine("You can add things given below");
            Console.SetCursorPosition(x, y + 4);
            Console.WriteLine("  1: Additional MUSIC  SYSTEM                      2: DINNER:            ");
            Console.SetCursorPosition(x, y + 5);
            Console.WriteLine("     MIKE+Deck                                     Per Person      ");
            Console.SetCursorPosition(x, y + 6);
            Console.WriteLine("     RPS = 2000                                    RPS = 1200       ");
            Console.SetCursorPosition(x, y + 7);
            Console.WriteLine("Choose '1' for Yes or '0' for No.");
            Console.SetCursorPosition(x, y + 8);
            Console.SetCursorPosition(x, y + 9);
            Console.WriteLine("Do You Want to Add Additional Music System:");
            string addition_M = Console.ReadLine();
            Console.WriteLine(" ");
            if (addition_M == "1")
            {
                bill += 2000f;
            }
            Console.SetCursorPosition(x, y + 10);
            Console.WriteLine("Do You Want to Add Additional Dinner:");
            string addition_D = Console.ReadLine();
            Console.WriteLine(" ");
            if (addition_D == "1")
            {
                bill += (float)(1200 * persons);
            }
            return bill;
        }

        private static void print_predefined_Birthday_Pack(int x, int y)
        {
            Console.SetCursorPosition(x + 20, y);
            Console.WriteLine("------------------------------------------------------------");
            Console.SetCursorPosition(x + 20, y + 1);
            Console.WriteLine("    We have the following items COMPULSOR in birthday package ");
            Console.SetCursorPosition(x + 20, y + 2);
            Console.WriteLine("------------------------------------------------------------");
            Console.SetCursorPosition(x, y + 3);
            Console.WriteLine("* Ballon Decorated Main Wall");
            Console.SetCursorPosition(x, y + 4);
            Console.WriteLine("* Banners of BirthDay boy/girl photographs ");
            Console.SetCursorPosition(x, y + 5);
            Console.WriteLine("* BirthDay Cake ");
            Console.SetCursorPosition(x, y + 6);
            Console.WriteLine("* Music System ");
            Console.SetCursorPosition(x, y + 7);
            Console.WriteLine("* Chairs ");
            Console.SetCursorPosition(x, y + 8);
            Console.WriteLine("* Tables ");
            Console.SetCursorPosition(x, y + 9);
            Console.WriteLine("* Party Supplies:Include plates, cups, napkins, utensils, and other disposable tableware.");
            Console.SetCursorPosition(x, y + 10);
            Console.WriteLine("* Cold Drinks ");
            Console.SetCursorPosition(x, y + 11);
            Console.WriteLine("* Lighting ");
            Console.SetCursorPosition(x, y + 12);
            Console.WriteLine("* Waiters ");
            Console.SetCursorPosition(x, y + 14);
            Console.WriteLine("COST: PER PERSON RPS 2000");
        }

        private static void print_predefined_Wedd_Pack(int x, int y)
        {
            Console.SetCursorPosition(x + 20, y - 2);
            Console.WriteLine("----------------------------------------------------------");
            Console.SetCursorPosition(x + 20, y - 1);
            Console.WriteLine("We have the following items COMPULSORY in WEDDING PACKAGES ");
            Console.SetCursorPosition(x + 20, y);
            Console.WriteLine("-----------------------------------------------------------");
            Console.SetCursorPosition(x, y + 1);
            Console.WriteLine("* Catering ");
            Console.SetCursorPosition(x, y + 2);
            Console.WriteLine("* Photographer ");
            Console.SetCursorPosition(x, y + 3);
            Console.WriteLine("* Decoration");
            Console.SetCursorPosition(x, y + 4);
            Console.WriteLine("* Florist ");
            Console.SetCursorPosition(x, y + 5);
            Console.WriteLine("* Eecutive Bridal Room");
            Console.SetCursorPosition(x, y + 6);
            Console.WriteLine("* Music System ");
            Console.SetCursorPosition(x, y + 7);
            Console.WriteLine("* Chairs ");
            Console.SetCursorPosition(x, y + 8);
            Console.WriteLine("* Tables ");
            Console.SetCursorPosition(x, y + 9);
            Console.WriteLine("* Party Supplies:Include plates, cups, napkins, utensils, and other disposable tableware.");
            Console.SetCursorPosition(x, y + 10);
            Console.WriteLine("* Cold Drinks ");
            Console.SetCursorPosition(x, y + 11);
            Console.WriteLine("* Lighting ");
            Console.SetCursorPosition(x, y + 12);
            Console.WriteLine("* Waiters ");
            Console.SetCursorPosition(x, y + 13);
            Console.WriteLine("* Venue ");
            Console.WriteLine(" ");
            Console.SetCursorPosition(x, y + 15);
            Console.WriteLine("All these things cost 30,000 RPS.");
            Console.SetCursorPosition(x + 20, y + 17);
            Console.WriteLine("---------------------");
            Console.SetCursorPosition(x + 20, y + 18);
            Console.WriteLine(" FLOWERING PACKAGES: ");
            Console.SetCursorPosition(x + 20, y + 19);
            Console.WriteLine("---------------------");
            Console.WriteLine(" ");
            Console.WriteLine("1: Lush and Soft Mixed Posy           |  2: Phalanepsis Orcid Posy             |  3: Antique Mixed Posy ");
            Console.WriteLine("                                      |                                        |                          ");
            Console.WriteLine("   A Combination of roses ,           |     A soft lusious bouquet             |   Hydrangea in dusty Blue  ");
            Console.WriteLine("   spray roses , Fressia  &           |     of  Singapore  Orchids             |   Purple, Green and White   ");
            Console.WriteLine("   small seasonal available           |     wrapped  in a delicate             |   Hyacint []h florets, roses,   ");
            Console.WriteLine("   blooms such  as Jonquils           |     phelaneopsis Orcids.               |   Lisanthus in White.        ");
            Console.WriteLine("                                      |                                        |                          ");
            Console.WriteLine("        RPS = 6,000                   |          RPS = 5,500                   |       RPS = 7,000         ");
            Console.SetCursorPosition(x + 20, y + 30);
            Console.WriteLine("---------------------");
            Console.SetCursorPosition(x + 20, y + 31);
            Console.WriteLine(" PHOTOGRAPHY PACKAAGES: ");
            Console.SetCursorPosition(x + 20, y + 32);
            Console.WriteLine("---------------------");
            Console.WriteLine(" ");
            Console.WriteLine("1: One  hour  Bridal   Session  ,      |    2: Two hour Bridal Session ,             |   3: Two hour Bridal Session ");
            Console.WriteLine("   Three hour  Wedding   Coverage      |       Six hour Wedding Coverage             |      8 hour Wedding Coverage   ");
            Console.WriteLine("   Professional photo Enhancement      |       Online Photo Album                    |      Disc of all Images   ");
            Console.WriteLine("                                       |                                             |                          ");
            Console.WriteLine("            RPS = 3000                 |               RPS = 4000                    |            RPS = 6000           ");
            Console.WriteLine(" ");
            Console.SetCursorPosition(x + 20, y + 42);
            Console.WriteLine("-------------------------------------------------");
            Console.SetCursorPosition(x + 20, y + 43);
            Console.WriteLine("We have the following items COMPULSORY in DINNER ");
            Console.SetCursorPosition(x + 20, y + 44);
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine(" ");
            Console.SetCursorPosition(x, y + 45);
            Console.WriteLine("* One type of Rice ");
            Console.SetCursorPosition(x, y + 46);
            Console.WriteLine("* One type of Qorma ");
            Console.SetCursorPosition(x, y + 47);
            Console.WriteLine("* Appitizer (Russian Salad)");
            Console.SetCursorPosition(x, y + 48);
            Console.WriteLine("* Appitizer (Russian Salad)");
            Console.SetCursorPosition(x, y + 49);
            Console.WriteLine("* Appitizer (Russian Salad)");
            Console.SetCursorPosition(x, y + 50);
            Console.WriteLine("* Tandori Bread ");
            Console.SetCursorPosition(x, y + 51);
            Console.WriteLine("* Cold Drinks");
            Console.SetCursorPosition(x, y + 52);
            Console.WriteLine("* Ice cream ");
            Console.WriteLine(" ");
            Console.SetCursorPosition(x + 20, y + 53);
            Console.WriteLine("--------------------------");
            Console.SetCursorPosition(x + 20, y + 54);
            Console.WriteLine("ADDITIONAL DINNER ITEMS: ");
            Console.SetCursorPosition(x + 20, y + 55);
            Console.WriteLine("--------------------------");
            Console.WriteLine("  1: Additional Appitizer                  |   2: Additional dinner item             |     3: Additional Dessert   ");
            Console.WriteLine("     Macronie Pasta                        |      Grilled Fish                       |        Red fruits cheesecake  ");
            Console.WriteLine("      RPS = 8,000                          |       RPS = 20,000                      |        RPS = 15,000");
            Console.WriteLine(" ");
        }

        private static void print_predefined_Concert_Pack(int x, int y)
        {
            Console.SetCursorPosition(x + 20, y - 1);
            Console.WriteLine("------------------------------- ");
            Console.SetCursorPosition(x + 20, y);
            Console.WriteLine("      :CONCERT PACKAGES: ");
            Console.WriteLine(" ");
            Console.SetCursorPosition(x + 20, y + 1);
            Console.WriteLine("------------------------------- ");
            Console.SetCursorPosition(x, y + 2);
            Console.WriteLine(" 1: GOLD                                                  2:  PLATINUM");
            Console.SetCursorPosition(x, y + 3);
            Console.WriteLine("    Highly Decorated stage                                    Simply Decorated Stage   ");
            Console.SetCursorPosition(x, y + 4);
            Console.WriteLine("    Setting Arrangement                                       Artist Arrangemnet                          ");
            Console.SetCursorPosition(x, y + 5);
            Console.WriteLine("    Artist  Arrangement                                       Parking                    ");
            Console.SetCursorPosition(x, y + 6);
            Console.WriteLine("    Parking                                                   Ticketing Arrangement        ");
            Console.SetCursorPosition(x, y + 7);
            Console.WriteLine("    Dinner                                                    Dinner is not included   ");
            Console.SetCursorPosition(x, y + 8);
            Console.WriteLine("    Ticeting System");
            Console.SetCursorPosition(x, y + 8);
            Console.WriteLine("   ");
            Console.SetCursorPosition(x, y + 10);
            Console.WriteLine("        Rps = 40,000                                              Rps = 30,000");
            Console.WriteLine(" ");
        }

        private static void Printheader()
        {
            Console.WriteLine(" ");
            Console.WriteLine("                                       ##     ##      #####      ##   ##     ##    ##     ##   ##      #####     ");
            Console.WriteLine("                                       ##     ##     ##   ##     ##  ##      ##    ##     ###  ##     ##   ##   ");
            Console.WriteLine("                                       #########     #######     ## ##       ##    ##     ## # ##     #######   ");
            Console.WriteLine("                                       ##     ##     ##   ##     ##  ##      ##    ##     ##  ###     ##   ##   ");
            Console.WriteLine("                                       ##     ##     ##   ##     ##   ##      ######      ##   ##     ##   ##   ");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("                                       ##       ##      #####      ########       #####      ########      #####");
            Console.WriteLine("                                       ###     ###     ##   ##        ##         ##   ##        ##        ##   ##");
            Console.WriteLine("                                       ## #   # ##     #######        ##         #######        ##        #######");
            Console.WriteLine("                                       ##  ###  ##     ##   ##        ##         ##   ##        ##        ##   ##");
            Console.WriteLine("                                       ##   #   ##     ##   ##        ##         ##   ##        ##        ##   ## ");
            Console.WriteLine(" ");
            Console.WriteLine("***************************************************************************************************************************************************************");
        }

        private static void print_intro()
        {
            Console.WriteLine("           Welcome to HAKUNAMA TATA ||BEST EVENT PLANNING SYSTEM (A Man With The Plan).Our Application is a user friy platform It will ");
            Console.WriteLine("           smothen your event process. We prioritize our customers at every step, offering a seamless and  personalized   experience  that ");
            Console.WriteLine("           empowers them to bring their unique event visions to life.  From elegant weddings to corporate confe From  elegant weddings  to ");
            Console.WriteLine("           conferences and everything in between, our application offers a wide range of tools and features to cater to diverse event needs.");
            Console.WriteLine(" ");
            Console.WriteLine("**************************************************************************************************************************************************************");
        }

        private static string loginMenu()
        {
            Console.SetCursorPosition(40, 25);
            Console.WriteLine("---------------------------------------");
            Console.SetCursorPosition(40, 26);
            Console.WriteLine("             1: SIGN IN:               ");
            Console.SetCursorPosition(40, 27);
            Console.WriteLine("             2: SIGN UP:               ");
            Console.SetCursorPosition(40, 28);
            Console.WriteLine("             3: EXIT:                  ");
            Console.SetCursorPosition(40, 29);
            Console.WriteLine("             SELECT OOPTION:           ");
            Console.SetCursorPosition(46, 30);
            string option = Console.ReadLine();
            Console.SetCursorPosition(40, 31);
            Console.WriteLine("---------------------------------------");
            return option;
        }

        private static bool check_int(string p)
        {
            int ch = 0;
            if (p.Length > 8)
            {
                bool ans = false;
            }
            for (int i = 0; i < p.Length; i++)
            {
                if (p[i] == '1' || p[i] == '2' || p[i] == '3' || p[i] == '4' || p[i] == '5' || p[i] == '6' || p[i] == '7' || p[i] == '8' || p[i] == '9')
                {
                    ch++;
                }
            }
            if (ch == p.Length)
            {
                return true;
            }
            return false;
        }

        private static bool check_planner_exsist(string type, string[] new_pack_type, string[] status, int planners_idx)
        {
            bool ans = false;
            int ch = 0;
            switch (type)
            {
                case "Birthday":
                    {
                        for (int i = 0; i < planners_idx; i++)
                        {
                            if (new_pack_type[i] == "Birthday")
                            {
                                ch++;
                            }
                        }
                        break;
                    }
                case "Wedding":
                    {
                        for (int j = 0; j < planners_idx; j++)
                        {
                            if (new_pack_type[j] == "Wedding")
                            {
                                ch++;
                            }
                        }
                        break;
                    }
                case "Concert":
                    {
                        for (int k = 0; k < planners_idx; k++)
                        {
                            if (new_pack_type[k] == "Concert")
                            {
                                ch++;
                            }
                        }
                        break;
                    }
            }
            if (ch != 0)
            {
                ans = true;
            }
            return ans;
        }
    }
}
