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
    public class Category
    {

        public int idCatalog { get; set; }
        public string rusName { get; set; }
        public string name { get; set; }
        private string short_description { get; set; }
        private string description { get; set; }
        private string image { get; set; }
        public int IdParent { get; set; }

        public Category(int _idCatalog,string _rusName, string _name, string _short_description, string _description, string _image, int _idParent)
        {
            this.idCatalog = _idCatalog;
            this.rusName = _rusName;
            this.name = _name;
            this.short_description = _short_description;
            this.description = _description;
            this.image = _image;
            this.IdParent = _idParent;
        }
    }
}
