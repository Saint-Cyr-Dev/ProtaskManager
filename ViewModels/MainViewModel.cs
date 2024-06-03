using ProTaskMangers02.Models; // Add this line
using ProTaskManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTaskMangers02.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public ObservableCollection<Project> Projects { get; set; }

        public MainViewModel()
        {
            // Initialize Projects collection
            Projects = new ObservableCollection<Project>();
            LoadProjects(); // Load projects from database
        }

        private async void LoadProjects()
        {
            // Load projects from the database and add them to Projects collection
            // Example:
            Projects = new ObservableCollection<Project>(await App.Database.GetProjectsAsync());
        }
    }
}
