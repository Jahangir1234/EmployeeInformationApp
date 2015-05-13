using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmployeeInformationApp.DAL;
using EmployeeInformationApp.MODEL;

namespace EmployeeInformationApp
{
    public partial class form : Form
    {
        public form()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Employee employee=new Employee();
            employee.name = nameTextBox.Text;
            employee.address = addressTextBox.Text;
            employee.email = emailTextBox.Text;
            employee.salary = Convert.ToDecimal(salaryTextBox.Text);
            EmployeeGateway employeeGateway=new EmployeeGateway();
            string msg = employeeGateway.SaveEmployee(employee);
            MessageBox.Show(msg);
           LoadGridView();
            ClearTextBox();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadGridView();
        }
        private void LoadGridView()
        {

            EmployeeGateway employeeGateway = new EmployeeGateway();
            List<Employee> employeelist = employeeGateway.EmployeelList();
            employeeGridview.DataSource = employeelist;

            
        }
        private void ClearTextBox()
        {
            nameTextBox.Text = string.Empty;
            addressTextBox.Text = string.Empty;
            emailTextBox.Text = string.Empty;
            salaryTextBox.Text = string.Empty;
           
        }

        private void employeeGridview_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                nameTextBox.Text = employeeGridview.Rows[e.RowIndex].Cells[0].Value.ToString();
                addressTextBox.Text = employeeGridview.Rows[e.RowIndex].Cells[1].Value.ToString();
                emailTextBox.Text = employeeGridview.Rows[e.RowIndex].Cells[2].Value.ToString();
                salaryTextBox.Text = employeeGridview.Rows[e.RowIndex].Cells[3].Value.ToString();
                }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            employee.name = nameTextBox.Text;
            employee.address = addressTextBox.Text;
            employee.email = emailTextBox.Text;
            employee.salary = Convert.ToDecimal(salaryTextBox.Text);
            EmployeeGateway employeeGateway = new EmployeeGateway();
            string msg = employeeGateway.UpdateEmployee(employee);
            MessageBox.Show(msg);
            LoadGridView();
            ClearTextBox();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            
           
            EmployeeGateway employeeGateway = new EmployeeGateway();
            string name = nameTextBox.Text;
            string msg = employeeGateway.DeleteEmployee(name);
            MessageBox.Show(msg);
            LoadGridView();
            ClearTextBox();

           
        }
    }
}
