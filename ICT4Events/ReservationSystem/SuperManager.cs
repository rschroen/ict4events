﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountLibrary;
using DataLibrary;

namespace ReservationSystem
{
    public class SuperManager
    {
        ReservationManager rManager = new ReservationManager();
        AccountManager aManager = new AccountManager();
        DataManager dManager = new DataManager();

        /*  Temporary managers and accounts 
         *  Works as a link between the main form and "Add persons" form
         */
        public Account currentExistingAccount; // Holds the existing account that has been found in the "Add persons" form
        public Account mainBooker;
        public AccountManager tempAccountManager = new AccountManager();

        public SuperManager()
        {
        }

        public bool CheckPlace(string number){
            return dManager.IsReserved(number);
        }

        public Guest GetAccount(int ID)
        {
            List<Dictionary<string, string>> list = dManager.GetFreeGuestAccount(ID);
            Guest g = null;
            foreach (Dictionary<string, string> d in list)
            {
                g = new Guest(
                    Convert.ToInt32(d["ACCOUNTID"]),
                    Convert.ToInt32(d["EVENTID"]),
                    d["USERNAME"],
                    d["PASSWORD"],
                    d["FULLNAME"],
                    d["ADRESS"],
                    d["CITY"],
                    d["POSTALCODE"],
                    Convert.ToDateTime(d["DATEOFBIRTH"]),
                    d["EMAIL"],
                    d["PHONENUMBER"],
                    d["RFID"],
                    d["ISPRESENT"]
                    );
                aManager.AddAccount(g);
            }
            return g;
        }

        public Guest GetAccount(string username)
        {
            List<Dictionary<string, string>> list = dManager.GetFreeGuestAccount(username);
            Guest g = null;
            foreach (Dictionary<string, string> d in list)
            {
                g = new Guest(
                    Convert.ToInt32(d["ACCOUNTID"]),
                    Convert.ToInt32(d["EVENTID"]),
                    d["USERNAME"],
                    d["PASSWORD"],
                    d["FULLNAME"],
                    d["ADRESS"],
                    d["CITY"],
                    d["POSTALCODE"],
                    Convert.ToDateTime(d["DATEOFBIRTH"]),
                    d["EMAIL"],
                    d["PHONENUMBER"],
                    d["RFID"],
                    d["ISPRESENT"]
                    );
                aManager.AddAccount(g); 
            }
            return g;
        }

        public void AddAccount(Account a)
        {
            aManager.AddAccount(a);
        }

        public int SetReservation(List<string> reservationParams)
        {
            int ID = dManager.SetReservation(reservationParams);
            return ID;
        }

        public int SetAccount(List<string> accountParams)
        {
            int accountID = dManager.SetGuestAccount(accountParams);
            return accountID;
        }

        public void SetGuestReservation(int ID, int RID)
        {
            dManager.SetGuestReservation(Convert.ToString(ID), Convert.ToString(RID));
        }

        public List<Reservation> GetReservations(string field, string value){
            List<Dictionary<string, string>> list = dManager.GetReservationByField(field, value);
            if (list.Count == 0)
            {
                return null;
            }
            List<Account> dummyList = new List<Account>();
            List<Reservation> reservations = new List<Reservation>();
            foreach (Dictionary<string, string> d in list)
            {
                Reservation r = new Reservation(
                    Convert.ToInt32(d["RESERVATIONID"]),
                    Convert.ToInt32(d["LOCATIONID"]),
                    Convert.ToInt32(d["TOTALAMOUNT"]),
                    d["PAYMENTSTATUS"],
                    dummyList
                );
                reservations.Add(r);
            }
            return reservations;
        }

        public bool DeleteReservation(string ID)
        {
            return dManager.DeleteReservation(ID);
        }
  
  
    }
}
