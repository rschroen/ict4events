﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountLibrary
{
    public class AccountManager
    {

        private List<Account> accounts;
        private List<Employee> employees;

        public List<Employee> Employees
        {
            get { return employees; }
            set { employees = value; }
        }
        public List<Account> Accounts
        {
            get { return accounts; }
            set { accounts = value; }
        }
        
        
        public AccountManager()
        {
            Accounts = new List<Account>();
            Employees = new List<Employee>();
        }

        

        public bool AddAccount(Account account)
        {
            // Look for account with the same ID
            Account exists = Accounts.Find(a => a.ID == account.ID);
            if (exists != null & account.ID != 0) // If account has ID 0, it's a temporary account
            {
                // ID already in use, return false
                return false;
            }
            // ID not in use, add account to list and return true
            Accounts.Add(account);
            return true;
        }
        public bool AddAccountE(Employee emp)
        {
            // Look for account with the same ID
            Account exists = Accounts.Find(a => a.ID == emp.ID);
            if (exists != null & emp.ID != 0) // If account has ID 0, it's a temporary account
            {
                // ID already in use, return false
                return false;
            }
            // ID not in use, add account to list and return true
            Employees.Add(emp);
            return true;
        }

        public bool RemoveAccount(int id)
        {
            // Look for account with the given ID
            Account account = Accounts.Find(a => a.ID == id);
            if (account != null)
            {
                // Account found, remove it, return true
                Accounts.Remove(account);
                return true;
            }
            // No account found, return false
            return false;
        }

        public bool RemoveAccount(Account a)
        {
            Accounts.Remove(a);
            return true;
        }
    }
}
