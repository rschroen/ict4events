﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//download allemaal http://www.oracle.com/technetwork/topics/dotnet/index-085163.html
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace DataLibrary
{
    public class DataManager
    {
        //FIELDS
        DatabaseConnection connect;
        List<Dictionary<string, string>> result;
        //CONSTRUCTOR
        public DataManager()
        {
        }
        /// <summary>
        /// Universal execute non-query (delete,update,insert).
        /// </summary>
        /// <param name="query">string query</param>
        public void XCTNonQuery(string query)
        {
            
            try
            {
                connect = new DatabaseConnection();
                connect.Connect();
                OracleCommand cmd = new OracleCommand(query, connect.Con);
                cmd.ExecuteNonQuery();
            }
            catch (OracleException ex)
            {
                Console.WriteLine("Exception: " + ex);
            }
            finally
            {
                connect.Close();
            }
        }
        /// <summary>
        /// Universal execute reader (select).
        /// </summary>
        /// <param name="query">string query</param>
        /// <returns>List dictrionary of string-string</returns>
        public List<Dictionary<string, string>> XCTReader(string query)
        {
            result = new List<Dictionary<string, string>>();
            
            try
            {  
                connect = new DatabaseConnection();
                connect.Connect();
                OracleCommand cmd = new OracleCommand(query, connect.Con);
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Dictionary<string, string> fields = new Dictionary<string, string>();
                    for (int f = 0; f < reader.FieldCount; f++)
                    {
                        Console.WriteLine(reader.GetName(f));
                        fields[reader.GetName(f)] = Convert.ToString(reader.GetValue(f));
                    }
                        
                    result.Add(fields);
                }
            }
            catch (OracleException ex)
            {
                Console.WriteLine("Exception: " + ex);
            }
            finally
            {
                connect.Close();
            }
            return result;
        }
        /// <summary>
        /// Get a guest from the database using an ID.
        /// </summary>
        /// <param name="ID">int ID</param>
        /// <returns>List dictrionary of string-string</returns>
        public List<Dictionary<string, string>> GetGuestAccount(int ID)
        {
            string query = String.Format("SELECT * FROM Account a, Guest g WHERE a.AccountID = g.AccountID AND a.AccountID = {0}", ID);
            result = XCTReader(query);
            return result;
        }
        /// <summary>
        /// Get a guest from the database using a username.
        /// </summary>
        /// <param name="username">string username</param>
        /// <returns>List dictrionary of string-string</returns>
        public List<Dictionary<string, string>> GetGuestAccount(string username)
        {
            string query = String.Format("SELECT * FROM Account a, Employee g WHERE a.AccountID = g.AccountID AND a.Username = '{0}'", username);
            result = XCTReader(query);
            return result;
        }
        /// <summary>
        /// Get a guest from the database using a name.
        /// </summary>
        /// <param name="name">string name</param>
        /// <returns>List dictrionary of string-string</returns>
        public List<Dictionary<string, string>> GetGuestAccountWithName(string name)
        {
            string query = String.Format("SELECT * FROM Account a, Guest g WHERE a.AccountID = g.AccountID AND a.FULLNAME LIKE '%{0}%'", name);
            result = XCTReader(query);
            return result;
        }

        /// <summary>
        /// Get all guests that have no connection to a reservation an ID.
        /// </summary>
        /// <param name="ID">int ID</param>
        /// <returns>List dictrionary of string-string</returns>
        public List<Dictionary<string, string>> GetFreeGuestAccount(int ID)
        {
            string query = String.Format(@"SELECT * FROM Account a, Guest g WHERE a.AccountID = g.AccountID AND a.AccountID = {0} AND 
                                        g.GuestID NOT IN (SELECT gr.GuestID FROM GuestReservation gr WHERE GuestID = g.GuestID)", ID);
            result = XCTReader(query);
            return result;
        }
        /// <summary>
        /// Get all guests that have no connection to a reservation using a username.
        /// </summary>
        /// <param name="username">string username</param>
        /// <returns>List dictrionary of string-string</returns>
        public List<Dictionary<string, string>> GetFreeGuestAccount(string username)
        {
            string query = String.Format(@"SELECT * FROM Account a, Guest g WHERE a.AccountID = g.AccountID AND a.USERNAME = {0} AND 
                                        g.GuestID NOT IN (SELECT gr.GuestID FROM GuestReservation gr WHERE GuestID = g.GuestID)", username);
            result = XCTReader(query);
            return result;
        }
        /// <summary>
        /// Get a guest from the database using the RFID.
        /// </summary>
        /// <param name="RFID">string RFID</param>
        /// <returns>List dictrionary of string-string</returns>
        public List<Dictionary<string, string>> GetGuestAccountWithRFID(string RFID)
        {
            string query = String.Format("SELECT * FROM Account a, Guest g WHERE a.AccountID = g.AccountID AND g.RFID = '{0}'", RFID);
            result = XCTReader(query);
            return result;
        }
        /// <summary>
        /// Get a guest from the database using the reservationID.
        /// </summary>
        /// <param name="reservationID">string reservationID</param>
        /// <returns>List dictrionary of string-string</returns>
        public List<Dictionary<string, string>> GetGuestAccountByReservationID(string reservationID)
        {
            string query = String.Format(@"SELECT a.* FROM Account a, Guest g, GuestReservation gr, Reservation r WHERE a.AccountID = g.AccountID 
                                           AND gr.GuestID = g.GuestID AND gr.ReservationID = r.ReservationID AND r.ReservationID = {0} ", reservationID);
            result = XCTReader(query);
            return result;
        }
        /// <summary>
        /// Get an employee from the database using an ID.
        /// </summary>
        /// <param name="ID">int ID</param>
        /// <returns>List dictrionary of string-string</returns>
        public List<Dictionary<string, string>> GetEmployeeAccount(int ID)
        {
            string query = String.Format("SELECT * FROM Account a, Employee g WHERE a.AccountID = g.AccountID AND a.AccountID = {0}", ID);
            result = XCTReader(query);
            return result;
        }
        /// <summary>
        /// Get an employee from the database using a name.
        /// </summary>
        /// <param name="name">string name</param>
        /// <returns>List dictrionary of string-string</returns>
        public List<Dictionary<string, string>> GetEmployeeAccount(string name)
        {
            string query = String.Format("SELECT * FROM Account a, Employee g WHERE a.AccountID = g.AccountID AND a.AccountID = '{0}'", name);
            result = XCTReader(query);
            return result;
        }
        /// <summary>
        /// Set a guest in the database using the accountlibrary.account.
        /// </summary>
        /// <param name="account">list account</string></param>
        /// <returns>List dictrionary of string-string</returns>
        public int SetGuestAccount(List<string> account)
        {
            string query = "SELECT AccountID FROM Account WHERE AccountID = (SELECT MAX(AccountID) FROM Account)";
            result = XCTReader(query);
            int accountID;
            if (result.Count == 0)
            {
                accountID = 1;
            }
            else
            {
                string number = result[0]["ACCOUNTID"];
                accountID = Convert.ToInt32(number) + 1;
                Console.WriteLine("ACCOUNTID " + number);
            }
            query = "SELECT GuestID FROM Guest WHERE GuestID = (SELECT MAX(GuestID) FROM Guest)";
            result = XCTReader(query);
            Console.WriteLine("Count: " + result.Count);
            int guestID;
            if (result.Count == 0)
            {
                guestID = 1;
            }
            else
            {
                string number = result[0]["GUESTID"];
                guestID = Convert.ToInt32(number) + 1;
                Console.WriteLine("GUESTID " + number);
            }
            query = "SELECT RFID FROM RFID WHERE RFID NOT IN (SELECT RFID FROM Guest)";
            string RFID;
            result = XCTReader(query);
            if (result.Count == 0)
            {
                return 0;
            }
            else
            {
                RFID = result[0]["RFID"];
            }
            string date = String.Format("TO_DATE('{0}', 'DD-MM-YYYY')", account[7]);
            query = String.Format("INSERT INTO ACCOUNT VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',{8},'{9}','{10}')"
                , accountID, account[0], account[1], account[2]
                , account[3], account[4], account[5], account[6]
                , date, account[8],account[9]);
            XCTNonQuery(query);
            query = String.Format("INSERT INTO GUEST VALUES('{0}',{1},'{2}','N')"
                , guestID, accountID, RFID);
            Console.WriteLine("Try to add a guest with account ID: " + accountID);
            XCTNonQuery(query);
            return guestID;
        }
        /// <summary>
        /// Set an employee in the database using the accountlibrary.account and accountlibrary.employee.
        /// </summary>
        /// <param name="account">list account and list employee</param>
        /// <param name="employee">List dictrionary of string-string</param>
        public void SetEmployeeAccount(List<string> account, List<string> employee)
        {
            string date = String.Format("TO_DATE('{0}', 'DD-MM-YYYY HH24:MI:SS')", account[8]);
            string query = String.Format("INSERT INTO ACCOUNT VALUES({0},{1},'{2}','{3}','{4}','{5}','{6}','{7}',{8},'{9}','{10}')"
                , account[0], account[1], account[2], account[3]
                , account[4], account[5], account[6], account[7]
                , date, account[9], account[10]);
            XCTNonQuery(query);
            query = String.Format("INSERT INTO Employee VALUES({0},{1},{2})"
                , employee[0], employee[1], employee[2]);
            XCTNonQuery(query);
        }
        /// <summary>
        /// Get all guests from the database.
        /// </summary>
        /// <returns>List dictrionary of string-string</returns>
        public List<Dictionary<string, string>> GetAllGuests()
        {
            string query = "SELECT * FROM Account a, Guest g WHERE a.AccountID = g.AccountID";
            result = XCTReader(query);
            Console.WriteLine(result);
            return result;
        }
        /// <summary>
        /// Get all employees from the database.
        /// </summary>
        /// <returns>List dictrionary of string-string</returns>
        public List<Dictionary<string, string>> GetAllEmployees()
        {
            string query = "SELECT g.*, a.*, r.name as RoleName FROM Employee g, Account a, Role r WHERE a.AccountID = g.AccountID AND g.RoleID = r.RoleID ";
            result = XCTReader(query);
            return result;
        }
        /// <summary>
        /// Get all events from the database.
        /// </summary>
        /// <returns>List dictrionary of string-string</returns>
        public List<Dictionary<string, string>> GetAllEvents()
        {
            string query = "SELECT * FROM Event";
            result = XCTReader(query);
            return result;
        }
        /// <summary>
        /// Get an event from the database using an ID.
        /// </summary>
        /// <param name="ID">int ID</param>
        /// <returns>List dictrionary of string-string</returns>
        public List<Dictionary<string, string>> GetEvent(string ID)
        {
            string query = String.Format("SELECT * FROM Event WHERE EventID = {0}", ID);
            result = XCTReader(query);
            return result;
        }
        /// <summary>
        /// Set an event in the database using the eventinfo from a given list.
        /// </summary>
        /// <param name="eventinfo">List-string eventinfo</param>
        public void SetEvent(List<string> eventinfo)
        {
            string dateStart = String.Format("TO_DATE('{0}', 'DD-MM-YYYY HH24:MI:SS')", eventinfo[2]);
            string dateEnd = String.Format("TO_DATE('{0}', 'DD-MM-YYYY HH24-MI-SS')", eventinfo[3]);
            string query = String.Format("INSERT INTO Event VALUES ('{0}','{1}',{2},{3},'{4}','{5}')"
                , eventinfo[0], eventinfo[1], dateStart, dateEnd
                , eventinfo[4], eventinfo[5]);
            XCTNonQuery(query);
        }
        /// <summary>
        /// Delete a guest from the database using an ID.
        /// </summary>
        /// <param name="ID">string ID</param>
        public void DeleteGuest(string ID)
        {
            string query = String.Format("DELETE FROM GuestReservation WHERE GuestID = (SELECT GuestID FROM Account WHERE AccountID = {0})", ID);
            XCTNonQuery(query);
            query = String.Format("DELETE FROM Guest WHERE AccountID = {0}", ID);
            XCTNonQuery(query);

            query = String.Format("DELETE FROM Account WHERE AccountID = {0}", ID);
            XCTNonQuery(query);
        }
        /// <summary>
        /// Delete an employee from the database using an ID.
        /// </summary>
        /// <param name="ID">string ID</param>
        public void DeleteEmployee(string ID)
        {
            string query = String.Format("DELETE FROM Employee WHERE AccountID = {0}", ID);
            XCTNonQuery(query);
            query = String.Format("DELETE FROM Account WHERE AccountID = {0}", ID);
            XCTNonQuery(query);
        }
        /// <summary>
        /// Delete an event from the database using an ID.
        /// </summary>
        /// <param name="ID">string ID</param>
        public void DeleteEvent(string ID)
        {
            string query = String.Format("DELETE FROM Account WHERE EventID = {0}", ID);
            XCTNonQuery(query);
            query = String.Format("DELETE FROM Event WHERE EventID = {0}", ID);
            XCTNonQuery(query);
        }
        /// <summary>
        /// Update a guest in the database using a list of strings.
        /// </summary>
        /// <param name="guest">list-string guest</param>
        public void UpdateGuest(List<string> guest)
        {
            string query = String.Format("UPDATE Guest SET RFID = '{1}', IsPresent = '{2}' WHERE AccountID = guest{0};"
                , guest[0], guest[1], guest[2]);
            XCTNonQuery(query);
        }
        /// <summary>
        /// Update an employee in the database using a list of strings.
        /// </summary>
        /// <param name="employee">list-string employee</param>
        public void UpdateEmployee(List<string> employee)
        {
            string query = String.Format("UPDATE Employee SET EMPLOYEEID = {0}, ACCOUNTID = {1}, ROLEID = '{2}';"
                , employee[0], employee[1], employee[2]);
            XCTNonQuery(query);
        }
        /// <summary>
        /// Update an event in the database using a list of strings.
        /// </summary>
        /// <param name="eventinfo">list-string eventinfo</param>
        public void UpdateEvent(List<string> eventinfo)
        {
            string dateStart = String.Format("TO_DATE('{0}', 'DD-MM-YYYY HH24:MI:SS')", eventinfo[2]);
            string dateEnd = String.Format("TO_DATE('{0}', 'DD-MM-YYYY HH24:MI:SS')", eventinfo[3]);
            string query = String.Format("UPDATE Event SET LOCATION = '{1}', STARTDATE = {2}, ENDDATE = {3}, DESCRIPTION = '{4}', ADMISSIONFEE = '{5}' WHERE EventID = {0}"
                , eventinfo[0], eventinfo[1], dateStart, dateEnd, eventinfo[4], eventinfo[5]);
            XCTNonQuery(query);
        }
        /// <summary>
        /// Update an account in the database using a list of strings.
        /// </summary>
        /// <param name="account">list-string account</param>
        public void UpdateAccount(List<string> account)
        {
            string date = String.Format("TO_DATE('{0}', 'DD-MM-YYYY HH24:MI:SS')", account[8]);
            string query = String.Format("UPDATE  Account SET EVENTID = {1}, USERNAME = '{2}', PASSWORD = '{3}', FULLNAME = '{4}', ADRESS = '{5}', CITY = '{6}', POSTALCODE = '{7}', DATEOFBIRTH = {8}, EMAIL = '{9}', PHONENUMBER = '{10}' WHERE AccountID = {0}"
                , account[0], account[1], account[2], account[3]
                , account[4], account[5], account[6], account[7]
                , date, account[9], account[10]);
            XCTNonQuery(query);
        }
        /// <summary>
        /// Update a location in the database using a list of strings.
        /// </summary>
        /// <param name="location">list-string location</param>
        public void UpdateLocation(List<string> location)
        {
            string query = String.Format("UPDATE LocationType SET LOCATIONTYPEID = {0}, NAME = '{1}', DESCRIPTION = '{2}', PRICE = {3} WHERE LOCATIONTYPEID = {0}"
                , location[0], location[1], location[2], location[3]);
            XCTNonQuery(query);
        }

        /// <summary>
        /// Get an item from the database using an ID.
        /// </summary>
        /// <param name="ID">string ID</param>
        /// <returns>List dictrionary of string-string</returns>
        public List<Dictionary<string, string>> GetItem(string ID)
        {
            string query = String.Format("SELECT * FROM Item WHERE ITEMID = {0}", ID);
            result = XCTReader(query);
            return result;
        }

        public List<Dictionary<string, string>> GetAllItems()
        {
            string query = String.Format("SELECT * FROM Item");
            result = XCTReader(query);
            return result;
        }
        public List<Dictionary<string, string>> GetAllRentedItems()
        {
            string query = String.Format("SELECT ir.ITEMRENTALID,a.FULLNAME, i.TYPEITEM, i.NAME, r.STARTDATE, r.ENDDATE, r.TOTALAMOUNT,i.ITEMID FROM ITEM i , ITEMRENTAL ir, RENTAL r, GUEST g, ACCOUNT a WHERE i.ITEMID = ir.ITEMID AND ir.RENTALID = r.RENTALID AND r.GUESTID = g.GUESTID AND g.ACCOUNTID = a.ACCOUNTID");
            result = XCTReader(query);
            return result;
        }
        public List<Dictionary<string, string>> GetRentedItemsByRFID(string RFID)
        {
            string query = String.Format("SELECT ir.ITEMRENTALID,a.FULLNAME, i.TYPEITEM, i.NAME, r.STARTDATE, r.ENDDATE, r.TOTALAMOUNT,i.ITEMID FROM ITEM i , ITEMRENTAL ir, RENTAL r, GUEST g, ACCOUNT a WHERE i.ITEMID = ir.ITEMID AND ir.RENTALID = r.RENTALID AND r.GUESTID = g.GUESTID AND g.ACCOUNTID = a.ACCOUNTID AND g.RFID = '{0}'",RFID);
            result = XCTReader(query);
            return result;
        }
        
        /// <summary>
        /// Set an item in the database using a list of strings.
        /// </summary>
        /// <param name="item">list-string item</param>
        public void SetItem(List<string> item)
        {
            string query = "SELECT ITEMID FROM Item WHERE ITEMID=(Select MAX(ITEMID) FROM Item)";
            result = XCTReader(query);
            int ID;
            if (result.Count == 0)
            {
                ID = 1;
            }
            else
            {
                string number = result[0]["ITEMID"];
                ID = Convert.ToInt32(number) + 1;
                Console.WriteLine(number);
            }
            query = String.Format("INSERT INTO Item VALUES({0},'{1}','{2}','{3}','{4}')"
                , ID, item[0], item[1], item[2]
                , item[3]);
            XCTNonQuery(query);
        }
        /// <summary>
        /// Get a reservation from the database using an ID.
        /// </summary>
        /// <param name="ID">string ID</param>
        /// <returns>List dictrionary of string-string</returns>
        public List<Dictionary<string, string>> GetReservation(string ID)
        {
            string query = String.Format("SELECT * FROM RESERVATION R,GUESTRESERVATION G WHERE R.RESERVATIONID = G.RESERVATIONID AND G.GUESTID = {0}", ID);
            result = XCTReader(query);
            return result;
        }
        /// <summary>
        /// Get a reservation from the database using a value and a field.
        /// </summary>
        /// <param name="field">string field</param>
        /// <param name="value">string value</param>
        /// <returns>List dictrionary of string-string</returns>
        public List<Dictionary<string, string>> GetReservationByField(string field, string value)
        {
            string query = String.Format("SELECT * FROM RESERVATION WHERE {0} = '{1}'", field, value);
            result = XCTReader(query);
            return result;
        }
        /// <summary>
        /// Set a reservation in the database using a list of strings.
        /// </summary>
        /// <param name="reservation">list-string reservation</param>
        /// <returns>int ID</returns>
        public int SetReservation(List<string> reservation)
        {
            string query = "SELECT ReservationID FROM Reservation WHERE ReservationID = (SELECT MAX(ReservationID) FROM Reservation)";
            result = XCTReader(query);
            int ID;
            if (result.Count == 0)
            {
                ID = 1;
            }
            else
            {
                string number = result[0]["RESERVATIONID"];
                ID = Convert.ToInt32(number) + 1;
                Console.WriteLine(number);
            }
            
            Console.WriteLine(ID);
            
            string dateStart = String.Format("TO_DATE('{0}', 'yyyy/mm/dd hh24:mi:ss')", reservation[1]);
            string dateEnd = String.Format("TO_DATE('{0}', 'yyyy/mm/dd hh24:mi:ss')", reservation[2]);
            query = String.Format("INSERT INTO Reservation VALUES({0},'{1}',{2},{3},'{4}','{5}')"
                , ID, reservation[0], dateStart, dateEnd
                , reservation[3], reservation[4]);
            XCTNonQuery(query);
            return ID;
            
        }
        /// <summary>
        /// Set a guestreservation in the database using a guestID and a reservationID
        /// </summary>
        /// <param name="PID">string guestID</param>
        /// <param name="RID">string reservationID</param>
        public void SetGuestReservation(string PID, string RID)
        {
            string query = "SELECT GuestReservationID FROM GuestReservation WHERE GuestReservationID = (SELECT MAX(GuestReservationID) FROM GuestReservation)";
            result = XCTReader(query);
            int ID;
            if (result.Count == 0)
            {
                ID = 1;
            }
            else
            {
                ID = Convert.ToInt32(result[0]["GUESTRESERVATIONID"]) + 1;
            }
            
            query = String.Format("INSERT INTO GUESTRESERVATION VALUES({0},{1},{2})", ID, PID, RID);
            XCTNonQuery(query);
        }
        /// <summary>
        /// Get the presence of a guest from the database using an ID.
        /// </summary>
        /// <param name="ID">string ID</param>
        /// <returns>List dictrionary of string-string</returns>
        public List<Dictionary<string, string>> GetPresence(string ID)
        {
            string query = String.Format("SELECT ISPRESENT FROM GUEST WHERE GUESTID = {0}", ID);
            result = XCTReader(query);
            return result;
        }
        /// <summary>
        /// Update the presence of a guest in the database using list of strings.
        /// </summary>
        /// <param name="GuestID">string guestID</param>
        /// <param name="AccountID">string accountID</param>
        /// <param name="RFID">string RFID</param>
        /// <param name="isPresent">string isPresent</param>
        public void UpdatePresence(string GuestID, string AccountID, string RFID, string isPresent)
        {
            string query = String.Format("UPDATE GUEST SET GUESTID = {0}, ACCOUNTID = {1},RFID = '{2}',ISPRESENT = '{3}' WHERE GUESTID = {0}", GuestID, AccountID,RFID,isPresent);
            XCTNonQuery(query);
        }

        /// <summary>
        /// Set a file in the database using a list of strings.
        /// </summary>
        /// <param name="file">list-string file</param>
        public void SetFile(List<string> file)
        {
            string query = "SELECT FileID FROM FileTable WHERE FileID = (SELECT MAX(FileID) FROM FileTable)";
            result = XCTReader(query);
            int ID;
            if (result.Count == 0)
            {
                ID = 1;
            }
            else
            {
                ID = Convert.ToInt32(result[0]["FILEID"]) + 1;
            }
            string dateStart = String.Format("TO_DATE('{0}', 'dd/mm/yyyy hh24:mi:ss')", file[2]);
            query = String.Format("INSERT INTO FILETABLE VALUES({0},{1},{2},'{3}','{4}',{5},{6})"
                , ID, file[1], dateStart
                , file[3], file[4], file[5], file[6]);
            Console.WriteLine(query);
            XCTNonQuery(query);
        }

        /// <summary>
        /// Set a comment in the database using a list of strings
        /// </summary>
        /// <param name="comment">list-string comment</param>
        public void SetComment(List<string> comment)
        {
            string query = "SELECT CommentID FROM CommentTable where CommentID = (SELECT MAX(CommentID) FROM CommentTable)";
            result = XCTReader(query);
            int ID;
            if (result.Count == 0)
            {
                ID = 1;
            }
            else
            {
                ID = Convert.ToInt32(result[0]["COMMENTID"]) + 1;
            }
            string dateStart = String.Format("TO_DATE('{0}', 'dd/mm/yyyy hh24:mi:ss')", comment[4]);
            query = String.Format("INSERT INTO COMMENTTABLE VALUES({0},{1},{2},{3},{4},'{5}','{6}',{7},{8})"
                , ID, comment[1], comment[2], comment[3]
                , dateStart, comment[5], comment[6], comment[7]
                , comment[8]);
            XCTNonQuery(query);
        }

        /// <summary>
        /// Set a like/flag in the database using a list of strings.
        /// </summary>
        /// <param name="likeorflag">list-string likeorflag</param>
        public void SetLikeOrFlag(List<string> likeorflag)
        {
            string query = "SELECT LIKEFLAGID FROM LIKEORFLAG where LIKEFLAGID = (SELECT MAX(LIKEFLAGID) FROM LIKEORFLAG)";
            result = XCTReader(query);
            int ID;
            if (result.Count == 0)
            {
                ID = 1;
            }
            else
            {
                ID = Convert.ToInt32(result[0]["LIKEFLAGID"]) + 1;
            }
            string dateStart = String.Format("TO_DATE('{0}', 'dd/mm/yyyy hh24:mi:ss')", likeorflag[4]);
            string type = likeorflag[5].ToUpper();

            query = String.Format("INSERT INTO LIKEORFLAG VALUES({0}, {1}, {2}, {3}, {4}, '{5}')"
                , ID, likeorflag[1], likeorflag[2], likeorflag[3]
                , dateStart, type);
            XCTNonQuery(query);
        }

        /// <summary>
        /// Get a file from the database using an ID.
        /// </summary>
        /// <param name="ID">string ID</param>
        /// <returns>List dictrionary of string-string</returns>
        public List<Dictionary<string, string>> GetFile(string ID)
        {
            string query = String.Format("SELECT * FROM FILETABLE WHERE FILEID = {0}", ID);
            result = XCTReader(query);
            return result;
        }
        /// <summary>
        /// Get a comment from the database using an ID.    
        /// </summary>
        /// <param name="ID">string ID</param>
        /// <returns>List dictrionary of string-string</returns>
        public List<Dictionary<string, string>> GetComment(string fileID)
        {
            string query = String.Format("SELECT * FROM COMMENTTABLE WHERE FILEID = {0}", fileID);
            result = XCTReader(query);
            return result;
        }
        /// <summary>
        /// Get a like/flag from the database using an ID.
        /// </summary>
        /// <param name="ID">string ID</param>
        /// <returns>List dictrionary of string-string</returns>
        public List<Dictionary<string, string>> GetFlagOrLike(string ID)
        {
            string query = String.Format("SELECT * FROM LIKEORFLAG WHERE LIKEFLAGID = {0}", ID);
            result = XCTReader(query);
            return result;
        }
        /// <summary>
        /// Update a file using a list of strings.
        /// </summary>
        /// <param name="file">list-string file</param>
        public void UpdateFile(List<string> file)
        {
            string dateStart = String.Format("TO_DATE('{0}', 'dd/mm/yyyy hh24:mi:ss')", file[2]);
            string query = String.Format("UPDATE FILETABLE SET FILEID = {0}, ACCOUNTID = {1}, DATETIMEFILE = {2}, TITEL = '{3}', FILEPATH = '{4}', NUMBEROFLIKES = {5}, NUMBEROFFLAGS = {6} WHERE FILEID = {0}"
                , file[0], file[1], dateStart, file[3]
                , file[4], file[5], file[6]);
            XCTNonQuery(query);
        }
        /// <summary>
        /// Update a comment using a list of strings.
        /// </summary>
        /// <param name="file">list-string file</param>
        public void UpdateComment(List<string> comment)
        {
            string dateStart = String.Format("TO_DATE('{0}', 'dd/mm/yyyy hh24:mi:ss')", comment[4]);
            string query = String.Format("UPDATE COMMENTTABLE SET COMMENTID = {0}, FILEID = {1}, ACCOUNTID = {2}, COMMENTRECU = {3}, DATETIMECOMMENT = {4}, TITEL = '{5}', MESSAGE = '{6}', NUMBEROFLIKES = '{7}', NUMBEROFFLAGS = '{8}' WHERE COMMENTID = {0}"
                , comment[0], comment[1], comment[2], comment[3]
                , dateStart, comment[5], comment[6], comment[7], comment[8]);
            XCTNonQuery(query);
        }
        /// <summary>
        /// Delete a file from the datase using an ID.
        /// </summary>
        /// <param name="ID">string ID</param>
        public void DeleteFile(int ID)
        {
            string query = String.Format("DELETE FROM LIKEORFLAG WHERE FILEID = {0}", ID);
            XCTNonQuery(query);
            query = String.Format("DELETE FROM FILETABLE WHERE FILEID = {0}", ID);
            XCTNonQuery(query);
        }
        /// <summary>
        /// Delete a comment from the database using an ID.
        /// </summary>
        /// <param name="ID">string ID</param>
        public void DeleteComment(int ID)
        {
            string query = String.Format("DELETE FROM LIKEORFLAG WHERE COMMENTID = {0}", ID);
            XCTNonQuery(query);
            query = String.Format("DELETE FROM COMMENTTABLE WHERE COMMENTRECU = {0}", ID);
            XCTNonQuery(query);
            query = String.Format("DELETE FROM COMMENTTABLE WHERE COMMENTID = {0}", ID);
            XCTNonQuery(query);
        }
        /// <summary>
        /// Delete a flag/like from the database using an ID.
        /// </summary>
        /// <param name="ID">string ID</param>
        public void DeleteFlagLike(string ID)
        {
            string query = String.Format("DELETE FROM LIKEORFLAG WHERE LIKEFLAGID = {0}", ID);
            XCTNonQuery(query);
        }
        /// <summary>
        /// Delete a reservation from the database using an ID.
        /// </summary>
        /// <param name="ID">string ID</param>
        /// <returns>boolean</returns>
        public bool DeleteReservation(string ID)
        {
            try
            {
                string query = String.Format("DELETE FROM GuestReservation WHERE RESERVATIONID = {0}", ID);
                XCTNonQuery(query);
                query = String.Format("DELETE FROM Reservation WHERE RESERVATIONID = {0}", ID);
                XCTNonQuery(query);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Get all data from a reservation using an ID.
        /// </summary>
        /// <param name="ID">string ID</param>
        /// <returns>List dictionary of string-string</returns>
        public List<Dictionary<string, string>> GetINCReservation(string ID)
        {
            string query = String.Format("SELECT * FROM RESERVATION R, GUESTRESERVATION GR, GUEST G, LOCATION L WHERE R.RESERVATIONID = GR.RESERVATIONID AND GR.GUESTID = G.GUESTID AND R.RESERVATIONID = {0}");
            result = XCTReader(query);
            return result;
        }
        /// <summary>
        /// Get all present guests from the database.
        /// </summary>
        /// <returns>List dictionary of string-string</returns>
        public List<Dictionary<string, string>> GetAllPresentGuests()
        {
            {
                string query = "SELECT * FROM Account a, Guest g WHERE a.AccountID = g.AccountID AND g.ISPRESENT = 'Y'";
                result = XCTReader(query);
                Console.WriteLine(result);
                return result;
            }
        }

        /// <summary>
        /// Update an item in the database using a list of strings.
        /// </summary>
        /// <param name="item">list-string item</param>
        public void UpdateItem(List<string> newInfo, string itemID)
        {
            string query = String.Format("UPDATE ITEM SET NAME = '{0}', TYPEITEM = '{1}', STOCK = {2}, PRICE = {3} WHERE ITEMID = {4}"
                , newInfo[0], newInfo[1], newInfo[2]
                , newInfo[3],itemID);
            XCTNonQuery(query);
        }
        /// <summary>
        /// Set a rental in the database using an ID.
        /// </summary>
        /// <param name="rental">string ID</param>
        public int SetRental(List<string> rental)
        {
            string query = "SELECT RentalID FROM Rental WHERE RentalID = (SELECT MAX(RentalID) FROM Rental)";
            result = XCTReader(query);
            int ID;
            if (result.Count == 0)
            {
                ID = 1;
            }
            else
            {
                string number = result[0]["RENTALID"];
                ID = Convert.ToInt32(number) + 1;
                Console.WriteLine(number);
            }

            Console.WriteLine(ID);

            string dateStart = String.Format("TO_DATE('{0}', 'dd/mm/yyyy')", rental[1]);
            string dateEnd = String.Format("TO_DATE('{0}', 'dd/mm/yyyy')", rental[2]);
            query = String.Format("INSERT INTO RENTAL VALUES({0},{1},{2},{3},{4})"
                , ID, rental[0], dateStart, dateEnd
                , rental[3]);
            XCTNonQuery(query);
            return ID;
        }
        /// <summary>
        /// Get a rental from the database using an ID.
        /// </summary>
        /// <param name="ID">string ID</param>
        /// <returns>List dictionary of string-string</returns>
        public List<Dictionary<string, string>> GetRental(string ID)
        {
            string query = String.Format("SELECT * FROM RENTAL WHERE ID = {0}", ID);
            result = XCTReader(query);
            return result;
        }
        /// <summary>
        /// Update a rental in the database using a list of strings.
        /// </summary>
        /// <param name="rental">list-string rental</param>
        public void UpdateRental(List<string> rental)
        {
            string dateStart = String.Format("TO_DATE('{0}', 'yyyy/mm/dd hh24:mi:ss')", rental[2]);
            string dateEnd = String.Format("TO_DATE('{0}', 'yyyy/mm/dd hh24:mi:ss')", rental[3]);
            string query = String.Format("UPDATE RENTAL SET RENTALID = {0}, GUESTID = {1}, STARTDATE = {2}, ENDDATE = {3}, TOTALAMOUNT = '{4}')"
                , rental[0], rental[1], dateStart, dateEnd
                , rental[4]);
            XCTNonQuery(query);
        }
        /// <summary>
        /// Delete a rental from the database using an ID.
        /// </summary>
        /// <param name="ID">string ID</param>
        public void DeleteRental(string ID)
        {
            string query = String.Format("DELETE * FROM RENTAL WHERE RENTALID = {0}", ID);
            XCTNonQuery(query);
        }
        /// <summary>
        /// Delete an ItemRental from the database using an ID.
        /// </summary>
        /// <param name="ID">string ID</param>
        public void DeleteItemRental(string ID)
        {
            string query = String.Format("DELETE FROM ITEMRENTAL WHERE ITEMRENTALID = {0}", ID);
            XCTNonQuery(query);
        }
        /// <summary>
        /// Delete an item from the database using an ID.
        /// </summary>
        /// <param name="ID">string ID</param>
        public void DeleteItem(string ID)
        {
            string query = String.Format("DELETE FROM ITEM WHERE ITEMID = {0}", ID);
            XCTNonQuery(query);
        }
        /// <summary>
        /// Check the reserved status of a location using a locationID.
        /// </summary>
        /// <param name="PlaatsNR">string PlaatsNR</param>
        /// <returns>boolean</returns>
        public bool IsReserved(string PlaatsNR)
        {
            string query = String.Format("SELECT l.LocationID FROM Location l WHERE l.LocationID NOT IN (SELECT r.LocationID FROM Reservation r) AND l.LocationID = '{0}'", PlaatsNR);
            result = XCTReader(query);
            return result.Count != 0 ? true : false;
        }
        /// <summary>
        /// Set an itemrental in the database using a list of string.
        /// </summary>
        /// <param name="irental">list-string irental</param>
        public void SetItemRental(List<string> irental)
        {
            string query = "SELECT ITEMRENTALID FROM ITEMRENTAL WHERE ITEMRENTALID = (SELECT MAX(ITEMRENTALID) FROM ITEMRENTAL)";
            result = XCTReader(query);
            int ID;
            if (result.Count == 0)
            {
                ID = 1;
            }
            else
            {
                string number = result[0]["ITEMRENTALID"];
                ID = Convert.ToInt32(number) + 1;
                Console.WriteLine("ITEMRENTALID " + number);
            }
            query = String.Format("INSERT INTO ITEMRENTAL VALUES({0},{1},{2})"
                , ID, irental[0], irental[1]);
            XCTNonQuery(query);
        }
        /// <summary>
        /// Get a file from the database using a filepath.
        /// </summary>
        /// <param name="filepath">string filepath</param>
        /// <returns>List dictionary of string-string</returns>
        public List<Dictionary<string, string>> GetFileByFilePath(string filepath)
        {
            string query = String.Format("SELECT * FROM FileTable WHERE FILEPATH = '{0}'", filepath);
            result = XCTReader(query);
            return result;
        }
        /// <summary>
        /// Get a paymentstatus from the database using a name.
        /// </summary>
        /// <param name="name">string name</param>
        /// <returns>List dictionary of string-string</returns>
        public List<Dictionary<string,string>> GetPaymentStatus(string name)
        {
            string query = String.Format("SELECT r.PaymentStatus FROM Account a, Guest g, GuestReservation gr, Reservation r WHERE a.AccountID = g.AccountID AND g.GuestID = gr. GuestID AND gr.ReservationID = r.ReservationID AND a.Username = '{0}'", name);
            result = XCTReader(query);
            return result;
        }
        /// <summary>
        /// Get all locations from the database.
        /// </summary>
        /// <returns>List dictionary of string-string</returns>
        public List<Dictionary<string, string>> GetAllLocations()
        {
            string query = "SELECT * FROM LocationType";
            result = XCTReader(query);
            return result;
        }
        /// <summary>
        /// Check if username and login are correct and match the database values.
        /// </summary>
        /// <param name="username">string username</param>
        /// <param name="password">string password</param>
        /// <returns>List dictionary of string-string</returns>
        public List<Dictionary<string, string>> Login(string username, string password)
        {
            string query = String.Format("SELECT * FROM Account WHERE USERNAME = '{0}' AND PASSWORD = '{1}'", username, password);
            result = XCTReader(query);
            return result;
        }
        /// <summary>
        /// Check if username and login are correct and match the database values.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public List<Dictionary<string, string>> EmployeeLogin(string username, string password)
        {
            string query = String.Format("SELECT a.* FROM Account a, Employee e WHERE a.ACCOUNTID = e.ACCOUNTID AND  USERNAME = '{0}' AND PASSWORD = '{1}'", username, password);
            result = XCTReader(query);
            return result;
        }
        /// <summary>
        /// Check if username and login are correct and match the database values.
        /// </summary>
        /// <param name="username">string username</param>
        /// <param name="password">string password</param>
        /// <returns>List dictionary of string-string</returns>
        public List<Dictionary<string, string>> LoginEmp(string username, string password)
        {
            string query = String.Format("SELECT * FROM Account WHERE USERNAME = '{0}' AND PASSWORD = '{1}' AND AccountID NOT IN(SELECT AccountID FROM Guest)", username, password);
            result = XCTReader(query);
            return result;
        }
        
        /// <summary>
        /// Get all the swear words from the database.
        /// </summary>
        /// <returns>List dictionary of string-string</returns>
        public List<Dictionary<string, string>> GetAllSwearWords()
        {
            string query = String.Format("SELECT * FROM SWEARWORD");
            result = XCTReader(query);
            return result;
        }
     
        /// <summary>
        /// Get an account name from the database using an ID.
        /// </summary>
        /// <param name="id">int ID</param>
        /// <returns>List dictionary of string-string</returns>
        public List<Dictionary<string, string>> GetAccountName(int id)
        {
            string query = String.Format("SELECT FULLNAME FROM Account WHERE ACCOUNTID = {0}", id);
            result = XCTReader(query);
            return result;
        }
        /// <summary>
        /// Get a like/flag from a file using an ID and an accountID
        /// </summary>
        /// <param name="targetID">int fileID</param>
        /// <param name="accountID">int accountID</param>
        /// <returns>List dictionary of string-string</returns>
        public List<Dictionary<string, string>> GetFileLikeFlag(int targetID, int accountID)
        {
            string query = String.Format("SELECT * FROM LIKEORFLAG WHERE ACCOUNTID = '{0}' AND FILEID = '{1}'", accountID, targetID);
            result = XCTReader(query);
            return result;
        }
        /// <summary>
        /// Get a like/flag from a comment using an ID and an accountID
        /// </summary>
        /// <param name="targetID">int commentID</param>
        /// <param name="accountID">int accountID</param>
        /// <returns>List dictionary of string-string</returns>
        public List<Dictionary<string, string>> GetCommentLikeFlag(int targetID, int accountID)
        {
            string query = String.Format("SELECT * FROM LIKEORFLAG WHERE ACCOUNTID = '{0}' AND COMMENTID = '{1}'", accountID, targetID);
            result = XCTReader(query);
            return result;
        }

    }
}

