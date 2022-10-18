using MigrationTool.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MigrationTool.Dialogs
{
    public partial class ConnectionStringEnteringDialog : Form
    {
        public ConnectionStringEnteringDialog()
        {
            InitializeComponent();
        }

        public ConnectionStringEnteringDialog(string label, string initialValue)
        {
            InitializeComponent();
            this.connectionTextBox.Text = initialValue;
            if (!String.IsNullOrWhiteSpace(label))
            {
                this.Text = label;
            }
        }
        
        public string ConnectionString => connectionTextBox.Text;

        private void testConnectionStringAction_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                this.Invoke(() => { 
                    this.testConnectionStringAction.Enabled = false;
                    this.UseWaitCursor = true;
                });
                var checkResult = DatabaseHelpers.ValidateConnectionString(ConnectionString);

                this.Invoke(() =>
                {
                    this.testConnectionStringAction.Enabled = true;
                    this.UseWaitCursor = false;
                    if (!checkResult)
                    {
                        MessageBox.Show("Connection string isn't correct.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    MessageBox.Show("Connection established, test passed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                });
            });
            
        }
    }
}
