// <copyright file="CheckingAccount.cs" company="Balaschak Software">
// Copyright (c) Balaschak Software. All rights reserved.
// </copyright>

namespace Banking_Logic
{
    /// <summary>
    /// Checking account class.
    /// </summary>
    public class CheckingAccount : Account
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CheckingAccount"/> class.
        /// </summary>
        /// <param name="accountID">Unique ID number of the account.</param>
        /// <param name="accountName">Human-readable account name.</param>
        /// <param name="balance">Amount of money in account.</param>
        public CheckingAccount(string accountID, string accountName, decimal balance)
            : base(accountID, accountName, balance)
        {
        }

        /// <summary>
        /// Withdraws money from account.
        /// </summary>
        /// <param name="amount">Amount to withdraw.</param>
        /// <exception cref="Exception">Thrown if withdrawl amount greater than account balance.</exception>
        public override void Withdraw(decimal amount)
        {
            if (this.AccountBalance >= amount)
            {
                this.balance -= amount;
            }
            else
            {
                throw new Exception("Withdrawl amount greater than account balance.");
            }
        }
    }
}