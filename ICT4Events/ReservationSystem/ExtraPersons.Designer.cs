﻿namespace ReservationSystem
{
    partial class ExtraPersons
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
            this.lstPersons = new System.Windows.Forms.ListBox();
            this.gboxPersons = new System.Windows.Forms.GroupBox();
            this.btDeleteAccount = new System.Windows.Forms.Button();
            this.btCancelForm = new System.Windows.Forms.Button();
            this.btSubmitForm = new System.Windows.Forms.Button();
            this.gboxAdd = new System.Windows.Forms.GroupBox();
            this.btAddMainBooker = new System.Windows.Forms.Button();
            this.lblPostalCode = new System.Windows.Forms.Label();
            this.txtPostalCode = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.btAddPerson = new System.Windows.Forms.Button();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.lblDateOfBirth = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblTutorial = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btAddExistingAccount = new System.Windows.Forms.Button();
            this.lblFoundAccountInfo = new System.Windows.Forms.Label();
            this.lblFoundAccount = new System.Windows.Forms.Label();
            this.btSearchAccount = new System.Windows.Forms.Button();
            this.lblAccountEntry = new System.Windows.Forms.Label();
            this.tbAccountEntry = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gboxPersons.SuspendLayout();
            this.gboxAdd.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstPersons
            // 
            this.lstPersons.FormattingEnabled = true;
            this.lstPersons.Location = new System.Drawing.Point(4, 17);
            this.lstPersons.Margin = new System.Windows.Forms.Padding(2);
            this.lstPersons.Name = "lstPersons";
            this.lstPersons.Size = new System.Drawing.Size(502, 199);
            this.lstPersons.TabIndex = 9;
            // 
            // gboxPersons
            // 
            this.gboxPersons.Controls.Add(this.btDeleteAccount);
            this.gboxPersons.Controls.Add(this.lstPersons);
            this.gboxPersons.Location = new System.Drawing.Point(256, 143);
            this.gboxPersons.Margin = new System.Windows.Forms.Padding(2);
            this.gboxPersons.Name = "gboxPersons";
            this.gboxPersons.Padding = new System.Windows.Forms.Padding(2);
            this.gboxPersons.Size = new System.Drawing.Size(510, 279);
            this.gboxPersons.TabIndex = 6;
            this.gboxPersons.TabStop = false;
            this.gboxPersons.Text = "Bijbehorende personen";
            // 
            // btDeleteAccount
            // 
            this.btDeleteAccount.Location = new System.Drawing.Point(4, 233);
            this.btDeleteAccount.Margin = new System.Windows.Forms.Padding(2);
            this.btDeleteAccount.Name = "btDeleteAccount";
            this.btDeleteAccount.Size = new System.Drawing.Size(84, 33);
            this.btDeleteAccount.TabIndex = 12;
            this.btDeleteAccount.Text = "Verwijderen";
            this.btDeleteAccount.UseVisualStyleBackColor = true;
            this.btDeleteAccount.Click += new System.EventHandler(this.btDeleteAccount_Click);
            // 
            // btCancelForm
            // 
            this.btCancelForm.Location = new System.Drawing.Point(590, 428);
            this.btCancelForm.Margin = new System.Windows.Forms.Padding(2);
            this.btCancelForm.Name = "btCancelForm";
            this.btCancelForm.Size = new System.Drawing.Size(86, 33);
            this.btCancelForm.TabIndex = 10;
            this.btCancelForm.Text = "Annuleren";
            this.btCancelForm.UseVisualStyleBackColor = true;
            this.btCancelForm.Click += new System.EventHandler(this.btCancelForm_Click);
            // 
            // btSubmitForm
            // 
            this.btSubmitForm.Location = new System.Drawing.Point(680, 428);
            this.btSubmitForm.Margin = new System.Windows.Forms.Padding(2);
            this.btSubmitForm.Name = "btSubmitForm";
            this.btSubmitForm.Size = new System.Drawing.Size(86, 33);
            this.btSubmitForm.TabIndex = 11;
            this.btSubmitForm.Text = "Voltooien";
            this.btSubmitForm.UseVisualStyleBackColor = true;
            this.btSubmitForm.Click += new System.EventHandler(this.btSubmitForm_Click);
            // 
            // gboxAdd
            // 
            this.gboxAdd.Controls.Add(this.btAddMainBooker);
            this.gboxAdd.Controls.Add(this.lblPostalCode);
            this.gboxAdd.Controls.Add(this.txtPostalCode);
            this.gboxAdd.Controls.Add(this.txtAddress);
            this.gboxAdd.Controls.Add(this.lblAddress);
            this.gboxAdd.Controls.Add(this.btAddPerson);
            this.gboxAdd.Controls.Add(this.txtPhone);
            this.gboxAdd.Controls.Add(this.lblPhone);
            this.gboxAdd.Controls.Add(this.txtEmail);
            this.gboxAdd.Controls.Add(this.lblEmail);
            this.gboxAdd.Controls.Add(this.dtpDateOfBirth);
            this.gboxAdd.Controls.Add(this.lblDateOfBirth);
            this.gboxAdd.Controls.Add(this.txtCity);
            this.gboxAdd.Controls.Add(this.lblCity);
            this.gboxAdd.Controls.Add(this.txtName);
            this.gboxAdd.Controls.Add(this.lblName);
            this.gboxAdd.Controls.Add(this.lblTutorial);
            this.gboxAdd.Location = new System.Drawing.Point(13, 10);
            this.gboxAdd.Name = "gboxAdd";
            this.gboxAdd.Size = new System.Drawing.Size(234, 412);
            this.gboxAdd.TabIndex = 7;
            this.gboxAdd.TabStop = false;
            this.gboxAdd.Text = "Nieuwe accounts aanmaken";
            // 
            // btAddMainBooker
            // 
            this.btAddMainBooker.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAddMainBooker.Location = new System.Drawing.Point(9, 367);
            this.btAddMainBooker.Margin = new System.Windows.Forms.Padding(2);
            this.btAddMainBooker.Name = "btAddMainBooker";
            this.btAddMainBooker.Size = new System.Drawing.Size(110, 33);
            this.btAddMainBooker.TabIndex = 15;
            this.btAddMainBooker.Text = "Voeg hoofdboeker toe";
            this.btAddMainBooker.UseVisualStyleBackColor = true;
            this.btAddMainBooker.Click += new System.EventHandler(this.btAddMainBooker_Click);
            // 
            // lblPostalCode
            // 
            this.lblPostalCode.AutoSize = true;
            this.lblPostalCode.Location = new System.Drawing.Point(136, 165);
            this.lblPostalCode.Name = "lblPostalCode";
            this.lblPostalCode.Size = new System.Drawing.Size(55, 13);
            this.lblPostalCode.TabIndex = 14;
            this.lblPostalCode.Text = "Postcode:";
            // 
            // txtPostalCode
            // 
            this.txtPostalCode.Location = new System.Drawing.Point(139, 181);
            this.txtPostalCode.Name = "txtPostalCode";
            this.txtPostalCode.Size = new System.Drawing.Size(87, 20);
            this.txtPostalCode.TabIndex = 4;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(10, 128);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(216, 20);
            this.txtAddress.TabIndex = 2;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(7, 112);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(34, 13);
            this.lblAddress.TabIndex = 11;
            this.lblAddress.Text = "Adres";
            // 
            // btAddPerson
            // 
            this.btAddPerson.Location = new System.Drawing.Point(123, 367);
            this.btAddPerson.Margin = new System.Windows.Forms.Padding(2);
            this.btAddPerson.Name = "btAddPerson";
            this.btAddPerson.Size = new System.Drawing.Size(104, 33);
            this.btAddPerson.TabIndex = 8;
            this.btAddPerson.Text = "Voeg account toe";
            this.btAddPerson.UseVisualStyleBackColor = true;
            this.btAddPerson.Click += new System.EventHandler(this.btAddPerson_Click);
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(9, 282);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(219, 20);
            this.txtPhone.TabIndex = 6;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(7, 266);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(52, 13);
            this.lblPhone.TabIndex = 9;
            this.lblPhone.Text = "Telefoon:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(9, 232);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(219, 20);
            this.txtEmail.TabIndex = 5;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(6, 216);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 7;
            this.lblEmail.Text = "Email:";
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.Location = new System.Drawing.Point(9, 333);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new System.Drawing.Size(218, 20);
            this.dtpDateOfBirth.TabIndex = 7;
            // 
            // lblDateOfBirth
            // 
            this.lblDateOfBirth.AutoSize = true;
            this.lblDateOfBirth.Location = new System.Drawing.Point(6, 316);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new System.Drawing.Size(83, 13);
            this.lblDateOfBirth.TabIndex = 5;
            this.lblDateOfBirth.Text = "Geboortedatum:";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(10, 181);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(123, 20);
            this.txtCity.TabIndex = 3;
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(6, 165);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(67, 13);
            this.lblCity.TabIndex = 3;
            this.lblCity.Text = "Woonplaats:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(9, 80);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(217, 20);
            this.txtName.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(7, 64);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Naam:";
            // 
            // lblTutorial
            // 
            this.lblTutorial.Location = new System.Drawing.Point(7, 20);
            this.lblTutorial.Name = "lblTutorial";
            this.lblTutorial.Size = new System.Drawing.Size(221, 27);
            this.lblTutorial.TabIndex = 0;
            this.lblTutorial.Text = "Vul onderstaande gevens in om een nieuw account aan te maken.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btAddExistingAccount);
            this.groupBox1.Controls.Add(this.lblFoundAccountInfo);
            this.groupBox1.Controls.Add(this.lblFoundAccount);
            this.groupBox1.Controls.Add(this.btSearchAccount);
            this.groupBox1.Controls.Add(this.lblAccountEntry);
            this.groupBox1.Controls.Add(this.tbAccountEntry);
            this.groupBox1.Location = new System.Drawing.Point(256, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(510, 128);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bestaande accounts opzoeken";
            // 
            // btAddExistingAccount
            // 
            this.btAddExistingAccount.Enabled = false;
            this.btAddExistingAccount.Location = new System.Drawing.Point(105, 91);
            this.btAddExistingAccount.Name = "btAddExistingAccount";
            this.btAddExistingAccount.Size = new System.Drawing.Size(113, 23);
            this.btAddExistingAccount.TabIndex = 20;
            this.btAddExistingAccount.Text = "Account toevoegen";
            this.btAddExistingAccount.UseVisualStyleBackColor = true;
            this.btAddExistingAccount.Click += new System.EventHandler(this.btAddExistingAccount_Click);
            // 
            // lblFoundAccountInfo
            // 
            this.lblFoundAccountInfo.Location = new System.Drawing.Point(102, 54);
            this.lblFoundAccountInfo.Name = "lblFoundAccountInfo";
            this.lblFoundAccountInfo.Size = new System.Drawing.Size(389, 34);
            this.lblFoundAccountInfo.TabIndex = 19;
            this.lblFoundAccountInfo.Text = "<geen account gevonden>";
            // 
            // lblFoundAccount
            // 
            this.lblFoundAccount.Location = new System.Drawing.Point(6, 54);
            this.lblFoundAccount.Name = "lblFoundAccount";
            this.lblFoundAccount.Size = new System.Drawing.Size(103, 15);
            this.lblFoundAccount.TabIndex = 18;
            this.lblFoundAccount.Text = "Gevonden gevens:";
            // 
            // btSearchAccount
            // 
            this.btSearchAccount.Location = new System.Drawing.Point(413, 11);
            this.btSearchAccount.Name = "btSearchAccount";
            this.btSearchAccount.Size = new System.Drawing.Size(75, 23);
            this.btSearchAccount.TabIndex = 17;
            this.btSearchAccount.Text = "Zoeken";
            this.btSearchAccount.UseVisualStyleBackColor = true;
            this.btSearchAccount.Click += new System.EventHandler(this.btSearchAccount_Click);
            // 
            // lblAccountEntry
            // 
            this.lblAccountEntry.Location = new System.Drawing.Point(6, 16);
            this.lblAccountEntry.Name = "lblAccountEntry";
            this.lblAccountEntry.Size = new System.Drawing.Size(206, 20);
            this.lblAccountEntry.TabIndex = 16;
            this.lblAccountEntry.Text = "Vul een account ID of gebruikersnaam in:";
            // 
            // tbAccountEntry
            // 
            this.tbAccountEntry.Location = new System.Drawing.Point(229, 13);
            this.tbAccountEntry.Name = "tbAccountEntry";
            this.tbAccountEntry.Size = new System.Drawing.Size(178, 20);
            this.tbAccountEntry.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(246, 438);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(339, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Accounts worden pas aangemaakt na het plaatsen van de reservering";
            // 
            // ExtraPersons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 469);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btCancelForm);
            this.Controls.Add(this.gboxAdd);
            this.Controls.Add(this.btSubmitForm);
            this.Controls.Add(this.gboxPersons);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ExtraPersons";
            this.Text = "Vul de persoonsgegevens in";
            this.Load += new System.EventHandler(this.ExtraPersons_Load);
            this.gboxPersons.ResumeLayout(false);
            this.gboxAdd.ResumeLayout(false);
            this.gboxAdd.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstPersons;
        private System.Windows.Forms.GroupBox gboxPersons;
        private System.Windows.Forms.Button btCancelForm;
        private System.Windows.Forms.Button btSubmitForm;
        private System.Windows.Forms.GroupBox gboxAdd;
        private System.Windows.Forms.Label lblTutorial;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.DateTimePicker dtpDateOfBirth;
        private System.Windows.Forms.Label lblDateOfBirth;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btAddPerson;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblPostalCode;
        private System.Windows.Forms.TextBox txtPostalCode;
        private System.Windows.Forms.Button btAddMainBooker;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btDeleteAccount;
        private System.Windows.Forms.Label lblAccountEntry;
        private System.Windows.Forms.TextBox tbAccountEntry;
        private System.Windows.Forms.Label lblFoundAccount;
        private System.Windows.Forms.Button btSearchAccount;
        private System.Windows.Forms.Label lblFoundAccountInfo;
        private System.Windows.Forms.Button btAddExistingAccount;
        private System.Windows.Forms.Label label1;


    }
}