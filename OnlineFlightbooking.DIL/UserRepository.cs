using OnilneFlightBooking.Entity;
using OnlineFlightbooking.DIL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace OnlineFlightbooking.DAL
{
    public class UserRepository
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

        public static List<UserEntity>RegisterUser()
        {
            UserContext userContext = new UserContext();
            return userContext.UserEntity.ToList();
        }
        public static Int16 ValidateLogin(UserEntity user)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open();
                    string sql = "SP_LOGIN";
                    SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlParameter param = new SqlParameter("@MOBILENUMBER",user.Mobile);
                    sqlCommand.Parameters.Add(param);
                    param = new SqlParameter("@PASSWORD",user.Password);
                    sqlCommand.Parameters.Add(param);
                    string Role = sqlCommand.ExecuteScalar().ToString();
                    if (Role == "Admin")
                    {
                        return 1;
                    }
                    else if (Role == "user")
                    {
                        return 2;
                    }
                    else
                    {
                        return 0;
                    }
                }
                catch (Exception)
                {
                    return 0;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }
        public static Boolean RegisterUser(UserEntity user)
        {
            int row = 0;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open();
                    string sql = "SP_USER_PROC_INSERT";
                    using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                    {
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter param = new SqlParameter("@NAME", user.Name);
                        sqlCommand.Parameters.Add(param);
                        param = new SqlParameter("@MOBILENUMBER", user.Mobile);
                        sqlCommand.Parameters.Add(param);
                        param = new SqlParameter("@DOB", user.Dob);
                        sqlCommand.Parameters.Add(param);
                        param = new SqlParameter("@SEX", user.Sex);
                        sqlCommand.Parameters.Add(param);
                        param = new SqlParameter("@USERADDRESS", user.UserAddress);
                        sqlCommand.Parameters.Add(param);
                        param = new SqlParameter("@PASSWORD", user.Password);
                        sqlCommand.Parameters.Add(param);
                        row = sqlCommand.ExecuteNonQuery();
                    }
                    if (row > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }
        //public static DataTable ViewFlightDetails()
        //{
        //    string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        //    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
        //    {
        //        sqlConnection.Open();
        //        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * from flightdb", sqlConnection);
        //        DataTable dataTable = new DataTable();
        //        sqlDataAdapter.Fill(dataTable);
        //        return dataTable;
        //    }
        //}
    }
}
