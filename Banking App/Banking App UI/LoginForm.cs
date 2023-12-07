// <copyright file="LoginForm.cs" company="Balaschak Software">
// Copyright (c) Balaschak Software. All rights reserved.
// </copyright>

namespace Banking_App_UI
{
    using Banking_Logic;

    /// <summary>
    /// Form for login window.
    /// </summary>
    public partial class LoginForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginForm"/> class.
        /// </summary>
        public LoginForm()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invokes events when login properties change.
        /// </summary>
        public event EventHandler<LoginEventArgs>? OnLogin;

        /// <summary>
        /// Runs when user clicks login button.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event args.</param>
        private void LoginButton_Click(object sender, EventArgs e)
        {
            string username = this.usernameTextBox.Text;
            string password = this.passwordTextBox.Text;
            try
            {
                User activeUser = UserManager.Login(username, password);
                this.Hide();
                this.OnLogin?.Invoke(this, new LoginEventArgs(activeUser));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}