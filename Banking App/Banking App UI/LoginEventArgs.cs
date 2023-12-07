// <copyright file="LoginEventArgs.cs" company="Balaschak Software">
// Copyright (c) Balaschak Software. All rights reserved.
// </copyright>

namespace Banking_App_UI
{
    using Banking_Logic;

    /// <summary>
    /// Event args class for sending an event that a user is logged in.
    /// </summary>
    public class LoginEventArgs : EventArgs
    {
        public User activeUser;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginEventArgs"/> class.
        /// </summary>
        /// <param name="user">The user logged in.</param>
        public LoginEventArgs(User user)
        {
            this.activeUser = user;
        }
    }
}
