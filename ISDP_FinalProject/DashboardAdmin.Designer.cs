
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
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(766, 345);
            this.tabControl1.TabIndex = 0;
            // 
            // tabUsers
            // 
            this.tabUsers.Controls.Add(this.dataGridUsers);
            this.tabUsers.Location = new System.Drawing.Point(4, 29);
            this.tabUsers.Name = "tabUsers";
            this.tabUsers.Padding = new System.Windows.Forms.Padding(3);
            this.tabUsers.Size = new System.Drawing.Size(758, 312);
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
            this.tabPermissions.Size = new System.Drawing.Size(758, 312);
            this.tabPermissions.TabIndex = 1;
            this.tabPermissions.Text = "Permissions";
            this.tabPermissions.UseVisualStyleBackColor = true;
            // 
            // dataGridUsers
            // 
            this.dataGridUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridUsers.Location = new System.Drawing.Point(6, 6);
            this.dataGridUsers.Name = "dataGridUsers";
            this.dataGridUsers.RowHeadersWidth = 51;
            this.dataGridUsers.RowTemplate.Height = 29;
            this.dataGridUsers.Size = new System.Drawing.Size(746, 300);
            this.dataGridUsers.TabIndex = 0;
            // 
            // dataGridPermissions
            // 
            this.dataGridPermissions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPermissions.Location = new System.Drawing.Point(7, 7);
            this.dataGridPermissions.Name = "dataGridPermissions";
            this.dataGridPermissions.RowHeadersWidth = 51;
            this.dataGridPermissions.RowTemplate.Height = 29;
            this.dataGridPermissions.Size = new System.Drawing.Size(745, 299);
            this.dataGridPermissions.TabIndex = 0;
            // 
            // DashboardAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "DashboardAdmin";
            this.Text = "DashboardAdmin";
            this.tabControl1.ResumeLayout(false);
            this.tabUsers.ResumeLayout(false);
            this.tabPermissions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPermissions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabUsers;
        private DataGridView dataGridUsers;
        private TabPage tabPermissions;
        private DataGridView dataGridPermissions;
    }
}