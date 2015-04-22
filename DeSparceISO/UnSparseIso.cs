using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Permissions;
using System.Diagnostics;


namespace DeSparceISO
{
    public partial class UnSparseIso : Form
    {
        private String file_location = "";
        private String[] path_segments = {};
        private String current_dir = "";
        public UnSparseIso()
        {
            InitializeComponent();

            this.current_dir = Directory.GetCurrentDirectory();
            this.toolTipRemoveSparceFlag.SetToolTip(txtFileName, "Write the filename with extension in the current directory.");
            this.toolTipRemoveSparceFlag.SetToolTip(btnBrowse, "Browse to the location of the ISO file and select it.");
            this.toolTipRemoveSparceFlag.SetToolTip(btnUnSparse, "Remove the sparce flag from the selected file.");
            this.toolTipRemoveSparceFlag.SetToolTip(prgExecution, "Show execution progress of the current operation.");

            FileIOPermission file_permissions = new FileIOPermission(PermissionState.Unrestricted);
            file_permissions.AllLocalFiles = FileIOPermissionAccess.AllAccess;
            try
            {
                file_permissions.Demand();
            }
            catch (Exception exp) {
                showError(exp.Message);
            }
        }

        private void showError(String message){
            MessageBox.Show(message, "There was a problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void showInfo(String message) {
            MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static FileAttributes removeAttribute(FileAttributes attributes, FileAttributes attribute_to_remove) {
            return attributes & ~attribute_to_remove;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            prgExecution.Value = 0;
            getFileNameLocation.ShowDialog();
            this.file_location = getFileNameLocation.FileName;
            this.path_segments = file_location.Split(Path.DirectorySeparatorChar);
            txtFileName.Text = this.file_location;
        }

        private void btnDeSparce_Click(object sender, EventArgs e)
        {
            try
            {
                prgExecution.Value = 0;
                if (txtFileName.Text.Length > 0) {
                    this.file_location = txtFileName.Text;
                }
                if (this.file_location.Length > 0)
                {
                    if (this.path_segments.Length <= 0){
                        this.file_location = this.current_dir + txtFileName.Text;
                        this.path_segments = file_location.Split(Path.DirectorySeparatorChar);
                    }
                    prgExecution.Value += 10;
                    // Get file attributes/flags
                    FileAttributes file_attrib = File.GetAttributes(this.file_location);
                    // Remove read-only attributes
                    if ((file_attrib & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                    {
                        prgExecution.Value += 10;
                        file_attrib = removeAttribute(file_attrib, FileAttributes.ReadOnly);
                        File.SetAttributes(file_location, file_attrib);
                        prgExecution.Value += 10;
                    }
                    else { 
                        prgExecution.Value += 20; 
                    }
                    // Remove sparse flag
                    if ((file_attrib & FileAttributes.SparseFile) == FileAttributes.SparseFile)
                    {
                        prgExecution.Value += 10;
                        Process process = new Process();
                        ProcessStartInfo start = new ProcessStartInfo();
                        start.WindowStyle = ProcessWindowStyle.Hidden;
                        start.FileName = "cmd.exe";
                        start.Arguments = "/C fsutil sparse setflag \"" + file_location + "\" 0";
                        process.StartInfo = start;
                        bool status = process.Start();
                        if (process.HasExited)
                        {
                            status = status & (process.ExitCode==0);
                        }
                        if(!status) throw new Exception("Could not remove sparse flag from file.");
                        prgExecution.Value += 10;
                    }
                    else {
                        prgExecution.Value += 20;
                    }
                    showInfo("Operation completed successfully!");
                }
                else {
                    prgExecution.Value = 0;
                    showError("There is no file selected. Please select a file and try again.");
                }
            }
            catch (Exception exp) {
                prgExecution.Value = 0;
                showError(exp.Message);
            }
        }
    }
}
