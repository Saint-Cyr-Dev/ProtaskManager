using ProTaskManager.ViewModels;
using System.Collections.ObjectModel;
using ProTaskManagers02.Models;

namespace ProTaskMangers02.ViewModels
{

    public class CollaboratorsViewModel : BaseViewModel
    {
        public ObservableCollection<Collaborator> Collaborators { get; set; }

        public CollaboratorsViewModel()
        {
            Collaborators = new ObservableCollection<Collaborator>();

            LoadCollaborators();
        }

        private void LoadCollaborators()
        {
            var collaborators = new List<Collaborator>
            {
                new Collaborator { Id = 1, Name = "John Doe", Role = "Developer", Email = "john.doe@example.com" },
                new Collaborator { Id = 2, Name = "Jane Smith", Role = "Designer", Email = "jane.smith@example.com" },
                new Collaborator { Id = 3, Name = "Mike Johnson", Role = "Tester", Email = "mike.johnson@example.com" }
            };

            foreach (var collaborator in collaborators)
            {
                Collaborators.Add(collaborator);
            }
        }
    }
}
