namespace Banking_App_UI
{
    partial class TransferView
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
            AccountSelector = new ComboBox();
            FromAccount = new Label();
            ToAccount = new Label();
            ToAccountTextBox = new TextBox();
            TransferButton = new Button();
            AmountTextBox = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // AccountSelector
            // 
            AccountSelector.DropDownStyle = ComboBoxStyle.DropDownList;
            AccountSelector.FormattingEnabled = true;
            AccountSelector.Items.AddRange(new object[] { "Checking", "Savings" });
            AccountSelector.Location = new Point(12, 44);
            AccountSelector.Name = "AccountSelector";
            AccountSelector.Size = new Size(163, 23);
            AccountSelector.TabIndex = 0;
            // 
            // FromAccount
            // 
            FromAccount.AutoSize = true;
            FromAccount.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FromAccount.Location = new Point(12, 9);
            FromAccount.Name = "FromAccount";
            FromAccount.Size = new Size(163, 32);
            FromAccount.TabIndex = 1;
            FromAccount.Text = "From Account";
            // 
            // ToAccount
            // 
            ToAccount.AutoSize = true;
            ToAccount.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ToAccount.Location = new Point(25, 79);
            ToAccount.Name = "ToAccount";
            ToAccount.Size = new Size(133, 32);
            ToAccount.TabIndex = 2;
            ToAccount.Text = "To Account";
            // 
            // ToAccountTextBox
            // 
            ToAccountTextBox.BorderStyle = BorderStyle.FixedSingle;
            ToAccountTextBox.Location = new Point(12, 114);
            ToAccountTextBox.Name = "ToAccountTextBox";
            ToAccountTextBox.Size = new Size(160, 23);
            ToAccountTextBox.TabIndex = 3;
            // 
            // TransferButton
            // 
            TransferButton.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TransferButton.Location = new Point(12, 264);
            TransferButton.Name = "TransferButton";
            TransferButton.Size = new Size(163, 56);
            TransferButton.TabIndex = 4;
            TransferButton.Text = "Transfer";
            TransferButton.UseVisualStyleBackColor = true;
            TransferButton.Click += TransferButton_Click;
            // 
            // AmountTextBox
            // 
            AmountTextBox.BorderStyle = BorderStyle.FixedSingle;
            AmountTextBox.Location = new Point(12, 172);
            AmountTextBox.Name = "AmountTextBox";
            AmountTextBox.Size = new Size(160, 23);
            AmountTextBox.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(40, 140);
            label1.Name = "label1";
            label1.Size = new Size(100, 32);
            label1.TabIndex = 5;
            label1.Text = "Amount";
            // 
            // TransferView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(184, 332);
            Controls.Add(AmountTextBox);
            Controls.Add(label1);
            Controls.Add(TransferButton);
            Controls.Add(ToAccountTextBox);
            Controls.Add(ToAccount);
            Controls.Add(FromAccount);
            Controls.Add(AccountSelector);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "TransferView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "New Transfer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox AccountSelector;
        private Label FromAccount;
        private Label ToAccount;
        private TextBox ToAccountTextBox;
        private Button TransferButton;
        private TextBox AmountTextBox;
        private Label label1;
    }
}