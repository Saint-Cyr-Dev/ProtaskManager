using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace ProTaskMangers02
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Project> Projects { get; set; }

        public MainPage()
        {
            InitializeComponent();

            Projects = new ObservableCollection<Project>
            {
                new Project { Title = "Project 1", EndDate = "01/01/2024", Status = "En cours..." },
                new Project { Title = "Project 2", EndDate = "02/02/2024", Status = "Terminé" }
            };

            // Binding Projects to the ListView
            var projectListView = new ListView
            {
                ItemsSource = Projects,
                ItemTemplate = new DataTemplate(() =>
                {
                    var grid = new Grid();
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

                    // Add row definition
                    grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

                    var titleLabel = new Label { StyleClass = new[] { "projectTitle" } };
                    var dateLabel = new Label { StyleClass = new[] { "projectDate" } };
                    var statusLabel = new Label { StyleClass = new[] { "projectStatus" } };

                    titleLabel.SetBinding(Label.TextProperty, "Title");
                    dateLabel.SetBinding(Label.TextProperty, "EndDate");
                    statusLabel.SetBinding(Label.TextProperty, "Status");

                    grid.Children.Add(titleLabel);
                    Grid.SetColumn(titleLabel, 0);
                    Grid.SetRow(titleLabel, 0);

                    grid.Children.Add(dateLabel);
                    Grid.SetColumn(dateLabel, 1);
                    Grid.SetRow(dateLabel, 0);

                    grid.Children.Add(statusLabel);
                    Grid.SetColumn(statusLabel, 2);
                    Grid.SetRow(statusLabel, 0);

                    return new ViewCell { View = grid };
                })
            };

            Content = new StackLayout
            {
                Children = { projectListView }
            };
        }

        private void InitializeComponent()
        {
            // Your existing implementation of InitializeComponent
        }

        public class Project
        {
            public required string Title { get; set; }
            public required string EndDate { get; set; }
            public required string Status { get; set; }
        }
    }
}
