using System.Diagnostics;
using System.Xml.Linq;
namespace FindFile
{
    public partial class JfrogDeploy : Form
    {
        public JfrogDeploy()
        {
            InitializeComponent();
            
        }

        string folderPath, logFilePath, logErrorFilePath, uploadedFilePath, errorFilePath, deployUrl = "";

        private void InitValue()
        {
            txtResult2.Text = "";

            deployUrl = txtDeployUrl.Text;

            folderPath = txtPath.Text;

            logFilePath = Path.Combine(folderPath, "logs", "deployment_log.txt");
            logErrorFilePath = Path.Combine(folderPath, "logs", "deployment_error_log.txt");

            uploadedFilePath = Path.Combine(folderPath, "uploaded");
            errorFilePath = Path.Combine(folderPath, "errror");
            if (!Directory.Exists(uploadedFilePath))
            {
                Directory.CreateDirectory(uploadedFilePath);
            }
            if (!Directory.Exists(errorFilePath))
            {
                Directory.CreateDirectory(errorFilePath);
            }
            if (!Directory.Exists(Path.Combine(folderPath, "logs")))
            {
                Directory.CreateDirectory(Path.Combine(folderPath, "logs"));
            }
        }

        private void BackupLogs()
        {
            if (File.Exists(logFilePath))
            {
                string newlogFileName = Path.Combine(folderPath, "logs", $"deployment_log-{DateTime.Now:yyyyMMddHHmmss}.txt");

                File.Copy(logFilePath, newlogFileName, true);

                File.Delete(logFilePath);
            }
            if (File.Exists(logErrorFilePath))
            {
                string newlogFileName = Path.Combine(folderPath, "logs", $"deployment_error_log-{DateTime.Now:yyyyMMddHHmmss}.txt");

                File.Copy(logErrorFilePath, newlogFileName, true);
                File.Delete(logErrorFilePath);
            }
        }

        private async void btnDeploy_Click(object sender, EventArgs e)
        {
            try
            {
                InitValue();
                BackupLogs();
                string[] jarFiles = Directory.GetFiles(txtPath.Text, "*.jar");

                // Sử dụng async method để không blocking UI
                await Task.Run(() =>
                {
                    foreach (string jarFile in jarFiles)
                    {
                        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(jarFile);
                        string pomFile = Path.Combine(folderPath, fileNameWithoutExtension + ".pom.xml");

                        if (File.Exists(pomFile))
                        {
                            try
                            {
                                string command = $"mvn -X deploy:deploy-file -s \"{txtSettingsPath.Text}\" -DpomFile=\"{pomFile}\" -Dfile=\"{jarFile}\" -DrepositoryId=jfrog-artifactory -Durl=\"{deployUrl}\"";

                                ProcessStartInfo processInfo = new ProcessStartInfo("cmd.exe", $"/c {command}")
                                {
                                    WorkingDirectory = txtM2Home.Text,
                                    CreateNoWindow = true,
                                    UseShellExecute = false,
                                    RedirectStandardOutput = true,
                                    RedirectStandardError = true
                                };

                                using (Process process = new Process())
                                {
                                    process.StartInfo = processInfo;

                                    // Sử dụng AutoResetEvent để đồng bộ hóa
                                    using (var outputWaitHandle = new AutoResetEvent(false))
                                    using (var errorWaitHandle = new AutoResetEvent(false))
                                    {
                                        process.OutputDataReceived += (sender, e) =>
                                        {
                                            if (e.Data == null)
                                            {
                                                outputWaitHandle.Set();
                                            }
                                            else
                                            {
                                                this.Invoke((MethodInvoker)delegate
                                                {
                                                    txtResult2.AppendText(e.Data + Environment.NewLine);
                                                    SetColor(e.Data);
                                                    txtResult2.ScrollToCaret();
                                                });
                                            }
                                        };

                                        process.ErrorDataReceived += (sender, e) =>
                                        {
                                            if (e.Data == null)
                                            {
                                                errorWaitHandle.Set();
                                            }
                                            else
                                            {
                                                this.Invoke((MethodInvoker)delegate
                                                {
                                                    txtResult2.AppendText("[ERROR]: " + e.Data + Environment.NewLine);
                                                    SetColor("[ERROR]: " + e.Data);
                                                    txtResult2.ScrollToCaret();
                                                });
                                            }
                                        };

                                        process.Start();
                                        process.BeginOutputReadLine();
                                        process.BeginErrorReadLine();

                                        // Đợi process kết thúc với timeout
                                        if (process.WaitForExit(300000)) // Timeout 5 phút
                                        {
                                            // Đợi output và error stream kết thúc
                                            outputWaitHandle.WaitOne(5000);
                                            errorWaitHandle.WaitOne(5000);

                                            string status = process.ExitCode == 0 ? "[SUCCESS]" : "[ERROR]";
                                            string logEntry = $"{status}: {fileNameWithoutExtension}";

                                            // Ghi log vào file
                                            string destinationLogPath = status == "[SUCCESS]" ? logFilePath : logErrorFilePath;
                                            File.AppendAllText(destinationLogPath, logEntry + Environment.NewLine);

                                            // Di chuyển tệp tin dựa trên trạng thái
                                            string destinationPath = status == "[SUCCESS]" ? uploadedFilePath : errorFilePath;
                                            string jarDestination = Path.Combine(destinationPath, Path.GetFileName(jarFile));
                                            string pomDestination = Path.Combine(destinationPath, Path.GetFileName(pomFile));

                                            File.Move(jarFile, jarDestination, true);
                                            File.Move(pomFile, pomDestination, true);

                                            // Hiển thị kết quả cuối cùng
                                            this.Invoke((MethodInvoker)delegate
                                            {
                                                txtResult2.AppendText(logEntry + Environment.NewLine);
                                                SetColor(logEntry);
                                                txtResult2.ScrollToCaret();

                                            });
                                        }
                                        else
                                        {
                                            // Xử lý trường hợp timeout
                                            this.Invoke((MethodInvoker)delegate
                                            {
                                                txtResult2.AppendText($"Timeout for {fileNameWithoutExtension}" + Environment.NewLine);
                                                SetColor($"[ERROR] Timeout for {fileNameWithoutExtension}");
                                                txtResult2.ScrollToCaret();
                                            });

                                            // Kill process nếu vượt quá timeout
                                            process.Kill();
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                // Ghi log lỗi
                                File.AppendAllText(logErrorFilePath, $"{fileNameWithoutExtension}: ERROR - {ex.Message}" + Environment.NewLine);

                                // Hiển thị lỗi
                                this.Invoke((MethodInvoker)delegate
                                {
                                    txtResult2.AppendText($"[ERROR] Exception for {fileNameWithoutExtension}: {ex.Message}" + Environment.NewLine);
                                    SetColor($"[ERROR] Exception for {fileNameWithoutExtension}: {ex.Message}");

                                    txtResult2.ScrollToCaret();
                                });
                            }
                        }
                    }
                });

                MessageBox.Show("Deployment process completed. Check deployment_log.txt for details.", "Deployed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                txtResult2.AppendText("[ERROR] " + ex.Message + Environment.NewLine);
                SetColor("[ERROR]  " + ex.Message);
                File.AppendAllText(logErrorFilePath, $"[ERROR] - {ex.Message}" + Environment.NewLine);
                MessageBox.Show("Error", "Deployed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void SetColor(Color color, string text)
        {
            // Get the starting and ending positions of the text you want to color
            int startPosition = txtResult2.Find(text);
            int endPosition = startPosition + text.Length;
            // Select the text
            txtResult2.Select(startPosition, endPosition - startPosition);
            // Set the color
            txtResult2.SelectionColor = color;
        }
        private void SetColor(string text)
        {
            // Find the starting position of the line
            int lineStart = txtResult2.Text.LastIndexOf(text);

            // --- Colorize DEBUG and INFO ---
            int debugIndex = text.IndexOf("[DEBUG]");
            if (debugIndex != -1)
            {
                txtResult2.Select(lineStart + debugIndex, "[DEBUG]".Length);
                txtResult2.SelectionColor = Color.Aquamarine;
            }

            int infoIndex = text.IndexOf("[INFO]");
            if (infoIndex != -1)
            {
                txtResult2.Select(lineStart + infoIndex, "[INFO]".Length);
                txtResult2.SelectionColor = Color.DodgerBlue;
            }

            int successIndex = text.IndexOf("[SUCCESS]");
            if (successIndex != -1)
            {
                txtResult2.Select(lineStart + successIndex, "[SUCCESS]".Length);
                txtResult2.SelectionColor = Color.LimeGreen;
            }

            int errorIndex = text.IndexOf("[ERROR]");
            if (errorIndex != -1)
            {
                txtResult2.Select(lineStart + errorIndex, "[ERROR]".Length);
                txtResult2.SelectionColor = Color.Red;
            }
            // --- End colorize ---
        }

        private async void btnPomDeploy_Click(object sender, EventArgs e)
        {
            try
            {
                InitValue();
                BackupLogs();
                string[] pomFiles = Directory.GetFiles(txtPath.Text, "*.pom.xml");
                
                await Task.Run((Action)(() =>
                {
                    foreach (string pomFile in pomFiles)
                    {
                        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(pomFile);

                        string jarFile = Path.Combine(folderPath, fileNameWithoutExtension.Replace(".pom",".jar"));

                        if (!File.Exists(jarFile))
                        {
                            try
                            {
                                XDocument doc = XDocument.Load(pomFile);

                                //groupId, artifactId, version
                                XElement groupIdElement = doc.Descendants(XName.Get("groupId", "http://maven.apache.org/POM/4.0.0")).FirstOrDefault();
                                XElement artifactIdElement = doc.Descendants(XName.Get("artifactId", "http://maven.apache.org/POM/4.0.0")).FirstOrDefault();
                                XElement versionElement = doc.Descendants(XName.Get("version", "http://maven.apache.org/POM/4.0.0")).FirstOrDefault();


                                string command = $"mvn -X deploy:deploy-file -s \"{txtSettingsPath.Text}\" -Dfile=\"{pomFile}\" -DrepositoryId=jfrog-artifactory -Durl=\"{deployUrl}\" -DgroupId={groupIdElement.Value} -DartifactId={artifactIdElement.Value} -Dversion={versionElement.Value} -Dpackaging=pom";

                                ProcessStartInfo processInfo = new("cmd.exe", $"/c {command}")
                                {
                                    WorkingDirectory = txtM2Home.Text,
                                    CreateNoWindow = true,
                                    UseShellExecute = false,
                                    RedirectStandardOutput = true,
                                    RedirectStandardError = true
                                };

                                using (Process process = new Process())
                                {
                                    process.StartInfo = processInfo;

                                    // Sử dụng AutoResetEvent để đồng bộ hóa
                                    using (var outputWaitHandle = new AutoResetEvent(false))
                                    using (var errorWaitHandle = new AutoResetEvent(false))
                                    {
                                        process.OutputDataReceived += (sender, e) =>
                                        {
                                            if (e.Data == null)
                                            {
                                                outputWaitHandle.Set();
                                            }
                                            else
                                            {
                                                this.Invoke((MethodInvoker)delegate
                                                {
                                                    txtResult2.AppendText(e.Data + Environment.NewLine);
                                                    SetColor(e.Data);
                                                    txtResult2.ScrollToCaret();
                                                });
                                            }
                                        };

                                        process.ErrorDataReceived += (sender, e) =>
                                        {
                                            if (e.Data == null)
                                            {
                                                errorWaitHandle.Set();
                                            }
                                            else
                                            {
                                                this.Invoke((MethodInvoker)delegate
                                                {
                                                    txtResult2.AppendText("[ERROR]: " + e.Data + Environment.NewLine);
                                                    SetColor("[ERROR]: " + e.Data);
                                                    txtResult2.ScrollToCaret();
                                                });
                                            }
                                        };

                                        process.Start();
                                        process.BeginOutputReadLine();
                                        process.BeginErrorReadLine();

                                        // Đợi process kết thúc với timeout
                                        if (process.WaitForExit(300000)) // Timeout 5 phút
                                        {
                                            // Đợi output và error stream kết thúc
                                            outputWaitHandle.WaitOne(5000);
                                            errorWaitHandle.WaitOne(5000);

                                            string status = process.ExitCode == 0 ? "[SUCCESS]" : "[ERROR]";
                                            string logEntry = $"{status}: {fileNameWithoutExtension}";

                                            // Ghi log vào file
                                            string destinationLogPath = status == "[SUCCESS]" ? logFilePath : logErrorFilePath;
                                            File.AppendAllText(destinationLogPath, logEntry + Environment.NewLine);

                                            // Di chuyển tệp tin dựa trên trạng thái
                                            string destinationPath = status == "[SUCCESS]" ? uploadedFilePath : errorFilePath;
                                            string pomDestination = Path.Combine(destinationPath, Path.GetFileName(pomFile));

                                            File.Move(pomFile, pomDestination, true);

                                            // Hiển thị kết quả cuối cùng
                                            this.Invoke((MethodInvoker)delegate
                                            {
                                                txtResult2.AppendText(logEntry + Environment.NewLine);
                                                SetColor(logEntry);
                                                txtResult2.ScrollToCaret();

                                            });
                                        }
                                        else
                                        {
                                            // Xử lý trường hợp timeout
                                            this.Invoke((MethodInvoker)delegate
                                            {
                                                txtResult2.AppendText($"Timeout for {fileNameWithoutExtension}" + Environment.NewLine);
                                                SetColor($"[ERROR] Timeout for {fileNameWithoutExtension}");
                                                txtResult2.ScrollToCaret();
                                            });

                                            // Kill process nếu vượt quá timeout
                                            process.Kill();
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                // Ghi log lỗi
                                File.AppendAllText(logErrorFilePath, $"{fileNameWithoutExtension}: ERROR - {ex.Message}" + Environment.NewLine);

                                // Hiển thị lỗi
                                this.Invoke((MethodInvoker)delegate
                                {
                                    txtResult2.AppendText($"Exception for {fileNameWithoutExtension}: {ex.Message}" + Environment.NewLine);
                                    SetColor($"[ERROR] Exception for {fileNameWithoutExtension}: {ex.Message}");

                                    txtResult2.ScrollToCaret();
                                });
                            }
                        }
                    }
                }));

                MessageBox.Show("Deployment process completed. Check deployment_log.txt for details.", "Deployed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                txtResult2.AppendText("[ERROR] " + ex.Message + Environment.NewLine);
                SetColor("[ERROR]  " + ex.Message);
                MessageBox.Show("Error", "Deployed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
