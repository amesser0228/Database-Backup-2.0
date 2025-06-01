using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;
using Microsoft.Win32.TaskScheduler;
using Task = System.Threading.Tasks.Task;
using System.Diagnostics;
using System.Reflection;


namespace BackupApp
{
    public partial class BackupAppForm1 : Form
    {
        private DateTime backupTime; // Declare as a field
        private string timestamp;
        private string destinationDirectory;

        public BackupAppForm1()
        {
            InitializeComponent();
            CheckAndCreateFiles();
        }

        string projectName = Assembly.GetExecutingAssembly().GetName().Name + " Message";

        public static bool TaskExists(string taskName)
        {
            using (TaskService ts = new TaskService())
            {
                Microsoft.Win32.TaskScheduler.Task task = ts.FindTask(taskName, true);
                if (task != null)
                {
                    return true;
                }
                else
                {
                    return false; // The task does not exist
                }
            }
        }

        public bool IsTaskEnabled(string taskName)
        {
            using (TaskService ts = new TaskService())
            {
                Microsoft.Win32.TaskScheduler.Task task = ts.FindTask(taskName, true);
                return task != null && task.Enabled;
            }
        }

        public async void verifyScedulerTasks()
        {
            await Task.Delay(1000); // Delay for 1 second
            string backupName = "ETC Backup";
            List<string> existingTasks = new List<string>();
            Dictionary<string, bool> taskStatuses = new Dictionary<string, bool>();
            bool schedTask = false;

            using (TaskService taskService = new TaskService())
            {
                // Get all tasks
                var allTasks = taskService.AllTasks;

                // Filter tasks that start with the defined backupName
                var foundTasks = allTasks.Where(task => task.Name.StartsWith(backupName));

                foreach (var foundTask in foundTasks)
                {
                    schedTask = true;
                    existingTasks.Add(foundTask.Name);
                    taskStatuses[foundTask.Name] = foundTask.Enabled;
                }
            }

            if (schedTask)
            {
                string message = "A TaskScheduler task is created on this system:\n";
                foreach (var taskName in existingTasks)
                {
                    string status = taskStatuses[taskName] ? "enabled" : "disabled";
                    message += $"{taskName} - {status}\n";
                }
                MessageBox.Show(message, projectName);
            }
            else
            {
                MessageBox.Show("No scheduler tasks for ETC backup exist on this system", projectName);
            }
        }

        //persistent storage files
        public string fileBackupPath = Path.Combine(Application.StartupPath, "fileBackUpList.txt");
        public string backUpPath = Path.Combine(Application.StartupPath, "backupPathList.txt");
        public string folderBackupPath = Path.Combine(Application.StartupPath, "folderBackupList.txt");

        //check if persistent storage files exist
        public void CheckAndCreateFiles()
        {
            if (!File.Exists(fileBackupPath))
            {
                File.Create(fileBackupPath).Close();
            }

            if (!File.Exists(backUpPath))
            {
                File.Create(backUpPath).Close();
            }

            if (!File.Exists(folderBackupPath))
            {
                File.Create(folderBackupPath).Close();
            }
        }



        private void Form2_Load(object sender, EventArgs e)
        {
            if (File.Exists("fileBackUpList.txt"))
            {
                using (StreamReader reader = new StreamReader("fileBackUpList.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        fileListBox.Items.Add(line);
                    }
                }
            }

            if (File.Exists("fileBackUpList.txt"))
            {
                using (StreamReader backUpPathReader = new StreamReader("backupPathList.txt"))
                {
                    string line;
                    while ((line = backUpPathReader.ReadLine()) != null)
                    {
                        BackupPathListBox.Items.Add(line);
                    }
                }

                if (File.Exists(folderBackupPath))
                {
                    using (StreamReader folderBackUpPathReader = new StreamReader(folderBackupPath))
                    {
                        string line;
                        while ((line = folderBackUpPathReader.ReadLine()) != null)
                        {
                            folderListBox.Items.Add(line);
                        }
                    }
                }
            }

            //verifyScedulerTasks();

        }

        private void addFileBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true; //allow multiple files
            openFileDialog.Title = "Select Files to Backup";
            openFileDialog.Filter = "All Files (*.*)|*.*"; openFileDialog.CheckFileExists = true; openFileDialog.CheckPathExists = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in openFileDialog.FileNames)
                {
                    fileListBox.Items.Add(file);
                }
            }

        }

        private void removeFileBtn_Click(object sender, EventArgs e)
        {
            if (fileListBox.Items.Count > 0)
            {
                if (fileListBox.SelectedIndex != -1)
                {
                    fileListBox.Items.RemoveAt(fileListBox.SelectedIndex);
                }
                else
                {
                    MessageBox.Show("No file selected.", "Information");
                }

            }
            else
            {
                MessageBox.Show("There are no files currently targeted for backup.", "Information");
            }

        }

        private void addFolderBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            DialogResult folderResult = folderBrowser.ShowDialog();
            if (folderResult == DialogResult.OK)
            {
                string folder = folderBrowser.SelectedPath;
                //folderListBox.Items.Clear();
                folderListBox.Items.Add(folder);
                folderListBox.MultiColumn = true;
            }

        }

        private void removeFolderBtn_Click(object sender, EventArgs e)
        {

            if (folderListBox.Items.Count > 0)
            {
                if (folderListBox.SelectedIndex != -1)
                {

                    folderListBox.Items.RemoveAt(folderListBox.SelectedIndex);
                }
                else
                {
                    MessageBox.Show("No file selected.", "Information");
                }

            }
            else
            {
                MessageBox.Show("There are no files currently targeted for backup.", "Information");
            }
        }

        private void BackupAppForm1_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (StreamWriter writer = new StreamWriter("fileBackUpList.txt"))
            {
                foreach (var item in fileListBox.Items)
                {
                    writer.WriteLine(item.ToString());
                }
            }

            using (StreamWriter backUpPathWriter = new StreamWriter("backupPathList.txt"))
            {
                foreach (var item in BackupPathListBox.Items)
                {
                    backUpPathWriter.WriteLine(item.ToString());
                }
            }

            using (StreamWriter folderBackupWriter = new StreamWriter("folderBackupList.txt"))
            {
                foreach (var item in folderListBox.Items)
                {
                    folderBackupWriter.WriteLine(item.ToString());
                }
            }

        }

        private void chooseBackupLocationBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            //show browser dialog
            DialogResult result = folderBrowser.ShowDialog();
            if (result == DialogResult.OK)
            {
                string folderName = folderBrowser.SelectedPath;
                // Clear existing items
                BackupPathListBox.Items.Clear();
                BackupPathListBox.Items.Add(folderName);
            }
        }

        private void RemoveBackupFolderBtn_Click(object sender, EventArgs e)
        {
            // Clear existing items
            BackupPathListBox.Items.Clear();

        }

        public void CopyFiles()
        {
            backupTime = DateTime.Now;
            timestamp = backupTime.ToString("MM.dd.yyyy_HH.mm.ss");

            if (fileListBox.Items.Count == 0 && folderListBox.Items.Count == 0)
            {
                MessageBox.Show("A file or folder must be selected for backup", projectName);
                return;
            }
            //if (folderListBox.Items.Count == 0)
            {
                DialogResult backUpMessage = MessageBox.Show("You are about to back up " + fileListBox.Items.Count + " file(s) and " + folderListBox.Items.Count + " folder(s). \nDo you want to continue?", "ATTENTION", MessageBoxButtons.OKCancel);
                if (backUpMessage == DialogResult.OK)

                {


                    if (BackupPathListBox.Items.Count == 0)
                    {
                        MessageBox.Show("Please select a destination folder first.", projectName);
                        return;
                    }


                    destinationDirectory = BackupPathListBox.Items[0].ToString(); // Assuming only one destination

                    if (!Directory.Exists(destinationDirectory))
                    {
                        MessageBox.Show("The destination directory does not exist.", "Warning");
                        return;
                    }

                    foreach (string filePath in fileListBox.Items)
                    {
                        if (File.Exists(filePath))
                        {
                            try
                            {

                                string fileName = Path.GetFileNameWithoutExtension(filePath);
                                string fileExtension = Path.GetExtension(filePath);
                                string destFile = Path.Combine(destinationDirectory, $"{fileName}_{timestamp}{fileExtension}");
                                File.Copy(filePath, destFile, true); // Overwrites if the file already exists
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error copying file {filePath}: {ex.Message}", "Error");
                            }
                        }
                        else
                        {
                            MessageBox.Show($"File not found: {filePath}", "Warning");
                        }
                    }

                    foreach (string folderPath in folderListBox.Items)
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
                                    File.Copy(file, destFile, true); // Overwrite if filename already exists
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
                                MessageBox.Show($"Error copying file {folderPath}: {ex.Message}", "Error");
                            }
                        }
                        else
                        {
                            MessageBox.Show($"File not found: {folderPath}", "Warning");
                        }
                    }

                    MessageBox.Show("Files backed up successfully", projectName);
                }
                else
                {
                    MessageBox.Show("Please select at least one file to backup", projectName);
                }
            }
        }

        private async void TaskSchedStatusBtn_Click(object sender, EventArgs e)
        {
            TaskSchedProgressStrip.Visible = true;
            toolStripStatusLabel1.Text = "Checking TaskScheduler. Please wait...";
            verifyScedulerTasks();
            await Task.Delay(2000);
            TaskSchedProgressStrip.Visible = false;

        }

        private void silentDatabaseBackup1_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                CopyFiles();
            });
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AboutBox1 abt1 = new AboutBox1();
            abt1.ShowDialog();

        }

        private void BackupBtn_Click(object sender, EventArgs e)
        {
            CopyFiles();
        }

        private void OpenBackupFolderBtn_Click(object sender, EventArgs e)
        {
            if (BackupPathListBox.Items.Count > 0)
            {
                destinationDirectory = BackupPathListBox.Items[0].ToString(); // Assuming only one destination
                Process.Start("explorer.exe", destinationDirectory);
            }
            else 
            {
                MessageBox.Show("Select a backup location first", projectName);
            }
        }
    }
}
