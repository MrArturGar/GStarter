using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHandler
{
    /// <summary>
    /// Шаблон данных о категории
    /// </summary>
    class Category
    {
        public int idCatalog { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string image { get; set; }

    }
}
