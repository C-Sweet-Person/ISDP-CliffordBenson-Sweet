namespace ISDP_FinalProject.Admin_Functions
{
    partial class LocationTools
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
            this.BtnRefresh = new System.Windows.Forms.Button();
            this.dataViewLocations = new System.Windows.Forms.DataGridView();
            this.btnEditLocation = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewLocations)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnRefresh
            // 
            this.BtnRefresh.Location = new System.Drawing.Point(12, 338);
            this.BtnRefresh.Name = "BtnRefresh";
            this.BtnRefresh.Size = new System.Drawing.Size(175, 29);
            this.BtnRefresh.TabIndex = 0;
            this.BtnRefresh.Text = "Refresh/Load";
            this.BtnRefresh.UseVisualStyleBackColor = true;
            this.BtnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // dataViewLocations
            // 
            this.dataViewLocations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataViewLocations.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataViewLocations.Location = new System.Drawing.Point(12, 12);
            this.dataViewLocations.MultiSelect = false;
            this.dataViewLocations.Name = "dataViewLocations";
            this.dataViewLocations.RowHeadersWidth = 51;
            this.dataViewLocations.RowTemplate.Height = 29;
            this.dataViewLocations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataViewLocations.Size = new System.Drawing.Size(776, 320);
            this.dataViewLocations.TabIndex = 1;
            // 
            // btnEditLocation
            // 
            this.btnEditLocation.Location = new System.Drawing.Point(12, 373);
            this.btnEditLocation.Name = "btnEditLocation";
            this.btnEditLocation.Size = new System.Drawing.Size(175, 29);
            this.btnEditLocation.TabIndex = 2;
            this.btnEditLocation.Text = "EditLocation";
            this.btnEditLocation.UseVisualStyleBackColor = true;
            this.btnEditLocation.Click += new System.EventHandler(this.btnEditLocation_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(613, 338);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(175, 29);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Exit";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(12, 409);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(175, 29);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "DeleteLocation";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // LocationTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnEditLocation);
            this.Controls.Add(this.dataViewLocations);
            this.Controls.Add(this.BtnRefresh);
            this.Name = "LocationTools";
            this.Text = "LocationTools - Bullseye Sporting Goods";
            ((System.ComponentModel.ISupportInitialize)(this.dataViewLocations)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button BtnRefresh;
        private DataGridView dataViewLocations;
        private Button btnEditLocation;
        private Button btnClose;
        private Button btnDelete;
    }
}