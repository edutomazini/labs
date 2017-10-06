using LlabsDomain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace LlabsRepository
{
    public class RepositoryEmployee
    {
        string ConnectionString = "";
        public RepositoryEmployee()
        {
            //para rodar os testes, descomente a linha abaixo e comente a seguinte (coloque o caminho correto do BD)
            //ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\eduar\\Source\\Repos\\labs\\LlabsAPI\\ManagerEmployee\\App_Data\\LlabEmployee.mdf; Integrated Security = True";
            ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = |DataDirectory|\\LlabEmployee.mdf; Integrated Security = True";
        }

        public List<Employee> List()
        {
            try
            {
                var Employees = new List<Employee>();
                using (var connection = new SqlConnection(ConnectionString))
                {
                    using (var cmd = new SqlCommand("SelectEmployee", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            Employees.Add(
                                new Employee()
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Name = Convert.ToString(reader["Name"]),
                                    Email = Convert.ToString(reader["Email"]),
                                    Department = reader["Department"].ToString()
                                });
                        }
                    }
                }

                return Employees;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int Insert(Employee value)
        {
            int Id = 0;
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    using (var cmd = new SqlCommand("InsertEmployee", connection))
                    {
                        cmd.Parameters.AddWithValue("@Name", value.Name);
                        cmd.Parameters.AddWithValue("@Email", value.Email);
                        cmd.Parameters.AddWithValue("@Department", value.Department);
                        cmd.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        reader.Read();

                        Id = Convert.ToInt32(reader["Id"]);

                    }
                }
                return Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int Delete(int Id)
        {
            try
            {
                int i = 0;
                using (var connection = new SqlConnection(ConnectionString))
                {
                    using (var cmd = new SqlCommand("DeleteEmployee", connection))
                    {

                        cmd.Parameters.AddWithValue("@Id", Id);
                        cmd.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        i = cmd.ExecuteNonQuery();
                    }
                }
                return i;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
