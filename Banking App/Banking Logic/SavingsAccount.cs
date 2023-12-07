// <copyright file="SavingsAccount.cs" company="Balaschak Software">
// Copyright (c) Balaschak Software. All rights reserved.
// </copyright>

namespace Banking_Logic
{
    /// <summary>
    /// Savings account class.
    /// </summary>
    public class SavingsAccount : Account
    {
        private double interestRate;
        private decimal cumulativeInterest;
        private decimal minimumBalance;

        /// <summary>
        /// Initializes a new instance of the <see cref="SavingsAccount"/> class.
        /// </summary>
        /// <param name="accountID">Unique ID number of the account.</param>
        /// <param name="accountName">Human-readable account name.</param>
        /// <param name="balance">Amount of money in account.</param>
        /// <param name="interestRate">Yearly interest rate.</param>
        /// <param name="cumulativeInterest">Amount of money accumulated through interest for the current year.</param>
        /// <param name="minimumBalance">Minimum balance in the account.</param>
        public SavingsAccount(string accountID, string accountName, decimal balance, double interestRate, decimal cumulativeInterest, decimal minimumBalance)
            : base(accountID, accountName, balance)
        {
            this.interestRate = interestRate;
            this.cumulativeInterest = cumulativeInterest;
            this.minimumBalance = minimumBalance;
        }

        /// <summary>
        /// Gets interest rate.
        /// </summary>
        public double InterestRate
        {
            get { return this.interestRate; }
        }

        /// <summary>
        /// Gets cumulative interest.
        /// </summary>
        public decimal CumulativeInterest
        {
            get { return this.cumulativeInterest; }
        }

        /// <summary>
        /// Withdraws money from account.
        /// </summary>
        /// <param name="amount">Amount to withdraw.</param>
        /// <exception cref="Exception">Thrown if withdrawl amount greater than minimum account balance.</exception>
        public override void Withdraw(decimal amount)
        {
            if ((this.AccountBalance - this.minimumBalance) >= amount)
            {
                this.balance -= amount;
            }
            else
            {
                throw new Exception("Withdrawl amount greater than minimum account balance.");
            }
        }
    }
}
