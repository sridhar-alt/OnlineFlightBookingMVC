using OnilneFlightBooking.Entity;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace OnlineFlightbooking.DAL
{
    public class UserRepository
    {
        //public static Int16 ValidateLogin(string mobile, string password)
        //{
        //    string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        //    SqlConnection sqlConnection = new SqlConnection(connectionString);
        //    sqlConnection.Open();
        //    string sql = "USER_PROC_LOGIN";
        //    SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
        //    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
        //    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
        //    {
        //        if (dataReader.HasRows)
        //        {
        //            while (dataReader.Read())
        //            {
        //                if ((dataReader.GetString(0) == mobile) && (dataReader.GetString(1) == password))
        //                {
        //                    return 1;
        //                }
        //            }
        //        }
        //    }
        //    sql = "USER_PROC_ADMINLOGIN";
        //    sqlCommand = new SqlCommand(sql, sqlConnection);
        //    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
        //    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
        //    {
        //        if (dataReader.HasRows)
        //        {
        //            while (dataReader.Read())
        //            {
        //                if ((dataReader.GetString(0) == mobile) && (dataReader.GetString(1) == password))
        //                {
        //                    return 2;
        //                }
        //            }
        //        }
        //    }
        //    return 0;
        //}
        public static Boolean RegisterUser(UserEntity user)
        {
            int row = 0;
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            string sql = "USER_PROC_INSERT";
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
                param = new SqlParameter("@MEMBERROLE", user.Role);
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
