using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace soundboard
{
    internal class File
    {

        private string _path {  get; set; }
        private string _fileName { get; set; }

        public File(string path, string fileName)
        {
            this._path = path;
            this._fileName = fileName;
        }
    }
}
