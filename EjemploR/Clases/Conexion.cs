using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Windows.Forms;
using System.Collections;

namespace EjemploR.Clases
{
    public class Conexion
    {
        static String servidor = "127.0.0.1";
        static String puerto = "27017";

        public static MongoClient cliente = new MongoClient("mongodb://" + servidor + ":" + puerto);

        private MongoClient establecerConexion()
        {
            try
            {
                List<String> NombresBasesDatos = cliente.ListDatabaseNames().ToList();

                foreach(var db in NombresBasesDatos)
                {
                    //MessageBox.Show("Se pudo conectar correctamente a la base de datos: "+ db.ToString());
                }
            }
            catch(MongoClientException e)
            {
                //MessageBox.Show("No se logró conectar a MongoDB. Error: "+e.ToString());
            }
            return cliente;
        }

        public int buscar()
        {
            var client = new MongoClient();
            var bd = client.GetDatabase("Proyecto");
            var collection = bd.GetCollection<Registros>("agosto");

            var consumoAgosto = collection
                .Aggregate()
                .Group(u => u.doble_carta,
                ac => new {
                    id = ac.Key,
                    total = ac.Sum(u => 1)
                });

            var AgostoGrupo = consumoAgosto.ToList();

            int resultado = 0;
            foreach (var group in AgostoGrupo)
            {
                resultado+=(group.id * group.total);
            }

            return resultado;
        }

        public bool agregar(string nombre, string raza, string coleccion)
        {
            establecerConexion();
            var bdActual = cliente.GetDatabase("ejemplo");
            var collection = bdActual.GetCollection<Registros>(coleccion);
            //var nuevoElemento = new Registros { Nombre = nombre, Raza = raza };
            //collection.InsertOne(nuevoElemento);
            return true;
        }

        public List<Registros> obtenerLista(string coleccion)
        {
            //MessageBox.Show(coleccion);
            establecerConexion();
            var bdActual = cliente.GetDatabase("ejemplo");
            var collection = bdActual.GetCollection<Registros>(coleccion);
            var resultado = IMongoCollectionExtensions.AsQueryable(collection).ToList();
            return resultado;
        }
        public void editar(string nombre, string raza, ObjectId id, string coleccion)
        {
            establecerConexion();
            var bdActual = cliente.GetDatabase("ejemplo");
            var collection = bdActual.GetCollection<Registros>(coleccion);
            var filtro = Builders<Registros>.Filter.Eq("Id",id);
            var update = Builders<Registros>.Update.Set("Nombre", nombre).Set("Raza",raza);
            collection.UpdateOne(filtro,update);
        }
        public void borrar(string nombre, string raza, ObjectId id, string coleccion)
        {
            establecerConexion();
            var bdActual = cliente.GetDatabase("ejemplo");
            var collection = bdActual.GetCollection<Registros>(coleccion);
            var filtro = Builders<Registros>.Filter.Eq("Id", id);
            collection.DeleteOne(filtro);
        }
    }
}
