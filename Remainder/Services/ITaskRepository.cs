using Remainder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remainder.Services
{
    public interface ITaskRepository
    {
        Task<int> SaveItem(TodoItem task);
        Task<int> DeleteItem(TodoItem task);
        Task<List<TodoItem>> GetItems();
        Task<int> UpdateStatus(TodoItem item);

    }
}
