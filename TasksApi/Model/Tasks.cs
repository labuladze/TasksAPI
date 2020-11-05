using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TasksApi.Model
{
    public class Tasks
    {
        public Tasks()
        {
            employees = new List<string>();
        }
        public int id { get; set; }
        public string description { get; set; }
        public string creationDate { get; set; }
        public string dueDate { get; set; }
        public string performedDate { get; set; }
        public string status { get; set; }
        public List<string> employees { get; set; }
    }
}
