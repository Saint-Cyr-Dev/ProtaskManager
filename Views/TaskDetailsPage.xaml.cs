using ProTaskMangers02.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTaskMangers02.Views
{
    public partial class TaskDetailsPage : ContentPage
    {
        public TaskDetailsPage(int taskId)
        {
            InitializeComponent();
            BindingContext = new TaskDetailsViewModel(taskId);
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }
    }
}
