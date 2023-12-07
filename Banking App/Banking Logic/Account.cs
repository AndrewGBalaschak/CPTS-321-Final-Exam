// <copyright file="Account.cs" company="Balaschak Software">
// Copyright (c) Balaschak Software. All rights reserved.
// </copyright>

namespace Banking_Logic
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// Abstract account class.
    /// </summary>
    public abstract class Account : INotifyPropertyChanged
    {
        private protected string accountID;                 // Unique account ID
        private protected string accountName;               // Human-readable account name
        private protected decimal balance;                  // Account balance
        private protected List<string> transfers;           // List of transfer IDs involving account
        private protected List<string> recentTransfers;     // List of five most recent transfers

        /// <summary>
        /// Initializes a new instance of the <see cref="Account"/> class.
        /// </summary>
        /// <param name="accountID">Unique ID number of the account.</param>
        /// <param name="accountName">Human-readable account name.</param>
        /// <param name="balance">Amount of money in account.</param>
        public Account(string accountID, string accountName, decimal balance)
        {
            this.accountID = accountID;
            this.accountName = accountName;
            this.balance = balance;
            this.transfers = new List<string>();
            this.recentTransfers = new List<string>();
        }

        /// <inheritdoc/>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Gets or sets account name.
        /// </summary>
        public string AccountName
        {
            get
            {
                return this.accountName;
            }

            set
            {
                this.accountName = value;
                this.NotifyPropertyChanged("AccountName");
            }
        }

        /// <summary>
        /// Gets account balance.
        /// </summary>
        public decimal AccountBalance
        {
            get { return this.balance; }
        }

        /// <summary>
        /// Gets list of transfers.
        /// </summary>
        public List<string> Transfers
        {
            get { return this.transfers; }
        }

        /// <summary>
        /// Gets list of recent transfers.
        /// </summary>
        public List<string> RecentTransfers
        {
            get { return this.recentTransfers; }
        }

        /// <summary>
        /// Adds a transfer to the list of transfers.
        /// </summary>
        /// <param name="transferID">Unique transfer ID.</param>
        public void AddTransfer(string transferID)
        {
            this.transfers.Add(transferID);
            this.recentTransfers.Add(transferID);
            if (this.recentTransfers.Count > 5)
            {
                this.recentTransfers.RemoveAt(0);
            }
        }

        /// <summary>
        /// Removes a transfer to the list of transfers.
        /// </summary>
        /// <param name="transferID">Unique transfer ID.</param>
        public void RemoveTransfer(string transferID)
        {
            try
            {
                // Remove it from the recent transfers, if it's not there we jump to catch
                this.recentTransfers.Remove(transferID);

                // Find where the transfer was in the history, and get the one before it if it exists
                string candidateTransferID = this.transfers[this.transfers.IndexOf(transferID) - 1];

                // Make sure it's not in the recent transfers already
                if (!this.recentTransfers.Contains(candidateTransferID))
                {
                    this.recentTransfers.Insert(0, candidateTransferID);
                }
            }
            catch
            {
                // do nothing
            }

            // Remove from the account's transfer history
            this.transfers.Remove(transferID);
        }

        /// <summary>
        /// Abstract withdraw function, must be overwritten by children.
        /// </summary>
        /// <param name="amount">Amount to withdraw.</param>
        public abstract void Withdraw(decimal amount);

        /// <summary>
        /// Deposit amount into account.
        /// </summary>
        /// <param name="amount">Amount to deposit.</param>
        /// <exception cref="Exception">Thrown if amount is negative.</exception>
        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                this.balance += amount;
            }
            else
            {
                throw new Exception("Cannot deposit a negative amount.");
            }
        }

        // This method is from the MSDN documentation on implementing INotifyPropertyChanged
        private void NotifyPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}