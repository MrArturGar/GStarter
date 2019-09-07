using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHandler
{
    public interface IElement
    {
        int Id { get; set; }
        string NameRus { get; set; }
        string ShortDescription { get; set; }
        string Image { get; set; }
    }
}
