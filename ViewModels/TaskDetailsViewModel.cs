using ProTaskManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTaskMangers02.ViewModels
{
    public class TaskDetailsViewModel : BaseViewModel
    {
        private Task _task;

        public Task Task
        {
            get { return _task; }
            set { SetProperty(ref _task, value); }
        }

        public TaskDetailsViewModel(int taskId)
        {
            LoadTask(taskId); // Load task details from database
        }

        private void LoadTask(int taskId)
        {
            // Load task details from the database using taskId
            // Example:
            // Task = await App.Database.GetTaskAsync(taskId);
        }
    }
}
