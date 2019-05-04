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

            // initialise comboBox value of log attribute
            LogAttributeComboBox.DataSource = Enum.GetValues(typeof(LogAttributesEnum));

            // subscribe
            model.logChanged += update;
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Browse_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "JSON File|*.json";

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                logController.setLogFile(dialog.FileName);
            }

            catch (Exception ex)
            {

                logger.AddLog("Failed to open Json File", ex);
            }
        }

        private void LogViewerForm_Load(object sender, EventArgs e)
        {

        }

        private void update()
        {
            var bindingSource = new BindingSource();
            bindingSource.DataSource = model.getFilteredLogs();
            logDataGrid.DataSource = bindingSource;
            logDataGrid.AutoResizeColumns();

        }

        private void ApplyFilter_Click(object sender, EventArgs e)
        {
            logController.clearFilter(); // TODO remove
            logController.addFilter((LogAttributesEnum)LogAttributeComboBox.SelectedItem, FilterTextBox.Text);

        }

        private void FilterTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void LogAttributeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ResetFilter_Click(object sender, EventArgs e)
        {
            logController.clearFilter();
            FilterTextBox.Text = "";
        }
    }
}
