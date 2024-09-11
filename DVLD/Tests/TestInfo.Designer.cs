namespace DVLD.Tests
{
    partial class TestInfo
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
            this.uctrTestInfo1 = new DVLD.Tests.Vison_Test.uctrTestInfo();
            this.SuspendLayout();
            // 
            // uctrTestInfo1
            // 
            this.uctrTestInfo1.Location = new System.Drawing.Point(2, 1);
            this.uctrTestInfo1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.uctrTestInfo1.Name = "uctrTestInfo1";
            this.uctrTestInfo1.Size = new System.Drawing.Size(543, 549);
            this.uctrTestInfo1.TabIndex = 0;
            this.uctrTestInfo1.TestAppointmentID = -1;
            // 
            // TestInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 589);
            this.Controls.Add(this.uctrTestInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "TestInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TestInfo";
            this.ResumeLayout(false);

        }

        #endregion

        private Vison_Test.uctrTestInfo uctrTestInfo1;
    }
}