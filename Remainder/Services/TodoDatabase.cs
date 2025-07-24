
using Remainder.Models;
using Remainder.Services;
using SQLite;

namespace Remainder.Services
{    
    public class TodoDatabase : ITaskRepository
    {
        private readonly SQLiteAsyncConnection _connection;
        public TodoDatabase()
            {
                string dbPath = Path.Combine(FileSystem.AppDataDirectory, "Todo.db");//נבנה באופן אוטומטי בפעם הראשונה
                _connection = new SQLiteAsyncConnection(dbPath);
                _connection.CreateTableAsync<TodoItem>().Wait();
            }
          //לקבל את כל הרשומות בטבלה  
        public Task<List<TodoItem>> GetItems() 
            {

                return _connection.Table<TodoItem>().ToListAsync();

            }
        //הוספת או עדכון רשומה לטבלה
        //returns Id of new record
        public Task<int> SaveItem(TodoItem item)
            {
            if (item.Id == 0) //אין בטבלה
            {
                return _connection.InsertAsync(item);
            }
            return _connection.UpdateAsync(item); //אם קיים אז לעדכן

                  
            }
        //מחיקת רשומה מטבלה
        public Task<int> DeleteItem(TodoItem item)
            {
                return _connection.DeleteAsync(item);
            }

        //עדכון סטטוס של רשומה בטבלה    

        public Task<int> UpdateStatus(TodoItem item)
        {
            return _connection.UpdateAsync(item);
        }


    }
}