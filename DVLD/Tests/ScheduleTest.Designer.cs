namespace DVLD.Tests.Vison_Test
{
    partial class ScheduleTest
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
            this.uctrlScheduleTest1 = new DVLD.Tests.uctrlScheduleTest();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uctrlScheduleTest1
            // 
            this.uctrlScheduleTest1.BackColor = System.Drawing.Color.White;
            this.uctrlScheduleTest1.DLAppID = -1;
            this.uctrlScheduleTest1.Location = new System.Drawing.Point(1, 1);
            this.uctrlScheduleTest1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uctrlScheduleTest1.Name = "uctrlScheduleTest1";
            this.uctrlScheduleTest1.Size = new System.Drawing.Size(408, 544);
            this.uctrlScheduleTest1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD.Properties.Resources.Close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(164, 547);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 33);
            this.btnClose.TabIndex = 25;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ScheduleTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(408, 587);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.uctrlScheduleTest1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ScheduleTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ScheduleTest";
            this.ResumeLayout(false);

        }

        #endregion

        private uctrlScheduleTest uctrlScheduleTest1;
        private System.Windows.Forms.Button btnClose;
    }
}