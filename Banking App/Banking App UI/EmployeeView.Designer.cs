namespace Banking_App_UI
{
    partial class EmployeeView
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
            DisputeTransferButton = new Button();
            SuspendLayout();
            // 
            // DisputeTransferButton
            // 
            DisputeTransferButton.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DisputeTransferButton.Location = new Point(12, 12);
            DisputeTransferButton.Name = "DisputeTransferButton";
            DisputeTransferButton.Size = new Size(360, 337);
            DisputeTransferButton.TabIndex = 7;
            DisputeTransferButton.Text = "Dispute Transfer";
            DisputeTransferButton.UseVisualStyleBackColor = true;
            DisputeTransferButton.Click += DisputeTransferButton_Click;
            // 
            // EmployeeView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 361);
            Controls.Add(DisputeTransferButton);
            Name = "EmployeeView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EmployeeView";
            ResumeLayout(false);
        }

        #endregion

        private Button DisputeTransferButton;
    }
}