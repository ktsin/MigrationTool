using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationTool.Services
{
    public class StateManager
    {
        public string InputConnection { get; set; } = "Server=.;Database=inputDB;Trusted_Connection=True;";

        public string OutputConnection { get; set; } = "Server=.;Database=outputDB;Trusted_Connection=True;";
    }
}
