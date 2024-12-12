namespace FindFile
{
    partial class hfReadme
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
            label1 = new Label();
            txtOosId = new TextBox();
            txtReleaseVersion = new TextBox();
            label2 = new Label();
            txtJarsForDrop = new TextBox();
            label3 = new Label();
            label4 = new Label();
            txtBugId = new TextBox();
            label5 = new Label();
            txtBugName = new TextBox();
            label6 = new Label();
            txtBugSolution = new TextBox();
            btnCreate = new Button();
            txtFilesForDrop = new TextBox();
            label7 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(100, 30);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 0;
            label1.Text = "OOS_ID";
            // 
            // txtOosId
            // 
            txtOosId.Location = new Point(153, 27);
            txtOosId.Name = "txtOosId";
            txtOosId.Size = new Size(219, 23);
            txtOosId.TabIndex = 1;
            txtOosId.Text = "26966784";
            // 
            // txtReleaseVersion
            // 
            txtReleaseVersion.Location = new Point(538, 30);
            txtReleaseVersion.Name = "txtReleaseVersion";
            txtReleaseVersion.Size = new Size(188, 23);
            txtReleaseVersion.TabIndex = 3;
            txtReleaseVersion.Text = "2022.1.01.006";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(428, 35);
            label2.Name = "label2";
            label2.Size = new Size(104, 15);
            label2.TabIndex = 2;
            label2.Text = "RELEASE_VERSION";
            // 
            // txtJarsForDrop
            // 
            txtJarsForDrop.Location = new Point(153, 232);
            txtJarsForDrop.Multiline = true;
            txtJarsForDrop.Name = "txtJarsForDrop";
            txtJarsForDrop.Size = new Size(573, 74);
            txtJarsForDrop.TabIndex = 11;
            txtJarsForDrop.Text = "dcma-imagemagick";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(52, 235);
            label3.Name = "label3";
            label3.Size = new Size(95, 15);
            label3.TabIndex = 10;
            label3.Text = "JARS_FOR_DROP";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(101, 69);
            label4.Name = "label4";
            label4.Size = new Size(46, 15);
            label4.TabIndex = 4;
            label4.Text = "BUG_ID";
            // 
            // txtBugId
            // 
            txtBugId.Location = new Point(153, 66);
            txtBugId.Name = "txtBugId";
            txtBugId.Size = new Size(219, 23);
            txtBugId.TabIndex = 5;
            txtBugId.Text = "195110";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(78, 105);
            label5.Name = "label5";
            label5.Size = new Size(69, 15);
            label5.TabIndex = 6;
            label5.Text = "BUG_NAME";
            // 
            // txtBugName
            // 
            txtBugName.Location = new Point(153, 105);
            txtBugName.Multiline = true;
            txtBugName.Name = "txtBugName";
            txtBugName.Size = new Size(573, 44);
            txtBugName.TabIndex = 7;
            txtBugName.Text = "The itext-searchable text in an output PDF file alignment position incorrect.";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(56, 158);
            label6.Name = "label6";
            label6.Size = new Size(91, 15);
            label6.TabIndex = 8;
            label6.Text = "BUG_SOLUTION";
            // 
            // txtBugSolution
            // 
            txtBugSolution.Location = new Point(153, 155);
            txtBugSolution.Multiline = true;
            txtBugSolution.Name = "txtBugSolution";
            txtBugSolution.Size = new Size(573, 71);
            txtBugSolution.TabIndex = 9;
            txtBugSolution.Text = "Correctly search for a keyword and verify the alignment of the word's position in the searchable PDF.";
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(631, 392);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(95, 47);
            btnCreate.TabIndex = 14;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // txtFilesForDrop
            // 
            txtFilesForDrop.Location = new Point(153, 312);
            txtFilesForDrop.Multiline = true;
            txtFilesForDrop.Name = "txtFilesForDrop";
            txtFilesForDrop.Size = new Size(573, 74);
            txtFilesForDrop.TabIndex = 13;
            txtFilesForDrop.Text = "jniidenginejar-2.2.0.jar, jniidengine.dll,idextract_signature.xml,bundle_idmax_server.se,id-extract.properties";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(9, 312);
            label7.Name = "label7";
            label7.Size = new Size(138, 15);
            label7.TabIndex = 12;
            label7.Text = "FILE_FOLDER_FOR_DROP";
            // 
            // hfReadme
            // 
            AcceptButton = btnCreate;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(744, 450);
            Controls.Add(txtFilesForDrop);
            Controls.Add(label7);
            Controls.Add(btnCreate);
            Controls.Add(txtBugSolution);
            Controls.Add(label6);
            Controls.Add(txtJarsForDrop);
            Controls.Add(txtBugName);
            Controls.Add(label3);
            Controls.Add(label5);
            Controls.Add(txtReleaseVersion);
            Controls.Add(txtBugId);
            Controls.Add(label2);
            Controls.Add(label4);
            Controls.Add(txtOosId);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "hfReadme";
            Text = "HF Readme create";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtOosId;
        private TextBox txtReleaseVersion;
        private Label label2;
        private TextBox txtJarsForDrop;
        private Label label3;
        private Label label4;
        private TextBox txtBugId;
        private Label label5;
        private TextBox txtBugName;
        private Label label6;
        private TextBox txtBugSolution;
        private Button btnCreate;
        private TextBox txtFilesForDrop;
        private Label label7;
    }
}