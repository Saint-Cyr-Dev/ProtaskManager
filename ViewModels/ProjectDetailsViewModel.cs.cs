using ProTaskMangers02.Models;
using ProTaskManager.ViewModels;
using System;
using System.Threading.Tasks;

namespace ProTaskMangers02.ViewModels
{
    public class ProjectDetailsViewModel : BaseViewModel
    {
        private Project _project;

        public Project Project
        {
            get => _project;
            set => SetProperty(ref _project, value);
        }

        public ProjectDetailsViewModel(int projectId)
        {
            Task.Run(async () => await LoadProject(projectId));
        }

        private async Task LoadProject(int projectId)
        {
            try
            {
                Project = await App.Database.GetProjectAsync(projectId) ?? throw new Exception("Projet non trouvé.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors du chargement du projet : {ex.Message}");
            }
        }
    }
}
