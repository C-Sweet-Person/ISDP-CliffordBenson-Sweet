﻿
namespace ISDP_FinalProject
{
    partial class DashboardAdmin
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabUsers = new System.Windows.Forms.TabPage();
            this.tabPermissions = new System.Windows.Forms.TabPage();
            this.dataGridUsers = new System.Windows.Forms.DataGridView();
            this.dataGridPermissions = new System.Windows.Forms.DataGridView();
            this.btn_newUser = new System.Windows.Forms.Button();
            this.btn_removeUser = new System.Windows.Forms.Button();
            this.btn_closeAdminDashboard = new System.Windows.Forms.Button();
            this.btn_refreshInfo = new System.Windows.Forms.Button();
            this.btn_editUser = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabUsers.SuspendLayout();
            this.tabPermissions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPermissions)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabUsers);
            this.tabControl1.Controls.Add(this.tabPermissions);
            this.tabControl1.Location = new System.Drawing.Point(12, 33);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(766, 338);
            this.tabControl1.TabIndex = 0;
            // 
            // tabUsers
            // 
            this.tabUsers.Controls.Add(this.dataGridUsers);
            this.tabUsers.Location = new System.Drawing.Point(4, 29);
            this.tabUsers.Name = "tabUsers";
            this.tabUsers.Padding = new System.Windows.Forms.Padding(3);
            this.tabUsers.Size = new System.Drawing.Size(758, 305);
            this.tabUsers.TabIndex = 0;
            this.tabUsers.Text = "Users";
            this.tabUsers.UseVisualStyleBackColor = true;
            // 
            // tabPermissions
            // 
            this.tabPermissions.Controls.Add(this.dataGridPermissions);
            this.tabPermissions.Location = new System.Drawing.Point(4, 29);
            this.tabPermissions.Name = "tabPermissions";
            this.tabPermissions.Padding = new System.Windows.Forms.Padding(3);
            this.tabPermissions.Size = new System.Drawing.Size(758, 305);
            this.tabPermissions.TabIndex = 1;
            this.tabPermissions.Text = "Permissions";
            this.tabPermissions.UseVisualStyleBackColor = true;
            // 
            // dataGridUsers
            // 
            this.dataGridUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridUsers.Location = new System.Drawing.Point(6, 5);
            this.dataGridUsers.Name = "dataGridUsers";
            this.dataGridUsers.RowHeadersWidth = 51;
            this.dataGridUsers.RowTemplate.Height = 29;
            this.dataGridUsers.Size = new System.Drawing.Size(746, 294);
            this.dataGridUsers.TabIndex = 0;
            // 
            // dataGridPermissions
            // 
            this.dataGridPermissions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPermissions.Location = new System.Drawing.Point(7, 7);
            this.dataGridPermissions.Name = "dataGridPermissions";
            this.dataGridPermissions.RowHeadersWidth = 51;
            this.dataGridPermissions.RowTemplate.Height = 29;
            this.dataGridPermissions.Size = new System.Drawing.Size(745, 292);
            this.dataGridPermissions.TabIndex = 0;
            // 
            // btn_newUser
            // 
            this.btn_newUser.Location = new System.Drawing.Point(659, 377);
            this.btn_newUser.Name = "btn_newUser";
            this.btn_newUser.Size = new System.Drawing.Size(109, 29);
            this.btn_newUser.TabIndex = 1;
            this.btn_newUser.Text = "Add new user";
            this.btn_newUser.UseVisualStyleBackColor = true;
            // 
            // btn_removeUser
            // 
            this.btn_removeUser.Location = new System.Drawing.Point(659, 412);
            this.btn_removeUser.Name = "btn_removeUser";
            this.btn_removeUser.Size = new System.Drawing.Size(109, 29);
            this.btn_removeUser.TabIndex = 2;
            this.btn_removeUser.Text = "Remove User";
            this.btn_removeUser.UseVisualStyleBackColor = true;
            // 
            // btn_closeAdminDashboard
            // 
            this.btn_closeAdminDashboard.Location = new System.Drawing.Point(659, 447);
            this.btn_closeAdminDashboard.Name = "btn_closeAdminDashboard";
            this.btn_closeAdminDashboard.Size = new System.Drawing.Size(109, 29);
            this.btn_closeAdminDashboard.TabIndex = 3;
            this.btn_closeAdminDashboard.Text = "Close";
            this.btn_closeAdminDashboard.UseVisualStyleBackColor = true;
            // 
            // btn_refreshInfo
            // 
            this.btn_refreshInfo.Location = new System.Drawing.Point(22, 394);
            this.btn_refreshInfo.Name = "btn_refreshInfo";
            this.btn_refreshInfo.Size = new System.Drawing.Size(109, 29);
            this.btn_refreshInfo.TabIndex = 4;
            this.btn_refreshInfo.Text = "Refresh";
            this.btn_refreshInfo.UseVisualStyleBackColor = true;
            this.btn_refreshInfo.Click += new System.EventHandler(this.btn_refreshInfo_Click);
            // 
            // btn_editUser
            // 
            this.btn_editUser.Location = new System.Drawing.Point(22, 429);
            this.btn_editUser.Name = "btn_editUser";
            this.btn_editUser.Size = new System.Drawing.Size(109, 29);
            this.btn_editUser.TabIndex = 5;
            this.btn_editUser.Text = "Edit";
            this.btn_editUser.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(289, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(482, 41);
            this.label1.TabIndex = 6;
            this.label1.Text = "User Management (Admin Section)";
            // 
            // DashboardAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 488);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_editUser);
            this.Controls.Add(this.btn_refreshInfo);
            this.Controls.Add(this.btn_closeAdminDashboard);
            this.Controls.Add(this.btn_removeUser);
            this.Controls.Add(this.btn_newUser);
            this.Controls.Add(this.tabControl1);
            this.Name = "DashboardAdmin";
            this.Text = "DashboardAdmin";
            this.tabControl1.ResumeLayout(false);
            this.tabUsers.ResumeLayout(false);
            this.tabPermissions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPermissions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabUsers;
        private DataGridView dataGridUsers;
        private TabPage tabPermissions;
        private DataGridView dataGridPermissions;
        private Button btn_newUser;
        private Button btn_removeUser;
        private Button btn_closeAdminDashboard;
        private Button btn_refreshInfo;
        private Button btn_editUser;
        private Label label1;
    }
}