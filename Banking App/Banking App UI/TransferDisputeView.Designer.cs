namespace Banking_App_UI
{
    partial class TransferDisputeView
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
            TransferIDLabel = new Label();
            TransferIDTextBox = new TextBox();
            ReasonLabel = new Label();
            DisputeTransferButton = new Button();
            richTextBox1 = new RichTextBox();
            SuspendLayout();
            // 
            // TransferIDLabel
            // 
            TransferIDLabel.AutoSize = true;
            TransferIDLabel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TransferIDLabel.Location = new Point(12, 9);
            TransferIDLabel.Name = "TransferIDLabel";
            TransferIDLabel.Size = new Size(128, 32);
            TransferIDLabel.TabIndex = 2;
            TransferIDLabel.Text = "Transfer ID";
            // 
            // TransferIDTextBox
            // 
            TransferIDTextBox.BorderStyle = BorderStyle.FixedSingle;
            TransferIDTextBox.Location = new Point(12, 44);
            TransferIDTextBox.Name = "TransferIDTextBox";
            TransferIDTextBox.Size = new Size(460, 23);
            TransferIDTextBox.TabIndex = 4;
            // 
            // ReasonLabel
            // 
            ReasonLabel.AutoSize = true;
            ReasonLabel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ReasonLabel.Location = new Point(12, 70);
            ReasonLabel.Name = "ReasonLabel";
            ReasonLabel.Size = new Size(90, 32);
            ReasonLabel.TabIndex = 5;
            ReasonLabel.Text = "Reason";
            // 
            // DisputeTransferButton
            // 
            DisputeTransferButton.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DisputeTransferButton.Location = new Point(12, 293);
            DisputeTransferButton.Name = "DisputeTransferButton";
            DisputeTransferButton.Size = new Size(460, 56);
            DisputeTransferButton.TabIndex = 6;
            DisputeTransferButton.Text = "Dispute Transfer";
            DisputeTransferButton.UseVisualStyleBackColor = true;
            DisputeTransferButton.Click += DisputeTransferButton_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.Location = new Point(12, 105);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(460, 182);
            richTextBox1.TabIndex = 7;
            richTextBox1.Text = "";
            // 
            // TransferDisputeView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 361);
            Controls.Add(richTextBox1);
            Controls.Add(DisputeTransferButton);
            Controls.Add(ReasonLabel);
            Controls.Add(TransferIDTextBox);
            Controls.Add(TransferIDLabel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "TransferDisputeView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dispute Transfer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label TransferIDLabel;
        private TextBox TransferIDTextBox;
        private Label ReasonLabel;
        private Button DisputeTransferButton;
        private RichTextBox richTextBox1;
    }
}