using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace soundboard
{
    internal class File
    {
        private string _path { get; set; }
        private string _file__name { get; set; }
        public File(string path, string file_name) {
            this._path = path;
            this._file__name = file_name;
        }
    }
}
