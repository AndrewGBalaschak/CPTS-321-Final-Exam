// <copyright file="EmployeeView.cs" company="Balaschak Software">
// Copyright (c) Balaschak Software. All rights reserved.
// </copyright>

namespace Banking_App_UI
{
    /// <summary>
    /// View for employees.
    /// </summary>
    public partial class EmployeeView : Form
    {
        private string activeUser;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeView"/> class.
        /// </summary>
        /// <param name="activeUser">The active user.</param>
        public EmployeeView(string activeUser)
        {
            this.activeUser = activeUser;
            this.InitializeComponent();
        }

        private void DisputeTransferButton_Click(object sender, EventArgs e)
        {
            TransferDisputeView transferDisputeView = new TransferDisputeView(this.activeUser);
            transferDisputeView.Show();
        }
    }
}
