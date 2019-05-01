using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logger;


namespace LogViewer
{
    public partial class LogViewerForm : Form
    {
        private ILoggerManager logger;
        private LogModel model;
        private LogViewController logController;

        public LogViewerForm(ILoggerManager logger, LogModel model,LogViewController logViewController)
        {
            InitializeComponent();
            this.logger = logger;
            this.model = model;
            logController = logViewController;
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Browse_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "JSON File|*.json";

            if (dialog.ShowDialog() == DialogResult.OK)
                return;

            try
            {


            }

            catch (Exception ex)
            {

                logger.AddLog("Failed to open Json File", ex);
            }
        }
    }
}
