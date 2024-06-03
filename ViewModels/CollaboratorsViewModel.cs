using ProTaskManager.ViewModels;
using ProTaskMangers02.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTaskMangers02.ViewModels
{
    public class CollaboratorsViewModel : BaseViewModel
    {
        public ObservableCollection<Collaborator> Collaborators { get; set; }

        public CollaboratorsViewModel()
        {
            // Initialize Collaborators collection
            Collaborators = new ObservableCollection<Collaborator>();
            LoadCollaborators(); // Load collaborators from database
        }

        private void LoadCollaborators()
        {
            // Load collaborators from the database and add them to Collaborators collection
            // Example:
            // Collaborators = new ObservableCollection<Collaborator>(await App.Database.GetCollaboratorsAsync());
        }
    }
}
