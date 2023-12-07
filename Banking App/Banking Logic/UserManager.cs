// <copyright file="UserManager.cs" company="Balaschak Software">
// Copyright (c) Balaschak Software. All rights reserved.
// </copyright>

namespace Banking_Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Manages the database of users.
    /// </summary>
    public static class UserManager
    {
        private static Dictionary<string, User> users;

        /// <summary>
        /// Initializes static members of the <see cref="UserManager"/> class.
        /// </summary>
        static UserManager()
        {
            users = new Dictionary<string, User>();
        }

        /// <summary>
        /// Attempts to log in a user.
        /// </summary>
        /// <param name="username">Username of user to log in.</param>
        /// <param name="password">Password of user to log in.</param>
        /// <returns>User object if user is successfuly logged in.</returns>
        /// <exception cref="Exception">Throws exception for non-existent username or incorrect password.</exception>
        public static User Login(string username, string password)
        {
            if (users.ContainsKey(username))
            {
                User candidate = users[username];
                if (candidate.Authenticate(password))
                {
                    return candidate;
                }

                throw new Exception("Incorrect password.");
            }

            throw new Exception(string.Format("User {0} does not exist.", username));
        }

        /// <summary>
        /// Returns a user based on username.
        /// </summary>
        /// <param name="username">Unique username.</param>
        /// <returns>User object.</returns>
        /// <exception cref="Exception">Thrown if user does not exist.</exception>
        public static User GetUser(string username)
        {
            if (!users.ContainsKey(username))
            {
                throw new Exception("Invalid username");
            }

            return users[username];
        }

        /// <summary>
        /// Returns a user's savings account ID.
        /// </summary>
        /// <param name="username">Unique username.</param>
        /// <returns>String representing savings account ID.</returns>
        /// <exception cref="Exception">Thrown if user is not a client.</exception>
        public static string GetSavingsID(string username)
        {
            if (!IsClient(username))
            {
                throw new Exception("That user is not a client");
            }

            Client user = (Client)GetUser(username);
            return user.SavingsAccountID;
        }

        /// <summary>
        /// Returns a user's checking account ID.
        /// </summary>
        /// <param name="username">Unique username.</param>
        /// <returns>String representing checking account ID.</returns>
        /// <exception cref="Exception">Thrown if user is not a client.</exception>
        public static string GetCheckingID(string username)
        {
            if (!IsClient(username))
            {
                throw new Exception("That user is not a client");
            }

            Client user = (Client)GetUser(username);
            return user.CheckingAccountID;
        }

        /// <summary>
        /// Returns a user's first and last name.
        /// </summary>
        /// <param name="username">Unique username.</param>
        /// <returns>String of user's first and last name.</returns>
        /// <exception cref="Exception">Thrown if username is invalid.</exception>
        public static string GetFullName(string username)
        {
            if (!users.ContainsKey(username))
            {
                throw new Exception("Invalid username.");
            }

            User user = GetUser(username);
            return user.FullName;
        }

        /// <summary>
        /// Returns true if user is a client.
        /// </summary>
        /// <param name="username">Unique username.</param>
        /// <returns>True if user is client type.</returns>
        public static bool IsClient(string username)
        {
            User user = GetUser(username);
            if (user is Client)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Returns true if user is an employee.
        /// </summary>
        /// <param name="username">Unique username.</param>
        /// <returns>True if user is employee type.</returns>
        public static bool IsEmployee(string username)
        {
            User user = GetUser(username);
            if (user is Employee)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Creates a new user and adds them to the dictionary of users.
        /// </summary>
        /// <param name="type">Type of user, either client or employee.</param>
        /// <param name="username">Unique human-readable username.</param>
        /// <param name="password">Password hash.</param>
        /// <param name="firstName">User's first name.</param>
        /// <param name="lastName">User's last name.</param>
        /// <exception cref="Exception">Throws exception for invalid user type.</exception>
        public static void CreateUser(string type, string username, string password, string firstName, string lastName)
        {
            if (CheckNewUsername(username))
            {
                if (type == "Client")
                {
                    User user = new Client(username, password, firstName, lastName);
                    users.Add(username, user);
                }
                else if (type == "Employee")
                {
                    User user = new Employee(username, password, firstName, lastName);
                    users.Add(username, user);
                }
                else
                {
                    throw new Exception("Invalid user type.");
                }
            }
        }

        /// <summary>
        /// Associates a bank account with a specific user.
        /// </summary>
        /// <param name="username">User to associate with account.</param>
        /// <param name="accountType">Type of account, checking or savings.</param>
        /// <param name="accountID">Account to associate with user.</param>
        /// <exception cref="Exception">Thrown when something is wrong.</exception>
        public static void AssociateAccount(string username, string accountType, string accountID)
        {
            if (users.ContainsKey(username))
            {
                if (AccountManager.CheckValidAccount(accountID))
                {
                    Client temp = (Client)users[username];

                    if (accountType == "Savings")
                    {
                        temp.SavingsAccountID = accountID;
                    }
                    else if (accountType == "Checking")
                    {
                        temp.CheckingAccountID = accountID;
                    }
                    else
                    {
                        throw new Exception("Invalid account type.");
                    }
                }
                else
                {
                    throw new Exception("Invalid account ID.");
                }
            }
            else
            {
                throw new Exception("Invalid user ID.");
            }
        }

        /// <summary>
        /// Checks to make sure a new username is unique.
        /// </summary>
        /// <param name="username">New username.</param>
        /// <returns>True if username is unique.</returns>
        private static bool CheckNewUsername(string username)
        {
            if (users.ContainsKey(username))
            {
                return false;
            }

            return true;
        }
    }
}