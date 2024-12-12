namespace FindFile
{
    partial class HotFixBuild
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HotFixBuild));
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.txtHFPath = new System.Windows.Forms.TextBox();
            this.btnGenHF = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPathSnapshot = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGenericInstallerXml = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtHotFixPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEnv = new System.Windows.Forms.TextBox();
            this.btnBuildDeliverablesHotFix = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSuffix = new System.Windows.Forms.TextBox();
            this.btnNewHF = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtVersion
            // 
            this.txtVersion.Location = new System.Drawing.Point(370, 56);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(132, 23);
            this.txtVersion.TabIndex = 32;
            this.txtVersion.Text = "2022.1.01.006";
            // 
            // txtHFPath
            // 
            this.txtHFPath.Location = new System.Drawing.Point(168, 12);
            this.txtHFPath.Name = "txtHFPath";
            this.txtHFPath.Size = new System.Drawing.Size(568, 23);
            this.txtHFPath.TabIndex = 30;
            this.txtHFPath.Text = "C:\\EpheSoft\\HOTFIX\\EEN-32443\\2022.1.01.006";
            // 
            // btnGenHF
            // 
            this.btnGenHF.Location = new System.Drawing.Point(588, 336);
            this.btnGenHF.Name = "btnGenHF";
            this.btnGenHF.Size = new System.Drawing.Size(148, 50);
            this.btnGenHF.TabIndex = 29;
            this.btnGenHF.Text = "3. Build HF";
            this.btnGenHF.UseVisualStyleBackColor = true;
            this.btnGenHF.Click += new System.EventHandler(this.btnGenHF_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(95, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 33;
            this.label1.Text = "Root folder";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(319, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 33;
            this.label2.Text = "Version";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(9, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 60);
            this.label4.TabIndex = 35;
            this.label4.Text = "Path of ephesoft-generic-installer-1.0-SNAPSHOT.jar";
            // 
            // txtPathSnapshot
            // 
            this.txtPathSnapshot.Location = new System.Drawing.Point(166, 157);
            this.txtPathSnapshot.Name = "txtPathSnapshot";
            this.txtPathSnapshot.Size = new System.Drawing.Size(569, 23);
            this.txtPathSnapshot.TabIndex = 34;
            this.txtPathSnapshot.Text = "C:\\EpheSoft\\products\\Transact\\transact.tools.infor.patchdeployment\\target";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 15);
            this.label5.TabIndex = 37;
            this.label5.Text = "Path of genericInstaller.xml";
            // 
            // txtGenericInstallerXml
            // 
            this.txtGenericInstallerXml.Location = new System.Drawing.Point(167, 203);
            this.txtGenericInstallerXml.Name = "txtGenericInstallerXml";
            this.txtGenericInstallerXml.Size = new System.Drawing.Size(569, 23);
            this.txtGenericInstallerXml.TabIndex = 36;
            this.txtGenericInstallerXml.Text = "C:\\EpheSoft\\products\\Transact\\transact.tools.infor.patchdeployment\\src\\main\\resou" +
    "rces\\hotfix";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(98, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 15);
            this.label6.TabIndex = 39;
            this.label6.Text = "HF sources";
            // 
            // txtHotFixPath
            // 
            this.txtHotFixPath.Location = new System.Drawing.Point(167, 114);
            this.txtHotFixPath.Name = "txtHotFixPath";
            this.txtHotFixPath.Size = new System.Drawing.Size(569, 23);
            this.txtHotFixPath.TabIndex = 38;
            this.txtHotFixPath.Text = "C:\\EpheSoft\\HOTFIX\\HF_SOURCES\\2022.1.01.006";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(137, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 15);
            this.label3.TabIndex = 41;
            this.label3.Text = "Env";
            // 
            // txtEnv
            // 
            this.txtEnv.Location = new System.Drawing.Point(169, 53);
            this.txtEnv.Name = "txtEnv";
            this.txtEnv.Size = new System.Drawing.Size(132, 23);
            this.txtEnv.TabIndex = 40;
            this.txtEnv.Text = "Windows";
            // 
            // btnBuildDeliverablesHotFix
            // 
            this.btnBuildDeliverablesHotFix.Location = new System.Drawing.Point(588, 295);
            this.btnBuildDeliverablesHotFix.Name = "btnBuildDeliverablesHotFix";
            this.btnBuildDeliverablesHotFix.Size = new System.Drawing.Size(148, 35);
            this.btnBuildDeliverablesHotFix.TabIndex = 42;
            this.btnBuildDeliverablesHotFix.Text = "1. Build deliverables";
            this.btnBuildDeliverablesHotFix.UseVisualStyleBackColor = true;
            this.btnBuildDeliverablesHotFix.Click += new System.EventHandler(this.btnBuildDeliverablesHotFix_Click);
            // 
            // label7
            // 
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(12, 255);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(570, 131);
            this.label7.TabIndex = 43;
            this.label7.Text = resources.GetString("label7.Text");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(104, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 15);
            this.label8.TabIndex = 45;
            this.label8.Text = "Lib suffix";
            // 
            // txtSuffix
            // 
            this.txtSuffix.Location = new System.Drawing.Point(165, 85);
            this.txtSuffix.Name = "txtSuffix";
            this.txtSuffix.Size = new System.Drawing.Size(136, 23);
            this.txtSuffix.TabIndex = 44;
            this.txtSuffix.Text = "-0.0.15-SNAPSHOT.jar";
            // 
            // btnNewHF
            // 
            this.btnNewHF.Location = new System.Drawing.Point(588, 245);
            this.btnNewHF.Name = "btnNewHF";
            this.btnNewHF.Size = new System.Drawing.Size(148, 35);
            this.btnNewHF.TabIndex = 46;
            this.btnNewHF.Text = "New HF";
            this.btnNewHF.UseVisualStyleBackColor = true;
            this.btnNewHF.Click += new System.EventHandler(this.btnNewHF_Click);
            // 
            // HotFixBuild
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 399);
            this.Controls.Add(this.btnNewHF);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtSuffix);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnBuildDeliverablesHotFix);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEnv);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtHotFixPath);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtGenericInstallerXml);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPathSnapshot);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtVersion);
            this.Controls.Add(this.txtHFPath);
            this.Controls.Add(this.btnGenHF);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "HotFixBuild";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HotFixBuild";
            this.Load += new System.EventHandler(this.HotFixBuild_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtVersion;
        private TextBox txtHFPath;
        private Button btnGenHF;
        private Label label1;
        private Label label2;
        private Label label4;
        private TextBox txtPathSnapshot;
        private Label label5;
        private TextBox txtGenericInstallerXml;
        private Label label6;
        private TextBox txtHotFixPath;
        private Label label3;
        private TextBox txtEnv;
        private Button btnBuildDeliverablesHotFix;
        private Label label7;
        private Label label8;
        private TextBox txtSuffix;
        private Button btnNewHF;
    }
}