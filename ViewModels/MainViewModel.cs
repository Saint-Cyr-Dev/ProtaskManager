using ProTaskManager.Models;
using ProTaskManager.Data;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProTaskManager.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        private readonly AppDbContext _context;

        public ObservableCollection<Project> Projects { get; private set; }

        public ICommand AddProjectCommand { get; }

        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _description;
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        private DateTime _startDate = DateTime.Now;
        public DateTime StartDate
        {
            get => _startDate;
            set => SetProperty(ref _startDate, value);
        }

        private DateTime _endDate = DateTime.Now;
        public DateTime EndDate
        {
            get => _endDate;
            set => SetProperty(ref _endDate, value);
        }

        public HomePageViewModel(AppDbContext context)
        {
            _context = context;

            Projects = new ObservableCollection<Project>();

            AddProjectCommand = new Command(async () => await AddProjectAsync());

            LoadProjectsAsync();
        }

        private async Task LoadProjectsAsync()
        {
            try
            {
                var projects = await _context.Projects.ToListAsync();
                Projects.Clear();
                Projects.AddRange(projects);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors du chargement des projets : {ex.Message}");
            }
        }

        private async Task AddProjectAsync()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Name))
                {
                    Console.WriteLine("Le nom du projet est requis.");
                    return;
                }

                var newProject = new Project
                {
                    Name = Name,
                    Description = Description,
                    StartDate = StartDate,
                    EndDate = EndDate
                };

                _context.Projects.Add(newProject);
                await _context.SaveChangesAsync();

                Projects.Add(newProject);

                Name = string.Empty;
                Description = string.Empty;
                StartDate = DateTime.Now;
                EndDate = DateTime.Now;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de l'ajout du projet : {ex.Message}");
            }
        }
    }
}
