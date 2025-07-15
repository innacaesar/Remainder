
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Remainder.Data;
using Remainder.Models;
using System.Collections.ObjectModel;

namespace Remainder.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {

        private readonly TodoDatabase _database;

        [ObservableProperty]
        private ObservableCollection<TodoItem> todoItems;

        [ObservableProperty]
        private string newTaskTitle; //for entry

        [ObservableProperty]
        private bool isCompleted;

        public MainViewModel()
        {
            _database = new TodoDatabase(); 
            LoadItems();

        }

        [RelayCommand]
        private async void LoadItems()
        {
            var items = await _database.GetItems();
            TodoItems = new ObservableCollection<TodoItem>(items);

           
        }

       

        [RelayCommand]
        private async void AddItem()
        {
            if (!string.IsNullOrEmpty(newTaskTitle))
            {
                var newItem = new TodoItem { Title = NewTaskTitle, IsCompleted = false };
                await _database.SaveItem(newItem);
                NewTaskTitle = "";
                LoadItems();
            }
        }

        [RelayCommand]
        private async void DeleteItem(TodoItem item)
        {
            await _database.DeleteItem(item);
            LoadItems(); 
        }

        [RelayCommand]
        private async void UpdateStatus(TodoItem item)
        {
            
                item.IsCompleted = IsCompleted;
                await _database.UpdateStatus(item);
               
            
            LoadItems();
        }

    }
}
