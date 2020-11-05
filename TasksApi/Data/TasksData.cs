using Microsoft.AspNetCore.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasksApi.Model;
using System.Data.SqlClient;
using System.Data;

namespace TasksApi.Data
{
    public class TasksData : ITasks
    {
        private readonly SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-2CSILTI\PC;Initial Catalog=Tasks;Integrated Security=True");
        
        IEnumerable<Tasks> ITasks.GetAllTasks()
        {   // Gets Tasks from dtabase
            List<Tasks> list = new List<Tasks>();
            SqlCommand cmd = new SqlCommand($"GetTasks", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var task = new Tasks();
                    task.id = Convert.ToInt32(reader["task_ID"]);
                    task.description = reader["description"].ToString();
                    task.creationDate = reader["creation_date"].ToString();
                    task.dueDate = reader["due_date"].ToString();
                    task.performedDate = reader["performed_date"].ToString();
                    task.status = reader["Status"].ToString();
                    list.Add(task);
                }
            }
            //  Gets employees and Adds  to specific task 
            foreach (var item in list)
            {
                SqlCommand cmd2 = new SqlCommand($"getTaskByID", connection);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("ID", item.id);
                using (SqlDataReader reader = cmd2.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        item.employees.Add(reader["full_name"].ToString());
                    }
                }
            }            
            connection.Close();
            return list;            
        }
    }
}
