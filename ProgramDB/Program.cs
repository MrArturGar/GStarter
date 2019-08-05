using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DataHandler
{
    /// <summary>
    /// Шаблон данных о программе
    /// </summary>
    public class Program : IElement
    {
        public int IdProgram { get; set; }
        public string NameOrig { get; set; }
        public string NameRus { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string IdCatalog { get; set; }
        public double Weight { get; set; }
        public string LinkSite { get; set; }
        public string LinkDownload { get; set; }
        public string IdDeveloper { get; set; }

    }
}
