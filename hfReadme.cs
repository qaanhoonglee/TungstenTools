using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Security;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FindFile
{
    public partial class hfReadme : Form
    {
        public hfReadme()
        {
            InitializeComponent();
        }

        string oosId = "";
        string releasVersion = "";
        string buildDate = "";
        string bugId = "";
        string bugName = "";
        string bugSolution = "";

        private void btnCreate_Click(object sender, EventArgs e)
        {
            oosId = txtOosId.Text;
            releasVersion = txtReleaseVersion.Text;
            buildDate = DateTime.Today.ToString("MMM dd, yyyy");
            bugId = txtBugId.Text;
            bugName = txtBugName.Text;
            bugSolution = txtBugSolution.Text;

            var executablePath = Assembly.GetExecutingAssembly().Location;
            var executableDir = Path.GetDirectoryName(executablePath);
            var sourceHtml = Path.Combine(executableDir, "HF\\readme");

            var destinationHtml = Path.Combine(sourceHtml+"\\generate", $"ReadMe-Transact-{releasVersion}.FIX{oosId}");

            string destFolder = Path.GetDirectoryName(destinationHtml);

            if (!Directory.Exists(destFolder))
            {
                Directory.CreateDirectory(destFolder);
            }

            writeReadme(Path.Combine(sourceHtml, "ReadMe-Transact.html"), $"{destinationHtml}.html");

            destinationHtml = Path.Combine(sourceHtml + "\\generate", $"ReadMe-Transact-{releasVersion}.FIX{oosId}");
            writeReadme(Path.Combine(sourceHtml, "ReadMe-Transact_ForLinux.html"), $"{destinationHtml}_ForLinux.html");

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "explorer.exe",
                Arguments = $"\"{Path.GetDirectoryName(destinationHtml)}\""
            };

            Process.Start(startInfo);
        }

        private void writeReadme(string sourceHtml, string destinationHtml)
        {

            string readmeHtml = File.ReadAllText(sourceHtml);

            readmeHtml = readmeHtml.Replace("{RELEASE_VERSION}", releasVersion);

            readmeHtml = readmeHtml.Replace("{OOS_ID}", oosId);

            readmeHtml = readmeHtml.Replace("{BUILD_DATE}", buildDate);

            readmeHtml = readmeHtml.Replace("{BUG_ID}", bugId);

            readmeHtml = readmeHtml.Replace("{BUG_NAME}", bugName);

            readmeHtml = readmeHtml.Replace("{BUG_SOLUTION}", bugSolution);

            if (txtJarsForDrop.Text.Trim().Length > 0)
            {
                string[] jarsForDrop = txtJarsForDrop.Text.Split(",");
                string jars = "";
                foreach (string jar in jarsForDrop)
                {
                    jars += $"<tr><td>{jar}-{releasVersion}.FIX{oosId}.jar</td><td>N/A</td></tr>";
                }
                readmeHtml = readmeHtml.Replace("{JARS_FOR_DROP}", jars);
            }
            else
            {
                readmeHtml = readmeHtml.Replace("{JARS_FOR_DROP}", "");
            }
            if (txtFilesForDrop.Text.Trim().Length > 0)
            {
                string[] filesForDrop = txtFilesForDrop.Text.Split(",");
                string files = "";
                foreach (string file in filesForDrop)
                {
                    files += $"<tr><td>{file}</td><td>N/A</td></tr>";
                }
                readmeHtml = readmeHtml.Replace("{FILE_FILE_FOR_DROP}", files);
            }
            else
            {
                readmeHtml = readmeHtml.Replace("{FILE_FILE_FOR_DROP}", "");
            }
            File.WriteAllText(destinationHtml, readmeHtml);

        }
    }
}
