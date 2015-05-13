using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeInformationApp.DataBaseConnection;
using EmployeeInformationApp.MODEL;

namespace EmployeeInformationApp.DAL
{
    public class EmployeeGateway:Dbconnection
    {
        public string SaveEmployee(Employee employee)
        {
            SqlConnection connection = GetDBConnection();
            connection.Open();
            string insert = String.Format(
                "insert into tbl_employee  values ('{0}','{1}','{2}','{3}')",
                employee.name,
               employee.address,
               employee.email,
               employee.salary
                );
            SqlCommand command = new SqlCommand(insert,connection);
            
            command.ExecuteNonQuery();
            connection.Close();
            return "Employee Information Save Successfully.";
        }
        public List<Employee> EmployeelList()
        {
            SqlConnection connection = GetDBConnection();
            connection.Open();
            string select = "select * from tbl_employee";
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = select;
            SqlDataReader reader = command.ExecuteReader();
            List<Employee> employees = new List<Employee>();
            while (reader.Read())
            {
                Employee employee = new Employee();
                employee.name = reader[0].ToString();
                employee.address = reader[1].ToString();
                employee.email = reader[2].ToString();
                employee.salary = Convert.ToDecimal(reader[3].ToString());
                employees.Add(employee);

            }
            connection.Close();
            return employees;
        }
        public string UpdateEmployee(Employee employee)
        {
            SqlConnection connection = GetDBConnection();
            connection.Open();
            string update = String.Format(
                "Update tbl_employee Set Address='{1}',Email='{2}',Salary='{3}' where Name='{0}'",
                employee.name,
               employee.address,
               employee.email,
               employee.salary);
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = update;
            command.ExecuteNonQuery();
            connection.Close();

            return "Update Successfully";
        }

        public string DeleteEmployee(string name)
        {
            SqlConnection connection = GetDBConnection();
            connection.Open();
            string query =
                String.Format("Delete From tbl_employee  where Name='{0}'", name);
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = query;
            command.ExecuteNonQuery();
            connection.Close();

            return "Delete Successfully";
        }
    }
}
