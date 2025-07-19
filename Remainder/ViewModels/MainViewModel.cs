
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Remainder.Data;
using Remainder.Models;
using Remainder.Helper;
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

        [ObservableProperty]
        private DateTime createdDate; //for date picker

        [ObservableProperty]
        private string completeIcon=FontHelper.NOT_COMPLETE_ICON;
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
                var newItem = new TodoItem { Title = NewTaskTitle, IsCompleted = false, CreatedDate = DateTime.UtcNow };
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
        public async Task ToggleComplete(TodoItem item)
        {
            item.IsCompleted = !item.IsCompleted;
            CompleteIcon = item.IsCompleted ? FontHelper.COMPLETE_ICON : FontHelper.NOT_COMPLETE_ICON;
            
            await _database.UpdateStatus(item);
            LoadItems();
        }
        [RelayCommand]
        public async Task ShowItem(TodoItem item)
        {
           // Console.WriteLine($"Item: {item.Title}, Completed: {item.IsCompleted}, Created Date: {item.CreatedDate}");
            await App.Current.MainPage.DisplayAlert("משימה", $"{item.Title}\n העם בוצע {item.IsCompleted}\n תאריך {item.CreatedDate}", "אישור");
           
        }

    }
}
