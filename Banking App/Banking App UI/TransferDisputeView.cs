// <copyright file="TransferDisputeView.cs" company="Balaschak Software">
// Copyright (c) Balaschak Software. All rights reserved.
// </copyright>

namespace Banking_App_UI
{
    using Banking_Logic;

    /// <summary>
    /// Allows user to dispute transfers on their account.
    /// </summary>
    public partial class TransferDisputeView : Form
    {
        private string activeUser;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransferDisputeView"/> class.
        /// </summary>
        /// <param name="activeUser">The active user.</param>
        public TransferDisputeView(string activeUser)
        {
            this.activeUser = activeUser;
            this.InitializeComponent();
        }

        /// <summary>
        /// Invokes events when transfer occurs.
        /// </summary>
        public event EventHandler? OnDispute;

        private void DisputeTransferButton_Click(object sender, EventArgs e)
        {
            try
            {
                TransferManager.UndoTransfer(this.activeUser, this.TransferIDTextBox.Text);
                this.OnDispute?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
