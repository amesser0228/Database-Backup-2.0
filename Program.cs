using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackupApp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool backupArgPresent = args.Any(arg => arg.ToLower() == "backup");
            if (backupArgPresent)
            {
                BackupBackgroundWorker backupBackgroundWorker = new BackupBackgroundWorker();
                backupBackgroundWorker.backup();
            }

            else
            {

                Application.Run(new BackupAppForm1());
            }
        }
    }
}
