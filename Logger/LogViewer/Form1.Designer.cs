namespace LogViewer
{
    partial class LogViewerForm
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
            this.logDataGrid = new System.Windows.Forms.DataGridView();
            this.browse = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.logDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // logDataGrid
            // 
            this.logDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.logDataGrid.Location = new System.Drawing.Point(12, 213);
            this.logDataGrid.Name = "logDataGrid";
            this.logDataGrid.Size = new System.Drawing.Size(1077, 397);
            this.logDataGrid.TabIndex = 0;
            this.logDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellContentClick);
            // 
            // browse
            // 
            this.browse.Location = new System.Drawing.Point(117, 13);
            this.browse.Name = "browse";
            this.browse.Size = new System.Drawing.Size(75, 23);
            this.browse.TabIndex = 1;
            this.browse.Text = "Browse";
            this.browse.UseVisualStyleBackColor = true;
            this.browse.Click += new System.EventHandler(this.Browse_Click);
            // 
            // LogViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 622);
            this.Controls.Add(this.browse);
            this.Controls.Add(this.logDataGrid);
            this.Name = "LogViewerForm";
            this.Text = "LogViewerForm";
            this.Load += new System.EventHandler(this.LogViewerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.logDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView logDataGrid;
        private System.Windows.Forms.Button browse;
    }
}