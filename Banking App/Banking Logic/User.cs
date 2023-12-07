// <copyright file="User.cs" company="Balaschak Software">
// Copyright (c) Balaschak Software. All rights reserved.
// </copyright>

namespace Banking_Logic
{
    /// <summary>
    /// Abstract user class.
    /// </summary>
    public abstract class User
    {
        private string username;
        private string password;
        private string firstName;
        private string lastName;

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="username">Unique human-readable username.</param>
        /// <param name="password">Password hash.</param>
        /// <param name="firstName">User's first name.</param>
        /// <param name="lastName">User's last name.</param>
        public User(string username, string password, string firstName, string lastName)
        {
            this.username = username;
            this.password = password;
            this.firstName = firstName;
            this.lastName = lastName;
        }

        /// <summary>
        /// Gets username.
        /// </summary>
        public string Username
        {
            get { return this.username; }
        }

        /// <summary>
        /// Gets user's first and last name.
        /// </summary>
        public string FullName
        {
            get
            {
                return this.firstName + " " + this.lastName;
            }
        }

        /// <summary>
        /// Checks a password against the user's password.
        /// </summary>
        /// <param name="password">Input password.</param>
        /// <returns>True if password matches, false if no match.</returns>
        public bool Authenticate(string password)
        {
            if (password == this.password)
            {
                return true;
            }

            return false;
        }
    }
}