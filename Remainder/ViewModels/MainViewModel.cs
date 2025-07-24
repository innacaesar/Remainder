
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Remainder.Helper;
using Remainder.Models;
using Remainder.Services;
using System.Collections.ObjectModel;
using System.Globalization;

namespace Remainder.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {

        //private readonly TodoDatabase _database;
        private readonly ITaskRepository _repository;

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

        [ObservableProperty]
        private string colorComplete = "#FF0000"; // Default color for not completed tasks
        public MainViewModel(ITaskRepository task) //parameter injection for repository
        {
           //_database = new TodoDatabase();
            _repository = task;
            LoadItems();

        }


        [RelayCommand]
        private async void LoadItems()
        {
            var items = await _repository.GetItems();
            TodoItems = new ObservableCollection<TodoItem>(items);


        }



        [RelayCommand]
        private async void AddItem()
        {
            if (!string.IsNullOrEmpty(newTaskTitle))
            {
                var newItem = new TodoItem { Title = NewTaskTitle, IsCompleted = false, CreatedDate = DateTime.UtcNow };
                await _repository.SaveItem(newItem);
                NewTaskTitle = "";
                LoadItems();
            }
        }

        [RelayCommand]
        private async void DeleteItem(TodoItem item)
        {
            await _repository.DeleteItem(item);
            LoadItems();
        }


        [RelayCommand]
        public async Task ToggleComplete(TodoItem item)
        {
            item.IsCompleted = !item.IsCompleted;

            //not working without converters:
            //CompleteIcon = item.IsCompleted ? FontHelper.COMPLETE_ICON : FontHelper.NOT_COMPLETE_ICON; // Update icon based on completion status
           // ColorComplete = item.IsCompleted ? "#00FF00" : "#FF0000"; // Change color based on completion status
            await _repository.UpdateStatus(item);
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
