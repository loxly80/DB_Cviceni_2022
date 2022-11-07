using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DB_Cviceni_2022
{
    public class SqlRepository
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Cviceni_2022;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<Clovek> GetLidi()
        {
            List<Clovek> result = new List<Clovek>();
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using(SqlCommand sqlCommand = connection.CreateCommand())
                {
                    sqlCommand.CommandText = "select * from Lidi";
                    using(SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            result.Add(new Clovek()
                            {
                                ID = Convert.ToInt32(sqlDataReader["ID"]),
                                FirstName = sqlDataReader["FirstName"].ToString(),
                                LastName = sqlDataReader["LastName"].ToString(),
                                Email = sqlDataReader["Email"].ToString(),
                                Phone = sqlDataReader["Phone"].ToString()
                            });
                        }
                    }
                }
                connection.Close();
            }
            return result;
        }

        public void DeleteClovek(Clovek clovek)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand sqlCommand = connection.CreateCommand())
                {
                    sqlCommand.CommandText = $"delete from Lidi where ID={clovek.ID}";
                    sqlCommand.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void DeleteClovek(string id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand sqlCommand = connection.CreateCommand())
                {
                    sqlCommand.CommandText = $"delete from Lidi where ID={id}";
                    sqlCommand.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}
