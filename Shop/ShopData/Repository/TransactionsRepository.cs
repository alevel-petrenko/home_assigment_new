using ShopData.DataModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopData.Repository
{
    class TransactionsRepository
    {
        public interface ITransactionsRepository
        {
            int Add(Transactions transaction);

            void Update(Transactions transaction);

            void Delete(int id);

            List<Transactions> GetAll();

            Transactions Get(int id);
        }

        class ClientRepository : ITransactionsRepository
        {
            readonly string connectionString = @"Data Source=PETRENKOPC\SQLEXPRESS;Initial Catalog=Shop;Integrated Security=True";
            int value;

            public int Add(Transactions transaction)
            {
                string sqlExpression = "Transactions_Insert";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(sqlExpression, conn);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlParameter nameParam = new SqlParameter
                    {
                        ParameterName = "@amount",
                        Value = transaction.Amount
                    };
                    command.Parameters.Add(nameParam);
                    value = (int)command.ExecuteScalar();
                    // если нам не надо возвращать id
                    //var result = command.ExecuteNonQuery();
                }
                return value;
            }

            public void Update(Client client)
            {
                string sqlExpression = "Client_Update";
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

                    SqlParameter idParam = new SqlParameter
                    {
                        ParameterName = "@id",
                        Value = client.Id
                    };
                    command.Parameters.Add(idParam);

                    var result = command.ExecuteNonQuery();
                }
            }

            public void Delete(int id)
            {
                string sqlExpression = "Client_Delete";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(sqlExpression, conn);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlParameter idParam = new SqlParameter
                    {
                        ParameterName = "@id",
                        Value = id,
                        SqlDbType = SqlDbType.NVarChar
                    };
                    command.Parameters.Add(idParam);

                    var result = command.ExecuteNonQuery();
                }
            }

            public Client Get(int id)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    var command = new SqlCommand("SELECT * FROM Client", conn);

                    var reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            int age = reader.GetInt32(2);
                        }
                    }

                    return null;
                }
            }

            public List<Client> GetAll()
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    var command = new SqlCommand("SELECT * FROM [Client]", conn);
                    var reader = command.ExecuteReader();
                    List<Client> clients = null;

                    var dataTable = new DataTable();
                    dataTable.Load(reader);

                    foreach (DataRow dr in dataTable.Rows)
                    {
                        var client = new Client();

                        client.Id = int.Parse(dr["Id"].ToString());
                        client.Name = dr["Name"].ToString();
                        client.IsDeleted = bool.Parse(dr["IsDeleted"].ToString());

                        clients.Add(client);
                    }

                    return clients;
                }
            }

            public void Update(Transactions transaction)
            {
                throw new NotImplementedException();
            }

            List<Transactions> ITransactionsRepository.GetAll()
            {
                throw new NotImplementedException();
            }

            Transactions ITransactionsRepository.Get(int id)
            {
                throw new NotImplementedException();
            }
        }
    }
}
