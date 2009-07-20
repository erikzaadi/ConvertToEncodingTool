using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace ConvertToEncoding.WinForm
{
    public partial class ConvertToEncodingToolForm : Form
    {
        private string[] AlteredFiles;
        public ConvertToEncodingToolForm()
        {
            InitializeComponent();
        }

        #region Form Events

        private void ConvertToTool_Load(object sender, EventArgs e)
        {
            foreach (EncodingInfo info in Encoding.GetEncodings())
            {
                comboBoxEncoding.Items.Add(info.Name);
            }
            comboBoxEncoding.SelectedIndex = comboBoxEncoding.Items.Count - 1;
        }

        private void buttonAddExtension_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxExtension.Text))
                return;

            string extension = textBoxExtension.Text.StartsWith(".") ? textBoxExtension.Text : "." + textBoxExtension.Text;

            if (!listBoxFileExtensions.Items.Contains(extension))
            {
                listBoxFileExtensions.Items.Add(extension);
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (listBoxFileExtensions.Items.Count > 0 &&
                listBoxFileExtensions.SelectedIndex != -1)
            {
                listBoxFileExtensions.Items.RemoveAt(listBoxFileExtensions.SelectedIndex);
            }
        }

        private void buttonChooseFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.Description = "Choose Root Folder";
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxRootFolder.Text = folderBrowserDialog1.SelectedPath;
            }
            folderBrowserDialog1.Description = "";
        }

        private void linkLabelShowFiles_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            folderBrowserDialog1.Description = "Choose log folder";
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                if (!Directory.Exists(folderBrowserDialog1.SelectedPath))
                {
                    MessageBox.Show(this, "The folder does not exist!", Text);
                }
                else
                {
                    using (var writer = File.CreateText(Path.Combine(folderBrowserDialog1.SelectedPath, "modified.log")))
                    {
                        foreach (string file in AlteredFiles)
                            writer.WriteLine(file);
                        writer.Close();
                    }
                }
            }
            folderBrowserDialog1.Description = "";

        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            linkLabelShowFiles.Visible = false;
            labelSummary.Text = "";
            labelSummary.ForeColor = Color.Black;
            if (string.IsNullOrEmpty(textBoxRootFolder.Text))
            {
                labelSummary.Text = "Please choose a root folder first..";
                labelSummary.ForeColor = Color.Red;

                return;
            }

            string[] Extensions = null;
            if (listBoxFileExtensions.Items.Count == 0)
            {
                if (MessageBox.Show(this, "You've not chosen any file extensions.\nDo you wish to alter all files?", this.Text, MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return;
            }
            else
            {
                Extensions = new string[listBoxFileExtensions.Items.Count];
                for (int x = 0; x < listBoxFileExtensions.Items.Count; x++)
                {
                    Extensions[x] = listBoxFileExtensions.Items[x].ToString();
                }

            }
            Encoding encoding = Encoding.GetEncoding(comboBoxEncoding.SelectedItem.ToString());

            Thread myThread = new Thread(new ParameterizedThreadStart(Threader));
            myThread.Start(new ConvertToEncoding.EncodingConverter.ConverterParams
            {
                BasePath = textBoxRootFolder.Text,
                WantedEncoding = encoding,
                Extensions = Extensions
            });

        }

        #endregion Form Events

        #region Thread Methods

        delegate void BackFromThread(string[] Modified);

        private void BackFromThreadMethod(string[] Modified)
        {
            labelSummary.Text = string.Format("Modified {0} files.", Modified.Length);
            linkLabelShowFiles.Visible = Modified.Length > 0;
            AlteredFiles = Modified;
        }

        private void Threader(object Params)
        {
            string[] modified = ConvertToEncoding.EncodingConverter.Converter.Convert((ConvertToEncoding.EncodingConverter.ConverterParams)Params);
            this.Invoke(new BackFromThread(BackFromThreadMethod), new object[] { modified });
        }

        #endregion Thread Methods
    }
}
