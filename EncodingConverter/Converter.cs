using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace ConvertToEncoding.EncodingConverter
{
    public static class Converter
    {
        public static string[] Convert(string BasePath, Encoding WantedEncoding)
        {
            return Convert(BasePath, null, WantedEncoding);
        }

        public static string[] Convert(string BasePath, string[] Extensions, Encoding WantedEncoding)
        {
            return Convert(new ConverterParams { BasePath = BasePath, Extensions = Extensions, WantedEncoding = WantedEncoding });
        }

        public static string[] Convert(ConverterParams Parameters)
        {
            List<string> fileExtensions = Parameters.Extensions == null ? new List<string>() : new List<string>(Parameters.Extensions);
            fileExtensions.ForEach(new Action<string>(delegate(string item)
            {
                if (!item.StartsWith("."))
                    fileExtensions[fileExtensions.IndexOf(item)] = "." + item;
            }));

            List<FileInfo> files = new List<FileInfo>();
            foreach (var file in new DirectoryInfo(Parameters.BasePath).GetFiles("*", SearchOption.AllDirectories))
            {
                if (fileExtensions.Count > 0 && !fileExtensions.Contains(file.Extension))
                    continue;
                files.Add(file);
            }

            files.ForEach(new Action<FileInfo>(delegate(FileInfo file)
            {
                Encoding current = GetFileEncoding(file.FullName);
                if (!ConvertSingleFile(file, Parameters.WantedEncoding))
                    files.Remove(file);
            }));

            return (from fi in files
                    select fi.FullName).ToArray();
        }

        public static bool ConvertSingleFile(string FileFullPath, Encoding WantedEncoding)
        {
            return ConvertSingleFile(new FileInfo(FileFullPath), WantedEncoding);
        }

        public static bool ConvertSingleFile(FileInfo file, Encoding WantedEncoding)
        {
            Encoding current = GetFileEncoding(file.FullName);
            if (current == WantedEncoding)
                return false;
            string contents = File.ReadAllText(file.FullName, current);
            File.WriteAllText(file.FullName, contents, WantedEncoding);
            return true;
        }

        //http://www.personalmicrocosms.com/Pages/dotnettips.aspx?c=15&t=17#tip
        public static Encoding GetFileEncoding(string FileName)
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
