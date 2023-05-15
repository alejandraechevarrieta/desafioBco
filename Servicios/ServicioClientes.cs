using bco;
using bco.Model;
using bco.Models;
using System;
using System.Linq;

namespace bco.Servicios
{   
    public class ServicioClientes : IDisposable
    {
        private readonly bancoEntities1 db = new bancoEntities1();
        //sin función, se usará para distintos usos de clientes
        public bool VerificarFecha(DateTime? fecha)
        {            
            bool value = false;            
            return value;
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}

