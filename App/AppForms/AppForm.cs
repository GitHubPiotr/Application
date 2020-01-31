using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using App.AppForms;

namespace App
{
    public partial class AppForm : System.Windows.Forms.Form
    {
        private string connectionString;
        private SqlConnection sqlConnection;
        public AppForm()
        {
            // connection string of local database
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mielc\source\repos\App\App\Database\Database.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);

            InitializeComponent();
            RefreshDataGridView();

            // DataError handler
            dataGridView.DataError += new DataGridViewDataErrorEventHandler(dataGridView_DataError);
            // Disable Ids column
            dataGridView.Columns[0].ReadOnly = true;
            dataGridView.AllowUserToAddRows = false;
        }

        private void RefreshDataGridView()
        {
            // Show content of [Students] table
            try
            {
                sqlConnection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Students", sqlConnection);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                dataGridView.DataSource = dataTable;
                sqlConnection.Close();
            }
            catch
            {
                MessageBox.Show("Cannot get data from Database!");
                if (sqlConnection.State == ConnectionState.Open) sqlConnection.Close();
            }           
        }

        private void AddStudentButton_Click(object sender, EventArgs e)
        {
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand;

                sqlCommand = new SqlCommand("INSERT INTO[dbo].[Students]([FirstName], [LastName], [BirthDate], [IndexNumber]) " +
                    "VALUES(@FirstName, @LastName, @BirthDate, @IndexNumber)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("FirstName", textBox1.Text);
                sqlCommand.Parameters.AddWithValue("LastName", textBox2.Text);
                sqlCommand.Parameters.AddWithValue("BirthDate", Convert.ToDateTime(textBox3.Text).Date.ToString("yyyy-MM-dd"));
                sqlCommand.Parameters.AddWithValue("IndexNumber", textBox4.Text);

                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();

                RefreshDataGridView();
            }
            catch
            {
                MessageBox.Show("Invaild input data!");
                if (sqlConnection.State == ConnectionState.Open) sqlConnection.Close();
            }
        }

        private void RemoveStudentButton_Click(object sender, EventArgs e)
        {        
            try
            { 
                SqlCommand sqlCommand;
                sqlConnection.Open();

                DataGridViewRow selectedRow = dataGridView.CurrentCell.OwningRow;
                int studentId = Int16.Parse(selectedRow.Cells[0].Value.ToString());

                // Delete all Student Grades
                sqlCommand = new SqlCommand("DELETE FROM Grades WHERE StudentId = @StudentId", sqlConnection);
                sqlCommand.Parameters.AddWithValue("StudentId", studentId);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

                // Then delete the Student
                sqlCommand = new SqlCommand("DELETE FROM Students WHERE Id = @StudentId", sqlConnection);
                sqlCommand.Parameters.AddWithValue("StudentId", studentId);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();
                // Show result
                RefreshDataGridView();
            } 
            catch
            {
                MessageBox.Show("No row selected to remove!");
                if (sqlConnection.State == ConnectionState.Open) sqlConnection.Close();
            }
        }

        private void GradesButton_Click(object sender, EventArgs e)
        {
            // Open new Form
            GradesForm addGradeForm = new GradesForm(sqlConnection);
            addGradeForm.ShowDialog();
            RefreshDataGridView();
        }

        // DataGridView error handler
        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;

            string txt = "Error with " + dataGridView.Columns[e.ColumnIndex].HeaderText + "\n\n" + e.Exception.Message;
            MessageBox.Show(txt, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            e.Cancel = false;
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand sqlCommand;
                sqlConnection.Open();

                if (comboBox1.Text == null) return;

                // If selected column is [BirthDate] convert "Phrase" to DateTime.ToString()
                if (comboBox1.Text == "BirthDate")
                {
                    sqlCommand = new SqlCommand("SELECT * FROM Students WHERE BirthDate=@Phrase", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("Phrase", Convert.ToDateTime(TextBox.Text).Date.ToString("yyyy-MM-dd"));
                }
                else
                {
                    sqlCommand = new SqlCommand("SELECT * FROM Students WHERE " + comboBox1.Text + " LIKE @Phrase", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("Phrase", TextBox.Text);
                }

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable databaseRecord = new DataTable();
                sqlDataAdapter.Fill(databaseRecord);
                dataGridView.DataSource = databaseRecord;

                sqlConnection.Close();
            }
            catch
            {
                MessageBox.Show("Text field empty or wrong text format!");
                if (sqlConnection.State == ConnectionState.Open) sqlConnection.Close();
            }

        }

        // Reset search result
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SqlCommand sqlCommand;
                sqlConnection.Open();

                int row = e.RowIndex;
                int column = e.ColumnIndex;
                string cellValue = dataGridView.Rows[row].Cells[column].Value.ToString();

                DataGridViewRow selectedRow = dataGridView.CurrentCell.OwningRow;
                int studentId = Int16.Parse(selectedRow.Cells[0].Value.ToString());

                // If selected DateTime column(BirthDate) convert "Value" to DateTime.ToString()
                if (column == 3)
                {
                    sqlCommand = new SqlCommand("UPDATE Students SET BirthDate=@Value WHERE Id=@StudentId", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("Value", Convert.ToDateTime(cellValue).Date.ToString("yyyy-MM-dd"));
                    sqlCommand.Parameters.AddWithValue("StudentId", studentId);

                }
                // If selected IndexNumber column convert "Value" to int
                else if (column == 4)
                {
                    sqlCommand = new SqlCommand("UPDATE Students SET IndexNumber=@Value WHERE Id=@StudentId", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("Value", Int32.Parse(cellValue));
                    sqlCommand.Parameters.AddWithValue("StudentId", studentId);
                }
                else
                {
                    sqlCommand = new SqlCommand("UPDATE Students SET " + dataGridView.Columns[column].Name + "=@Value WHERE Id=@StudentId", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("Value", cellValue);
                    sqlCommand.Parameters.AddWithValue("StudentId", studentId);
                }

                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch
            {
                MessageBox.Show("Cannot UPDATE Database!");
                if (sqlConnection.State == ConnectionState.Open) sqlConnection.Close();

            }
            // Show result
            RefreshDataGridView();
        }
    }

}      