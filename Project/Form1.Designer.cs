namespace PG3D_CryptoPrefsGen2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Decrypt = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.DecryptValueIn = new System.Windows.Forms.TextBox();
            this.DecryptKeyIn = new System.Windows.Forms.TextBox();
            this.DecryptValueOut = new System.Windows.Forms.TextBox();
            this.DecryptKeyOut = new System.Windows.Forms.TextBox();
            this.FullTextDec = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Encrypt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.EncryptValueIn = new System.Windows.Forms.TextBox();
            this.EncryptKeyIn = new System.Windows.Forms.TextBox();
            this.EncryptValueOut = new System.Windows.Forms.TextBox();
            this.EncryptKeyOut = new System.Windows.Forms.TextBox();
            this.FullTextEnc = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.OldEnc = new System.Windows.Forms.TabControl();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.OldEnc.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.FullTextDec);
            this.tabPage2.Controls.Add(this.DecryptKeyOut);
            this.tabPage2.Controls.Add(this.DecryptValueOut);
            this.tabPage2.Controls.Add(this.DecryptKeyIn);
            this.tabPage2.Controls.Add(this.DecryptValueIn);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.Decrypt);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(793, 832);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Decrypt";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Decrypt
            // 
            this.Decrypt.Location = new System.Drawing.Point(8, 282);
            this.Decrypt.Name = "Decrypt";
            this.Decrypt.Size = new System.Drawing.Size(777, 121);
            this.Decrypt.TabIndex = 9;
            this.Decrypt.Text = "Decrypt";
            this.Decrypt.UseVisualStyleBackColor = true;
            this.Decrypt.Click += new System.EventHandler(this.Decrypt_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 17);
            this.label8.TabIndex = 11;
            this.label8.Text = "Value:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "Key:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 501);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 17);
            this.label6.TabIndex = 15;
            this.label6.Text = "Value:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 413);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 17);
            this.label5.TabIndex = 16;
            this.label5.Text = "Key:";
            // 
            // DecryptValueIn
            // 
            this.DecryptValueIn.Location = new System.Drawing.Point(62, 95);
            this.DecryptValueIn.MaxLength = 65535;
            this.DecryptValueIn.Multiline = true;
            this.DecryptValueIn.Name = "DecryptValueIn";
            this.DecryptValueIn.Size = new System.Drawing.Size(723, 166);
            this.DecryptValueIn.TabIndex = 10;
            // 
            // DecryptKeyIn
            // 
            this.DecryptKeyIn.Location = new System.Drawing.Point(62, 10);
            this.DecryptKeyIn.Multiline = true;
            this.DecryptKeyIn.Name = "DecryptKeyIn";
            this.DecryptKeyIn.Size = new System.Drawing.Size(723, 79);
            this.DecryptKeyIn.TabIndex = 13;
            // 
            // DecryptValueOut
            // 
            this.DecryptValueOut.Location = new System.Drawing.Point(62, 498);
            this.DecryptValueOut.MaxLength = 65535;
            this.DecryptValueOut.Multiline = true;
            this.DecryptValueOut.Name = "DecryptValueOut";
            this.DecryptValueOut.Size = new System.Drawing.Size(723, 166);
            this.DecryptValueOut.TabIndex = 14;
            // 
            // DecryptKeyOut
            // 
            this.DecryptKeyOut.Location = new System.Drawing.Point(62, 413);
            this.DecryptKeyOut.Multiline = true;
            this.DecryptKeyOut.Name = "DecryptKeyOut";
            this.DecryptKeyOut.Size = new System.Drawing.Size(723, 79);
            this.DecryptKeyOut.TabIndex = 17;
            // 
            // FullTextDec
            // 
            this.FullTextDec.Location = new System.Drawing.Point(62, 671);
            this.FullTextDec.MaxLength = 65535;
            this.FullTextDec.Multiline = true;
            this.FullTextDec.Name = "FullTextDec";
            this.FullTextDec.Size = new System.Drawing.Size(723, 153);
            this.FullTextDec.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 671);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 17);
            this.label10.TabIndex = 19;
            this.label10.Text = "Full:";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.FullTextEnc);
            this.tabPage1.Controls.Add(this.EncryptKeyOut);
            this.tabPage1.Controls.Add(this.EncryptValueOut);
            this.tabPage1.Controls.Add(this.EncryptKeyIn);
            this.tabPage1.Controls.Add(this.EncryptValueIn);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.Encrypt);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(793, 832);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Encrypt";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // Encrypt
            // 
            this.Encrypt.Location = new System.Drawing.Point(8, 283);
            this.Encrypt.Name = "Encrypt";
            this.Encrypt.Size = new System.Drawing.Size(777, 121);
            this.Encrypt.TabIndex = 0;
            this.Encrypt.Text = "Encrypt";
            this.Encrypt.UseVisualStyleBackColor = true;
            this.Encrypt.Click += new System.EventHandler(this.Encrypt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Value:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Key:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 502);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Value:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 414);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Key:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // EncryptValueIn
            // 
            this.EncryptValueIn.Location = new System.Drawing.Point(62, 96);
            this.EncryptValueIn.MaxLength = 65535;
            this.EncryptValueIn.Multiline = true;
            this.EncryptValueIn.Name = "EncryptValueIn";
            this.EncryptValueIn.Size = new System.Drawing.Size(723, 166);
            this.EncryptValueIn.TabIndex = 1;
            this.EncryptValueIn.TextChanged += new System.EventHandler(this.EncryptValueIn_TextChanged);
            // 
            // EncryptKeyIn
            // 
            this.EncryptKeyIn.Location = new System.Drawing.Point(62, 11);
            this.EncryptKeyIn.Multiline = true;
            this.EncryptKeyIn.Name = "EncryptKeyIn";
            this.EncryptKeyIn.Size = new System.Drawing.Size(723, 79);
            this.EncryptKeyIn.TabIndex = 4;
            this.EncryptKeyIn.TextChanged += new System.EventHandler(this.EncryptKeyIn_TextChanged);
            // 
            // EncryptValueOut
            // 
            this.EncryptValueOut.Location = new System.Drawing.Point(62, 499);
            this.EncryptValueOut.MaxLength = 65535;
            this.EncryptValueOut.Multiline = true;
            this.EncryptValueOut.Name = "EncryptValueOut";
            this.EncryptValueOut.Size = new System.Drawing.Size(723, 166);
            this.EncryptValueOut.TabIndex = 5;
            this.EncryptValueOut.TextChanged += new System.EventHandler(this.EncryptValueOut_TextChanged);
            // 
            // EncryptKeyOut
            // 
            this.EncryptKeyOut.Location = new System.Drawing.Point(62, 414);
            this.EncryptKeyOut.Multiline = true;
            this.EncryptKeyOut.Name = "EncryptKeyOut";
            this.EncryptKeyOut.Size = new System.Drawing.Size(723, 79);
            this.EncryptKeyOut.TabIndex = 8;
            this.EncryptKeyOut.TextChanged += new System.EventHandler(this.EncryptKeyOut_TextChanged);
            // 
            // FullTextEnc
            // 
            this.FullTextEnc.Location = new System.Drawing.Point(62, 671);
            this.FullTextEnc.MaxLength = 65535;
            this.FullTextEnc.Multiline = true;
            this.FullTextEnc.Name = "FullTextEnc";
            this.FullTextEnc.Size = new System.Drawing.Size(723, 153);
            this.FullTextEnc.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 671);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 17);
            this.label9.TabIndex = 10;
            this.label9.Text = "Full:";
            // 
            // OldEnc
            // 
            this.OldEnc.Controls.Add(this.tabPage1);
            this.OldEnc.Controls.Add(this.tabPage2);
            this.OldEnc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OldEnc.Location = new System.Drawing.Point(0, 0);
            this.OldEnc.Name = "OldEnc";
            this.OldEnc.SelectedIndex = 0;
            this.OldEnc.Size = new System.Drawing.Size(801, 861);
            this.OldEnc.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 861);
            this.Controls.Add(this.OldEnc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "PG3D-CryptoPlayerPrefsCreator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.OldEnc.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox FullTextDec;
        private System.Windows.Forms.TextBox DecryptKeyOut;
        private System.Windows.Forms.TextBox DecryptValueOut;
        private System.Windows.Forms.TextBox DecryptKeyIn;
        private System.Windows.Forms.TextBox DecryptValueIn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button Decrypt;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox FullTextEnc;
        private System.Windows.Forms.TextBox EncryptKeyOut;
        private System.Windows.Forms.TextBox EncryptValueOut;
        private System.Windows.Forms.TextBox EncryptKeyIn;
        private System.Windows.Forms.TextBox EncryptValueIn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Encrypt;
        private System.Windows.Forms.TabControl OldEnc;
    }
}

