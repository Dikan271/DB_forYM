namespace YM_3._0
{
    partial class AddWorks
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.linkField = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.titleField = new System.Windows.Forms.TextBox();
            this.listUsers = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonCencel = new System.Windows.Forms.Button();
            this.buttonNewUser = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonView = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.linkField);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.titleField);
            this.panel1.Location = new System.Drawing.Point(168, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(362, 101);
            this.panel1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "PostLink";
            // 
            // linkField
            // 
            this.linkField.Location = new System.Drawing.Point(87, 64);
            this.linkField.Name = "linkField";
            this.linkField.Size = new System.Drawing.Size(264, 22);
            this.linkField.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Titile\r\n";
            // 
            // titleField
            // 
            this.titleField.Location = new System.Drawing.Point(87, 19);
            this.titleField.Name = "titleField";
            this.titleField.Size = new System.Drawing.Size(264, 22);
            this.titleField.TabIndex = 0;
            // 
            // listUsers
            // 
            this.listUsers.FormattingEnabled = true;
            this.listUsers.ItemHeight = 16;
            this.listUsers.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.listUsers.Location = new System.Drawing.Point(10, 30);
            this.listUsers.Name = "listUsers";
            this.listUsers.Size = new System.Drawing.Size(152, 180);
            this.listUsers.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Users";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(87, 3);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 58);
            this.buttonAdd.TabIndex = 8;
            this.buttonAdd.Text = "Add\r\npost";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonCencel
            // 
            this.buttonCencel.Location = new System.Drawing.Point(87, 3);
            this.buttonCencel.Name = "buttonCencel";
            this.buttonCencel.Size = new System.Drawing.Size(75, 58);
            this.buttonCencel.TabIndex = 7;
            this.buttonCencel.Text = "Close";
            this.buttonCencel.UseVisualStyleBackColor = true;
            this.buttonCencel.Click += new System.EventHandler(this.buttonCencel_Click);
            // 
            // buttonNewUser
            // 
            this.buttonNewUser.Location = new System.Drawing.Point(6, 3);
            this.buttonNewUser.Name = "buttonNewUser";
            this.buttonNewUser.Size = new System.Drawing.Size(75, 58);
            this.buttonNewUser.TabIndex = 6;
            this.buttonNewUser.Text = "New User";
            this.buttonNewUser.UseVisualStyleBackColor = true;
            this.buttonNewUser.Click += new System.EventHandler(this.buttonNewUser_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonNewUser);
            this.panel2.Controls.Add(this.buttonAdd);
            this.panel2.Location = new System.Drawing.Point(359, 137);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(171, 68);
            this.panel2.TabIndex = 10;
            // 
            // buttonView
            // 
            this.buttonView.Location = new System.Drawing.Point(6, 3);
            this.buttonView.Name = "buttonView";
            this.buttonView.Size = new System.Drawing.Size(75, 58);
            this.buttonView.TabIndex = 11;
            this.buttonView.Text = "View all Posts";
            this.buttonView.UseVisualStyleBackColor = true;
            this.buttonView.Click += new System.EventHandler(this.buttonView_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.buttonView);
            this.panel3.Controls.Add(this.buttonCencel);
            this.panel3.Location = new System.Drawing.Point(168, 137);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(171, 68);
            this.panel3.TabIndex = 12;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // AddWorks
            // 
            this.AcceptButton = this.buttonAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonView;
            this.ClientSize = new System.Drawing.Size(537, 214);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listUsers);
            this.Controls.Add(this.panel1);
            this.Name = "AddWorks";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddWorks";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox linkField;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox titleField;
        private System.Windows.Forms.ListBox listUsers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonCencel;
        private System.Windows.Forms.Button buttonNewUser;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonView;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}