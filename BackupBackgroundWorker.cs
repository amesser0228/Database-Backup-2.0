using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;
using System.Runtime.CompilerServices;

namespace BackupApp
{
    public class BackupBackgroundWorker
    {
        private DateTime backupTime; // Declare as a field
        private string timestamp;

        public BackupBackgroundWorker()
        {
            backupTime = DateTime.Now;
            timestamp = backupTime.ToString("yyyyMMdd_HHmmss");
        }

        

        //listBoxes can't be mutated in a non-form class. Converting text file read containers to lists for the BackupBackgroundWorker class
        public List<string> fileList = new List<string>();
        public List<string> folderList = new List<string>();
        public List<string> BackupPathList = new List<string>();


        //persistent storage files
        public string fileBackupPath = Path.Combine(Application.StartupPath, "fileBackUpList.txt");
        public string backUpPath = Path.Combine(Application.StartupPath, "backupPathList.txt");
        public string folderBackupPath = Path.Combine(Application.StartupPath, "folderBackupList.txt");

        public void backup()
        {
            List<string> missingFiles = new List<string>();
            if (!File.Exists(fileBackupPath))
            {
                missingFiles.Add(fileBackupPath);
                MessageBox.Show("fileBackupPath missing", "Database Backup 2.0");
            }
            if (!File.Exists(backUpPath))
            {
                missingFiles.Add(backUpPath);
                MessageBox.Show("backUpPath missing", "Database Backup 2.0");
            }
            if (!File.Exists(folderBackupPath))
            {
                missingFiles.Add(folderBackupPath);
                MessageBox.Show("backupFolder missing", "Database Backup 2.0");
            }

            if (missingFiles.Count > 0)
            {
                string missingFile = string.Join("\n", missingFiles);
                MessageBox.Show("A required file does not exist on this system:\n" + missingFile, "Database Backup 2.0");
            }

            //using (StreamWriter writer = new StreamWriter("fileBackUpList.txt"))
            //{
            //    foreach (var item in fileListBox.Items)
            //    {
            //        writer.WriteLine(item.ToString());
            //    }
            //}

            //using (StreamWriter backUpPathWriter = new StreamWriter("backupPathList.txt"))
            //{
            //    foreach (var item in BackupPathListBox.Items)
            //    {
            //        backUpPathWriter.WriteLine(item.ToString());
            //    }
            //}

            //using (StreamWriter folderBackupWriter = new StreamWriter("folderBackupList.txt"))
            //{
            //    foreach (var item in folderListBox.Items)
            //    {
            //        folderBackupWriter.WriteLine(item.ToString());
            //    }
            //}

            if (File.Exists(fileBackupPath))
            {
                using (StreamReader reader = new StreamReader(fileBackupPath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        fileList.Add(line);
                    }
                }
            }

            if (File.Exists(backUpPath))
            {
                using (StreamReader backUpPathReader = new StreamReader(backUpPath))
                {
                    string line;
                    while ((line = backUpPathReader.ReadLine()) != null)
                    {
                        BackupPathList.Add(line);
                    }
                }

                if (File.Exists(folderBackupPath))
                {
                    using (StreamReader folderBackUpPathReader = new StreamReader(folderBackupPath))
                    {
                        string line;
                        while ((line = folderBackUpPathReader.ReadLine()) != null)
                        {
                            folderList.Add(line);
                        }
                    }
                }
            }

            ///////////////////////////////////////////////////////////////
            //             COPIES DATA TO BACKUP LOCATION                // 
            ///////////////////////////////////////////////////////////////
            
            if (fileList.Count != 0)
                //if (folderList.Count == 0)
                {
                    //DialogResult backUpMessage = MessageBox.Show("You are about to back up " + fileList.Count + " file(s) and " + folderList.Count + " folder(s). \nDo you want to continue?", "Attention", MessageBoxButtons.OKCancel);
                    //if (backUpMessage == DialogResult.OK)

                    //{


                        if (BackupPathList.Count == 0)
                {
                    MessageBox.Show("Please select a destination folder first.", "Database Backup 2.0");
                    return;
                }


                string destinationDirectory = BackupPathList[0]; // Assuming only one destination

                if (!Directory.Exists(destinationDirectory))
                {
                    MessageBox.Show("The destination directory does not exist.", "Database Backup 2.0");
                    return;
                }

                // initialize DateTime folder container
                //Directory.CreateDirectory(backupFolderContainer);

                foreach (string filePath in fileList)
                {
                    if (File.Exists(filePath))
                    {
                        try
                        {

                            string fileName = Path.GetFileNameWithoutExtension(filePath);
                            string fileExtension = Path.GetExtension(filePath);
                            string destFile = Path.Combine(destinationDirectory, $"{fileName}_{timestamp}{fileExtension}");
                            File.Copy(filePath, destFile); // Overwrites if the file already exists
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error copying file {filePath}: {ex.Message}", "Database Backup 2.0");
                        }
                    }
                    else
                    {
                        MessageBox.Show($"File not found: {filePath}", "Database Backup 2.0");
                    }
                }

                foreach (string folderPath in folderList)
                {
                    if (Directory.Exists(folderPath))
                    {
                        try
                        {
                            string folderName = Path.GetFileNameWithoutExtension(folderPath);
                            string folderExtension = Path.GetExtension(folderPath);
                            string destFolder = Path.Combine(destinationDirectory, $"{folderName}_{timestamp}{folderExtension}");
                            Directory.CreateDirectory(destFolder); // Create destination folder

                            // Copy all files from the source folder to the destination folder
                            foreach (string file in Directory.GetFiles(folderPath))
                            {
                                string destFile = Path.Combine(destFolder, Path.GetFileName(file));
                                File.Copy(file, destFile); // Overwrite if filename already exists
                            }

                            // copy subdirectories
                            foreach (string subDir in Directory.GetDirectories(folderPath))
                            {
                                string destSubDir = Path.Combine(destFolder, Path.GetFileName(subDir));
                                FileSystem.CopyDirectory(subDir, destSubDir);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error copying file {folderPath}: {ex.Message}", "Database Backup 2.0");
                        }
                    }
                    else
                    {
                        MessageBox.Show($"File not found: {folderPath}", "Database Backup 2.0");
                    }
                }

                MessageBox.Show("Files backed up successfully", "Database Backup 2.0");
            }
            else
            {
                MessageBox.Show("Please select at least one file to backup", "Database Backup 2.0");
            }
        }
        //}


    }
}
