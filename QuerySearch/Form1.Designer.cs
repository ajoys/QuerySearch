namespace QuerySearch
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.datepick = new System.Windows.Forms.MonthCalendar();
            this.dropBox = new System.Windows.Forms.ComboBox();
            this.submit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Raw = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Tally = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pick a Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 280);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Pick a Lane:";
            // 
            // datepick
            // 
            this.datepick.Location = new System.Drawing.Point(79, 19);
            this.datepick.MaxSelectionCount = 1;
            this.datepick.Name = "datepick";
            this.datepick.ShowToday = false;
            this.datepick.TabIndex = 2;
            // 
            // dropBox
            // 
            this.dropBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.dropBox.FormattingEnabled = true;
            this.dropBox.Items.AddRange(new object[] {
            "2230",
            "0345",
            "0630",
            "1130",
            "1430",
            "1930",
            "2130",
            "All"});
            this.dropBox.Location = new System.Drawing.Point(129, 272);
            this.dropBox.Name = "dropBox";
            this.dropBox.Size = new System.Drawing.Size(121, 21);
            this.dropBox.TabIndex = 3;
            // 
            // submit
            // 
            this.submit.Location = new System.Drawing.Point(129, 323);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(110, 23);
            this.submit.TabIndex = 4;
            this.submit.Text = "Submit Query";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(144, 374);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 5;
            // 
            // Raw
            // 
            this.Raw.AutoSize = true;
            this.Raw.Checked = true;
            this.Raw.Location = new System.Drawing.Point(6, 19);
            this.Raw.Name = "Raw";
            this.Raw.Size = new System.Drawing.Size(73, 17);
            this.Raw.TabIndex = 6;
            this.Raw.TabStop = true;
            this.Raw.Text = "Raw Data";
            this.Raw.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Tally);
            this.groupBox1.Controls.Add(this.Raw);
            this.groupBox1.Location = new System.Drawing.Point(73, 193);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(233, 58);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pick a Form Type";
            // 
            // Tally
            // 
            this.Tally.AutoSize = true;
            this.Tally.Location = new System.Drawing.Point(111, 19);
            this.Tally.Name = "Tally";
            this.Tally.Size = new System.Drawing.Size(73, 17);
            this.Tally.TabIndex = 7;
            this.Tally.TabStop = true;
            this.Tally.Text = "Tally Data";
            this.Tally.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 395);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.submit);
            this.Controls.Add(this.dropBox);
            this.Controls.Add(this.datepick);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Search Lanes";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox dropBox;
        private System.Windows.Forms.Button submit;
        internal System.Windows.Forms.MonthCalendar datepick;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton Raw;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton Tally;
    }
}

