using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ConvertToEncodingTool
{
    public partial class ConvertToEncodingToolForm : Form
    {
        public ConvertToEncodingToolForm()
        {
            InitializeComponent();
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
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxRootFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            labelSummary.Text = "";
            labelSummary.ForeColor = Color.Black;
            if (string.IsNullOrEmpty(textBoxRootFolder.Text))
            {
                labelSummary.Text = "Please choose a root folder first..";
                labelSummary.ForeColor = Color.Red;

                return;
            }

            if (listBoxFileExtensions.Items.Count == 0 &&
                MessageBox.Show(this, "You've not chosen any file extensions.\nDo you wish to alter all files?", this.Text, MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;

            Encoding encoding = Encoding.GetEncoding(comboBoxEncoding.SelectedItem.ToString());

            int altered = 0;

            foreach (var file in new DirectoryInfo(textBoxRootFolder.Text).GetFiles("*", SearchOption.AllDirectories))
            {
                if (listBoxFileExtensions.Items.Count > 0 && !listBoxFileExtensions.Items.Contains(file.Extension))
                    continue;
                string contents = File.ReadAllText(file.FullName, GetFileEncoding(file.FullName));
                File.WriteAllText(file.FullName, contents, encoding);
                ++altered;
            }
            labelSummary.Text = string.Format("Modified {0} files.", altered);
        }

        private void ConvertToTool_Load(object sender, EventArgs e)
        {
            foreach (EncodingInfo info in Encoding.GetEncodings())
            {
                comboBoxEncoding.Items.Add(info.Name);
            }
            comboBoxEncoding.SelectedIndex = comboBoxEncoding.Items.Count - 1;
        }

        //http://www.personalmicrocosms.com/Pages/dotnettips.aspx?c=15&t=17#tip
        public static Encoding GetFileEncoding(String FileName)
        // Return the Encoding of a text file.  Return Encoding.Default if no Unicode
        // BOM (byte order mark) is found.
        {
            Encoding Result = null;

            FileInfo FI = new FileInfo(FileName);

            FileStream FS = null;

            try
            {
                FS = FI.OpenRead();

                Encoding[] UnicodeEncodings = { Encoding.BigEndianUnicode, Encoding.Unicode, Encoding.UTF8 };

                for (int i = 0; Result == null && i < UnicodeEncodings.Length; i++)
                {
                    FS.Position = 0;

                    byte[] Preamble = UnicodeEncodings[i].GetPreamble();

                    bool PreamblesAreEqual = true;

                    for (int j = 0; PreamblesAreEqual && j < Preamble.Length; j++)
                    {
                        PreamblesAreEqual = Preamble[j] == FS.ReadByte();
                    }

                    if (PreamblesAreEqual)
                    {
                        Result = UnicodeEncodings[i];
                    }
                }
            }
            catch (System.IO.IOException)
            {
            }
            finally
            {
                if (FS != null)
                {
                    FS.Close();
                }
            }

            if (Result == null)
            {
                Result = Encoding.Default;
            }

            return Result;
        }
    }
}
