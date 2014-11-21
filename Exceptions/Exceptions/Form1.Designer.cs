namespace Exceptions
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
            this.postcodeTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.emailTextbox = new System.Windows.Forms.TextBox();
            this.telephoneTextbox = new System.Windows.Forms.TextBox();
            this.exceptionTextbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // postcodeTextbox
            // 
            this.postcodeTextbox.Location = new System.Drawing.Point(109, 23);
            this.postcodeTextbox.Name = "postcodeTextbox";
            this.postcodeTextbox.Size = new System.Drawing.Size(130, 20);
            this.postcodeTextbox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Postcode";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "E-Mail";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Telefoon";
            // 
            // emailTextbox
            // 
            this.emailTextbox.Location = new System.Drawing.Point(109, 64);
            this.emailTextbox.Name = "emailTextbox";
            this.emailTextbox.Size = new System.Drawing.Size(130, 20);
            this.emailTextbox.TabIndex = 4;
            // 
            // telephoneTextbox
            // 
            this.telephoneTextbox.Location = new System.Drawing.Point(109, 108);
            this.telephoneTextbox.Name = "telephoneTextbox";
            this.telephoneTextbox.Size = new System.Drawing.Size(130, 20);
            this.telephoneTextbox.TabIndex = 5;
            // 
            // exceptionTextbox
            // 
            this.exceptionTextbox.Location = new System.Drawing.Point(109, 159);
            this.exceptionTextbox.Multiline = true;
            this.exceptionTextbox.Name = "exceptionTextbox";
            this.exceptionTextbox.Size = new System.Drawing.Size(314, 193);
            this.exceptionTextbox.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "ExceptionText";
            // 
            // checkButton
            // 
            this.checkButton.Location = new System.Drawing.Point(109, 358);
            this.checkButton.Name = "checkButton";
            this.checkButton.Size = new System.Drawing.Size(130, 73);
            this.checkButton.TabIndex = 8;
            this.checkButton.Text = "Check invoer";
            this.checkButton.UseVisualStyleBackColor = true;
            this.checkButton.Click += new System.EventHandler(this.checkButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 443);
            this.Controls.Add(this.checkButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.exceptionTextbox);
            this.Controls.Add(this.telephoneTextbox);
            this.Controls.Add(this.emailTextbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.postcodeTextbox);
            this.Name = "Form1";
            this.Text = "Exceptions";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox postcodeTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox emailTextbox;
        private System.Windows.Forms.TextBox telephoneTextbox;
        private System.Windows.Forms.TextBox exceptionTextbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button checkButton;
    }
}

