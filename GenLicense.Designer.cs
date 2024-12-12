namespace FindFile
{
    partial class GenLicense
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
            label2 = new Label();
            txtIDEAnnuaImageCount = new TextBox();
            txtServerAnnuaImageCount = new TextBox();
            label3 = new Label();
            txtICRPlusAnnualImageCount = new TextBox();
            label4 = new Label();
            txtLicenseExpiryDate = new TextBox();
            lblLicenseExpiryDate = new Label();
            txtIDExpiryDate = new TextBox();
            lblIDExpiryDate = new Label();
            cboIdeSwitch = new ComboBox();
            label5 = new Label();
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
            btnFind.Visible = false;
            btnFind.Click += btnFind_Click;
            // 
            // txtDirectory
            // 
            txtDirectory.Location = new Point(12, 259);
            txtDirectory.Name = "txtDirectory";
            txtDirectory.Size = new Size(365, 23);
            txtDirectory.TabIndex = 3;
            txtDirectory.Text = "C:\\Users\\quanhong.le\\.m2\\repository";
            txtDirectory.Visible = false;
            // 
            // txtFileName
            // 
            txtFileName.Location = new Point(383, 260);
            txtFileName.Name = "txtFileName";
            txtFileName.Size = new Size(148, 23);
            txtFileName.TabIndex = 4;
            txtFileName.Visible = false;
            // 
            // txtResult
            // 
            txtResult.Location = new Point(7, 144);
            txtResult.Name = "txtResult";
            txtResult.Size = new Size(638, 194);
            txtResult.TabIndex = 11;
            txtResult.Text = "";
            txtResult.TextChanged += txtResult_TextChanged;
            // 
            // txtFilePath
            // 
            txtFilePath.Location = new Point(865, 42);
            txtFilePath.Name = "txtFilePath";
            txtFilePath.Size = new Size(216, 23);
            txtFilePath.TabIndex = 7;
            txtFilePath.Text = "C:\\Ephesoft";
            txtFilePath.Visible = false;
            // 
            // btnChecksum
            // 
            btnChecksum.Location = new Point(1357, 42);
            btnChecksum.Name = "btnChecksum";
            btnChecksum.Size = new Size(75, 23);
            btnChecksum.TabIndex = 9;
            btnChecksum.Text = "Full name";
            btnChecksum.UseVisualStyleBackColor = true;
            btnChecksum.Visible = false;
            btnChecksum.Click += btnChecksum_Click;
            // 
            // txtResult2
            // 
            txtResult2.Location = new Point(865, 116);
            txtResult2.Name = "txtResult2";
            txtResult2.Size = new Size(807, 433);
            txtResult2.TabIndex = 12;
            txtResult2.Text = "";
            txtResult2.Visible = false;
            // 
            // btnUnzip
            // 
            btnUnzip.Location = new Point(784, 39);
            btnUnzip.Name = "btnUnzip";
            btnUnzip.Size = new Size(75, 23);
            btnUnzip.TabIndex = 1;
            btnUnzip.Text = "Unzip";
            btnUnzip.UseVisualStyleBackColor = true;
            btnUnzip.Visible = false;
            btnUnzip.Click += btnUnzip_Click;
            // 
            // txtFieName2
            // 
            txtFieName2.Location = new Point(1087, 39);
            txtFieName2.Name = "txtFieName2";
            txtFieName2.Size = new Size(183, 23);
            txtFieName2.TabIndex = 8;
            txtFieName2.Visible = false;
            // 
            // btnFinFolder
            // 
            btnFinFolder.Location = new Point(586, 260);
            btnFinFolder.Name = "btnFinFolder";
            btnFinFolder.Size = new Size(57, 23);
            btnFinFolder.TabIndex = 6;
            btnFinFolder.Text = "Folder";
            btnFinFolder.UseVisualStyleBackColor = true;
            btnFinFolder.Visible = false;
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
            btnExtractJar.Visible = false;
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
            btnNameLike.Visible = false;
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
            btnMvn.Visible = false;
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
            txtMavenArguments.Visible = false;
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
            btnMvnCommand.Visible = false;
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
            btnShoDependency.Visible = false;
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
            btnDependencyOne.Visible = false;
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
            btnNameContain.Visible = false;
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
            btnWebService.Visible = false;
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
            btnActiveLicense.Location = new Point(584, 87);
            btnActiveLicense.Name = "btnActiveLicense";
            btnActiveLicense.Size = new Size(78, 51);
            btnActiveLicense.TabIndex = 20;
            btnActiveLicense.Text = "Active license";
            btnActiveLicense.UseVisualStyleBackColor = true;
            btnActiveLicense.Click += btnActiveLicense_Click;
            // 
            // txtMacAddress
            // 
            txtMacAddress.Location = new Point(44, 12);
            txtMacAddress.Name = "txtMacAddress";
            txtMacAddress.Size = new Size(147, 23);
            txtMacAddress.TabIndex = 21;
            txtMacAddress.Text = "88-A4-C2-13-58-98";
            // 
            // btnInstallerUpgradeEphesoft
            // 
            btnInstallerUpgradeEphesoft.Location = new Point(732, 105);
            btnInstallerUpgradeEphesoft.Name = "btnInstallerUpgradeEphesoft";
            btnInstallerUpgradeEphesoft.Size = new Size(127, 48);
            btnInstallerUpgradeEphesoft.TabIndex = 23;
            btnInstallerUpgradeEphesoft.Text = "Installer UpgradeEphesoft.jar";
            btnInstallerUpgradeEphesoft.UseVisualStyleBackColor = true;
            btnInstallerUpgradeEphesoft.Visible = false;
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
            btnDecompiler.Visible = false;
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
            btnGenHF.Visible = false;
            btnGenHF.Click += btnGenHF_Click;
            // 
            // txtEnv
            // 
            txtEnv.Location = new Point(7, 299);
            txtEnv.Name = "txtEnv";
            txtEnv.Size = new Size(83, 23);
            txtEnv.TabIndex = 26;
            txtEnv.Text = "Windows";
            txtEnv.Visible = false;
            txtEnv.TextChanged += txtEnv_TextChanged;
            // 
            // txtHFPath
            // 
            txtHFPath.Location = new Point(209, 299);
            txtHFPath.Name = "txtHFPath";
            txtHFPath.Size = new Size(310, 23);
            txtHFPath.TabIndex = 26;
            txtHFPath.Text = "C:\\EpheSoft\\HOTFIX\\EEN-32443-HF-2022.1.01.006";
            txtHFPath.Visible = false;
            txtHFPath.TextChanged += txtHFPath_TextChanged;
            // 
            // txtVersion
            // 
            txtVersion.Location = new Point(96, 300);
            txtVersion.Name = "txtVersion";
            txtVersion.Size = new Size(107, 23);
            txtVersion.TabIndex = 27;
            txtVersion.Text = "2022.1.01.006";
            txtVersion.Visible = false;
            txtVersion.TextChanged += txtVersion_TextChanged;
            // 
            // btnGenLic
            // 
            btnGenLic.Location = new Point(586, 12);
            btnGenLic.Name = "btnGenLic";
            btnGenLic.Size = new Size(78, 51);
            btnGenLic.TabIndex = 28;
            btnGenLic.Text = "Gen .lic";
            btnGenLic.UseVisualStyleBackColor = true;
            btnGenLic.Click += btnGenLic_Click;
            // 
            // txtLicenseVersion
            // 
            txtLicenseVersion.Location = new Point(403, 13);
            txtLicenseVersion.Name = "txtLicenseVersion";
            txtLicenseVersion.Size = new Size(79, 23);
            txtLicenseVersion.TabIndex = 29;
            txtLicenseVersion.Text = "2023.1.00";
            // 
            // btnCopy
            // 
            btnCopy.Location = new Point(676, 172);
            btnCopy.Name = "btnCopy";
            btnCopy.Size = new Size(192, 23);
            btnCopy.TabIndex = 30;
            btnCopy.Text = "Copy -0.0.15-SNAPSHOT.jar";
            btnCopy.UseVisualStyleBackColor = true;
            btnCopy.Visible = false;
            btnCopy.Click += btnCopy_Click;
            // 
            // txtOcr_cpu_count
            // 
            txtOcr_cpu_count.Location = new Point(236, 12);
            txtOcr_cpu_count.Name = "txtOcr_cpu_count";
            txtOcr_cpu_count.Size = new Size(30, 23);
            txtOcr_cpu_count.TabIndex = 31;
            txtOcr_cpu_count.Text = "4";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(195, 16);
            label1.Name = "label1";
            label1.Size = new Size(30, 15);
            label1.TabIndex = 32;
            label1.Text = "CPU";
            // 
            // cboOperatingSystem
            // 
            cboOperatingSystem.FormattingEnabled = true;
            cboOperatingSystem.Items.AddRange(new object[] { "Windows", "Linux", "Windows & Linux" });
            cboOperatingSystem.Location = new Point(276, 13);
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
            txtSearchFolder.Visible = false;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(1276, 87);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 35;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Visible = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearchKey
            // 
            txtSearchKey.Location = new Point(1149, 87);
            txtSearchKey.Name = "txtSearchKey";
            txtSearchKey.Size = new Size(121, 23);
            txtSearchKey.TabIndex = 36;
            txtSearchKey.Text = "itextpdf";
            txtSearchKey.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(39, 80);
            label2.Name = "label2";
            label2.Size = new Size(133, 15);
            label2.TabIndex = 37;
            label2.Text = "IDE annual image count";
            // 
            // txtIDEAnnuaImageCount
            // 
            txtIDEAnnuaImageCount.Location = new Point(209, 77);
            txtIDEAnnuaImageCount.Name = "txtIDEAnnuaImageCount";
            txtIDEAnnuaImageCount.Size = new Size(75, 23);
            txtIDEAnnuaImageCount.TabIndex = 38;
            txtIDEAnnuaImageCount.Text = "10";
            // 
            // txtServerAnnuaImageCount
            // 
            txtServerAnnuaImageCount.Location = new Point(209, 48);
            txtServerAnnuaImageCount.Name = "txtServerAnnuaImageCount";
            txtServerAnnuaImageCount.Size = new Size(75, 23);
            txtServerAnnuaImageCount.TabIndex = 40;
            txtServerAnnuaImageCount.Text = "10";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(39, 51);
            label3.Name = "label3";
            label3.Size = new Size(148, 15);
            label3.TabIndex = 39;
            label3.Text = "Server annual image count";
            // 
            // txtICRPlusAnnualImageCount
            // 
            txtICRPlusAnnualImageCount.Location = new Point(209, 106);
            txtICRPlusAnnualImageCount.Name = "txtICRPlusAnnualImageCount";
            txtICRPlusAnnualImageCount.Size = new Size(75, 23);
            txtICRPlusAnnualImageCount.TabIndex = 42;
            txtICRPlusAnnualImageCount.Text = "10";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(39, 109);
            label4.Name = "label4";
            label4.Size = new Size(159, 15);
            label4.TabIndex = 41;
            label4.Text = "ICR Plus annual image count";
            // 
            // txtLicenseExpiryDate
            // 
            txtLicenseExpiryDate.Location = new Point(424, 48);
            txtLicenseExpiryDate.Name = "txtLicenseExpiryDate";
            txtLicenseExpiryDate.Size = new Size(154, 23);
            txtLicenseExpiryDate.TabIndex = 44;
            txtLicenseExpiryDate.Text = "December 30 2030";
            // 
            // lblLicenseExpiryDate
            // 
            lblLicenseExpiryDate.AutoSize = true;
            lblLicenseExpiryDate.Location = new Point(290, 51);
            lblLicenseExpiryDate.Name = "lblLicenseExpiryDate";
            lblLicenseExpiryDate.Size = new Size(108, 15);
            lblLicenseExpiryDate.TabIndex = 43;
            lblLicenseExpiryDate.Text = "License Expiry Date";
            // 
            // txtIDExpiryDate
            // 
            txtIDExpiryDate.Location = new Point(424, 80);
            txtIDExpiryDate.Name = "txtIDExpiryDate";
            txtIDExpiryDate.Size = new Size(154, 23);
            txtIDExpiryDate.TabIndex = 46;
            txtIDExpiryDate.Text = "December 30 2030";
            // 
            // lblIDExpiryDate
            // 
            lblIDExpiryDate.AutoSize = true;
            lblIDExpiryDate.Location = new Point(290, 85);
            lblIDExpiryDate.Name = "lblIDExpiryDate";
            lblIDExpiryDate.Size = new Size(128, 15);
            lblIDExpiryDate.TabIndex = 45;
            lblIDExpiryDate.Text = "IDE License Expiry Date";
            // 
            // cboIdeSwitch
            // 
            cboIdeSwitch.FormattingEnabled = true;
            cboIdeSwitch.Items.AddRange(new object[] { "ON", "OFF" });
            cboIdeSwitch.Location = new Point(424, 109);
            cboIdeSwitch.Name = "cboIdeSwitch";
            cboIdeSwitch.Size = new Size(121, 23);
            cboIdeSwitch.TabIndex = 47;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(290, 112);
            label5.Name = "label5";
            label5.Size = new Size(62, 15);
            label5.TabIndex = 45;
            label5.Text = "IDE Switch";
            // 
            // GenLicense
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(674, 345);
            Controls.Add(cboIdeSwitch);
            Controls.Add(txtIDExpiryDate);
            Controls.Add(label5);
            Controls.Add(lblIDExpiryDate);
            Controls.Add(txtLicenseExpiryDate);
            Controls.Add(lblLicenseExpiryDate);
            Controls.Add(txtICRPlusAnnualImageCount);
            Controls.Add(label4);
            Controls.Add(txtServerAnnuaImageCount);
            Controls.Add(label3);
            Controls.Add(txtIDEAnnuaImageCount);
            Controls.Add(label2);
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
            Controls.Add(txtDirectory);
            Controls.Add(btnUnzip);
            Controls.Add(btnFinFolder);
            Controls.Add(btnFind);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "GenLicense";
            Text = "Form1";
            Load += GenLicense_Load;
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
        private TextBox txtICRPlusAnnualImageCount;
        private TextBox txtSearchFolder;
        private Button btnSearch;
        private TextBox txtSearchKey;
        private Label label2;
        private TextBox txtIDEAnnuaImageCount;
        private TextBox txtServerAnnuaImageCount;
        private Label label3;
        private Label label4;
        private TextBox txtLicenseExpiryDate;
        private Label lblLicenseExpiryDate;
        private TextBox txtIDExpiryDate;
        private Label lblIDExpiryDate;
        private ComboBox cboIdeSwitch;
        private Label label5;
    }
}