using System.Data.SqlClient;

namespace EmployeeInformationApp.DataBaseConnection
{
    public  class Dbconnection
    {
        protected SqlConnection connection;

        protected SqlConnection GetDBConnection()
        {
            string connectionString = @"server=PC-301-25\SQLEXPRESS;database=JAHANGIR;Integrated Security=true;";
            connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            return connection;
        }
    }
}