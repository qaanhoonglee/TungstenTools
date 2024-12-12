namespace FindFile
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnFind = new Button();
            txtDirectory = new TextBox();
            txtFileName = new TextBox();
            txtResult = new RichTextBox();
            txtFilePath = new TextBox();
            btnChecksum = new Button();
            txtResult2 = new RichTextBox();
            btnUnzip = new Button();
            txtDirectory1 = new TextBox();
            txtFieName2 = new TextBox();
            btnFinFolder = new Button();
            btnExtractJar = new Button();
            btnNameLike = new Button();
            btnMvn = new Button();
            txtMavenArguments = new TextBox();
            btnMvnCommand = new Button();
            btnShoDependency = new Button();
            btnDependencyOne = new Button();
            btnNameContain = new Button();
            btnWebService = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            batchClassManagementToolStripMenuItem = new ToolStripMenuItem();
            getBatchClassListToolStripMenuItem = new ToolStripMenuItem();
            reportingWebServicesToolStripMenuItem = new ToolStripMenuItem();
            decryptReportingBatchXmlToolStripMenuItem = new ToolStripMenuItem();
            runReportingToolStripMenuItem = new ToolStripMenuItem();
            btnActiveLicense = new Button();
            txtMacAddress = new TextBox();
            txtAnt = new TextBox();
            btnInstallerUpgradeEphesoft = new Button();
            btnDecompiler = new Button();
            btnGenHF = new Button();
            txtEnv = new TextBox();
            txtHFPath = new TextBox();
            txtVersion = new TextBox();
            btnGenLic = new Button();
            txtLicenseVersion = new TextBox();
            btnCopy = new Button();
            txtOcr_cpu_count = new TextBox();
            label1 = new Label();
            cboOperatingSystem = new ComboBox();
            txtSearchFolder = new TextBox();
            btnSearch = new Button();
            txtSearchKey = new TextBox();
            btnHfReadme = new Button();
            btnJfrogDeploy = new Button();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // btnFind
            // 
            btnFind.Location = new Point(537, 260);
            btnFind.Name = "btnFind";
            btnFind.Size = new Size(43, 23);
            btnFind.TabIndex = 5;
            btnFind.Text = "Files";
            btnFind.UseVisualStyleBackColor = true;
            btnFind.Click += btnFind_Click;
            // 
            // txtDirectory
            // 
            txtDirectory.Location = new Point(12, 259);
            txtDirectory.Name = "txtDirectory";
            txtDirectory.Size = new Size(365, 23);
            txtDirectory.TabIndex = 3;
            txtDirectory.Text = "C:\\Users\\quanhong.le\\.m2\\repository";
            // 
            // txtFileName
            // 
            txtFileName.Location = new Point(383, 260);
            txtFileName.Name = "txtFileName";
            txtFileName.Size = new Size(148, 23);
            txtFileName.TabIndex = 4;
            // 
            // txtResult
            // 
            txtResult.Location = new Point(12, 342);
            txtResult.Name = "txtResult";
            txtResult.Size = new Size(847, 207);
            txtResult.TabIndex = 11;
            txtResult.Text = "dcma-da\ndcma-util";
            txtResult.TextChanged += txtResult_TextChanged;
            // 
            // txtFilePath
            // 
            txtFilePath.Location = new Point(865, 42);
            txtFilePath.Name = "txtFilePath";
            txtFilePath.Size = new Size(216, 23);
            txtFilePath.TabIndex = 7;
            txtFilePath.Text = "C:\\Ephesoft";
            // 
            // btnChecksum
            // 
            btnChecksum.Location = new Point(1357, 42);
            btnChecksum.Name = "btnChecksum";
            btnChecksum.Size = new Size(75, 23);
            btnChecksum.TabIndex = 9;
            btnChecksum.Text = "Full name";
            btnChecksum.UseVisualStyleBackColor = true;
            btnChecksum.Click += btnChecksum_Click;
            // 
            // txtResult2
            // 
            txtResult2.Location = new Point(865, 116);
            txtResult2.Name = "txtResult2";
            txtResult2.Size = new Size(807, 433);
            txtResult2.TabIndex = 12;
            txtResult2.Text = "";
            // 
            // btnUnzip
            // 
            btnUnzip.Location = new Point(784, 39);
            btnUnzip.Name = "btnUnzip";
            btnUnzip.Size = new Size(75, 23);
            btnUnzip.TabIndex = 1;
            btnUnzip.Text = "Unzip";
            btnUnzip.UseVisualStyleBackColor = true;
            btnUnzip.Click += btnUnzip_Click;
            // 
            // txtDirectory1
            // 
            txtDirectory1.Location = new Point(43, 11);
            txtDirectory1.Name = "txtDirectory1";
            txtDirectory1.Size = new Size(439, 23);
            txtDirectory1.TabIndex = 0;
            txtDirectory1.Text = "C:\\EpheSoft\\Resources\\0.VM_Settups\\LicenseRelease.zip";
            // 
            // txtFieName2
            // 
            txtFieName2.Location = new Point(1087, 39);
            txtFieName2.Name = "txtFieName2";
            txtFieName2.Size = new Size(183, 23);
            txtFieName2.TabIndex = 8;
            // 
            // btnFinFolder
            // 
            btnFinFolder.Location = new Point(586, 260);
            btnFinFolder.Name = "btnFinFolder";
            btnFinFolder.Size = new Size(57, 23);
            btnFinFolder.TabIndex = 6;
            btnFinFolder.Text = "Folder";
            btnFinFolder.UseVisualStyleBackColor = true;
            btnFinFolder.Click += btnFinFolder_Click;
            // 
            // btnExtractJar
            // 
            btnExtractJar.Location = new Point(784, 10);
            btnExtractJar.Name = "btnExtractJar";
            btnExtractJar.Size = new Size(75, 23);
            btnExtractJar.TabIndex = 2;
            btnExtractJar.Text = "Extract jar";
            btnExtractJar.UseVisualStyleBackColor = true;
            btnExtractJar.Click += btnExtractJar_Click;
            // 
            // btnNameLike
            // 
            btnNameLike.Location = new Point(1434, 42);
            btnNameLike.Name = "btnNameLike";
            btnNameLike.Size = new Size(111, 23);
            btnNameLike.TabIndex = 10;
            btnNameLike.Text = "* & SNAPSHOT.jar";
            btnNameLike.UseVisualStyleBackColor = true;
            btnNameLike.Click += btnNameLike_Click;
            // 
            // btnMvn
            // 
            btnMvn.Location = new Point(865, 11);
            btnMvn.Name = "btnMvn";
            btnMvn.Size = new Size(104, 23);
            btnMvn.TabIndex = 13;
            btnMvn.Text = "mvn run build";
            btnMvn.UseVisualStyleBackColor = true;
            btnMvn.Click += btnMvn_Click;
            // 
            // txtMavenArguments
            // 
            txtMavenArguments.Location = new Point(1514, 14);
            txtMavenArguments.Margin = new Padding(3, 2, 3, 2);
            txtMavenArguments.Name = "txtMavenArguments";
            txtMavenArguments.Size = new Size(158, 23);
            txtMavenArguments.TabIndex = 14;
            txtMavenArguments.Text = "mvn install -DskipTests";
            // 
            // btnMvnCommand
            // 
            btnMvnCommand.Location = new Point(1374, 16);
            btnMvnCommand.Margin = new Padding(3, 2, 3, 2);
            btnMvnCommand.Name = "btnMvnCommand";
            btnMvnCommand.Size = new Size(71, 21);
            btnMvnCommand.TabIndex = 15;
            btnMvnCommand.Text = "Text build";
            btnMvnCommand.UseVisualStyleBackColor = true;
            btnMvnCommand.Click += btnMvnCommand_Click;
            // 
            // btnShoDependency
            // 
            btnShoDependency.Location = new Point(975, 10);
            btnShoDependency.Name = "btnShoDependency";
            btnShoDependency.Size = new Size(131, 23);
            btnShoDependency.TabIndex = 16;
            btnShoDependency.Text = "Show All dependency";
            btnShoDependency.UseVisualStyleBackColor = true;
            btnShoDependency.Click += btnShoDependency_Click;
            // 
            // btnDependencyOne
            // 
            btnDependencyOne.Location = new Point(1112, 11);
            btnDependencyOne.Name = "btnDependencyOne";
            btnDependencyOne.Size = new Size(122, 23);
            btnDependencyOne.TabIndex = 17;
            btnDependencyOne.Text = "Show Dependency";
            btnDependencyOne.UseVisualStyleBackColor = true;
            btnDependencyOne.Click += btnDependencyOne_Click;
            // 
            // btnNameContain
            // 
            btnNameContain.Location = new Point(1276, 39);
            btnNameContain.Name = "btnNameContain";
            btnNameContain.Size = new Size(75, 23);
            btnNameContain.TabIndex = 18;
            btnNameContain.Text = "Name like";
            btnNameContain.UseVisualStyleBackColor = true;
            btnNameContain.Click += btnNameContain_Click;
            // 
            // btnWebService
            // 
            btnWebService.Location = new Point(744, 300);
            btnWebService.Name = "btnWebService";
            btnWebService.Size = new Size(75, 23);
            btnWebService.TabIndex = 19;
            btnWebService.Text = "Web service";
            btnWebService.UseVisualStyleBackColor = true;
            btnWebService.Click += btnWebService_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { batchClassManagementToolStripMenuItem, reportingWebServicesToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(209, 48);
            // 
            // batchClassManagementToolStripMenuItem
            // 
            batchClassManagementToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { getBatchClassListToolStripMenuItem });
            batchClassManagementToolStripMenuItem.Name = "batchClassManagementToolStripMenuItem";
            batchClassManagementToolStripMenuItem.Size = new Size(208, 22);
            batchClassManagementToolStripMenuItem.Text = "Batch Class Management";
            // 
            // getBatchClassListToolStripMenuItem
            // 
            getBatchClassListToolStripMenuItem.Name = "getBatchClassListToolStripMenuItem";
            getBatchClassListToolStripMenuItem.Size = new Size(166, 22);
            getBatchClassListToolStripMenuItem.Text = "getBatchClassList";
            getBatchClassListToolStripMenuItem.Click += getBatchClassListToolStripMenuItem_Click;
            // 
            // reportingWebServicesToolStripMenuItem
            // 
            reportingWebServicesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { decryptReportingBatchXmlToolStripMenuItem, runReportingToolStripMenuItem });
            reportingWebServicesToolStripMenuItem.Name = "reportingWebServicesToolStripMenuItem";
            reportingWebServicesToolStripMenuItem.Size = new Size(208, 22);
            reportingWebServicesToolStripMenuItem.Text = "Reporting Web Services";
            // 
            // decryptReportingBatchXmlToolStripMenuItem
            // 
            decryptReportingBatchXmlToolStripMenuItem.Name = "decryptReportingBatchXmlToolStripMenuItem";
            decryptReportingBatchXmlToolStripMenuItem.Size = new Size(217, 22);
            decryptReportingBatchXmlToolStripMenuItem.Text = "decryptReportingBatchXml";
            // 
            // runReportingToolStripMenuItem
            // 
            runReportingToolStripMenuItem.Name = "runReportingToolStripMenuItem";
            runReportingToolStripMenuItem.Size = new Size(217, 22);
            runReportingToolStripMenuItem.Text = "runReporting";
            // 
            // btnActiveLicense
            // 
            btnActiveLicense.Location = new Point(578, 9);
            btnActiveLicense.Name = "btnActiveLicense";
            btnActiveLicense.Size = new Size(67, 51);
            btnActiveLicense.TabIndex = 20;
            btnActiveLicense.Text = "Active license";
            btnActiveLicense.UseVisualStyleBackColor = true;
            btnActiveLicense.Click += btnActiveLicense_Click;
            // 
            // txtMacAddress
            // 
            txtMacAddress.Location = new Point(43, 70);
            txtMacAddress.Name = "txtMacAddress";
            txtMacAddress.Size = new Size(147, 23);
            txtMacAddress.TabIndex = 21;
            txtMacAddress.Text = "88-A4-C2-13-58-98";
            // 
            // txtAnt
            // 
            txtAnt.Location = new Point(43, 40);
            txtAnt.Name = "txtAnt";
            txtAnt.Size = new Size(439, 23);
            txtAnt.TabIndex = 22;
            txtAnt.Text = "C:\\jdks\\apache-ant-1.10.14\\bin";
            // 
            // btnInstallerUpgradeEphesoft
            // 
            btnInstallerUpgradeEphesoft.Location = new Point(507, 70);
            btnInstallerUpgradeEphesoft.Name = "btnInstallerUpgradeEphesoft";
            btnInstallerUpgradeEphesoft.Size = new Size(127, 48);
            btnInstallerUpgradeEphesoft.TabIndex = 23;
            btnInstallerUpgradeEphesoft.Text = "Installer UpgradeEphesoft.jar";
            btnInstallerUpgradeEphesoft.UseVisualStyleBackColor = true;
            btnInstallerUpgradeEphesoft.Click += btnInstallerUpgradeEphesoft_Click;
            // 
            // btnDecompiler
            // 
            btnDecompiler.Location = new Point(784, 69);
            btnDecompiler.Name = "btnDecompiler";
            btnDecompiler.Size = new Size(75, 23);
            btnDecompiler.TabIndex = 24;
            btnDecompiler.Text = "decompiler";
            btnDecompiler.UseVisualStyleBackColor = true;
            btnDecompiler.Click += btnDecompiler_Click;
            // 
            // btnGenHF
            // 
            btnGenHF.Location = new Point(534, 299);
            btnGenHF.Name = "btnGenHF";
            btnGenHF.Size = new Size(100, 24);
            btnGenHF.TabIndex = 25;
            btnGenHF.Text = "Build HF";
            btnGenHF.UseVisualStyleBackColor = true;
            btnGenHF.Click += btnGenHF_Click;
            // 
            // txtEnv
            // 
            txtEnv.Location = new Point(7, 299);
            txtEnv.Name = "txtEnv";
            txtEnv.Size = new Size(83, 23);
            txtEnv.TabIndex = 26;
            txtEnv.Text = "Windows";
            txtEnv.TextChanged += txtEnv_TextChanged;
            // 
            // txtHFPath
            // 
            txtHFPath.Location = new Point(209, 299);
            txtHFPath.Name = "txtHFPath";
            txtHFPath.Size = new Size(310, 23);
            txtHFPath.TabIndex = 26;
            txtHFPath.Text = "C:\\EpheSoft\\HOTFIX\\EEN-32443-HF-2022.1.01.006";
            txtHFPath.TextChanged += txtHFPath_TextChanged;
            // 
            // txtVersion
            // 
            txtVersion.Location = new Point(96, 300);
            txtVersion.Name = "txtVersion";
            txtVersion.Size = new Size(107, 23);
            txtVersion.TabIndex = 27;
            txtVersion.Text = "2022.1.01.006";
            txtVersion.TextChanged += txtVersion_TextChanged;
            // 
            // btnGenLic
            // 
            btnGenLic.Location = new Point(488, 12);
            btnGenLic.Name = "btnGenLic";
            btnGenLic.Size = new Size(75, 44);
            btnGenLic.TabIndex = 28;
            btnGenLic.Text = "Gen .lic";
            btnGenLic.UseVisualStyleBackColor = true;
            btnGenLic.Click += btnGenLic_Click;
            // 
            // txtLicenseVersion
            // 
            txtLicenseVersion.Location = new Point(403, 71);
            txtLicenseVersion.Name = "txtLicenseVersion";
            txtLicenseVersion.Size = new Size(79, 23);
            txtLicenseVersion.TabIndex = 29;
            txtLicenseVersion.Text = "2023.1.00";
            // 
            // btnCopy
            // 
            btnCopy.Location = new Point(627, 159);
            btnCopy.Name = "btnCopy";
            btnCopy.Size = new Size(192, 23);
            btnCopy.TabIndex = 30;
            btnCopy.Text = "Copy -0.0.15-SNAPSHOT.jar";
            btnCopy.UseVisualStyleBackColor = true;
            btnCopy.Click += btnCopy_Click;
            // 
            // txtOcr_cpu_count
            // 
            txtOcr_cpu_count.Location = new Point(230, 70);
            txtOcr_cpu_count.Name = "txtOcr_cpu_count";
            txtOcr_cpu_count.Size = new Size(30, 23);
            txtOcr_cpu_count.TabIndex = 31;
            txtOcr_cpu_count.Text = "4";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(189, 74);
            label1.Name = "label1";
            label1.Size = new Size(30, 15);
            label1.TabIndex = 32;
            label1.Text = "CPU";
            // 
            // cboOperatingSystem
            // 
            cboOperatingSystem.FormattingEnabled = true;
            cboOperatingSystem.Items.AddRange(new object[] { "Windows", "Linux", "Windows & Linux" });
            cboOperatingSystem.Location = new Point(276, 71);
            cboOperatingSystem.Name = "cboOperatingSystem";
            cboOperatingSystem.Size = new Size(121, 23);
            cboOperatingSystem.TabIndex = 33;
            // 
            // txtSearchFolder
            // 
            txtSearchFolder.Location = new Point(865, 87);
            txtSearchFolder.Name = "txtSearchFolder";
            txtSearchFolder.Size = new Size(278, 23);
            txtSearchFolder.TabIndex = 34;
            txtSearchFolder.Text = "C:\\EpheSoft\\products\\Transact";
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(1276, 87);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 35;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearchKey
            // 
            txtSearchKey.Location = new Point(1149, 87);
            txtSearchKey.Name = "txtSearchKey";
            txtSearchKey.Size = new Size(121, 23);
            txtSearchKey.TabIndex = 36;
            txtSearchKey.Text = "itextpdf";
            // 
            // btnHfReadme
            // 
            btnHfReadme.Location = new Point(651, 13);
            btnHfReadme.Name = "btnHfReadme";
            btnHfReadme.Size = new Size(127, 47);
            btnHfReadme.TabIndex = 37;
            btnHfReadme.Text = "Build HF readme HTML";
            btnHfReadme.UseVisualStyleBackColor = true;
            btnHfReadme.Click += btnHfReadme_Click;
            // 
            // btnJfrogDeploy
            // 
            btnJfrogDeploy.Location = new Point(640, 74);
            btnJfrogDeploy.Name = "btnJfrogDeploy";
            btnJfrogDeploy.Size = new Size(91, 44);
            btnJfrogDeploy.TabIndex = 38;
            btnJfrogDeploy.Text = "JFROG Deploy";
            btnJfrogDeploy.UseVisualStyleBackColor = true;
            btnJfrogDeploy.Click += btnJfrogDeploy_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1684, 562);
            Controls.Add(btnJfrogDeploy);
            Controls.Add(btnHfReadme);
            Controls.Add(txtSearchKey);
            Controls.Add(btnSearch);
            Controls.Add(txtSearchFolder);
            Controls.Add(cboOperatingSystem);
            Controls.Add(label1);
            Controls.Add(txtOcr_cpu_count);
            Controls.Add(btnCopy);
            Controls.Add(txtLicenseVersion);
            Controls.Add(btnGenLic);
            Controls.Add(txtVersion);
            Controls.Add(txtHFPath);
            Controls.Add(txtEnv);
            Controls.Add(btnGenHF);
            Controls.Add(btnDecompiler);
            Controls.Add(btnInstallerUpgradeEphesoft);
            Controls.Add(txtAnt);
            Controls.Add(txtMacAddress);
            Controls.Add(btnActiveLicense);
            Controls.Add(btnWebService);
            Controls.Add(btnNameContain);
            Controls.Add(btnDependencyOne);
            Controls.Add(btnShoDependency);
            Controls.Add(btnMvnCommand);
            Controls.Add(txtMavenArguments);
            Controls.Add(btnMvn);
            Controls.Add(btnNameLike);
            Controls.Add(btnExtractJar);
            Controls.Add(txtFieName2);
            Controls.Add(txtResult2);
            Controls.Add(txtFilePath);
            Controls.Add(btnChecksum);
            Controls.Add(txtResult);
            Controls.Add(txtFileName);
            Controls.Add(txtDirectory1);
            Controls.Add(txtDirectory);
            Controls.Add(btnUnzip);
            Controls.Add(btnFinFolder);
            Controls.Add(btnFind);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnFind;
        private TextBox txtDirectory;
        private TextBox txtFileName;
        private RichTextBox txtResult;
        private TextBox txtFilePath;
        private Button btnChecksum;
        private RichTextBox txtResult2;
        private Button btnUnzip;
        private TextBox txtDirectory1;
        private TextBox txtFieName2;
        private Button btnFinFolder;
        private Button btnExtractJar;
        private Button btnNameLike;
        private Button btnMvn;
        private TextBox txtMavenArguments;
        private Button btnMvnCommand;
        private Button btnShoDependency;
        private Button btnDependencyOne;
        private Button btnNameContain;
        private Button btnWebService;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem reportingWebServicesToolStripMenuItem;
        private ToolStripMenuItem decryptReportingBatchXmlToolStripMenuItem;
        private ToolStripMenuItem runReportingToolStripMenuItem;
        private ToolStripMenuItem batchClassManagementToolStripMenuItem;
        private ToolStripMenuItem getBatchClassListToolStripMenuItem;
        private Button btnActiveLicense;
        private TextBox txtMacAddress;
        private TextBox txtAnt;
        private Button btnInstallerUpgradeEphesoft;
        private Button btnDecompiler;
        private Button btnGenHF;
        private TextBox txtEnv;
        private TextBox txtHFPath;
        private TextBox txtVersion;
        private Button btnGenLic;
        private TextBox txtLicenseVersion;
        private Button btnCopy;
        private TextBox txtOcr_cpu_count;
        private Label label1;
        private ComboBox cboOperatingSystem;
        private TextBox textBox1;
        private TextBox txtSearchFolder;
        private Button btnSearch;
        private TextBox txtSearchKey;
        private Button btnHfReadme;
        private Button btnJfrogDeploy;
    }
}