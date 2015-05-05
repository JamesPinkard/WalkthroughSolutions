namespace AbstractFactory
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
            this.rdbUseSqlServer = new System.Windows.Forms.RadioButton();
            this.rdbUseOleDB = new System.Windows.Forms.RadioButton();
            this.btnGetDatabase = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rdbUseSqlServer
            // 
            this.rdbUseSqlServer.AutoSize = true;
            this.rdbUseSqlServer.Location = new System.Drawing.Point(13, 25);
            this.rdbUseSqlServer.Name = "rdbUseSqlServer";
            this.rdbUseSqlServer.Size = new System.Drawing.Size(102, 17);
            this.rdbUseSqlServer.TabIndex = 0;
            this.rdbUseSqlServer.TabStop = true;
            this.rdbUseSqlServer.Text = "Use SQL Server";
            this.rdbUseSqlServer.UseVisualStyleBackColor = true;
            // 
            // rdbUseOleDB
            // 
            this.rdbUseOleDB.AutoSize = true;
            this.rdbUseOleDB.Location = new System.Drawing.Point(13, 48);
            this.rdbUseOleDB.Name = "rdbUseOleDB";
            this.rdbUseOleDB.Size = new System.Drawing.Size(77, 17);
            this.rdbUseOleDB.TabIndex = 1;
            this.rdbUseOleDB.TabStop = true;
            this.rdbUseOleDB.Text = "Use OleDb";
            this.rdbUseOleDB.UseVisualStyleBackColor = true;
            // 
            // btnGetDatabase
            // 
            this.btnGetDatabase.Location = new System.Drawing.Point(12, 85);
            this.btnGetDatabase.Name = "btnGetDatabase";
            this.btnGetDatabase.Size = new System.Drawing.Size(151, 23);
            this.btnGetDatabase.TabIndex = 2;
            this.btnGetDatabase.Text = "Get Database";
            this.btnGetDatabase.UseVisualStyleBackColor = true;
            this.btnGetDatabase.Click += new System.EventHandler(this.btnGetDatabase_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnGetDatabase);
            this.Controls.Add(this.rdbUseOleDB);
            this.Controls.Add(this.rdbUseSqlServer);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdbUseSqlServer;
        private System.Windows.Forms.RadioButton rdbUseOleDB;
        private System.Windows.Forms.Button btnGetDatabase;
    }
}

