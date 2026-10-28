namespace ContohSoal1
{
    partial class Form10ListPenerbangan
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
            this.applyBtn = new System.Windows.Forms.Button();
            this.departureLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.destinationLabel = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.passengerLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.sortBox = new System.Windows.Forms.ComboBox();
            this.timeCheck1 = new System.Windows.Forms.CheckBox();
            this.timeCheck2 = new System.Windows.Forms.CheckBox();
            this.timeCheck3 = new System.Windows.Forms.CheckBox();
            this.timeCheck4 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridPenerbangan = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodePenerbangan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Maskapai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BandaraKeberangkatan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BandaraTujuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HargaPerTiket = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Jam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BeliTiket = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPenerbangan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // applyBtn
            // 
            this.applyBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.applyBtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applyBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.applyBtn.Location = new System.Drawing.Point(808, 165);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Size = new System.Drawing.Size(213, 44);
            this.applyBtn.TabIndex = 9;
            this.applyBtn.Text = "Terapkan Filter";
            this.applyBtn.UseVisualStyleBackColor = true;
            this.applyBtn.Click += new System.EventHandler(this.applyBtn_Click);
            // 
            // departureLabel
            // 
            this.departureLabel.AutoSize = true;
            this.departureLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.departureLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.departureLabel.Location = new System.Drawing.Point(92, 86);
            this.departureLabel.Name = "departureLabel";
            this.departureLabel.Size = new System.Drawing.Size(185, 25);
            this.departureLabel.TabIndex = 7;
            this.departureLabel.Text = "Soekarno-Hatta (CGK)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(89, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(327, 48);
            this.label3.TabIndex = 8;
            this.label3.Text = "List Penerbangan";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(22, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 28);
            this.label1.TabIndex = 7;
            this.label1.Text = "Urutkan Berdasarkan";
            // 
            // destinationLabel
            // 
            this.destinationLabel.AutoSize = true;
            this.destinationLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.destinationLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.destinationLabel.Location = new System.Drawing.Point(316, 86);
            this.destinationLabel.Name = "destinationLabel";
            this.destinationLabel.Size = new System.Drawing.Size(185, 25);
            this.destinationLabel.TabIndex = 7;
            this.destinationLabel.Text = "Soekarno-Hatta (CGK)";
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dateLabel.Location = new System.Drawing.Point(549, 86);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(195, 25);
            this.dateLabel.TabIndex = 7;
            this.dateLabel.Text = "Saturday, 24 May 2023";
            // 
            // passengerLabel
            // 
            this.passengerLabel.AutoSize = true;
            this.passengerLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passengerLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.passengerLabel.Location = new System.Drawing.Point(801, 86);
            this.passengerLabel.Name = "passengerLabel";
            this.passengerLabel.Size = new System.Drawing.Size(122, 25);
            this.passengerLabel.TabIndex = 7;
            this.passengerLabel.Text = "1 Penumpang";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(22, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(205, 28);
            this.label7.TabIndex = 7;
            this.label7.Text = "Waktu Keberangkatan";
            // 
            // sortBox
            // 
            this.sortBox.BackColor = System.Drawing.SystemColors.Window;
            this.sortBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sortBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.sortBox.FormattingEnabled = true;
            this.sortBox.Items.AddRange(new object[] {
            "Harga terendah",
            "Keberangkatan paling awal",
            "Keberangkatan paling akhir",
            "Kedatangan paling awal",
            "Kedatangan paling akhir",
            "Durasi tercepat"});
            this.sortBox.Location = new System.Drawing.Point(27, 173);
            this.sortBox.Name = "sortBox";
            this.sortBox.Size = new System.Drawing.Size(262, 36);
            this.sortBox.TabIndex = 11;
            // 
            // timeCheck1
            // 
            this.timeCheck1.AutoSize = true;
            this.timeCheck1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeCheck1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.timeCheck1.Location = new System.Drawing.Point(27, 85);
            this.timeCheck1.Name = "timeCheck1";
            this.timeCheck1.Size = new System.Drawing.Size(128, 25);
            this.timeCheck1.TabIndex = 12;
            this.timeCheck1.Text = "00:00 - 06:00";
            this.timeCheck1.UseVisualStyleBackColor = true;
            // 
            // timeCheck2
            // 
            this.timeCheck2.AutoSize = true;
            this.timeCheck2.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeCheck2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.timeCheck2.Location = new System.Drawing.Point(177, 85);
            this.timeCheck2.Name = "timeCheck2";
            this.timeCheck2.Size = new System.Drawing.Size(128, 25);
            this.timeCheck2.TabIndex = 12;
            this.timeCheck2.Text = "06:00 - 12:00";
            this.timeCheck2.UseVisualStyleBackColor = true;
            // 
            // timeCheck3
            // 
            this.timeCheck3.AutoSize = true;
            this.timeCheck3.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeCheck3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.timeCheck3.Location = new System.Drawing.Point(324, 85);
            this.timeCheck3.Name = "timeCheck3";
            this.timeCheck3.Size = new System.Drawing.Size(128, 25);
            this.timeCheck3.TabIndex = 12;
            this.timeCheck3.Text = "12:00 - 18:00";
            this.timeCheck3.UseVisualStyleBackColor = true;
            // 
            // timeCheck4
            // 
            this.timeCheck4.AutoSize = true;
            this.timeCheck4.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeCheck4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.timeCheck4.Location = new System.Drawing.Point(472, 85);
            this.timeCheck4.Name = "timeCheck4";
            this.timeCheck4.Size = new System.Drawing.Size(128, 25);
            this.timeCheck4.TabIndex = 12;
            this.timeCheck4.Text = "18:00 - 24:00";
            this.timeCheck4.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridPenerbangan);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.sortBox);
            this.groupBox1.Controls.Add(this.applyBtn);
            this.groupBox1.Controls.Add(this.timeCheck4);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.timeCheck3);
            this.groupBox1.Controls.Add(this.timeCheck1);
            this.groupBox1.Controls.Add(this.timeCheck2);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(25, 172);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1043, 506);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // dataGridPenerbangan
            // 
            this.dataGridPenerbangan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPenerbangan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.KodePenerbangan,
            this.Maskapai,
            this.BandaraKeberangkatan,
            this.BandaraTujuan,
            this.HargaPerTiket,
            this.Tanggal,
            this.Jam,
            this.BeliTiket});
            this.dataGridPenerbangan.Location = new System.Drawing.Point(27, 217);
            this.dataGridPenerbangan.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridPenerbangan.Name = "dataGridPenerbangan";
            this.dataGridPenerbangan.RowHeadersWidth = 62;
            this.dataGridPenerbangan.Size = new System.Drawing.Size(994, 272);
            this.dataGridPenerbangan.TabIndex = 13;
            this.dataGridPenerbangan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridPenerbangan_CellClick);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 8;
            this.ID.Name = "ID";
            this.ID.Width = 150;
            // 
            // KodePenerbangan
            // 
            this.KodePenerbangan.DataPropertyName = "KodePenerbangan";
            this.KodePenerbangan.HeaderText = "Kode Penerbangan";
            this.KodePenerbangan.MinimumWidth = 8;
            this.KodePenerbangan.Name = "KodePenerbangan";
            this.KodePenerbangan.Width = 150;
            // 
            // Maskapai
            // 
            this.Maskapai.DataPropertyName = "Maskapai";
            this.Maskapai.HeaderText = "Maskapai";
            this.Maskapai.MinimumWidth = 8;
            this.Maskapai.Name = "Maskapai";
            this.Maskapai.Width = 150;
            // 
            // BandaraKeberangkatan
            // 
            this.BandaraKeberangkatan.DataPropertyName = "BandaraKeberangkatan";
            this.BandaraKeberangkatan.HeaderText = "Bandara Keberangkatan";
            this.BandaraKeberangkatan.MinimumWidth = 8;
            this.BandaraKeberangkatan.Name = "BandaraKeberangkatan";
            this.BandaraKeberangkatan.Width = 150;
            // 
            // BandaraTujuan
            // 
            this.BandaraTujuan.DataPropertyName = "BandaraTujuan";
            this.BandaraTujuan.HeaderText = "Bandara Tujuan";
            this.BandaraTujuan.MinimumWidth = 8;
            this.BandaraTujuan.Name = "BandaraTujuan";
            this.BandaraTujuan.Width = 150;
            // 
            // HargaPerTiket
            // 
            this.HargaPerTiket.DataPropertyName = "HargaPerTiket";
            this.HargaPerTiket.HeaderText = "Harga";
            this.HargaPerTiket.MinimumWidth = 8;
            this.HargaPerTiket.Name = "HargaPerTiket";
            this.HargaPerTiket.Width = 150;
            // 
            // Tanggal
            // 
            this.Tanggal.DataPropertyName = "Tanggal";
            this.Tanggal.HeaderText = "Tanggal";
            this.Tanggal.MinimumWidth = 8;
            this.Tanggal.Name = "Tanggal";
            this.Tanggal.Width = 150;
            // 
            // Jam
            // 
            this.Jam.DataPropertyName = "Jam";
            this.Jam.HeaderText = "Jam Berangkat";
            this.Jam.MinimumWidth = 8;
            this.Jam.Name = "Jam";
            this.Jam.Width = 150;
            // 
            // BeliTiket
            // 
            this.BeliTiket.HeaderText = "";
            this.BeliTiket.MinimumWidth = 8;
            this.BeliTiket.Name = "BeliTiket";
            this.BeliTiket.Text = "Beli Tiket";
            this.BeliTiket.UseColumnTextForButtonValue = true;
            this.BeliTiket.Width = 150;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::ContohSoal1.Properties.Resources.multiple_man_woman;
            this.pictureBox3.Location = new System.Drawing.Point(770, 86);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(25, 25);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 10;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::ContohSoal1.Properties.Resources.calendar_date_mark_circle;
            this.pictureBox2.Location = new System.Drawing.Point(518, 86);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(25, 25);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ContohSoal1.Properties.Resources.arrow_right1;
            this.pictureBox1.Location = new System.Drawing.Point(282, 86);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::ContohSoal1.Properties.Resources.chevron_arrow_left;
            this.pictureBox7.Location = new System.Drawing.Point(25, 27);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(50, 50);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 10;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.Click += new System.EventHandler(this.pictureBox7_Click);
            // 
            // Form10ListPenerbangan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1094, 700);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.passengerLabel);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.destinationLabel);
            this.Controls.Add(this.departureLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form10ListPenerbangan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form10ListPenerbangan";
            this.Load += new System.EventHandler(this.Form10ListPenerbangan_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPenerbangan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button applyBtn;
        private System.Windows.Forms.Label departureLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label destinationLabel;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label passengerLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox sortBox;
        private System.Windows.Forms.CheckBox timeCheck1;
        private System.Windows.Forms.CheckBox timeCheck2;
        private System.Windows.Forms.CheckBox timeCheck3;
        private System.Windows.Forms.CheckBox timeCheck4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.DataGridView dataGridPenerbangan;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodePenerbangan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Maskapai;
        private System.Windows.Forms.DataGridViewTextBoxColumn BandaraKeberangkatan;
        private System.Windows.Forms.DataGridViewTextBoxColumn BandaraTujuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn HargaPerTiket;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tanggal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jam;
        private System.Windows.Forms.DataGridViewButtonColumn BeliTiket;
    }
}