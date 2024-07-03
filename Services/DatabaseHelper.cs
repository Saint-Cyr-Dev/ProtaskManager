using SQLite;
using ProTaskMangers02.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProTaskManager.Services
{
    public class DatabaseHelper
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseHelper(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            InitializeDatabaseAsync().Wait();
        }

        private async Task InitializeDatabaseAsync()
        {
            try
            {
                await Task.Run(async () =>
                {
                    await _database.CreateTableAsync<Project>().ConfigureAwait(false);
                    await _database.CreateTableAsync<TaskModel>().ConfigureAwait(false);
                    await _database.CreateTableAsync<Collaborator>().ConfigureAwait(false);
                }).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de l'initialisation de la base de données : {ex.Message}");
                throw;
            }
        }

        // Projets

        public async Task<List<Project>> GetProjectsAsync()
        {
            try
            {
                return await _database.Table<Project>().ToListAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la récupération des projets : {ex.Message}");
                throw;
            }
        }

        public async Task<Project> GetProjectAsync(int id)
        {
            try
            {
                return await _database.Table<Project>().Where(p => p.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la récupération du projet avec l'ID {id} : {ex.Message}");
                throw;
            }
        }

        public async Task<int> SaveProjectAsync(Project project)
        {
            try
            {
                return project.Id != 0 ? await _database.UpdateAsync(project).ConfigureAwait(false) :
                                         await _database.InsertAsync(project).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de l'enregistrement du projet : {ex.Message}");
                throw;
            }
        }

        public async Task<int> DeleteProjectAsync(Project project)
        {
            try
            {
                return await _database.DeleteAsync(project).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la suppression du projet : {ex.Message}");
                throw;
            }
        }

        // Tâches

        public async Task<List<TaskModel>> GetTasksAsync()
        {
            try
            {
                return await _database.Table<TaskModel>().ToListAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la récupération des tâches : {ex.Message}");
                throw;
            }
        }

        public async Task<TaskModel> GetTaskAsync(int id)
        {
            try
            {
                return await _database.Table<TaskModel>().Where(t => t.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la récupération de la tâche avec l'ID {id} : {ex.Message}");
                throw;
            }
        }

        public async Task<int> SaveTaskAsync(TaskModel task)
        {
            try
            {
                return task.Id != 0 ? await _database.UpdateAsync(task).ConfigureAwait(false) :
                                         await _database.InsertAsync(task).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de l'enregistrement de la tâche : {ex.Message}");
                throw;
            }
        }

        public async Task<int> DeleteTaskAsync(TaskModel task)
        {
            try
            {
                return await _database.DeleteAsync(task).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la suppression de la tâche : {ex.Message}");
                throw;
            }
        }

        // Collaborateurs

        public async Task<List<Collaborator>> GetCollaboratorsAsync()
        {
            try
            {
                return await _database.Table<Collaborator>().ToListAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la récupération des collaborateurs : {ex.Message}");
                throw;
            }
        }

        public async Task<Collaborator> GetCollaboratorAsync(int id)
        {
            try
            {
                return await _database.Table<Collaborator>().Where(c => c.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la récupération du collaborateur avec l'ID {id} : {ex.Message}");
                throw;
            }
        }

        public async Task<int> SaveCollaboratorAsync(Collaborator collaborator)
        {
            try
            {
                return collaborator.Id != 0 ? await _database.UpdateAsync(collaborator).ConfigureAwait(false) :
                                               await _database.InsertAsync(collaborator).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de l'enregistrement du collaborateur : {ex.Message}");
                throw;
            }
        }

        public async Task<int> DeleteCollaboratorAsync(Collaborator collaborator)
        {
            try
            {
                return await _database.DeleteAsync(collaborator).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la suppression du collaborateur : {ex.Message}");
                throw;
            }
        }
    }
}
