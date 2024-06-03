using ProTaskMangers02.Models;
using ProTaskManager.ViewModels;
using System.Threading.Tasks;

namespace ProTaskMangers02.ViewModels
{
    public class ProjectDetailsViewModel : BaseViewModel
    {
        private Project _project;

        public Project Project
        {
            get { return _project; }
            set { SetProperty(ref _project, value); }
        }

        public ProjectDetailsViewModel(int projectId)
        {
            _ = LoadProject(projectId); // Charger les détails du projet depuis la base de données
        }

        private async System.Threading.Tasks.Task LoadProject(int projectId) =>
            // Charger les détails du projet depuis la base de données en utilisant projectId
            Project = await App.Database.GetProjectAsync(projectId);
    }
}
