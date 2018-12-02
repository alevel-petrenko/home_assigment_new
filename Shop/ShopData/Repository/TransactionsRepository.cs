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
    public interface ITransactionsRepository
    {
        int Add(Transactions transaction);

        void Update(Transactions transaction);

        void Delete(int id);

        List<Transactions> GetAll();

        Transactions Get(int id);
    }

    class TransactionsRepository : ITransactionsRepository
    {
        readonly string connectionString = @"Data Source=PETRENKOPC\SQLEXPRESS;Initial Catalog=Shop;Integrated Security=True";

        public int Add(Transactions transaction)
        {
            string sqlExpression = "Transactions_Insert";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlExpression, conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@ClientId",
                    Value = transaction.ClientId
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Amount",
                    Value = transaction.Amount
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Date",
                    Value = transaction.Date
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@IsDeleted",
                    Value = transaction.IsDeleted
                });
                var result = (int)command.ExecuteScalar();
            }
            return transaction.Id;
        }

        public void Update(Transactions transaction)
        {
            string sqlExpression = "Transactions_Update";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlExpression, conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@ClientId",
                    Value = transaction.ClientId
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Amount",
                    Value = transaction.Amount
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Date",
                    Value = transaction.Date
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@IsDeleted",
                    Value = transaction.IsDeleted
                });
                var result = command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            string sqlExpression = "Transactions_Delete";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlExpression, conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id,
                });
                var result = command.ExecuteNonQuery();
            }
        }

        public Transactions Get(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                var command = new SqlCommand($"SELECT * FROM Client where Id = {id}", conn);
                var reader = command.ExecuteReader();
                Transactions tr = new Transactions();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        tr.Id = reader.GetInt32(0);
                        tr.ClientId = reader.GetInt32(1);
                        tr.Date = reader.GetDateTime(2);
                        tr.Amount = reader.GetFloat(3);
                        tr.IsDeleted = reader.GetBoolean(4);
                        tr.Client = new Client();
                    }
                }
                return tr;
            }
        }

        public List<Transactions> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("SELECT * FROM [Client]", conn);
                var reader = command.ExecuteReader();
                List<Transactions> transactions = null;

                var dataTable = new DataTable();
                dataTable.Load(reader);

                foreach (DataRow dr in dataTable.Rows)
                {
                    var tr = new Transactions();

                    tr.Id = int.Parse(dr["Id"].ToString());
                    tr.ClientId = int.Parse(dr["ClientId"].ToString());
                    tr.Date = DateTime.Parse(dr["Date"].ToString());
                    tr.Amount = float.Parse(dr["Amount"].ToString());
                    tr.IsDeleted = bool.Parse(dr["IsDeleted"].ToString());
                    tr.Client = new Client();
                    transactions.Add(tr);
                }
                return transactions;
            }
        }
    }
}
