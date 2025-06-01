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
            bool backupArgPresentValidate = args.Any(arg => arg.ToLower() == "backup_validate");

            if (backupArgPresent)
            {
                BackupBackgroundWorker backupBackgroundWorker = new BackupBackgroundWorker();
                backupBackgroundWorker.backup();
            }
            else if (backupArgPresentValidate)
            { 
                BackupBackgroundWorker_Validation backupBackgroundWorker_Validation = new BackupBackgroundWorker_Validation();
                backupBackgroundWorker_Validation.backup();
            }

            else
            {

                Application.Run(new BackupAppForm1());
            }
        }
    }
}
