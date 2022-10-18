using MigrationTool.Services;
using MigrationTool.Helpers;
using MigrationTool.Dialogs;

namespace MigrationTool
{
    public partial class MainWindow : Form
    {
        private readonly StateManager _stateManager;

        public MainWindow()
        {
            _stateManager = Program.ServiceProvider.GetService<StateManager>();
            InitializeComponent();
            this.statusLabelInput.Text = $"Source: {_stateManager.InputConnection}";
            this.statusLabelOutput.Text = $"Destination: {_stateManager.OutputConnection}";
        }

        private void setSourceConnectionStringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var connectionStringDialog = new ConnectionStringEnteringDialog(
                "Set source connection string",
                _stateManager.InputConnection);
            var dialogResult = connectionStringDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                _stateManager.InputConnection = connectionStringDialog.ConnectionString;
                this.statusLabelInput.Text = $"Source: {_stateManager.InputConnection}";
            }
        }

        private void setDestinationConnectionStringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var connectionStringDialog = new ConnectionStringEnteringDialog(
                "Set destination connection string",
                _stateManager.OutputConnection);
            var dialogResult = connectionStringDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                _stateManager.OutputConnection = connectionStringDialog.ConnectionString;
                this.statusLabelOutput.Text = $"Destination: {_stateManager.OutputConnection}";
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var aboutBox = new AboutBox();
            aboutBox.ShowDialog();
        }
    }
}