namespace Hello.AdminTool
{
    partial class FRMMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.bntCreateUser = new System.Windows.Forms.Button();
            this.bntCreateMessage = new System.Windows.Forms.Button();
            this.bntCreateRelationship = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bntCreateUser
            // 
            this.bntCreateUser.Location = new System.Drawing.Point(81, 50);
            this.bntCreateUser.Name = "bntCreateUser";
            this.bntCreateUser.Size = new System.Drawing.Size(107, 28);
            this.bntCreateUser.TabIndex = 0;
            this.bntCreateUser.Text = "Benutzer erstellen";
            this.bntCreateUser.UseVisualStyleBackColor = true;
            this.bntCreateUser.Click += new System.EventHandler(this.bntCreateUser_Click);
            // 
            // bntCreateMessage
            // 
            this.bntCreateMessage.Location = new System.Drawing.Point(81, 118);
            this.bntCreateMessage.Name = "bntCreateMessage";
            this.bntCreateMessage.Size = new System.Drawing.Size(107, 28);
            this.bntCreateMessage.TabIndex = 1;
            this.bntCreateMessage.Text = "Nachricht erstellen";
            this.bntCreateMessage.UseVisualStyleBackColor = true;
            this.bntCreateMessage.Click += new System.EventHandler(this.bntCreateMessage_Click);
            // 
            // bntCreateRelationship
            // 
            this.bntCreateRelationship.Location = new System.Drawing.Point(45, 179);
            this.bntCreateRelationship.Name = "bntCreateRelationship";
            this.bntCreateRelationship.Size = new System.Drawing.Size(176, 28);
            this.bntCreateRelationship.TabIndex = 2;
            this.bntCreateRelationship.Text = "Freundschaftsbeziehung erstellen";
            this.bntCreateRelationship.UseVisualStyleBackColor = true;
            this.bntCreateRelationship.Click += new System.EventHandler(this.bntCreateRelationship_Click);
            // 
            // FRMMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.bntCreateRelationship);
            this.Controls.Add(this.bntCreateMessage);
            this.Controls.Add(this.bntCreateUser);
            this.Name = "FRMMain";
            this.Text = "AdminTool";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bntCreateUser;
        private System.Windows.Forms.Button bntCreateMessage;
        private System.Windows.Forms.Button bntCreateRelationship;
    }
}

