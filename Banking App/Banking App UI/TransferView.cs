// <copyright file="TransferView.cs" company="Balaschak Software">
// Copyright (c) Balaschak Software. All rights reserved.
// </copyright>

namespace Banking_App_UI
{
    using Banking_Logic;

    /// <summary>
    /// Allows user to transfer money.
    /// </summary>
    public partial class TransferView : Form
    {
        private string activeUser;
        private string savingsAccountID;
        private string checkingAccountID;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransferView"/> class.
        /// </summary>
        /// <param name="activeUser">The active user.</param>
        public TransferView(string activeUser)
        {
            this.activeUser = activeUser;
            this.savingsAccountID = UserManager.GetSavingsID(activeUser);
            this.checkingAccountID = UserManager.GetCheckingID(activeUser);
            this.InitializeComponent();
        }

        /// <summary>
        /// Invokes events when transfer occurs.
        /// </summary>
        public event EventHandler? OnTransfer;

        private void TransferButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Transfer from checking
                if (this.AccountSelector.SelectedIndex == 0)
                {
                    decimal amount = decimal.Parse(this.AmountTextBox.Text);
                    string transferID = TransferManager.CreateTransfer(this.checkingAccountID, this.ToAccountTextBox.Text, amount);
                    AccountManager.AssociateTransfer(this.checkingAccountID, this.ToAccountTextBox.Text, transferID);
                    this.OnTransfer?.Invoke(this, EventArgs.Empty);
                }

                // Transfer from savings
                else if (this.AccountSelector.SelectedIndex == 1)
                {
                    decimal amount = decimal.Parse(this.AmountTextBox.Text);
                    string transferID = TransferManager.CreateTransfer(this.savingsAccountID, this.ToAccountTextBox.Text, amount);
                    AccountManager.AssociateTransfer(this.savingsAccountID, this.ToAccountTextBox.Text, transferID);
                    this.OnTransfer?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    throw new Exception("Something went wrong.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
