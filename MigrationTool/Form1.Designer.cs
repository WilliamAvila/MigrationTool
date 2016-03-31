namespace MigrationTool
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxUserSource = new System.Windows.Forms.TextBox();
            this.textBoxPasswordSource = new System.Windows.Forms.TextBox();
            this.textBoxServerSouce = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPortSource = new System.Windows.Forms.TextBox();
            this.textBoxPortDest = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxServerDest = new System.Windows.Forms.TextBox();
            this.textBoxPasswordDest = new System.Windows.Forms.TextBox();
            this.textBoxUserDest = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.buttonTestSource = new System.Windows.Forms.Button();
            this.buttonTestDest = new System.Windows.Forms.Button();
            this.labelTestSource = new System.Windows.Forms.Label();
            this.labelTestDest = new System.Windows.Forms.Label();
            this.comboBoxDatabaseSource = new System.Windows.Forms.ComboBox();
            this.comboBoxDatabaseDestination = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.labelSuccessMigration = new System.Windows.Forms.Label();
            this.labelDBNameSrc = new System.Windows.Forms.Label();
            this.textBoxDBNameSrc = new System.Windows.Forms.TextBox();
            this.textBoxDBNameDest = new System.Windows.Forms.TextBox();
            this.labelDBNameDest = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(217, 352);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Migrate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxUserSource
            // 
            this.textBoxUserSource.Location = new System.Drawing.Point(87, 91);
            this.textBoxUserSource.Name = "textBoxUserSource";
            this.textBoxUserSource.Size = new System.Drawing.Size(100, 20);
            this.textBoxUserSource.TabIndex = 2;
            // 
            // textBoxPasswordSource
            // 
            this.textBoxPasswordSource.Location = new System.Drawing.Point(87, 131);
            this.textBoxPasswordSource.Name = "textBoxPasswordSource";
            this.textBoxPasswordSource.Size = new System.Drawing.Size(100, 20);
            this.textBoxPasswordSource.TabIndex = 3;
            this.textBoxPasswordSource.UseSystemPasswordChar = true;
            // 
            // textBoxServerSouce
            // 
            this.textBoxServerSouce.Location = new System.Drawing.Point(86, 176);
            this.textBoxServerSouce.Name = "textBoxServerSouce";
            this.textBoxServerSouce.Size = new System.Drawing.Size(100, 20);
            this.textBoxServerSouce.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "User";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Server";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 223);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Port";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // textBoxPortSource
            // 
            this.textBoxPortSource.Location = new System.Drawing.Point(87, 223);
            this.textBoxPortSource.Name = "textBoxPortSource";
            this.textBoxPortSource.Size = new System.Drawing.Size(51, 20);
            this.textBoxPortSource.TabIndex = 5;
            // 
            // textBoxPortDest
            // 
            this.textBoxPortDest.Location = new System.Drawing.Point(413, 223);
            this.textBoxPortDest.Name = "textBoxPortDest";
            this.textBoxPortDest.Size = new System.Drawing.Size(51, 20);
            this.textBoxPortDest.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(338, 223);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Port";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(335, 182);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Server";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(335, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Password";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(338, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "User";
            // 
            // textBoxServerDest
            // 
            this.textBoxServerDest.Location = new System.Drawing.Point(412, 176);
            this.textBoxServerDest.Name = "textBoxServerDest";
            this.textBoxServerDest.Size = new System.Drawing.Size(100, 20);
            this.textBoxServerDest.TabIndex = 11;
            // 
            // textBoxPasswordDest
            // 
            this.textBoxPasswordDest.Location = new System.Drawing.Point(413, 131);
            this.textBoxPasswordDest.Name = "textBoxPasswordDest";
            this.textBoxPasswordDest.Size = new System.Drawing.Size(100, 20);
            this.textBoxPasswordDest.TabIndex = 10;
            this.textBoxPasswordDest.UseSystemPasswordChar = true;
            // 
            // textBoxUserDest
            // 
            this.textBoxUserDest.Location = new System.Drawing.Point(413, 91);
            this.textBoxUserDest.Name = "textBoxUserDest";
            this.textBoxUserDest.Size = new System.Drawing.Size(100, 20);
            this.textBoxUserDest.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(93, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 20);
            this.label9.TabIndex = 28;
            this.label9.Text = "Source";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(400, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 20);
            this.label10.TabIndex = 29;
            this.label10.Text = "Destination";
            // 
            // buttonTestSource
            // 
            this.buttonTestSource.Location = new System.Drawing.Point(15, 275);
            this.buttonTestSource.Name = "buttonTestSource";
            this.buttonTestSource.Size = new System.Drawing.Size(97, 23);
            this.buttonTestSource.TabIndex = 7;
            this.buttonTestSource.Text = "Test Connection";
            this.buttonTestSource.UseVisualStyleBackColor = true;
            this.buttonTestSource.Click += new System.EventHandler(this.buttonTestSource_Click);
            // 
            // buttonTestDest
            // 
            this.buttonTestDest.Location = new System.Drawing.Point(338, 275);
            this.buttonTestDest.Name = "buttonTestDest";
            this.buttonTestDest.Size = new System.Drawing.Size(98, 23);
            this.buttonTestDest.TabIndex = 14;
            this.buttonTestDest.Text = "Test Connection";
            this.buttonTestDest.UseVisualStyleBackColor = true;
            this.buttonTestDest.Click += new System.EventHandler(this.buttonTestDest_Click);
            // 
            // labelTestSource
            // 
            this.labelTestSource.AutoSize = true;
            this.labelTestSource.Location = new System.Drawing.Point(133, 284);
            this.labelTestSource.Name = "labelTestSource";
            this.labelTestSource.Size = new System.Drawing.Size(0, 13);
            this.labelTestSource.TabIndex = 22;
            // 
            // labelTestDest
            // 
            this.labelTestDest.AutoSize = true;
            this.labelTestDest.Location = new System.Drawing.Point(459, 284);
            this.labelTestDest.Name = "labelTestDest";
            this.labelTestDest.Size = new System.Drawing.Size(0, 13);
            this.labelTestDest.TabIndex = 23;
            // 
            // comboBoxDatabaseSource
            // 
            this.comboBoxDatabaseSource.FormattingEnabled = true;
            this.comboBoxDatabaseSource.Items.AddRange(new object[] {
            "Oracle",
            "Postgres"});
            this.comboBoxDatabaseSource.Location = new System.Drawing.Point(86, 50);
            this.comboBoxDatabaseSource.Name = "comboBoxDatabaseSource";
            this.comboBoxDatabaseSource.Size = new System.Drawing.Size(101, 21);
            this.comboBoxDatabaseSource.TabIndex = 1;
            this.comboBoxDatabaseSource.SelectedIndexChanged += new System.EventHandler(this.comboBoxDatabaseSource_SelectedIndexChanged);
            // 
            // comboBoxDatabaseDestination
            // 
            this.comboBoxDatabaseDestination.FormattingEnabled = true;
            this.comboBoxDatabaseDestination.Items.AddRange(new object[] {
            "Oracle",
            "Postgres"});
            this.comboBoxDatabaseDestination.Location = new System.Drawing.Point(411, 47);
            this.comboBoxDatabaseDestination.Name = "comboBoxDatabaseDestination";
            this.comboBoxDatabaseDestination.Size = new System.Drawing.Size(101, 21);
            this.comboBoxDatabaseDestination.TabIndex = 8;
            this.comboBoxDatabaseDestination.SelectedIndexChanged += new System.EventHandler(this.comboBoxDatabaseDestination_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(338, 50);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "DataBase";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 53);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 13);
            this.label12.TabIndex = 16;
            this.label12.Text = "DataBase";
            // 
            // labelSuccessMigration
            // 
            this.labelSuccessMigration.AutoSize = true;
            this.labelSuccessMigration.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSuccessMigration.Location = new System.Drawing.Point(337, 355);
            this.labelSuccessMigration.Name = "labelSuccessMigration";
            this.labelSuccessMigration.Size = new System.Drawing.Size(0, 20);
            this.labelSuccessMigration.TabIndex = 28;
            // 
            // labelDBNameSrc
            // 
            this.labelDBNameSrc.AutoSize = true;
            this.labelDBNameSrc.Location = new System.Drawing.Point(7, 268);
            this.labelDBNameSrc.Name = "labelDBNameSrc";
            this.labelDBNameSrc.Size = new System.Drawing.Size(84, 13);
            this.labelDBNameSrc.TabIndex = 21;
            this.labelDBNameSrc.Text = "Database Name";
            this.labelDBNameSrc.Visible = false;
            // 
            // textBoxDBNameSrc
            // 
            this.textBoxDBNameSrc.Location = new System.Drawing.Point(97, 265);
            this.textBoxDBNameSrc.Name = "textBoxDBNameSrc";
            this.textBoxDBNameSrc.Size = new System.Drawing.Size(99, 20);
            this.textBoxDBNameSrc.TabIndex = 6;
            this.textBoxDBNameSrc.Visible = false;
            this.textBoxDBNameSrc.TextChanged += new System.EventHandler(this.textBoxDBNameSrc_TextChanged);
            // 
            // textBoxDBNameDest
            // 
            this.textBoxDBNameDest.Location = new System.Drawing.Point(420, 269);
            this.textBoxDBNameDest.Name = "textBoxDBNameDest";
            this.textBoxDBNameDest.Size = new System.Drawing.Size(99, 20);
            this.textBoxDBNameDest.TabIndex = 13;
            this.textBoxDBNameDest.Visible = false;
            // 
            // labelDBNameDest
            // 
            this.labelDBNameDest.AutoSize = true;
            this.labelDBNameDest.Location = new System.Drawing.Point(330, 272);
            this.labelDBNameDest.Name = "labelDBNameDest";
            this.labelDBNameDest.Size = new System.Drawing.Size(84, 13);
            this.labelDBNameDest.TabIndex = 27;
            this.labelDBNameDest.Text = "Database Name";
            this.labelDBNameDest.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 406);
            this.Controls.Add(this.textBoxDBNameDest);
            this.Controls.Add(this.labelDBNameDest);
            this.Controls.Add(this.textBoxDBNameSrc);
            this.Controls.Add(this.labelDBNameSrc);
            this.Controls.Add(this.labelSuccessMigration);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.comboBoxDatabaseDestination);
            this.Controls.Add(this.comboBoxDatabaseSource);
            this.Controls.Add(this.labelTestDest);
            this.Controls.Add(this.labelTestSource);
            this.Controls.Add(this.buttonTestDest);
            this.Controls.Add(this.buttonTestSource);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxPortDest);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxServerDest);
            this.Controls.Add(this.textBoxPasswordDest);
            this.Controls.Add(this.textBoxUserDest);
            this.Controls.Add(this.textBoxPortSource);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxServerSouce);
            this.Controls.Add(this.textBoxPasswordSource);
            this.Controls.Add(this.textBoxUserSource);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxUserSource;
        private System.Windows.Forms.TextBox textBoxPasswordSource;
        private System.Windows.Forms.TextBox textBoxServerSouce;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxPortSource;
        private System.Windows.Forms.TextBox textBoxPortDest;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxServerDest;
        private System.Windows.Forms.TextBox textBoxPasswordDest;
        private System.Windows.Forms.TextBox textBoxUserDest;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.Button buttonTestSource;
        private System.Windows.Forms.Button buttonTestDest;
        private System.Windows.Forms.Label labelTestSource;
        private System.Windows.Forms.Label labelTestDest;
        private System.Windows.Forms.ComboBox comboBoxDatabaseSource;
        private System.Windows.Forms.ComboBox comboBoxDatabaseDestination;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label labelSuccessMigration;
        private System.Windows.Forms.Label labelDBNameSrc;
        private System.Windows.Forms.TextBox textBoxDBNameSrc;
        private System.Windows.Forms.TextBox textBoxDBNameDest;
        private System.Windows.Forms.Label labelDBNameDest;
    }
}

