// <copyright file="TestBankingLogic.cs" company="Balaschak Software">
// Copyright (c) Balaschak Software. All rights reserved.
// </copyright>

namespace Test_Banking_Logic
{
    using Banking_Logic;

    public class TestBankingLogic
    {
        private Client andrew;        // User for testing
        private Client bob;           // User for testing

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestTransfer()
        {
            // Set up demo user and accounts
            UserManager.CreateUser("Client", "AndrewB", "password", "Andrew", "Balaschak");
            this.andrew = (Client)UserManager.GetUser("AndrewB");
            UserManager.CreateUser("Client", "Bob", "password", "Bob", "Burgers");
            this.bob = (Client)UserManager.GetUser("Bob");

            UserManager.AssociateAccount("AndrewB", "Checking", AccountManager.CreateAccount("Checking", 500m));
            UserManager.AssociateAccount("AndrewB", "Savings", AccountManager.CreateAccount("Savings", 500m));

            UserManager.AssociateAccount("Bob", "Checking", AccountManager.CreateAccount("BobChecking", "Checking", 50));
            UserManager.AssociateAccount("Bob", "Savings", AccountManager.CreateAccount("BobSavings", "Savings", 300));

            // Check balances before transfer
            Assert.That(AccountManager.BalanceInquiry(this.andrew.CheckingAccountID), Is.EqualTo(500m));
            Assert.That(AccountManager.BalanceInquiry(this.bob.CheckingAccountID), Is.EqualTo(50m));

            // Create a transfer
            string transferID_1 = TransferManager.CreateTransfer(this.andrew.CheckingAccountID, this.bob.CheckingAccountID, 45);
            AccountManager.AssociateTransfer(this.andrew.CheckingAccountID, this.bob.CheckingAccountID, transferID_1);

            // Check balance after transfer
            Assert.That(AccountManager.BalanceInquiry(this.andrew.CheckingAccountID), Is.EqualTo(455m));
            Assert.That(AccountManager.BalanceInquiry(this.bob.CheckingAccountID), Is.EqualTo(95m));
        }

        [Test]
        public void TestTransferUndo()
        {
            // Check balance before transfer
            Assert.That(AccountManager.BalanceInquiry(this.andrew.CheckingAccountID), Is.EqualTo(455m));
            Assert.That(AccountManager.BalanceInquiry(this.bob.CheckingAccountID), Is.EqualTo(95m));

            // Create a transfer
            string transferID_1 = TransferManager.CreateTransfer(this.andrew.CheckingAccountID, this.bob.CheckingAccountID, 55);
            AccountManager.AssociateTransfer(this.andrew.CheckingAccountID, this.bob.CheckingAccountID, transferID_1);

            // Check balance after transfer
            Assert.That(AccountManager.BalanceInquiry(this.andrew.CheckingAccountID), Is.EqualTo(400m));
            Assert.That(AccountManager.BalanceInquiry(this.bob.CheckingAccountID), Is.EqualTo(150m));

            // Undo Transfer
            TransferManager.UndoTransfer(this.andrew.Username, transferID_1);

            // Check balance after undoing transfer
            Assert.That(AccountManager.BalanceInquiry(this.andrew.CheckingAccountID), Is.EqualTo(455m));
            Assert.That(AccountManager.BalanceInquiry(this.bob.CheckingAccountID), Is.EqualTo(95m));
        }
    }
}