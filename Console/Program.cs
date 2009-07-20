using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ConvertToEncoding.Console
{
    class Program
    {
        const string StarLine = "********************************************************************************";

        static void Main(string[] args)
        {
            /*
             * WantedEncoding (mandatory)
             * Extensions CSV array of complete file paths
             * BasePath
             * SingleFile
             * Help
             */
            if (args == null || args.Length == 0)
            {
                PrintHelpMessage();
                return;
            }
            var compiledArgs = new CommandLine.Utility.Arguments(args);
            if (!string.IsNullOrEmpty(compiledArgs["Help"]))
            {
                PrintHelpMessage();
                return;
            }
            string wantedEncodingString = compiledArgs["WantedEncoding"];
            if (string.IsNullOrEmpty(wantedEncodingString))
            {
                PrintWantedEncodingNeeded();
                return;
            }

            Encoding wantedEncoding = Encoding.GetEncoding(wantedEncodingString);

            string singleFile = compiledArgs["SingleFile"];
            string basePath = compiledArgs["BasePath"];

            if (string.IsNullOrEmpty(singleFile) && string.IsNullOrEmpty(basePath))
            {
                PrintSingleOrBasePathNeeded();
                return;
            }

            if (!string.IsNullOrEmpty(singleFile))
            {
                if (!File.Exists(singleFile))
                {
                    PrintFileMissing(singleFile);
                    return;
                }
                if (ConvertToEncoding.EncodingConverter.Converter.ConvertSingleFile(singleFile, wantedEncoding))
                {
                    PrintFileModified(singleFile, wantedEncodingString);
                    return;
                }
                else
                {
                    PrintFileNotModified(singleFile, wantedEncodingString);
                    return;
                }
            }
            //If we got here, base path is not null
            string[] Extensions = null;
            string extensionParam = compiledArgs["Extensions"];
            if (!string.IsNullOrEmpty(extensionParam))
            {
                Extensions = extensionParam.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            }

            string[] modified = ConvertToEncoding.EncodingConverter.Converter.Convert(new
                ConvertToEncoding.EncodingConverter.ConverterParams
                {
                    BasePath = basePath,
                    WantedEncoding = wantedEncoding,
                    Extensions = Extensions
                });

            PrintModifiedN(basePath, modified, wantedEncodingString);
        }

        #region PrinterHelpers

        private static void PrintModifiedN(string basePath, string[] modified, string wantedEncodingString)
        {
            if (modified != null && modified.Length > 0)
            {
                var lines = new List<string>();
                lines.Add("");
                lines.AddRange(modified);
                lines.Add("");
                lines.Add(StarLine);
                lines.Add("");
                lines.Add(string.Format("Modified {0} file{1} to {2} in the '{3}' folder",
                        modified.Length,
                        modified.Length > 1 ? "s" : "",
                        wantedEncodingString,
                        basePath));
                PrintMessage(lines.ToArray());
            }
            else
            {
                PrintMessage("No files modified..");
            }

        }

        private static void PrintFileNotModified(string singleFile, string wantedEncodingString)
        {
            PrintMessage(string.Format("The file '{0}' was already in the '{1}' encoding..", singleFile, wantedEncodingString));
        }

        private static void PrintFileModified(string singleFile, string wantedEncodingString)
        {
            PrintMessage(string.Format("The file '{0}' was was modified to the '{1}' encoding..", singleFile, wantedEncodingString));
        }

        private static void PrintFileMissing(string singleFile)
        {
            PrintMessage(string.Format("The file '{0}' is missing!", singleFile));
        }

        private static void PrintSingleOrBasePathNeeded()
        {
            PrintMessage("You need to specify either the SingleFile or the BasePath Parameter.. Run with -Help for more details");
        }

        private static void PrintWantedEncodingNeeded()
        {
            PrintMessage("You need to specify the WantedEncoding Parameter..");
        }

        private static void PrintHelpMessage()
        {
            var message = new string[]{
                "Convert To Encoding Utility Help",
                "",
                "Alters a text based file's encoding..",
                "",
                "Usage :",
                "ConvertToEncodingConsole -param1 /param2",
                "",
                "Note:",
                "Parameters can be prefixed either with '-' or '/'",
                "",
                "This utility can be used either for one specific file (see Single File Usage),",
                "or for several files (see Multiple File Usage)",
                "",
                StarLine,
                "",
                "Mandatory Parameter:",
                "",
                "WantedEncoding  -> name of encoding (E.g. utf-8/utf-16)",
                "",
                StarLine,
                "",
                "Multiple File Usage Parameters:",
                "",                
                "Extensions  -> Comma separated values of file extensions to use,",
                "               (E.g \"cs,js,txt\" etc)",
                "               (NOTE: not mandatory, will modify all files if empty/missing..)",
                "BasePath  -> Root Directory that the program will search for files to modify",
                "",
                StarLine,
                "",
                "Single File Usage Parameter:",
                "",
                "SingleFile  -> Full path to file to modify",
                "",
                StarLine,
                "",
                "Help  -> This help message.."};
            PrintMessage(message);
        }

        private static void PrintMessage(string Message)
        {
            PrintMessage(new string[] { Message });
        }

        private static void PrintMessage(string[] MessageLines)
        {
            System.Console.WriteLine(StarLine);
            System.Console.WriteLine("");
            foreach (string line in MessageLines)
            {
                System.Console.WriteLine(line);
            }
            System.Console.WriteLine("");
            System.Console.WriteLine(StarLine);
        }

        #endregion PrinterHelpers
    }
}
