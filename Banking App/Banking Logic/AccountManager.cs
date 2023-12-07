// <copyright file="AccountManager.cs" company="Balaschak Software">
// Copyright (c) Balaschak Software. All rights reserved.
// </copyright>

namespace Banking_Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Manages the database of accounts.
    /// </summary>
    public static class AccountManager
    {
        private static Dictionary<string, Account> accounts;

        /// <summary>
        /// Initializes static members of the <see cref="AccountManager"/> class.
        /// </summary>
        static AccountManager()
        {
            accounts = new Dictionary<string, Account>();
        }

        /// <summary>
        /// Creates a new account with the specifed account ID, returns the Account ID.
        /// </summary>
        /// <param name="accountID">Selection for unique account ID.</param>
        /// <param name="type">Type of account, checking or savings.</param>
        /// <param name="initialDeposit">Initial deposit into account.</param>
        /// <returns>Account ID.</returns>
        public static string CreateAccount(string accountID, string type, decimal initialDeposit)
        {
            if (accounts.ContainsKey(accountID))
            {
                throw new Exception("Account ID taken.");
            }

            if (type == "Checking")
            {
                Account temp = new CheckingAccount(accountID, "Checking", initialDeposit);
                accounts.Add(accountID, temp);
                return accountID;
            }
            else if (type == "Savings")
            {
                Account temp = new SavingsAccount(accountID, "Savings", initialDeposit, 0.05, 0m, 5m);
                accounts.Add(accountID, temp);
                return accountID;
            }

            throw new Exception("Invalid account type.");
        }

        /// <summary>
        /// Creates a new account, returns the Account ID.
        /// </summary>
        /// <param name="type">Type of account, checking or savings.</param>
        /// <param name="initialDeposit">Initial deposit into account.</param>
        /// <returns>Account ID.</returns>
        public static string CreateAccount(string type, decimal initialDeposit)
        {
            if (type == "Checking")
            {
                string accountID = GenerateAccountID();
                Account temp = new CheckingAccount(accountID, "Checking", initialDeposit);
                accounts.Add(accountID, temp);
                return accountID;
            }
            else if (type == "Savings")
            {
                string accountID = GenerateAccountID();
                Account temp = new SavingsAccount(accountID, "Savings", initialDeposit, 0.05, 0m, 5m);
                accounts.Add(accountID, temp);
                return accountID;
            }

            throw new Exception("Invalid account type.");
        }

        /// <summary>
        /// Associates a transfer with a pair of bank accounts.
        /// </summary>
        /// <param name="accountID1">First account to associate with transfer.</param>
        /// <param name="accountID2">Second account to associate with transfer.</param>
        /// <param name="transferID">Transfer to assiciate with account.</param>
        /// <exception cref="Exception">Something wrong.</exception>
        public static void AssociateTransfer(string accountID1, string accountID2, string transferID)
        {
            if (!CheckValidAccount(accountID1))
            {
                throw new Exception("Invalid account ID.");
            }

            if (!CheckValidAccount(accountID2))
            {
                throw new Exception("Invalid account ID.");
            }

            if (!TransferManager.CheckValidTransfer(transferID))
            {
                throw new Exception("Invalid transfer ID.");
            }

            accounts[accountID1].AddTransfer(transferID);
            accounts[accountID2].AddTransfer(transferID);
        }

        /// <summary>
        /// Associates a transfer with a specific bank account.
        /// </summary>
        /// <param name="accountID">Account to disassociate with transfer.</param>
        /// <param name="transferID">Transfer to disassociate with account.</param>
        /// <exception cref="Exception">Something wrong.</exception>
        public static void RemoveTransfer(string accountID, string transferID)
        {
            if (!CheckValidAccount(accountID))
            {
                throw new Exception("Invalid account ID.");
            }

            if (!TransferManager.CheckValidTransfer(transferID))
            {
                throw new Exception("Invalid transfer ID.");
            }

            accounts[accountID].RemoveTransfer(transferID);
        }

        /// <summary>
        /// Associates a transfer with a pair of bank accounts.
        /// </summary>
        /// <param name="accountID1">First account to disassociate with transfer.</param>
        /// <param name="accountID2">Second account to disassociate with transfer.</param>
        /// <param name="transferID">Transfer to disassociate with account.</param>
        /// <exception cref="Exception">Something wrong.</exception>
        public static void RemoveTransfer(string accountID1, string accountID2, string transferID)
        {
            if (!CheckValidAccount(accountID1))
            {
                throw new Exception("Invalid account ID.");
            }

            if (!CheckValidAccount(accountID2))
            {
                throw new Exception("Invalid account ID.");
            }

            if (!TransferManager.CheckValidTransfer(transferID))
            {
                throw new Exception("Invalid transfer ID.");
            }

            accounts[accountID1].RemoveTransfer(transferID);
            accounts[accountID2].RemoveTransfer(transferID);
        }

        /// <summary>
        /// Returns true if account exists.
        /// </summary>
        /// <param name="accountID">Unique ID number of the account.</param>
        /// <returns>True if account exists.</returns>
        public static bool CheckValidAccount(string accountID)
        {
            if (accounts.ContainsKey(accountID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the balance of the account with accountID.
        /// </summary>
        /// <param name="accountID">Unique ID number of the account.</param>
        /// <returns>Account balance.</returns>
        /// <exception cref="Exception">Thrown if account ID is invalid.</exception>
        public static decimal BalanceInquiry(string accountID)
        {
            if (!CheckValidAccount(accountID))
            {
                throw new Exception("Invalid account ID.");
            }

            return accounts[accountID].AccountBalance;
        }

        /// <summary>
        /// Gets the interest rate of the account with accountID.
        /// </summary>
        /// <param name="accountID">Unique ID number of the account.</param>
        /// <returns>Account interest rate.</returns>
        /// <exception cref="Exception">Thrown if accout is not valid or not savings.</exception>
        public static double GetInterestRate(string accountID)
        {
            if (!CheckValidAccount(accountID))
            {
                throw new Exception("Invalid account ID.");
            }

            try
            {
                SavingsAccount account = (SavingsAccount)accounts[accountID];
                return account.InterestRate;
            }
            catch
            {
                throw new Exception(string.Format("Account {0} is not a savings account.", accountID));
            }
        }

        /// <summary>
        /// Gets the interest from the current year to date of the account with accountID.
        /// </summary>
        /// <param name="accountID">Unique ID number of the account.</param>
        /// <returns>Account interest from the current year to date.</returns>
        /// <exception cref="Exception">Thrown if account is not valid or not savings.</exception>
        public static decimal GetInterestYTD(string accountID)
        {
            if (!CheckValidAccount(accountID))
            {
                throw new Exception("Invalid account ID.");
            }

            try
            {
                SavingsAccount account = (SavingsAccount)accounts[accountID];
                return account.CumulativeInterest;
            }
            catch
            {
                throw new Exception(string.Format("Account {0} is not a savings account.", accountID));
            }
        }

        /// <summary>
        /// Returns the five most recent transfers on an account.
        /// </summary>
        /// <param name="accountID">Unique account ID.</param>
        /// <returns>List of transfer IDs.</returns>
        /// <exception cref="Exception">Thrown if account ID is not valid.</exception>
        public static List<string> GetMostRecentTransfers(string accountID)
        {
            if (!CheckValidAccount(accountID))
            {
                throw new Exception("Invalid account ID.");
            }

            return accounts[accountID].RecentTransfers;
        }

        /// <summary>
        /// Withdraws ammount from account with accountID.
        /// </summary>
        /// <param name="accountID">Unique ID number of the account.</param>
        /// <param name="amount">Amount of money to withdraw.</param>
        /// <exception cref="Exception">Thrown if account ID is invalid.</exception>
        public static void Withdraw(string accountID, decimal amount)
        {
            if (CheckValidAccount(accountID))
            {
                accounts[accountID].Withdraw(amount);
            }
            else
            {
                throw new Exception("Invalid account ID.");
            }
        }

        /// <summary>
        /// Deposits ammount into account with accountID.
        /// </summary>
        /// <param name="accountID">Unique ID number of the account.</param>
        /// <param name="amount">Amount of money to deposit.</param>
        /// <exception cref="Exception">Thrown if account ID is invalid.</exception>
        public static void Deposit(string accountID, decimal amount)
        {
            if (CheckValidAccount(accountID))
            {
                accounts[accountID].Deposit(amount);
            }
            else
            {
                throw new Exception("Invalid account ID.");
            }
        }

        /// <summary>
        /// Generates a unique account ID.
        /// </summary>
        /// <returns>Unique account ID.</returns>
        private static string GenerateAccountID()
        {
            // Create input for the hashing algorithm for accountID
            string hashInput = DateTime.Now.ToString();
            byte[] inputBytes = ASCIIEncoding.ASCII.GetBytes(hashInput);

            // Salt the hash
            byte[] saltBytes = new byte[16];
            RandomNumberGenerator rand = RandomNumberGenerator.Create();
            rand.GetBytes(saltBytes);

            // Concatenate inputBytes and saltBytes
            byte[] inputBytesWithSaltBytes = new byte[inputBytes.Length + saltBytes.Length];

            for (int i = 0; i < inputBytes.Length; i++)
            {
                inputBytesWithSaltBytes[i] = inputBytes[i];
            }

            for (int i = 0; i < saltBytes.Length; i++)
            {
                inputBytesWithSaltBytes[inputBytes.Length + i] = saltBytes[i];
            }

            // Hash
            SHA256 mySHA256 = SHA256.Create();
            byte[] accountID = mySHA256.ComputeHash(inputBytesWithSaltBytes);
            StringBuilder sb = new StringBuilder();

            /*
            // Append bytes to a stringbuilder
            foreach (byte b in accountID)
            {
                sb.Append(b.ToString("x2"));
            }
            */

            // Append first 4 bytes to stringbuilder
            for (int i = 0; i < 4; i++)
            {
                sb.Append(accountID[i].ToString("x2"));
            }

            return sb.ToString();
        }
    }
}