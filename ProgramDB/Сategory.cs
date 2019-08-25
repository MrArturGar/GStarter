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
    public class Category : IElement
    {

        public int IdCatalog { get; set; }
        public string NameRus { get; set; }
        public string NameOrig { get; set; }
        public string ShortDescription { get; set; }
        private string Description { get; set; }
        public string Image { get; set; }
        public int IdParent { get; set; }

        public Category(int _idCatalog,string _rusName, string _name, string _short_description, string _description, string _image, int _idParent)
        {
            this.IdCatalog = _idCatalog;
            this.NameRus = _rusName;
            this.NameOrig = _name;
            this.ShortDescription = _short_description;
            this.Description = _description;
            this.Image = _image;
            this.IdParent = _idParent;
        }
    }
}
