// <copyright file="Program.cs" company="Balaschak Software">
// Copyright (c) Balaschak Software. All rights reserved.
// </copyright>

namespace Banking_App_UI
{
    using Banking_Logic;

    /// <summary>
    /// Main program.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            // Set up demo user and accounts
            UserManager.CreateUser("Client", "AndrewB", "password", "Andrew", "Balaschak");
            Client andrew = (Client)UserManager.GetUser("AndrewB");
            UserManager.CreateUser("Client", "Bob", "password", "Bob", "Burgers");
            Client bob = (Client)UserManager.GetUser("Bob");

            UserManager.AssociateAccount("AndrewB", "Checking", AccountManager.CreateAccount("Checking", 500m));
            UserManager.AssociateAccount("AndrewB", "Savings", AccountManager.CreateAccount("Savings", 500m));

            UserManager.AssociateAccount("Bob", "Checking", AccountManager.CreateAccount("BobChecking", "Checking", 45m));
            UserManager.AssociateAccount("Bob", "Savings", AccountManager.CreateAccount("BobSavings", "Savings", 275m));

            // Create some demo transfers
            string transferID_1 = TransferManager.CreateTransfer(andrew.CheckingAccountID, bob.CheckingAccountID, 45);
            AccountManager.AssociateTransfer(andrew.CheckingAccountID, bob.CheckingAccountID, transferID_1);

            string transferID_2 = TransferManager.CreateTransfer(andrew.SavingsAccountID, bob.CheckingAccountID, 10, DateTime.Now.Subtract(TimeSpan.FromMinutes(10)));
            AccountManager.AssociateTransfer(andrew.SavingsAccountID, bob.CheckingAccountID, transferID_2);

            // Set up demo employee
            UserManager.CreateUser("Employee", "admin", "admin", "Sue", "Doe");

            // Initialize
            ApplicationConfiguration.Initialize();
            LoginForm loginForm = new LoginForm();

            // Subscribe to the OnLogin event
            loginForm.OnLogin += OpenAccountsView;

            // Start the GUI
            Application.Run(loginForm);
        }

        /// <summary>
        /// Runs when a user successfully logs in.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">LoginEventArgs object.</param>
        private static void OpenAccountsView(object sender, LoginEventArgs e)
        {
            // Check if logged in user is client or employee
            if (UserManager.IsClient(e.activeUser.Username))
            {
                UserAccountsView accountsView = new UserAccountsView(e.activeUser.Username);
                accountsView.Show();
            }
            else if (UserManager.IsEmployee(e.activeUser.Username))
            {
                EmployeeView employeeView = new EmployeeView(e.activeUser.Username);
                employeeView.Show();
            }
            else
            {
                MessageBox.Show("Invalid user.");
            }
        }
    }
}