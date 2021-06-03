namespace Assignment3
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
            this.messagebox = new System.Windows.Forms.ListBox();
            this.yourmessage = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.usersnames = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // messagebox
            // 
            this.messagebox.FormattingEnabled = true;
            this.messagebox.ItemHeight = 16;
            this.messagebox.Location = new System.Drawing.Point(12, 29);
            this.messagebox.Name = "messagebox";
            this.messagebox.ScrollAlwaysVisible = true;
            this.messagebox.Size = new System.Drawing.Size(567, 196);
            this.messagebox.TabIndex = 0;
            // 
            // yourmessage
            // 
            this.yourmessage.AccessibleDescription = "";
            this.yourmessage.AccessibleName = "";
            this.yourmessage.Location = new System.Drawing.Point(12, 251);
            this.yourmessage.Multiline = true;
            this.yourmessage.Name = "yourmessage";
            this.yourmessage.Size = new System.Drawing.Size(567, 192);
            this.yourmessage.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 465);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 33);
            this.button1.TabIndex = 2;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(639, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 26);
            this.label2.TabIndex = 4;
            this.label2.Text = "Users:";
            // 
            // usersnames
            // 
            this.usersnames.FormattingEnabled = true;
            this.usersnames.ItemHeight = 16;
            this.usersnames.Location = new System.Drawing.Point(644, 58);
            this.usersnames.Name = "usersnames";
            this.usersnames.Size = new System.Drawing.Size(220, 260);
            this.usersnames.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 510);
            this.Controls.Add(this.usersnames);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.yourmessage);
            this.Controls.Add(this.messagebox);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox messagebox;
        private System.Windows.Forms.TextBox yourmessage;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox usersnames;
    }
}

