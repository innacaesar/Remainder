﻿
using SQLite;
namespace Remainder.Models
{
    public class TodoItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Title { get; set; }

        public bool IsCompleted {  get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
