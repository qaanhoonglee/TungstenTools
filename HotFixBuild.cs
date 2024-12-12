using Microsoft.VisualBasic.FileIO;
using System.Diagnostics;
using System.IO.Compression;
using System.Reflection;
using System.Collections.Generic;
using System.Xml.Linq;
using static FindFile.DataModel;
using System.Text.RegularExpressions;

namespace FindFile
{
    public partial class HotFixBuild : Form
    {
        public HotFixBuild()
        {
            InitializeComponent();
        }

        private void HotFixBuild_Load(object sender, EventArgs e)
        {

        }

        string _hotfixName = "";
        string _hotfixVersion = "";
        string _hotfixEnviroment = "";
        //string _deliVerDir = ""; string _deliHotfixDir = ""; 
        string _deliverablesDir = ""; string _rootDir = "";

        string _hfVersion = ""; string _hfFolder = ""; string _deliverables = "";

       // List<Artifact> _artifacts = new List<Artifact>();


        private void btnBuildDeliverablesHotFix_Click(object sender, EventArgs e)
        {

            //CleanDirectory(txtGenericInstallerXml.Text);

            _hotfixVersion = txtVersion.Text;
            _hotfixEnviroment = txtEnv.Text;
            _hotfixName = $"Hotfix-{_hotfixVersion}-{_hotfixEnviroment}";

            _deliverables = Path.Combine(txtHFPath.Text, "deliverables");
            Directory.CreateDirectory(_deliverables);

            _hfFolder = Path.Combine(_deliverables, _hotfixName);
            Directory.CreateDirectory(_hfFolder);


            _hfVersion = Path.Combine(_hfFolder, _hotfixVersion);
            Directory.CreateDirectory(_hfVersion);

            Directory.CreateDirectory(Path.Combine(_hfVersion, "backup"));

            UpdateReadmeDeli(_hfVersion);

            CopyHotFixFiles(_hfVersion);
            CopyHotFixFolder(_hfVersion);



            //zip hotfix
            string folderToZip = _hfFolder;
            string zipPath = Path.Combine(_deliverables, $"{_hotfixName}.zip");
            if (File.Exists(zipPath))
                File.Delete(zipPath);


            ZipFile.CreateFromDirectory(folderToZip, zipPath);

            //copy to hotfix project

            string destPath = Path.Combine(txtGenericInstallerXml.Text, $"{_hotfixName}.zip");
            File.Copy(zipPath, destPath, true);

            //delete hot fix delivery
            //File.Delete(zipPath);

            MessageBox.Show("Done", "Transact", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGenHF_Click(object sender, EventArgs e)
        {
            //_artifacts = GetArtifacts();

            //copy to hotfixzip
            CopyGenericInstaller(_hfVersion);
            string folderToZip = _hfFolder;
            string zipPath = Path.Combine(_deliverables, $"{_hotfixName}.zip");
            if (File.Exists(zipPath))
                File.Delete(zipPath);

            var artifacts = txtGenericInstallerXml.Text.GetArtifacts();
            UpdateReadmeDeli(_hfVersion, artifacts);

            
            ZipFile.CreateFromDirectory(folderToZip, zipPath);

            _hotfixVersion = txtVersion.Text;
            _hotfixEnviroment = txtEnv.Text;
            _hotfixName = $"Hotfix-{_hotfixVersion}-{_hotfixEnviroment}";

            _rootDir = Path.Combine(txtHFPath.Text, $"{_hotfixName}");

            var rootVersionDir = Path.Combine(_rootDir, _hotfixVersion);

            Directory.CreateDirectory(_rootDir);
            Directory.CreateDirectory(rootVersionDir);

            var pdtToolDir = Path.Combine(rootVersionDir, "PDT-TOOL");
            _deliverablesDir = Path.Combine(rootVersionDir, "deliverables");

            // root version
            Directory.CreateDirectory(_deliverablesDir);
            Directory.CreateDirectory(pdtToolDir);

            UpdateReadmeRoot(rootVersionDir);
            // PDT-TOOL
            Directory.CreateDirectory(Path.Combine(pdtToolDir, "deliverables"));
            CopyHFScript(pdtToolDir);

            string sourcePath = Path.Combine(txtPathSnapshot.Text, $"ephesoft-generic-installer-1.0-SNAPSHOT.jar");
            string destPath = Path.Combine(pdtToolDir, "ephesoft-generic-installer-1.0-SNAPSHOT.jar");
            File.Copy(sourcePath, destPath, true);
            UpdateReadmePDT(pdtToolDir, artifacts);

            //deliverables build hot fix file zip structue
            File.Copy(zipPath, Path.Combine(_deliverablesDir, Path.GetFileName(zipPath)), true);


            folderToZip = _rootDir;
            zipPath = Path.Combine(txtHFPath.Text, $"{_hotfixName}.zip");
            if (File.Exists(zipPath))
                File.Delete(zipPath);

            ZipFile.CreateFromDirectory(folderToZip, zipPath);

            //Directory.Delete(folderToZip, true);
            //Directory.Delete(_deliverables, true);

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "explorer.exe",
                Arguments = $"\"{txtHFPath.Text}\""
            };

            Process.Start(startInfo);
        }

        private void CleanDirectory(string directory)
        {

            string[] subFolders = Directory.GetDirectories(directory);

            foreach (string folder in subFolders)
            {
                Directory.Delete(folder, true);
            }

            string[] files = Directory.GetFiles(directory);

            // Xóa các file
            foreach (string file in files)
            {
                File.Delete(file);
            }
        }


        private void UpdateReadmeRoot(string destination)
        {
            var executablePath = Assembly.GetExecutingAssembly().Location;
            var executableDir = Path.GetDirectoryName(executablePath);
            var hfDir = Path.Combine(executableDir, "HF");

            var readmeFile = Path.Combine(hfDir, "readmeRoot.txt");

            string text = File.ReadAllText(Path.Combine(hfDir, readmeFile));

            text = text.Replace("{hotfix-name}", _hotfixName);
            text = text.Replace("{version}", _hotfixVersion);
            text = text.Replace("{version-from}", _hotfixVersion.Substring(0, _hotfixVersion.Length - 1) + "0");

            string? extension;
            if (_hotfixEnviroment.Equals("Windows", StringComparison.OrdinalIgnoreCase))
                extension = ".bat";
            else
                extension = ".sh";
            text = text.Replace("{env-extension}", extension);

            string destPath = Path.Combine(destination, $"readme.txt");

            File.WriteAllText(destPath, text);
        }


        private void UpdateReadmeDeli(string destination)
        {
            var executablePath = Assembly.GetExecutingAssembly().Location;
            var executableDir = Path.GetDirectoryName(executablePath);
            var hfDir = Path.Combine(executableDir, "HF");

            var readmeFile = Path.Combine(hfDir, "readmeDeli.txt");

            string text = File.ReadAllText(Path.Combine(hfDir, readmeFile));
            text = text.Replace("{hotfix-name}", _hotfixName);
            text = text.Replace("{version}", _hotfixVersion);
            text = text.Replace("{version-from}", _hotfixVersion.Substring(0, _hotfixVersion.Length - 1) + "0");
            
            string? extension;
            if (_hotfixEnviroment.Equals("Windows", StringComparison.OrdinalIgnoreCase))
                extension = ".bat";
            else
                extension = ".sh";
            text = text.Replace("{env-extension}", extension);

            text = text.Replace("{version}", _hotfixVersion);

            var jarName = "";
            string sourceFolder = txtHotFixPath.Text;
            string[] files = Directory.GetFiles(sourceFolder);
            foreach (string file in files)
            {
                FileInfo fi = new FileInfo(file);
                string fileName = fi.Name;

                string hfJar = fileName.Replace("-0.0.15-SNAPSHOT.jar", $"-*.jar");
                jarName += $"    - {hfJar}{Environment.NewLine}";
            }
            text = text.Replace("{HOT_FIX_JAR}", jarName);

            string destPath = Path.Combine(destination, $"readme.txt");

            File.WriteAllText(destPath, text);
        }

        private void UpdateReadmeDeli(string destination, List<Artifact> artifacts)
        {
            var executablePath = Assembly.GetExecutingAssembly().Location;
            var executableDir = Path.GetDirectoryName(executablePath);
            var hfDir = Path.Combine(executableDir, "HF");

            var readmeFile = Path.Combine(hfDir, "readmeDeli.txt");

            string text = File.ReadAllText(Path.Combine(hfDir, readmeFile));

            text = text.Replace("{hotfix-name}", _hotfixName);
            string? extension;
            if (_hotfixEnviroment.Equals("Windows", StringComparison.OrdinalIgnoreCase))
                extension = ".bat";
            else
                extension = ".sh";
            text = text.Replace("{env-extension}", extension);

            text = text.Replace("{version}", _hotfixVersion);

            //Backup step
            var stepIndex = 1;

            var readmeReplace = "";
            var hotFixJars = artifacts.Where(e => e.type == ArtifactType.HOT_FIX_JAR);
            if (hotFixJars.Any())
            {                
                readmeReplace = $"2.{stepIndex} Navigate to Ephesoft Transact HOT-FIXES directory location, for example, the path may look like this 'c:\\Ephesoft\\Application\\WEB-INF\\lib\\HOT-FIXES\'\n" +
                    $"2.{stepIndex + 1} Move below mentioned jar files (if present) from the root of the directory to 'c:\\Ephesoft\\Version\\{_hotfixVersion}\\backup\\' directory:\n" +
                string.Join("\r\n", hotFixJars.Select(e => $"\t- {e.name}"));
                text = text.Replace("{HOT_FIX_JAR_BACKUP}", readmeReplace);
                stepIndex += 2;
            }
            else
            {
                text = text.ReplaceKeyToEmpty("{HOT_FIX_JAR_BACKUP}");
            }

            readmeReplace = "";
            var hotFixFolderFiles = artifacts.Where(e => e.type == ArtifactType.FOLDER_REPLACE || e.type == ArtifactType.FILE_REPLACE || e.type == ArtifactType.META_INF_PROP);
            if (hotFixFolderFiles.Any())
            {
                foreach (var artifact in hotFixFolderFiles)
                {
                    readmeReplace += $"2.{stepIndex} Move the '{artifact.name}' {artifact.type.GetDescription()} from the 'Ephesoft\\{artifact.path}' folder to the 'Ephesoft\\Version\\{_hotfixVersion}\\backup' folder.\n";                 
                    stepIndex++;
                }
                text = text.Replace("{FOLDER_FILE_META_INF_PROP_REPLACE_BACKUP}", readmeReplace.Substring(0, readmeReplace.Length - 1));
            }
            else
            {
                text = text.ReplaceKeyToEmpty("{FOLDER_FILE_META_INF_PROP_REPLACE_BACKUP}");
            }

            // Deploy step
            stepIndex = 1; readmeReplace = "";
            if (hotFixJars.Any())
            {
                readmeReplace = $"3.{stepIndex} Copy the below jars from the 'Ephesoft\\Version\\{_hotfixVersion}\\' folder to the root of 'Ephesoft\\Application\\WEB-INF\\lib\\HOT-FIXES\\' folder:\n" +
                string.Join("\r\n", hotFixJars.Select(e => $"\t- {e.name}"));
                text = text.Replace("{HOT_FIX_JAR_DEPLOY}", readmeReplace);
                stepIndex++;
            }
            else
            {
                text = text.ReplaceKeyToEmpty("{HOT_FIX_JAR_DEPLOY}");
            }

            readmeReplace = "";
            if (hotFixFolderFiles.Any())
            {
                foreach (var artifact in hotFixFolderFiles)
                {
                    readmeReplace += $"3.{stepIndex} Copy the '{artifact.name}' {artifact.type.GetDescription()} from the 'Ephesoft\\Version\\{_hotfixVersion}\\' folder to the root of 'Ephesoft\\{artifact.path}' folder.\n".Replace("/", "\\");
                    stepIndex++;                    
                }
                text = text.Replace("{FOLDER_FILE_META_INF_PROP_REPLACE_DEPLOY}", readmeReplace.Substring(0, readmeReplace.Length - 1));
            }
            else
            {
                text = text.ReplaceKeyToEmpty("{FOLDER_FILE_META_INF_PROP_REPLACE_DEPLOY}");
            }


            //revert step

            stepIndex = 2; readmeReplace = "";
            if (hotFixJars.Any())
            {
                readmeReplace = $"1.{stepIndex} Navigate to the root of 'Ephesoft\\Application\\WEB-INF\\lib\\HOT-FIXES\\' folder and delete below jars:\n" +
                string.Join("\r\n", hotFixJars.Select(e => $"\t- {e.name}"));
                text = text.Replace("{HOT_FIX_JAR_REVERT}", readmeReplace);
                stepIndex++;
            }
            else
            {
                text = text.ReplaceKeyToEmpty("{HOT_FIX_JAR_REVERT}");
            }

            readmeReplace = "";
            if (hotFixFolderFiles.Any())
            {
                foreach (var artifact in hotFixFolderFiles)
                {
                    readmeReplace += $"1.{stepIndex} Navigate to the root of 'Ephesoft\\{artifact.path}' folder and delete '{artifact.name}' {artifact.type.GetDescription()}.\n".Replace("/", "\\");
                    stepIndex++;
                }
                text = text.Replace("{FOLDER_FILE_META_INF_PROP_REPLACE_REVERT}", readmeReplace.Substring(0, readmeReplace.Length - 1));
            }
            else
            {
                text = text.ReplaceKeyToEmpty("{FOLDER_FILE_META_INF_PROP_REPLACE_REVERT}");
            }

            //revert changes step

            stepIndex = 1; readmeReplace = "";
            if (hotFixJars.Any())
            {
                readmeReplace = $"2.{stepIndex} Move the following backed-up jars back from the 'Ephesoft\\Version\\{_hotfixVersion}\\backup' folder to the root of 'Ephesoft\\Application\\WEB-INF\\lib\\HOT-FIXES\' folder:\n" +
                string.Join("\r\n", hotFixJars.Select(e => $"\t- {e.name}"));
                text = text.Replace("{HOT_FIX_JAR_REVERT_CHANGE}", readmeReplace);
                stepIndex++;
            }
            else
            {
                text = text.ReplaceKeyToEmpty("{HOT_FIX_JAR_REVERT_CHANGE}");
            }

            readmeReplace = "";
            if (hotFixFolderFiles.Any())
            {
                foreach (var artifact in hotFixFolderFiles)
                {
                    readmeReplace += $"2.{stepIndex} Move the following backed-up '{artifact.name}' '{artifact.type.GetDescription()}' back from the 'Ephesoft\\Version\\{_hotfixVersion}\\backup' folder " +
                        $"to the root of '{artifact.path}' folder.\n".Replace("/", "\\");
                    stepIndex++;
                }
                text = text.Replace("{FOLDER_FILE_META_INF_PROP_REPLACE_REVERT_CHANGE}", readmeReplace.Substring(0, readmeReplace.Length - 1));
            }
            else
            {
                text = text.ReplaceKeyToEmpty("{FOLDER_FILE_META_INF_PROP_REPLACE_REVERT_CHANGE}");
            }

            //TODO Excute script...

            text = text.ReplaceKeyToEmpty("{DB_SCRIPT_REVERT}");
            text = text.ReplaceKeyToEmpty("{DB_SCRIPT_DEPLOY}");
            text = text.ReplaceKeyToEmpty("{DB_SCRIPT_REVERT_CHANGE}");






            string destPath = Path.Combine(destination, $"readme.txt");

            File.WriteAllText(destPath, text);
        }

        private void UpdateReadmePDT(string destination, List<Artifact> artifacts)
        {
            var executablePath = Assembly.GetExecutingAssembly().Location;
            var executableDir = Path.GetDirectoryName(executablePath);
            var hfDir = Path.Combine(executableDir, "HF");

            var readmeFile = Path.Combine(hfDir, "readmePDT.txt");

            string text = File.ReadAllText(Path.Combine(hfDir, readmeFile));

            text = text.Replace("{hotfix-name}", _hotfixName);
            text = text.Replace("{version}", _hotfixVersion);
            text = text.Replace("{version-from}", _hotfixVersion.Substring(0, _hotfixVersion.Length - 1) + "0");

            var stepIndex = 1;
            var readmeReplace = "";
            artifacts.ForEach(artifact =>
            {
                var path1 = $"[Ephesoft\\{artifact.path}]";
                var path2 = $"[Ephesoft\\{artifact.path}]";
                if(artifact.type == ArtifactType.HOT_FIX_JAR)
                {
                    path1 = $"[Ephesoft_INSTALLATION_DIR]\\lib";
                    path2 = $"[Ephesoft_INSTALLATION_DIR]\\lib\\HOT-FIX";
                }
                readmeReplace += $"1.{stepIndex} Go to {path1} directory." +
                $"\n\tTake backup of existing '{artifact.name}' {artifact.type.GetDescription()} and then delete the same." +
                $"\n\tCopy extracted '{artifact.name}' {artifact.type.GetDescription()} to {path1} directory.\n";
                stepIndex++;
            });
            readmeReplace += $"1.{stepIndex} Start Ephesoft service.";

            //TODO Excute script...



            //var jarName = "";
            //string sourceFolder = txtHotFixPath.Text;
            //string[] files = Directory.GetFiles(sourceFolder);
            //foreach (string file in files)
            //{
            //    FileInfo fi = new FileInfo(file);
            //    string fileName = fi.Name;

            //    string hfJar = fileName.Replace("-0.0.15-SNAPSHOT.jar", $"-*.jar");
            //    jarName += $"{hfJar}$";
            //}
            text = text.Replace("{PDT-Deploy}", readmeReplace);

            string destPath = Path.Combine(destination, $"readme.txt");

            File.WriteAllText(destPath, text);
        }

        private void CopyHFScript(string destination)
        {
            var executablePath = Assembly.GetExecutingAssembly().Location;
            var executableDir = Path.GetDirectoryName(executablePath);
            var hfDir = Path.Combine(executableDir, "HF");
            var scriptDir = Path.Combine(hfDir, "Script");

            string? extension;
            if (_hotfixEnviroment.Equals("Windows", StringComparison.OrdinalIgnoreCase))
                extension = ".bat";
            else
                extension = ".sh";

            string sourcePath = Path.Combine(scriptDir, $"generic_installer{extension}");
            string destPath = Path.Combine(destination, $"generic_installer{extension}");
            File.Copy(sourcePath, destPath, true);

            sourcePath = Path.Combine(scriptDir, $"generic_uninstaller{extension}");
            destPath = Path.Combine(destination, $"generic_uninstaller{extension}");
            File.Copy(sourcePath, destPath, true);
        }

        private void CopyHotFixFiles(string destination)
        {
            string sourceFolder = txtHotFixPath.Text;

            string[] files = Directory.GetFiles(sourceFolder);

            foreach (string file in files)
            {
                FileInfo fi = new FileInfo(file);
                string fileName = fi.Name;

                string newFileName = fileName.Replace(txtSuffix.Text, $"-{_hotfixVersion}.jar");

                File.Copy(file, Path.Combine(destination, newFileName), true);
            }
        }

        private void CopyHotFixFolder(string destination)
        {
            string rootFolder = txtHotFixPath.Text;
            string[] subFolders = Directory.GetDirectories(rootFolder).Select(folderPath => Path.GetFileName(folderPath)).ToArray();

            foreach (string folder in subFolders)
            {
                string sourceFolder = Path.Combine(rootFolder, folder);
                string dest = Path.Combine(destination, folder);

                FileSystem.CopyDirectory(sourceFolder, dest, true);
            }
        }
        private void CopyGenericInstaller(string destination)
        {
            string sourceFolder = txtGenericInstallerXml.Text;

            string[] files = Directory.GetFiles(sourceFolder);

            foreach (string file in files)
            {
                FileInfo fi = new FileInfo(file);
                string fileName = fi.Name;
                if (!Path.GetExtension(fileName).Contains("zip"))
                    File.Copy(file, Path.Combine(destination, fileName), true);
            }
        }

        private void btnNewHF_Click(object sender, EventArgs e)
        {
            CleanDirectory(txtGenericInstallerXml.Text);
            //if (Directory.Exists(_rootDir))
            //    Directory.Delete(_rootDir, true);
            //if (Directory.Exists(_deliverables))
            //    Directory.Delete(_deliverables, true);
        }


    }
}
