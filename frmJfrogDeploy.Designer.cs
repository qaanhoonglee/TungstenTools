namespace FindFile
{
    partial class frmJfrogDeploy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmJfrogDeploy));
            btnDeploy = new Button();
            txtPath = new TextBox();
            label1 = new Label();
            txtDeployUrl = new TextBox();
            label2 = new Label();
            txtSettingsPath = new TextBox();
            label3 = new Label();
            txtResult2 = new RichTextBox();
            txtM2Home = new TextBox();
            label4 = new Label();
            btnPomDeploy = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnDeploy
            // 
            btnDeploy.FlatStyle = FlatStyle.Popup;
            btnDeploy.Location = new Point(589, 84);
            btnDeploy.Name = "btnDeploy";
            btnDeploy.Size = new Size(125, 81);
            btnDeploy.TabIndex = 0;
            btnDeploy.Text = "JAR Deploy";
            btnDeploy.UseVisualStyleBackColor = true;
            btnDeploy.Click += btnDeploy_Click;
            // 
            // txtPath
            // 
            txtPath.Location = new Point(125, 83);
            txtPath.Name = "txtPath";
            txtPath.Size = new Size(458, 23);
            txtPath.TabIndex = 1;
            txtPath.Text = "C:\\MyGet2JFrog\\myGetArtifacts";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 86);
            label1.Name = "label1";
            label1.Size = new Size(108, 15);
            label1.TabIndex = 0;
            label1.Text = "Dependencies path";
            // 
            // txtDeployUrl
            // 
            txtDeployUrl.Location = new Point(125, 112);
            txtDeployUrl.Name = "txtDeployUrl";
            txtDeployUrl.Size = new Size(458, 23);
            txtDeployUrl.TabIndex = 3;
            txtDeployUrl.Text = "http://us01cmsysart01:8082/artifactory/transact-thirdparty";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 112);
            label2.Name = "label2";
            label2.Size = new Size(34, 15);
            label2.TabIndex = 2;
            label2.Text = "Repo";
            // 
            // txtSettingsPath
            // 
            txtSettingsPath.Location = new Point(125, 141);
            txtSettingsPath.Name = "txtSettingsPath";
            txtSettingsPath.Size = new Size(458, 23);
            txtSettingsPath.TabIndex = 5;
            txtSettingsPath.Text = "C:\\MyGet2JFrog\\settings_ad.xml";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 144);
            label3.Name = "label3";
            label3.Size = new Size(76, 15);
            label3.TabIndex = 4;
            label3.Text = "Settings path";
            // 
            // txtResult2
            // 
            txtResult2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtResult2.BackColor = Color.Black;
            txtResult2.ForeColor = SystemColors.Window;
            txtResult2.Location = new Point(12, 220);
            txtResult2.Name = "txtResult2";
            txtResult2.ReadOnly = true;
            txtResult2.Size = new Size(844, 572);
            txtResult2.TabIndex = 7;
            txtResult2.Text = "";
            // 
            // txtM2Home
            // 
            txtM2Home.Location = new Point(125, 170);
            txtM2Home.Name = "txtM2Home";
            txtM2Home.Size = new Size(458, 23);
            txtM2Home.TabIndex = 9;
            txtM2Home.Text = "C:\\MyGet2JFrog\\apache-maven-3.8.7\\bin";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 173);
            label4.Name = "label4";
            label4.Size = new Size(64, 15);
            label4.TabIndex = 8;
            label4.Text = "M2_HOME";
            // 
            // btnPomDeploy
            // 
            btnPomDeploy.FlatStyle = FlatStyle.Popup;
            btnPomDeploy.Location = new Point(732, 86);
            btnPomDeploy.Name = "btnPomDeploy";
            btnPomDeploy.Size = new Size(125, 81);
            btnPomDeploy.TabIndex = 0;
            btnPomDeploy.Text = "POM Deploy";
            btnPomDeploy.UseVisualStyleBackColor = true;
            btnPomDeploy.Click += btnPomDeploy_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.banner;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(868, 78);
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // frmJfrogDeploy
            // 
            AcceptButton = btnDeploy;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(868, 804);
            Controls.Add(txtM2Home);
            Controls.Add(label4);
            Controls.Add(txtResult2);
            Controls.Add(txtSettingsPath);
            Controls.Add(label3);
            Controls.Add(txtDeployUrl);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtPath);
            Controls.Add(btnPomDeploy);
            Controls.Add(btnDeploy);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmJfrogDeploy";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "JFROG Deploy";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnDeploy;
        private TextBox txtPath;
        private Label label1;
        private TextBox txtDeployUrl;
        private Label label2;
        private TextBox txtSettingsPath;
        private Label label3;
        private RichTextBox txtResult2;
        private TextBox txtM2Home;
        private Label label4;
        private Button btnPomDeploy;
        private PictureBox pictureBox1;
    }
}