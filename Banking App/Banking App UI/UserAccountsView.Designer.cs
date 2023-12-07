namespace Banking_App_UI
{
    partial class UserAccountsView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            CheckingLabel = new Label();
            SavingsLabel = new Label();
            UserLabel = new Label();
            CheckingBalance = new Label();
            SavingsBalance = new Label();
            TransferButton = new Button();
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            CheckingAccountNumber = new Label();
            SavingsAccountNumber = new Label();
            InterestRateLabel = new Label();
            InterestRateValue = new Label();
            InterestYTDLabel = new Label();
            InterestYTDValue = new Label();
            DisputeTransferButton = new Button();
            CheckingTransfers = new RichTextBox();
            SavingsTransfers = new RichTextBox();
            SuspendLayout();
            // 
            // CheckingLabel
            // 
            CheckingLabel.AutoSize = true;
            CheckingLabel.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CheckingLabel.Location = new Point(12, 100);
            CheckingLabel.Name = "CheckingLabel";
            CheckingLabel.Size = new Size(151, 45);
            CheckingLabel.TabIndex = 0;
            CheckingLabel.Text = "Checking";
            // 
            // SavingsLabel
            // 
            SavingsLabel.AutoSize = true;
            SavingsLabel.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SavingsLabel.Location = new Point(12, 287);
            SavingsLabel.Name = "SavingsLabel";
            SavingsLabel.Size = new Size(127, 45);
            SavingsLabel.TabIndex = 1;
            SavingsLabel.Text = "Savings";
            // 
            // UserLabel
            // 
            UserLabel.AutoSize = true;
            UserLabel.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            UserLabel.Location = new Point(12, 12);
            UserLabel.Name = "UserLabel";
            UserLabel.Size = new Size(349, 65);
            UserLabel.TabIndex = 2;
            UserLabel.Text = "User Full Name";
            // 
            // CheckingBalance
            // 
            CheckingBalance.AutoSize = true;
            CheckingBalance.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CheckingBalance.Location = new Point(50, 150);
            CheckingBalance.Name = "CheckingBalance";
            CheckingBalance.Size = new Size(156, 25);
            CheckingBalance.TabIndex = 3;
            CheckingBalance.Text = "CheckingBalance";
            // 
            // SavingsBalance
            // 
            SavingsBalance.AutoSize = true;
            SavingsBalance.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SavingsBalance.Location = new Point(50, 337);
            SavingsBalance.Name = "SavingsBalance";
            SavingsBalance.Size = new Size(142, 25);
            SavingsBalance.TabIndex = 4;
            SavingsBalance.Text = "SavingsBalance";
            // 
            // TransferButton
            // 
            TransferButton.BackColor = Color.SteelBlue;
            TransferButton.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TransferButton.ForeColor = SystemColors.Control;
            TransferButton.Location = new Point(522, 449);
            TransferButton.Name = "TransferButton";
            TransferButton.Size = new Size(250, 100);
            TransferButton.TabIndex = 5;
            TransferButton.Text = "Transfer";
            TransferButton.UseVisualStyleBackColor = false;
            TransferButton.Click += TransferButton_Click;
            // 
            // CheckingAccountNumber
            // 
            CheckingAccountNumber.AutoSize = true;
            CheckingAccountNumber.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CheckingAccountNumber.Location = new Point(169, 116);
            CheckingAccountNumber.Name = "CheckingAccountNumber";
            CheckingAccountNumber.Size = new Size(228, 25);
            CheckingAccountNumber.TabIndex = 6;
            CheckingAccountNumber.Text = "CheckingAccountNumber";
            // 
            // SavingsAccountNumber
            // 
            SavingsAccountNumber.AutoSize = true;
            SavingsAccountNumber.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SavingsAccountNumber.Location = new Point(169, 303);
            SavingsAccountNumber.Name = "SavingsAccountNumber";
            SavingsAccountNumber.Size = new Size(214, 25);
            SavingsAccountNumber.TabIndex = 7;
            SavingsAccountNumber.Text = "SavingsAccountNumber";
            // 
            // InterestRateLabel
            // 
            InterestRateLabel.AutoSize = true;
            InterestRateLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            InterestRateLabel.Location = new Point(50, 372);
            InterestRateLabel.Name = "InterestRateLabel";
            InterestRateLabel.Size = new Size(121, 25);
            InterestRateLabel.TabIndex = 8;
            InterestRateLabel.Text = "Interest Rate:";
            // 
            // InterestRateValue
            // 
            InterestRateValue.AutoSize = true;
            InterestRateValue.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            InterestRateValue.Location = new Point(175, 372);
            InterestRateValue.Name = "InterestRateValue";
            InterestRateValue.Size = new Size(24, 25);
            InterestRateValue.TabIndex = 9;
            InterestRateValue.Text = "ir";
            // 
            // InterestYTDLabel
            // 
            InterestYTDLabel.AutoSize = true;
            InterestYTDLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            InterestYTDLabel.Location = new Point(50, 407);
            InterestYTDLabel.Name = "InterestYTDLabel";
            InterestYTDLabel.Size = new Size(118, 25);
            InterestYTDLabel.TabIndex = 10;
            InterestYTDLabel.Text = "Interest YTD:";
            // 
            // InterestYTDValue
            // 
            InterestYTDValue.AutoSize = true;
            InterestYTDValue.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            InterestYTDValue.Location = new Point(175, 407);
            InterestYTDValue.Name = "InterestYTDValue";
            InterestYTDValue.Size = new Size(38, 25);
            InterestYTDValue.TabIndex = 11;
            InterestYTDValue.Text = "ytd";
            // 
            // DisputeTransferButton
            // 
            DisputeTransferButton.BackColor = Color.Peru;
            DisputeTransferButton.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DisputeTransferButton.ForeColor = SystemColors.Control;
            DisputeTransferButton.Location = new Point(522, 343);
            DisputeTransferButton.Name = "DisputeTransferButton";
            DisputeTransferButton.Size = new Size(250, 100);
            DisputeTransferButton.TabIndex = 12;
            DisputeTransferButton.Text = "Dispute Transfer";
            DisputeTransferButton.UseVisualStyleBackColor = false;
            DisputeTransferButton.Click += DisputeTransferButton_Click;
            // 
            // CheckingTransfers
            // 
            CheckingTransfers.Location = new Point(50, 178);
            CheckingTransfers.Name = "CheckingTransfers";
            CheckingTransfers.ReadOnly = true;
            CheckingTransfers.Size = new Size(450, 100);
            CheckingTransfers.TabIndex = 13;
            CheckingTransfers.Text = "";
            CheckingTransfers.WordWrap = false;
            // 
            // SavingsTransfers
            // 
            SavingsTransfers.Location = new Point(50, 435);
            SavingsTransfers.Name = "SavingsTransfers";
            SavingsTransfers.ReadOnly = true;
            SavingsTransfers.Size = new Size(450, 100);
            SavingsTransfers.TabIndex = 14;
            SavingsTransfers.Text = "";
            SavingsTransfers.WordWrap = false;
            // 
            // UserAccountsView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 561);
            Controls.Add(SavingsTransfers);
            Controls.Add(CheckingTransfers);
            Controls.Add(DisputeTransferButton);
            Controls.Add(InterestYTDValue);
            Controls.Add(InterestYTDLabel);
            Controls.Add(InterestRateValue);
            Controls.Add(InterestRateLabel);
            Controls.Add(SavingsAccountNumber);
            Controls.Add(CheckingAccountNumber);
            Controls.Add(TransferButton);
            Controls.Add(SavingsBalance);
            Controls.Add(CheckingBalance);
            Controls.Add(UserLabel);
            Controls.Add(SavingsLabel);
            Controls.Add(CheckingLabel);
            Name = "UserAccountsView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AccountsView";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label CheckingLabel;
        private Label SavingsLabel;
        private Label UserLabel;
        private Label CheckingBalance;
        private Label SavingsBalance;
        private Button TransferButton;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private Label CheckingAccountNumber;
        private Label SavingsAccountNumber;
        private Label InterestRateLabel;
        private Label InterestRateValue;
        private Label InterestYTDLabel;
        private Label InterestYTDValue;
        private Button DisputeTransferButton;
        private RichTextBox CheckingTransfers;
        private RichTextBox SavingsTransfers;
    }
}