using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ForexModel
{
    public static class MimeTypes
    {
        public static Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".pdf", "application/pdf"},
                {".zip", "application/x-zip-compressed"},
                {".csv", "text/csv"},
                {".doc", "application/msword"},
                {".htm", "text/html"},
                {".html", "text/html"},
            };
        }
    }
    

}
