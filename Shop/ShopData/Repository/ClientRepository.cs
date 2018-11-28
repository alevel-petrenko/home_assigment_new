using Dapper;
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

        readonly string connectionString = @"Data Source=PETRENKOPC\SQLEXPRESS;Initial Catalog=Shop;Integrated Security=True";
        int value;
        public int Add (Client client)
        {
            string sqlExpression = "Client_Insert";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlExpression, conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@name",
                    Value = client.Name
                };
                command.Parameters.Add(nameParam);
                value = (int) command.ExecuteScalar();
                // если нам не надо возвращать id
                //var result = command.ExecuteNonQuery();
            }
            return value;
        }

        public void Update (int id, string name)
        {
            string sqlExpression = "Client_Update";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlExpression, conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@name",
                    Value = name
                };
                command.Parameters.Add(nameParam);

                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id
                };
                command.Parameters.Add(idParam);

                var result = command.ExecuteNonQuery();
            }
        }

        public void Delete (int id)
        {
            string sqlExpression = "Client_Delete";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlExpression, conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id
                };
                command.Parameters.Add(idParam);

                var result = command.ExecuteNonQuery();
            }
        }

        public Client Get(int id)
        {
            Client client = default;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string _getClientById = $"select * from [Client] where Id = {id}";

                client = conn.Query<Client>(_getClientById).FirstOrDefault();
                return client;
            }
        }

        public List<Client> GetAll ()
        {
            List<Client> clients;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string _getClients = $"select * from [Client]";

                clients = conn.Query<Client>(_getClients).ToList();
                return clients;
            }
        }
    }
}
