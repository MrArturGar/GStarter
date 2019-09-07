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
        public int Id { get; set; }
        public string NameOrig { get; set; }
        public string NameRus { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string IdCatalog { get; set; }
        public double Weight { get; set; }
        public string LinkSite { get; set; }
        public string LinkDownload { get; set; }
        public int IdDeveloper { get; set; }

        public Program(int _idProgram, string _nameOrig, string _nameRus, string _shortDescription, string _description, string _image, string _idCatalog, double _weight, string _linkSite, string _linkDownload, int _idDeveloper)
        {
            Id = _idProgram;
            NameOrig = _nameOrig;
            NameRus = _nameRus;
            ShortDescription = _shortDescription;
            Description = _description;
            Image = _image;
            IdCatalog = _idCatalog;
            Weight = _weight;
            LinkSite = _linkSite;
            LinkDownload = _linkDownload;
            IdDeveloper = _idDeveloper;
        }

    }
}
