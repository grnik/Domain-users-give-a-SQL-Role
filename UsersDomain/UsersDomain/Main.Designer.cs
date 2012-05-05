namespace UsersDomain
{
    partial class Main
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btCheckUser = new System.Windows.Forms.Button();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.btAllUser = new System.Windows.Forms.Button();
            this.txtDomainPath = new System.Windows.Forms.TextBox();
            this.dtgAllUsers = new System.Windows.Forms.DataGridView();
            this.btSearch = new System.Windows.Forms.Button();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btAddUser = new System.Windows.Forms.Button();
            this.dtgRoles = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAllUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgRoles)).BeginInit();
            this.SuspendLayout();
            // 
            // btCheckUser
            // 
            this.btCheckUser.Location = new System.Drawing.Point(12, 12);
            this.btCheckUser.Name = "btCheckUser";
            this.btCheckUser.Size = new System.Drawing.Size(75, 23);
            this.btCheckUser.TabIndex = 0;
            this.btCheckUser.Text = "Check user";
            this.btCheckUser.UseVisualStyleBackColor = true;
            this.btCheckUser.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(151, 12);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(100, 20);
            this.txtUserName.TabIndex = 1;
            // 
            // btAllUser
            // 
            this.btAllUser.Location = new System.Drawing.Point(12, 70);
            this.btAllUser.Name = "btAllUser";
            this.btAllUser.Size = new System.Drawing.Size(75, 23);
            this.btAllUser.TabIndex = 2;
            this.btAllUser.Text = "All user";
            this.btAllUser.UseVisualStyleBackColor = true;
            this.btAllUser.Click += new System.EventHandler(this.btAllUser_Click);
            // 
            // txtDomainPath
            // 
            this.txtDomainPath.Location = new System.Drawing.Point(151, 72);
            this.txtDomainPath.Name = "txtDomainPath";
            this.txtDomainPath.Size = new System.Drawing.Size(100, 20);
            this.txtDomainPath.TabIndex = 4;
            // 
            // dtgAllUsers
            // 
            this.dtgAllUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgAllUsers.Location = new System.Drawing.Point(12, 99);
            this.dtgAllUsers.Name = "dtgAllUsers";
            this.dtgAllUsers.Size = new System.Drawing.Size(498, 177);
            this.dtgAllUsers.TabIndex = 6;
            // 
            // btSearch
            // 
            this.btSearch.Location = new System.Drawing.Point(12, 41);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(75, 23);
            this.btSearch.TabIndex = 7;
            this.btSearch.Text = "Search";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(151, 41);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(100, 20);
            this.txtFilter.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 293);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Roles";
            // 
            // btAddUser
            // 
            this.btAddUser.Location = new System.Drawing.Point(12, 428);
            this.btAddUser.Name = "btAddUser";
            this.btAddUser.Size = new System.Drawing.Size(75, 23);
            this.btAddUser.TabIndex = 13;
            this.btAddUser.Text = "Add user";
            this.btAddUser.UseVisualStyleBackColor = true;
            this.btAddUser.Click += new System.EventHandler(this.btAddUser_Click);
            // 
            // dtgRoles
            // 
            this.dtgRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgRoles.Location = new System.Drawing.Point(12, 310);
            this.dtgRoles.Name = "dtgRoles";
            this.dtgRoles.Size = new System.Drawing.Size(498, 109);
            this.dtgRoles.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(102, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(102, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Filter";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(102, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Domain";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 463);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtgRoles);
            this.Controls.Add(this.btAddUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.btSearch);
            this.Controls.Add(this.dtgAllUsers);
            this.Controls.Add(this.txtDomainPath);
            this.Controls.Add(this.btAllUser);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.btCheckUser);
            this.Name = "Main";
            this.Text = "Manager user DB";
            ((System.ComponentModel.ISupportInitialize)(this.dtgAllUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgRoles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btCheckUser;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Button btAllUser;
        private System.Windows.Forms.TextBox txtDomainPath;
        private System.Windows.Forms.DataGridView dtgAllUsers;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btAddUser;
        private System.Windows.Forms.DataGridView dtgRoles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

