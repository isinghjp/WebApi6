using System.Collections.Generic;
using System.Data.SqlClient;

namespace WebApi6.Models
{
    public class StudentRepository : IStudentRepository
    {
        private SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(DbAccess.ConnectionString);
            return connection;
        }
        public void AddStudent(Student student)
        {
            string sqlCmd = "usp_AddStudent";
            using (SqlConnection connection = GetConnection())
            {
                using(SqlCommand command = new SqlCommand(sqlCmd, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FirstName", student.FirstName);
                    command.Parameters.AddWithValue("@LastName", student.LastName);
                    command.Parameters.AddWithValue("@Email", student.Email);
                    command.Parameters.AddWithValue("@Mobile", student.Mobile);
                    command.Parameters.AddWithValue("@Address", student.Address);


                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
        }

        public void DeleteStudent(int id)
        {
            string sqlCmd = "usp_DeleteStudent";
            using (SqlConnection connection = GetConnection())
            {
                using (SqlCommand command = new SqlCommand(sqlCmd, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", id);

                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
        }

        public List<Student> GetAllStudents()
        {
            string sqlCmd = "usp_GetAllStudent";
            List <Student> students = new List<Student>();
            Student student = null;
            using (SqlConnection connection = GetConnection())
            {
                using (SqlCommand command = new SqlCommand(sqlCmd, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader reader=null;
                    command.Connection.Open();
                    reader = command.ExecuteReader();
                     while (reader.Read())
                    {
                        student = new Student();
                        student.ID = (int)reader["ID"];
                        student.FirstName = reader["FirstName"].ToString();
                        student.LastName = reader["LastName"].ToString();
                        student.Email = reader["Email"].ToString();
                        student.Mobile = reader["Mobile"].ToString();
                        student.Address = reader["Address"].ToString();
                        students.Add(student);
                    }
                    command.Connection.Close();
                }
            }
            return students;
        }

        public Student GetStudentById(int id)
        {
            string sqlCmd = "usp_GetStudentById";
            Student student = null;
            using (SqlConnection connection = GetConnection())
            {
                using (SqlCommand command = new SqlCommand(sqlCmd, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", id);

                    SqlDataReader reader = null;
                    command.Connection.Open();
                    reader = command.ExecuteReader();
                    bool result = reader.Read();
                    if(result)
                    {
                        student = new Student();
                        student.ID = (int)reader["ID"];
                        student.FirstName = reader["FirstName"].ToString();
                        student.LastName = reader["LastName"].ToString();
                        student.Email = reader["Email"].ToString();
                        student.Mobile = reader["Mobile"].ToString();
                        student.Address = reader["Address"].ToString();
                   }
                    command.Connection.Close();
                }
            }
            return student;
        }

        public void UpdateStudent(Student student)
        {
            string sqlCmd = "usp_UpdateStudent";
            using (SqlConnection connection = GetConnection())
            {
                using (SqlCommand command = new SqlCommand(sqlCmd, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", student.ID);
                    command.Parameters.AddWithValue("@FirstName", student.FirstName);
                    command.Parameters.AddWithValue("@LastName", student.LastName);
                    command.Parameters.AddWithValue("@Email", student.Email);
                    command.Parameters.AddWithValue("@Mobile", student.Mobile);
                    command.Parameters.AddWithValue("@Address", student.Address);


                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
        }
    }
}
