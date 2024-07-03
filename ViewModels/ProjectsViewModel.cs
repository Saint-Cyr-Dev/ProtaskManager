using ProTaskManager.Services;
using ProTaskManager.ViewModels;
using ProTaskMangers02.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ProTaskMangers02.ViewModels
{
    public class ProjectsViewModel : BaseViewModel
    {
        private ObservableCollection<Project> _projects;
        public ObservableCollection<Project> Projects
        {
            get { return _projects; }
            set { SetProperty(ref _projects, value); }
        }

        private readonly DatabaseHelper _database;

        public ProjectsViewModel(DatabaseHelper database)
        {
            _database = database ?? throw new ArgumentNullException(nameof(database));

            Projects = new ObservableCollection<Project>();

            Task.Run(async () => await LoadProjects());
        }

        private async Task LoadProjects()
        {
            try
            {
                var projects = await _database.GetProjectsAsync();

                Projects.Clear();

                foreach (var project in projects)
                {
                    Projects.Add(project);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors du chargement des projets : {ex.Message}");
            }
        }
    }
}
