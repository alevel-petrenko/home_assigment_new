using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopData.Repository
{
    class ClientRepository
    {
        //using Sql
        //SQLCommand для хранимок
        //models are used as a parameter
        //реализовать все энпоинты

        private readonly string _path = "";

        public int Add (Client client)
        {
            using (var conn = new SqlConnection(_path))

                return 0;
        }

        public void Update (int id)
        {

        }

        public void Delete (int id)
        {

        }

        public Client Get (int id)
        {
            return new Client();
        }

        public List<Client> GetAll ()
        {
            return new List<Client>();
        }
    }
}
