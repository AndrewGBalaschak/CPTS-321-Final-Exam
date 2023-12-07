// <copyright file="Transfer.cs" company="Balaschak Software">
// Copyright (c) Balaschak Software. All rights reserved.
// </copyright>

namespace Banking_Logic
{
    using System;
    using System.Buffers.Binary;
    using System.Globalization;
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    /// Transfer class.
    /// </summary>
    public class Transfer
    {
        private string transferID;
        private string senderAccountID;
        private string recipientAccountID;
        private decimal amount;
        private DateTime time;

        /// <summary>
        /// Initializes a new instance of the <see cref="Transfer"/> class.
        /// </summary>
        /// <param name="transferID">Unique transfer ID.</param>
        /// <param name="senderAccountID">Account to transfer money from.</param>
        /// <param name="recipientAccountID">Account to transfer money to.</param>
        /// <param name="amount">Amount to transfer.</param>
        public Transfer(string transferID, string senderAccountID, string recipientAccountID, decimal amount)
        {
            this.transferID = transferID;
            this.senderAccountID = senderAccountID;
            this.recipientAccountID = recipientAccountID;
            this.amount = amount;
            this.time = DateTime.Now;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Transfer"/> class.
        /// </summary>
        /// <param name="transferID">Unique transfer ID.</param>
        /// <param name="senderAccountID">Account to transfer money from.</param>
        /// <param name="recipientAccountID">Account to transfer money to.</param>
        /// <param name="amount">Amount to transfer.</param>
        /// <param name="time">Time the transfer took place.</param>
        public Transfer(string transferID, string senderAccountID, string recipientAccountID, decimal amount, DateTime time)
        {
            this.transferID = transferID;
            this.senderAccountID = senderAccountID;
            this.recipientAccountID = recipientAccountID;
            this.amount = amount;
            this.time = time;
        }

        /// <summary>
        /// Gets transfer ID.
        /// </summary>
        public string TransferID
        {
            get { return this.transferID; }
        }

        /// <summary>
        /// Gets sender account ID.
        /// </summary>
        public string SenderAccountID
        {
            get { return this.senderAccountID; }
        }

        /// <summary>
        /// Gets recipient account ID.
        /// </summary>
        public string RecipientAccountID
        {
            get { return this.recipientAccountID; }
        }

        /// <summary>
        /// Gets transfer amount.
        /// </summary>
        public decimal Amount
        {
            get { return this.amount; }
        }

        /// <summary>
        /// Gets the transfer time.
        /// </summary>
        public DateTime Time
        {
            get { return this.time; }
        }
    }
}
