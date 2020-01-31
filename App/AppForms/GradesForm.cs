using System;
using System.Data;
using System.Data.SqlClient;

using System.Windows.Forms;

namespace App.AppForms
{
    public partial class GradesForm : Form
    {
        SqlConnection sqlConnection;

        public GradesForm(SqlConnection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
            InitializeComponent();
            InsertStudentIdsToComboBox();
            dataGridViewAddGrade.AllowUserToAddRows = false;
        }
        private void InsertStudentIdsToComboBox()
        {
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlConnection.Open();

            sqlCommand.CommandText = "SELECT Id FROM Students";
            
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataTable);

            StudentIdsComboBox.Items.Clear();
            foreach (DataRow dr in dataTable.Rows)
            {
                StudentIdsComboBox.Items.Add(dr["Id"].ToString());
            }
            dataGridViewAddGrade.ReadOnly = true;
        }
        
        private void RefreshDataGridView()
        {
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Grades WHERE StudentId = '" + 
                Int16.Parse(StudentIdsComboBox.Text) + "'", sqlConnection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridViewAddGrade.DataSource = dataTable;
            sqlConnection.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }

        private void AddGradeButton_Click(object sender, EventArgs e)
        {
            // Add Grade to selected Student id
            try
            {
                SqlCommand sqlCommand;
                sqlConnection.Open();

                sqlCommand = new SqlCommand("INSERT INTO [dbo].[Grades] ([StudentId], [Value], [Subject]) " +
                                            "VALUES(@StudentId, @Value, @Subject)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("StudentId", Int16.Parse(StudentIdsComboBox.Text));
                sqlCommand.Parameters.AddWithValue("Value", Int16.Parse(comboBox2.Text));
                sqlCommand.Parameters.AddWithValue("Subject", comboBox3.Text);
                
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

                RefreshDataGridView();
            }
            catch
            {
                MessageBox.Show("Invaild input data!");
            }
        }

        private void RemoveGradeButton_Click(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = CommandType.Text;

            // Delete Student's Grade
            try
            {   
                var cell = dataGridViewAddGrade.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridViewAddGrade.Rows[cell];
                int GradeId = Int16.Parse(selectedRow.Cells[0].Value.ToString());
          
                sqlCommand.CommandText = "DELETE FROM Grades WHERE Id = '" + GradeId + "' ";
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

                RefreshDataGridView();
            }
            catch
            {
                MessageBox.Show("No row selected to remove!");
            }
        }
    }
}
