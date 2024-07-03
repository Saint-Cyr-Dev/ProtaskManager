using ProTaskManager.Services;
using ProTaskManager.ViewModels;
using ProTaskMangers02.Models;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProTaskMangers02.ViewModels
{
    public class TaskDetailsViewModel : BaseViewModel
    {
        private TaskModel _task;

        public TaskModel Task
        {
            get { return _task; }
            set { SetProperty(ref _task, value); }
        }

        private readonly DatabaseHelper _database;

        public TaskDetailsViewModel(DatabaseHelper database, int taskId)
        {
            _database = database ?? throw new ArgumentNullException(nameof(database));

            Task.Run(async () => await LoadTask(taskId));
        }

        private async Task LoadTask(int taskId)
        {
            try
            {
                Task = await _database.GetTaskAsync(taskId);

                if (Task == null)
                {
                    await HandleTaskNotFound(taskId);
                }
            }
            catch (Exception ex)
            {
                await HandleException(ex);
            }
        }

        private async Task HandleTaskNotFound(int taskId)
        {
            await App.Current.MainPage.DisplayAlert("Erreur", $"La tâche avec l'ID {taskId} n'a pas été trouvée.", "OK");
        }

        private async Task HandleException(Exception ex)
        {
            await App.Current.MainPage.DisplayAlert("Erreur", $"Erreur lors du chargement de la tâche : {ex.Message}", "OK");
        }
    }
}
