using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ProgramDB
{
    /// <summary>
    /// Шаблон данных о программе
    /// </summary>
    public class Program
    {
        public int idProgram { get; set; }
        public string origName { get; set; }
        public string name { get; set; }
        public string shortDescription { get; set; }
        public string description { get; set; }
        public string Image { get; set; }
        public string idCatalog { get; set; }
        public double weight { get; set; }
        public string linkSite { get; set; }
        public string linkDownload { get; set; }
        public string idDeveloper { get; set; }

    }
}
