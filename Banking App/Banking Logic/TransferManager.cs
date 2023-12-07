// <copyright file="TransferManager.cs" company="Balaschak Software">
// Copyright (c) Balaschak Software. All rights reserved.
// </copyright>

namespace Banking_Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Manages the database of accounts.
    /// </summary>
    public static class TransferManager
    {
        private static Dictionary<string, Transfer> transfers;

        /// <summary>
        /// Initializes static members of the <see cref="TransferManager"/> class.
        /// </summary>
        static TransferManager()
        {
            transfers = new Dictionary<string, Transfer>();
        }

        /// <summary>
        /// Creates a transfer, logs it in the transfers dictionary, requests AccountManager to perform the transfer, and returns transfer ID.
        /// </summary>
        /// <param name="senderAccountID">Unique ID number of the sender account.</param>
        /// <param name="recipientAccountID">Unique ID number of the recipient account.</param>
        /// <param name="amount">Amount to transfer.</param>
        /// <returns>Transfer ID.</returns>
        /// <exception cref="Exception">Thrown if account ID is null or invalid.</exception>
        public static string CreateTransfer(string senderAccountID, string recipientAccountID, decimal amount)
        {
            if (string.IsNullOrEmpty(senderAccountID))
            {
                throw new Exception("Empty sender account ID.");
            }

            if (string.IsNullOrEmpty(recipientAccountID))
            {
                throw new Exception("Empty recipient account ID.");
            }

            if (senderAccountID == recipientAccountID)
            {
                throw new Exception("Cannot transfer to same account.");
            }

            if (amount <= 0)
            {
                throw new Exception("Cannot transfer zero or negative amount.");
            }

            if (!AccountManager.CheckValidAccount(senderAccountID))
            {
                throw new Exception("Invalid sender account ID.");
            }

            if (!AccountManager.CheckValidAccount(recipientAccountID))
            {
                throw new Exception("Invalid recipient account ID.");
            }

            string transferID = GenerateTransferID(senderAccountID, recipientAccountID);
            Transfer transfer = new Transfer(transferID, senderAccountID, recipientAccountID, amount);
            transfers.Add(transferID, transfer);
            AccountManager.Withdraw(senderAccountID, amount);
            AccountManager.Deposit(recipientAccountID, amount);
            return transferID;
        }

        /// <summary>
        /// Creates a transfer, logs it in the transfers dictionary, requests AccountManager to perform the transfer, and returns transfer ID.
        /// </summary>
        /// <param name="senderAccountID">Unique ID number of the sender account.</param>
        /// <param name="recipientAccountID">Unique ID number of the recipient account.</param>
        /// <param name="amount">Amount to transfer.</param>
        /// <param name="time">Time the transfer took place.</param>
        /// <returns>Transfer ID.</returns>
        /// <exception cref="Exception">Thrown if account ID is null or invalid.</exception>
        public static string CreateTransfer(string senderAccountID, string recipientAccountID, decimal amount, DateTime time)
        {
            if (string.IsNullOrEmpty(senderAccountID))
            {
                throw new Exception("Empty sender account ID.");
            }

            if (string.IsNullOrEmpty(recipientAccountID))
            {
                throw new Exception("Empty recipient account ID.");
            }

            if (senderAccountID == recipientAccountID)
            {
                throw new Exception("Cannot transfer to same account.");
            }

            if (amount <= 0)
            {
                throw new Exception("Cannot transfer zero or negative amount.");
            }

            if (!AccountManager.CheckValidAccount(senderAccountID))
            {
                throw new Exception("Invalid sender account ID.");
            }

            if (!AccountManager.CheckValidAccount(recipientAccountID))
            {
                throw new Exception("Invalid recipient account ID.");
            }

            string transferID = GenerateTransferID(senderAccountID, recipientAccountID);
            Transfer transfer = new Transfer(transferID, senderAccountID, recipientAccountID, amount, time);
            transfers.Add(transferID, transfer);
            AccountManager.Withdraw(senderAccountID, amount);
            AccountManager.Deposit(recipientAccountID, amount);
            return transferID;
        }

        /// <summary>
        /// Undoes a transfer, removes it in the transfers dictionary, and requests AccountManager to undo the transfer.
        /// </summary>
        /// <param name="username">Unique ID number of the account requesting the undo.</param>
        /// <param name="transferID">Unique ID number of the transfer to undo.</param>
        public static void UndoTransfer(string username, string transferID)
        {
            // Client can undo for 5 minutes
            if (UserManager.IsClient(username))
            {
                Transfer transfer = transfers[transferID];
                TimeSpan timespan = DateTime.Now.Subtract(transfer.Time);
                if (timespan.TotalMinutes < 5)
                {
                    // Make sure this transfer involves the user
                    if (UserManager.GetCheckingID(username) == transfer.SenderAccountID || UserManager.GetSavingsID(username) == transfer.SenderAccountID || UserManager.GetCheckingID(username) == transfer.RecipientAccountID || UserManager.GetSavingsID(username) == transfer.RecipientAccountID)
                    {
                        // Undo the transfer
                        AccountManager.Deposit(transfer.SenderAccountID, transfer.Amount);
                        AccountManager.Withdraw(transfer.RecipientAccountID, transfer.Amount);

                        // Remove from sender account
                        AccountManager.RemoveTransfer(transfer.SenderAccountID, transferID);

                        // Remove from recipient account
                        AccountManager.RemoveTransfer(transfer.RecipientAccountID, transferID);

                        // Remove from transfers database
                        transfers.Remove(transferID);
                    }
                    else
                    {
                        throw new Exception("Transfer ID not valid.");
                    }
                }
                else
                {
                    throw new Exception("Transfer is too old to undo.");
                }
            }

            // Employee can undo for 24 hours
            else if (UserManager.IsEmployee(username))
            {
                Transfer transfer = transfers[transferID];
                TimeSpan timespan = DateTime.Now.Subtract(transfer.Time);
                if (timespan.TotalHours < 24)
                {
                    // Undo the transfer
                    AccountManager.Deposit(transfer.SenderAccountID, transfer.Amount);
                    AccountManager.Withdraw(transfer.RecipientAccountID, transfer.Amount);

                    // Remove from sender account
                    AccountManager.RemoveTransfer(transfer.SenderAccountID, transferID);

                    // Remove from recipient account
                    AccountManager.RemoveTransfer(transfer.RecipientAccountID, transferID);

                    // Remove from transfers database
                    transfers.Remove(transferID);
                }
                else
                {
                    throw new Exception("Transfer is too old to undo.");
                }
            }
            else
            {
                throw new Exception("Invalid user type.");
            }
        }

        /// <summary>
        /// Gets the amount that was transfered from the user's perspective (deposit or withdrawl).
        /// </summary>
        /// <param name="accountID">Unique ID number of account.</param>
        /// <param name="transferID">Unique transfer ID.</param>
        /// <returns>Amount transferred into or out of user's account.</returns>
        /// <exception cref="Exception">Thrown if account ID is null or invalid.</exception>
        public static decimal GetTransferAmount(string accountID, string transferID)
        {
            if (!CheckValidTransfer(transferID))
            {
                throw new Exception("Invalid transfer ID.");
            }

            // If the account sent the amount
            if (transfers[transferID].SenderAccountID == accountID)
            {
                return -1 * transfers[transferID].Amount;
            }

            // If the account received the amount
            else if (transfers[transferID].RecipientAccountID == accountID)
            {
                return transfers[transferID].Amount;
            }
            else
            {
                throw new Exception("Invalid transfer ID.");
            }
        }

        /// <summary>
        /// Gets the time that a transaction took place.
        /// </summary>
        /// <param name="transferID">Unique transfer ID.</param>
        /// <returns>Time that the transaction took place.</returns>
        public static DateTime GetTransferTime(string transferID)
        {
            if (!CheckValidTransfer(transferID))
            {
                throw new Exception("Invalid transfer ID.");
            }

            return transfers[transferID].Time;
        }

        /// <summary>
        /// Returns true if transfer exists.
        /// </summary>
        /// <param name="transferID">Unique ID number of the transfer.</param>
        /// <returns>True if transfer exists.</returns>
        public static bool CheckValidTransfer(string transferID)
        {
            if (transfers.ContainsKey(transferID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Generates a unique transfer ID.
        /// </summary>
        /// <param name="senderAccountID">Unique ID number of sender account.</param>
        /// <param name="recipientAccountID">Unique ID number of receiving account.</param>
        /// <returns>Unique transfer ID number.</returns>
        private static string GenerateTransferID(string senderAccountID, string recipientAccountID)
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

            // Append names to stringbuilder
            sb.Append(senderAccountID.Substring(0, 4));
            sb.Append(recipientAccountID.Substring(0, 4));

            // Append first 4 bytes to stringbuilder
            for (int i = 0; i < 4; i++)
            {
                sb.Append(accountID[i].ToString("x2"));
            }

            return sb.ToString();
        }
    }
}