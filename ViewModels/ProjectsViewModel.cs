using ProTaskManager.Services; // Assurez-vous que le bon namespace est inclus
using ProTaskManager.ViewModels;
using ProTaskMangers02.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ProTaskMangers02.ViewModels
{
    public class ProjectsViewModel : BaseViewModel
    {
        public ObservableCollection<Project> Projects { get; set; }

        public ProjectsViewModel()
        {
            // Initialize Projects collection
            Projects = new ObservableCollection<Project>();
            _ = LoadProjects(); // Load projects from database
        }

        private async System.Threading.Tasks.Task LoadProjects()
        {
            // Load projects from the database and add them to Projects collection
            var database = new DatabaseHelper("your_db_path.db3"); // Assurez-vous de passer le bon chemin de base de données
            Projects = new ObservableCollection<Project>(await database.GetProjectsAsync());
        }
    }
}
