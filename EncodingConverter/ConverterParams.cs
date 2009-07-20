using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConvertToEncoding.EncodingConverter
{
    public class ConverterParams
    {
        public Encoding WantedEncoding { get; set; }
        public string[] Extensions { get; set; }
        public string BasePath { get; set; }
    }
}
