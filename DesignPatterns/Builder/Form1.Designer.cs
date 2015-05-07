namespace Builder
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
            this.btnGetDatabase = new System.Windows.Forms.Button();
            this.radUseSqlServer = new System.Windows.Forms.RadioButton();
            this.radUseOleDB = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnGetDatabase
            // 
            this.btnGetDatabase.Location = new System.Drawing.Point(90, 124);
            this.btnGetDatabase.Name = "btnGetDatabase";
            this.btnGetDatabase.Size = new System.Drawing.Size(100, 23);
            this.btnGetDatabase.TabIndex = 0;
            this.btnGetDatabase.Text = "Get Database";
            this.btnGetDatabase.UseVisualStyleBackColor = true;
            this.btnGetDatabase.Click += new System.EventHandler(this.btnGetDatabase_Click);
            // 
            // radUseSqlServer
            // 
            this.radUseSqlServer.AutoSize = true;
            this.radUseSqlServer.Location = new System.Drawing.Point(13, 13);
            this.radUseSqlServer.Name = "radUseSqlServer";
            this.radUseSqlServer.Size = new System.Drawing.Size(96, 17);
            this.radUseSqlServer.TabIndex = 1;
            this.radUseSqlServer.TabStop = true;
            this.radUseSqlServer.Text = "Use Sql Server";
            this.radUseSqlServer.UseVisualStyleBackColor = true;
            // 
            // radUseOleDB
            // 
            this.radUseOleDB.AutoSize = true;
            this.radUseOleDB.Location = new System.Drawing.Point(12, 36);
            this.radUseOleDB.Name = "radUseOleDB";
            this.radUseOleDB.Size = new System.Drawing.Size(81, 17);
            this.radUseOleDB.TabIndex = 2;
            this.radUseOleDB.TabStop = true;
            this.radUseOleDB.Text = "Use Ole DB";
            this.radUseOleDB.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.radUseOleDB);
            this.Controls.Add(this.radUseSqlServer);
            this.Controls.Add(this.btnGetDatabase);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetDatabase;
        private System.Windows.Forms.RadioButton radUseSqlServer;
        private System.Windows.Forms.RadioButton radUseOleDB;
    }
}

