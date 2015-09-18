namespace Hello.AdminTool
{
    partial class FRMRelationshipCreate
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
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.lblUserID = new System.Windows.Forms.Label();
            this.lblFriend = new System.Windows.Forms.Label();
            this.bntFriendshipCreate = new System.Windows.Forms.Button();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(117, 83);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 1;
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Location = new System.Drawing.Point(12, 37);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(49, 13);
            this.lblUserID.TabIndex = 2;
            this.lblUserID.Text = "Benutzer";
            // 
            // lblFriend
            // 
            this.lblFriend.AutoSize = true;
            this.lblFriend.Location = new System.Drawing.Point(12, 86);
            this.lblFriend.Name = "lblFriend";
            this.lblFriend.Size = new System.Drawing.Size(40, 13);
            this.lblFriend.TabIndex = 3;
            this.lblFriend.Text = "Freund";
            // 
            // bntFriendshipCreate
            // 
            this.bntFriendshipCreate.Location = new System.Drawing.Point(117, 123);
            this.bntFriendshipCreate.Name = "bntFriendshipCreate";
            this.bntFriendshipCreate.Size = new System.Drawing.Size(121, 23);
            this.bntFriendshipCreate.TabIndex = 4;
            this.bntFriendshipCreate.Text = "Freundschaft erstellen";
            this.bntFriendshipCreate.UseVisualStyleBackColor = true;
            this.bntFriendshipCreate.Click += new System.EventHandler(this.bntFriendshipCreate_Click);
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(117, 34);
            this.txtUser.Name = "txtUser";
            this.txtUser.ReadOnly = true;
            this.txtUser.Size = new System.Drawing.Size(121, 20);
            this.txtUser.TabIndex = 5;
            // 
            // FRMRelationshipCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 173);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.bntFriendshipCreate);
            this.Controls.Add(this.lblFriend);
            this.Controls.Add(this.lblUserID);
            this.Controls.Add(this.comboBox2);
            this.Name = "FRMRelationshipCreate";
            this.Text = "FRMRelationshipCreate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Label lblFriend;
        private System.Windows.Forms.Button bntFriendshipCreate;
        private System.Windows.Forms.TextBox txtUser;
    }
}