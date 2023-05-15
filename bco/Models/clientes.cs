using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace bco.Models
{
    public class clientesVM
    {
        public int idUsuario { get; set; }
        public string Nombre { get; set; }
        public string dni { get; set; }
        public string email { get; set; }
        public int cuenta { get; set; }
        public int cuil { get; set; }
        public string password { get; set; }       

    }
}