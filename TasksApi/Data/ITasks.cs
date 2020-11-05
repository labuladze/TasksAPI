using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasksApi.Model;

namespace TasksApi.Data
{
   public interface ITasks
    {
        IEnumerable<Tasks> GetAllTasks();

    }
}
