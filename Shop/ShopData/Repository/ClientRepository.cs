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

        //models are used as a parameter
        //реализовать все энпоинты

        readonly string connectionString = @"Data Source=PETRENKOPC\SQLEXPRESS;Initial Catalog=Shop;Integrated Security=True";

        public int Add (Client client)
        {
            string sqlExpression = "Client_Insert";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlExpression, conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(client);
                command.ExecuteScalar();
                // если нам не надо возвращать id
                //var result = command.ExecuteNonQuery();
            }
            return 0;
        }

        public void Update (int id)
        {
            string sqlExpression = "Client_Update";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlExpression, conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.;
                command.ExecuteScalar();
                // если нам не надо возвращать id
                //var result = command.ExecuteNonQuery();
            }
            return 0;
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
