namespace ContohSoal1
{
    partial class Form1Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1Login));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblUsn = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lblDaftar = new System.Windows.Forms.Label();
            this.lblBlumPunya = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(172, 243);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(243, 20);
            this.textBox1.TabIndex = 0;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(340, 295);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblUsn
            // 
            this.lblUsn.AutoSize = true;
            this.lblUsn.Location = new System.Drawing.Point(100, 243);
            this.lblUsn.Name = "lblUsn";
            this.lblUsn.Size = new System.Drawing.Size(55, 13);
            this.lblUsn.TabIndex = 2;
            this.lblUsn.Text = "Username";
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(100, 269);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(53, 13);
            this.lblPass.TabIndex = 4;
            this.lblPass.Text = "Password";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(172, 269);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.Size = new System.Drawing.Size(243, 20);
            this.textBox2.TabIndex = 3;
            // 
            // lblDaftar
            // 
            this.lblDaftar.AutoSize = true;
            this.lblDaftar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDaftar.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblDaftar.Location = new System.Drawing.Point(281, 332);
            this.lblDaftar.Name = "lblDaftar";
            this.lblDaftar.Size = new System.Drawing.Size(88, 13);
            this.lblDaftar.TabIndex = 7;
            this.lblDaftar.Text = "Daftar Sekarang!";
            this.lblDaftar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDaftar.Click += new System.EventHandler(this.lblDaftar_Click);
            // 
            // lblBlumPunya
            // 
            this.lblBlumPunya.AutoSize = true;
            this.lblBlumPunya.Location = new System.Drawing.Point(152, 332);
            this.lblBlumPunya.Name = "lblBlumPunya";
            this.lblBlumPunya.Size = new System.Drawing.Size(103, 13);
            this.lblBlumPunya.TabIndex = 8;
            this.lblBlumPunya.Text = "Belum Punya Akun?";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ContohSoal1.Properties.Resources.airplane_logo_template_airplane_logo_elements_airplane_logo_icon_vector;
            this.pictureBox1.Location = new System.Drawing.Point(83, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(355, 186);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // Form1Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 401);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblBlumPunya);
            this.Controls.Add(this.lblDaftar);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.lblUsn);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Roberth Airlines - Login";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblUsn;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lblDaftar;
        private System.Windows.Forms.Label lblBlumPunya;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
