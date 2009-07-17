namespace ConvertToEncodingTool
{
    partial class ConvertToEncodingToolForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConvertToEncodingToolForm));
            this.comboBoxEncoding = new System.Windows.Forms.ComboBox();
            this.buttonChooseFolder = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.textBoxRootFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.buttonConvert = new System.Windows.Forms.Button();
            this.listBoxFileExtensions = new System.Windows.Forms.ListBox();
            this.textBoxExtension = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonAddExtension = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.labelSummary = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxEncoding
            // 
            this.comboBoxEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEncoding.FormattingEnabled = true;
            this.comboBoxEncoding.Location = new System.Drawing.Point(91, 112);
            this.comboBoxEncoding.Name = "comboBoxEncoding";
            this.comboBoxEncoding.Size = new System.Drawing.Size(121, 21);
            this.comboBoxEncoding.TabIndex = 4;
            // 
            // buttonChooseFolder
            // 
            this.buttonChooseFolder.Location = new System.Drawing.Point(218, 137);
            this.buttonChooseFolder.Name = "buttonChooseFolder";
            this.buttonChooseFolder.Size = new System.Drawing.Size(102, 23);
            this.buttonChooseFolder.TabIndex = 6;
            this.buttonChooseFolder.Text = "&Choose Folder";
            this.buttonChooseFolder.UseVisualStyleBackColor = true;
            this.buttonChooseFolder.Click += new System.EventHandler(this.buttonChooseFolder_Click);
            // 
            // textBoxRootFolder
            // 
            this.textBoxRootFolder.Location = new System.Drawing.Point(91, 139);
            this.textBoxRootFolder.Name = "textBoxRootFolder";
            this.textBoxRootFolder.Size = new System.Drawing.Size(121, 20);
            this.textBoxRootFolder.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Encoding";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(12, 139);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(62, 13);
            this.Label2.TabIndex = 3;
            this.Label2.Text = "Root Folder";
            // 
            // buttonConvert
            // 
            this.buttonConvert.Location = new System.Drawing.Point(91, 178);
            this.buttonConvert.Name = "buttonConvert";
            this.buttonConvert.Size = new System.Drawing.Size(121, 37);
            this.buttonConvert.TabIndex = 7;
            this.buttonConvert.Text = "Convert";
            this.buttonConvert.UseVisualStyleBackColor = true;
            this.buttonConvert.Click += new System.EventHandler(this.buttonConvert_Click);
            // 
            // listBoxFileExtensions
            // 
            this.listBoxFileExtensions.FormattingEnabled = true;
            this.listBoxFileExtensions.Location = new System.Drawing.Point(91, 37);
            this.listBoxFileExtensions.Name = "listBoxFileExtensions";
            this.listBoxFileExtensions.Size = new System.Drawing.Size(121, 69);
            this.listBoxFileExtensions.TabIndex = 2;
            // 
            // textBoxExtension
            // 
            this.textBoxExtension.Location = new System.Drawing.Point(91, 8);
            this.textBoxExtension.Name = "textBoxExtension";
            this.textBoxExtension.Size = new System.Drawing.Size(121, 20);
            this.textBoxExtension.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Add Extension";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "File Extensions";
            // 
            // buttonAddExtension
            // 
            this.buttonAddExtension.Location = new System.Drawing.Point(218, 5);
            this.buttonAddExtension.Name = "buttonAddExtension";
            this.buttonAddExtension.Size = new System.Drawing.Size(102, 23);
            this.buttonAddExtension.TabIndex = 1;
            this.buttonAddExtension.Text = "&Add";
            this.buttonAddExtension.UseVisualStyleBackColor = true;
            this.buttonAddExtension.Click += new System.EventHandler(this.buttonAddExtension_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(218, 37);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(102, 23);
            this.buttonRemove.TabIndex = 3;
            this.buttonRemove.Text = "&Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // labelSummary
            // 
            this.labelSummary.AutoSize = true;
            this.labelSummary.Location = new System.Drawing.Point(218, 190);
            this.labelSummary.Name = "labelSummary";
            this.labelSummary.Size = new System.Drawing.Size(0, 13);
            this.labelSummary.TabIndex = 3;
            // 
            // ConvertToEncodingToolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 240);
            this.Controls.Add(this.listBoxFileExtensions);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelSummary);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxExtension);
            this.Controls.Add(this.textBoxRootFolder);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonAddExtension);
            this.Controls.Add(this.buttonConvert);
            this.Controls.Add(this.buttonChooseFolder);
            this.Controls.Add(this.comboBoxEncoding);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConvertToEncodingToolForm";
            this.Text = "Convert To Encoding Tool";
            this.Load += new System.EventHandler(this.ConvertToTool_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxEncoding;
        private System.Windows.Forms.Button buttonChooseFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox textBoxRootFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.Button buttonConvert;
        private System.Windows.Forms.ListBox listBoxFileExtensions;
        private System.Windows.Forms.TextBox textBoxExtension;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonAddExtension;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Label labelSummary;
    }
}

