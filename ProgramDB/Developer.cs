using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHandler
{    /// <summary>
     /// Шаблон данных о разработчиках
     /// </summary>
    class Developer : IElement
    {
        public int idDeveloper { get; set; }
        public string NameRus { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string OfficialSite { get; set; }
        public string Image { get; set; }

    }
}
