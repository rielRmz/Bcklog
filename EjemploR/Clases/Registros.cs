using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace EjemploR.Clases
{
    public class Registros
    {
        public ObjectId Id { get; set; }
        public int doble_carta { get; set; }
        public int carta { get; set; }
        public int oficio { get; set; }

    }
}
