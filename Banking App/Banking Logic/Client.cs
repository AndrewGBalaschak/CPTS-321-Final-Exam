// <copyright file="Client.cs" company="Balaschak Software">
// Copyright (c) Balaschak Software. All rights reserved.
// </copyright>

namespace Banking_Logic
{
    /// <summary>
    /// User subclass for bank clients.
    /// </summary>
    public class Client : User
    {
        private string savingsAccountID;
        private string checkingAccountID;

        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// </summary>
        /// <param name="username"">Unique user ID.</param>
        /// <param name="password">Password hash.</param>
        /// <param name="firstName">User's first name.</param>
        /// <param name="lastName">User's last name.</param>
        public Client(string username, string password, string firstName, string lastName)
            : base(username, password, firstName, lastName)
        {
            this.savingsAccountID = string.Empty;
            this.checkingAccountID = string.Empty;
        }

        /// <summary>
        /// Gets or sets SavingsAccountID.
        /// </summary>
        public string SavingsAccountID
        {
            get
            {
                return this.savingsAccountID;
            }

            set
            {
                if (string.IsNullOrEmpty(this.savingsAccountID))
                {
                    this.savingsAccountID = value;
                }
                else
                {
                    throw new Exception("User already has savings account.");
                }
            }
        }

        /// <summary>
        /// Gets or sets CheckingAccountID.
        /// </summary>
        public string CheckingAccountID
        {
            get
            {
                return this.checkingAccountID;
            }

            set
            {
                if (string.IsNullOrEmpty(this.checkingAccountID))
                {
                    this.checkingAccountID = value;
                }
                else
                {
                    throw new Exception("User already has checking account.");
                }
            }
        }
    }
}