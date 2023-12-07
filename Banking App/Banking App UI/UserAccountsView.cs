// <copyright file="UserAccountsView.cs" company="Balaschak Software">
// Copyright (c) Balaschak Software. All rights reserved.
// </copyright>

namespace Banking_App_UI
{
    using System.Globalization;
    using System.Text;
    using System.Transactions;
    using System.Windows.Forms;
    using Banking_Logic;

    /// <summary>
    /// View for active user's accounts.
    /// </summary>
    public partial class UserAccountsView : Form
    {
        private string activeUser;
        private string savingsAccountID;
        private string checkingAccountID;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserAccountsView"/> class.
        /// </summary>
        /// <param name="activeUser">User that is currently logged in.</param>
        public UserAccountsView(string activeUser)
        {
            this.activeUser = activeUser;
            this.savingsAccountID = UserManager.GetSavingsID(activeUser);
            this.checkingAccountID = UserManager.GetCheckingID(activeUser);
            this.InitializeComponent();

            // Set static text
            this.SavingsAccountNumber.Text = this.savingsAccountID;
            this.CheckingAccountNumber.Text = this.checkingAccountID;
            this.InterestRateValue.Text = string.Format("{0}%", AccountManager.GetInterestRate(this.savingsAccountID) * 100);
            this.InterestYTDValue.Text = this.FormatMoney(AccountManager.GetInterestYTD(this.savingsAccountID));

            // Initialize balances
            this.UpdateGUI();
        }

        private void UpdateGUI()
        {
            this.UserLabel.Text = UserManager.GetFullName(this.activeUser);
            this.Text = this.UserLabel.Text + " Accounts";
            this.SavingsBalance.Text = this.FormatMoney(AccountManager.BalanceInquiry(this.savingsAccountID));
            this.CheckingBalance.Text = this.FormatMoney(AccountManager.BalanceInquiry(this.checkingAccountID));

            // Transcations
            StringBuilder sb = new StringBuilder();
            List<string> transactions = AccountManager.GetMostRecentTransfers(this.checkingAccountID);
            for (int i = transactions.Count - 1; i >= 0; i--)
            {
                sb.Append("Time: ");
                sb.Append(TransferManager.GetTransferTime(transactions[i]));
                sb.Append(" Transfer ID: ");
                sb.Append(transactions[i]);
                sb.Append(" Amount: ");
                sb.Append(this.FormatMoney(TransferManager.GetTransferAmount(this.checkingAccountID, transactions[i])));
                sb.Append('\n');
            }

            this.CheckingTransfers.Text = sb.ToString();

            sb.Clear();
            transactions = AccountManager.GetMostRecentTransfers(this.savingsAccountID);
            for (int i = transactions.Count - 1; i >= 0; i--)
            {
                sb.Append("Time: ");
                sb.Append(TransferManager.GetTransferTime(transactions[i]));
                sb.Append(" Transfer ID: ");
                sb.Append(transactions[i]);
                sb.Append(" Amount: ");
                sb.Append(this.FormatMoney(TransferManager.GetTransferAmount(this.savingsAccountID, transactions[i])));
                sb.Append('\n');
            }

            this.SavingsTransfers.Text = sb.ToString();
        }

        /// <summary>
        /// Event handler version of updateGUI.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event args.</param>
        private void UpdateGUI(object sender, EventArgs e)
        {
            this.UpdateGUI();
        }

        private string FormatMoney(decimal amount)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
            culture.NumberFormat.CurrencyNegativePattern = 1;
            return string.Format(culture, "{0:C}", amount);
        }

        private void TransferButton_Click(object sender, EventArgs e)
        {
            TransferView transferView = new TransferView(this.activeUser);
            transferView.OnTransfer += this.UpdateGUI;
            transferView.Show();
        }

        private void DisputeTransferButton_Click(object sender, EventArgs e)
        {
            TransferDisputeView transferDisputeView = new TransferDisputeView(this.activeUser);
            transferDisputeView.OnDispute += this.UpdateGUI;
            transferDisputeView.Show();
        }
    }
}
