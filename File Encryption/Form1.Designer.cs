
namespace File_Encryption
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
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.txtLocalEncryptFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNewEncryptFile = new System.Windows.Forms.TextBox();
            this.txtLocalDecryptFile = new System.Windows.Forms.TextBox();
            this.txtNewDecryptFile = new System.Windows.Forms.TextBox();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(565, 21);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(101, 60);
            this.btnEncrypt.TabIndex = 0;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // txtLocalEncryptFile
            // 
            this.txtLocalEncryptFile.Location = new System.Drawing.Point(93, 21);
            this.txtLocalEncryptFile.Name = "txtLocalEncryptFile";
            this.txtLocalEncryptFile.Size = new System.Drawing.Size(455, 22);
            this.txtLocalEncryptFile.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Local file:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "New file:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Local file:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "New file:";
            // 
            // txtNewEncryptFile
            // 
            this.txtNewEncryptFile.Location = new System.Drawing.Point(93, 59);
            this.txtNewEncryptFile.Name = "txtNewEncryptFile";
            this.txtNewEncryptFile.Size = new System.Drawing.Size(455, 22);
            this.txtNewEncryptFile.TabIndex = 6;
            // 
            // txtLocalDecryptFile
            // 
            this.txtLocalDecryptFile.Location = new System.Drawing.Point(93, 96);
            this.txtLocalDecryptFile.Name = "txtLocalDecryptFile";
            this.txtLocalDecryptFile.Size = new System.Drawing.Size(455, 22);
            this.txtLocalDecryptFile.TabIndex = 7;
            // 
            // txtNewDecryptFile
            // 
            this.txtNewDecryptFile.Location = new System.Drawing.Point(93, 133);
            this.txtNewDecryptFile.Name = "txtNewDecryptFile";
            this.txtNewDecryptFile.Size = new System.Drawing.Size(455, 22);
            this.txtNewDecryptFile.TabIndex = 8;
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(565, 96);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(101, 60);
            this.btnDecrypt.TabIndex = 9;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 181);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.txtNewDecryptFile);
            this.Controls.Add(this.txtLocalDecryptFile);
            this.Controls.Add(this.txtNewEncryptFile);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLocalEncryptFile);
            this.Controls.Add(this.btnEncrypt);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.TextBox txtLocalEncryptFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNewEncryptFile;
        private System.Windows.Forms.TextBox txtLocalDecryptFile;
        private System.Windows.Forms.TextBox txtNewDecryptFile;
        private System.Windows.Forms.Button btnDecrypt;
    }
}

