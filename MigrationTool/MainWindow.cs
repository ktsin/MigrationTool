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
            this.toolStripStatusLabel1.Text = $"Source: {_stateManager.InputConnection}";
            this.toolStripStatusLabel2.Text = $"Destination: {_stateManager.OutputConnection}";
        }

        private void setSourceConnectionStringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var connectionStringDialog = new ConnectionStringEnteringDialog();
            connectionStringDialog.ShowDialog();
        }

        private void setDestinationConnectionStringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var connectionStringDialog = new ConnectionStringEnteringDialog();
            connectionStringDialog.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var aboutBox = new AboutBox();
            aboutBox.ShowDialog();
        }


    }
}