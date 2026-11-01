namespace ContohSoal1
{
    partial class PenumpangControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.numberLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.titleBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.fullNameText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // numberLabel
            // 
            this.numberLabel.AutoSize = true;
            this.numberLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.numberLabel.Location = new System.Drawing.Point(15, 14);
            this.numberLabel.Name = "numberLabel";
            this.numberLabel.Size = new System.Drawing.Size(169, 30);
            this.numberLabel.TabIndex = 0;
            this.numberLabel.Text = "Penumpang #1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(15, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 28);
            this.label2.TabIndex = 0;
            this.label2.Text = "Titel";
            // 
            // titleBox
            // 
            this.titleBox.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.titleBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.titleBox.FormattingEnabled = true;
            this.titleBox.Items.AddRange(new object[] {
            "Tuan",
            "Nyonya"});
            this.titleBox.Location = new System.Drawing.Point(164, 62);
            this.titleBox.Name = "titleBox";
            this.titleBox.Size = new System.Drawing.Size(196, 36);
            this.titleBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(15, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 28);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nama Lengkap";
            // 
            // fullNameText
            // 
            this.fullNameText.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.fullNameText.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fullNameText.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.fullNameText.Location = new System.Drawing.Point(164, 115);
            this.fullNameText.Name = "fullNameText";
            this.fullNameText.Size = new System.Drawing.Size(519, 34);
            this.fullNameText.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semilight", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label4.Location = new System.Drawing.Point(160, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(386, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "Isi sesuai KTP/Paspor/SIM (tanpa tanda baca dan gelar)";
            // 
            // PenumpangControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.Controls.Add(this.titleBox);
            this.Controls.Add(this.fullNameText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numberLabel);
            this.Name = "PenumpangControl";
            this.Size = new System.Drawing.Size(712, 194);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label numberLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox titleBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox fullNameText;
        private System.Windows.Forms.Label label4;
    }
}
