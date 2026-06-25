using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CyberBot
{
    public class TaskManager
    {
        private string connectionString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;
                AttachDbFilename=|DataDirectory|\CyberbotDB.mdf;
                Integrated Security=True";

        //METHODS BELOW
        //Task
        public void AddTask(string title, string description, DateTime? reminderDate)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string sql = @"INSERT INTO CSTasks(Title, Desription, ReminderDate)

                VALUES 
                                
                (@Title, @Description, @ReminderDate)";

                MySqlCommand command = new MySqlCommand(sql, connection);

                command.Parameters.AddWithValue("@Title", title);

                command.Parameters.AddWithValue("@Description", description);

                command.Parameters.AddWithValue("@ReminderDate", (object?)reminderDate ?? DBNull.Value);

                command.ExecuteNonQuery();
            }
        }

        //get tasks
        public List<CSTasks> GetTasks()
        {
            List<CSTasks> tasks = new List<CSTasks>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT * FROM CSTasks";

                MySqlCommand command = new MySqlCommand(sql, connection);

                MySqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    tasks.Add(new CSTasks
                    {
                        TaskId = Convert.ToInt32(reader["TaskId"]),

                        Title = reader["Title"].ToString(),

                        Description = reader["Description"].ToString(),

                        ReminderDate = reader["ReminderDate"] == DBNull.Value
                                        ? (DateTime?)null 
                                        : Convert.ToDateTime(reader["ReminderDate"]),

                        Status = reader["Status"].ToString(),

                        DateCreated = Convert.ToDateTime(reader["DateCreated"])
                    });
                }
            }
            return tasks;
        }

        //comple tasks
        public void CompletedTasks(int taskId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string sql =
                @"UPDATE CSTasks 
                SET Status = 'Completed'
                WHERE TaskId = @TaskId";

                MySqlCommand command = new MySqlCommand(sql, connection);

                command.Parameters.AddWithValue("@TaskId", taskId);

                command.ExecuteNonQuery();
            }
        }
    }
}
